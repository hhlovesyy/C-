
namespace 五子棋
{
    partial class FrmGobangPVP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGobangPVP));
            this.lblCurrentPlayer = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BlackTimer = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lblBlackMin = new System.Windows.Forms.Label();
            this.lblBlackSec = new System.Windows.Forms.Label();
            this.lblWhiteMin = new System.Windows.Forms.Label();
            this.lblWhiteSec = new System.Windows.Forms.Label();
            this.btnReload = new System.Windows.Forms.Button();
            this.WhiteTimer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlGobang = new System.Windows.Forms.Panel();
            this.picCurrentPlayer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCurrentPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCurrentPlayer
            // 
            this.lblCurrentPlayer.AutoSize = true;
            this.lblCurrentPlayer.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCurrentPlayer.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblCurrentPlayer.Location = new System.Drawing.Point(714, 310);
            this.lblCurrentPlayer.Name = "lblCurrentPlayer";
            this.lblCurrentPlayer.Size = new System.Drawing.Size(221, 32);
            this.lblCurrentPlayer.TabIndex = 5;
            this.lblCurrentPlayer.Text = "悟空,轮到你落子了";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(659, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 30);
            this.label2.TabIndex = 8;
            this.label2.Text = "悟空的剩余时间";
            // 
            // BlackTimer
            // 
            this.BlackTimer.Tick += new System.EventHandler(this.BlackTimer_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(659, 430);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 30);
            this.label3.TabIndex = 9;
            this.label3.Text = "师傅的剩余时间";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.BurlyWood;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.DarkGreen;
            this.button2.Location = new System.Drawing.Point(675, 579);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(334, 40);
            this.button2.TabIndex = 11;
            this.button2.Text = "弟子决心闭关修行......";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblBlackMin
            // 
            this.lblBlackMin.AutoSize = true;
            this.lblBlackMin.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBlackMin.Location = new System.Drawing.Point(822, 198);
            this.lblBlackMin.Name = "lblBlackMin";
            this.lblBlackMin.Size = new System.Drawing.Size(49, 30);
            this.lblBlackMin.TabIndex = 12;
            this.lblBlackMin.Text = "  分";
            // 
            // lblBlackSec
            // 
            this.lblBlackSec.AutoSize = true;
            this.lblBlackSec.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBlackSec.Location = new System.Drawing.Point(877, 198);
            this.lblBlackSec.Name = "lblBlackSec";
            this.lblBlackSec.Size = new System.Drawing.Size(49, 30);
            this.lblBlackSec.TabIndex = 13;
            this.lblBlackSec.Text = "  秒";
            // 
            // lblWhiteMin
            // 
            this.lblWhiteMin.AutoSize = true;
            this.lblWhiteMin.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWhiteMin.Location = new System.Drawing.Point(792, 474);
            this.lblWhiteMin.Name = "lblWhiteMin";
            this.lblWhiteMin.Size = new System.Drawing.Size(49, 30);
            this.lblWhiteMin.TabIndex = 14;
            this.lblWhiteMin.Text = "  分";
            // 
            // lblWhiteSec
            // 
            this.lblWhiteSec.AutoSize = true;
            this.lblWhiteSec.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWhiteSec.Location = new System.Drawing.Point(877, 474);
            this.lblWhiteSec.Name = "lblWhiteSec";
            this.lblWhiteSec.Size = new System.Drawing.Size(49, 30);
            this.lblWhiteSec.TabIndex = 15;
            this.lblWhiteSec.Text = "  秒";
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.BurlyWood;
            this.btnReload.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnReload.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReload.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnReload.Location = new System.Drawing.Point(675, 520);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(334, 40);
            this.btnReload.TabIndex = 16;
            this.btnReload.Text = " 师傅，再给弟子一次机会吧！";
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // WhiteTimer
            // 
            this.WhiteTimer.Tick += new System.EventHandler(this.WhiteTimer_Tick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.BurlyWood;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.DarkGreen;
            this.button1.Location = new System.Drawing.Point(765, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 37);
            this.button1.TabIndex = 17;
            this.button1.Text = "设置时间";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.NavajoWhite;
            this.label1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(688, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 30);
            this.label1.TabIndex = 18;
            this.label1.Text = "待悟空落棋后，倒计时开始";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pnlGobang
            // 
            this.pnlGobang.BackgroundImage = global::五子棋.Properties.Resources.board_expanded3;
            this.pnlGobang.Location = new System.Drawing.Point(0, 0);
            this.pnlGobang.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnlGobang.Name = "pnlGobang";
            this.pnlGobang.Size = new System.Drawing.Size(630, 630);
            this.pnlGobang.TabIndex = 4;
            this.pnlGobang.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGobang_Paint);
            this.pnlGobang.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlGobang_MouseDown_1);
            this.pnlGobang.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlGobang_MouseMove);
            // 
            // picCurrentPlayer
            // 
            this.picCurrentPlayer.Image = ((System.Drawing.Image)(resources.GetObject("picCurrentPlayer.Image")));
            this.picCurrentPlayer.Location = new System.Drawing.Point(650, 294);
            this.picCurrentPlayer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picCurrentPlayer.Name = "picCurrentPlayer";
            this.picCurrentPlayer.Size = new System.Drawing.Size(58, 71);
            this.picCurrentPlayer.TabIndex = 3;
            this.picCurrentPlayer.TabStop = false;
            this.picCurrentPlayer.Click += new System.EventHandler(this.picCurrentPlayer_Click);
            // 
            // FrmGobangPVP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Moccasin;
            this.ClientSize = new System.Drawing.Size(1021, 631);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.lblWhiteSec);
            this.Controls.Add(this.lblWhiteMin);
            this.Controls.Add(this.lblBlackSec);
            this.Controls.Add(this.lblBlackMin);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCurrentPlayer);
            this.Controls.Add(this.pnlGobang);
            this.Controls.Add(this.picCurrentPlayer);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmGobangPVP";
            this.Text = "五子棋";
            this.Load += new System.EventHandler(this.FrrmGobangPVP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCurrentPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picCurrentPlayer;
        private System.Windows.Forms.Panel pnlGobang;
        public System.Windows.Forms.Label lblCurrentPlayer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer BlackTimer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblBlackMin;
        private System.Windows.Forms.Label lblBlackSec;
        private System.Windows.Forms.Label lblWhiteMin;
        private System.Windows.Forms.Label lblWhiteSec;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Timer WhiteTimer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}