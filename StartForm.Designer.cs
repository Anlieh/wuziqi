
namespace wuqizi
{
    partial class StartForm
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
            this.boardBtn = new System.Windows.Forms.Button();
            this.queryBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // boardBtn
            // 
            this.boardBtn.Font = new System.Drawing.Font("MesloLGM NF", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boardBtn.Location = new System.Drawing.Point(12, 236);
            this.boardBtn.Name = "boardBtn";
            this.boardBtn.Size = new System.Drawing.Size(50, 209);
            this.boardBtn.TabIndex = 0;
            this.boardBtn.Text = "下棋";
            this.boardBtn.UseVisualStyleBackColor = true;
            this.boardBtn.Click += new System.EventHandler(this.boardBtn_Click);
            // 
            // queryBtn
            // 
            this.queryBtn.Font = new System.Drawing.Font("MesloLGM NF", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.queryBtn.Location = new System.Drawing.Point(12, 547);
            this.queryBtn.Name = "queryBtn";
            this.queryBtn.Size = new System.Drawing.Size(50, 240);
            this.queryBtn.TabIndex = 1;
            this.queryBtn.Text = "对弈记录";
            this.queryBtn.UseVisualStyleBackColor = true;
            this.queryBtn.Click += new System.EventHandler(this.queryBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Font = new System.Drawing.Font("MesloLGM NF", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(121, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 1300);
            this.panel1.TabIndex = 2;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1378, 1344);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.queryBtn);
            this.Controls.Add(this.boardBtn);
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.Load += new System.EventHandler(this.StartForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button boardBtn;
        private System.Windows.Forms.Button queryBtn;
        private System.Windows.Forms.Panel panel1;
    }
}