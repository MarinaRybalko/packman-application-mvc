using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Tanks
{
    class FireTank
    {
        FireTankImg ftimg = new FireTankImg();
        Image curimg;
 
        public Image Curimg
        {
            get
            {
                return curimg;
            }

           
        }

        public int X
        {
            get
            {
                return x;
            }

           
        }

        public int Y
        {
            get
            {
                return y;
            }

            
        }

       
       
        private Image[] imgR;
        private Image[] imgUp;
        int x, y;
       public FireTank(int x,int y)
        {
            this.x = x;
            this.y = y;
            
            imgR = ftimg.FiretankRight;
            imgUp = ftimg.FiretankUp;
            PutCurImgR();
            
        }
        public void FireUp()
        {
            PutCurImgUp();
        }
        public void FireR()
        {
            PutCurImgR();
        }
        int k;
        public void PutCurImgR()
        {
           
                curimg = imgR[k];
                k++;
                if (k == 5)
                {
                    k = 0;
                }
           
        }
       public void PutCurImgUp()
        {

            curimg = imgUp[k];
            k++;
            if (k == 5)
            {
                k = 0;
            }

        }
    }
}
