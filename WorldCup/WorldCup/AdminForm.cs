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

        #region Thong bao
        private string thongTinBangTaiKhoan = "Chứa thông tin về các tài khoản hiện có.\r\nAdmin phân quyền bằng cách chỉnh sửa trực tiếp trên bảng và nhấp Commit.";
        private string thongTinBangWorldCup = "Chứa thông tin về các mùa WorldCup.";
        private string thongTinBangQuanLyDoiBong = "Chứa thông tin về TeamManager và đội bóng họ quản lý.\r\nAdmin phân quyền bằng cách chỉnh sửa trực tiếp trên bảng và nhấp Commit.";
        private string thongTinTranDau = "Chứa thông tin chi tiết về các trận đấu.";
        private string thongBaoLoi = "Đã có lỗi xảy ra, vui lòng kiểm ra lại.";
        #endregion

        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            lbUsername.Text = "Xin chào,\r\n" + Program.username;
            btCommit.Enabled = false;

            //btRefresh.FlatStyle = FlatStyle.Flat;
            //btRefresh.FlatAppearance.MouseDownBackColor = Color.White;

            //btLogout.FlatStyle = FlatStyle.Flat;
            //btLogout.FlatAppearance.MouseDownBackColor = Color.White;

            //btCommit.FlatStyle = FlatStyle.Flat;
            //btCommit.FlatAppearance.MouseDownBackColor = Color.White;
        }

        private void tbTaiKhoan_Click(object sender, EventArgs e)
        {
            btCommit.Enabled = false;

            currentTable = TableType.TaiKhoan;
            utilitiesObject.viewTaiKhoan(dgv);
            tbThongTin.Text = thongTinBangTaiKhoan;
        }

        private void btWorldCup_Click(object sender, EventArgs e)
        {
            btCommit.Enabled = false;

            currentTable = TableType.WorldCup;
            utilitiesObject.viewWorldCup(dgv);
            tbThongTin.Text = thongTinBangWorldCup;
        }

        private void btQuanLyDoiBong_Click(object sender, EventArgs e)
        {
            btCommit.Enabled = false;

            currentTable = TableType.QuanLyDoiBong;
            utilitiesObject.viewQuanLyDoiBong(dgv);
            tbThongTin.Text = thongTinBangQuanLyDoiBong;
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            //switch (currentTable)
            //{
            //    case TableType.WorldCup:
            //        utilitiesObject.updateWorldCup();
            //        break;
            //    case TableType.TaiKhoan:
            //        tbThongTin.Text = utilitiesObject.updateTaiKhoan();
            //        break;
            //    case TableType.QuanLyDoiBong:
            //        utilitiesObject.updateQuanLyDoiBong();
            //        break;
            //    case TableType.BinhLuan:
            //        utilitiesObject.updateBinhLuan();
            //        break;
            //}
            try
            {
                //utilitiesObject.update();
                tbThongTin.Text = utilitiesObject.update();
                btCommit.Enabled = false;
            }
            catch (Exception ex)
            {
                tbThongTin.Text = thongBaoLoi;
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
                case TableType.TranDau:
                    utilitiesObject.viewTranDau(dgv);
                    break;
            }
        }

        private void btLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btTranDau_Click(object sender, EventArgs e)
        {
            btCommit.Enabled = false;
            
            currentTable = TableType.TranDau;
            utilitiesObject.viewTranDau(dgv);
            tbThongTin.Text = thongTinTranDau;
        }

        private void dgv_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            btCommit.Enabled = true;
        }

        private void dgv_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            btCommit.Enabled = true;
        }

        private void dgv_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            btCommit.Enabled = true;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataRow dr = utilitiesObject.getDataSet.Tables[0].Rows[e.RowIndex];
                tbThongTin.Text = dr[e.ColumnIndex].ToString();
            } catch (Exception ex)
            {
                tbThongTin.Text = null;
            }
            
        }

        private void btRefresh_MouseHover(object sender, EventArgs e)
        {
            btRefresh.ImageKey = "RefreshButtonHover.png";
        }

        private void btRefresh_MouseLeave(object sender, EventArgs e)
        {
            btRefresh.ImageKey = "RefreshButton.png";
        }

        private void btLogout_MouseHover(object sender, EventArgs e)
        {
            btLogout.ImageKey = "SignoutButtonHover.png";
        }

        private void btCommit_MouseHover(object sender, EventArgs e)
        {
            btCommit.ImageKey = "CommitButtonHover.png";
        }

        private void btLogout_MouseLeave(object sender, EventArgs e)
        {
            btLogout.ImageKey = "SignoutButton.png";
        }

        private void btCommit_MouseLeave(object sender, EventArgs e)
        {
            btCommit.ImageKey = "CommitButton.png";
        }

        private void tbTaiKhoan_MouseHover(object sender, EventArgs e)
        {
            btTaiKhoan.ImageKey = "TaiKhoanHover.png";
        }

        private void tbTaiKhoan_MouseLeave(object sender, EventArgs e)
        {
            btTaiKhoan.ImageKey = "TaiKhoan.png";
        }

        private void btWorldCup_MouseHover(object sender, EventArgs e)
        {
            btWorldCup.ImageKey = "WorldCupHover.png";
        }

        private void btWorldCup_MouseLeave(object sender, EventArgs e)
        {
            btWorldCup.ImageKey = "WorldCup.png";
        }

        private void btQuanLyDoiBong_MouseHover(object sender, EventArgs e)
        {
            btQuanLyDoiBong.ImageKey = "QuanLyHover.png";
        }

        private void btQuanLyDoiBong_MouseLeave(object sender, EventArgs e)
        {
            btQuanLyDoiBong.ImageKey = "QuanLy.png";
        }

        private void btTranDau_MouseHover(object sender, EventArgs e)
        {
            btTranDau.ImageKey = "TranDauHover.png";
        }

        private void btTranDau_MouseLeave(object sender, EventArgs e)
        {
            btTranDau.ImageKey = "TranDau.png";
        }
    }
}
