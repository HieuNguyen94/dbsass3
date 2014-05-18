using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
namespace WorldCup
{
    public partial class LoginForm : Form
    {
        private string username = null;
        private string password = null;
        private string accountType = null;
        public LoginForm()
        {
            InitializeComponent();
        }

        public string getUsername
        {
            get { return username; }
        }

        public string getPassword
        {
            get { return password; }
        }

        public string getAccountType
        {
            get { return accountType; }
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if (validAccount(tbUsername.Text, tbPassword.Text, cbAccountType.Text))
            {
                MessageBox.Show("Welcome " + tbUsername.Text);
                username = tbUsername.Text;
                password = tbPassword.Text;
                accountType = cbAccountType.Text;
                this.Close();
            }
            else MessageBox.Show("Invalid account");

        }

        /* Ham nay dung de kiem tra xem tai khoan nguoi dung nhap vao co ton tai hay khong
         * Neu co return true
         * Nguoc lai return false
         */
        private bool validAccount(string iusername, string password, string loai)
        {
            string oradb = "DATA SOURCE=ORCL;USER ID=HR;Password=Nhom3";
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();

            OracleCommand cmd = new OracleCommand("isValidAccount", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_username = new OracleParameter();
            in_username.OracleDbType = OracleDbType.Varchar2;
            in_username.Direction = ParameterDirection.Input;
            in_username.Value = iusername;
            cmd.Parameters.Add(in_username);

            OracleParameter in_password = new OracleParameter();
            in_password.OracleDbType = OracleDbType.Varchar2;
            in_password.Direction = ParameterDirection.Input;
            in_password.Value = password;
            cmd.Parameters.Add(in_password);

            OracleParameter in_loai = new OracleParameter();
            in_loai.OracleDbType = OracleDbType.Varchar2;
            in_loai.Direction = ParameterDirection.Input;
            in_loai.Value = loai;
            cmd.Parameters.Add(in_loai);

            OracleParameter flag = new OracleParameter();
            flag.OracleDbType = OracleDbType.Int16;
            flag.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(flag);

            cmd.ExecuteNonQuery();
            if (cmd.Parameters[3].Value.ToString() == "1")
                return true;
            else return false;

            conn.Close();
            conn.Dispose();
        }
    }
}
