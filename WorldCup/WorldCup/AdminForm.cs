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
        private Utilities utilitiesObject = new Utilities("DATA SOURCE=ORCL;USER ID=Admin;Password=Nhom3");

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
        }

        private void btWorldCup_Click(object sender, EventArgs e)
        {
            currentTable = TableType.WorldCup;
            utilitiesObject.viewWorldCup(dgv);
        }

        private void btQuanLyDoiBong_Click(object sender, EventArgs e)
        {
            currentTable = TableType.QuanLyDoiBong;
            utilitiesObject.viewQuanLyDoiBong(dgv);
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
            }
        }

        
    }
}
