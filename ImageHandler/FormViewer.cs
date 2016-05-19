using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageHandler
{
    public partial class FormViewer : Form
    {
        public FormViewer()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            string ex  ="."+comboBox2.SelectedItem.ToString();          
            s.FileName = "my pic _" + this.mode + ex;

            if (s.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            try
            {
                if(!s.FileName.EndsWith(ex))
                    s.FileName +=ex;
                Signature(this.pictureBox1.Image,s.FileName);
                MessageBox.Show("saved to \r\n +"+s.FileName);
            }
            catch { MessageBox.Show("error in saving ", "sorry"); }

        }
        public Color SelectedColor = Color.Orange;

        private void Signature( Image bitmap , string p)
        {

            PointF firstLocation = new PointF(0f, 0f);
            string imageFilePath = p;           

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                using (Font arialFont = new Font("Arial Black", Bestfont()))
                {
                   // graphics.DrawString(firstText, arialFont, Brushes.Orange, firstLocation);

                    graphics.DrawString(Form1.firstText, arialFont ,Brushes.Orange, firstLocation);
                    //graphics.DrawLine(Pens.Azure,0,0,0,20);// 
                }
            }

            bitmap.Save(imageFilePath );
        }

        private float Bestfont()
        {
            return Form1.Bestfont(this.pictureBox1.Image);
        }


        private void Signature(string p)
        {

            string firstText = "By 4neso";
            PointF firstLocation = new PointF(0f, 0f);
            string imageFilePath = p; 
            Bitmap bitmap = (Bitmap)Image.FromFile(imageFilePath);//load the image file

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                using (Font arialFont = new Font("Comic Sans Ms", 10))
                {
                    graphics.DrawString(firstText, arialFont, Brushes.Blue, firstLocation);
               
                }
            }
            bitmap.Save(imageFilePath+"_"+DateTime.Now.Millisecond+"."+comboBox2.SelectedItem.ToString());
        }
        public string mode="normal";

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (comboBoxmode.SelectedIndex)
            {
                case 0: pictureBox1.SizeMode = PictureBoxSizeMode.Normal; break;
                case 1: pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; break;
                case 2: pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize; break;
                case 3: pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage; break;
                case 4: pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; break;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }// { get; set; }

        internal void setimage(Image image)
        {
            this.pictureBox1.Image = image;
        }

        private void FormViewer_Load(object sender, EventArgs e)
        { 
            comboBoxmode.SelectedIndex = comboBoxmode.Items.Count - 1;
            comboBox2.SelectedIndex = 5;


        }
       private System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Jpeg;

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.format = System.Drawing.Imaging.ImageFormat.Jpeg;

            switch (comboBoxmode.SelectedIndex)
            {
                case 0: this.format = System.Drawing.Imaging.ImageFormat.Bmp; break;
                case 1: this.format = System.Drawing.Imaging.ImageFormat.Emf; break;
                case 2: this.format = System.Drawing.Imaging.ImageFormat.Exif; break;
                case 3: this.format = System.Drawing.Imaging.ImageFormat.Gif; break;
                case 4: this.format = System.Drawing.Imaging.ImageFormat.Icon; break;
                case 5: this.format = System.Drawing.Imaging.ImageFormat.Jpeg; break;
                case 6: this.format = System.Drawing.Imaging.ImageFormat.MemoryBmp; break;
                case 7: this.format = System.Drawing.Imaging.ImageFormat.Png; break;
                case 8: this.format = System.Drawing.Imaging.ImageFormat.Tiff; break;
                case 9: this.format = System.Drawing.Imaging.ImageFormat.Wmf; break;


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog d = new ColorDialog();
            if (d.ShowDialog() != DialogResult.OK)
                return;
            this.BackColor = d.Color;
        }
    }
}
