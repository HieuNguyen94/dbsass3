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
        private int SelectedTable;

        public ReporterForm()
        {
            InitializeComponent();
            SelectedTable = 0;
        }

        private void ReporterForm_Load(object sender, EventArgs e)
        {
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            SelectedTable = TableList.SelectedIndex;
            switch (SelectedTable)
            {
                case 0:
                    utilitiesObject.viewTranDau(dataView);
                    break;
                case 1:
                    utilitiesObject.viewPhatThe(dataView);
                    break;
                case 2:
                    utilitiesObject.viewBanThang(dataView);
                    break;
                case 3:
                    utilitiesObject.viewChonCauThuXuatSac(dataView);
                    break;
                case 4:
                    utilitiesObject.viewThayNguoi(dataView);
                    break;
                case 5:
                    utilitiesObject.viewLuanLuu(dataView);
                    break;
                case 6:
                    utilitiesObject.viewDeoBangDoiTruong(dataView);
                    break;
                case 7:
                    utilitiesObject.viewDoiHinhXuatPhat(dataView);
                    break;
                case 8:
                    utilitiesObject.viewBinhLuan(dataView);
                    break;
            }
        }
    }
}
