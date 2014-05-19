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
    public partial class ClientForm : Form
    {
        Utilities utilitiesObject;
        public ClientForm()
        {
            InitializeComponent();
            utilitiesObject = new Utilities("DATA SOURCE=ORCL;USER ID=Client;Password=Nhom3");
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            lbUsername.Text = "Welcome " + Program.username;
            //utilitiesObject.viewTranDau(
        }
    }
}
