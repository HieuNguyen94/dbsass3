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
namespace WorldCup
{
    public partial class ClientForm : Form
    {
        Utilities utilitiesObject;
        DataSet dsTranDau;
        DataSet dsBinhLuan;
        private int rowIndex = 0;
        private int maxRowIndex = 0;
        private string binhLuan = null;
        public ClientForm()
        {
            InitializeComponent();
            utilitiesObject = new Utilities("DATA SOURCE=ORCL;USER ID=Client;Password=Nhom3");
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            lbUsername.Text = "Welcome " + Program.username;
            dsTranDau = utilitiesObject.getTranDau();
            maxRowIndex = dsTranDau.Tables[0].Rows.Count;
            getInformation(3);
        }

        private void getInformation(int row)
        {
            DataRow dr = dsTranDau.Tables[0].Rows[row];
            lbDoiTuyen1.Text = dr["doi_tuyen_1"].ToString();
            lbDoiTuyen2.Text = dr["doi_tuyen_2"].ToString();
            lbTiSoHiepChinh.Text = dr["ti_so_hiep_chinh"].ToString();
            lbTiSoHiepPhu.Text = dr["ti_so_hiep_phu"].ToString();
            if (dr["ti_so_luan_luu"].ToString() != null)
            {
                lbTiSoLuanLuu.Text = dr["ti_so_luan_luu"].ToString();
            }
            else lbTiSoLuanLuu.Text = "";
        }

        private void btPrevious_Click(object sender, EventArgs e)
        {
            rowIndex--;
            if (rowIndex >= 0)
            {
                getInformation(rowIndex);
            } else
            {
                rowIndex = maxRowIndex - 1;
                getInformation(rowIndex);
            }
            DataRow dr = dsTranDau.Tables[0].Rows[rowIndex];
            string id = dr["id"].ToString();
            getBinhLuan(id);
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            rowIndex++;
            if (rowIndex < maxRowIndex)
            {
                getInformation(rowIndex);
            }
            else
            {
                rowIndex = 0;
                getInformation(rowIndex);
            }
            DataRow dr = dsTranDau.Tables[0].Rows[rowIndex];
            string id = dr["id"].ToString();
            getBinhLuan(id);
        }

        private void getBinhLuan(string id_tran_dau)
        {
            binhLuan = null;
            dsBinhLuan = utilitiesObject.getBinhLuan(id_tran_dau);
            for (int i = 0; i < dsBinhLuan.Tables[0].Rows.Count; i++)
            {
                DataRow dr = dsBinhLuan.Tables[0].Rows[i];
                if (dr["duyet"].ToString() == "Y")
                { 
                    binhLuan = binhLuan +
                    dr["username"].ToString() + " wrote:\r\n\"" +
                    dr["noi_dung"].ToString() + "\"\r\n" + dr["Thoi_diem"].ToString() + "\r\n\r\n";
                }
            }
            tbComment.Text = binhLuan;
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            tbNewComment.Text = null;
        }

        private void btPost_Click(object sender, EventArgs e)
        {
            if (tbNewComment.Text != null)
            {
                DataRow dr = dsTranDau.Tables[0].Rows[rowIndex];
                utilitiesObject.insertBinhLuan(dr["id"].ToString(), Program.username, tbNewComment.Text);
                MessageBox.Show("Your comment will be posted later");
            }
        }

        private void btLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

    }
}
