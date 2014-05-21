using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.Data;
using System.IO;
using System.Drawing;
using Oracle.DataAccess.Types;
namespace WorldCup
{
    public class Utilities
    {
    
        private OracleConnection conn;
        private OracleCommand cmd;
        private OracleDataAdapter da;
        private OracleCommandBuilder cb;
        private DataSet ds;

        public Utilities(string connectionString)
        {
            conn = new OracleConnection(connectionString);
        }
        /* Ham validAccount dung de kiem tra xem tai khoan nguoi dung nhap vao co ton tai hay khong
         * Neu co return true
         * Nguoc lai return false
         */
        public bool foundAccount(string iusername, string password, string loai)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd = new OracleCommand("isValidAccount", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_username = new OracleParameter();
            in_username.OracleDbType = OracleDbType.Varchar2;
            in_username.Direction = ParameterDirection.Input;
            in_username.Value = iusername;
            cmd.Parameters.Add(in_username);

            OracleParameter in_password = new OracleParameter();
            in_password.OracleDbType = OracleDbType.Varchar2;
            in_password.Direction = ParameterDirection.Input;
            in_password.Value = password;
            cmd.Parameters.Add(in_password);

            OracleParameter in_loai = new OracleParameter();
            in_loai.OracleDbType = OracleDbType.Varchar2;
            in_loai.Direction = ParameterDirection.Input;
            in_loai.Value = loai;
            cmd.Parameters.Add(in_loai);

            OracleParameter flag = new OracleParameter();
            flag.OracleDbType = OracleDbType.Int16;
            flag.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(flag);

            cmd.ExecuteNonQuery();
            if (cmd.Parameters[3].Value.ToString() == "1")
                return true;
            else return false;

            conn.Close();
            conn.Dispose();
        }
        #region TEAMMANAGER
        public int choose_team(string name)
        {
            int i;
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd = new OracleCommand("hr.quan_ly", conn);
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
            //conn.Close();
            //conn.Dispose();
            return i;
        }

