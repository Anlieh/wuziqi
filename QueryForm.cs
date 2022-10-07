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
            this.InitDataGridView();
          
        }

        private void InitDataGridView()
        {
            //// 去掉最左侧的空白列
            //bdgv.RowHeadersVisible = false;
            //cdgv.RowHeadersVisible = false;

            // 列宽自适应
            bdgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            cdgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            bdgv.DataSource = MySqlController.GetFilledDataSet("board").Tables[0];
            cdgv.DataSource = MySqlController.GetFilledDataSet("chess").Tables[0];

            //// DataGridView_Chess 自动填充 DataGridView_Board 第一行对应棋子
            //int initId = Convert.ToInt32(bdgv.SelectedRows[0].Cells[0].Value); // 第一个单元格的数据
            //cdgv.DataSource = SqlController.GetChessDataSetOnCondition(initId).Tables[0];

        }

        private void bdgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = bdgv.CurrentRow.Index;    //取得选中行的索引  
            int boardId = Convert.ToInt32(bdgv.Rows[index].Cells["id"].Value);

            // 查询棋子: 满足棋子id == board_id  
            DataSet ds = MySqlController.GetChessDataSetOnCondition(boardId);
            cdgv.DataSource = ds.Tables[0];
        }

    }
}