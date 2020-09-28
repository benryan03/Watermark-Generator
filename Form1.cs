using System;
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
            //test();
        }

        private void test()
        {
            Bitmap baseImage = (Bitmap)Image.FromFile(@"C:\Users\Ben\Desktop\C#\Watermark-Generator\base.jpg");
            Bitmap overlayImage = (Bitmap)Image.FromFile(@"C:\Users\Ben\Desktop\C#\Watermark-Generator\overlay.png");

            var finalImage = new Bitmap(baseImage.Width, baseImage.Height, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(finalImage);
            graphics.CompositingMode = CompositingMode.SourceOver;

            graphics.DrawImage(baseImage, 0, 0);
            graphics.DrawImage(overlayImage, 0, 0);

            //save the final composite image to disk
            finalImage.Save(@"C:\Users\Ben\Desktop\C#\Watermark-Generator\final.jpg", ImageFormat.Jpeg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Move selected files to listbox
                foreach (object filePath in openFileDialog1.FileNames)
                {
                    listBox1.Items.Add(filePath.ToString());
                }   
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            // If export directory does not exist, create it
            if (!Directory.Exists(@"C:\test\"))
            {
                System.IO.Directory.CreateDirectory(@"C:\test\");
            }

            // Export images
            foreach (string filePath in listBox1.Items)
            {
                addWatermark(filePath);
            }
        }

        private void addWatermark(string filePath)
        {
            Bitmap baseImage = (Bitmap)Image.FromFile(filePath);
            Bitmap overlayImage = (Bitmap)Image.FromFile(@"C:\Users\Ben\Desktop\C#\Watermark-Generator\overlay.png");
            var watermarkedImage = new Bitmap(baseImage.Width, baseImage.Height, PixelFormat.Format32bppArgb);
            
            var graphics = Graphics.FromImage(watermarkedImage);
            graphics.CompositingMode = CompositingMode.SourceOver;
            graphics.DrawImage(baseImage, 0, 0);
            graphics.DrawImage(overlayImage, 0, 0);

            // Save
            // Todo: Extract this from this method
            string fileName = Path.GetFileName(filePath);
            string exportFilePath = @"C:\test\" + fileName;
            watermarkedImage.Save(exportFilePath, ImageFormat.Jpeg);
        }
    }
}
