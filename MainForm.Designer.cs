
namespace wuqizi
{
    partial class MainForm
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
            this.huiqi = new System.Windows.Forms.Button();
            this.oneMore = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.boardPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // boardPictureBox
            // 
            this.boardPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boardPictureBox.Location = new System.Drawing.Point(0, 0);
            this.boardPictureBox.Name = "boardPictureBox";
            this.boardPictureBox.Size = new System.Drawing.Size(1078, 744);
            this.boardPictureBox.TabIndex = 0;
            this.boardPictureBox.TabStop = false;
            this.boardPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BoardPictureBox_MouseClick);
            // 
            // huiqi
            // 
            this.huiqi.Font = new System.Drawing.Font("宋体", 14F);
            this.huiqi.Location = new System.Drawing.Point(753, 73);
            this.huiqi.Name = "huiqi";
            this.huiqi.Size = new System.Drawing.Size(91, 54);
            this.huiqi.TabIndex = 1;
            this.huiqi.Text = "悔棋";
            this.huiqi.UseVisualStyleBackColor = true;
            this.huiqi.Click += new System.EventHandler(this.HuiqiBtnClick);
            // 
            // oneMore
            // 
            this.oneMore.Font = new System.Drawing.Font("宋体", 14F);
            this.oneMore.Location = new System.Drawing.Point(896, 73);
            this.oneMore.Name = "oneMore";
            this.oneMore.Size = new System.Drawing.Size(145, 54);
            this.oneMore.TabIndex = 2;
            this.oneMore.Text = "再来一局";
            this.oneMore.UseVisualStyleBackColor = true;
            this.oneMore.Click += new System.EventHandler(this.Reset);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1078, 744);
            this.Controls.Add(this.oneMore);
            this.Controls.Add(this.huiqi);
            this.Controls.Add(this.boardPictureBox);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.boardPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.Button huiqiBtn;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.PictureBox boardPictureBox;
        private System.Windows.Forms.Button huiqi;
        private System.Windows.Forms.Button oneMore;
    }
}

