using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            IPAddress hostIP = (Dns.Resolve(IPAddress.Any.ToString())).AddressList[0];
            IPEndPoint ep = new IPEndPoint(hostIP, 25525);
            socket.Bind(ep);
            while (true)
            {
                socket.Listen(10);
                var array = new byte[100];
                socket.Receive(array);
                if (array.Length > 0)
                {
                    MessageBox.Show(array.ToString());
                }
            }
            
        }

        protected override void OnStop()
        {
        }
    }
}
