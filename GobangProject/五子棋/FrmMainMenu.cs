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
    public partial class FrmMainMenu : Form
    {
        public FrmMainMenu()
        {
            InitializeComponent();
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width - this.Size.Width) / 2;//设置窗体打开默认在右下角显示
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            this.StartPosition = FormStartPosition.Manual; //窗体的位置由Location属性决定
            this.Location = (Point)new Size(x, y);         //窗体的起始位置为(x,y)
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmSecondMenu frmSecondMenu = new FrmSecondMenu();
            this.Hide();
            frmSecondMenu.ShowDialog();
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmMainMenu_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmStory frmStory = new FrmStory();
            this.Hide();
            frmStory.ShowDialog();
            this.Dispose();
        }
    }
}
