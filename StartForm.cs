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
    public partial class StartForm : Form
    {
        private static DuiyiForm duiyiForm;
        private static QueryForm queryForm;

        public StartForm()
        {
            InitializeComponent();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            if (duiyiForm == null)
            {
                duiyiForm = new DuiyiForm();
            }
            if(queryForm == null)
            {
                queryForm = new QueryForm();
            }
            
            // 总觉得哪里怪怪的
            boardBtn_Click(null, null);

        }

        private void boardBtn_Click(object sender, EventArgs e)
        {
            // 设置子窗口：不显示为顶级窗口
            duiyiForm.TopLevel = false;
            // 设置子窗口：不显示标题栏
           // duiyiForm.FormBorderStyle = FormBorderStyle.None;
            // 填充
            duiyiForm.Dock = DockStyle.Fill;

            // 清空Panel中的控件
            this.panel1.Controls.Clear();
            // 添加控件
            this.panel1.Controls.Add(duiyiForm);

            // 显示窗体
            duiyiForm.Show();
        }

        private void queryBtn_Click(object sender, EventArgs e)
        {
            // 设置子窗口：不显示为顶级窗口
            queryForm.TopLevel = false;
            // 设置子窗口：不显示标题栏
           // queryForm.FormBorderStyle = FormBorderStyle.None;
            // 填充
            queryForm.Dock = DockStyle.Fill;

            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(queryForm);

            // 显示窗体
            queryForm.Show();
        }
    }
}
