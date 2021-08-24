using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace 五子棋
{
    class Pieces : PictureBox
    {
        public Pieces(int x,int y)
        {
            this.BackgroundImage = Properties.Resources.black;
            this.Location = new Point(x,y);
            this.Size = new Size(50, 50);
        }
    }
}
