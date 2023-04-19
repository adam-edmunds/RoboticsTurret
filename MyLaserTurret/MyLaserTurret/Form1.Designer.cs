namespace MyLaserTurret
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.port = new System.IO.Ports.SerialPort(this.components);
            this.GrabLabel = new System.Windows.Forms.Label();
            this.grabBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cameraCollection = new System.Windows.Forms.ComboBox();
            this.cameraButton = new System.Windows.Forms.Button();
            this.xLabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.xText = new System.Windows.Forms.TextBox();
            this.yText = new System.Windows.Forms.TextBox();
            this.modeCombo = new System.Windows.Forms.ComboBox();
            this.modeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // port
            // 
            this.port.PortName = "COM3";
            // 
            // GrabLabel
            // 
            this.GrabLabel.AutoSize = true;
            this.GrabLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrabLabel.Location = new System.Drawing.Point(279, 101);
            this.GrabLabel.Name = "GrabLabel";
            this.GrabLabel.Size = new System.Drawing.Size(185, 33);
            this.GrabLabel.TabIndex = 4;
            this.GrabLabel.Text = "isGrabbing: ";
            // 
            // grabBox
            // 
            this.grabBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grabBox.Location = new System.Drawing.Point(454, 96);
            this.grabBox.Name = "grabBox";
            this.grabBox.Size = new System.Drawing.Size(168, 44);
            this.grabBox.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(656, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 360);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // cameraCollection
            // 
            this.cameraCollection.FormattingEnabled = true;
            this.cameraCollection.Location = new System.Drawing.Point(656, 23);
            this.cameraCollection.Name = "cameraCollection";
            this.cameraCollection.Size = new System.Drawing.Size(380, 21);
            this.cameraCollection.TabIndex = 11;
            // 
            // cameraButton
            // 
            this.cameraButton.Location = new System.Drawing.Point(1043, 20);
            this.cameraButton.Name = "cameraButton";
            this.cameraButton.Size = new System.Drawing.Size(174, 23);
            this.cameraButton.TabIndex = 12;
            this.cameraButton.Text = "detect";
            this.cameraButton.UseVisualStyleBackColor = true;
            this.cameraButton.Click += new System.EventHandler(this.cameraButton_Click);
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel.Location = new System.Drawing.Point(279, 177);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(53, 33);
            this.xLabel.TabIndex = 13;
            this.xLabel.Text = "X: ";
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yLabel.Location = new System.Drawing.Point(279, 220);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(54, 33);
            this.yLabel.TabIndex = 14;
            this.yLabel.Text = "Y: ";
            // 
            // xText
            // 
            this.xText.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xText.Location = new System.Drawing.Point(338, 166);
            this.xText.Name = "xText";
            this.xText.Size = new System.Drawing.Size(168, 44);
            this.xText.TabIndex = 15;
            // 
            // yText
            // 
            this.yText.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yText.Location = new System.Drawing.Point(338, 215);
            this.yText.Name = "yText";
            this.yText.Size = new System.Drawing.Size(168, 44);
            this.yText.TabIndex = 16;
            // 
            // modeCombo
            // 
            this.modeCombo.FormattingEnabled = true;
            this.modeCombo.Location = new System.Drawing.Point(12, 51);
            this.modeCombo.Name = "modeCombo";
            this.modeCombo.Size = new System.Drawing.Size(186, 21);
            this.modeCombo.TabIndex = 17;
            this.modeCombo.SelectedIndexChanged += new System.EventHandler(this.modeCombo_SelectedIndexChanged);
            // 
            // modeLabel
            // 
            this.modeLabel.AutoSize = true;
            this.modeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modeLabel.Location = new System.Drawing.Point(52, 15);
            this.modeLabel.Name = "modeLabel";
            this.modeLabel.Size = new System.Drawing.Size(91, 33);
            this.modeLabel.TabIndex = 18;
            this.modeLabel.Text = "Mode";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1398, 561);
            this.Controls.Add(this.modeLabel);
            this.Controls.Add(this.modeCombo);
            this.Controls.Add(this.yText);
            this.Controls.Add(this.xText);
            this.Controls.Add(this.yLabel);
            this.Controls.Add(this.xLabel);
            this.Controls.Add(this.cameraButton);
            this.Controls.Add(this.cameraCollection);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.grabBox);
            this.Controls.Add(this.GrabLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.IO.Ports.SerialPort port;
        private System.Windows.Forms.Label GrabLabel;
        private System.Windows.Forms.TextBox grabBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cameraCollection;
        private System.Windows.Forms.Button cameraButton;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.TextBox xText;
        private System.Windows.Forms.TextBox yText;
        private System.Windows.Forms.ComboBox modeCombo;
        private System.Windows.Forms.Label modeLabel;
    }
}

