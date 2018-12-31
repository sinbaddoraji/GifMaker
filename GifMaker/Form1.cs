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
            InitilizePreviewForm();
        }

        #region All Event Handlers
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void OpenGifToolStripMenuItem_Click(object sender, EventArgs e) => OpenGif();

        private void PlayGifToolStripMenuItem_Click(object sender, EventArgs e) => PlayGIF();

        private void SaveGifToolStripMenuItem_Click(object sender, EventArgs e) => SaveGif();

        private void DisplayExternally_Click(object sender, EventArgs e) => DisplayExternally();

        private void AddFrameToolStripMenuItem_Click(object sender, EventArgs e) => AddFrame();

        private void Button1_Click(object sender, EventArgs e) => AlterFrameDuration(0.1, true);

        private void Button2_Click(object sender, EventArgs e) => AlterFrameDuration(0.5, true);

        private void Button3_Click(object sender, EventArgs e) => AlterFrameDuration(1, true);

        private void Button4_Click(object sender, EventArgs e) => AlterFrameDuration(0.1, false);

        private void Button5_Click(object sender, EventArgs e) => AlterFrameDuration(0.5, false);

        private void Button6_Click(object sender, EventArgs e) => AlterFrameDuration(1, false);

        private void FrameSelected(Frame lastClickedItem) => ShowFrameEditPanel(lastClickedItem);

        private void FrameDuration_TextChanged(object sender, EventArgs e) => HandleFrameDisplayTime();

        #endregion Event Handlers

        #region Gif Save / Create

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

        private void SaveGifFile(string img = null)
        {
            CreateTempFiles(frameList1.Frames);
            if (img == null) CreateGif(frameList1.Frames);
            else CreateGif(frameList1.Frames, img);
            OpenImage(TempFile);
            DeleteTempFiles();
        }

        private void ExtractGifFrames(string f)
        {
            var img = Image.FromFile(f);
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

        private static void DeleteTempFiles()
        {
            Directory.Delete($@"{Directory.GetCurrentDirectory()}\temp", true);
            File.Delete(TempFile);
        }

        private void AddFrame()
        {
            if (openDialog.ShowDialog() != DialogResult.OK) return;

            if (new FileInfo(openDialog.FileName).Extension.ToLower() == ".gif")
            {
                ExtractGifFrames(openDialog.FileName);
                playGifToolStripMenuItem.PerformClick();
                return;
            }

            try
            {
                frameList1.AddFrame(openDialog.FileNames);
                playGifToolStripMenuItem.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveGif()
        {
            var o = new SaveFileDialog() { Filter = @"GIF|*.gif" };
            if (o.ShowDialog() == DialogResult.OK) SaveGifFile(o.FileName);
        }

        #endregion

        #region Gif image Open

        private void OpenImage(string file)
        {
            //https://stackoverflow.com/questions/22016544/showing-animated-gif-in-winforms-without-locking-the-file
            //Hans Passant thank you....
            using (var fs = new FileStream(file, FileMode.Open))
            {
                var ms = new MemoryStream();
                fs.CopyTo(ms);
                ms.Position = 0;
                if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                _picturePreview.Image = pictureBox1.Image = Image.FromStream(ms);
            }
        }
        private void OpenGif()
        {
            frameList1.Clear();
            var o = new OpenFileDialog();
            if (o.ShowDialog() == DialogResult.OK)
            {
                ExtractGifFrames(o.FileName);
                playGifToolStripMenuItem.PerformClick();
            }
        }

        #endregion

        #region Gif Edit

        private void ShowFrameEditPanel(Frame lastClickedItem)
         {
                try
                {
                    panel1.Show();
                    frameDuration.Text = lastClickedItem.DisplayTimeInSeconds.ToString(CultureInfo.CurrentCulture);
                    playGifToolStripMenuItem.PerformClick();
                }
                catch (Exception)
                {
                    // ignored
                }
         }

        private void AlterFrameDuration(double v, bool add)
        {
            if (!add) v *= -1;
            double duration = double.Parse(frameDuration.Text) + v;
            frameDuration.Text = duration.ToString();

            playGifToolStripMenuItem.PerformClick();
        }

        private void HandleFrameDisplayTime()
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

        private void PlayGIF() => SaveGifFile();

        private void InitilizePreviewForm()
        {
            _picturePreview = new PicturePreview();
            frameList1.FrameSelected = FrameSelected;
            frameList1.FrameDeselected = delegate { panel1.Hide(); };
        }
        #endregion

        #region UX

        private void DisplayExternally()
        {
            if (_picturePreview.Image != pictureBox1.Image || pictureBox1.Image == null) return;
            _picturePreview.Show();

            //Reset pictureBox image to make images play at the same time
            pictureBox1.Image = _picturePreview.Image;
        }



        #endregion

    }
}