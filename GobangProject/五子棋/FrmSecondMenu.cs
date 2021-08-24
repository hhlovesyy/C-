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
    public partial class FrmSecondMenu : Form
    {
        public FrmSecondMenu()
        {
            InitializeComponent();
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width - this.Size.Width) / 2;//设置窗体打开默认在右下角显示
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            this.StartPosition = FormStartPosition.Manual; //窗体的位置由Location属性决定
            this.Location = (Point)new Size(x, y);         //窗体的起始位置为(x,y)
            GameManager.nowplaylevels = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            frmGobang.ShowDialog();
            this.Dispose();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmMainMenu frmMainMenu = new FrmMainMenu();
            this.Hide();
            frmMainMenu.ShowDialog();
            this.Dispose();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            TwoPlayerSelect twoPlayerSelect = new TwoPlayerSelect();
            this.Hide();
            twoPlayerSelect.ShowDialog();
            this.Dispose();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmLevelsChoose frmlevelschoose = new FrmLevelsChoose();
            GameManager.nowplaywithAI = true;
            GameManager.nowplaylevels = true;
            this.Dispose();
            frmlevelschoose.ShowDialog();
           
        }
    }
}
