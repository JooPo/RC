using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RC_control
{
    class WiFi_scanner
    {
        ListView lstLocal;

        public WiFi_scanner(ListView RCRaspis) {
            lstLocal = RCRaspis;
        }

        static string NetworkGateway()
        {
            string ip = null;

            foreach (NetworkInterface f in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (f.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (GatewayIPAddressInformation d in f.GetIPProperties().GatewayAddresses)
                    {
                        ip = d.Address.ToString();
                    }
                }
            }

            return ip;
        }

        public void Ping_all()
        {

            string gate_ip = NetworkGateway();

            //Extracting and pinging all other ip's.
            string[] array = gate_ip.Split('.');

            for (int i = 2; i <= 255; i++)
            {

                string ping_var = array[0] + "." + array[1] + "." + array[2] + "." + i;

                Console.WriteLine("Pinging: " + ping_var);

                //time in milliseconds           
                Ping(ping_var, 4, 4000);

            }

        }

        public void Ping(string host, int attempts, int timeout)
        {
            for (int i = 0; i < attempts; i++)
            {
                new Thread(delegate ()
                {
                    try
                    {
                        System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
                        ping.PingCompleted += new PingCompletedEventHandler(PingCompleted);
                        ping.SendAsync(host, timeout, host);
                    }
                    catch
                    {
                        // Do nothing and let it try again until the attempts are exausted.
                        // Exceptions are thrown for normal ping failurs like address lookup
                        // failed.  For this reason we are supressing errors.
                    }
                }).Start();
            }
        }

        private void PingCompleted(object sender, PingCompletedEventArgs e)
        {
            string ip = (string)e.UserState;
            if (e.Reply != null && e.Reply.Status == IPStatus.Success)
            {
                string hostname = GetHostName(ip);
                string[] arr = new string[1];
                Console.WriteLine("New device1: " + hostname);

                if (hostname != null && hostname.Contains("RC"))
                {
                    //store all three parameters to be shown on ListView
                    arr[0] = hostname ;

                    // Logic for Ping Reply Success
                    ListViewItem item = new ListViewItem();
                    Console.WriteLine("New device2: " + hostname);
                    if (lstLocal != null)
                    {
                        foreach (ListViewItem device in lstLocal.Items)
                            if (device.Text.Equals(ip))
                                return;
                        lstLocal.Items.Add(ip).SubItems.AddRange(arr);
                        
                    }
                }
            }
        }

        private void Invoke(Action action)
        {
            throw new NotImplementedException();
        }

        public string GetHostName(string ipAddress)
        {
            try
            {
                IPHostEntry entry = Dns.GetHostEntry(ipAddress);
                if (entry != null)
                {
                    return entry.HostName;
                }
            }
            catch (SocketException)
            {
                // MessageBox.Show(e.Message.ToString());
            }

            return null;
        }
    }
}
