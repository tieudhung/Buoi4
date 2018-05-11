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

namespace Bai_2_UDP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        byte[] data = new byte[1024];
        private void button1_Click(object sender, EventArgs e)
        {
            int startport = Convert.ToInt32(txtFrom.Text);
            int endport = Convert.ToInt32(txtTo.Text);

            progressBar1.Value = 0;
            progressBar1.Maximum = endport - startport + 1;

            Cursor.Current = Cursors.WaitCursor;

            for (int ourrport = startport; ourrport <= endport; ourrport++)
            {
                UdpClient udp = new UdpClient();
                int a = 10;
                try
                {
                    udp.Connect(txtIP.Text, ourrport);
                    data = BitConverter.GetBytes(a);
                    udp.Send(data, data.Length);
                    IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(txtIP.Text), ourrport);
                    data = udp.Receive(ref ipe);
                    //udp.Connect(ipe);
                    textBox1.AppendText("Port " + ourrport + " open .\n ");

                }
                catch
                {

                    textBox1.AppendText("Port " + ourrport + " closed .\n ");
                }
                progressBar1.PerformStep();
            }
            Cursor.Current = Cursors.Arrow;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
