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
    public partial class FrmLevelsChoose : Form
    {
        public static int nowlevelchoose = 0;
        public static string[] levels = new string[] { @"levels/level1.txt", @"levels/level2.txt", @"levels/level3.txt", @"levels/level4.txt", @"levels/level5.txt", @"levels/level6.txt",
        "levels/level7.txt","levels/level8.txt","levels/level9.txt","levels/level10.txt","levels/level11.txt","levels/level12.txt","levels/level13.txt","levels/level14.txt","levels/level15.txt","levels/level16.txt",
        "levels/level17.txt","levels/level18.txt","levels/level19.txt","levels/level20.txt","levels/level21.txt","levels/level22.txt","levels/level23.txt","levels/level24.txt","levels/level25.txt",
        "levels/level26.txt","levels/level27.txt","levels/level28.txt","levels/level29.txt","levels/level30.txt"};
        public FrmLevelsChoose()
        {
            InitializeComponent();
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width - this.Size.Width) / 2;//设置窗体打开默认在右下角显示
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            this.StartPosition = FormStartPosition.Manual; //窗体的位置由Location属性决定
            this.Location = (Point)new Size(x, y);         //窗体的起始位置为(x,y)
            GameManager.hasgotawinner = false;
            
        }

        private void button1_Click(object sender, EventArgs e) //第一难
        {
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            nowlevelchoose = 0;
            frmGobang.ReadFile(levels[0]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
           
            //this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            nowlevelchoose = 1;
            frmGobang.ReadFile(levels[1]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            nowlevelchoose = 2;
            frmGobang.ReadFile(levels[2]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmSecondMenu frmsecondmenu = new FrmSecondMenu();
            this.Dispose();
            frmsecondmenu.ShowDialog();
            GameManager.nowplaylevels = false;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            nowlevelchoose = 3;
            frmGobang.ReadFile(levels[3]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            nowlevelchoose = 4;
            frmGobang.ReadFile(levels[4]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            nowlevelchoose = 5;
            frmGobang.ReadFile(levels[5]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            nowlevelchoose = 6;
            frmGobang.ReadFile(levels[6]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            nowlevelchoose = 7;
            frmGobang.ReadFile(levels[7]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            nowlevelchoose = 8;
            frmGobang.ReadFile(levels[8]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            nowlevelchoose = 9;
            frmGobang.ReadFile(levels[9]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            nowlevelchoose = 10;
            frmGobang.ReadFile(levels[10]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            nowlevelchoose = 11;
            frmGobang.ReadFile(levels[11]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            nowlevelchoose = 12;
            frmGobang.ReadFile(levels[12]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            nowlevelchoose = 13;
            frmGobang.ReadFile(levels[13]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            nowlevelchoose = 14;
            frmGobang.ReadFile(levels[14]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if(GameManager.isVIP==false)
            {
                MessageBox.Show("悟空,你还没有充值,不能玩这关");
                return;
            }
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            nowlevelchoose = 15;
            frmGobang.ReadFile(levels[15]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (GameManager.isVIP == false)
            {
                MessageBox.Show("悟空,你还没有充值,不能玩这关");
                return;
            }
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            nowlevelchoose = 16;
            frmGobang.ReadFile(levels[16]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (GameManager.isVIP == false)
            {
                MessageBox.Show("悟空,你还没有充值,不能玩这关");
                return;
            }
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            nowlevelchoose = 17;
            frmGobang.ReadFile(levels[17]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (GameManager.isVIP == false)
            {
                MessageBox.Show("悟空,你还没有充值,不能玩这关");
                return;
            }
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            nowlevelchoose = 18;
            frmGobang.ReadFile(levels[18]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (GameManager.isVIP == false)
            {
                MessageBox.Show("悟空,你还没有充值,不能玩这关");
                return;
            }
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            nowlevelchoose = 19;
            frmGobang.ReadFile(levels[19]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (GameManager.isVIP == false)
            {
                MessageBox.Show("悟空,你还没有充值,不能玩这关");
                return;
            }
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            nowlevelchoose = 20;
            frmGobang.ReadFile(levels[20]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (GameManager.isVIP == false)
            {
                MessageBox.Show("悟空,你还没有充值,不能玩这关");
                return;
            }
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            nowlevelchoose = 21;
            frmGobang.ReadFile(levels[21]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (GameManager.isVIP == false)
            {
                MessageBox.Show("悟空,你还没有充值,不能玩这关");
                return;
            }
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            nowlevelchoose = 22;
            frmGobang.ReadFile(levels[22]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (GameManager.isVIP == false)
            {
                MessageBox.Show("悟空,你还没有充值,不能玩这关");
                return;
            }
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            nowlevelchoose = 23;
            frmGobang.ReadFile(levels[23]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (GameManager.isVIP == false)
            {
                MessageBox.Show("悟空,你还没有充值,不能玩这关");
                return;
            }
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            nowlevelchoose = 24;
            frmGobang.ReadFile(levels[24]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (GameManager.isVIP == false)
            {
                MessageBox.Show("悟空,你还没有充值,不能玩这关");
                return;
            }
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            nowlevelchoose = 25;
            frmGobang.ReadFile(levels[25]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (GameManager.isVIP == false)
            {
                MessageBox.Show("悟空,你还没有充值,不能玩这关");
                return;
            }
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            nowlevelchoose = 26;
            frmGobang.ReadFile(levels[26]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (GameManager.isVIP == false)
            {
                MessageBox.Show("悟空,你还没有充值,不能玩这关");
                return;
            }
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            nowlevelchoose = 27;
            frmGobang.ReadFile(levels[27]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (GameManager.isVIP == false)
            {
                MessageBox.Show("悟空,你还没有充值,不能玩这关");
                return;
            }
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            nowlevelchoose = 28;
            frmGobang.ReadFile(levels[28]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (GameManager.isVIP == false)
            {
                MessageBox.Show("悟空,你还没有充值,不能玩这关");
                return;
            }
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            nowlevelchoose = 29;
            frmGobang.ReadFile(levels[29]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
        }
    }
}
