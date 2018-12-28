using System.ComponentModel;
using System.Windows.Forms;

namespace GifMaker
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.o = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.frameDuration = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openGifToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGifToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playGifToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayImageExternallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frameList1 = new GifMaker.FrameList();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // o
            // 
            this.o.Multiselect = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(0, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(714, 292);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.frameDuration);
            this.panel1.Location = new System.Drawing.Point(0, 318);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 31);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "seconds";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Frame Duration";
            // 
            // frameDuration
            // 
            this.frameDuration.Location = new System.Drawing.Point(99, 4);
            this.frameDuration.Name = "frameDuration";
            this.frameDuration.Size = new System.Drawing.Size(53, 20);
            this.frameDuration.TabIndex = 0;
            this.frameDuration.Text = "0.5";
            this.frameDuration.TextChanged += new System.EventHandler(this.FrameDuration_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.frameToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(714, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openGifToolStripMenuItem,
            this.saveGifToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openGifToolStripMenuItem
            // 
            this.openGifToolStripMenuItem.Name = "openGifToolStripMenuItem";
            this.openGifToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openGifToolStripMenuItem.Text = "Open Gif";
            this.openGifToolStripMenuItem.Click += new System.EventHandler(this.openGifToolStripMenuItem_Click);
            // 
            // saveGifToolStripMenuItem
            // 
            this.saveGifToolStripMenuItem.Name = "saveGifToolStripMenuItem";
            this.saveGifToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveGifToolStripMenuItem.Text = "Save Gif";
            this.saveGifToolStripMenuItem.Click += new System.EventHandler(this.saveGifToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playGifToolStripMenuItem,
            this.displayImageExternallyToolStripMenuItem});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // playGifToolStripMenuItem
            // 
            this.playGifToolStripMenuItem.Name = "playGifToolStripMenuItem";
            this.playGifToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.playGifToolStripMenuItem.Text = "Play Gif";
            this.playGifToolStripMenuItem.Click += new System.EventHandler(this.playGifToolStripMenuItem_Click);
            // 
            // displayImageExternallyToolStripMenuItem
            // 
            this.displayImageExternallyToolStripMenuItem.Name = "displayImageExternallyToolStripMenuItem";
            this.displayImageExternallyToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.displayImageExternallyToolStripMenuItem.Text = "Display Image Externally";
            // 
            // frameToolStripMenuItem
            // 
            this.frameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFrameToolStripMenuItem});
            this.frameToolStripMenuItem.Name = "frameToolStripMenuItem";
            this.frameToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.frameToolStripMenuItem.Text = "Frame";
            // 
            // addFrameToolStripMenuItem
            // 
            this.addFrameToolStripMenuItem.Name = "addFrameToolStripMenuItem";
            this.addFrameToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.addFrameToolStripMenuItem.Text = "Add Frame";
            this.addFrameToolStripMenuItem.Click += new System.EventHandler(this.addFrameToolStripMenuItem_Click);
            // 
            // frameList1
            // 
            this.frameList1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.frameList1.Location = new System.Drawing.Point(0, 350);
            this.frameList1.Name = "frameList1";
            this.frameList1.Size = new System.Drawing.Size(714, 106);
            this.frameList1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(714, 457);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.frameList1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FrameList frameList1;
        private OpenFileDialog o;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Label label1;
        private TextBox frameDuration;
        private Label label2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openGifToolStripMenuItem;
        private ToolStripMenuItem saveGifToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem imageToolStripMenuItem;
        private ToolStripMenuItem frameToolStripMenuItem;
        private ToolStripMenuItem addFrameToolStripMenuItem;
        private ToolStripMenuItem playGifToolStripMenuItem;
        private ToolStripMenuItem displayImageExternallyToolStripMenuItem;
    }
}

