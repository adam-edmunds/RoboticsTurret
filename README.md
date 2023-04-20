# Robotics Laser Turret!!

This is an implementation for a laster turret that uses hand tracking or facial recognition to move a turret with a laser attached to it.

# Tech Stack

## Backend

For this project I used C# to interact with the GUI I made. The GUI was a Windows Forms App. I used Emgu.CV for facial recognition, Leap SDK for interacting with the Leap Motion Controller and AForge.Video for implementing the video stream.

## Hardware

For this project I used an arduino uno that with 2 servo motors and a laser module. I also bought a custom mounting bracket for my servo motots so they can move in the X and Y direction.
I also used a microsoft webcam in order to provide a video in / output for the app. In addition to the Leap Motion Control hand tracking sensor to achieve manual control.

# How to run

First you'll need to clone this repo. 

## Backend

To run the backend makesure you have the latest version of Visual Studio installed.
Once installed you need to install the software from this link (https://developer-archive.leapmotion.com/get-started?id=v3-developer-beta&platform=windows&version=3.2.1.45911) and run the installer.
Once installed follow the instructions here (https://developer-archive.leapmotion.com/documentation/csharp/devguide/Project_Setup.html#setting-up-a-windows-forms-or-wpf-project). This will allow for the C# program to interact with the leap motion controller.

## Hardware

Install the Arduino IDE and upload the program to the arduino.

# How to use

Once everything is connected and running, you can start the C# program.

<b>Note:</b> The Leap Motion Controller will only track the right hand.

# Useful Links

- [Emgu](https://www.emgu.com/wiki/index.php/Main_Page)
- [AForge](http://www.aforgenet.com/framework/samples/video.html)
- [Visual Studio](https://visualstudio.microsoft.com/)
- [Arduino IDE](https://www.arduino.cc/en/software)
