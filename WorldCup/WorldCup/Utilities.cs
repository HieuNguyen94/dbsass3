using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.Data;
namespace WorldCup
{
    public class Utilities
    {
        
        
        OracleCommandBuilder cmdbd;
        public void invokeFunctByString(string functName)
        {
            Type type = typeof(Utilities);
            MethodInfo method = type.GetMethod(functName);
            Utilities utilitiesObject = new Utilities();
            method.Invoke(utilitiesObject, null);
        }

        /* Ham nay dung de hien thi Table ra datagridview
         * Truyen vao ten bang table_name giong trong CSDL
         * Ham tra ve ket qua dua tren datagridview truyen vao dgv
         */
        public void viewTable(string table_name, DataGridView dgv)
        {
            string oradb = "DATA SOURCE=ORCL;USER ID=HR;Password=Nhom3";
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();

            DataSet ds = new DataSet();
            OracleCommand cmd = new OracleCommand("viewTable", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            

            OracleParameter in_table_name = new OracleParameter();
            in_table_name.OracleDbType = OracleDbType.Varchar2;
            in_table_name.Direction = ParameterDirection.Input;
            in_table_name.Value = table_name;
            cmd.Parameters.Add(in_table_name);
            
            OracleParameter out_cusor = new OracleParameter();
            out_cusor.OracleDbType = OracleDbType.RefCursor;
            out_cusor.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(out_cusor);

            OracleDataAdapter ad = new OracleDataAdapter(cmd);
            ad.Fill(ds, table_name);
            dgv.DataSource = ds.Tables[0];
            conn.Close();
            conn.Dispose();
        }

        public int choose_team(string name)
        {
            int i;
            OracleConnection conn = new OracleConnection("DATA SOURCE=ORCL;PERSIST SECURITY INFO=True;USER ID=HR;Password=Nhom3");
            conn.Open();

            OracleCommand cmd = new OracleCommand("quan_ly", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter uname = new OracleParameter();
            uname.OracleDbType = OracleDbType.Varchar2;
            uname.Direction = ParameterDirection.Input;
            uname.Value = Program.username;
            cmd.Parameters.Add(uname);

            OracleParameter ten = new OracleParameter();
            ten.OracleDbType = OracleDbType.Varchar2;
            ten.Direction = ParameterDirection.Input;
            ten.Value = name;
            cmd.Parameters.Add(ten);

            OracleParameter flag = new OracleParameter();
            flag.OracleDbType = OracleDbType.Int16;
            flag.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(flag);

            cmd.ExecuteNonQuery();

            if (cmd.Parameters[2].Value.ToString() == "1")
            {
                //MessageBox.Show("Successful");
                i = 1;
            }
            else
            {
                MessageBox.Show("You are not team manager of this team");
                i = 0;
            }
            conn.Close();
            conn.Dispose();
            return i;
        }

        public void update(string parameter)
        {
            
        }
    }
}
