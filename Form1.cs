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

namespace WatermarkGenerator
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
                    imageList.Items.Add(filePath.ToString());
                }   
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            imageList.Items.Remove(imageList.SelectedItem);
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            // If export directory does not exist, create it
            string currentDir = Directory.GetCurrentDirectory();
            if (!Directory.Exists(currentDir + @"\ExportedImages\"))
            {
                Directory.CreateDirectory(currentDir + @"\ExportedImages\");
            }

            int generatedImagesCount = 0;
            foreach (string filePath in imageList.Items)
            {
                // Update status
                string fileName = Path.GetFileName(filePath);
                statusLabel.Text = "Generating " + fileName + ".jpg";

                // Add watermark to image
                Bitmap watermarkedImage = addWatermark(filePath);

                // Export image
                string exportFilePath = currentDir + @"\ExportedImages\" + fileName;
                watermarkedImage.Save(exportFilePath, ImageFormat.Jpeg);

                generatedImagesCount++;
            }

            statusLabel.Text = generatedImagesCount.ToString() + " images successfully generated.";
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
