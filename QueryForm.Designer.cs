
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
            this.BoardDataGridView = new System.Windows.Forms.DataGridView();
            this.ChessDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.BoardDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChessDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // BoardDataGridView
            // 
            this.BoardDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BoardDataGridView.Location = new System.Drawing.Point(349, 0);
            this.BoardDataGridView.Name = "BoardDataGridView";
            this.BoardDataGridView.RowHeadersWidth = 62;
            this.BoardDataGridView.RowTemplate.Height = 30;
            this.BoardDataGridView.Size = new System.Drawing.Size(1062, 853);
            this.BoardDataGridView.TabIndex = 0;
            // 
            // ChessDataGridView
            // 
            this.ChessDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChessDataGridView.Location = new System.Drawing.Point(0, 0);
            this.ChessDataGridView.Name = "ChessDataGridView";
            this.ChessDataGridView.RowHeadersWidth = 62;
            this.ChessDataGridView.RowTemplate.Height = 30;
            this.ChessDataGridView.Size = new System.Drawing.Size(343, 853);
            this.ChessDataGridView.TabIndex = 1;
            // 
            // QueryForm
            // 
            this.ClientSize = new System.Drawing.Size(1411, 853);
            this.Controls.Add(this.ChessDataGridView);
            this.Controls.Add(this.BoardDataGridView);
            this.Name = "QueryForm";
            ((System.ComponentModel.ISupportInitialize)(this.BoardDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChessDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView BoardDataGridView;
        private System.Windows.Forms.DataGridView ChessDataGridView;
    }
}