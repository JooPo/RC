using SlimDX;
using SlimDX.DirectInput;
using SlimDX.Windows;
using SlimDX.XInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace RC_control
{
    public partial class Form1 : Form
    {
        DirectInput Input = new DirectInput();
        SlimDX.DirectInput.Joystick wheel;
        Joystick[] Wheels;

        bool started = false;
        int camHeight = 90;
        int camWidth = 90;

        SocketClient client;
        System.Diagnostics.Process process = new System.Diagnostics.Process();
        System.Diagnostics.Process process2 = new System.Diagnostics.Process();

        // Constants
        const int ECHO_PORT = 8888;  // The Echo protocol uses port 7 in this sample
        const int QOTD_PORT = 17; // The Quote of the Day (QOTD) protocol uses port 17 in this sample

        public Form1()
        {
            InitializeComponent();
            WiFi_scanner ip_scanner = new WiFi_scanner(RCRaspis);
            ip_scanner.Ping_all();

        }

        public Joystick[] GetWheels()
        {
            List<SlimDX.DirectInput.Joystick> wheels = new List<Joystick>();
            foreach(DeviceInstance device in Input.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly))
            {
                try
                {
                    wheel = new Joystick(Input, device.InstanceGuid);
                    wheel.Acquire();
                    foreach(DeviceObjectInstance deviceObject in wheel.GetObjects())
                    {
                        if((deviceObject.ObjectType & ObjectDeviceType.Axis) !=0)
                        {
                            wheel.GetObjectPropertiesById((int)deviceObject.ObjectType).SetRange(-100, 0);
                        }
                    }
                    wheels.Add(wheel);
                }
                catch(DirectInputException)
                {

                }
            }
            return wheels.ToArray();
        }

        void wheelHandle(Joystick wheel, int id)
        {
            JoystickState state = new JoystickState();
            state = wheel.GetCurrentState();

            bool[] buttons = state.GetButtons();

            if (buttons[12] || buttons[11])
            {
                client.Send("0:0:0");
                System.Threading.Thread.Sleep(1000);
                System.Windows.Forms.Application.Exit();
            }

            int sendAcc = 0;
            int sendTurn = 0;

            int[] views = state.GetPointOfViewControllers();
    
            if (views[0] == 0)
                if(camHeight > 0)
                    camHeight = camHeight - 5;
            if (views[0] == 9000)
                if(camWidth > 0)
                    camWidth = camWidth - 5;
            if (views[0] == 18000)
                if(camHeight < 180)
                    camHeight = camHeight + 5;
            if (views[0] == 27000)
                if(camWidth < 180)
                    camWidth = camWidth + 5;

            if (WheelButton.Checked) {

                sendAcc = -state.RotationZ;
                if (state.Y < state.RotationZ)
                    sendAcc = state.Y;

                sendTurn = (state.X + 50) * 2;
            }
            else if (joyStickButton.Checked)
            {
                sendAcc = -state.Y * 2 - 100;
                sendTurn = (state.X + 50) * 2;
            }
            else if (joypadButton.Checked)
            {
                sendAcc = -state.Y * 2 - 100;
                sendTurn = (state.X + 50) * 2;
            }
            Debug.WriteLine("X: " + sendTurn.ToString());
            Debug.WriteLine("Z: " + sendAcc.ToString());

            if (!started)
            {
                if (sendAcc == 50)
                    return;
                else
                    started = true;
            }

            string sendString = "1:" + sendAcc.ToString() + ":" + sendTurn.ToString() + ":" + camHeight.ToString() + ":" + camWidth.ToString();
            string result = client.Send(sendString);

            if (buttons[1])
            {
                camHeight = 90;
                camWidth = 90;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Joystick[] wheel = GetWheels();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            Debug.WriteLine("timer1_Tick_1");
            for (int i = 0; i < Wheels.Length;i++)
            {
                wheelHandle(Wheels[i], i);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var process1 in Process.GetProcessesByName("gst-launch-1.0"))
            {
                Debug.WriteLine("killed");
                process1.Kill();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ip = connectBox.Text;
            Debug.WriteLine(ip);

            string port = portBox.Text;
            string width = widthTextBox.Text;
            string height = heightTextBox.Text;
            string fps = fpsTextBox.Text;
            string rotation = rotTextBox.Text;

            startButton.Text = "Start";
            string result;

            if (client == null)
            {
                client = new SocketClient();
                result = client.Connect(ip, ECHO_PORT);
                GetWheels();
                Wheels = GetWheels();
            }
            string sendString = "";
            if (videoCheckBox.Checked == true)
            {
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = @"/c h:\gstreamer\1.0\x86\bin\gst-launch-1.0 udpsrc port=" + port + " ! application/x-rtp, payload=96 ! rtpjitterbuffer ! rtph264depay ! avdec_h264 ! fpsdisplaysink sync=false text-overlay=false";
               
                process.StartInfo = startInfo;
                process.Start();
                sendString = "0:" + port + ":" + height + ":" + width + ":" + fps + ":" + rotation;
            }
            else
            {
                sendString = "0:0:1";
            }
            result = client.Send(sendString);
            
            startButton.Enabled = true;
            disconnectButton.Enabled = true;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (chk.Checked)
            {
                portBox.Enabled = true;
                widthTextBox.Enabled = true;
                heightTextBox.Enabled = true;
                fpsTextBox.Enabled = true;
                rotTextBox.Enabled = true;
            }
            else {
                portBox.Enabled = false;
                widthTextBox.Enabled = false;
                heightTextBox.Enabled = false;
                fpsTextBox.Enabled = false;
                rotTextBox.Enabled = false;
            }
        }
        
        private void startButton_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
                startButton.Text = "Pause";
                connectButton.Enabled = false;
            }
            else
            {
                timer1.Enabled = false;
                startButton.Text = "Continue";
                string sendString = "1:0:0:90:90";
                string result = client.Send(sendString);
                connectButton.Enabled = true;
            }
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            string sendString = "1:0:0:90:90";
            string result = client.Send(sendString);
            sendString = "0:0:0";
            timer1.Enabled = false;
            result = client.Send(sendString);
            startButton.Enabled = false;
            disconnectButton.Enabled = false;
            connectButton.Enabled = true;
            foreach (var process1 in Process.GetProcessesByName("gst-launch-1.0"))
            {
                Debug.WriteLine("killed");
                process1.Kill();
            }
            System.Threading.Thread.Sleep(1000);
            System.Windows.Forms.Application.Exit();
        }

        private void RCRaspis_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(RCRaspis.SelectedItems[0].Text);
            if (!RCRaspis.SelectedItems[0].Text.Equals(connectBox.Text))
                connectBox.Text = RCRaspis.SelectedItems[0].Text;
        }
    }
}
