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
using ImageMagick;

namespace GifMaker
{
    public partial class Form1 : Form
    {
        PicturePreview picturePreview;
        public Form1()
        {
            InitializeComponent();
            RefreshPreviewForm();
        }

        private void RefreshPreviewForm()
        {
            picturePreview = new PicturePreview();
            frameList1.FrameSelected = FrameSelected;
            frameList1.FrameDeselected = FrameDeslected;
            frameList1.displayExternallyToolStripMenuItem.Click += button2_Click;
        }

        private void FrameSelected(Frame lastClickedItem)
        {
            try
            {
                picturePreview.Image = lastClickedItem.RealImage;
            panel1.Show();

            frameDuration.Text = (lastClickedItem.DisplayTime / 100).ToString();
            }
            catch (Exception)
            {
                
            }
            
        }

        private void FrameDeslected(Frame lastClickedItem)
        {
            panel1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dialogResult = o.ShowDialog();
            if(dialogResult != DialogResult.OK) return;
            
            try
            {
                frameList1.AddFrame(o.FileNames);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) => DisplayExternally();

        private void DisplayExternally()
        {
            if (frameList1.lastClickedItem == null) return;
            picturePreview.Image = frameList1.lastClickedItem.RealImage;

            ShowPicturePreview:;
            try
            {
                picturePreview.Show();
            }
            catch { RefreshPreviewForm(); goto ShowPicturePreview; }
            
        }

        private void FrameDuration_TextChanged(object sender, EventArgs e)
        {
            try
            {
                frameList1.lastClickedItem.DisplayTime = int.Parse(frameDuration.Text) * 100;
            }
            catch
            {
                frameList1.FrameSelected.Invoke(frameList1.lastClickedItem);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Frame[] frames = frameList1.Frames;
            if(!Directory.Exists("temp"))Directory.CreateDirectory("temp");

            for (int i = 0; i < frames.Length; i++)
            {
                Frame current = frames[i];
                int w = frameList1.AverageSize.Width;
                int h = frameList1.AverageSize.Height;
                Image currentImage =current.RealImage.GetThumbnailImage(w,h,null,IntPtr.Zero);
                currentImage.Save($@"{Directory.GetCurrentDirectory()}\temp\{i}.png");
            }
			string outputFilePath = "test.gif";

            string[] rawFrames = Directory.GetFiles("temp");

            using (MagickImageCollection collection = new MagickImageCollection())
            {
                for (int i = 0, count = rawFrames.Length; i < count; i++ ) 
			    {
                    collection.Add(rawFrames[i]);
                    collection[i].AnimationDelay = frames[i].DisplayTime;
			    }

                // Optionally reduce colors
                QuantizeSettings settings = new QuantizeSettings();
                settings.Colors = 256;
                collection.Quantize(settings);

                //Optionally optimize the images (images should have the same size).
                collection.Optimize();
                
                // Save gif
                collection.Write(outputFilePath);
            }

            pictureBox1.Image = Image.FromFile(outputFilePath);

            Directory.Delete($@"{Directory.GetCurrentDirectory()}\temp",true);
        }
    }
}
