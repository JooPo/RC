using System.Windows.Forms;

namespace RC_control
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.connectBox = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.WheelButton = new System.Windows.Forms.RadioButton();
            this.joyStickButton = new System.Windows.Forms.RadioButton();
            this.joypadButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.portBox = new System.Windows.Forms.TextBox();
            this.videoCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.fpsTextBox = new System.Windows.Forms.TextBox();
            this.rotTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.RCRaspis = new System.Windows.Forms.ListView();
            this.IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // connectBox
            // 
            this.connectBox.Location = new System.Drawing.Point(9, 22);
            this.connectBox.Margin = new System.Windows.Forms.Padding(2);
            this.connectBox.Name = "connectBox";
            this.connectBox.Size = new System.Drawing.Size(108, 20);
            this.connectBox.TabIndex = 0;
            this.connectBox.Text = "192.168.11.7";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(16, 333);
            this.connectButton.Margin = new System.Windows.Forms.Padding(2);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(60, 23);
            this.connectButton.TabIndex = 1;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // WheelButton
            // 
            this.WheelButton.AutoSize = true;
            this.WheelButton.Checked = true;
            this.WheelButton.Location = new System.Drawing.Point(13, 48);
            this.WheelButton.Name = "WheelButton";
            this.WheelButton.Size = new System.Drawing.Size(56, 17);
            this.WheelButton.TabIndex = 2;
            this.WheelButton.TabStop = true;
            this.WheelButton.Text = "Wheel";
            this.WheelButton.UseVisualStyleBackColor = true;
            // 
            // joyStickButton
            // 
            this.joyStickButton.AutoSize = true;
            this.joyStickButton.Location = new System.Drawing.Point(13, 72);
            this.joyStickButton.Name = "joyStickButton";
            this.joyStickButton.Size = new System.Drawing.Size(63, 17);
            this.joyStickButton.TabIndex = 3;
            this.joyStickButton.Text = "Joystick";
            this.joyStickButton.UseVisualStyleBackColor = true;
            // 
            // joypadButton
            // 
            this.joypadButton.AutoSize = true;
            this.joypadButton.Location = new System.Drawing.Point(13, 95);
            this.joypadButton.Name = "joypadButton";
            this.joypadButton.Size = new System.Drawing.Size(59, 17);
            this.joypadButton.TabIndex = 4;
            this.joypadButton.Text = "Joypad";
            this.joypadButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Port";
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(65, 170);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(100, 20);
            this.portBox.TabIndex = 6;
            this.portBox.Text = "5000";
            // 
            // videoCheckBox
            // 
            this.videoCheckBox.AutoSize = true;
            this.videoCheckBox.Checked = true;
            this.videoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.videoCheckBox.Location = new System.Drawing.Point(14, 147);
            this.videoCheckBox.Name = "videoCheckBox";
            this.videoCheckBox.Size = new System.Drawing.Size(88, 17);
            this.videoCheckBox.TabIndex = 7;
            this.videoCheckBox.Text = "Stream video";
            this.videoCheckBox.UseVisualStyleBackColor = true;
            this.videoCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Height";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Width";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "FPS";
            // 
            // heightTextBox
            // 
            this.heightTextBox.Location = new System.Drawing.Point(65, 197);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(100, 20);
            this.heightTextBox.TabIndex = 11;
            this.heightTextBox.Text = "1080";
            // 
            // widthTextBox
            // 
            this.widthTextBox.Location = new System.Drawing.Point(64, 224);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(100, 20);
            this.widthTextBox.TabIndex = 12;
            this.widthTextBox.Text = "1920";
            // 
            // fpsTextBox
            // 
            this.fpsTextBox.Location = new System.Drawing.Point(64, 251);
            this.fpsTextBox.Name = "fpsTextBox";
            this.fpsTextBox.Size = new System.Drawing.Size(100, 20);
            this.fpsTextBox.TabIndex = 13;
            this.fpsTextBox.Text = "30";
            // 
            // rotTextBox
            // 
            this.rotTextBox.Location = new System.Drawing.Point(64, 277);
            this.rotTextBox.Name = "rotTextBox";
            this.rotTextBox.Size = new System.Drawing.Size(100, 20);
            this.rotTextBox.TabIndex = 15;
            this.rotTextBox.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Rotation";
            // 
            // startButton
            // 
            this.startButton.Enabled = false;
            this.startButton.Location = new System.Drawing.Point(81, 333);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(60, 23);
            this.startButton.TabIndex = 16;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Enabled = false;
            this.disconnectButton.Location = new System.Drawing.Point(147, 333);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(75, 23);
            this.disconnectButton.TabIndex = 17;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // RCRaspis
            // 
            this.RCRaspis.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IP,
            this.Name});
            this.RCRaspis.Location = new System.Drawing.Point(176, 22);
            this.RCRaspis.Name = "RCRaspis";
            this.RCRaspis.Size = new System.Drawing.Size(200, 100);
            this.RCRaspis.TabIndex = 18;
            this.RCRaspis.UseCompatibleStateImageBehavior = false;
            this.RCRaspis.View = System.Windows.Forms.View.Details;
            this.RCRaspis.SelectedIndexChanged += new System.EventHandler(this.RCRaspis_SelectedIndexChanged);
            // 
            // IP
            // 
            this.IP.Text = "IP";
            this.IP.Width = 100;
            // 
            // Name
            // 
            this.Name.Text = "Name";
            this.Name.Width = 100;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 490);
            this.Controls.Add(this.RCRaspis);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.rotTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.fpsTextBox);
            this.Controls.Add(this.widthTextBox);
            this.Controls.Add(this.heightTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.videoCheckBox);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.joypadButton);
            this.Controls.Add(this.joyStickButton);
            this.Controls.Add(this.WheelButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.connectBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox connectBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.RadioButton joypadButton;
        private System.Windows.Forms.RadioButton joyStickButton;
        private System.Windows.Forms.RadioButton WheelButton;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox videoCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.TextBox fpsTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox rotTextBox;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.ListView RCRaspis;
        private System.Windows.Forms.ColumnHeader IP;
        private System.Windows.Forms.ColumnHeader Name;
    }
}

