using ImageMagick;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace GifMaker
{
    public partial class Form1 : Form
    {
        private PicturePreview _picturePreview;
        private const string TempFile = "test.gif";

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
            frameList1.FrameDeselected = delegate { panel1.Hide(); };
            frameList1.displayExternallyToolStripMenuItem.Click += DisplayExternally_Click;
        }

        private void FrameSelected(Frame lastClickedItem)
        {
            try
            {
                _picturePreview.Image = lastClickedItem.RealImage;
                panel1.Show();
                frameDuration.Text = lastClickedItem.DisplayTimeInSeconds.ToString(CultureInfo.CurrentCulture);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void DisplayExternally()
        {
            if (frameList1.LastClickedItem != null)
            {
                _picturePreview.Image = frameList1.LastClickedItem.RealImage;

                ShowPicturePreview:
                try
                {
                    _picturePreview.Show();
                }
                catch
                {
                    RefreshPreviewForm();
                    goto ShowPicturePreview;
                }
            }
            else
            {
                if (_picturePreview.Image != pictureBox1.Image || pictureBox1.Image == null) return;
                _picturePreview.Show();

                //Reset pictureBox image to make images play at the same time
                pictureBox1.Image = _picturePreview.Image;
            }
        }

        private void FrameDuration_TextChanged(object sender, EventArgs e)
        {
            try
            {
                frameList1.LastClickedItem.DisplayTime = double.Parse(frameDuration.Text) * 100;
            }
            catch
            {
                frameList1.FrameSelected.Invoke(frameList1.LastClickedItem);
            }
        }

        private static void DeleteTempFiles()
        {
            Directory.Delete($@"{Directory.GetCurrentDirectory()}\temp", true);
            File.Delete(TempFile);
        }

        private void CreateTempFiles(IReadOnlyList<Frame> frames)
        {
            if (!Directory.Exists("temp")) Directory.CreateDirectory("temp");

            for (var i = 0; i < frames.Count; i++)
            {
                var current = frames[i];

                var w = frameList1.AverageSize.Width;
                var h = frameList1.AverageSize.Height;
                var currentImage = current.RealImage.GetThumbnailImage(w, h, null, IntPtr.Zero);

                currentImage.Save($@"{Directory.GetCurrentDirectory()}\temp\{i}.png");
            }
        }

        private void CreateGif(IReadOnlyList<Frame> frames, string file = TempFile)
        {
            var rawFrames = Directory.GetFiles("temp");
            if (rawFrames.Length != frames.Count)
            {
                MessageBox.Show(@"There was a problem somewhere");
                return;
            }

            using (var collection = new MagickImageCollection())
            {
                for (var i = 0; i < rawFrames.Length; i++)
                {
                    collection.Add(rawFrames[i]);
                    collection[i].AnimationDelay = (int)frames[i].DisplayTime;
                }

                // Optionally reduce colors
                var settings = new QuantizeSettings
                {
                    Colors = 256
                };
                collection.Quantize(settings);

                //Optionally optimize the images (images should have the same size).
                collection.Optimize();

                // Save gif
                if (file != TempFile)
                {
                    collection.Write(TempFile);
                }

                collection.Write(file);
                collection.Dispose();
            }
        }

        private void OpenGifToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frameList1.Clear();
            var o = new OpenFileDialog();
            if (o.ShowDialog() == DialogResult.OK)
            {
                var img = Image.FromFile(o.FileName);
                FrameDimension d = new FrameDimension(img.FrameDimensionsList[0]);

                Image[] images = new Image[img.GetFrameCount(d)];
                int[] imageDisplay = new int[images.Length];

                for (int i = 0; i < images.Length; i++)
                {
                    img.SelectActiveFrame(d, i);
                    images[i] = (Image)img.Clone();

                    var p = images[i].GetPropertyItem(0x5100);

                    int delay = (p.Value[0] + p.Value[1] * 256);

                    imageDisplay[i] = delay;
                }

                for (int i = 0; i < images.Length; i++)
                {
                    frameList1.AddFrame(images[i]);
                    frameList1.SetFrameDelay(i, imageDisplay[i]);
                }
            }
        }

        private void AddFrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openDialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                frameList1.AddFrame(openDialog.FileNames);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PlayGifToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _picturePreview.Image = pictureBox1.Image = null;

            CreateTempFiles(frameList1.Frames);
            CreateGif(frameList1.Frames);

            using (var fs = new FileStream(TempFile, FileMode.Open))
            {
                var ms = new MemoryStream();
                fs.CopyTo(ms);
                ms.Position = 0;
                if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                _picturePreview.Image = pictureBox1.Image = Image.FromStream(ms);
            }

            DeleteTempFiles();
        }

        private void DisplayExternally_Click(object sender, EventArgs e) => DisplayExternally();

        private void SaveGifToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var o = new SaveFileDialog() { Filter = @"GIF|*.gif" })
            {
                if (o.ShowDialog() != DialogResult.OK) return;

                CreateTempFiles(frameList1.Frames);
                CreateGif(frameList1.Frames, o.FileName);

                using (var fs = new FileStream(TempFile, FileMode.Open))
                {
                    var ms = new MemoryStream();
                    fs.CopyTo(ms);
                    ms.Position = 0;                              
                    if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                    _picturePreview.Image = pictureBox1.Image = Image.FromStream(ms);
                }

                DeleteTempFiles();
            }
        }

        private void AlterFrameDuration(double v, bool add)
        {
            if (!add) v *= -1;
            double duration = double.Parse(frameDuration.Text) + v;
            frameDuration.Text = duration.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AlterFrameDuration(0.1, true);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AlterFrameDuration(0.1, false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AlterFrameDuration(0.5, true);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AlterFrameDuration(0.5, false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AlterFrameDuration(1, true);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AlterFrameDuration(1, false);
        }
    }
}