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
        //private string username = null;
        private string password = null;
        private AccountType accountType = AccountType.None;
        private Utilities utilitiesObject = new Utilities("DATA SOURCE=ORC;USER ID=HR;Password=Nhom3");
        public LoginForm()
        {
            InitializeComponent();
        }

        //public string getUsername
        //{
        //    get { return username; }
        //}

        public string getPassword
        {
            get { return password; }
        }

        public AccountType getAccountType
        {
            get { return accountType; }
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if (utilitiesObject.foundAccount(tbUsername.Text, tbPassword.Text, cbAccountType.Text))
            {
                //MessageBox.Show("Welcome " + tbUsername.Text);
                Program.username = tbUsername.Text;
                password = tbPassword.Text;
                accountType = (AccountType)Enum.Parse(typeof(AccountType), cbAccountType.Text);
                this.Close();
            }
            else MessageBox.Show("Account not found");
        }

        
    }
}
