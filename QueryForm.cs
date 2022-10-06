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

    }
}
