using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GifMaker
{
    public partial class PicturePreview : Form
    {
        public PicturePreview() => InitializeComponent();
        public PicturePreview(Image image) : this() => pictureBox1.Image = image;

        public Image Image
        {
            get => pictureBox1.Image;
            set => pictureBox1.Image = value;
        }
    }
}
