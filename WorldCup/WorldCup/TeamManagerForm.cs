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
        private OracleCommand cmd;

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
                lbUsername.Visible = true;
                label1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                Button btn = sender as Button;
                btn.Location = new Point(TeamManagerForm.ActiveForm.Size.Width - button1.Size.Width - 15, 25);
                button1.Enabled = false;
                i = 1;
                textBox1.Visible = true;
                textBox1.Text = uti.c_time(name);
                menuStrip1.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            name = "NETHERLANDS";
            if (uti.choose_team("NETHERLANDS") == 1)
            {
                label1.Visible = false;
                lbUsername.Visible = true;
                button1.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                Button btn = sender as Button;
                btn.Location = new Point(TeamManagerForm.ActiveForm.Size.Width - button2.Size.Width - 15, 25);
                button2.Enabled = false;
                menuStrip1.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            name = "SPAIN";
            if (uti.choose_team("SPAIN") == 1)
            {
                lbUsername.Visible = true;
                label1.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                button4.Visible = false;
                Button btn = sender as Button;
                btn.Location = new Point(TeamManagerForm.ActiveForm.Size.Width - button3.Size.Width - 15, 25);
                button3.Enabled = false;
                menuStrip1.Visible = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            name = "BRAZIL";
            if (uti.choose_team("BRAZIL") == 1)
            {
                lbUsername.Visible = true;
                label1.Visible = false;
                button1.Visible = false;
                button3.Visible = false;
                button2.Visible = false;
                Button btn = sender as Button;
                btn.Location = new Point(TeamManagerForm.ActiveForm.Size.Width - button4.Size.Width - 15, 25);
                button4.Enabled = false;
                menuStrip1.Visible = true;
            }
        }

        private void caToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (name == "ENGLAND")
            {
                button5.Visible = true;
                button6.Visible = true;
                button7.Visible = true;
                button8.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;


                label2.Text = "Wayne Rooney";
                button5.BackgroundImage = Properties.Resources.rooney;
                label3.Text = "Steven Gerrard";
                button6.BackgroundImage = Properties.Resources.gerrard;
                label5.Text = "Neymar da Silva";
                button8.BackgroundImage = Properties.Resources.neymar;
                label4.Text = "Wesley Sneijder";
                button7.BackgroundImage = Properties.Resources.sneijder;
            }
            else if (name == "NETHERLANDS")
            {
                button5.Visible = true;
                button6.Visible = true;
                button7.Visible = true;
                button8.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;

                label5.Text = "Robin Van Persie";
                button8.BackgroundImage = Properties.Resources.persie;
                label3.Text = "Thiago Silva";
                button6.BackgroundImage = Properties.Resources.silva;
                label4.Text = "Xavi Hernandez";
                button7.BackgroundImage = Properties.Resources.xavi;
                label2.Text = "Cesc Fabregas";
                button5.BackgroundImage = Properties.Resources.cesc;
            }
            else if (name == "BRAZIL")
            {
                button5.Visible = true;
                button6.Visible = true;
                button7.Visible = true;
                button8.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;

                label2.Text = "Oliver Kahn";
                button5.BackgroundImage = Properties.Resources.kahn;
                label3.Text = "Philip Lahm";
                button6.BackgroundImage = Properties.Resources.lahm;
                label4.Text = "Mesut Özil";
                button7.BackgroundImage = Properties.Resources.ozil;
                label5.Text = "Zinédine Zidanes";
                button8.BackgroundImage = Properties.Resources.zidane;
            }
            else if (name == "SPAIN")
            {
                button5.Visible = true;
                button6.Visible = true;
                button7.Visible = true;
                button8.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;

                label2.Text = "Miroslav Klose";
                button5.BackgroundImage = Properties.Resources.klose;
                label3.Text = "Franck Ribéry";
                button6.BackgroundImage = Properties.Resources.ribery;
                label4.Text = "Diego Forlán";
                button7.BackgroundImage = Properties.Resources.forlan;
                label5.Text = "Ronaldo de Lima";
                button8.BackgroundImage = Properties.Resources.ronaldo;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (name == "ENGLAND")
            {
                cmd = new OracleCommand();
                cmd = uti.view_ct("CT0001");



            }
        }

        
    }
}