        public string c_time(string name)
        {
            cmd = new OracleCommand("hr.champ_t", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_name = new OracleParameter();
            in_name.OracleDbType = OracleDbType.Varchar2;
            in_name.Direction = ParameterDirection.Input;
            in_name.Value = name;
            cmd.Parameters.Add(in_name);

            OracleParameter num = new OracleParameter();
            num.OracleDbType = OracleDbType.Int16;
            num.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(num);

            cmd.ExecuteNonQuery();
            return cmd.Parameters[1].Value.ToString();
        }

        public OracleCommand view_ct(string name)
        {
            cmd = new OracleCommand("hr.view_ct", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter p_name = new OracleParameter();
            p_name.OracleDbType = OracleDbType.Varchar2;
            p_name.Direction = ParameterDirection.Input;
            p_name.Value = name;
            cmd.Parameters.Add(p_name);

            OracleParameter b_day = new OracleParameter();
            b_day.OracleDbType = OracleDbType.Date;
            b_day.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(b_day);
           
            OracleParameter num = new OracleParameter();
            num.OracleDbType = OracleDbType.Int16;
            num.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(num);

            OracleParameter pos = new OracleParameter();
            pos.OracleDbType = OracleDbType.Varchar2;
            pos.Direction = ParameterDirection.Output;
            pos.Size = 4000;
            cmd.Parameters.Add(pos);

            OracleParameter m_num = new OracleParameter();
            m_num.OracleDbType = OracleDbType.Int16;
            m_num.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(m_num);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return cmd;
        }

        public string v_team(string name)
        {
            cmd = new OracleCommand("hr.v_team", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_name = new OracleParameter();
            in_name.OracleDbType = OracleDbType.Varchar2;
            in_name.Direction = ParameterDirection.Input;
            in_name.Value = name;
            cmd.Parameters.Add(in_name);

            OracleParameter hlv = new OracleParameter();
            hlv.OracleDbType = OracleDbType.Varchar2;
            hlv.Direction = ParameterDirection.Output;
            hlv.Size = 4000;
            cmd.Parameters.Add(hlv);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return cmd.Parameters[1].Value.ToString();
        }

        public string v_team_for(string name)
        {
            cmd = new OracleCommand("hr.v_team_for", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_name = new OracleParameter();
            in_name.OracleDbType = OracleDbType.Varchar2;
            in_name.Direction = ParameterDirection.Input;
            in_name.Value = name;
            cmd.Parameters.Add(in_name);

            OracleParameter dh = new OracleParameter();
            dh.OracleDbType = OracleDbType.Varchar2;
            dh.Direction = ParameterDirection.Output;
            dh.Size = 4000;
            cmd.Parameters.Add(dh);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return cmd.Parameters[1].Value.ToString();
        }

        public void v_dt_thamdu(string name, DataGridView dgv)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd = new OracleCommand("hr.v_dt_thamdu", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter in_name = new OracleParameter();
                in_name.OracleDbType = OracleDbType.Varchar2;
                in_name.Direction = ParameterDirection.Input;
                in_name.Value = name;
                cmd.Parameters.Add(in_name);

                OracleParameter cur = new OracleParameter();
                cur.OracleDbType = OracleDbType.RefCursor;
                cur.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(cur);

                da = new OracleDataAdapter(cmd);
                da.DeleteCommand = getDeleteTeam();
                da.InsertCommand = getInsertTeam();
                da.UpdateCommand = getUpdateTeam();

                cb = new OracleCommandBuilder(da);
                ds = new DataSet();

                da.Fill(ds);
                dgv.DataSource = ds.Tables[0];
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void captain(string name, DataGridView dgv)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd = new OracleCommand("hr.captain", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter in_name = new OracleParameter();
                in_name.OracleDbType = OracleDbType.Varchar2;
                in_name.Direction = ParameterDirection.Input;
                in_name.Value = name;
                cmd.Parameters.Add(in_name);

                OracleParameter cur = new OracleParameter();
                cur.OracleDbType = OracleDbType.RefCursor;
                cur.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(cur);

                da = new OracleDataAdapter(cmd);
                da.DeleteCommand = getDeleteCap();
                da.InsertCommand = getInsertCap();
                da.UpdateCommand = getUpdateCap();

                cb = new OracleCommandBuilder(da);
                ds = new DataSet();

                da.Fill(ds);
                dgv.DataSource = ds.Tables[0];
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void trandau(string name, DataGridView dgv)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd = new OracleCommand("hr.trandau", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter in_name = new OracleParameter();
                in_name.OracleDbType = OracleDbType.Varchar2;
                in_name.Direction = ParameterDirection.Input;
                in_name.Value = name;
                cmd.Parameters.Add(in_name);

                OracleParameter cur = new OracleParameter();
                cur.OracleDbType = OracleDbType.RefCursor;
                cur.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(cur);

                da = new OracleDataAdapter(cmd);
                da.DeleteCommand = getDeleteMatch();
                da.InsertCommand = getInsertMatch();
                da.UpdateCommand = getUpdateMatch();

                cb = new OracleCommandBuilder(da);
                ds = new DataSet();

                da.Fill(ds);
                dgv.DataSource = ds.Tables[0];
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private OracleCommand getDeleteTeam()
        {
            OracleCommand cmd = new OracleCommand("hr.deleteTeam", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter id_dt = new OracleParameter();
            id_dt.SourceColumn = "ID_DOI_TUYEN";
            id_dt.OracleDbType = OracleDbType.Varchar2;
            id_dt.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(id_dt);

            OracleParameter y = new OracleParameter();
            y.SourceColumn = "NAM";
            y.OracleDbType = OracleDbType.Int16;
            y.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(y);

            return cmd;
        }

        public void updateTeam()
        {
            try
            {
                da.Update(ds.Tables[0]);
                MessageBox.Show("Success", "Information", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid value");
            }
        }

        public OracleCommand getDeleteCap()
        {
            OracleCommand cmd = new OracleCommand("hr.deleteCap", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter id_ct = new OracleParameter();
            id_ct.SourceColumn = "ID_CAU_THU";
            id_ct.OracleDbType = OracleDbType.Varchar2;
            id_ct.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(id_ct);

            OracleParameter id_dt = new OracleParameter();
            id_dt.SourceColumn = "ID_DOI_TUYEN";
            id_dt.OracleDbType = OracleDbType.TimeStamp;
            id_dt.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(id_dt);

            OracleParameter st = new OracleParameter();
            st.SourceColumn = "BAT_DAU";
            st.OracleDbType = OracleDbType.TimeStamp;
            st.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(st);

            OracleParameter fi = new OracleParameter();
            fi.SourceColumn = "KET_THUC";
            fi.OracleDbType = OracleDbType.TimeStamp;
            fi.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(fi);

            return cmd;
        }

        public OracleCommand getDeleteMatch()
        {
            OracleCommand cmd = new OracleCommand("hr.deleteMatch", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter id = new OracleParameter();
            id.SourceColumn = "ID";
            id.OracleDbType = OracleDbType.Varchar2;
            id.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(id);

            return cmd;
        }

        private OracleCommand getInsertTeam()
        {
            OracleCommand cmd = new OracleCommand("hr.insertTeam", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter id = new OracleParameter();
            id.SourceColumn = "ID_DOI_TUYEN";
            id.OracleDbType = OracleDbType.Varchar2;
            id.Direction = ParameterDirection.Input;
            id.IsNullable = true;
            cmd.Parameters.Add(id);

            OracleParameter nam = new OracleParameter();
            nam.SourceColumn = "NAM";
            nam.OracleDbType = OracleDbType.Int16;
            nam.Direction = ParameterDirection.Input;
            nam.IsNullable = true;
            cmd.Parameters.Add(nam);

            OracleParameter ao_1 = new OracleParameter();
            ao_1.SourceColumn = "AO_1";
            ao_1.OracleDbType = OracleDbType.Varchar2;
            ao_1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(ao_1);

            OracleParameter ao_2 = new OracleParameter();
            ao_2.SourceColumn = "AO_2";
            ao_2.OracleDbType = OracleDbType.Varchar2;
            ao_2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(ao_2);

            OracleParameter id_dh = new OracleParameter();
            id_dh.SourceColumn = "ID_DOI_HINH";
            id_dh.OracleDbType = OracleDbType.Varchar2;
            id_dh.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(id_dh);



            return cmd;
        }

        private OracleCommand getInsertMatch()
        {
            OracleCommand cmd = new OracleCommand("hr.insertMatch", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter id = new OracleParameter();
            id.SourceColumn = "ID";
            id.OracleDbType = OracleDbType.Varchar2;
            id.Direction = ParameterDirection.Input;
            id.IsNullable = true;
            cmd.Parameters.Add(id);

            OracleParameter loai = new OracleParameter();
            loai.SourceColumn = "LOAI_TRAN_DAU";
            loai.OracleDbType = OracleDbType.Varchar2;
            loai.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(loai);

            OracleParameter st = new OracleParameter();
            st.SourceColumn = "THOI_DIEM_BAT_DAU";
            st.OracleDbType = OracleDbType.TimeStamp;
            st.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(st);

            OracleParameter fi = new OracleParameter();
            fi.SourceColumn = "THOI_DIEM_KET_THUC";
            fi.OracleDbType = OracleDbType.TimeStamp;
            fi.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(fi);

            OracleParameter svd = new OracleParameter();
            svd.SourceColumn = "ID_SAN_VAN_DONG";
            svd.OracleDbType = OracleDbType.Varchar2;
            svd.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(svd);

            OracleParameter ma = new OracleParameter();
            ma.SourceColumn = "TI_SO_HIEP_CHINH";
            ma.OracleDbType = OracleDbType.Varchar2;
            ma.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(ma);

            OracleParameter ex = new OracleParameter();
            ex.SourceColumn = "TI_SO_HIEP_PHU";
            ex.OracleDbType = OracleDbType.Varchar2;
            ex.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(ex);

            OracleParameter pen = new OracleParameter();
            pen.SourceColumn = "TI_SO_LUAN_LUU";
            pen.OracleDbType = OracleDbType.Varchar2;
            pen.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(pen);

            OracleParameter id_dt1 = new OracleParameter();
            id_dt1.SourceColumn = "ID_DOI_TUYEN_1";
            id_dt1.OracleDbType = OracleDbType.Varchar2;
            id_dt1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(id_dt1);

            OracleParameter id_dh1 = new OracleParameter();
            id_dh1.SourceColumn = "ID_DOI_HINH_1";
            id_dh1.OracleDbType = OracleDbType.Varchar2;
            id_dh1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(id_dh1);

            OracleParameter id_dt2 = new OracleParameter();
            id_dt2.SourceColumn = "ID_DOI_TUYEN_2";
            id_dt2.OracleDbType = OracleDbType.Varchar2;
            id_dt2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(id_dt2);

            OracleParameter id_dh2 = new OracleParameter();
            id_dh2.SourceColumn = "ID_DOI_HINH_2";
            id_dh2.OracleDbType = OracleDbType.Varchar2;
            id_dh2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(id_dh2);

            return cmd;
        }

        private OracleCommand getInsertCap()
        {
            OracleCommand cmd = new OracleCommand("hr.insertCap", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter id1 = new OracleParameter();
            id1.SourceColumn = "ID_CAU_THU";
            id1.OracleDbType = OracleDbType.Varchar2;
            id1.Direction = ParameterDirection.Input;
            id1.IsNullable = true;
            cmd.Parameters.Add(id1);

            OracleParameter id2 = new OracleParameter();
            id2.SourceColumn = "ID_DOI_TUYEN";
            id2.OracleDbType = OracleDbType.Varchar2;
            id2.Direction = ParameterDirection.Input;
            id2.IsNullable = true;
            cmd.Parameters.Add(id2);

            OracleParameter st = new OracleParameter();
            st.SourceColumn = "BAT_DAU";
            st.OracleDbType = OracleDbType.Date;
            st.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(st);

            OracleParameter fi = new OracleParameter();
            fi.SourceColumn = "KET_THUC";
            fi.OracleDbType = OracleDbType.Date;
            fi.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(fi);

            return cmd;
        }

        private OracleCommand getUpdateTeam()
        {
            OracleCommand cmd = new OracleCommand("hr.updateTeam", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter old_id = new OracleParameter();
            old_id.SourceVersion = DataRowVersion.Original;
            old_id.SourceColumn = "ID_DOI_TUYEN";
            old_id.OracleDbType = OracleDbType.Varchar2;
            old_id.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(old_id);

            OracleParameter old_nam = new OracleParameter();
            old_nam.SourceVersion = DataRowVersion.Original;
            old_nam.SourceColumn = "NAM";
            old_nam.OracleDbType = OracleDbType.Int16;
            old_nam.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(old_nam);

            OracleParameter id = new OracleParameter();
            id.SourceColumn = "ID_DOI_TUYEN";
            id.OracleDbType = OracleDbType.Varchar2;
            id.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(id);

            OracleParameter nam = new OracleParameter();
            nam.SourceColumn = "NAM";
            nam.OracleDbType = OracleDbType.Int16;
            nam.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(nam);

            OracleParameter ao_1 = new OracleParameter();
            ao_1.SourceColumn = "AO_1";
            ao_1.OracleDbType = OracleDbType.Varchar2;
            ao_1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(ao_1);

            OracleParameter ao_2 = new OracleParameter();
            ao_2.SourceColumn = "AO_2";
            ao_2.OracleDbType = OracleDbType.Varchar2;
            ao_2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(ao_2);

            OracleParameter id_dh = new OracleParameter();
            id_dh.SourceColumn = "ID_DOI_HINH";
            id_dh.OracleDbType = OracleDbType.Varchar2;
            id_dh.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(id_dh);



            return cmd;
        }

        private OracleCommand getUpdateMatch()
        {
            OracleCommand cmd = new OracleCommand("hr.updateMatch", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter old_id = new OracleParameter();
            old_id.SourceVersion = DataRowVersion.Original;
            old_id.SourceColumn = "ID";
            old_id.OracleDbType = OracleDbType.Varchar2;
            old_id.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(old_id);

            OracleParameter id = new OracleParameter();
            id.SourceColumn = "ID";
            id.OracleDbType = OracleDbType.Varchar2;
            id.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(id);

            OracleParameter loai = new OracleParameter();
            loai.SourceColumn = "LOAI_TRAN_DAU";
            loai.OracleDbType = OracleDbType.Varchar2;
            loai.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(loai);

            OracleParameter st = new OracleParameter();
            st.SourceColumn = "THOI_DIEM_BAT_DAU";
            st.OracleDbType = OracleDbType.TimeStamp;
            st.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(st);

            OracleParameter fi = new OracleParameter();
            fi.SourceColumn = "THOI_DIEM_KET_THUC";
            fi.OracleDbType = OracleDbType.TimeStamp;
            fi.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(fi);

            OracleParameter svd = new OracleParameter();
            svd.SourceColumn = "ID_SAN_VAN_DONG";
            svd.OracleDbType = OracleDbType.Varchar2;
            svd.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(svd);

            OracleParameter ma = new OracleParameter();
            ma.SourceColumn = "TI_SO_HIEP_CHINH";
            ma.OracleDbType = OracleDbType.Varchar2;
            ma.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(ma);

            OracleParameter ex = new OracleParameter();
            ex.SourceColumn = "TI_SO_HIEP_PHU";
            ex.OracleDbType = OracleDbType.Varchar2;
            ex.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(ex);

            OracleParameter pen = new OracleParameter();
            pen.SourceColumn = "TI_SO_LUAN_LUU";
            pen.OracleDbType = OracleDbType.Varchar2;
            pen.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(pen);

            OracleParameter id_dt1 = new OracleParameter();
            id_dt1.SourceColumn = "ID_DOI_TUYEN_1";
            id_dt1.OracleDbType = OracleDbType.Varchar2;
            id_dt1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(id_dt1);

            OracleParameter id_dh1 = new OracleParameter();
            id_dh1.SourceColumn = "ID_DOI_HINH_1";
            id_dh1.OracleDbType = OracleDbType.Varchar2;
            id_dh1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(id_dh1);

            OracleParameter id_dt2 = new OracleParameter();
            id_dt2.SourceColumn = "ID_DOI_TUYEN_2";
            id_dt2.OracleDbType = OracleDbType.Varchar2;
            id_dt2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(id_dt2);

            OracleParameter id_dh2 = new OracleParameter();
            id_dh2.SourceColumn = "ID_DOI_HINH_2";
            id_dh2.OracleDbType = OracleDbType.Varchar2;
            id_dh2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(id_dh2);

            return cmd;
        }

        private OracleCommand getUpdateCap()
        {
            OracleCommand cmd = new OracleCommand("hr.updateCap", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter old_id1 = new OracleParameter();
            old_id1.SourceVersion = DataRowVersion.Original;
            old_id1.SourceColumn = "ID_CAU_THU";
            old_id1.OracleDbType = OracleDbType.Varchar2;
            old_id1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(old_id1);

            OracleParameter old_id2 = new OracleParameter();
            old_id2.SourceVersion = DataRowVersion.Original;
            old_id2.SourceColumn = "ID_DOI_TUYEN";
            old_id2.OracleDbType = OracleDbType.Varchar2;
            old_id2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(old_id2);

            OracleParameter old_st = new OracleParameter();
            old_st.SourceVersion = DataRowVersion.Original;
            old_st.SourceColumn = "BAT_DAU";
            old_st.OracleDbType = OracleDbType.Date;
            old_st.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(old_st);

            OracleParameter old_fi = new OracleParameter();
            old_fi.SourceVersion = DataRowVersion.Original;
            old_fi.SourceColumn = "KET_THUC";
            old_fi.OracleDbType = OracleDbType.Date;
            old_fi.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(old_fi);

            OracleParameter id1 = new OracleParameter();
            id1.SourceColumn = "ID_CAU_THU";
            id1.OracleDbType = OracleDbType.Varchar2;
            id1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(id1);

            OracleParameter id2 = new OracleParameter();
            id2.SourceColumn = "ID_DOI_TUYEN";
            id2.OracleDbType = OracleDbType.Varchar2;
            id2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(id2);

            OracleParameter st = new OracleParameter();
            st.SourceColumn = "BAT_DAU";
            st.OracleDbType = OracleDbType.Date;
            st.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(st);

            OracleParameter fi = new OracleParameter();
            fi.SourceColumn = "KET_THUC";
            fi.OracleDbType = OracleDbType.Date;
            fi.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(fi);

            return cmd;
        }

        public void show_flag(string name, Button b)
        {
            cmd = new OracleCommand("hr.show_country_flag", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter c_name = new OracleParameter();
            c_name.OracleDbType = OracleDbType.Varchar2;
            c_name.Direction = ParameterDirection.Input;
            c_name.Value = name;
            cmd.Parameters.Add(c_name);

            OracleParameter c_flag = new OracleParameter();
            c_flag.OracleDbType = OracleDbType.Blob;
            c_flag.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(c_flag);
            try
            {
                cmd.ExecuteReader();

                OracleBlob ob = (OracleBlob)cmd.Parameters[1].Value;
                Byte[] byteBLOBData = ob.Value;
                MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                b.BackgroundImage = Image.FromStream(stmBLOBData);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void update_ct(string old_name, int old_match, string name, string pos, int num, int match)
        {
            OracleCommand cmd = new OracleCommand("hr.update_ct", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter _old_name = new OracleParameter();
            _old_name.SourceVersion = DataRowVersion.Original;
            _old_name.SourceColumn = "HO_TEN";
            _old_name.OracleDbType = OracleDbType.Varchar2;
            _old_name.Direction = ParameterDirection.Input;
            _old_name.Value = old_name;
            cmd.Parameters.Add(_old_name);

            OracleParameter _old_match = new OracleParameter();
            _old_match.SourceVersion = DataRowVersion.Original;
            _old_match.SourceColumn = "SO_TRAN_DOI_TUYEN_QUOC_GIA";
            _old_match.OracleDbType = OracleDbType.Int16;
            _old_match.Direction = ParameterDirection.Input;
            _old_match.Value = old_match;
            cmd.Parameters.Add(_old_match);

            //OracleParameter _b_day = new OracleParameter();
            //_b_day.OracleDbType = OracleDbType.Date;
            //_b_day.Direction = ParameterDirection.Input;
            //_b_day.Value = b_day;
            //cmd.Parameters.Add(_b_day);

            OracleParameter _name = new OracleParameter();
            _name.SourceColumn = "HO_TEN";
            _name.OracleDbType = OracleDbType.Varchar2;
            _name.Direction = ParameterDirection.Input;
            _name.Value = _name;
            cmd.Parameters.Add(_name);

            OracleParameter _pos = new OracleParameter();
            _pos.OracleDbType = OracleDbType.Varchar2;
            _pos.SourceColumn = "VI_TRI_SO_TRUONG";
            _pos.Direction = ParameterDirection.Input;
            _pos.Value = pos;
            cmd.Parameters.Add(_pos);

            OracleParameter _num = new OracleParameter();
            _num.OracleDbType = OracleDbType.Int16;
            _num.SourceColumn = "SO_AO";
            _num.Direction = ParameterDirection.Input;
            _num.Value = num;
            cmd.Parameters.Add(_num);

            OracleParameter _match = new OracleParameter();
            _match.OracleDbType = OracleDbType.Int16;
            _match.SourceColumn = "SO_TRAN_DOI_TUYEN_QUOC_GIA";
            _match.Direction = ParameterDirection.Input;
            _match.Value = match;
            cmd.Parameters.Add(_match);
            try
            {
                da = new OracleDataAdapter();
                da.UpdateCommand = cmd;
                ds = new DataSet();
                cb = new OracleCommandBuilder(da);
                da.Fill(ds);
                da.Update(ds.Tables[0]);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }

#endregion
        # region TAI_KHOAN
        public void viewTaiKhoan(DataGridView dgv)
        {
            try
            { 
                if (conn.State != ConnectionState.Open)
                    conn.Open();
            
                cmd = new OracleCommand("hr.viewTaiKhoan", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter out_cur = new OracleParameter();
                out_cur.OracleDbType = OracleDbType.RefCursor;
                out_cur.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(out_cur);

                da = new OracleDataAdapter(cmd);
                da.InsertCommand = getInsertTaiKhoan();
                da.DeleteCommand = getDeleteTaiKhoan();
                da.UpdateCommand = getUpdateTaiKhoan();

                cb = new OracleCommandBuilder(da);
                ds = new DataSet();

                da.Fill(ds);
                dgv.DataSource = ds.Tables[0];
            } catch (Exception ex)
            {
                MessageBox.Show("Operation failed: " + ex.Message);
            }
        }

        public void updateTaiKhoan()
        {
            try
            {
                da.Update(ds.Tables[0]);
                MessageBox.Show("Success", "Information", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid value");
            }
        }

        private OracleCommand getInsertTaiKhoan()
        {
            OracleCommand cmd = new OracleCommand("hr.insertTaiKhoan", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_username = new OracleParameter();
            in_username.SourceColumn = "USERNAME";
            in_username.OracleDbType = OracleDbType.Varchar2;
            in_username.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_username);

            OracleParameter in_password = new OracleParameter();
            in_password.SourceColumn = "PASSWORD";
            in_password.OracleDbType = OracleDbType.Varchar2;
            in_password.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_password);

            OracleParameter in_loai_tai_khoan = new OracleParameter();
            in_loai_tai_khoan.SourceColumn = "LOAI_TAI_KHOAN";
            in_loai_tai_khoan.OracleDbType = OracleDbType.Varchar2;
            in_loai_tai_khoan.Direction = ParameterDirection.Input;
            in_loai_tai_khoan.IsNullable = true;
            cmd.Parameters.Add(in_loai_tai_khoan);

            return cmd;
        }

        private OracleCommand getDeleteTaiKhoan()
        {
            OracleCommand cmd = new OracleCommand("hr.deleteTaiKhoan", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_username = new OracleParameter();
            in_username.SourceColumn = "USERNAME";
            in_username.OracleDbType = OracleDbType.Varchar2;
            in_username.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_username);

            return cmd;
        }

        private OracleCommand getUpdateTaiKhoan()
        {
            OracleCommand cmd = new OracleCommand("hr.updateTaiKhoan", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_old_username = new OracleParameter();
            in_old_username.SourceVersion = DataRowVersion.Original;
            in_old_username.SourceColumn = "USERNAME";
            in_old_username.OracleDbType = OracleDbType.Varchar2;
            in_old_username.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_old_username);

            OracleParameter in_username = new OracleParameter();
            in_username.SourceColumn = "USERNAME";
            in_username.OracleDbType = OracleDbType.Varchar2;
            in_username.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_username);

            OracleParameter in_password = new OracleParameter();
            in_password.SourceColumn = "PASSWORD";
            in_password.OracleDbType = OracleDbType.Varchar2;
            in_password.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_password);

            OracleParameter in_loai_tai_khoan = new OracleParameter();
            in_loai_tai_khoan.SourceColumn = "LOAI_TAI_KHOAN";
            in_loai_tai_khoan.OracleDbType = OracleDbType.Varchar2;
            in_loai_tai_khoan.Direction = ParameterDirection.Input;
            in_loai_tai_khoan.IsNullable = true;
            cmd.Parameters.Add(in_loai_tai_khoan);

            return cmd;
        }
        #endregion

        #region WORLD_CUP
        public void viewWorldCup(DataGridView dgv)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd = new OracleCommand("hr.viewWorldCup", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter out_cur = new OracleParameter();
                out_cur.OracleDbType = OracleDbType.RefCursor;
                out_cur.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(out_cur);

                da = new OracleDataAdapter(cmd);
                da.InsertCommand = getInsertWorldCup();
                da.DeleteCommand = getDeleteWorldCup();
                da.UpdateCommand = getUpdateWorldCup();

                cb = new OracleCommandBuilder(da);
                ds = new DataSet();

                da.Fill(ds);
                dgv.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Operation failed: " + ex.Message);
            }
        }

        public void updateWorldCup()
        {
            try
            {
                da.Update(ds.Tables[0]);
                MessageBox.Show("Success", "Information", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid value");
            }
        }

        private OracleCommand getInsertWorldCup()
        {
            OracleCommand cmd = new OracleCommand("hr.insertWorldCup", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_nam = new OracleParameter();
            in_nam.SourceColumn = "NAM";
            in_nam.OracleDbType = OracleDbType.Int32;
            in_nam.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_nam);

            OracleParameter in_so_doi = new OracleParameter();
            in_so_doi.SourceColumn = "SO_DOI";
            in_so_doi.OracleDbType = OracleDbType.Int32;
            in_so_doi.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_so_doi);

            OracleParameter in_id_cau_thu_xuat_sac_nhat = new OracleParameter();
            in_id_cau_thu_xuat_sac_nhat.SourceColumn = "ID_CAU_THU_XUAT_SAC_NHAT";
            in_id_cau_thu_xuat_sac_nhat.OracleDbType = OracleDbType.Varchar2;
            in_id_cau_thu_xuat_sac_nhat.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_cau_thu_xuat_sac_nhat);

            OracleParameter in_id_doi_vo_dich = new OracleParameter();
            in_id_doi_vo_dich.SourceColumn = "ID_DOI_VO_DICH";
            in_id_doi_vo_dich.OracleDbType = OracleDbType.Varchar2;
            in_id_doi_vo_dich.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_doi_vo_dich);

            OracleParameter in_id_doi_a_quan = new OracleParameter();
            in_id_doi_a_quan.SourceColumn = "ID_DOI_A_QUAN";
            in_id_doi_a_quan.OracleDbType = OracleDbType.Varchar2;
            in_id_doi_a_quan.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_doi_a_quan);

            OracleParameter in_id_doi_hang_3 = new OracleParameter();
            in_id_doi_hang_3.SourceColumn = "ID_DOI_HANG_3";
            in_id_doi_hang_3.OracleDbType = OracleDbType.Varchar2;
            in_id_doi_hang_3.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_doi_hang_3);

            return cmd;
        }

        private OracleCommand getDeleteWorldCup()
        {
            OracleCommand cmd = new OracleCommand("hr.deleteWorldCup", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_nam = new OracleParameter();
            in_nam.SourceColumn = "NAM";
            in_nam.OracleDbType = OracleDbType.Varchar2;
            in_nam.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_nam);

            return cmd;
        }

        private OracleCommand getUpdateWorldCup()
        {
            OracleCommand cmd = new OracleCommand("hr.updateWorldCup", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_old_nam = new OracleParameter();
            in_old_nam.SourceVersion = DataRowVersion.Original;
            in_old_nam.SourceColumn = "NAM";
            in_old_nam.OracleDbType = OracleDbType.Varchar2;
            in_old_nam.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_old_nam);

            OracleParameter in_nam = new OracleParameter();
            in_nam.SourceColumn = "NAM";
            in_nam.OracleDbType = OracleDbType.Int32;
            in_nam.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_nam);

            OracleParameter in_so_doi = new OracleParameter();
            in_so_doi.SourceColumn = "SO_DOI";
            in_so_doi.OracleDbType = OracleDbType.Int32;
            in_so_doi.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_so_doi);

            OracleParameter in_id_cau_thu_xuat_sac_nhat = new OracleParameter();
            in_id_cau_thu_xuat_sac_nhat.SourceColumn = "ID_CAU_THU_XUAT_SAC_NHAT";
            in_id_cau_thu_xuat_sac_nhat.OracleDbType = OracleDbType.Varchar2;
            in_id_cau_thu_xuat_sac_nhat.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_cau_thu_xuat_sac_nhat);

            OracleParameter in_id_doi_vo_dich = new OracleParameter();
            in_id_doi_vo_dich.SourceColumn = "ID_DOI_VO_DICH";
            in_id_doi_vo_dich.OracleDbType = OracleDbType.Varchar2;
            in_id_doi_vo_dich.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_doi_vo_dich);

            OracleParameter in_id_doi_a_quan = new OracleParameter();
            in_id_doi_a_quan.SourceColumn = "ID_DOI_A_QUAN";
            in_id_doi_a_quan.OracleDbType = OracleDbType.Varchar2;
            in_id_doi_a_quan.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_doi_a_quan);

            OracleParameter in_id_doi_hang_3 = new OracleParameter();
            in_id_doi_hang_3.SourceColumn = "ID_DOI_HANG_3";
            in_id_doi_hang_3.OracleDbType = OracleDbType.Varchar2;
            in_id_doi_hang_3.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_doi_hang_3);

            return cmd;
        }
        #endregion

        #region QUAN_LY_DOI_BONG
        public void viewQuanLyDoiBong(DataGridView dgv)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd = new OracleCommand("hr.viewQuanLyDoiBong", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter out_cur = new OracleParameter();
                out_cur.OracleDbType = OracleDbType.RefCursor;
                out_cur.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(out_cur);

                da = new OracleDataAdapter(cmd);
                da.InsertCommand = getInsertQuanLyDoiBong();
                da.DeleteCommand = getDeleteQuanLyDoiBong();
                da.UpdateCommand = getUpdateQuanLyDoiBong();

                cb = new OracleCommandBuilder(da);
                ds = new DataSet();

                da.Fill(ds);
                dgv.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Operation failed: " + ex.Message);
            }
        }

        public void updateQuanLyDoiBong()
        {
            try
            {
                da.Update(ds.Tables[0]);
                MessageBox.Show("Success", "Information", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid value");
            }
        }

        private OracleCommand getInsertQuanLyDoiBong()
        {
            OracleCommand cmd = new OracleCommand("hr.insertQuanLyDoiBong", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_username = new OracleParameter();
            in_username.SourceColumn = "USERNAME";
            in_username.OracleDbType = OracleDbType.Varchar2;
            in_username.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_username);

            OracleParameter in_id_doi_tuyen = new OracleParameter();
            in_id_doi_tuyen.SourceColumn = "ID_DOI_TUYEN";
            in_id_doi_tuyen.OracleDbType = OracleDbType.Varchar2;
            in_id_doi_tuyen.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_doi_tuyen);

            return cmd;
        }

        private OracleCommand getDeleteQuanLyDoiBong()
        {
            OracleCommand cmd = new OracleCommand("hr.deleteQuanLyDoiBong", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_username = new OracleParameter();
            in_username.SourceColumn = "USERNAME";
            in_username.OracleDbType = OracleDbType.Varchar2;
            in_username.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_username);

            OracleParameter in_id_doi_tuyen = new OracleParameter();
            in_id_doi_tuyen.SourceColumn = "ID_DOI_TUYEN";
            in_id_doi_tuyen.OracleDbType = OracleDbType.Varchar2;
            in_id_doi_tuyen.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_doi_tuyen);

            return cmd;
        }

        private OracleCommand getUpdateQuanLyDoiBong()
        {
            OracleCommand cmd = new OracleCommand("hr.updateQuanLyDoiBong", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_old_username = new OracleParameter();
            in_old_username.SourceVersion = DataRowVersion.Original;
            in_old_username.SourceColumn = "USERNAME";
            in_old_username.OracleDbType = OracleDbType.Varchar2;
            in_old_username.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_old_username);

            OracleParameter in_old_id_doi_tuyen = new OracleParameter();
            in_old_id_doi_tuyen.SourceVersion = DataRowVersion.Original;
            in_old_id_doi_tuyen.SourceColumn = "ID_DOI_TUYEN";
            in_old_id_doi_tuyen.OracleDbType = OracleDbType.Varchar2;
            in_old_id_doi_tuyen.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_old_id_doi_tuyen);

            OracleParameter in_username = new OracleParameter();
            in_username.SourceColumn = "USERNAME";
            in_username.OracleDbType = OracleDbType.Varchar2;
            in_username.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_username);

            OracleParameter in_id_doi_tuyen = new OracleParameter();
            in_id_doi_tuyen.SourceColumn = "ID_DOI_TUYEN";
            in_id_doi_tuyen.OracleDbType = OracleDbType.Varchar2;
            in_id_doi_tuyen.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_doi_tuyen);

            return cmd;
        }
        #endregion

        #region TRAN_DAU
        public void viewTranDau(DataGridView dgv)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd = new OracleCommand("hr.viewTranDau", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter out_cur = new OracleParameter();
                out_cur.OracleDbType = OracleDbType.RefCursor;
                out_cur.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(out_cur);

                da = new OracleDataAdapter(cmd);
                da.InsertCommand = getInsertTranDau();
                da.DeleteCommand = getDeleteTranDau();
                da.UpdateCommand = getUpdateTranDau();

                cb = new OracleCommandBuilder(da);
                ds = new DataSet();

                da.Fill(ds);
                dgv.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Operation failed: " + ex.Message);
            }
        }

        private OracleCommand getInsertTranDau()
        {
            OracleCommand cmd = new OracleCommand("hr.insertTranDau", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            /* Write your code here */

            return cmd;
        }

        private OracleCommand getDeleteTranDau()
        {
            OracleCommand cmd = new OracleCommand("hr.deleteTranDau", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            /* Write your code here */


            return cmd;
        }

        private OracleCommand getUpdateTranDau()
        {
            OracleCommand cmd = new OracleCommand("hr.updateTranDau", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            /* Write your code here */


            return cmd;
        }
        #endregion

        #region BINH_LUAN
        
        public void viewBinhLuan(DataGridView dgv)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd = new OracleCommand("hr.viewBinhLuan", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter out_cur = new OracleParameter();
                out_cur.OracleDbType = OracleDbType.RefCursor;
                out_cur.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(out_cur);

                da = new OracleDataAdapter(cmd);
                da.InsertCommand = getInsertBinhLuan();
                da.DeleteCommand = getDeleteBinhLuan();
                da.UpdateCommand = getUpdateBinhLuan();

                cb = new OracleCommandBuilder(da);
                ds = new DataSet();

                da.Fill(ds);
                dgv.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Operation failed: " + ex.Message);
            }
        }

        public void updateBinhLuan()
        {
            try
            {
                da.Update(ds.Tables[0]);
                MessageBox.Show("Success", "Information", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid value");
            }
        }
        private OracleCommand getInsertBinhLuan()
        {
            OracleCommand cmd = new OracleCommand("hr.insertBinhLuan", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_id_tran_dau = new OracleParameter();
            in_id_tran_dau.SourceColumn = "ID_TRAN_DAU";
            in_id_tran_dau.OracleDbType = OracleDbType.Varchar2;
            in_id_tran_dau.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_tran_dau);

            OracleParameter in_username = new OracleParameter();
            in_username.SourceColumn = "USERNAME";
            in_username.OracleDbType = OracleDbType.Varchar2;
            in_username.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_username);

            OracleParameter in_thoi_diem = new OracleParameter();
            in_thoi_diem.SourceColumn = "THOI_DIEM";
            in_thoi_diem.OracleDbType = OracleDbType.TimeStamp;
            in_thoi_diem.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_thoi_diem);

            OracleParameter in_noi_dung = new OracleParameter();
            in_noi_dung.SourceColumn = "NOI_DUNG";
            in_noi_dung.OracleDbType = OracleDbType.Varchar2;
            in_noi_dung.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_noi_dung);

            OracleParameter in_duyet = new OracleParameter();
            in_duyet.SourceColumn = "NOI_DUNG";
            in_duyet.OracleDbType = OracleDbType.Char;
            in_duyet.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_duyet);

            return cmd;
        }

        private OracleCommand getDeleteBinhLuan()
        {
            OracleCommand cmd = new OracleCommand("hr.deleteBinhLuan", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_id_tran_dau = new OracleParameter();
            in_id_tran_dau.SourceColumn = "ID_TRAN_DAU";
            in_id_tran_dau.OracleDbType = OracleDbType.Varchar2;
            in_id_tran_dau.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_tran_dau);

            OracleParameter in_username = new OracleParameter();
            in_username.SourceColumn = "USERNAME";
            in_username.OracleDbType = OracleDbType.Varchar2;
            in_username.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_username);

            OracleParameter in_thoi_diem = new OracleParameter();
            in_thoi_diem.SourceColumn = "THOI_DIEM";
            in_thoi_diem.OracleDbType = OracleDbType.TimeStamp;
            in_thoi_diem.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_thoi_diem);

            return cmd;
        }

        private OracleCommand getUpdateBinhLuan()
        {
            OracleCommand cmd = new OracleCommand("hr.updateBinhLuan", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_old_id_tran_dau = new OracleParameter();
            in_old_id_tran_dau.SourceVersion = DataRowVersion.Original;
            in_old_id_tran_dau.SourceColumn = "ID_TRAN_DAU";
            in_old_id_tran_dau.OracleDbType = OracleDbType.Varchar2;
            in_old_id_tran_dau.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_old_id_tran_dau);

            OracleParameter in_old_username = new OracleParameter();
            in_old_username.SourceVersion = DataRowVersion.Original;
            in_old_username.SourceColumn = "USERNAME";
            in_old_username.OracleDbType = OracleDbType.Varchar2;
            in_old_username.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_old_username);

            OracleParameter in_old_thoi_diem = new OracleParameter();
            in_old_thoi_diem.SourceVersion = DataRowVersion.Original;
            in_old_thoi_diem.SourceColumn = "THOI_DIEM";
            in_old_thoi_diem.OracleDbType = OracleDbType.TimeStamp;
            in_old_thoi_diem.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_old_thoi_diem);

            OracleParameter in_id_tran_dau = new OracleParameter();
            in_id_tran_dau.SourceColumn = "ID_TRAN_DAU";
            in_id_tran_dau.OracleDbType = OracleDbType.Varchar2;
            in_id_tran_dau.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_tran_dau);

            OracleParameter in_username = new OracleParameter();
            in_username.SourceColumn = "USERNAME";
            in_username.OracleDbType = OracleDbType.Varchar2;
            in_username.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_username);

            OracleParameter in_thoi_diem = new OracleParameter();
            in_thoi_diem.SourceColumn = "THOI_DIEM";
            in_thoi_diem.OracleDbType = OracleDbType.TimeStamp;
            in_thoi_diem.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_thoi_diem);

            OracleParameter in_noi_dung = new OracleParameter();
            in_noi_dung.SourceColumn = "NOI_DUNG";
            in_noi_dung.OracleDbType = OracleDbType.Varchar2;
            in_noi_dung.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_noi_dung);

            OracleParameter in_duyet = new OracleParameter();
            in_duyet.SourceColumn = "DUYET";
            in_duyet.OracleDbType = OracleDbType.Varchar2;
            in_duyet.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_duyet);

            return cmd;
        }
        #endregion
    }
}
