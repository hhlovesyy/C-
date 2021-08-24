using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace 五子棋
{
    partial class Borad
    {
        public static readonly int NODE_COUNT = 15; // public类外面要用//棋子/交叉点个数
        //private const Point NO_MATCH_NODE=new Point(-1,-1);//
        private static readonly Point NO_MATCH_NODE = new Point(-1, -1);//记录一个无效的点 //改成？//改为静态才能赋值
        private readonly int OFFSET = 21;//边界值  这个就像define
        private readonly int NODE_DISTANCEA = 42;//交叉点距离 也是棋子空间  
        private readonly int NODE_RADIUS = 12;//交叉点附近有效区间点的半径
        
        private Piece[,] pieces =new Piece[NODE_COUNT, NODE_COUNT];//9*9二维数组记录下过的棋子,从左往右是第一维,从上往下是第二维
        private Point lastPlaceNode =  NO_MATCH_NODE;//NO_MATCH_NODE;改为静态才能赋值 默认是无效的交叉点
        public static Point[] Queuechessman = new Point[NODE_COUNT*NODE_COUNT];//这个和下面的chessmancolor于pieces保持一致,从左往右是第一维,从上往下是第二维
        public static int[] chessmancolor = new int[NODE_COUNT * NODE_COUNT];
        public static Point[] ReadFileChessman = new Point[NODE_COUNT * NODE_COUNT];//这个和下面的是用来读取存档中的信息的
        public static int[] readfilechessmancolor = new int[NODE_COUNT * NODE_COUNT];
        public static int steps = 0;//这是目前的第几步
        //私有内置的字段 只能获取 不能修改
        public Point LlastPlaceNode//公有只读的属性
        {
            get
            {
                return lastPlaceNode;//记录最后一步棋子的交叉点
            }
        }

        //1 数组的下标正好和交叉点的下标一一对应
        //2 交叉点转化为真真实的棋子位置坐标
        //3 通过数组可以判断有没有下过棋子 
        //转化为真实棋子位置
        public void Reload()
        {
            lastPlaceNode = NO_MATCH_NODE;
            pieces = new Piece[NODE_COUNT, NODE_COUNT];
            for(int i=0;i<NODE_COUNT*NODE_COUNT;i++)
            {
                Queuechessman[i].X = -1;
                Queuechessman[i].Y = -1;
                ReadFileChessman[i].X = -1;
                ReadFileChessman[i].Y = -1;
                chessmancolor[i] = 0;
                readfilechessmancolor[i] = 0;
            }
            for (int i = 0; i < NODE_COUNT; i++)
            {
                for (int j = 0; j < NODE_COUNT; j++)
                {
                    pieces[i, j] = null;
                }
            }
            steps = 0;
        }
        private Point ConvertToRealPosition(Point nodeID)//参数是找到交叉点 //M:NODE_DISTANCEA=70
        {
            //nodeID.X nodeID.Y 获取真实下标x,y
            Point realPoint = new Point(OFFSET + NODE_DISTANCEA * nodeID.X, OFFSET + NODE_DISTANCEA * nodeID.Y);
            return realPoint;       
        }
        public int GetnowPlayerColor()//这个函数用于悔棋之后返回当前玩家是哪个玩家
        {
            return chessmancolor[steps + 1];
        }
        public void SetGameSavingPiece(string sFilename)//这个函数用来读取文件中的内容并保存在数组当中
        {
            int i = 0;//用来指示此时文件到了第几行
            using (StreamReader sr = new StreamReader(sFilename))
            {
                string line;
                // 从文件读取并显示行，直到文件的末尾 
                while ((line = sr.ReadLine()) != null)
                {
                    string []number=new string[3];//读取文件每行的三个数,分别表示此时颜色,x位置和y位置
                    number= line.Split(' ');
                    //Console.WriteLine("----------------------");
                    //Console.WriteLine("i= " + i);
                    
                    readfilechessmancolor[i] = int.Parse(number[0]);
                    ReadFileChessman[i].X = int.Parse(number[1]);
                    ReadFileChessman[i].Y = int.Parse(number[2]);
                    //Console.WriteLine("readfilechessmancolor[i]= " + readfilechessmancolor[i]);
                   // Console.WriteLine("ReadFileChessman[i].X= " + ReadFileChessman[i].X);
                    //Console.WriteLine("ReadFileChessman[i].Y= " + ReadFileChessman[i].Y);
                    i++;
                }
            }
        }
        public Piece GetTopPiece()
        {
            if(steps>=0)
            {
                steps--;
            }
             if(steps<-1)
            {
                return null;
            }
            Piece temppiece = pieces[Queuechessman[steps + 1].X, Queuechessman[steps + 1].Y];
            pieces[Queuechessman[steps + 1].X, Queuechessman[steps + 1].Y] = null;
            
            return temppiece;
        }
        public Piece GiveAPieceFromFile(int x,int y,int color)//利用文件中的内容下一个棋,x和y都是索引值
        {
            steps++;
            Queuechessman[steps].X = x;
            Queuechessman[steps].Y = y;
            chessmancolor[steps] = color;
            Point PlacePoint = new Point(x, y);
            Point realPoint = ConvertToRealPosition(PlacePoint);
            if (color == 1)
            {
                //如果是黑 数组中放入黑棋
                //数组下标与点的下标一一对应
                pieces[x,y] = new BlackPiece(realPoint.X, realPoint.Y);
            }
            else if (color == 2)
            {
                pieces[x,y] = new WhitePiece(realPoint.X, realPoint.Y);
            }
            return pieces[x,y];
        }
        public Piece PlaceAPiece(int x, int y, int color)
        {
            //Console.WriteLine("color= " + color);
            //Console.WriteLine("现在在placeapiece带color的重载函数里面");
            Point AIpoint = ComputerNextStep(color);
            //if (pieces[AIpoint.X, AIpoint.Y] != null)
            //    return null;
            Point realPoint = ConvertToRealPosition(AIpoint);//获得真实点坐标
            //Console.WriteLine("AIpoint.x= " + AIpoint.X);
            //Console.WriteLine("AIpoint.y= " + AIpoint.Y);
            ////Console.WriteLine("realpoint.x= " + realPoint.X);
            ////Console.WriteLine("realpoint.y= " + realPoint.Y);
            ///-------------------------------------------------
            ///-------------------------------------------------
            ///2021.7.26新增内容
            steps++;
            Queuechessman[steps].X = AIpoint.X;//是的,这样没错,X,Y正确赋值
            Queuechessman[steps].Y = AIpoint.Y;
            chessmancolor[steps] = color;
           
            ///--------------------------------------------------
            ///--------------------------------------------------
            ///--------------------------------------------------
            if (color == 1)
            {
                //如果是黑 数组中放入黑棋
                //数组下标与点的下标一一对应
                pieces[AIpoint.X, AIpoint.Y] = new BlackPiece(realPoint.X, realPoint.Y);
            }
            else if (color == 2)
            {
                pieces[AIpoint.X, AIpoint.Y] = new WhitePiece(realPoint.X, realPoint.Y);
            }
            lastPlaceNode = AIpoint;//如果成功放入黑棋/白棋 记录最新的交叉点 
            return pieces[AIpoint.X, AIpoint.Y];//返回之前判断黑或白
        }
        //放入一颗棋子 x,y ,枚举类型的type
        public Piece PlaceAPiece(int x,int y,PieceType type)
        {
            //获取最近的交叉点
            Point nodeId = FindTheClosestNode(x, y);
            //如果是无效的交叉点 则产生一个空的棋子
            //交叉点不存在 棋子也不存在
            if (nodeId == NO_MATCH_NODE)
                return null;

            //避免同一位置重复放入棋子
            //Console.WriteLine("nodeID.X= " + nodeId.X);
           // Console.WriteLine("nodeID.Y= " + nodeId.Y);

            if (pieces[nodeId.X, nodeId.Y] != null)
                return null;
            ///----------------------------------
            ///----------------------------------
            ///2021.7.26新增
            steps++;
            Queuechessman[steps].X = nodeId.X;//是的,这样没错,X,Y正确赋值
            Queuechessman[steps].Y = nodeId.Y;
            if(type==PieceType.BLACK)
            {
                chessmancolor[steps] = 1;
            }
            else if(type==PieceType.WHITE)
            {
                chessmancolor[steps] = 2;
            }
            
            Point realPoint = ConvertToRealPosition(nodeId);//获得真实点坐标
            if(type==PieceType.BLACK)
            {
                //如果是黑 数组中放入黑棋
                //数组下标与点的下标一一对应
                pieces[nodeId.X, nodeId.Y] = new BlackPiece(realPoint.X, realPoint.Y);
            }
            else if(type== PieceType.WHITE)
            {
                pieces[nodeId.X, nodeId.Y] = new WhitePiece(realPoint.X, realPoint.Y);
            }
            lastPlaceNode = nodeId;//如果成功放入黑棋/白棋 记录最新的交叉点 
            return pieces[nodeId.X, nodeId.Y];//返回之前判断黑或白
        }

        public PieceType GetPieceType(int nodeIdX, int nodeIdY )
        {
            if(pieces[nodeIdX, nodeIdY]==null)
            {
                return PieceType.NONE;
            }
            if (pieces[nodeIdX, nodeIdY] is BlackPiece)//is 判断是什么类型
            {
                return PieceType.BLACK;
            }
            if (pieces[nodeIdX, nodeIdY] is WhitePiece)//is 判断是什么类型
            {
                return PieceType.WHITE;
            }
            
            return PieceType.NONE;
        }
        

        public bool CanBePlaced(int x,int y)//布尔类型装载
        {
            Point nodeId = FindTheClosestNode(x,y);
            if(nodeId==NO_MATCH_NODE)
            {
                return false;
            }
            return true;
        }
        //二维查找交叉点
        public Point FindTheClosestNode(int x,int y)
        {
            int nodeIdx = FindTheClosestNode(x);
            if(nodeIdx==-1)
            {
                return NO_MATCH_NODE;
            }
            int nodeIdy = FindTheClosestNode(y);
            if (nodeIdy == -1)
            {
                return NO_MATCH_NODE;
            }
            //升维
            return new Point(nodeIdx, nodeIdy);
        }
        //一维查找
        public int FindTheClosestNode(int pos)
        {
            if (pos < OFFSET - NODE_RADIUS)//在边界
            {
                return -1;
            }
            pos -= OFFSET;//去掉边界距离
            int quotient = pos / NODE_DISTANCEA;//求商 恰恰是对应的第几个70的坐标
            int remainder = pos % NODE_DISTANCEA;//求余数 恰恰是这个点和左边交叉点的距离
            
            if (remainder<=NODE_RADIUS)
            {
                return quotient;//第几个棋子 返回左边的棋子 左边交叉点下标
            }
            else if(remainder>=NODE_DISTANCEA- NODE_RADIUS)
            {
                return quotient+1;//返回右边的棋子 右边交叉点下标
            }
            else
            {
                return -1;//有效下标 从零开始 返回-1是无效
            }
        }
    }
}
