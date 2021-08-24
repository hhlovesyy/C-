namespace 五子棋
{
    partial class FrmGobang
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGobang));
            this.lblCurrentPlayer = new System.Windows.Forms.Label();
            this.btnReload = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picCurrentPlayer = new System.Windows.Forms.PictureBox();
            this.pnlGobang = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCurrentPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCurrentPlayer
            // 
            this.lblCurrentPlayer.AutoSize = true;
            this.lblCurrentPlayer.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCurrentPlayer.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblCurrentPlayer.Location = new System.Drawing.Point(937, 554);
            this.lblCurrentPlayer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentPlayer.Name = "lblCurrentPlayer";
            this.lblCurrentPlayer.Size = new System.Drawing.Size(240, 32);
            this.lblCurrentPlayer.TabIndex = 1;
            this.lblCurrentPlayer.Text = "悟空，轮到你落子了";
            this.lblCurrentPlayer.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.BurlyWood;
            this.btnReload.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnReload.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReload.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnReload.Location = new System.Drawing.Point(944, 605);
            this.btnReload.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(323, 50);
            this.btnReload.TabIndex = 3;
            this.btnReload.Text = "师傅，再给弟子一次机会吧！";
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.BurlyWood;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.DarkGreen;
            this.button1.Location = new System.Drawing.Point(944, 662);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(323, 50);
            this.button1.TabIndex = 5;
            this.button1.Text = "弟子决心闭关修行......";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::五子棋.Properties.Resources.buhdda;
            this.pictureBox1.Location = new System.Drawing.Point(840, -10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(527, 544);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // picCurrentPlayer
            // 
            this.picCurrentPlayer.Image = ((System.Drawing.Image)(resources.GetObject("picCurrentPlayer.Image")));
            this.picCurrentPlayer.Location = new System.Drawing.Point(861, 542);
            this.picCurrentPlayer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picCurrentPlayer.Name = "picCurrentPlayer";
            this.picCurrentPlayer.Size = new System.Drawing.Size(67, 62);
            this.picCurrentPlayer.TabIndex = 2;
            this.picCurrentPlayer.TabStop = false;
            this.picCurrentPlayer.Click += new System.EventHandler(this.picCurrentPlayer_Click);
            // 
            // pnlGobang
            // 
            this.pnlGobang.BackgroundImage = global::五子棋.Properties.Resources.board_expanded3;
            this.pnlGobang.Location = new System.Drawing.Point(0, 0);
            this.pnlGobang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlGobang.Name = "pnlGobang";
            this.pnlGobang.Size = new System.Drawing.Size(840, 788);
            this.pnlGobang.TabIndex = 0;
            this.pnlGobang.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGobang_Paint);
            this.pnlGobang.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlGobang_MouseDown_1);
            this.pnlGobang.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlGobang_MouseMove);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.BurlyWood;
            this.button2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.DarkGreen;
            this.button2.Location = new System.Drawing.Point(944, 724);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 50);
            this.button2.TabIndex = 6;
            this.button2.Text = "下错了!悔棋";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.BurlyWood;
            this.button3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button3.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.Color.DarkGreen;
            this.button3.Location = new System.Drawing.Point(1128, 724);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(139, 50);
            this.button3.TabIndex = 7;
            this.button3.Text = "其他设置";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FrmGobang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Moccasin;
            this.ClientSize = new System.Drawing.Size(1361, 789);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.picCurrentPlayer);
            this.Controls.Add(this.lblCurrentPlayer);
            this.Controls.Add(this.pnlGobang);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmGobang";
            this.Text = "五子棋";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCurrentPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlGobang;
        public System.Windows.Forms.Label lblCurrentPlayer;
        private System.Windows.Forms.PictureBox picCurrentPlayer;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

