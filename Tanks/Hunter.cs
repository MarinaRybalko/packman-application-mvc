using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    class Hunter:Tank
    {
      
        HunterImg hunterimg = new HunterImg();
        private void PutImg()
        {
            if (Direct_x == 1)
            {
                img = hunterimg.Right;
            }
            if (Direct_x == -1)
            {
                img = hunterimg.Left;
            }
            if (Direct_y == 1)
            {
                img = hunterimg.Down;
            }
            if (Direct_y == -1)
            {
                img = hunterimg.Up;
            }
        }
        public Hunter(int size_field,int x, int y):base(size_field,x,y)
        {
            Direct_x = -1;
            Direct_y = 0;
            PutImg();
            PutCurImg();
        }
        public void Turn(int target_x,int target_y)
        {
            Direct_y = Direct_y = 0;
            if(X>target_x)
            {
                Direct_x = -1;
            }
            if(X<target_x)
            {
                Direct_x = 1;
            }
            if(Y>target_y)
            {
                Direct_y = -1;
            }
            if(Y<target_y)
            {
                Direct_y = 1;
            }
            if (Direct_x != 0 && Direct_y != 0)
            
                if (rn.Next(5000) < 2500)
                {
                    Direct_x = 0;
                }
                else
                {
                    Direct_y = 0;
                }
            PutImg();
            //PutCurImg();
        }
        new public void TurnAround()

        {
            Direct_x = -1*Direct_x;
            Direct_y = -1*Direct_y;
            PutImg();
        }
        public void Run(int target_x,int target_y)
        {
            
            
            x += direct_x;
            y += direct_y;
            if (Math.IEEERemainder(x, 80) == 0 && Math.IEEERemainder(y, 80) == 0)
            {
                Turn(target_x,target_y);
            }
            PutCurImg();
            Transparent();
        }
}
}
