using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Buoi4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int startport = Convert.ToInt32(txtFrom.Text);
            int endport = Convert.ToInt32(txtTo.Text);

            progressBar1.Value = 0;
            progressBar1.Maximum = endport - startport + 1;

            Cursor.Current = Cursors.WaitCursor;

            for (int ourrport = startport; ourrport <= endport; ourrport++)
            {
                TcpClient tcp = new TcpClient();
                
                try
                {
                    tcp.SendTimeout = 50;
                    tcp.ReceiveTimeout = 50;
                    tcp.Connect(txtIP.Text, ourrport);
                    if (tcp.Connected)
                    {
                        textBox1.AppendText("Port " + ourrport + " open .\n ");
                    }
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
