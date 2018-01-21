using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Tanks
{
    class Projectile
    {
        private Image img;
        private int kilometers;
        int x, y, direct_x, direct_y;
        private ProjectileImg projectileimg = new ProjectileImg();
        public Projectile()
        {
            DefaultSettings();
            img = projectileimg.Up;
            
        }
        public void DefaultSettings()
        {
            X = Y = -300;
            Direct_x = Direct_y = 0;
            kilometers = 0;
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

        public int Direct_x
        {
            get
            {
                return direct_x;
            }

            set
            {
                if (value == 0 || value == -1 || value == 1)
                {
                    direct_x = value;
                }
                else
                {
                    direct_x = 0;
                }
            }
        }
        public int Direct_y
        {
            get
            {
                return direct_y;
            }

            set
            {
                if (value == 0 || value == -1 || value == 1)
                {
                    direct_y = value;
                }
                else
                {
                    direct_y = 0;
                }
            }
        }

        public Image Img
        {
            get
            {
                return img;
            }

            
        }

        private void PutImg()
        {
            if (Direct_x == 1)
            {
                img = projectileimg.Right ;
            }
            if (Direct_x == -1)
            {
                img = projectileimg.Left;
            }
            if (Direct_y == 1)
            {
                img = projectileimg.Down;
            }
            if (Direct_y == -1)
            {
                img = projectileimg.Up;
            }
        }
        public void Run()
        {
            if (Direct_x == 0 && Direct_y == 0)
            {
                return;
            }
            else
            { 
                kilometers += 3;
                if (kilometers > 240)
                {
                    DefaultSettings();
                }
                PutImg();
                x += Direct_x * 3;
                y += Direct_y * 3;
            }
        }
    }
}
