using System.Drawing;
using System.Windows.Forms;

namespace GifMaker
{
    public class Frame : ListViewItem
    {
        public string Path;

        public Image RealImage;

        public double DisplayTime  = 50; // 1/100 of a second

        public Frame(Image img) => RealImage = img;

        public double DisplayTimeInSeconds => DisplayTime / 100;

        public static void SwapFrames(ref Frame a,ref Frame b)
        {
            var copyB= b.RealImage;
            b.RealImage = a.RealImage;
            a.RealImage = copyB;

            var aa = a.ImageIndex;
            var bb = b.ImageIndex;

            //Swap Image Indexex
            b.ImageIndex = aa;
            a.ImageIndex = bb;

            //Swap image paths
            var bPath = b.Path;
            b.Path = a.Path;
            a.Path = bPath;

            //Swap Display Values
            var bDisplayTime = b.DisplayTime;
            b.DisplayTime = a.DisplayTime;
            a.DisplayTime = bDisplayTime;
        }
    }
}
