using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Backup
{
    public partial class Form1 : Form
    {
        DirectorySearch dir = new DirectorySearch();
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string extension = comboBox1.SelectedItem.ToString().ToLower();
            dir.FileExtension = extension;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using(var browseDir = new FolderBrowserDialog())
            {
                browseDir.ShowDialog();
                textBox1.Text = String.Format("{0}",browseDir.SelectedPath);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dir.Source = textBox1.Text;
            Console.WriteLine(dir.Source);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var browseDir = new FolderBrowserDialog())
            {

                browseDir.ShowDialog();
                textBox2.Text = String.Format("{0}", browseDir.SelectedPath);
                string path = String.Format("{0}", browseDir.SelectedPath);
                DirectoryInfo d = null;
                try
                {
                    d = new DirectoryInfo(String.Format("{0}", browseDir.SelectedPath));
                    if (d.Exists && !Directory.EnumerateFileSystemEntries(path).Any())
                    {
                        dir.Backup = path;
                        Console.WriteLine("Empty!!"); //Debugging
                    }
                    else
                        Console.WriteLine("Full!!");//Debugging
                }
                catch (System.ArgumentException) 
                {
                    d = null;
                }
                

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dir.getSubDirectories();
            dir.moveFiles(dir.Source);
        }
    }
}
