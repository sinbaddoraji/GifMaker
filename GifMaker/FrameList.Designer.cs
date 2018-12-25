namespace GifMaker
{
    partial class FrameList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.holder = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.swapWithSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.displayExternallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // holder
            // 
            this.holder.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.holder.AllowDrop = true;
            this.holder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.holder.AutoArrange = false;
            this.holder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.holder.ContextMenuStrip = this.contextMenuStrip1;
            this.holder.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.holder.HideSelection = false;
            this.holder.LargeImageList = this.imageList;
            this.holder.Location = new System.Drawing.Point(0, 0);
            this.holder.MultiSelect = false;
            this.holder.Name = "holder";
            this.holder.Size = new System.Drawing.Size(552, 89);
            this.holder.TabIndex = 0;
            this.holder.TileSize = new System.Drawing.Size(300, 300);
            this.holder.UseCompatibleStateImageBehavior = false;
            this.holder.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.Holder_ItemMouseHover);
            this.holder.Click += new System.EventHandler(this.Holder_Click);
            this.holder.DragDrop += new System.Windows.Forms.DragEventHandler(this.Holder_DragDrop);
            this.holder.DragEnter += new System.Windows.Forms.DragEventHandler(this.Holder_DragEnter);
            this.holder.DoubleClick += new System.EventHandler(this.Holder_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectMenuItem,
            this.swapWithSelectedToolStripMenuItem,
            this.removeImageToolStripMenuItem,
            this.displayExternallyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 114);
            // 
            // selectMenuItem
            // 
            this.selectMenuItem.Name = "selectMenuItem";
            this.selectMenuItem.Size = new System.Drawing.Size(180, 22);
            this.selectMenuItem.Text = "Select";
            this.selectMenuItem.Click += new System.EventHandler(this.SelectMenuItem_Click);
            // 
            // swapWithSelectedToolStripMenuItem
            // 
            this.swapWithSelectedToolStripMenuItem.Name = "swapWithSelectedToolStripMenuItem";
            this.swapWithSelectedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.swapWithSelectedToolStripMenuItem.Text = "Swap With Selected";
            this.swapWithSelectedToolStripMenuItem.Click += new System.EventHandler(this.SwapWithSelectedToolStripMenuItem_Click);
            // 
            // removeImageToolStripMenuItem
            // 
            this.removeImageToolStripMenuItem.Name = "removeImageToolStripMenuItem";
            this.removeImageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.removeImageToolStripMenuItem.Text = "Remove Frame";
            this.removeImageToolStripMenuItem.Click += new System.EventHandler(this.RemoveImageToolStripMenuItem_Click);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(50, 50);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // displayExternallyToolStripMenuItem
            // 
            this.displayExternallyToolStripMenuItem.Name = "displayExternallyToolStripMenuItem";
            this.displayExternallyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.displayExternallyToolStripMenuItem.Text = "Display Externally";
            // 
            // FrameList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.holder);
            this.Name = "FrameList";
            this.Size = new System.Drawing.Size(552, 89);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView holder;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem selectMenuItem;
        private System.Windows.Forms.ToolStripMenuItem swapWithSelectedToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem removeImageToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem displayExternallyToolStripMenuItem;
    }
}
