
namespace wuqizi
{
    partial class QueryForm
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
            this.cdgv = new System.Windows.Forms.DataGridView();
            this.bdgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.cdgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdgv)).BeginInit();
            this.SuspendLayout();
            // 
            // cdgv
            // 
            this.cdgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cdgv.Location = new System.Drawing.Point(369, 0);
            this.cdgv.Name = "cdgv";
            this.cdgv.RowHeadersWidth = 62;
            this.cdgv.RowTemplate.Height = 30;
            this.cdgv.Size = new System.Drawing.Size(713, 745);
            this.cdgv.TabIndex = 0;
            // 
            // bdgv
            // 
            this.bdgv.AllowUserToDeleteRows = false;
            this.bdgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bdgv.Location = new System.Drawing.Point(0, 0);
            this.bdgv.Name = "bdgv";
            this.bdgv.RowHeadersWidth = 62;
            this.bdgv.RowTemplate.Height = 30;
            this.bdgv.Size = new System.Drawing.Size(363, 745);
            this.bdgv.TabIndex = 1;
            // 
            // QueryForm
            // 
            this.ClientSize = new System.Drawing.Size(1078, 744);
            this.Controls.Add(this.bdgv);
            this.Controls.Add(this.cdgv);
            this.Name = "QueryForm";
            this.Load += new System.EventHandler(this.QueryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cdgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView cdgv;
        private System.Windows.Forms.DataGridView bdgv;
    }
}