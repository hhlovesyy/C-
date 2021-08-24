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
    public partial class FrmSetTime : Form
    {
        public delegate void TextEventHandler(string strText);
        public TextEventHandler TextHandler;

        public FrmSetTime()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (TextHandler!=null)
            {
                TextHandler.Invoke(txtString.Text);
                DialogResult = DialogResult.OK;
            }
            
        }

        private void txtString_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtString_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Keys.Enter == (Keys)e.KeyChar)
            {
                if (null != TextHandler)
                {
                    TextHandler.Invoke(txtString.Text);
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmSecondMenu frmSecondMenu = new FrmSecondMenu();
            this.Hide();
            frmSecondMenu.ShowDialog();
            this.Dispose();
        }
    }
}
