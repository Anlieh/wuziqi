using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wuqizi
{
    public partial class QueryForm : Form
    {
        public QueryForm()
        {
            InitializeComponent();
        }
      
        private void QueryForm_Load(object sender, EventArgs e)
        {
            InitDataGridView();
            SetDataGridViewStyle();
        }


        private void InitDataGridView()
        {
            // lgdv: DataGridView of 棋局
            // rdgv: DataGridView of 棋子
            DataTable bdt = MySqlController.GetFilledDataSet("board").Tables[0];
            ldgv.DataSource = bdt;
            rdgv.DataSource = MySqlController.GetFilledDataSet("chess").Tables[0];

            // cgdv 自动填充最后一局的对弈详情
            int rowCount = bdt.Rows.Count;
            ClickLdgv2Rdgv(rowCount - 1);
        }


        private void SetDataGridViewStyle()
        {
            // 去掉最左侧的空白列
            ldgv.RowHeadersVisible = false;
            rdgv.RowHeadersVisible = false;

            // 列宽自适应
            ldgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            rdgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }


        private void ldgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = ldgv.CurrentRow.Index;    //取得选中行的索引  
            ClickLdgv2Rdgv(index);
        }


        private void ClickLdgv2Rdgv(int index)
        {
            int rowCount = ldgv.Rows.Count;
            if(rowCount >= 1 && index < rowCount)
            {
                int boardId = Convert.ToInt32(ldgv.Rows[index].Cells["id"].Value);
                // 查询棋子: 满足棋子id == board_id  
                DataSet ds = MySqlController.GetChessDataSetByBoard(boardId);
                rdgv.DataSource = ds.Tables[0];
            }
        }
    }
}
