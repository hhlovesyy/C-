using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 五子棋
{
    public partial class FrmGobangPVP : Form
    {
        private Game game = new Game();
        private int stepN=0;
        
        private int init_min=9;
        private int init_sec = 59;

        private int black_min;
        private int black_sec;
        private int white_min;
        private int white_sec;


        public FrmGobangPVP()
        {
            InitializeComponent();
            Time_init();
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width - this.Size.Width) / 2;//设置窗体打开默认在右下角显示
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            this.StartPosition = FormStartPosition.Manual; //窗体的位置由Location属性决定
            this.Location = (Point)new Size(x, y);         //窗体的起始位置为(x,y)
        }

        private void FrrmGobangPVP_Load(object sender, EventArgs e)
        {
            //启动控件，间隔为1000毫秒也就是1秒
            Time_init();
            
        }

        private void Time_init()
        {
            BlackTimer.Interval = 1000;
            WhiteTimer.Interval = 1000;

            lblBlackMin.Text = init_min + "分";
            lblBlackSec.Text = init_sec + "秒";
            lblWhiteMin.Text = init_min + "分";
            lblWhiteSec.Text = init_sec + "秒";

            white_min = black_min = init_min;
            white_sec = black_sec = init_sec;

            BlackTimer.Stop();
            WhiteTimer.Stop();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click1(object sender, EventArgs e)
        {
            
            
            BlackTimer.Start();
        }

        private void button1_Click2(object sender, EventArgs e)
        {
            this.picCurrentPlayer.Image = Properties.Resources.black2;
            this.pnlGobang.Controls.Clear();
            game.Reload();
            stepN = 0;
        }

        private void pnlGobang_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlGobang_MouseDown_1(object sender, MouseEventArgs e)
        {

            if (game.Winner != PieceType.NONE)//已经决出胜负！比赛结束啦 不再下棋了
            {
                return;
            }
           
            Piece piece = game.PlaceAPiece(e.X, e.Y);//重构后 三个参数变成2个参数 只和界面的时间e有关惹
            if (piece != null)
            {
                stepN++;
                piece.Text = stepN.ToString();


                this.pnlGobang.Controls.Add(piece);//放置 某方下完 可以提示下一个
                //this.picCurrentPlayer.Image = piece.GetNextImage();//该谁下棋的照片切换
                if (game.Winner == PieceType.BLACK)
                {
                    //Time_init();
                    this.lblCurrentPlayer.Text = "善哉，为师这就将筋斗云教授予你!";
                    this.picCurrentPlayer.Image = piece.GetImage();//赢了就固定
                    FrmWin frmWin = new FrmWin();
                    BlackTimer.Stop();
                    frmWin.ShowDialog();

                }
                else if (game.Winner == PieceType.WHITE)
                {
                    //Time_init();
                    this.lblCurrentPlayer.Text = "习武之人要静得下心来";
                    this.picCurrentPlayer.Image = Properties.Resources.white2;//赢了就固定
                    WhiteTimer.Stop();
                    MessageBox.Show("悟空，你的修行还不够啊。");
                }

                if (game.currentPlayer == PieceType.BLACK)
                {
                    this.lblCurrentPlayer.Text = "悟空,轮到你落子了";
                    BlackTimer.Start();
                    WhiteTimer.Stop();
                }
                else if (game.currentPlayer == PieceType.WHITE)
                {
                    this.lblCurrentPlayer.Text = "容为师思量片刻";
                    BlackTimer.Stop();
                    WhiteTimer.Start();
                }
                if (game.Winner != PieceType.WHITE &&game.Winner != PieceType.BLACK) 
                this.picCurrentPlayer.Image = piece.GetNextImage();//该谁下棋的照片切换
            }
        }

        private void pnlGobang_MouseMove(object sender, MouseEventArgs e)
        {
            //鼠标移动事件判断能不能放棋子
            //通过切换鼠标样子
            if (game.CanBePlaced(e.X, e.Y) == true)//两个参数不变 都是界面代码
            {
                this.Cursor = Cursors.Hand;//设置鼠标样式 出现小手
            }
            else
            {
                this.Cursor = Cursors.No;
            }
        }

        //重新开始
        private void btnReload_Click(object sender, EventArgs e)
        {
            this.picCurrentPlayer.Image = Properties.Resources.black2;
            this.lblCurrentPlayer.Text = "悟空,轮到你落子了";
            this.pnlGobang.Controls.Clear();
            game.Reload();
            Time_init();
            stepN = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        //返回主菜单
        private void button2_Click(object sender, EventArgs e)
        {
            FrmMainMenu frmMainMenu = new FrmMainMenu();
            this.Hide();
            frmMainMenu.ShowDialog();
            this.Dispose();
        }


        private void BlackTimer_Tick(object sender, EventArgs e)
        {
            
            //给label赋值
            if (black_min >= 0)
            {
                black_sec--;
                if (black_sec == 0)
                {
                    black_min--;
                    lblBlackMin.Text = black_min.ToString() + "分";
                    black_sec = 59;
                }
                lblBlackSec.Text = black_sec.ToString() + "秒";
            }

            else
            {
                Time_init();
                MessageBox.Show("悟空超时，师傅获胜！");
            }

        }
        private void WhiteTimer_Tick(object sender, EventArgs e)
        {
            if (white_min >= 0)
            {
                white_sec--;
                if (white_sec == 0)
                {
                    white_min--;
                    lblWhiteMin.Text = white_min.ToString() + "分";
                    white_sec = 59;
                }
                lblWhiteSec.Text = white_sec.ToString() + "秒";
            }
            else
            {
                Time_init();
                MessageBox.Show("师傅超时，悟空获胜！");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.picCurrentPlayer.Image = Properties.Resources.black2;
            this.pnlGobang.Controls.Clear();
            game.Reload();
            Time_init();
            stepN = 0;
            string strText = string.Empty;
            InputDialog.Show(out strText);
            init_min = int.Parse(strText)-1;
            Time_init();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void picCurrentPlayer_Click(object sender, EventArgs e)
        {

        }
    }
}


