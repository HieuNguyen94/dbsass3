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
        public ClientForm()
        {
            InitializeComponent();
            utilitiesObject = new Utilities("DATA SOURCE=ORC;USER ID=Client;Password=Nhom3");
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Xem thong tin";
            textBox2.Text += "COMMENT chua duoc duyet" + Environment.NewLine;
            textBox3.Text += "COMMENT da duoc duyet" + Environment.NewLine;
            splitContainer1.IsSplitterFixed = true;
            splitContainer2.IsSplitterFixed = true;
            splitContainer3.IsSplitterFixed = true;
            splitContainer4.IsSplitterFixed = true;
            splitContainer5.IsSplitterFixed = true;
            splitContainer6.IsSplitterFixed = true;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Thong tin TRAN DAU")
            {
                try
                {
                    string time = listView1.SelectedItems[0].Text + ",   ";
                    string match = listView1.SelectedItems[0].SubItems[1].Text + "\t";
                    string main_result = "Main Result : " + listView1.SelectedItems[0].SubItems[2].Text + "\t";
                    string extra_result = "Extra Result : " + listView1.SelectedItems[0].SubItems[2].Text + "\t";
                    string shootout_result = "ShootOut Result : " + listView1.SelectedItems[0].SubItems[2].Text;
                    comboBox1.Text = time + match + main_result + extra_result + shootout_result;
                    string id_tran_dau = listView1.SelectedItems[0].SubItems[5].Text;
                    id_td = id_tran_dau;
                    utilitiesObject.loadToListView(listView1, utilitiesObject.get_view("hr.viewSuKien", id_tran_dau));
                    utilitiesObject.showComment(textBox3, id_tran_dau);
                }
                catch { }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            id_td = null;
            switch (comboBox1.Text)
            {
                case "Thong tin cac ky World Cup":
                    utilitiesObject.loadToListView(listView1,utilitiesObject.get_view("hr.viewWorldCup"));
                    break;
                case "Thong tin DOI TUYEN":
                    utilitiesObject.loadToListView(listView1, utilitiesObject.get_view("hr.viewDoiTuyen"));
                    break;
                case "Thong tin CAU THU":
                    utilitiesObject.loadToListView(listView1, utilitiesObject.get_view("hr.viewCauThu"));
                    break;
                case "Thong tin HUAN LUYEN VIEN":
                    utilitiesObject.loadToListView(listView1, utilitiesObject.get_view("hr.viewHLV"));
                    break;
                case "Thong tin TRAN DAU":
                    utilitiesObject.loadToListView(listView1, utilitiesObject.get_view("hr.viewTranDau_clientMode"));
                    break;
                default: break;
            }
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
                string name = "client_1";
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
                textBox2.Text += "Vui long chon 1 tran dau trong bang TRAN_DAU" + Environment.NewLine;
            }
        }

        private void CLEAR_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text[0] == 'W')
            {
                utilitiesObject.loadToListView(listView1, utilitiesObject.get_view("hr.viewSuKien", id_td));
                textBox3.Clear();
                utilitiesObject.showComment(textBox3, id_td);
                return;
            }
            id_td = null;
            switch (comboBox1.Text)
            {
                case "Thong tin cac ky World Cup":
                    utilitiesObject.loadToListView(listView1, utilitiesObject.get_view("hr.viewWorldCup"));
                    break;
                case "Thong tin DOI TUYEN":
                    utilitiesObject.loadToListView(listView1, utilitiesObject.get_view("hr.viewDoiTuyen"));
                    break;
                case "Thong tin CAU THU":
                    utilitiesObject.loadToListView(listView1, utilitiesObject.get_view("hr.viewCauThu"));
                    break;
                case "Thong tin HUAN LUYEN VIEN":
                    utilitiesObject.loadToListView(listView1, utilitiesObject.get_view("hr.viewHLV"));
                    break;
                case "Thong tin TRAN DAU":
                    utilitiesObject.loadToListView(listView1, utilitiesObject.get_view("hr.viewTranDau_clientMode"));
                    break;
                default: break;
            }
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

    }
}
