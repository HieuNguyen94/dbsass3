using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldCup
{
    public partial class SignUpForm : Form
    {
        private string password = null;
        private AccountType accountType = AccountType.None;
        private Utilities utilitiesObject = new Utilities("DATA SOURCE=ORC;USER ID=HR;Password=Nhom3");
        LoginForm form = new LoginForm();

        public SignUpForm()
        {
            InitializeComponent();
        }

        public SignUpForm(LoginForm loginform)
        {
            InitializeComponent();
            this.form = loginform;
        }

        private void CheckBtn_Click(object sender, EventArgs e)
        {
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            form.Enabled = true;
            base.OnClosing(e);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (tbName.Text == null || tbPass.Text == null || tbRePass.Text == null)
            {
                MessageBox.Show("Incomplete form!");
            }
            else
            {
                if (utilitiesObject.checkUserName(tbName.Text))
                {
                    if (tbPass.Text != tbRePass.Text)
                    {
                        MessageBox.Show("Passwords are not matched");
                    }
                    else
                    {
                        utilitiesObject.createAccount(tbName.Text, tbPass.Text);
                        MessageBox.Show("Success!");
                    }
                }
                else
                {
                    MessageBox.Show("Username exists!");
                }
            }

        }
    }
}
