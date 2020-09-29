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
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Move selected file(s) to listbox
                foreach (object filePath in openFileDialog1.FileNames)
                {
                    listBox1.Items.Add(filePath.ToString());
                }   
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            // If export directory does not exist, create it
            string currentDir = Directory.GetCurrentDirectory();
            if (!Directory.Exists(currentDir + @"\ExportedImages\"))
            {
                MessageBox.Show("test");
                Directory.CreateDirectory(currentDir + @"\ExportedImages\");
            }

            foreach (string filePath in listBox1.Items)
            {
                // Add watermark to image
                Bitmap watermarkedImage = addWatermark(filePath);

                // Export image
                string fileName = Path.GetFileName(filePath);
                string exportFilePath = currentDir + @"\ExportedImages\" + fileName;
                watermarkedImage.Save(exportFilePath, ImageFormat.Jpeg);
            }
        }

        private Bitmap addWatermark(string filePath)
        {
            Bitmap baseImage = (Bitmap)Image.FromFile(filePath);
            Bitmap overlayImage = (Bitmap)Image.FromFile(@"C:\Users\Ben\Desktop\C#\Watermark-Generator\overlay.png");
            Bitmap watermarkedImage = new Bitmap(baseImage.Width, baseImage.Height);

            var graphics = Graphics.FromImage(watermarkedImage);
            graphics.CompositingMode = CompositingMode.SourceOver;
            graphics.DrawImage(baseImage, 0, 0, baseImage.Width, baseImage.Height);
            graphics.DrawImage(overlayImage, baseImage.Width - overlayImage.Width, baseImage.Height - overlayImage.Height, overlayImage.Width, overlayImage.Height);
            return watermarkedImage;
        }
    }
}
