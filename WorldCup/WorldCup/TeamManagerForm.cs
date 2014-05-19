using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldCup
{
    public partial class TeamManagerForm : Form
    {
        private Utilities uti = new Utilities("DATA SOURCE=ORCL;USER ID=TeamManager;Password=Nhom3");
        private int i = 0;
        private string name = "";

        public TeamManagerForm()
        {
            InitializeComponent();
        }

        private void TeamManagerForm_Load(object sender, EventArgs e)
        {
            lbUsername.Text = "Welcome " + Program.username;
            if (i == 1)
            {
                textBox1.Visible = true;
                textBox1.Text = uti.c_time(name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = "ENGLAND";
            if (uti.choose_team(name) == 1)
            {
                label1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                Button btn = sender as Button;
                btn.Location = new Point(TeamManagerForm.ActiveForm.Size.Width - button1.Size.Width - 15, 0);
                button1.Enabled = false;
                i = 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            name = "NETHERLANDS";
            if (uti.choose_team("NETHERLANDS") == 1)
            {
                label1.Visible = false;
                button1.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                Button btn = sender as Button;
                btn.Location = new Point(TeamManagerForm.ActiveForm.Size.Width - button2.Size.Width - 15, 0);
                button2.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            name = "SPAIN";
            if (uti.choose_team("SPAIN") == 1)
            {
                label1.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                button4.Visible = false;
                Button btn = sender as Button;
                btn.Location = new Point(TeamManagerForm.ActiveForm.Size.Width - button3.Size.Width - 15, 0);
                button3.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            name = "BRAZIL";
            if (uti.choose_team("BRAZIL") == 1)
            {
                label1.Visible = false;
                button1.Visible = false;
                button3.Visible = false;
                button2.Visible = false;
                Button btn = sender as Button;
                btn.Location = new Point(TeamManagerForm.ActiveForm.Size.Width - button4.Size.Width - 15, 0);
                button4.Enabled = false;
            }
        }

        
    }
}
