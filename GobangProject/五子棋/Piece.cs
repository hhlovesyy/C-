using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace 五子棋
{
    class Piece:Label
    {
        private const int IMAGE_WIDTH = 30;
        private const int IMAGE_HEIGHT = 30;//定义图片高度

        public Piece(int x,int y)
        {
            //this.Image =Properties.Resources.white;//黑棋白棋得再用子类
            this.Location = new Point(x- IMAGE_WIDTH/2, y- IMAGE_HEIGHT/2);//位置指定
            this.Size = new Size(IMAGE_WIDTH, IMAGE_HEIGHT);

            this.Text = "1";
            this.AutoSize = false;
            this.ForeColor = Color.Red;
            this.Font = new Font("微软雅黑", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.TextAlign = ContentAlignment.MiddleCenter;
        }
       // public abstract PieceType GetPieceType();//抽象方法 实现多态 
       public Image GetNextImage()//直接判断 没有使用抽象方法实现多态PV
        {
            if(this is BlackPiece)//is 判断是什么类型的数据 x is int 返回bool数据
            {
                return Properties.Resources.white2;
            }
            else
            {
                return Properties.Resources.black2;
            }
        }
        //public abstract Image GetNextImage();
        public Image GetImage()
        {
            //return this.Image;
            if (this is BlackPiece)//is 判断是什么类型的数据 x is int 返回bool数据
            {
                return Properties.Resources.white2;
            }
            else
            {
                return Properties.Resources.black2;
            }
        }
    }
}
