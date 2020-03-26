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
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;
	

namespace EVIL___DISQUS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string[] users;
        static int fail=0;
        static int success = 0;
        Point point0 = new Point();
        bool boolean0;
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            MessageBox.Show("Project Name : EVIL - DISQUS\nProgrammer : Karar(MrVirus)\nInstagram : BQBB\nTelegram : NNN7N\nTelegram Channel : Camera", "CopyRight");
users = File.ReadAllLines("list.txt");
        }
        static string ch(string user)
        {


            try
            {
                HttpWebRequest httpRQ = (HttpWebRequest)WebRequest.Create("https://disqus.com/by/" + user + "/");
                httpRQ.Method = "get";
                httpRQ.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
                httpRQ.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.132 Safari/537.36";
                HttpWebResponse WebR = (HttpWebResponse)httpRQ.GetResponse();
                Stream str = WebR.GetResponseStream();
                StreamReader strREAD = new StreamReader(str);
                return strREAD.ReadToEnd();
            }
            catch (System.Net.WebException){return "success";}
        }
        void work()
        {
            Parallel.ForEach(users, (user) => {
                string result = ch(user);
                if (result == "success")
                {
                    textBox1.AppendText(user+Environment.NewLine);
                    success += 1;
                    textBox3.Text = Convert.ToString(success);
                    Thread.Sleep(1000);
                }
                else
                {
                    textBox2.AppendText(user + Environment.NewLine);
                    fail += 1;
                    textBox4.Text = Convert.ToString(fail);
                    Thread.Sleep(1000);
                }
            
            });
            MessageBox.Show("Done...","GOOD JOB");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(()=>work());
            th.Start();
            
        }
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.point0 = new Point((0 - e.X), (0 - e.Y));
                this.boolean0 = true;
            }
        }
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.boolean0)
            {
                Point mousePosition = Control.MousePosition;
                mousePosition.Offset(this.point0.X, this.point0.Y);
                this.Location = mousePosition;
            }
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.boolean0 = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            File.WriteAllText("Available.txt", textBox1.Text);
            this.Close();
        }
    }
}
