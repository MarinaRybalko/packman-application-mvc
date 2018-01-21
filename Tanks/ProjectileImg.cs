using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Tanks
{
    class ProjectileImg
    {
        Image up = Properties.Resources.weaponTankII;
        Image down = Properties.Resources.weaponTankI;
        Image left = Properties.Resources.weaponTankIII;
        Image right = Properties.Resources.weaponTank;

        public Image Up
        {
            get
            {
                return up;
            }

            set
            {
                up = value;
            }
        }

        public Image Down
        {
            get
            {
                return down;
            }

            set
            {
                down = value;
            }
        }

        public Image Left
        {
            get
            {
                return left;
            }

            set
            {
                left = value;
            }
        }

        public Image Right
        {
            get
            {
                return right;
            }

            set
            {
                right = value;
            }
        }
    }
}
