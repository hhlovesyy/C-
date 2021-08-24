using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 五子棋
{
        /// <summary>
        /// 大问题:
        /// 1.解决color的类型问题
        /// 2.解决二维数组到底是先i后j还是先j后i的问题,以及对应的下标问题
        /// </summary>
        partial class Borad //这里继续写Borad类,用来写人工智能AI
        {
            ////对模型进行估值

            //成五
            private const int BE_FIVE = 1000000;
            //活四
            private const int ACTIVIE_FOUR = 50000;//原来5000
                                                   //冲四
            private const int RUSH_FOUR = 4000;//原来3000
                                               //活三
            private const int ACTIVIE_THREE = 3000;//原来3000
                                                   //眠三
            private const int SLEEP_THREE = 2000;//原来200
                                                 //活二
            private const int ACTIVE_TWO = 1000;//原来200
                                                //眠二
            private const int SLEEP_TWO = 500;//原来10
                                              //其他
            private const int OTHER = 10;//原来是1

            //棋型,后续会有函数判断当前场上是什么棋局
            public enum SituationType //枚举类型,表示目前棋面上的情况
            {
                BeFive,//成五
                ActiveFour,//活四
                RushFour,//冲四
                ActiveThree,//活三
                SleepThree,//眠三
                ActiveTwo,//活二
                SleepTwo,//眠二
                Other//其他
            }
            /// <summary>
            /// AI下下一步棋的内部位置,位置取整型(第几行,第几列)
            /// </summary>
            /// <param name="color"></param>
            /// <returns></returns>
            public Point ComputerNextStep(int color)//color的类型似乎不是int,后面再改一下吧
            {
                //Console.WriteLine("进入到ComputerNextStep函数");
                int[,] ScoreMyPoint = new int[NODE_COUNT, NODE_COUNT];
                int[,] ScoreOppPoint = new int[NODE_COUNT, NODE_COUNT];//分别记录棋盘每个位置的玩家的分数和AI的分数
                for (int i = 0; i < NODE_COUNT; i++)
                {
                    for (int j = 0; j < NODE_COUNT; j++)
                    {
                        //if (pieces[j, i] != null)//如果当前位置还没有下棋才进行估值,否则不进行估值,这里的i,j顺序要务必注意,尤其要考虑后面函数调用的问题,调用的时候i表示x轴,j表示y轴
                        //{
                        //    Console.WriteLine("不估值不估值 "+i+j);
                        //    continue;
                        //}
                        //else 
                        if (pieces[j, i] == null)
                        {
                            //Console.WriteLine("当前位置pieces[i,j]==null");
                            int SumMy = evaluate(i, j, color);//j,i是因为后续换算成坐标的时候,j增加的方向才是x轴方向,i增加方向为y方向,具体还是要一会看一下别的部分的代码是怎么写的
                            int SumOppo = evaluate(i, j, 3 - color);//算出玩家和AI此时的分数
                                                                    //进行玩家和AI分数数组的赋值
                            ScoreMyPoint[i, j] = SumMy;
                            ScoreOppPoint[i, j] = SumOppo;
                        }
                    }
                }

                //for (int i = 0; i < NODE_COUNT; i++)
                //{
                //    for (int j = 0; j < NODE_COUNT; j++)
                //    {
                //        //Console.WriteLine("i=" + i + " j=" + j + " sum=" + ScoreMyPoint[i, j]);
                //    }
                //}

                Point myBest = GetBestPoint(ScoreMyPoint);
                //Console.WriteLine("mybestx= " + myBest.X);
                //Console.WriteLine("mybesty= " + myBest.Y);


                Point oppBest = GetBestPoint(ScoreOppPoint);
                //Console.WriteLine("oppbestx= " + oppBest.X);
                //Console.WriteLine("oppbesty= " + oppBest.Y);
                //if(pieces[myBest.X,myBest.Y]!=null)
                //{
                //    return oppBest;
                //}
                //else if(pieces[oppBest.X, oppBest.Y] != null)
                //{
                //    return myBest;
                //}
                if (myBest != oppBest)
                {
                    if (ScoreOppPoint[oppBest.Y, oppBest.X] > ScoreMyPoint[myBest.Y, myBest.X])//站在AI的角度oppo指的是玩家,所以要去判断目前更需要堵玩家还是更需要让自己棋变得更好
                    {
                        return oppBest;
                    }
                    else
                    {
                        return myBest;
                    }
                }
                else
                {
                    return myBest;
                }
            }
            /// <summary>
            /// 评估对应的点的分数,利用每个棋型的分数进行判断赋值
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <param name="color">规定一下color=1是黑,color=2是白吧</param>
            /// <returns></returns>
            public int evaluate(int x, int y, int color)//同样,颜色类型应该不是int,后面再说
            {
                //Console.WriteLine("现在进入evaluate估值函数");
                int sum = 0;
                for (int i = 0; i < 4; i++)//对四个方向进行类型评估
                {
                    SituationType nowsituation = GetSituationType(x, y, i, color);
                    switch (nowsituation)
                    {
                        case SituationType.BeFive:
                            sum += BE_FIVE;
                            break;
                        case SituationType.ActiveFour:
                            sum += ACTIVIE_FOUR;
                            break;
                        case SituationType.RushFour:
                            sum += RUSH_FOUR;
                            break;
                        case SituationType.ActiveThree:
                            sum += ACTIVIE_THREE;
                            break;
                        case SituationType.SleepThree:
                            sum += SLEEP_THREE;
                            break;
                        case SituationType.ActiveTwo:
                            sum += ACTIVE_TWO;
                            break;
                        case SituationType.SleepTwo:
                            sum += SLEEP_TWO;
                            break;
                        default:
                            sum += OTHER;
                            break;
                    }
                }
                return sum;
            }
            /// <summary>
            /// 根据棋盘上每个点的分数数组所得到的值来判断哪个点是最优的结果(也就是对于玩家来说最大的)
            /// </summary>
            /// <param name="map">分值表,传入的是玩家的和AI的分值</param>
            /// <returns></returns>
            private Point GetBestPoint(int[,] map)
            {
                int iMax = 0;
                int jMax = 0;//存储分数最大值的点的下标
                for (int i = 0; i < NODE_COUNT; i++)
                {
                    for (int j = 0; j < NODE_COUNT; j++)
                    {
                        if (map[i, j] > map[iMax, jMax])
                        {
                            iMax = i;
                            jMax = j;
                        }
                    }
                }
                return new Point(jMax, iMax);
            }
            /// <summary>
            /// 以下函数用于判断此时的棋局是什么形势,比如活四冲四等,判断不是之后继续判断
            /// </summary>
            /// <param name="x">x轴索引值</param>
            /// <param name="y">y轴索引值</param>
            /// <param name="dir">方向,分别对应上下,左右,左上到右下,左下到右上</param>
            /// <param name="color"></param>
            /// <returns></returns>
            public SituationType GetSituationType(int x, int y, int dir, int color)
            {
                //Console.WriteLine("现在进入到GetSituationType函数当中,同时打印一下x和y");
                //Console.WriteLine("x=" + x);
                //Console.WriteLine("y=" + y);
                SituationType type = JudgeBeFive(x, y, dir, color);
                if (type == SituationType.Other)
                {
                    // Console.WriteLine("检验一下活四有没有");
                    type = JudgeActiveFour(x, y, dir, color);
                    if (type == SituationType.Other)
                    {
                        // Console.WriteLine("检验一下冲四有没有");
                        type = JudgeRushFour(x, y, dir, color);
                        if (type == SituationType.Other)
                        {
                            // Console.WriteLine("检验一下是不是活三眠三");
                            type = JudgeActiveThreeSleepThree(x, y, dir, color);
                            if (type == SituationType.Other)
                            {
                                // Console.WriteLine("检验一下是不是活二眠二");
                                return type = JudgeActiveTwoSleepTwo(x, y, dir, color);
                            }
                            else
                            {
                                //Console.WriteLine("都不是");
                                return type;
                            }

                        }
                        else
                            return type;
                    }
                    else
                        return type;
                }
                else
                    return type;
            }

            public int ChangeZero(int n) //如果n是0就按照1处理,这样做的用途是判断的时候去掉自己
            {
                return (n == 0) ? 1 : n;
            }
            /// <summary>
            /// 对于下述的规定函数,我们约定dir=0为上下方向,dir=1为左右方向,dir=2为左下到右上方向,dir=3为左上到右下方向
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <param name="dir"></param>
            /// <param name="color"></param>
            /// <returns></returns>
            //以下函数用于判断是否是活五,只要找到了一个活五就被认为是活五,返回即可
            private SituationType JudgeBeFive(int x, int y, int dir, int color)
            {
                for (int i = 1; i >= -4; i--)
                {
                    if (i == 0) continue;//绕过对于自己本身的判断
                    int delta1 = i;
                    int delta2 = ChangeZero(delta1 + 1);
                    int delta3 = ChangeZero(delta2 + 1);
                    int delta4 = ChangeZero(delta3 + 1);
                    if (dir == 0)
                    {
                        //Console.WriteLine("现在在JudgeBeFive当中,目前在检测dir==0");
                        Point p1 = new Point(x, y + delta1);
                        Point p2 = new Point(x, y + delta2);
                        Point p3 = new Point(x, y + delta3);
                        Point p4 = new Point(x, y + delta4);
                        if (BeFiveHelper(p1, p2, p3, p4, color))
                            return SituationType.BeFive;
                    }
                    else if (dir == 1)
                    {
                        Point p1 = new Point(x + delta1, y);
                        Point p2 = new Point(x + delta2, y);
                        Point p3 = new Point(x + delta3, y);
                        Point p4 = new Point(x + delta4, y);
                        if (BeFiveHelper(p1, p2, p3, p4, color))
                            return SituationType.BeFive;
                    }
                    else if (dir == 2)
                    {
                        Point p1 = new Point(x + delta1, y + delta1);
                        Point p2 = new Point(x + delta2, y + delta2);
                        Point p3 = new Point(x + delta3, y + delta3);
                        Point p4 = new Point(x + delta4, y + delta4);
                        if (BeFiveHelper(p1, p2, p3, p4, color))
                            return SituationType.BeFive;
                    }
                    else
                    {
                        Point p1 = new Point(x + delta1, y - delta1);
                        Point p2 = new Point(x + delta2, y - delta2);
                        Point p3 = new Point(x + delta3, y - delta3);
                        Point p4 = new Point(x + delta4, y - delta4);
                        if (BeFiveHelper(p1, p2, p3, p4, color))
                            return SituationType.BeFive;
                    }
                }
                return SituationType.Other;//所有的都没有判断出来,那就是没有活五了,返回Other用于判断下一种情况
            }

            //以下函数用于判断是否是活四,也就是判断六个子当中最外面的两个字是否为空且中间的是否为同色
            private SituationType JudgeActiveFour(int x, int y, int dir, int color)
            {
                //Console.WriteLine("现在来检测一下活四的情况,进入到JudgeAcriveFOUR");
                for (int i = -1; i >= -4; i--)
                {
                    int delta1 = i;
                    int delta2 = ChangeZero(delta1 + 1);
                    int delta3 = ChangeZero(delta2 + 1);
                    int delta4 = ChangeZero(delta3 + 1);
                    int delta5 = ChangeZero(delta4 + 1);
                    if (dir == 0)
                    {
                        Point p1 = new Point(x, y + delta1);
                        Point p2 = new Point(x, y + delta2);
                        Point p3 = new Point(x, y + delta3);
                        Point p4 = new Point(x, y + delta4);
                        Point p5 = new Point(x, y + delta5);
                        if (ActiveFourHelper(p1, p2, p3, p4, p5, color))
                        {
                            return SituationType.ActiveFour;
                        }
                    }
                    else if (dir == 1)
                    {
                        Point p1 = new Point(x + delta1, y);
                        Point p2 = new Point(x + delta2, y);
                        Point p3 = new Point(x + delta3, y);
                        Point p4 = new Point(x + delta4, y);
                        Point p5 = new Point(x + delta5, y);
                        if (ActiveFourHelper(p1, p2, p3, p4, p5, color))
                        {
                            return SituationType.ActiveFour;
                        }
                    }
                    else if (dir == 2)
                    {
                        Point p1 = new Point(x + delta1, y + delta1);
                        Point p2 = new Point(x + delta2, y + delta2);
                        Point p3 = new Point(x + delta3, y + delta3);
                        Point p4 = new Point(x + delta4, y + delta4);
                        Point p5 = new Point(x + delta5, y + delta5);
                        if (ActiveFourHelper(p1, p2, p3, p4, p5, color))
                        {
                            return SituationType.ActiveFour;
                        }
                    }
                    else if (dir == 3)
                    {
                        Point p1 = new Point(x + delta1, y - delta1);
                        Point p2 = new Point(x + delta2, y - delta2);
                        Point p3 = new Point(x + delta3, y - delta3);
                        Point p4 = new Point(x + delta4, y - delta4);
                        Point p5 = new Point(x + delta5, y - delta5);
                        if (ActiveFourHelper(p1, p2, p3, p4, p5, color))
                        {
                            return SituationType.ActiveFour;
                        }
                    }
                }
                return SituationType.Other;
            }
            //以下函数用于判断是否是冲四,也就是有一个连五点,所以其实就是连五的情况去掉了一个点(这个点为空)
            //相对比活四来说，冲四的威胁性就小了很多，因为这个时候，对方只要跟着防守在那个唯一的连五点上，冲四就没法形成连五。
            private SituationType JudgeRushFour(int x, int y, int dir, int color)
            {
                for (int i = 1; i >= -4; i--)
                {
                    if (i == 0)
                        continue;
                    else
                    {
                        int delta1 = i;
                        int delta2 = ChangeZero(i + 1);
                        int delta3 = ChangeZero(delta2 + 1);
                        int delta4 = ChangeZero(delta3 + 1);

                        if (dir == 0) //上下方向
                        {
                            Point p1 = new Point(x, y + delta1);
                            Point p2 = new Point(x, y + delta2);
                            Point p3 = new Point(x, y + delta3);
                            Point p4 = new Point(x, y + delta4);
                            if (RushFourHelper(p1, p2, p3, p4, color))
                                return SituationType.RushFour;
                        }
                        else if (dir == 1) //左右方向
                        {
                            Point p1 = new Point(x + delta1, y);
                            Point p2 = new Point(x + delta2, y);
                            Point p3 = new Point(x + delta3, y);
                            Point p4 = new Point(x + delta4, y);
                            if (RushFourHelper(p1, p2, p3, p4, color))
                                return SituationType.RushFour;
                        }
                        else if (dir == 2) //左斜线
                        {
                            Point p1 = new Point(x + delta1, y + delta1);
                            Point p2 = new Point(x + delta2, y + delta2);
                            Point p3 = new Point(x + delta3, y + delta3);
                            Point p4 = new Point(x + delta4, y + delta4);
                            if (RushFourHelper(p1, p2, p3, p4, color))
                                return SituationType.RushFour;
                        }
                        else //右斜线
                        {
                            Point p1 = new Point(x + delta1, y - delta1);
                            Point p2 = new Point(x + delta2, y - delta2);
                            Point p3 = new Point(x + delta3, y - delta3);
                            Point p4 = new Point(x + delta4, y - delta4);
                            if (RushFourHelper(p1, p2, p3, p4, color))
                                return SituationType.RushFour;
                        }
                    }
                }
                return SituationType.Other;
            }
            //以下函数用于判断是活三还是眠三
            private SituationType JudgeActiveThreeSleepThree(int x, int y, int dir, int color)
            {
                for (int i = -1; i >= -4; i--)
                {
                    int delta1 = i;
                    int delta2 = ChangeZero(i + 1);
                    int delta3 = ChangeZero(delta2 + 1);
                    int delta4 = ChangeZero(delta3 + 1);
                    int delta5 = ChangeZero(delta4 + 1);

                    if (dir == 0) //上下方向
                    {
                        Point p1 = new Point(x, y + delta1);
                        Point p2 = new Point(x, y + delta2);
                        Point p3 = new Point(x, y + delta3);
                        Point p4 = new Point(x, y + delta4);
                        Point p5 = new Point(x, y + delta5);
                        int res = ActiveThreeSleepThreeHelper(p1, p2, p3, p4, p5, color);
                        if (res == 2)
                            return SituationType.ActiveThree;
                        else if (res == 1)
                            return SituationType.SleepThree;
                    }
                    else if (dir == 1) //左右方向
                    {
                        Point p1 = new Point(x + delta1, y);
                        Point p2 = new Point(x + delta2, y);
                        Point p3 = new Point(x + delta3, y);
                        Point p4 = new Point(x + delta4, y);
                        Point p5 = new Point(x + delta5, y);
                        int res = ActiveThreeSleepThreeHelper(p1, p2, p3, p4, p5, color);
                        if (res == 2)
                            return SituationType.ActiveThree;
                        else if (res == 1)
                            return SituationType.SleepThree;
                    }
                    else if (dir == 2) //左斜线
                    {
                        Point p1 = new Point(x + delta1, y + delta1);
                        Point p2 = new Point(x + delta2, y + delta2);
                        Point p3 = new Point(x + delta3, y + delta3);
                        Point p4 = new Point(x + delta4, y + delta4);
                        Point p5 = new Point(x + delta5, y + delta5);
                        int res = ActiveThreeSleepThreeHelper(p1, p2, p3, p4, p5, color);
                        if (res == 2)
                            return SituationType.ActiveThree;
                        else if (res == 1)
                            return SituationType.SleepThree;
                    }
                    else //右斜线
                    {
                        Point p1 = new Point(x + delta1, y - delta1);
                        Point p2 = new Point(x + delta2, y - delta2);
                        Point p3 = new Point(x + delta3, y - delta3);
                        Point p4 = new Point(x + delta4, y - delta4);
                        Point p5 = new Point(x + delta5, y - delta5);
                        int res = ActiveThreeSleepThreeHelper(p1, p2, p3, p4, p5, color);
                        if (res == 2)
                            return SituationType.ActiveThree;
                        else if (res == 1)
                            return SituationType.SleepThree;
                    }
                }
                return SituationType.Other;
            }
            //以下函数用于判断是活二还是眠二
            private SituationType JudgeActiveTwoSleepTwo(int x, int y, int dir, int color)
            {
                for (int i = -1; i >= -4; i--)
                {
                    int delta1 = i;
                    int delta2 = ChangeZero(i + 1);
                    int delta3 = ChangeZero(delta2 + 1);
                    int delta4 = ChangeZero(delta3 + 1);
                    int delta5 = ChangeZero(delta4 + 1);

                    if (dir == 0) //上下方向
                    {
                        Point p1 = new Point(x, y + delta1);
                        Point p2 = new Point(x, y + delta2);
                        Point p3 = new Point(x, y + delta3);
                        Point p4 = new Point(x, y + delta4);
                        Point p5 = new Point(x, y + delta5);
                        int res = ActiveTwoSleepTwoHelper(p1, p2, p3, p4, p5, color);
                        if (res == 2)
                            return SituationType.ActiveTwo;
                        else if (res == 1)
                            return SituationType.SleepTwo;
                    }
                    else if (dir == 1) //左右方向
                    {
                        Point p1 = new Point(x + delta1, y);
                        Point p2 = new Point(x + delta2, y);
                        Point p3 = new Point(x + delta3, y);
                        Point p4 = new Point(x + delta4, y);
                        Point p5 = new Point(x + delta5, y);
                        int res = ActiveTwoSleepTwoHelper(p1, p2, p3, p4, p5, color);
                        if (res == 2)
                            return SituationType.ActiveTwo;
                        else if (res == 1)
                            return SituationType.SleepTwo;
                    }
                    else if (dir == 2) //左斜线
                    {
                        Point p1 = new Point(x + delta1, y + delta1);
                        Point p2 = new Point(x + delta2, y + delta2);
                        Point p3 = new Point(x + delta3, y + delta3);
                        Point p4 = new Point(x + delta4, y + delta4);
                        Point p5 = new Point(x + delta5, y + delta5);
                        int res = ActiveTwoSleepTwoHelper(p1, p2, p3, p4, p5, color);
                        if (res == 2)
                            return SituationType.ActiveTwo;
                        else if (res == 1)
                            return SituationType.SleepTwo;
                    }
                    else //右斜线
                    {
                        Point p1 = new Point(x + delta1, y - delta1);
                        Point p2 = new Point(x + delta2, y - delta2);
                        Point p3 = new Point(x + delta3, y - delta3);
                        Point p4 = new Point(x + delta4, y - delta4);
                        Point p5 = new Point(x + delta5, y - delta5);
                        int res = ActiveTwoSleepTwoHelper(p1, p2, p3, p4, p5, color);
                        if (res == 2)
                            return SituationType.ActiveTwo;
                        else if (res == 1)
                            return SituationType.SleepTwo;
                    }
                }
                return SituationType.Other;
            }
            /// <summary>
            /// 以下函数会传入前面判断冲四冲五时候的四个生成的点,并进而判断是否可以形成相关的棋局
            /// </summary>
            /// <param name="p1"></param>
            /// <param name="p2"></param>
            /// <param name="p3"></param>
            /// <param name="p4"></param>
            /// <param name="color"></param>
            /// <returns></returns>
            private bool BeFiveHelper(Point p1, Point p2, Point p3, Point p4, int color)
            {
                //Console.WriteLine("现在在BeFiveHelper函数当中,目前要检验一下四个点的x和y是否是正常的");
                //Console.WriteLine("p1:" + p1.X + "   " + p1.Y);
                //Console.WriteLine("p2:" + p2.X + "   " + p2.Y);
                //Console.WriteLine("p3:" + p3.X + "   " + p3.Y);
                // Console.WriteLine("p4:" + p4.X + "   " + p4.Y);
                if (LocateAndColorisOK(p1, color) && LocateAndColorisOK(p2, color) && LocateAndColorisOK(p3, color) && LocateAndColorisOK(p4, color))
                {
                    return true;
                }
                else
                    return false;
            }
            private bool ActiveFourHelper(Point p1, Point p2, Point p3, Point p4, Point p5, int color)
            {
                //Console.WriteLine("进入到ActiveFourHelper");
                if (IsEmptyLocate(p1) && IsEmptyLocate(p5) && LocateAndColorisOK(p2, color) && LocateAndColorisOK(p3, color) && LocateAndColorisOK(p4, color))
                {
                    return true;
                }
                else
                    return false;
            }
            private bool RushFourHelper(Point p1, Point p2, Point p3, Point p4, int color)
            {
                if (IsEmptyLocate(p1) && LocateAndColorisOK(p2, color) && LocateAndColorisOK(p3, color) && LocateAndColorisOK(p4, color))
                    return true;
                else if (LocateAndColorisOK(p1, color) && IsEmptyLocate(p2) && LocateAndColorisOK(p3, color) && LocateAndColorisOK(p4, color))
                    return true;
                else if (LocateAndColorisOK(p1, color) && LocateAndColorisOK(p2, color) && IsEmptyLocate(p3) && LocateAndColorisOK(p4, color))
                    return true;
                else if (LocateAndColorisOK(p1, color) && LocateAndColorisOK(p2, color) && LocateAndColorisOK(p3, color) && IsEmptyLocate(p4))
                    return true;
                else
                    return false;
            }
            /// <summary>
            /// 活三，眠三判断条件
            /// </summary>
            /// <param name="p1"></param>
            /// <param name="p2"></param>
            /// <param name="p3"></param>
            /// <param name="p4"></param>
            /// <param name="p5"></param>
            /// <param name="color"></param>
            /// <returns>2为活三，1为眠三</returns>
            private int ActiveThreeSleepThreeHelper(Point p1, Point p2, Point p3, Point p4, Point p5, int color)
            {
                //bool oneSide = (ExitAnotherColor(p5, color) && IsEmptyLocate(p1)) || (ExitAnotherColor(p1, color) && IsEmptyLocate(p5));
                bool oneSide = (!IsEmptyLocate(p5) && IsEmptyLocate(p1)) || (!IsEmptyLocate(p1) && IsEmptyLocate(p5));
                if (IsEmptyLocate(p1) && IsEmptyLocate(p2) && LocateAndColorisOK(p3, color) && LocateAndColorisOK(p4, color) && IsEmptyLocate(p5))
                    return 2;
                else if (IsEmptyLocate(p1) && LocateAndColorisOK(p2, color) && IsEmptyLocate(p3) && LocateAndColorisOK(p4, color) && IsEmptyLocate(p5))
                    return 2;
                else if (IsEmptyLocate(p1) && LocateAndColorisOK(p2, color) && LocateAndColorisOK(p3, color) && IsEmptyLocate(p4) && IsEmptyLocate(p5))
                    return 2;
                else if (IsEmptyLocate(p2) && LocateAndColorisOK(p3, color) && LocateAndColorisOK(p4, color) && oneSide)
                    return 1;
                else if (LocateAndColorisOK(p2, color) && IsEmptyLocate(p3) && LocateAndColorisOK(p4, color) && oneSide)
                    return 1;
                else if (LocateAndColorisOK(p2, color) && LocateAndColorisOK(p3, color) && IsEmptyLocate(p4) && oneSide)
                    return 1;
                else
                    return 0;
            }

            private int ActiveTwoSleepTwoHelper(Point p1, Point p2, Point p3, Point p4, Point p5, int color)//这个函数目前也没有检验是不是正确的,只是目前先看一下能不能下棋
            {
                bool oneSide = (!IsEmptyLocate(p5) && IsEmptyLocate(p1)) || (IsEmptyLocate(p5) && !IsEmptyLocate(p1));
                //bool oneSide= (!ExitAnotherColor(p5,color) && IsEmptyLocate(p1)) || (IsEmptyLocate(p5) && ExitAnotherColor(p1,color));
                if (IsEmptyLocate(p1) && LocateAndColorisOK(p2, color) && IsEmptyLocate(p3) && IsEmptyLocate(p4) && IsEmptyLocate(p5))
                    return 2;
                else if (IsEmptyLocate(p1) && IsEmptyLocate(p2) && LocateAndColorisOK(p3, color) && IsEmptyLocate(p4) && IsEmptyLocate(p5))
                    return 2;
                else if (IsEmptyLocate(p1) && IsEmptyLocate(p2) && IsEmptyLocate(p3) && LocateAndColorisOK(p4, color) && IsEmptyLocate(p5))
                    return 2;
                else if (LocateAndColorisOK(p2, color) && IsEmptyLocate(p3) && IsEmptyLocate(p4) && oneSide)
                    return 1;
                else if (IsEmptyLocate(p2) && LocateAndColorisOK(p3, color) && IsEmptyLocate(p4) && oneSide)
                    return 1;
                else if (IsEmptyLocate(p2) && IsEmptyLocate(p3) && LocateAndColorisOK(p4, color) && oneSide)
                    return 1;
                else
                    return 0;
            }
            private bool IsEmptyLocate(Point p)
            {
                if (NoCrossBorder(p.X, p.Y) && (pieces[p.Y, p.X] == null))
                    return true;
                else
                    return false;
            }
            public bool LocateAndColorisOK(Point p, int color)
            {
                //Console.WriteLine("现在来检测一下locateandcolorisok,理论上没意外的话每一轮需要检测四次的");
                if (color == 1)
                    return NoCrossBorder(p.X, p.Y) && (pieces[p.Y, p.X] is BlackPiece);
                else if (color == 2)
                    return NoCrossBorder(p.X, p.Y) && (pieces[p.Y, p.X] is WhitePiece);
                else
                    return false;
                //return true;
            }
            private bool ExitAnotherColor(Point p, int color)
            {
                if (color == 1)
                {
                    return NoCrossBorder(p.X, p.Y) && (pieces[p.X, p.Y] is WhitePiece);
                }
                else if (color == 2)
                {
                    return NoCrossBorder(p.X, p.Y) && (pieces[p.X, p.Y] is BlackPiece);
                }
                else
                    return false;
            }
            public bool NoCrossBorder(int x, int y)//此函数用于判断棋子是否发生了越界行为
            {
                // Console.WriteLine("现在检测一下x=" + x + "y=" + y + "的棋子是否发生了越界行为");
                bool isout = (x >= 0) && (x < NODE_COUNT) && (y >= 0) && (y < NODE_COUNT);
                //Console.WriteLine("刚才那颗棋子没越界吧?  " + isout);
                return isout;
            }

        }
    }

