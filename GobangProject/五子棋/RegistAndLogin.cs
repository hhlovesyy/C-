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
    public partial class RegistAndLogin : Form
    {
        private string name;
        private string password;
        public RegistAndLogin()
        {
            InitializeComponent();
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width - this.Size.Width) / 2;//设置窗体打开默认在右下角显示
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            this.StartPosition = FormStartPosition.Manual; //窗体的位置由Location属性决定
            this.Location = (Point)new Size(x, y);         //窗体的起始位置为(x,y)
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            name = this.textBox1.Text;
            password = this.textBox2.Text;

            FrmMainMenu frmmainmenu = new FrmMainMenu();
            this.Hide();
            frmmainmenu.ShowDialog();
            this.Dispose();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            FrmRegist frmregist = new FrmRegist();
            frmregist.ShowDialog();
        }
    }
}
