using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            // 去掉最左侧的空白列
            bdgv.RowHeadersVisible = false;
            cdgv.RowHeadersVisible = false;

            // 列宽自适应
            bdgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            // cdgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // 初始化数据
            bdgv.DataSource = SqlController.GetFilledDataSet("board").Tables[0];
            cdgv.DataSource = SqlController.GetFilledDataSet("chess").Tables[0];

        }

        private void BoardDataGridView_Load(object sender, EventArgs e)
        {
            bdgv.DataSource = SqlController.GetFilledDataSet("board").Tables[0];

        }

        private void ChessDataGridView_Load(object sender, EventArgs e)
        {
            cdgv.DataSource = SqlController.GetFilledDataSet("chess").Tables[0];

        }

        private void bdgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = bdgv.CurrentRow.Index;    //取得选中行的索引  
            int id = Convert.ToInt32(bdgv.Rows[index].Cells["id"].Value);

            // 查询棋子: 满足border_id == id
            DataSet ds = SqlController.GetChessDataSetOnCondition(id);
            cdgv.DataSource = ds.Tables[0];
        }

    }
}