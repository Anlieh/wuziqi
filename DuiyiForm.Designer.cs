
namespace wuqizi
{
    partial class DuiyiForm
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
            this.boardPictureBox = new System.Windows.Forms.PictureBox();
            this.huiqiBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.boardPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // boardPictureBox
            // 
            this.boardPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boardPictureBox.Location = new System.Drawing.Point(38, 100);
            this.boardPictureBox.Name = "boardPictureBox";
            this.boardPictureBox.Size = new System.Drawing.Size(1100, 1100);
            this.boardPictureBox.TabIndex = 0;
            this.boardPictureBox.TabStop = false;
            this.boardPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BoardPictureBox_MouseClick);
            // 
            // huiqiBtn
            // 
            this.huiqiBtn.Font = new System.Drawing.Font("宋体", 14F);
            this.huiqiBtn.Location = new System.Drawing.Point(338, 24);
            this.huiqiBtn.Name = "huiqi";
            this.huiqiBtn.Size = new System.Drawing.Size(91, 54);
            this.huiqiBtn.TabIndex = 1;
            this.huiqiBtn.Text = "悔棋";
            this.huiqiBtn.UseVisualStyleBackColor = true;
            this.huiqiBtn.Click += new System.EventHandler(this.HuiqiBtnClick);
            // 
            // resetBtn
            // 
            this.resetBtn.Font = new System.Drawing.Font("宋体", 14F);
            this.resetBtn.Location = new System.Drawing.Point(662, 24);
            this.resetBtn.Name = "oneMore";
            this.resetBtn.Size = new System.Drawing.Size(145, 54);
            this.resetBtn.TabIndex = 2;
            this.resetBtn.Text = "再来一局";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.Reset);
            // 
            // DuiyiForm
            // 
            this.ClientSize = new System.Drawing.Size(1178, 1244);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.huiqiBtn);
            this.Controls.Add(this.boardPictureBox);
            this.Name = "DuiyiForm";
            this.Load += new System.EventHandler(this.MainFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.boardPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox boardPictureBox;
        private System.Windows.Forms.Button huiqiBtn;
        private System.Windows.Forms.Button resetBtn;
    }
}

