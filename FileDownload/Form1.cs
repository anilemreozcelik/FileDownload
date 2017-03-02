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

namespace FileDownload
{
    public partial class Form1 : Form
    {
        WebClient wc = new WebClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            dialog.Title = "Browse";
            dialog.InitialDirectory = @"C:\";
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.button1.Enabled = false;
                string text = this.richTextBox1.Text;
                wc.DownloadFileCompleted += new AsyncCompletedEventHandler(FileDownloadCompleted);
                Uri uri = new Uri(text);
                wc.DownloadFileAsync(uri, dialog.FileName);
            }

            
        }

        private void FileDownloadCompleted(object sender,AsyncCompletedEventArgs e)
        {
            this.button1.Enabled = false;
            this.progressBar1.Value = 100;
            MessageBox.Show("Finished","Bilgi");
        }
    }
}
