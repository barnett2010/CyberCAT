﻿using CyberCAT.Core.ChunkedLz4;
using CyberCAT.Core.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CyberCAT.Forms
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox1.Text))
            {
                using (var compressedInputStream = File.OpenRead(textBox1.Text))
                {
                    var saveFile = new CyberPunkSaveFile();
                    saveFile.ReadHeader(compressedInputStream);
                    saveFile.Decompress(compressedInputStream);
                    saveFile.Compress("output.bin");
                    //_chunkedFile = new ChunkedLz4File(compressedInputStream);
                    //using (var inputStream = _chunkedFile.Decompress(compressedInputStream))
                    //{
                    //    using (var fileStream = File.Create(@"H:\CP2077_sg\output.bin"))
                    //    {
                    //        inputStream.Seek(0, SeekOrigin.Begin);
                    //        inputStream.CopyTo(fileStream);
                    //    }
                    //}
                }
            }
            else
            {
                MessageBox.Show("File does not exist");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var compressedInputStream = File.OpenRead(@"output.bin"))
            {
                var saveFile = new CyberPunkSaveFile();
                saveFile.ReadHeader(compressedInputStream);
                saveFile.Decompress(compressedInputStream);
                saveFile.Compress("output_2.bin");
                //_chunkedFile = new ChunkedLz4File(compressedInputStream);
                //using (var inputStream = _chunkedFile.Decompress(compressedInputStream))
                //{
                //    using (var fileStream = File.Create(@"H:\CP2077_sg\output.bin"))
                //    {
                //        inputStream.Seek(0, SeekOrigin.Begin);
                //        inputStream.CopyTo(fileStream);
                //    }
                //}
            }
        }
    }
}
