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
    public partial class FrmReadGobangFile : Form
    {
        public FrmSettings _father;
        public FrmSettings _Father
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
        

        public FrmReadGobangFile()
        {
            InitializeComponent();
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width - this.Size.Width) / 2;//设置窗体打开默认在右下角显示
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            this.StartPosition = FormStartPosition.Manual; //窗体的位置由Location属性决定
            this.Location = (Point)new Size(x, y);         //窗体的起始位置为(x,y)
            this.pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            if (FrmSettings.image1 != null)
                this.pictureBox2.Image = FrmSettings.image1;
            this.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            if(FrmSettings.image2!=null)
                this.pictureBox1.Image = FrmSettings.image2;
            this.pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            this.pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            if (FrmSettings.image3 != null)
                this.pictureBox3.Image = FrmSettings.image3;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//这个在点击读取存档1之后调用
        {
            ///TODO:目前还没有实现功能,总之是想要让原来的父窗口去调用ReadFile函数,就是那个FrmGobang,而不是子窗口
            //FrmGobang frmgobang = new FrmGobang();
            this._father._father.BeRefresh();
            this._father._father.ReadFile("gobang1.txt");
           // frmgobang.ReadFile("gobang1.txt");
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)//这个在点击读取存档2之后调用
        {
            this._father._father.BeRefresh();
            this._father._father.ReadFile("gobang2.txt");
            this.Dispose();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this._father._father.BeRefresh();
            this._father._father.ReadFile("gobang3.txt");

            this.Dispose();
        }
    }
}
