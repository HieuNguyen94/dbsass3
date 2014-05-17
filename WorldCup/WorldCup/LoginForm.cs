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
    public partial class LoginForm : Form
    {
        private string username = null;
        private string password = null;

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

        private void btLogin_Click(object sender, EventArgs e)
        {
            
        }
    }
}
