namespace WatermarkGenerator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.imageList = new System.Windows.Forms.ListBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.generateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.watermarkTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.AllowDrop = true;
            this.imageList.FormattingEnabled = true;
            this.imageList.ItemHeight = 20;
            this.imageList.Location = new System.Drawing.Point(12, 12);
            this.imageList.Name = "imageList";
            this.imageList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.imageList.Size = new System.Drawing.Size(776, 324);
            this.imageList.TabIndex = 1;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(12, 342);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(90, 40);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Images|*.jpg;*.jpeg;*.png;";
            this.openFileDialog1.Multiselect = true;
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(698, 342);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(90, 40);
            this.generateButton.TabIndex = 3;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(108, 342);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(90, 40);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // watermarkTextBox
            // 
            this.watermarkTextBox.Location = new System.Drawing.Point(278, 349);
            this.watermarkTextBox.Name = "watermarkTextBox";
            this.watermarkTextBox.Size = new System.Drawing.Size(363, 26);
            this.watermarkTextBox.TabIndex = 7;
            this.watermarkTextBox.Text = "Watermark text";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(8, 430);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(92, 20);
            this.statusLabel.TabIndex = 8;
            this.statusLabel.Text = "statusLabel";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.watermarkTextBox);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.imageList);
            this.Name = "Form1";
            this.Text = "Watermark Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox imageList;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TextBox watermarkTextBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label statusLabel;
    }
}

