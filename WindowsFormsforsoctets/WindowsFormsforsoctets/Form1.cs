using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace WindowsFormsforsoctets
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String sendingText = textBox1.Text;
            Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            IPAddress hostIP = (Dns.Resolve("localhost")).AddressList[0];
            IPEndPoint ep = new IPEndPoint(hostIP, 25525);
            //socket.Bind(ep);
            socket.Connect(hostIP, 25525);
            byte[] array = Encoding.ASCII.GetBytes(sendingText);
            socket.Send(array);
            socket.Close();
        }
    }
}
