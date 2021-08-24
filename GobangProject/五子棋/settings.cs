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
    public partial class FrmSettings : Form
    {
        public FrmGobang _father;
        public FrmGobang _Father
        {
            get
            {
                return _father;
            }
            set
            {
                _father = value;
            }
        }

        public FrmSettings()
        {
            InitializeComponent();
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width - this.Size.Width) / 2;//设置窗体打开默认在右下角显示
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            this.StartPosition = FormStartPosition.Manual; //窗体的位置由Location属性决定
            this.Location = (Point)new Size(x, y);         //窗体的起始位置为(x,y)
        }
        private string sFilename1="gobang1.txt";
        private string sFilename2="gobang2.txt";
        private string sFilename3="gobang3.txt";
        private string sImageName1 = "saving1.jpg";
        private string sImageName2 = "saving2.jpg";
        private string sImageName3 = "saving3.jpg";
        public static Bitmap image1;
        public static Bitmap image2;
        public static Bitmap image3;
        private void button3_Click(object sender, EventArgs e)
        {
            FileInfo fileinfo = new FileInfo(sFilename3);
            if (fileinfo.Length == 0)
            {
                if (MessageBox.Show("是否确认保存?", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (StreamWriter sw = new StreamWriter(sFilename3))//将当前内容写进文件当中
                    {
                        for (int i = 1; i <= Borad.steps; i++)//为了方便起见现在从下标1开始存放
                        {
                            sw.WriteLine(Borad.chessmancolor[i] + " " + Borad.Queuechessman[i].X + " " + Borad.Queuechessman[i].Y);
                        }
                    }
                    image3 = FrmGobang.bmp;
                    image3.Save("gobangsaving3.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            else
            {
                if (MessageBox.Show("当前存档不为空,是否确认覆盖?", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (StreamWriter sw = new StreamWriter(sFilename3))//将当前内容写进文件当中
                    {
                        for (int i = 1; i <= Borad.steps; i++)//为了方便起见现在从下标1开始存放
                        {
                            sw.WriteLine(Borad.chessmancolor[i] + " " + Borad.Queuechessman[i].X + " " + Borad.Queuechessman[i].Y);
                        }
                    }
                    image3 = FrmGobang.bmp;
                    image3.Save("gobangsaving3.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)//这个是保存到存档1里面
        {
            FileInfo fileinfo = new FileInfo(sFilename1);
            if(fileinfo.Length==0)
            {
                if (MessageBox.Show("是否确认保存?", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (StreamWriter sw = new StreamWriter(sFilename1))//将当前内容写进文件当中
                    {
                        for (int i = 1; i <= Borad.steps; i++)//为了方便起见现在从下标1开始存放
                        {
                            sw.WriteLine(Borad.chessmancolor[i] + " " + Borad.Queuechessman[i].X + " " + Borad.Queuechessman[i].Y);
                        }
                    }
                    image1 = FrmGobang.bmp;
                    image1.Save("gobangsaving1.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            else
            {
                if (MessageBox.Show("当前存档不为空,是否确认覆盖?", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (StreamWriter sw = new StreamWriter(sFilename1))//将当前内容写进文件当中
                    {
                        for (int i = 1; i <= Borad.steps; i++)//为了方便起见现在从下标1开始存放
                        {
                            sw.WriteLine(Borad.chessmancolor[i] + " " + Borad.Queuechessman[i].X + " " + Borad.Queuechessman[i].Y);
                        }
                    }
                    image1 = FrmGobang.bmp;
                    image1.Save("gobangsaving1.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }   
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();//窗口消失,返回刚才的棋局
        }

        private void button2_Click(object sender, EventArgs e)//这个是保存到存档2里面
        {
            FileInfo fileinfo = new FileInfo(sFilename2);
            if (fileinfo.Length == 0)
            {
                if (MessageBox.Show("是否确认保存?", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (StreamWriter sw = new StreamWriter(sFilename2))//将当前内容写进文件当中
                    {
                        for (int i = 1; i <= Borad.steps; i++)//为了方便起见现在从下标1开始存放
                        {
                            sw.WriteLine(Borad.chessmancolor[i] + " " + Borad.Queuechessman[i].X + " " + Borad.Queuechessman[i].Y);
                        }
                       
                    }
                    image2 = FrmGobang.bmp;
                    image2.Save("gobangsaving2.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            else
            {
                if (MessageBox.Show("当前存档不为空,是否确认覆盖?", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (StreamWriter sw = new StreamWriter(sFilename2))//将当前内容写进文件当中
                    {
                        for (int i = 1; i <= Borad.steps; i++)//为了方便起见现在从下标1开始存放
                        {
                            sw.WriteLine(Borad.chessmancolor[i] + " " + Borad.Queuechessman[i].X + " " + Borad.Queuechessman[i].Y);
                        }
                    }
                    //这个要存到存档二的图里面
                    image2 = FrmGobang.bmp;
                    image2.Save("gobangsaving2.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(GameManager.nowplaylevels==true)//在闯关过程当中是不能够读取存档的,否则可以作弊
            {
                MessageBox.Show("闯关过程中不能读取存档!");
                return;
            }
            FrmReadGobangFile frmreadfile = new FrmReadGobangFile();
            frmreadfile._Father = this;
            frmreadfile.ShowDialog();
        }
    }
}
