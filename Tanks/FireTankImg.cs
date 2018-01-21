using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Tanks
{
    class FireTankImg
    {
        Image[] firetankUp = new Image[]{
            Properties.Resources.FireTank0_1,
            Properties.Resources.FireTank0_1I,
            Properties.Resources.FireTank0_1II,
            Properties.Resources.FireTank0_1III,
            Properties.Resources.FireTank0_1IV
        };

        Image[] firetankRight = new Image[]{
            Properties.Resources.FireTank10,
            Properties.Resources.FireTank10I,
            Properties.Resources.FireTank10II,
            Properties.Resources.FireTank10III,
            Properties.Resources.FireTank01IV
        };

        public Image[] FiretankUp
        {
            get
            {
                return firetankUp;
            }

            set
            {
                firetankUp = value;
            }
        }

        public Image[] FiretankRight
        {
            get
            {
                return firetankRight;
            }

            set
            {
                firetankRight = value;
            }
        }
    }
}
