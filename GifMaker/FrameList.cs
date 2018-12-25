using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GifMaker
{
    public partial class FrameList : UserControl
    {
        public FrameList() => InitializeComponent();

        public Frame lastClickedItem = null;
        private Frame hoverOverItem = null;
        private Frame selectedItem = null;
        public Size AverageSize
        {
            get
            {
                int w = 0;
                int h = 0;
                foreach (Frame frame in holder.Items)
                {
                    w += frame.RealImage.Width;
                    h += frame.RealImage.Height;
                }
                w /= holder.Items.Count;
                h /= holder.Items.Count;

                return new Size(w,h);
            }
        }

        

        public Frame[] Frames
        {
            get
            {
                List<Frame> frames = new List<Frame>();

                foreach (Frame frame in holder.Items)
                    frames.Add(frame);

                return frames.ToArray();
            }
        }

        //Make picture viewer's picture update in realtime

        #region Added Functionality

        private void TrySelectItem()
        {
            if (selectMenuItem.Text == "Select")
            {
                selectedItem = (Frame)holder.SelectedItems[0] ?? null;
                timer1.Start();
            }
            else selectedItem = null;
        }

        private void SwapWithSelectedFrame()
        {
            if (selectedItem == null)
            {
                MessageBox.Show("There is no selected item");
                return;
            }

            int selectedItemIndex = holder.Items.IndexOf(selectedItem);
            int selectedReplacingItemIndex = holder.Items.IndexOf(holder.SelectedItems[0]);

           Frame a = (Frame)holder.Items[selectedReplacingItemIndex];
           Frame b = (Frame)holder.Items[selectedItemIndex];

            Frame.SwapFrames(ref a,ref b);

            selectedItem = null;
        }

        #endregion Added Functionality

        #region Frame Manipulation
        
        public void AddFrame(string img)
        {
            var frameImage = Image.FromFile(img);
            Frame frame = new Frame
            {
                RealImage = frameImage,
                Path = img
            };

            imageList.Images.Add(frameImage);

            frame.ImageIndex = imageList.Images.Count - 1;

            holder.Items.Add(frame);
        }

        public void AddFrame(string[] imageFilepath)
        {
            foreach (string item in imageFilepath) AddFrame(item);
        }

        public void RemoveFrame(Frame frame) => RemoveFrame(new[] { frame });

        public void RemoveFrame(Frame[] frames)
        {
            foreach (Frame item in frames)
            {
                imageList.Images.RemoveAt(item.ImageIndex);
                holder.Items.Remove(item);
            }
        }

        #endregion Frame Manipulation

        #region Event Handlers

        private void RemoveImageToolStripMenuItem_Click(object sender, EventArgs e) => RemoveFrame((Frame)holder.SelectedItems[0]);

        private void SwapWithSelectedToolStripMenuItem_Click(object sender, EventArgs e) => SwapWithSelectedFrame();

        private void SelectMenuItem_Click(object sender, EventArgs e) => TrySelectItem();

        private void Holder_DragDrop(object sender, DragEventArgs e) => AddFrame((string[])e.Data.GetData(DataFormats.FileDrop));

        private void Holder_DragEnter(object sender, DragEventArgs e) => e.Effect = DragDropEffects.Copy;

        private void Holder_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            selectMenuItem.Text = e.Item == selectedItem ? "Deselect" : "Select";
            hoverOverItem = (Frame)e.Item;

            if(holder.SelectedItems.Count == 0) FrameDeselected (lastClickedItem);
        }

        private void Holder_DoubleClick(object sender, EventArgs e)
        {
            if (selectedItem == null || selectMenuItem.Text == "Deselect") TrySelectItem();
            else SwapWithSelectedFrame();
        }

        private void Holder_Click(object sender, EventArgs e)
        {
            if(holder.SelectedItems.Count > 0)
            {
                lastClickedItem = (Frame)holder.SelectedItems[0];
                FrameSelected(lastClickedItem);
            }
            else
            {
                FrameDeselected(lastClickedItem);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            selectedItem = null;
            timer1.Stop();
        }

        #endregion Events

        #region Events
            public delegate void FrameSelect(Frame SelectedFrame);
            public FrameSelect FrameSelected = delegate{ };
            public FrameSelect FrameDeselected = delegate{ };
        #endregion

    }
}