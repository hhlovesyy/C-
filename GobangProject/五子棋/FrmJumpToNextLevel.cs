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
    public partial class FrmJumpToNextLevel : Form
    {
        public FrmJumpToNextLevel()
        {
            InitializeComponent();
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width - this.Size.Width) / 2;//设置窗体打开默认在右下角显示
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            this.StartPosition = FormStartPosition.Manual; //窗体的位置由Location属性决定
            this.Location = (Point)new Size(x, y);         //窗体的起始位置为(x,y)
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            FrmLevelsChoose frmlevelchoose = new FrmLevelsChoose();
            this.Dispose();
            frmlevelchoose.ShowDialog();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(FrmLevelsChoose.nowlevelchoose==14)
            {
                MessageBox.Show("后续关卡还没有解锁!");
                return;
            }
            FrmLevelsChoose.nowlevelchoose += 1;//也就是说现在要跳转到下一关
            GameManager.nowplaywithAI = true;
            FrmGobang frmGobang = new FrmGobang();
            this.Hide();
            frmGobang.ReadFile(FrmLevelsChoose.levels[FrmLevelsChoose.nowlevelchoose]);
            frmGobang.ShowDialog();
            frmGobang.BeRefresh();
        }
    }
}
