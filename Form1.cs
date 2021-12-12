using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Cache;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.InteropServices;
using System.Threading;
using System.Collections.Generic;

namespace reVirt_PSP
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

        }


        private void button5_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFile = new FolderBrowserDialog();
           
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                textBox1.Clear();
                textBox1.AppendText(openFile.SelectedPath);
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Just For Decoration!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Just For Decoration!");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Just For Decoration!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Just For Decoration!");
        }
        [DllImport("user32.dll")]
        static extern IntPtr intPtr(IntPtr hwc, IntPtr hwp);
        private void button6_Click(object sender, EventArgs e)
        {
           
            string args;
            string argsmain;
            string newcom;
            
            args = textBox1.Text;
            argsmain = "upkk_syb.dll pack " + args +" "+  AppDomain.CurrentDomain.BaseDirectory+"DROP_PSP.BF";
            newcom = "C:\\Windows\\System32\\cmd.exe";
            ProcessStartInfo psi = new ProcessStartInfo();

            psi.Arguments = argsmain;

                       
            psi.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            psi.FileName = "unpakke.exe";
            psi.WorkingDirectory = args;
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            


            Process unpakk = Process.Start(psi);
            
            Thread.Sleep(100);
            string output = unpakk.StandardOutput.ReadToEnd();
            textBox2.AppendText("---Built DROP_PSP.BF!\r\n");
            
            byte[] Filetext = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "DROP_PSP.BF");
            
            string infile = @AppDomain.CurrentDomain.BaseDirectory+"DROP_PSP.BF";
            string outfile = @"DROP_PSP.BF";
            Regex re = new Regex(@"VXBG");
            string repl = @"VXBF";

            Encoding ascii = Encoding.ASCII;
            byte[] inbytes = File.ReadAllBytes(infile);
            string instr = ascii.GetString(inbytes);
            Match match = re.Match(instr);
            int beg = 0;
            bool replaced = false;
            List<byte> newbytes = new List<byte>();
            while (match.Success)
            {
                replaced = true;
                for (int i = beg; i < match.Index; i++)
                    newbytes.Add(inbytes[i]);
                foreach (char c in repl)
                    newbytes.Add(Convert.ToByte(c));
                Match nmatch = match.NextMatch();
                int end = (nmatch.Success) ? nmatch.Index : inbytes.Length;
                for (int i = match.Index + match.Length; i < end; i++)
                    newbytes.Add(inbytes[i]);
                beg = end;
                match = nmatch;
            }
            if (replaced)
            {
                var newarr = newbytes.ToArray();
                File.WriteAllBytes(outfile, newarr);
            }
            else
            {
                File.WriteAllBytes(outfile, inbytes);
            }

           
            textBox2.AppendText("---Modified DROP_PSP.BF for PSP!\r\n");
            textBox2.AppendText("---You just need to replace the built DROP_PSP.BF with the one in Online Chess Kindoms---\r\n");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
