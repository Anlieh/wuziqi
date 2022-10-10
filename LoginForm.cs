using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wuqizi;

namespace wuziqi
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string pwd = pwdTextBox.Text;

            string sql = "select * from users where username = '" + username
                + " 'and password='" + pwd + "'";
            
            DataTable dt = DBclass.GetTable(sql);
            if (dt.Rows.Count > 0)
            {
                Setting.username = username;
                DuiyiForm duiyiForm = new DuiyiForm();
                duiyiForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("用户名或密码错误!");
            }
        }
    }
}
