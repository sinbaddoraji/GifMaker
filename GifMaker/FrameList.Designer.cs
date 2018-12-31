using System.ComponentModel;
using System.Windows.Forms;

namespace GifMaker
{
    partial class FrameList
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
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
            this.holder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.holder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
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
            this.holder.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.Holder_ItemDrag);
            this.holder.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.Holder_ItemMouseHover);
            this.holder.Click += new System.EventHandler(this.Holder_Click);
            this.holder.DragDrop += new System.Windows.Forms.DragEventHandler(this.Holder_DragDrop);
            this.holder.DragEnter += new System.Windows.Forms.DragEventHandler(this.Holder_DragEnter);
            this.holder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Holder_KeyDown);
            this.holder.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Holder_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeImageToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            // 
            // removeImageToolStripMenuItem
            // 
            this.removeImageToolStripMenuItem.Name = "removeImageToolStripMenuItem";
            this.removeImageToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.removeImageToolStripMenuItem.Text = "Remove Frame";
            this.removeImageToolStripMenuItem.Click += new System.EventHandler(this.RemoveImageToolStripMenuItem_Click);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(50, 50);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
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

        private ListView holder;
        private ImageList imageList;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem removeImageToolStripMenuItem;
        private ColumnHeader columnHeader1;
    }
}
