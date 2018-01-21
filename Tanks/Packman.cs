using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Tanks
{
   class Packman:IRun, ITurn,ITransparent,ICurPicture
    {
        PackmanImg packmanimg = new PackmanImg();
        Image[] img;
        Image curimg;
        int x, y;
        int size_field;
        int direct_x, direct_y,nextdirect_x,nextdirect_y;
        static Random rn;//для повышения разности чисел
        public Packman(int size_field)
        {
            this.size_field = size_field;
           
          
            Y = 480;
            X =240 ;
            Direct_x = 0;
            Direct_y = -1;
            Nextdirect_x = 0;
            Nextdirect_y = -1;
            PutImg();
            PutCurImg();
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

        public Image Curimg
        {
            get
            {
                return curimg;
            }

            set
            {
                curimg = value;
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

        public int Nextdirect_x
        {
            get
            {
                return nextdirect_x;
            }

            set
            {
                if (value == 0 || value == -1 || value == 1)
                {
                    nextdirect_x = value;
                }
                else
                {
                    nextdirect_x = 0;
                }
            }
        }

        public int Nextdirect_y
        {
            get
            {
                return nextdirect_y;
            }

            set
            {

                if (value == 0 || value == -1 || value == 1)
                {
                    nextdirect_y = value;
                }
                else
                {
                    nextdirect_y = 0;
                }
            }
        }
      
        public void Run()
        {
            
            X += Direct_x;
            Y += Direct_y;
            if (Math.IEEERemainder(X, 80) == 0 && Math.IEEERemainder(Y, 80) == 0)
            {
                Turn();
            }
            PutCurImg();
            Transparent();
        }
        int k;
        private void PutCurImg()
        {
            Curimg = img[k];
            k++;
            if (k == 5)
            {
                k = 0;
            }
        }
        public void Turn()
        {
            Direct_x = Nextdirect_x;
            Direct_y = Nextdirect_y;
            
            PutImg();
        }

        public void Transparent()
        {
            if (x == -1)
            {
                x = size_field - 136;
            }
            if (x == size_field - 119)
            {
                x = 1;
            }
            if (y == -1)
            {
                y = size_field - 136;
            }
            if (y == size_field - 119)
            {
                y = 1;
            }
        }
        void PutImg()
        {
            if (Direct_x == 1)
            {
                img = packmanimg.Right;
            }
            if (Direct_x == -1)
            {
                img = packmanimg.Left;
            }
            if (Direct_y == 1)
            {
                img = packmanimg.Down;
            }
            if (Direct_y == -1)
            {
                img = packmanimg.Up;
            }
        }
        public void TurnAround()
        {
            Direct_x = -Direct_x;
            Direct_y = -Direct_y;
            PutImg();
        }
    }
}
