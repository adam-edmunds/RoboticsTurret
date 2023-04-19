using System;
using System.Windows.Forms;
using System.Diagnostics;
using Leap;
using Emgu.CV;
using Emgu.CV.Structure;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing;

namespace MyLaserTurret
{
    public partial class Form1 : Form, ILeapEventDelegate {

        // Setting up class variables
        private Controller controller;                                                                                      // Leap motion controller
        private LeapEventListener listener;                                                                                 // Listener for events thrown by Leap motion
        private string[] modes = new string[] { "manual", "automatic" };                                                    // Available modes for turret
        private string currentMode = "manual";                                                                              // Default mode when starting
        private CascadeClassifier faceCascade = new CascadeClassifier("./detection/haarcascade_frontalface_default.xml");   // Data on for face detection
        private FilterInfoCollection filter;                                                                                // Used to get all video devices
        private VideoCaptureDevice videoCaptureDevice;                                                                      // Hold which video device is in use
        private Stopwatch watch { get; set; }                                                                               // Used for rate limiting

        // Constructor for the class
        public Form1() {
            watch = Stopwatch.StartNew();
            InitializeComponent();
            this.controller = new Controller();
            this.listener = new LeapEventListener(this);
            controller.AddListener(listener);
            filter = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in filter) {
                cameraCollection.Items.Add(device.Name);
            }
            cameraCollection.SelectedIndex = 0;
            videoCaptureDevice = new VideoCaptureDevice();
        }

        // Event which is called when the form is loaded
        private void Form1_Load(object sender, EventArgs e) {
            port.Open();
            modeCombo.Items.AddRange(modes);
            modeCombo.SelectedIndex = 0;
        }

        // multi threaing function for invoking events notifications later [Abstract implementation Provided by Leap API]
        delegate void LeapEventDelegate(string EventName);

        // Handles all the LeapMotion events that are needed to function 
        public void LeapEventNotification(string EventName) {
            if (!this.InvokeRequired) {
                switch (EventName) {
                    case "onInit":
                        Debug.WriteLine("Init");
                        break;
                    case "onConnect":
                        Debug.WriteLine("Leap MotionConnected");
                        break;
                    case "onFrame":
                        detectHandPosition(this.controller.Frame());
                        break;
                }
            } else {
                BeginInvoke(new LeapEventDelegate(LeapEventNotification), new object[] { EventName });
            }
        }

        // when in manual mode detect if the right hand is available.
        // Get coords of the hand map them so arduino can understand and send coords to arduino
        // Check to see if hand in grabbing, if so shoot the laser
        public void detectHandPosition(Frame frame) {
            if (currentMode == "automatic") return;
            if (watch.ElapsedMilliseconds > 30) {
                watch = Stopwatch.StartNew();
                Hand hand = frame.Hands.Frontmost;
                if (!hand.IsValid) return;
                if (hand.IsLeft) return;
                InteractionBox iBox = frame.InteractionBox;
                Finger finger = hand.Fingers[1];
                Vector leapPoint = finger.StabilizedTipPosition;
                Vector normalizedPoint = iBox.NormalizePoint(leapPoint, false);

                bool isGrabbing = hand.GrabStrength == 1;

                grabBox.Text = isGrabbing.ToString();

                if (isGrabbing) {
                    port.Write("Shoot");
                    return;
                }

                float appX = normalizedPoint.x * 180;
                float appY = (1 - normalizedPoint.y) * 180;

                float mappedX = 180 - ExtensionMethods.Map(appX, -500, 500, 0, 180);
                float mappedY = 180 - ExtensionMethods.Map(appY, -160, 200, 0, 180);

                xText.Text = ((int)mappedX).ToString();
                yText.Text = ((int)mappedY).ToString();
                port.Write(String.Format("X{0}Y{1}", (int)mappedX, (int)mappedY));

            }
        }

        // Used to switch between camera sources during automatic mode
        private void cameraButton_Click(object sender, EventArgs e) {
            if (currentMode == "automatic") {
                videoCaptureDevice = new VideoCaptureDevice(filter[cameraCollection.SelectedIndex].MonikerString);
                videoCaptureDevice.NewFrame += Device_NewFrame;
                videoCaptureDevice.Start();
            }
        }

        // update method for when a new frame is rendered on the PictureBox
        // Takes the frame, converts it to an image
        // Runs the OpenCV model to find a face
        // Gets the coordinates of the first rectangle and sends the coords to the arsuino
        private void Device_NewFrame(object sender, NewFrameEventArgs EventArgs) {
            Bitmap bitmap = (Bitmap)EventArgs.Frame.Clone();
            Image<Bgr, byte> greyImage = new Image<Bgr, byte>(bitmap);

            Rectangle[] rectangles = faceCascade.DetectMultiScale(greyImage, 1.1, 1, minSize: new Size(150, 150));
            if (rectangles.Length == 0) return;

            float mappedX = 180 - ExtensionMethods.Map(rectangles[0].X, 0, 500, 0, 180);
            float mappedY = ExtensionMethods.Map(rectangles[0].Y, 0, 300, 60, 180);

            xText.Invoke(() => xText.Text = ((int)mappedX).ToString());
            yText.Invoke(() => yText.Text = ((int)mappedY).ToString());
            port.Write(String.Format("X{0}Y{1}", (int)mappedX, (int)mappedY));
            foreach (Rectangle rectangle in rectangles) {
                using (Graphics graphics = Graphics.FromImage(bitmap)) {
                    using (Pen pen = new Pen(Color.Red, 1)) {
                        graphics.DrawRectangle(pen, rectangle);
                    }
                }
            }
            pictureBox1.Image = bitmap;
        }

        // When closing the application stop / switch off the camera
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            if (videoCaptureDevice.IsRunning) {
                videoCaptureDevice.Stop();
            }
        }

        // When the drop down for modes is changed
        // Update the necessary variables
        // If switched to manual mode stop the camera and remove the frozen image
        private void modeCombo_SelectedIndexChanged(object sender, EventArgs e) {
            ComboBox comboBox = (ComboBox)sender;
            string selectedMode = (string)comboBox.SelectedItem;
            currentMode = selectedMode;
            if (selectedMode == "manual") {
                if (videoCaptureDevice.IsRunning) {
                    videoCaptureDevice.Stop();
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
            }
        }
    }

    // Helper functions to allow for multi threaded updates
    public static class ExtensionMethods {
        public static float Map(float value, int fromLow, int fromHigh, int toLow, int toHigh) {
            return (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;
        }

        public static void Invoke(this Control control, MethodInvoker mi) {
            control.Invoke(mi);
            return;
        }
    }

    // Interface that is required by Leap Motion API
    public interface ILeapEventDelegate {
        void LeapEventNotification(string EventName);
    }

    // Listener class that is required by Leap Motion API
    public class LeapEventListener : Listener {
        ILeapEventDelegate eventDelegate;

        public LeapEventListener(ILeapEventDelegate delegateObject) {
            this.eventDelegate = delegateObject;
        }
        public override void OnInit(Controller controller) {
            this.eventDelegate.LeapEventNotification("onInit");
        }
        public override void OnConnect(Controller controller) {
            this.eventDelegate.LeapEventNotification("onConnect");
        }
        public override void OnFrame(Controller controller) {
            this.eventDelegate.LeapEventNotification("onFrame");
        }
        public override void OnExit(Controller controller) {
            this.eventDelegate.LeapEventNotification("onExit");
        }
        public override void OnDisconnect(Controller controller) {
            this.eventDelegate.LeapEventNotification("onDisconnect");
        }
    }
}
