﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace CombineImages
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            test();
        }

        private void test()
        {
            Bitmap baseImage = (Bitmap)Image.FromFile(@"C:\Users\Ben\source\repos\CombineImages\base.jpg");
            Bitmap overlayImage = (Bitmap)Image.FromFile(@"C:\Users\Ben\source\repos\CombineImages\overlay.png");

            var finalImage = new Bitmap(baseImage.Width, baseImage.Height, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(finalImage);
            graphics.CompositingMode = CompositingMode.SourceOver;

            graphics.DrawImage(baseImage, 0, 0);
            graphics.DrawImage(overlayImage, 0, 0);

            //show in a winform picturebox
            //pictureBox1.Image = finalImage;

            //save the final composite image to disk
            finalImage.Save(@"C:\Users\Ben\source\repos\CombineImages\final.jpg", ImageFormat.Jpeg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //Move selected files to listbox
        }
    }
}
