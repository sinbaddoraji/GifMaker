using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using ImageMagick;

namespace GifMaker
{
    public partial class Form1 : Form
    {
        private PicturePreview _picturePreview;
        private const string tempFile = "test.gif";
        
        public Form1()
        {
            InitializeComponent();
            RefreshPreviewForm();
            panel1.Hide();
        }

        private void RefreshPreviewForm()
        {
            _picturePreview = new PicturePreview();
            frameList1.FrameSelected = FrameSelected;
            frameList1.FrameDeselected = delegate{ panel1.Hide(); };
            frameList1.displayExternallyToolStripMenuItem.Click += displayExternally_Click;
        }

        private void FrameSelected(Frame lastClickedItem)
        {
            try
            {
                _picturePreview.Image = lastClickedItem.RealImage;
                panel1.Show();
                frameDuration.Text = lastClickedItem.DisplayTimeInSeconds.ToString();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void DisplayExternally()
        {
            if (frameList1.LastClickedItem == null)
            {
                if(_picturePreview.Image == pictureBox1.Image && pictureBox1.Image != null)
                {
                    _picturePreview.Show();
                    pictureBox1.Image = _picturePreview.Image;
                }

                return;
            }
            //Reset pictureBox image to make images play at the same time
            _picturePreview.Image = frameList1.LastClickedItem.RealImage;

            ShowPicturePreview:
            try
            {
                _picturePreview.Show();
            }
            catch 
            {
                RefreshPreviewForm(); goto ShowPicturePreview; 
            }
        }

        private void FrameDuration_TextChanged(object sender, EventArgs e)
        {
            try
            {
                frameList1.LastClickedItem.DisplayTime = int.Parse(frameDuration.Text) * 100;
            }
            catch
            {
                frameList1.FrameSelected.Invoke(frameList1.LastClickedItem);
            }
        }
        private static void DeleteTempFiles()
        {
           Directory.Delete($@"{Directory.GetCurrentDirectory()}\temp", true);
           //File.Delete(tempFile);
        }

        private void CreateTempFiles(Frame[] frames)
        {
            if (!Directory.Exists("temp")) Directory.CreateDirectory("temp");

            for (int i = 0; i < frames.Length; i++)
            {
                Frame current = frames[i];

                int w = frameList1.AverageSize.Width;
                int h = frameList1.AverageSize.Height;
                Image currentImage = current.RealImage.GetThumbnailImage(w, h, null, IntPtr.Zero);

                currentImage.Save($@"{Directory.GetCurrentDirectory()}\temp\{i}.png");
            }
        }

        private static void CreateGIF(Frame[] frames)
        {
            string[] rawFrames = Directory.GetFiles("temp");

            using (MagickImageCollection collection = new MagickImageCollection())
            {
                for (int i = 0, count = rawFrames.Length; i < count; i++)
                {
                    collection.Add(rawFrames[i]);
                    collection[i].AnimationDelay = (int)frames[i].DisplayTime;
                }

                // Optionally reduce colors
                QuantizeSettings settings = new QuantizeSettings
                {
                    Colors = 256
                };
                collection.Quantize(settings);

                //Optionally optimize the images (images should have the same size).
                collection.Optimize();

                // Save gif
                collection.Write(tempFile);
            }
        }

        private void openGifToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frameList1.Clear();
            var o = new OpenFileDialog();
            if(o.ShowDialog() == DialogResult.OK)
            {
                var img = Image.FromFile(o.FileName);
                FrameDimension d = new FrameDimension(img.FrameDimensionsList[0]);

                Image[] images = new Image[img.GetFrameCount(d)];
                int[] imageDisplay = new int[images.Length];

                for (int i = 0; i < images.Length; i++)
                {
                   img.SelectActiveFrame(d,i);
                   images[i] = (Image)img.Clone();

                   var p = images[i].GetPropertyItem(0x5100);

                   int delay = (p.Value[0] + p.Value[1] * 256);

                   imageDisplay[i] = delay;
                }

                for(int i = 0; i < images.Length; i++)
                {
                    frameList1.AddFrame(images[i]);
                    frameList1.SetFrameDelay(i,imageDisplay[i]);
                }
                
            }
        }

        private void addFrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
             if(o.ShowDialog() != DialogResult.OK) return;
            
            try
            {
                frameList1.AddFrame(o.FileNames);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void playGifToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateTempFiles(frameList1.Frames);
            CreateGIF(frameList1.Frames);

            pictureBox1.Image = (Image)Image.FromFile(tempFile).Clone();
            _picturePreview.Image = pictureBox1.Image;

            DeleteTempFiles();
        }

        private void displayExternally_Click(object sender, EventArgs e)
        {
            DisplayExternally();
        }

        private void saveGifToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(SaveFileDialog o = new SaveFileDialog(){ Filter = "GIF|*.gif"})
            {
                if(o.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image.Save(o.FileName,ImageFormat.Gif);
                }
            }
        }
    }
}
