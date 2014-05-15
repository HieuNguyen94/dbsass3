using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WorldCup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // This section is written by HieuNguyen94
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = "DATA SOURCE=<ORCL>;PERSIST SECURITY INFO=True;USER ID=HR;Password=Nhom3";
            OleDbCommand cmd = new OleDbCommand("select * from cau_thu", connection);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            connection.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "cauthu");
            this.dg1.DataSource = ds.Tables["cauthu"];
            connection.Close();
            // Hieu write here
        }
    } 
}
// Hieumas
