using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;
namespace WorldCup
{
    public partial class ClientForm : Form
    {
        Utilities utilitiesObject;
        string id_td = null;
        string backPath = "/";
        string season = " ", time, team1, team2, main_result, extra_result, shootout_result ;
        Rectangle rect1;
        public ClientForm()
        {
            InitializeComponent();
            utilitiesObject = new Utilities("DATA SOURCE=ORC;USER ID=Client;Password=Nhom3");
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Xem thông tin";
            textBox2.Text += "Bình luận chưa được duyệt" + Environment.NewLine;
            textBox3.Text += "Bình luận đã được duyệt" + Environment.NewLine;
            splitContainer1.IsSplitterFixed = true;
            splitContainer2.IsSplitterFixed = true;
            splitContainer3.IsSplitterFixed = true;
            splitContainer4.IsSplitterFixed = true;
            splitContainer5.IsSplitterFixed = true;
            splitContainer6.IsSplitterFixed = true;
            rect1 = new Rectangle(0, 0, 290, 220);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Thông tin TRẬN ĐẤU")
            {
                try
                {
                    season = listView1.SelectedItems[0].Text;
                    time = listView1.SelectedItems[0].SubItems[1].Text;
                    team1 = listView1.SelectedItems[0].SubItems[2].Text;
                    team2 = listView1.SelectedItems[0].SubItems[3].Text;
                    main_result = "Tỉ số hiệp chính: " + listView1.SelectedItems[0].SubItems[4].Text;
                    extra_result = "Tỉ số hiệp phụ: " + listView1.SelectedItems[0].SubItems[5].Text;
                    shootout_result = "Tỉ số luân lưu: " + listView1.SelectedItems[0].SubItems[6].Text;
                    comboBox1.Text = season +" "+ time +" "+ team1 + " vs " + team2;
                    splitContainer7.Panel2.Refresh();
                    string id_tran_dau = listView1.SelectedItems[0].SubItems[7].Text;
                    id_td = id_tran_dau;
                    string[] sk = new string[]{"Thời điểm", "Diễn biến"};
                    utilitiesObject.loadToListView(listView1,utilitiesObject.get_view("hr.viewSuKien",id_tran_dau),sk);
                    utilitiesObject.showComment(textBox3, id_tran_dau);
                }
                catch { }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            id_td = null;
            season = " ";
            splitContainer7.Panel2.Refresh();
            utilitiesObject.combolistOption(comboBox1.Text,listView1);
            string lastOpt = backPath.Split('/').Last();
            if(lastOpt != comboBox1.Text)
                backPath += "/" + comboBox1.Text;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.SelectionStart = textBox2.Text.Length;
            textBox2.ScrollToCaret();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.SelectionStart = textBox3.Text.Length;
            textBox3.ScrollToCaret();
        }

        private void SEND_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.ToString()[0] == 'W' && id_td != null)
            {
                if (textBox1.Text.Length < 1)
                    return;
                string time = DateTime.Today.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("hh:mm:ss:tt");
                string name = Program.username;
                string content = textBox1.Text.ToString();
                textBox2.Text += time + ", " + name + " : " + content + Environment.NewLine;
                textBox1.Clear();
                try
                {
                    utilitiesObject.insertBinhLuan(id_td, name, content);
                }
                catch { }
            }
            else
            {
                textBox2.Text += "Vui lòng chọn 1 trận đấu trong bảng trận đấu" + Environment.NewLine;
            }
        }

        private void CLEAR_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            splitContainer7.Panel2.Refresh();
            if (comboBox1.Text[0] == 'W')
            {
                utilitiesObject.loadToListView(listView1, utilitiesObject.get_view("hr.viewSuKien", id_td), new string[] { "Thời điểm", "Diễn biến" });
                textBox3.Clear();
                utilitiesObject.showComment(textBox3, id_td);
                return;
            }
            id_td = null;
            utilitiesObject.combolistOption(comboBox1.Text, listView1);
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text[0] == 'W')
            {
                comboBox1.Text = "Thông tin TRẬN ĐẤU";
                utilitiesObject.combolistOption("Thông tin TRẬN ĐẤU", listView1);
                season = " ";
                splitContainer7.Panel2.Refresh();
                return;
            }
            if (backPath.Length < 2)
                return;
            string opt = backPath.Split('/').Last();
            string remain = backPath.Substring(0, backPath.Length - opt.Length - 1);
            if (remain.Length < 2)
               return;
            opt = remain.Split('/').Last();
            comboBox1.Text = opt;
            backPath = remain;
            utilitiesObject.combolistOption(opt, listView1);
        }

        private void splitContainer7_Panel2_Paint(object sender, PaintEventArgs e)
        {
            if(season.Length < 2)return;
            if (this.Width < 900)
            {
                rect1 = new Rectangle(0, 0, 290, 220);
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                // Draw the text and the surrounding rectangle.
                e.Graphics.DrawString(season + "\n\n\n\n\n\n", new Font("Times New Roman", 20, FontStyle.Bold, GraphicsUnit.Point), Brushes.Yellow, rect1, stringFormat);
                e.Graphics.DrawString("\n" + team1 + " vs " + team2 + "\n\n\n\n\n", new Font("Times New Roman", 14, FontStyle.Bold, GraphicsUnit.Point), Brushes.Yellow, rect1, stringFormat);
                e.Graphics.DrawString("\n\n\n" + time + "\n" + main_result + "\n" + extra_result + "\n" + shootout_result, new Font("Times New Roman", 13, FontStyle.Bold, GraphicsUnit.Point), Brushes.Yellow, rect1, stringFormat);
                e.Graphics.DrawRectangle(Pens.Black, rect1);
            }
            else
            {
                rect1 = new Rectangle(0, 0, 453, 343);
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                // Draw the text and the surrounding rectangle.
                e.Graphics.DrawString(season + "\n\n\n\n\n\n\n\n\n", new Font("Times New Roman", 25, FontStyle.Bold, GraphicsUnit.Point), Brushes.Yellow, rect1, stringFormat);
                e.Graphics.DrawString("\n" + team1 + " vs " + team2 + "\n\n\n\n\n\n\n\n", new Font("Times New Roman", 20, FontStyle.Bold, GraphicsUnit.Point), Brushes.Yellow, rect1, stringFormat);
                e.Graphics.DrawString("\n\n\n" + time + "\n\n" + main_result + "\n\n" + extra_result + "\n\n" + shootout_result, new Font("Times New Roman", 16, FontStyle.Bold, GraphicsUnit.Point), Brushes.Yellow, rect1, stringFormat);
                e.Graphics.DrawRectangle(Pens.Black, rect1);
            }
        }

        private void ClientForm_MaximumSizeChanged(object sender, EventArgs e)
        {
             rect1 = new Rectangle(0, 0, 453, 343);
             splitContainer7.Panel2.Refresh();
        }

        private void ClientForm_MinimumSizeChanged(object sender, EventArgs e)
        {
            rect1 = new Rectangle(0, 0, 453, 343);
            splitContainer7.Panel2.Refresh();
        }
    }
}
