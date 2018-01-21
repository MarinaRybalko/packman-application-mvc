using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Tanks
{
    class Wall:IPicture
    {
        WallImg wallimg = new WallImg();
        private Image img;

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

        public Wall()
        {
            Img = wallimg.Img;
        }
    }
}
