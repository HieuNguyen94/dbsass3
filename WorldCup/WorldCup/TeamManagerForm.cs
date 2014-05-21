using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
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
        private Utilities uti = new Utilities("DATA SOURCE=ORC;USER ID=TeamManager;Password=Nhom3");
        private string name = "";
        private OracleCommand cmd;
        private int i = 0;

        public TeamManagerForm()
        {
            InitializeComponent();
            
        }

        private void TeamManagerForm_Load(object sender, EventArgs e)
        {
            lbUsername.Text = "Welcome " + Program.username;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            label1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = "ENGLAND";
            if (uti.choose_team(name) == 1)
            {
                hide_flag();
                uti.show_flag(name, button11);
                button9.BackgroundImage = Properties.Resources.Eng1;
                menuStrip1.Visible = true;
                profile_visible();
                show_info();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            name = "NETHERLANDS";
            if (uti.choose_team("NETHERLANDS") == 1)
            {
                hide_flag();
                uti.show_flag(name, button11);
                button9.BackgroundImage = Properties.Resources.Ned1;
                menuStrip1.Visible = true;
                profile_visible();
                show_info();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            name = "SPAIN";
            if (uti.choose_team("SPAIN") == 1)
            {
                hide_flag();
                uti.show_flag(name, button11);
                button9.BackgroundImage = Properties.Resources.SPA1;
                menuStrip1.Visible = true;
                profile_visible();
                show_info();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            name = "BRAZIL";
            if (uti.choose_team("BRAZIL") == 1)
            {
                hide_flag();
                uti.show_flag(name, button11);
                button9.BackgroundImage = Properties.Resources.BRA1;
                menuStrip1.Visible = true;
                profile_visible();
                show_info();
            }
        }

        private void caToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profile_visible();
            pr_rnLabel();
            textBox1.Visible = false;
            switch (name)
            {
                case "ENGLAND":
                    button1_Click(sender, e);
                    break;
                case "NETHERLANDS":
                    button2_Click(sender, e);
                    break;
                case "BRAZIL":
                    button4_Click(sender, e);
                    break;
                case "SPAIN":
                    button3_Click(sender, e);
                    break;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            i = 5;
            profile_visible();
            ct_rnLabel();
            button10.Visible = true;
            button10.BackgroundImage = button5.BackgroundImage;
            textBox1.Visible = true;
            label11.Visible = true;
            //button14.Enabled = true;
            //button13.Enabled = true;
            //button13.Visible = true;
            //button14.Visible = true;
            cmd = new OracleCommand();
            cmd = uti.view_ct(label2.Text);
            show_player_info();
            textBox1.Text = label2.Text;
        }

        private void player_visible()
        {
            label11.Visible = false;
            label6.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label7.Visible = false;
            textBox4.Visible = false;
            textBox3.Visible = false;
            textBox2.Visible = false;
            textBox5.Visible = false;
            textBox1.Visible = false;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = false;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            button10.Visible = false;
            dgv.Visible = false;
            button14.Visible = false;
            button13.Visible = false;
        }

        private void profile_visible()
        {
            button14.Visible = false;
            button13.Visible = false;
            button12.Visible = true;
            button9.Visible = true;
            button10.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label11.Visible = false;

            label6.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label7.Visible = true;
            textBox4.Visible = true;
            textBox3.Visible = true;
            textBox2.Visible = true;
            textBox5.Visible = true;

            dgv.Visible = false;
        }

        private void ct_rnLabel()
        {
            button9.Visible = false;
            label6.Visible = false;
            label7.Text = "Day of Birth:";
            label8.Text = "Playing Position:";
            label9.Text = "Number:";
            label10.Text = "Match:";
        }

        private void pr_rnLabel()
        {
            label7.Text = "Team:";
            label8.Text = "Coach:";
            label9.Text = "Champion Time:";
            label10.Text = "Formation:";
        }

        private void hide_flag()
        {
            lbUsername.Visible = true;
            label1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button11.Visible = true;
        }

        private void show_info()
        {
            textBox4.Text = uti.c_time(name);
            textBox2.Text = name;
            textBox3.Text = uti.v_team(name);
            textBox5.Text = uti.v_team_for(name);
        }

        private void show_player_info()
        {
            textBox2.Text = cmd.Parameters[1].Value.ToString();
            textBox3.Text = cmd.Parameters[3].Value.ToString();
            textBox4.Text = cmd.Parameters[2].Value.ToString();
            textBox5.Text = cmd.Parameters[4].Value.ToString();
        }

        private void matchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (name == "ENGLAND")
            {
                player_visible();
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
                player_visible();
                label5.Text = "Robin Van Persie";
                //button8.BackgroundImage = Properties.Resources.persie;
                label3.Text = "Thiago Silva";
                button6.BackgroundImage = Properties.Resources.silva;
                label4.Text = "Xavi Hernandez";
                button7.BackgroundImage = Properties.Resources.xavi;
                label2.Text = "Cesc Fabregas";
                button5.BackgroundImage = Properties.Resources.cesc;
            }
            else if (name == "BRAZIL")
            {
                player_visible();

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
                player_visible();

                label2.Text = "Miroslav Klose";
                button5.BackgroundImage = Properties.Resources.klose;
                label3.Text = "Franck Ribéry";
                button6.BackgroundImage = Properties.Resources.ribery;
                label4.Text = "Diego Forlán";
                //button7.BackgroundImage = Properties.Resources.forlan;
                label5.Text = "Ronaldo de Lima";
                button8.BackgroundImage = Properties.Resources.ronaldo;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            profile_visible();
            ct_rnLabel();
            button10.Visible = true;
            button10.BackgroundImage = button6.BackgroundImage;
            textBox1.Visible = true;
            label11.Visible = true;
            cmd = new OracleCommand();
            cmd = uti.view_ct(label3.Text);
            show_player_info();
            textBox1.Text = label3.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            profile_visible();
            ct_rnLabel();
            button10.Visible = true;
            button10.BackgroundImage = button7.BackgroundImage;
            textBox1.Visible = true;
            label11.Visible = true;
            cmd = new OracleCommand();
            cmd = uti.view_ct(label4.Text);
            show_player_info();
            textBox1.Text = label4.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            profile_visible();
            ct_rnLabel();
            button10.Visible = true;
            button10.BackgroundImage = button8.BackgroundImage;
            textBox1.Visible = true;
            label11.Visible = true;
            cmd = new OracleCommand();
            cmd = uti.view_ct(label5.Text);
            show_player_info();
            textBox1.Text = label5.Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;

            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            lbUsername.Visible = false;

            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            menuStrip1.Visible = false;
            dgv.Visible = false;

            TeamManagerForm_Load(sender, e);
        }

        private void matchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            i = 1;
            show_man_lb();
            uti.v_dt_thamdu(name, dgv);
            button13.Visible = true;
            button13.Enabled = true;
            button14.Visible = true;
            button14.Enabled = true;
        }

        private void captainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            i = 3;
            show_man_lb();
            uti.captain(name, dgv);
            button13.Visible = true;
            button13.Enabled = true;
            button14.Visible = true;
            button14.Enabled = true;
        }


        private void show_man_lb()
        {
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;

            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label7.Visible = false;
            label6.Visible = true;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;

            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;


            dgv.Visible = true;
        }

        private void teToolStripMenuItem_Click(object sender, EventArgs e)
        {
            i = 2;
            show_man_lb();
            uti.trandau(name, dgv);
            button13.Visible = true;
            button13.Enabled = true;
            button14.Visible = true;
            button14.Enabled = true;
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //int y;
            //int z;
            //int t;

            //if (i == 5)
            //{
            //    if (int.TryParse(cmd.Parameters[4].Value.ToString(),out y) )
            //    {
            //        if (int.TryParse(textBox4.Text, out z))
            //            if (int.TryParse(textBox5.Text, out t))
            //                uti.update_ct(label2.Text, z, textBox1.Text, textBox3.Text, z, t);
            //    }
            //}
            uti.updateTeam();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            switch (i)
            {
                case 1:
                    uti.v_dt_thamdu(name, dgv);
                    break;
                case 2:
                    uti.trandau(name, dgv);
                    break;
                case 3:
                    uti.captain(name, dgv);
                    break;
                //case 5:
                //    uti.view_ct(label2.Text);
                //    break;
            }
        }

        private void btLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
