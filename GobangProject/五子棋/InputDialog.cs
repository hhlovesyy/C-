﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 五子棋
{
    public static class InputDialog
    {
        public static DialogResult Show(out string strText)
        {
            string strTemp = string.Empty;

            FrmSetTime inputDialog = new FrmSetTime();
            inputDialog.TextHandler = (str) => { strTemp = str; };

            DialogResult result = inputDialog.ShowDialog();
            strText = strTemp;

            return result;
        }
    }

}
