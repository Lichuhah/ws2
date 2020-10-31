using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            IPAddress hostIP = (Dns.Resolve(IPAddress.Any.ToString())).AddressList[0];
            //
            IPEndPoint ep = new IPEndPoint(hostIP, 25525);
            var array = new byte[100];
            socket.Bind(ep);
            while (true)
            {
                socket.Listen(1);
                Socket newSocket = socket.Accept();
                newSocket.Receive(array);
                if (array.Length > 0)
                {
                    MessageBox.Show(Encoding.ASCII.GetString(array));
                }
                                   
                newSocket.Close();
            }
            //while (true)
            //{
            //    do
            //    {
            //      socket.Listen(0);
            //    } while (socket.Available <= 0);

            //  //  int a = socket.Available;
            //    var array = new byte[100];
            //    socket.Receive(array);
            //    if (array.Length > 0)
            //    {
            //        MessageBox.Show(array.ToString());
            //    }
            //}

        }
    }
}
