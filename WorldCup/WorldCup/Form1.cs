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
using Oracle.DataAccess.Client;
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
            string oradb = "DATA SOURCE=ORCL;USER ID=HR;Password=Nhom3";
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();

            OracleCommand cmd = new OracleCommand("viewTaiKhoan", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();

            //OracleParameter in_id = new OracleParameter();
            //in_id.OracleDbType = OracleDbType.Varchar2;
            //in_id.Direction = ParameterDirection.Input;
            //in_id.Value = "DT001";
            //cmd.Parameters.Add(in_id);

            OracleParameter out_cusor = new OracleParameter();
            out_cusor.OracleDbType = OracleDbType.RefCursor;
            out_cusor.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(out_cusor);

            OracleDataAdapter ad = new OracleDataAdapter(cmd);
            ad.Fill(ds);
            dg1.DataSource = ds.Tables[0];
            conn.Clone();
            conn.Dispose();
        }
    } 
}
