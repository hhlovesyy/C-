using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 五子棋
{
    class Game//带逻辑操作放入这里
    {
        private Borad borad = new Borad();//建立 棋盘 对象
        public PieceType currentPlayer = PieceType.BLACK;//默认当前玩家棋子是黑棋
        public PieceType AIplayer = PieceType.WHITE;//默认AI当前棋子为白棋
        private PieceType winner = PieceType.NONE;//私有封装 预先设定赢家是空
        public PieceType CurrentPlayer
        {
            get
            {
                return currentPlayer;
            }
        }
        public PieceType Winner //公有调用
        {
            get
            {
                return winner;
            }
        }
        public int ReadFileLines(string sFilename)//这个函数用来返回形参的文件中一共有多少行
        {
            int cnt = 0;
            using (StreamReader sr = new StreamReader(sFilename))
            {
                string line;
                // 从文件读取并显示行，直到文件的末尾 
                while ((line = sr.ReadLine()) != null)
                {
                    cnt++;
                }
            }
            borad.SetGameSavingPiece(sFilename);//这个时候顺便让棋盘存好这些子
            return cnt;
        }
        public Piece GetTopPiece()
        {
            Piece toppiece = borad.GetTopPiece();
            int playercolor = borad.GetnowPlayerColor();
            if(playercolor==1)
            {
                currentPlayer = PieceType.BLACK;
            }
            else if(playercolor==2)
            {
                currentPlayer = PieceType.WHITE;
            }
            return toppiece;
        }
        public Piece PlaceAPieceFromFile(int color,int x,int y)//这个是直接下在的某个位置,x和y是下标值不是真实坐标
        {
            Piece piece = borad.GiveAPieceFromFile(x, y, color);
            return piece;
        }
        public Piece AIPlaceAPiece(int x, int y, int color)//这个是针对于AI的,会在玩家下棋之后进行调用
        {
            Piece piece2 = borad.PlaceAPiece(x, y, color);
            if (piece2 != null)
            {
                //Console.WriteLine("AI下完棋要检验一下是不是有赢家");
                CheckWinner();
            }

            return piece2;
        }
        public Piece PlaceAPiece(int x,int y)// 重构 将部分代码封装在新的代码中
        {
            //这段代码是从FrmGobang窗体代码中抽出来的逻辑代码 封装到【game】中 不抽离界面代码 即重构
            Piece  piece= borad.PlaceAPiece(x,y,currentPlayer);
            if(piece!=null)
            {
                //生成新的棋子后 马上判断有没有赢家
                CheckWinner();
                if (GameManager.nowplaywithAI == false)
                {
                    if (currentPlayer == PieceType.BLACK)//PieceType enum 枚举
                    {
                        currentPlayer = PieceType.WHITE;
                    }
                    else if (currentPlayer == PieceType.WHITE)
                    {
                        currentPlayer = PieceType.BLACK;
                    }
                }
                else if (GameManager.nowplaywithAI == true)
                {
                    currentPlayer = PieceType.BLACK;
                }
               
            }
            return piece;
        }
        public bool CanBePlaced(int x,int y)
        {
            return borad.CanBePlaced(x,y);
        }
        public void CheckWinner()
        {
            int centerX = borad.LlastPlaceNode.X;//中心点的X=棋盘上最后一个交叉点的坐标（下标而不是真实位置）
            int centerY = borad.LlastPlaceNode.Y;//中心点的Y

            PieceType currentpiecetype = borad.GetPieceType(centerX, centerY);
            //dx，dy循环固定的方向  checkDx checkDy 是查找的方向 可能反向
            for (int dx = -1; dx <= 1; dx++)//dx方向变量 通过正负 0 控制增加 减少 不动
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (dx == 0 && dy == 0) //自己和自己不用判断 只要判断其他八个方向
                    {
                        continue;
                    }
                    int reverse = 0;//反向的次数 默认为0
                    int checkDx = dx;//动态考察 /移动的方向X 可能出现反向 不希望影响到外部的循环
                    int checkDy = dy;//动态考察 /移动的方向Y 可能出现反向

                    int count = 1;//这个棋子有一个了 反正是某一种 黑/白/NULL
                    int step = 0;//考察次数/移动的步子的次数 最多不能超过4
                    int distance = 1;//考察点和中心点的距离 绝对值

                    while (step < 4)//默认循环次数是4次 五颗同色的 则count=5
                    {
                        step++;//先往某一个方向走1步

                        int targetX = centerX + distance * checkDx;//考察点的X
                        int targetY = centerY + distance * checkDy;////考察点的Y

                        //如果找到的 超出了边界 或者不是同色的棋子 那么需要反向 这一步不算数 （中心和考察的）距离回到1
                       
                            if (   targetX <0  || targetX >= Borad.NODE_COUNT // 类名调用？
                                || targetY < 0 || targetY >= Borad.NODE_COUNT
                                || borad.GetPieceType(targetX, targetY) != currentpiecetype)
                            {
                                reverse++;//记录反向操作一次
                                checkDx = -checkDx;//方向反转
                                checkDy = -checkDy;
                                step--;//不作数，循环从头计数
                                distance = 1;//重置距离绝对值为1
                            }
                            //如果没有出边界 且是同色的 那么同色的棋子个数+1 距离加1
                            else
                            {
                                count++;
                                distance++;
                            }
                            //如果反向次数达到2次，终止循环
                            if(reverse==2)
                            {
                                break;//得到一颗不同色的棋子 达不到5个同色子
                            }                     
                        
                    }
                    if (count == 5)
                    {
                        winner = currentpiecetype;
                        GameManager.hasgotawinner = true;
                        return;  
                    }
                }
            
               
            }
        }
        public void Reload()
        {
            GameManager.hasgotawinner = false;
            currentPlayer = PieceType.BLACK;
            AIplayer = PieceType.WHITE;
            winner = PieceType.NONE;
            borad.Reload();
            
        }
    }
}
