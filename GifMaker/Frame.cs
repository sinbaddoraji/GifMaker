using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GifMaker
{
    public class Frame : ListViewItem
    {
        public Image RealImage;
        public string Path;
        public int DisplayTime  = 100; // 1/100 of a second

        public static void SwapFrames(ref Frame a,ref Frame b)
        {
            var copyB= b.RealImage;
            b.RealImage = a.RealImage;
            a.RealImage = copyB;

            int aa = a.ImageIndex;
            int bb = b.ImageIndex;

            b.ImageIndex = aa;
            a.ImageIndex = bb;

            string bPath = b.Path;
            b.Path = a.Path;
            a.Path = bPath;
        }
    }
}
