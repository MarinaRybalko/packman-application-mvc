using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    class Tank :  ITurn,ITransparent,ICurPicture,ITurnAround
    {
        private TankImg tankimg = new TankImg();
        private void PutImg()
        {
            if (Direct_x == 1)
            {
                img = tankimg.Right;
            }
            if (Direct_x == -1)
            {
                img = tankimg.Left;
            }
            if (Direct_y == 1)
            {
                img = tankimg.Down;
            }
            if (Direct_y == -1)
            {
                img = tankimg.Up;
            }
        }

        protected int x, y;
        protected int direct_x, direct_y; 
        protected Image []img;
        protected Image curimg;
        protected int size_field;
        protected static Random rn;//для повышения разности чисел
        protected int k;
        protected void PutCurImg()
        {
            Curimg = img[k];
            k++;
            if (k == 5)
            {
                k = 0;
            }
        }

        public Tank(int size_field , int x,int y)
        {
            this.size_field = size_field;
            rn = new Random();
            if(rn.Next(5000)<2500)
            {
                Direct_y = 0;
               loop:
                Direct_x = rn.Next(-1, 2);
                if(Direct_x==0)
                {
                    goto loop;
                }
            }
            else
            {
                Direct_x = 0;
            loop:
                Direct_y = rn.Next(-1, 2);
                if (Direct_y == 0)
                {
                    goto loop;
                }
            }
            PutImg();
            PutCurImg();
            Y = y;
            X = x;

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
        public void Run()
        {
            Transparent();
            x += direct_x;
            y += direct_y;
            if (Math.IEEERemainder(x, 80) == 0 && Math.IEEERemainder(y, 80) == 0)
            {
                Turn();
            }
            PutCurImg();
           
        }
       
        public void Turn()
        {
            
                if (rn.Next(5000) < 2500)// движение по вертикали
                {
                    if (Direct_y == 0)
                    {
                        direct_x = 0;
                        while (Direct_y == 0)
                        {
                            Direct_y = rn.Next(-1, 2);
                        
                        }
                    }
                }
                else                     // двигаемся по горизонтали
                {
                    if (Direct_x == 0)
                    {

                        direct_y = 0;
                        while (Direct_x == 0)
                        {
                            Direct_x = rn.Next(-1, 2);
                        }
                    }
                }
           
            PutImg();
        }
        public void Transparent()
        {
            
                    if (x == -1)
                    {
                        x = size_field - 121;
                    }
                    if (x == size_field - 109)
                    {
                        x = 1;
                    }
                    if (y == -1)
                    {
                        y = size_field - 121;
                    }
                    if (y == size_field - 109)
                    {
                        y = 1;
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
