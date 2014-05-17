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
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = "Provider=OraOLEDB.Oracle.1;Data Source=orcl;User ID=hr;Password=Nhom3";
            OleDbCommand cmd =  new OleDbCommand("select * from cau_thu", connection);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            connection.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "cauthu");
            this.dg1.DataSource = ds.Tables["cauthu"];
            connection.Close();
        }
    } 
}
