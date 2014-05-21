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
            utilitiesObject = new Utilities("DATA SOURCE=ORC;USER ID=Client;Password=Nhom3");
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            lbUsername.Text = "Welcome " + Program.username;
            dsTranDau = utilitiesObject.getTranDau();
            maxRowIndex = dsTranDau.Tables[0].Rows.Count;
            cbMaTranDau.DisplayMember = "ID";
            cbMaTranDau.ValueMember = "doi_tuyen_1";
            cbMaTranDau.DataSource = dsTranDau.Tables[0];
            

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
            getBinhLuan(rowIndex);
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
            
            getBinhLuan(rowIndex);
        }

        private void getBinhLuan(int rowIndex)
        {
            DataRow dr = dsTranDau.Tables[0].Rows[rowIndex];
            string id_tran_dau = dr["id"].ToString();
            binhLuan = null;
            dsBinhLuan = utilitiesObject.getBinhLuan(id_tran_dau);
            for (int i = 0; i < dsBinhLuan.Tables[0].Rows.Count; i++)
            {
                DataRow drow = dsBinhLuan.Tables[0].Rows[i];
                if (drow["duyet"].ToString() == "Y")
                { 
                    binhLuan = binhLuan +
                    drow["username"].ToString() + " wrote:\r\n\"" +
                    drow["noi_dung"].ToString() + "\"\r\n" + drow["Thoi_diem"].ToString() + "\r\n\r\n";
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

        private void cbMaTranDau_SelectedIndexChanged(object sender, EventArgs e)
        {
            rowIndex = cbMaTranDau.SelectedIndex;
            getInformation(rowIndex);
            getBinhLuan(rowIndex);
        }

    }
}
