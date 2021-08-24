using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace 五子棋
{   
    // 第一步：声明一个委托。（根据自己的需求）
    //注意：该委托必须声明在命名空间中，而不应该声明在类中，否则不能调用(新加)
    public delegate void ShouldReadFile(string sFilename);
    public partial class FrmGobang : Form
    {   //冒号表示继承 子类继承父类 自动获取父类的功能
        //第二步：声明一个委托类型的事件
        public event ShouldReadFile readingfile;
        /// <summary>
        /// 这个窗体用于AI和玩家下棋,玩家和玩家下棋,以下为该窗体的构造函数
        /// </summary>
        public FrmGobang()
        {
            InitializeComponent();
            //使窗体居中
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width - this.Size.Width) / 2;//设置窗体打开默认在右下角显示
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            this.StartPosition = FormStartPosition.Manual; //窗体的位置由Location属性决定
            this.Location = (Point)new Size(x, y);         //窗体的起始位置为(x,y)
            GameManager.hasgotawinner = false;
        }
        private Game game = new Game();
        public static Bitmap bmp;//这个用来存放当玩家点击设置的时候对棋盘进行截图(这是为了方便后续玩家保存存档的时候直接把图片放进去,不然不好实现)
        private void Form1_Load(object sender, EventArgs e)
        {
            //点多了,没用
        }

        private void pnlGobang_Paint(object sender, PaintEventArgs e)
        {
            //点多了,没用
        }

        private int stepN = 0;//步数N,全局变量,本身最主要是决定了每颗棋子上的那个数字

        /// <summary>
        /// 下面这个函数用于对玩家的点击下棋事件进行回应,用来处理玩家落子,GameManager用于判断此时是否是在和AI下棋
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlGobang_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (game.Winner != PieceType.NONE)//已经决出胜负,不再下棋了
            {
                return;
            }
            if (GameManager.nowplaywithAI == true)//如果是跟AI下棋,则玩家下棋之后AI需要做出反馈
            {
                Piece piece = game.PlaceAPiece(e.X, e.Y);
                if (piece != null)
                {
                    stepN++;
                    piece.Text = stepN.ToString();
                   
                    this.pnlGobang.Controls.Add(piece);//放置,然后切图片让AI下棋
                    if (game.Winner != PieceType.NONE)//已经决出胜负,不再下棋了
                    {
                        if (game.Winner == PieceType.BLACK)
                        {
                            this.lblCurrentPlayer.Text = "善哉，为师这就将筋斗云赐予你";
                            this.picCurrentPlayer.Image = piece.GetImage();//赢了就固定
                            if (GameManager.nowplaylevels == false)
                            {
                                FrmWin frmWin = new FrmWin();
                                frmWin.ShowDialog();
                            }
                            else if (GameManager.nowplaylevels == true)
                            {
                                //TODO:新建一个与闯关有关的页面,让用户跳转到下一关
                                FrmJumpToNextLevel JumpToNext = new FrmJumpToNextLevel();
                                JumpToNext.ShowDialog();
                                this.Dispose();
                            }
                        }
                        else if (game.Winner == PieceType.WHITE)
                        {
                            this.lblCurrentPlayer.Text = "习武之人要静得下心来";
                            this.picCurrentPlayer.Image = piece.GetImage();//赢了就固定
                            MessageBox.Show("悟空，你的修行还不够啊。");
                        }
                        return;
                    }
                    this.picCurrentPlayer.Image = piece.GetNextImage();//该谁下棋的照片切换
                    
                    Piece aipiece = game.AIPlaceAPiece(e.X, e.Y, 2);//AI的棋会被切换成为白色,AI调取后端函数开始下棋
                    if (aipiece != null)
                    {
                        stepN++;
                        aipiece.Text = stepN.ToString();
                        this.pnlGobang.Controls.Add(aipiece);//放置 某方下完 可以提示下一个
                        this.picCurrentPlayer.Image = aipiece.GetNextImage();//该谁下棋的照片切换

                    }
                    if (game.Winner == PieceType.BLACK)
                    {
                        this.lblCurrentPlayer.Text = "善哉，为师这就将筋斗云赐予你";
                        this.picCurrentPlayer.Image = piece.GetImage();//赢了就固定
                        if (GameManager.nowplaylevels == false)
                        {
                            FrmWin frmWin = new FrmWin();
                            frmWin.ShowDialog();
                        }
                        else if (GameManager.nowplaylevels == true)
                        {
                            //TODO:新建一个与闯关有关的页面,让用户跳转到下一关
                            FrmJumpToNextLevel JumpToNext = new FrmJumpToNextLevel();
                            this.Dispose();
                            JumpToNext.ShowDialog();
                            
                        }
                    }
                    else if (game.Winner == PieceType.WHITE)
                    {
                        this.lblCurrentPlayer.Text = "习武之人要静得下心来";
                        this.picCurrentPlayer.Image = piece.GetImage();//赢了就固定
                        MessageBox.Show("悟空，你的修行还不够啊。");
                    }

                    if (game.currentPlayer == PieceType.BLACK)
                    {
                        this.lblCurrentPlayer.Text = "悟空，轮到你落子了";
                    }
                    else if (game.currentPlayer == PieceType.WHITE)
                    {
                        this.lblCurrentPlayer.Text = "容为师思量片刻";
                    }
                   
                }
            }

            else if (GameManager.nowplaywithAI == false)//此时并非与AI下棋
            {
                Piece piece = game.PlaceAPiece(e.X, e.Y);
                if (piece != null)
                {
                    stepN++;
                    piece.Text = stepN.ToString();
                    //if (game.Winner != PieceType.NONE)//已经决出胜负,不再下棋了
                    //{
                    //    if (game.Winner == PieceType.BLACK)
                    //    {
                    //        this.lblCurrentPlayer.Text = "善哉，为师这就将筋斗云教授予你!";
                    //        this.picCurrentPlayer.Image = piece.GetImage();//赢了就固定
                    //        FrmWin frmWin = new FrmWin();
                    //        frmWin.ShowDialog();
                    //    }
                    //    else if (game.Winner == PieceType.WHITE)
                    //    {
                    //        this.lblCurrentPlayer.Text = "习武之人要静得下心来";
                    //        this.picCurrentPlayer.Image = piece.GetImage();//赢了就固定
                    //        MessageBox.Show("悟空，你的修行还不够啊。");
                    //    }
                    //    return;
                    //}

                    this.pnlGobang.Controls.Add(piece);//放置 某方下完 可以提示下一个
                    this.picCurrentPlayer.Image = piece.GetNextImage();//该谁下棋的照片切换

                    if (game.Winner == PieceType.BLACK)
                    {
                        this.lblCurrentPlayer.Text = "善哉，为师这就将筋斗云教授予你!";
                        //this.picCurrentPlayer.Image = piece.GetImage();//赢了就固定
                        this.picCurrentPlayer.Image = Properties.Resources.white2;
                        if(GameManager.nowplaylevels==false)
                        {
                            FrmWin frmWin = new FrmWin();
                            frmWin.ShowDialog();
                        }
                        else if(GameManager.nowplaylevels==true)
                        {
                            //TODO:新建一个与闯关有关的页面,让用户跳转到下一关
                            FrmJumpToNextLevel JumpToNext = new FrmJumpToNextLevel();
                            JumpToNext.ShowDialog();
                            this.Dispose();
                        }
                       
                    }
                    else if (game.Winner == PieceType.WHITE)
                    {
                        this.lblCurrentPlayer.Text = "习武之人要静得下心来";
                        //this.picCurrentPlayer.Image = piece.GetImage();//赢了就固定
                        this.picCurrentPlayer.Image = Properties.Resources.white2;
                        MessageBox.Show("悟空，你的修行还不够啊。");
                    }

                    if (game.currentPlayer == PieceType.BLACK)
                    {
                        this.lblCurrentPlayer.Text = "悟空，轮到你落子了";
                    }
                    else if (game.currentPlayer == PieceType.WHITE)
                    {
                        this.lblCurrentPlayer.Text = "容为师思量片刻";
                    }
                }
            }

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            //点多了,没用
        }
        /// <summary>
        /// 以下函数用于控制此时鼠标光标的形状,如果可以点击就显示手,否则显示禁止图案
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlGobang_MouseMove(object sender, MouseEventArgs e)
        {
            //鼠标移动事件判断能不能放棋子
            //通过切换鼠标样子
            if(game.CanBePlaced(e.X,e.Y)==true)//两个参数不变 都是界面代码
            {
                this.Cursor = Cursors.Hand;//设置鼠标样式 出现小手
            }
            else
            {
                this.Cursor = Cursors.No;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //点多了,没用
        }

        private void picCurrentPlayer_Click(object sender, EventArgs e)
        {
            //点多了,没用
        }
        /// <summary>
        /// 重新开始游戏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReload_Click(object sender, EventArgs e)
        {
            if(GameManager.nowplaylevels==false)
            {
                this.lblCurrentPlayer.Text = "悟空，轮到你落子了";
                this.picCurrentPlayer.Image = Properties.Resources.black2;
                this.pnlGobang.Controls.Clear();
                game.Reload();
                stepN = 0;
            }
            else if(GameManager.nowplaylevels==true)//闯关模式下重新开始会直接到现在的棋局
            {
                this.lblCurrentPlayer.Text = "悟空，轮到你落子了";
                this.picCurrentPlayer.Image = Properties.Resources.black2;
                this.pnlGobang.Controls.Clear();
                this.BeRefresh();
                this.ReadFile(FrmLevelsChoose.levels[FrmLevelsChoose.nowlevelchoose]);
               
            }
        }
        public void BeRefresh()//同样是刷新棋局,但是不通过button调用,而是通过对象调用的函数
        {
            this.picCurrentPlayer.Image = Properties.Resources.black2;
            this.pnlGobang.Controls.Clear();
            game.Reload();
            stepN = 0;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMainMenu frmMainMenu = new FrmMainMenu();
            this.Hide();
            frmMainMenu.ShowDialog();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(GameManager.nowplaylevels==true)
            {
                MessageBox.Show("闯关过程中不能悔棋!");
                return;
            }
            if(GameManager.nowplaywithAI==false)
            {
                if (GameManager.hasgotawinner == true)
                {
                    MessageBox.Show("胜负以分不能悔棋!");
                    return;
                 }
                Piece regretpiece = game.GetTopPiece();
                stepN--;
                if (stepN < 1) stepN = 0;
                this.pnlGobang.Controls.Remove(regretpiece);
                //if(this.pnlGobang.Controls.Count==0)
                //{
                //    stepN = 0;
                //}
                PieceType nowpiece = game.CurrentPlayer;
                if (nowpiece == PieceType.BLACK)
                {
                    this.picCurrentPlayer.Image = Properties.Resources.black2;
                    this.lblCurrentPlayer.Text = "悟空，轮到你落子了";
                }
                else if (nowpiece == PieceType.WHITE)
                {
                    this.picCurrentPlayer.Image = Properties.Resources.white2;
                    this.lblCurrentPlayer.Text = "容为师思量片刻";
                }
            }
            else if(GameManager.nowplaywithAI==true)//和AI下棋的时候每次需要回撤两步
            {
                if (GameManager.hasgotawinner == true&& game.Winner == PieceType.WHITE)
                {
                    MessageBox.Show("你这猢狲!输了还想抵赖不成?");
                    return;
                 }
                else if (GameManager.hasgotawinner == true && game.Winner == PieceType.BLACK)
                {
                    MessageBox.Show("善哉,你已经赢了,放过为师吧");
                    return;
                }
                Piece regretpiece1 = game.GetTopPiece();
                Piece regretpiece2 = game.GetTopPiece();
                stepN -=2;
                if (stepN < 1) stepN = 0;
                this.pnlGobang.Controls.Remove(regretpiece1);
                this.pnlGobang.Controls.Remove(regretpiece2);
                PieceType nowpiece = game.CurrentPlayer;
                if (nowpiece == PieceType.BLACK)
                {
                    this.picCurrentPlayer.Image = Properties.Resources.black2;
                    this.lblCurrentPlayer.Text = "悟空，轮到你落子了";
                }
                else if (nowpiece == PieceType.WHITE)
                {
                    this.picCurrentPlayer.Image = Properties.Resources.white2;
                    this.lblCurrentPlayer.Text = "容为师思量片刻";
                }
            }
        }
        private Bitmap GetScreen()
        {
            //获取整个屏幕图像,不包括任务栏
            Rectangle ScreenArea = Screen.GetWorkingArea(this);
            Bitmap bmp = new Bitmap(this.pnlGobang.Width, this.pnlGobang.Height);
            //using (Graphics g = Graphics.FromImage(bmp))
            //{
            //    g.CopyFromScreen(this.pnlGobang.Location.X,this.pnlGobang.Location.Y,0,0, new Size(this.pnlGobang.Width, this.pnlGobang.Height));
            //}            
            pnlGobang.DrawToBitmap(bmp, this.pnlGobang.ClientRectangle);//把当前panel组件对应的棋局进行保存
            bmp.Save("nowgobang.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            return bmp;
        }
        public void ReadFile(string Filename)//由FrmReadGobangFile调用这个函数,目的是将文件中的棋局复盘出来
        {
            int n = game.ReadFileLines(Filename);//这步结束之后会将棋局复刻到带有类似readfile字样的数组中
            //Console.WriteLine("n=  " + n);
            stepN = 0;//读取文件的时候步骤重新置为1
            for (int i=0;i<n;i++)//调用完这个之后,棋盘应该顺便存完子了
            {
                Piece ReadAPiece = game.PlaceAPieceFromFile(Borad.readfilechessmancolor[i], Borad.ReadFileChessman[i].X, Borad.ReadFileChessman[i].Y);
                stepN++;
                ReadAPiece.Text = stepN.ToString();
                this.pnlGobang.Controls.Add(ReadAPiece);
            }
            if(GameManager.nowplaywithAI==true)
            {
                PieceType nowpiece = game.CurrentPlayer;
                //Console.WriteLine(nowpiece);
                int colorfinal = Borad.readfilechessmancolor[n - 1];//看一下最后下的那个棋是什么颜色的
                Console.WriteLine("colorfinal=" + colorfinal);
                if (colorfinal == 1)//最后下的棋为黑色
                {
                    Piece AInewPiece = game.AIPlaceAPiece(0, 0, 2);
                    Console.WriteLine("来,AI下个棋");
                    stepN++;
                    AInewPiece.Text = stepN.ToString();
                    this.pnlGobang.Controls.Add(AInewPiece);
                    this.picCurrentPlayer.Image = Properties.Resources.black2;
                    this.lblCurrentPlayer.Text = "悟空，轮到你落子了";
                    
                }
                else if (colorfinal == 2)//最后下的棋为白色
                {
                    // this.picCurrentPlayer.Image = Properties.Resources.white2;
                    //this.lblCurrentPlayer.Text = "容为师思量片刻";
                    this.picCurrentPlayer.Image = Properties.Resources.black2;
                    this.lblCurrentPlayer.Text = "悟空，轮到你落子了";
                }
            }
            else if(GameManager.nowplaywithAI==false)
            {
                if(Borad.readfilechessmancolor[n-1]==1)//此时最后一个应该是黑子,所以接下来就应该是玩家白子下棋
                {
                    this.picCurrentPlayer.Image = Properties.Resources.white2;
                    this.lblCurrentPlayer.Text = "容为师思量片刻";
                }
                else if(Borad.readfilechessmancolor[n - 1] == 2)
                {
                    this.picCurrentPlayer.Image = Properties.Resources.black2;
                    this.lblCurrentPlayer.Text = "悟空，轮到你落子了";
                }
            }
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            bmp = GetScreen();
            FrmSettings frmsettings = new FrmSettings();
            frmsettings._Father = this;
            frmsettings.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)//点菩提祖师的小彩蛋
        {
            MessageBox.Show("徒儿安心下棋,不要点为师的照片!");
        }
    }
}
