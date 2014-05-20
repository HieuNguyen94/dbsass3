using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldCup
{
    public partial class ReporterForm : Form
    {
        private TableType currentTable = TableType.None;
        private Utilities utilitiesObject = new Utilities("DATA SOURCE=ORC;USER ID=Reporter;Password=Nhom3");

        public ReporterForm()
        {
            InitializeComponent();
        }

        private void ReporterForm_Load(object sender, EventArgs e)
        {
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            switch (TableList.SelectedIndex)
            {
                case 0:
                    currentTable = TableType.TranDau;
                    utilitiesObject.viewTranDau(dataView);
                    break;
                case 1:
                    currentTable = TableType.PhatThe;
                    utilitiesObject.viewPhatThe(dataView);
                    break;
                case 2:
                    currentTable = TableType.BanThang;
                    utilitiesObject.viewBanThang(dataView);
                    break;
                case 3:
                    currentTable = TableType.ChonCauThuXuatSac;
                    utilitiesObject.viewChonCauThuXuatSac(dataView);
                    break;
                case 4:
                    currentTable = TableType.ThayNguoi;
                    utilitiesObject.viewThayNguoi(dataView);
                    break;
                case 5:
                    currentTable = TableType.LuanLuu;
                    utilitiesObject.viewLuanLuu(dataView);
                    break;
                case 6:
                    currentTable = TableType.DeoBangDoiTruong;
                    utilitiesObject.viewDeoBangDoiTruong(dataView);
                    break;
                case 7:
                    currentTable = TableType.DoiHinhXuatPhat;
                    utilitiesObject.viewDoiHinhXuatPhat(dataView);
                    break;
                case 8:
                    currentTable = TableType.BinhLuan;
                    utilitiesObject.viewBinhLuan(dataView);
                    break;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            switch (currentTable)
            {
                case TableType.TranDau:
                    utilitiesObject.viewTranDau(dataView);
                    break;
                case TableType.PhatThe:
                    currentTable = TableType.PhatThe;
                    utilitiesObject.viewPhatThe(dataView);
                    break;
                case TableType.BanThang:
                    currentTable = TableType.BanThang;
                    utilitiesObject.viewBanThang(dataView);
                    break;
                case TableType.ChonCauThuXuatSac:
                    currentTable = TableType.ChonCauThuXuatSac;
                    utilitiesObject.viewChonCauThuXuatSac(dataView);
                    break;
                case TableType.ThayNguoi:
                    currentTable = TableType.ThayNguoi;
                    utilitiesObject.viewThayNguoi(dataView);
                    break;
                case TableType.LuanLuu:
                    currentTable = TableType.LuanLuu;
                    utilitiesObject.viewLuanLuu(dataView);
                    break;
                case TableType.DeoBangDoiTruong:
                    currentTable = TableType.DeoBangDoiTruong;
                    utilitiesObject.viewDeoBangDoiTruong(dataView);
                    break;
                case TableType.DoiHinhXuatPhat:
                    currentTable = TableType.DoiHinhXuatPhat;
                    utilitiesObject.viewDoiHinhXuatPhat(dataView);
                    break;
                case TableType.BinhLuan:
                    currentTable = TableType.BinhLuan;
                    utilitiesObject.viewBinhLuan(dataView);
                    break;
            }
        }

    }
}
