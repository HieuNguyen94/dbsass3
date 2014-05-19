using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
namespace WorldCup
{
    public partial class AdminForm : Form
    {
        private TableType currentTable = TableType.None;
        private Utilities utilitiesObject = new Utilities("DATA SOURCE=ORC;USER ID=Admin;Password=Nhom3");

        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            lbUsername.Text = "Welcome " + Program.username;
        }

        private void tbTaiKhoan_Click(object sender, EventArgs e)
        {
            currentTable = TableType.TaiKhoan;
            utilitiesObject.viewTaiKhoan(dgv);
            btCommit.Enabled = true;
            btRefresh.Enabled = true;
        }

        private void btWorldCup_Click(object sender, EventArgs e)
        {
            currentTable = TableType.WorldCup;
            utilitiesObject.viewWorldCup(dgv);
            btCommit.Enabled = true;
            btRefresh.Enabled = true;
        }

        private void btQuanLyDoiBong_Click(object sender, EventArgs e)
        {
            currentTable = TableType.QuanLyDoiBong;
            utilitiesObject.viewQuanLyDoiBong(dgv);
            btCommit.Enabled = true;
            btRefresh.Enabled = true;
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            switch (currentTable)
            {
                case TableType.WorldCup:
                    utilitiesObject.updateWorldCup();
                    break;
                case TableType.TaiKhoan:
                    utilitiesObject.updateTaiKhoan();
                    break;
                case TableType.QuanLyDoiBong:
                    utilitiesObject.updateQuanLyDoiBong();
                    break;
                case TableType.BinhLuan:
                    utilitiesObject.updateBinhLuan();
                    break;
            }          
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            switch (currentTable)
            {
                case TableType.WorldCup:
                    utilitiesObject.viewWorldCup(dgv);
                    break;
                case TableType.TaiKhoan:
                    utilitiesObject.viewTaiKhoan(dgv);
                    break;
                case TableType.QuanLyDoiBong:
                    utilitiesObject.viewQuanLyDoiBong(dgv);
                    break;
                case TableType.BinhLuan:
                    utilitiesObject.viewBinhLuan(dgv);
                    break;
            }
        }

        private void btLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btBinhLuan_Click(object sender, EventArgs e)
        {
            currentTable = TableType.BinhLuan;
            utilitiesObject.viewBinhLuan(dgv);
            btCommit.Enabled = true;
            btRefresh.Enabled = true;
        }

        private void btTranDau_Click(object sender, EventArgs e)
        {
            currentTable = TableType.TranDau;
            utilitiesObject.viewTranDau(dgv);
            btCommit.Enabled = false;
            btRefresh.Enabled = false;
        }

        
    }
}
