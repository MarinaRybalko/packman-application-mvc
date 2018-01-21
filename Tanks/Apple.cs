using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    class Apple:IPicture
    {
        AppleImg appleimg = new AppleImg();
        private Image img;
        int x, y;
        public Image Img
        {
            get
            {
                return img;
            }

            set
            {
                img = value;
            }
        }

        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        public Apple(int x,int y)
        {
            Img = appleimg.Img;
            X = x;
            Y = y;

        }
    }
}
