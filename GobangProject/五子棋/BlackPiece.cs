using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 五子棋
{
    class BlackPiece:Piece
    {
        public BlackPiece(int x,int y):base(x,y)//调用父亲
        {
            this.Image = Properties.Resources.black_60;
        }
    }
}
