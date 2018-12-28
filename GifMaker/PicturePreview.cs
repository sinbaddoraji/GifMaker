using System.Drawing;
using System.Windows.Forms;

namespace GifMaker
{
    public partial class PicturePreview : Form
    {
        public PicturePreview() => InitializeComponent();

        public Image Image
        {
            set => pictureBox1.Image = value;
            get => pictureBox1.Image;
        }
    }
}
