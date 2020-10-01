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
            statusLabel.Text = "";
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

                // Generate watermark text
                FontFamily fontFamily = new FontFamily("Arial");
                Font Arial = new Font(fontFamily, 48, FontStyle.Regular, GraphicsUnit.Pixel);
                Image overlayImage = DrawText(watermarkTextBox.Text, Arial, Color.White, Color.Transparent);

                // Add watermark to image
                Bitmap watermarkedImage = addWatermark(filePath, overlayImage);

                // Export image
                string exportFilePath = currentDir + @"\ExportedImages\" + fileName;
                watermarkedImage.Save(exportFilePath, ImageFormat.Jpeg);

                generatedImagesCount++;
            }

            statusLabel.Text = generatedImagesCount.ToString() + " images successfully generated.";
        }

        private Bitmap addWatermark(string filePath, Image overlayImage)
        {
            Bitmap baseImage = (Bitmap)Image.FromFile(filePath);
            Bitmap watermarkedImage = new Bitmap(baseImage.Width, baseImage.Height);

            var graphics = Graphics.FromImage(watermarkedImage);
            graphics.CompositingMode = CompositingMode.SourceOver;
            graphics.DrawImage(baseImage, 0, 0, baseImage.Width, baseImage.Height);
            graphics.DrawImage(overlayImage, baseImage.Width - overlayImage.Width, baseImage.Height - overlayImage.Height, overlayImage.Width, overlayImage.Height);
            
            return watermarkedImage;
        }

        // I stole this method from:
        // https://stackoverflow.com/questions/2070365/how-to-generate-an-image-from-text-on-fly-at-runtime
        private Image DrawText(String text, Font font, Color textColor, Color backColor)
        {
            //first, create a dummy bitmap just to get a graphics object
            Image img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);

            //measure the string to see how big the image needs to be
            SizeF textSize = drawing.MeasureString(text, font);

            //free up the dummy image and old graphics object
            img.Dispose();
            drawing.Dispose();

            //create a new image of the right size
            img = new Bitmap((int)textSize.Width, (int)textSize.Height);

            drawing = Graphics.FromImage(img);

            //paint the background
            drawing.Clear(backColor);

            //create a brush for the text
            Brush textBrush = new SolidBrush(textColor);

            drawing.DrawString(text, font, textBrush, 0, 0);

            drawing.Save();

            textBrush.Dispose();
            drawing.Dispose();

            return img;
        }
    }
}
