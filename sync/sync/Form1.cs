using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace sync
{
    public partial class Form1 : Form
    {
        string name, path;
        Mutex m = new Mutex();
        public Form1()
        {
            InitializeComponent();
            path = textBox1.Text;
        }

        public void NameFile()
        {
            m.WaitOne();
            name = Path.GetFileName(textBox1.Text);
            listBox1.Items.Add("File name: " + name);
            m.ReleaseMutex();
        }
        public void PathFile()
        {
            m.WaitOne();
            listBox1.Items.Add("Path file: " + textBox1.Text);
            m.WaitOne();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(NameFile));
            th.Start();
            Thread th1 = new Thread(new ThreadStart(PathFile));
            th1.Start();
        }
    }
}
