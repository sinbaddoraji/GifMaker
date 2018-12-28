using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GifMaker
{
    public partial class FrameList : UserControl
    {
        public FrameList()
        {
            InitializeComponent();
        }

        #region All FrameList Variables
        public Frame LastClickedItem;
        private Frame _selectedItem;
        private Frame itemDragged;

        public Size AverageSize
        {
            get
            {
                var w = Frames.Select(x => x.RealImage.Width).Sum() / holder.Items.Count;
                var h = Frames.Select(x => x.RealImage.Height).Sum() / holder.Items.Count;

                return new Size(w, h);
            }
        }


        public Frame[] Frames
        {
            get
            {
                var frames = new List<Frame>();

                foreach (Frame frame in holder.Items)
                    frames.Add(frame);

                return frames.ToArray();
            }
        }
        

        #endregion

        #region Added Functionality

        public void SetFrameDelay(int index,int delayValue)
        {
           Frame f = (Frame)holder.Items[index];
           f.DisplayTime = delayValue;
        }
        

        private void SwapWithSelectedFrame()
        {
           if (_selectedItem != null) goto StartSwapping;

           MessageBox.Show(@"There is no selected item"); return;
            
           StartSwapping:
           SwapFrames(_selectedItem,(Frame)holder.SelectedItems[0]);
            _selectedItem = null;
        }

        private void SwapFrames(Frame a, Frame b) => Frame.SwapFrames(ref a, ref b);

        #endregion Added Functionality

        #region Frame Manipulation

        public void AddFrame(string img)
        {
            var frameImage = Image.FromFile(img);
            Frame frame = new Frame(frameImage)
            {
                Path = img
            };

            imageList.Images.Add(frameImage);

            frame.ImageIndex = imageList.Images.Count - 1;

            holder.Items.Add(frame);
        }
        public void AddFrame(Image img)
        {
            Frame frame = new Frame(img)
            {
                Path = "Internal"
            };

            imageList.Images.Add(img);

            frame.ImageIndex = imageList.Images.Count - 1;

            holder.Items.Add(frame);
        }
        public void AddFrame(Image img,int delay)
        {
            Frame frame = new Frame(img)
            {
                Path = "Internal",
                DisplayTime = delay
            };

            imageList.Images.Add(img);

            frame.ImageIndex = imageList.Images.Count - 1;

            holder.Items.Add(frame);
        }
         public void AddFrame(Image[] images)
         {
            foreach (Image item in images) AddFrame(item);
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

        public void Clear() => RemoveFrame(Frames);

        #endregion Frame Manipulation

        #region Event Handlers

        private void RemoveImageToolStripMenuItem_Click(object sender, EventArgs e) => RemoveFrame((Frame)holder.SelectedItems[0]);

        private void SwapWithSelectedToolStripMenuItem_Click(object sender, EventArgs e) => SwapWithSelectedFrame();
        

        

        private void Holder_DragEnter(object sender, DragEventArgs e) => e.Effect = DragDropEffects.Copy;

        private void Holder_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            if(holder.SelectedItems.Count == 0) FrameDeselected (LastClickedItem);
        }
        
        private void Holder_Click(object sender, EventArgs e)
        {
            if(holder.SelectedItems.Count > 0)
            {
                LastClickedItem = (Frame)holder.SelectedItems[0];
                FrameSelected(LastClickedItem);
            }
            else
            {
                FrameDeselected(LastClickedItem);
            }
        }
        private void Holder_KeyDown(object sender, KeyEventArgs e)
        {
            if(holder.SelectedItems.Count < 1) return;
            if(e.KeyCode == Keys.Delete)  RemoveFrame((Frame)holder.SelectedItems[0]);

            int currentIndex = holder.Items.IndexOf(holder.SelectedItems[0]);
            int nextIndex = currentIndex;

            if(e.KeyCode == Keys.Left && currentIndex > 0)
                nextIndex -= 1;
            if(e.KeyCode == Keys.Right && currentIndex < holder.Items.Count -1)
                nextIndex += 1;

            if(currentIndex == nextIndex)return;

            Frame a = (Frame)holder.Items[currentIndex];
            Frame b = (Frame)holder.Items[nextIndex];
            Frame.SwapFrames(ref a, ref b);
        }

        private void Holder_ItemDrag(object sender, ItemDragEventArgs e)
        {
           holder.HoverSelection = true;
           var g = holder.CreateGraphics();
           itemDragged = (Frame)e.Item;
        }

        private void Holder_DragDrop(object sender, DragEventArgs e)
        {
            AddFrame((string[])e.Data.GetData(DataFormats.FileDrop));
        }
        

        private void Holder_MouseUp(object sender, MouseEventArgs e)
        {
            if (holder.HoverSelection)
            {
                Frame a = itemDragged;
                Frame b = (Frame)holder.SelectedItems[0];
                Frame.SwapFrames(ref a, ref b);

                holder.HoverSelection = false;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            _selectedItem = null;
            timer1.Stop();
        }

        #endregion Events

        #region Events
            public delegate void FrameSelect(Frame selectedFrame);
            public FrameSelect FrameSelected = delegate{ };
            public FrameSelect FrameDeselected = delegate{ };

        #endregion
        
        

        
    }
}