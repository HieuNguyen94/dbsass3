using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.Data;
using System.Diagnostics;
using Oracle.DataAccess.Types;
using System.Drawing;
namespace WorldCup
{
    public class Utilities
    {
    
        private OracleConnection conn;
        private OracleCommand cmd;
        private OracleDataAdapter da;
        private OracleCommandBuilder cb;
        public DataSet ds;

        public DataSet getDataSet
        {
            get { return ds; }
        }

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

        public string update()
        {
            string thongbao = null;
            try
            {
                da.Update(ds.Tables[0]);
                thongbao = "Thực hiện thành công, những thay đổi của bạn đã được lưu lại";
               // MessageBox.Show("Success", "Information", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                thongbao = "Đã có lỗi xảy ra, vui lòng kiểm tra các giá trị nhập và thử lại";
                //MessageBox.Show("Invalid value");
            }
            return thongbao;
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

        public string updateTaiKhoan()
        {
            string thongbao = null;
            try
            {
                da.Update(ds.Tables[0]);
                thongbao = "Thực hiện thành công, những thay đổi của bạn đã được lưu lại";
                //MessageBox.Show("Success", "Information", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                thongbao = "Đã có lỗi xảy ra, vui lòng kiểm tra các giá trị nhập và thử lại";
                //MessageBox.Show("Invalid value");
            }
            return thongbao;
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

        public DataSet getTranDau()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd = new OracleCommand("hr.getTranDau", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter out_cur = new OracleParameter();
                out_cur.OracleDbType = OracleDbType.RefCursor;
                out_cur.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(out_cur);

                da = new OracleDataAdapter(cmd);
                ds = new DataSet();

                da.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Operation failed: " + ex.Message);
            }
            return ds;
        }

        private OracleCommand getInsertTranDau()
        {
            OracleCommand cmd = new OracleCommand("hr.insertTranDau", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_id = new OracleParameter();
            in_id.SourceColumn = "ID";
            in_id.OracleDbType = OracleDbType.Varchar2;
            in_id.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id);

            OracleParameter in_loai_tran_dau = new OracleParameter();
            in_loai_tran_dau.SourceColumn = "LOAI_TRAN_DAU";
            in_loai_tran_dau.OracleDbType = OracleDbType.Varchar2;
            in_loai_tran_dau.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_loai_tran_dau);

            OracleParameter in_thoi_diem_bat_dau = new OracleParameter();
            in_thoi_diem_bat_dau.SourceColumn = "THOI_DIEM_BAT_DAU";
            in_thoi_diem_bat_dau.OracleDbType = OracleDbType.TimeStamp;
            in_thoi_diem_bat_dau.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_thoi_diem_bat_dau);

            OracleParameter in_thoi_diem_ket_thuc = new OracleParameter();
            in_thoi_diem_ket_thuc.SourceColumn = "THOI_DIEM_KET_THUC";
            in_thoi_diem_ket_thuc.OracleDbType = OracleDbType.TimeStamp;
            in_thoi_diem_ket_thuc.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_thoi_diem_ket_thuc);

            OracleParameter in_id_san_van_dong = new OracleParameter();
            in_id_san_van_dong.SourceColumn = "ID_SAN_VAN_DONG";
            in_id_san_van_dong.OracleDbType = OracleDbType.Varchar2;
            in_id_san_van_dong.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_san_van_dong);

            OracleParameter in_ti_so_hiep_chinh = new OracleParameter();
            in_ti_so_hiep_chinh.SourceColumn = "TI_SO_HIEP_CHINH";
            in_ti_so_hiep_chinh.OracleDbType = OracleDbType.Varchar2;
            in_ti_so_hiep_chinh.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_ti_so_hiep_chinh);

            OracleParameter in_ti_so_hiep_phu = new OracleParameter();
            in_ti_so_hiep_phu.SourceColumn = "TI_SO_HIEP_PHU";
            in_ti_so_hiep_phu.OracleDbType = OracleDbType.Varchar2;
            in_ti_so_hiep_phu.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_ti_so_hiep_phu);

            OracleParameter in_ti_so_luan_luu = new OracleParameter();
            in_ti_so_luan_luu.SourceColumn = "TI_SO_LUAN_LUU";
            in_ti_so_luan_luu.OracleDbType = OracleDbType.Varchar2;
            in_ti_so_luan_luu.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_ti_so_luan_luu);

            OracleParameter in_id_doi_tuyen_1 = new OracleParameter();
            in_id_doi_tuyen_1.SourceColumn = "ID_DOI_TUYEN_1";
            in_id_doi_tuyen_1.OracleDbType = OracleDbType.Varchar2;
            in_id_doi_tuyen_1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_doi_tuyen_1);

            OracleParameter in_id_doi_hinh_1 = new OracleParameter();
            in_id_doi_hinh_1.SourceColumn = "ID_DOI_HINH_1";
            in_id_doi_hinh_1.OracleDbType = OracleDbType.Varchar2;
            in_id_doi_hinh_1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_doi_hinh_1);


            OracleParameter in_id_doi_tuyen_2 = new OracleParameter();
            in_id_doi_tuyen_2.SourceColumn = "ID_DOI_TUYEN_2";
            in_id_doi_tuyen_2.OracleDbType = OracleDbType.Varchar2;
            in_id_doi_tuyen_2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_doi_tuyen_2);

            OracleParameter in_id_doi_hinh_2 = new OracleParameter();
            in_id_doi_hinh_2.SourceColumn = "ID_DOI_HINH_2";
            in_id_doi_hinh_2.OracleDbType = OracleDbType.Varchar2;
            in_id_doi_hinh_2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_doi_hinh_2);

            return cmd;
        }

        private OracleCommand getDeleteTranDau()
        {
            OracleCommand cmd = new OracleCommand("hr.deleteTranDau", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_id = new OracleParameter();
            in_id.SourceColumn = "ID";
            in_id.OracleDbType = OracleDbType.Varchar2;
            in_id.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id);

            return cmd;
        }


        private OracleCommand getUpdateTranDau()
        {
            OracleCommand cmd = new OracleCommand("hr.updateTranDau", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_old_id = new OracleParameter();
            in_old_id.SourceVersion = DataRowVersion.Original;
            in_old_id.SourceColumn = "ID";
            in_old_id.OracleDbType = OracleDbType.Varchar2;
            in_old_id.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_old_id);

            OracleParameter in_id = new OracleParameter();
            in_id.SourceColumn = "ID";
            in_id.OracleDbType = OracleDbType.Varchar2;
            in_id.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id);

            OracleParameter in_loai_tran_dau = new OracleParameter();
            in_loai_tran_dau.SourceColumn = "LOAI_TRAN_DAU";
            in_loai_tran_dau.OracleDbType = OracleDbType.Varchar2;
            in_loai_tran_dau.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_loai_tran_dau);

            OracleParameter in_thoi_diem_bat_dau = new OracleParameter();
            in_thoi_diem_bat_dau.SourceColumn = "THOI_DIEM_BAT_DAU";
            in_thoi_diem_bat_dau.OracleDbType = OracleDbType.TimeStamp;
            in_thoi_diem_bat_dau.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_thoi_diem_bat_dau);

            OracleParameter in_thoi_diem_ket_thuc = new OracleParameter();
            in_thoi_diem_ket_thuc.SourceColumn = "THOI_DIEM_KET_THUC";
            in_thoi_diem_ket_thuc.OracleDbType = OracleDbType.TimeStamp;
            in_thoi_diem_ket_thuc.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_thoi_diem_ket_thuc);

            OracleParameter in_id_san_van_dong = new OracleParameter();
            in_id_san_van_dong.SourceColumn = "ID_SAN_VAN_DONG";
            in_id_san_van_dong.OracleDbType = OracleDbType.Varchar2;
            in_id_san_van_dong.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_san_van_dong);

            OracleParameter in_ti_so_hiep_chinh = new OracleParameter();
            in_ti_so_hiep_chinh.SourceColumn = "TI_SO_HIEP_CHINH";
            in_ti_so_hiep_chinh.OracleDbType = OracleDbType.Varchar2;
            in_ti_so_hiep_chinh.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_ti_so_hiep_chinh);

            OracleParameter in_ti_so_hiep_phu = new OracleParameter();
            in_ti_so_hiep_phu.SourceColumn = "TI_SO_HIEP_PHU";
            in_ti_so_hiep_phu.OracleDbType = OracleDbType.Varchar2;
            in_ti_so_hiep_phu.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_ti_so_hiep_phu);

            OracleParameter in_ti_so_luan_luu = new OracleParameter();
            in_ti_so_luan_luu.SourceColumn = "TI_SO_LUAN_LUU";
            in_ti_so_luan_luu.OracleDbType = OracleDbType.Varchar2;
            in_ti_so_luan_luu.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_ti_so_luan_luu);

            OracleParameter in_id_doi_tuyen_1 = new OracleParameter();
            in_id_doi_tuyen_1.SourceColumn = "ID_DOI_TUYEN_1";
            in_id_doi_tuyen_1.OracleDbType = OracleDbType.Varchar2;
            in_id_doi_tuyen_1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_doi_tuyen_1);

            OracleParameter in_id_doi_hinh_1 = new OracleParameter();
            in_id_doi_hinh_1.SourceColumn = "ID_DOI_HINH_1";
            in_id_doi_hinh_1.OracleDbType = OracleDbType.Varchar2;
            in_id_doi_hinh_1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_doi_hinh_1);


            OracleParameter in_id_doi_tuyen_2 = new OracleParameter();
            in_id_doi_tuyen_2.SourceColumn = "ID_DOI_TUYEN_2";
            in_id_doi_tuyen_2.OracleDbType = OracleDbType.Varchar2;
            in_id_doi_tuyen_2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_doi_tuyen_2);

            OracleParameter in_id_doi_hinh_2 = new OracleParameter();
            in_id_doi_hinh_2.SourceColumn = "ID_DOI_HINH_2";
            in_id_doi_hinh_2.OracleDbType = OracleDbType.Varchar2;
            in_id_doi_hinh_2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_doi_hinh_2);

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

        public DataSet getBinhLuan(string id_tran_dau)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd = new OracleCommand("hr.getBinhLuan", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter in_id_tran_dau = new OracleParameter();
                in_id_tran_dau.OracleDbType = OracleDbType.Varchar2;
                in_id_tran_dau.Direction = ParameterDirection.Input;
                in_id_tran_dau.Value = id_tran_dau;
                cmd.Parameters.Add(in_id_tran_dau);

                OracleParameter out_cur = new OracleParameter();
                out_cur.OracleDbType = OracleDbType.RefCursor;
                out_cur.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(out_cur);

                da = new OracleDataAdapter(cmd);
                ds = new DataSet();

                da.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Operation failed: " + ex.Message);
            }
            return ds;
        }

        //Get DataTable of a procedure viewing a table
        public DataTable get_view(string procedure)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd = new OracleCommand(procedure, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            OracleParameter out_cur = new OracleParameter();
            out_cur.OracleDbType = OracleDbType.RefCursor;
            out_cur.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(out_cur);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "table");
            conn.Close();
            return ds.Tables["table"];
        }

        public DataTable get_view(string procedure, string id_tran_dau)
        {
            cmd = new OracleCommand(procedure, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            OracleParameter out_cur = new OracleParameter();
            out_cur.OracleDbType = OracleDbType.RefCursor;
            out_cur.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(out_cur);
            OracleParameter idtd = new OracleParameter();
            idtd.OracleDbType = OracleDbType.Varchar2;
            idtd.Direction = ParameterDirection.Input;
            idtd.Value = id_tran_dau;
            cmd.Parameters.Add(idtd);
            da = new OracleDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "table");
            conn.Close();
            return ds.Tables["table"];
        }

        //Load DataTable to a listView
        public void loadToListView(ListView lstView, DataTable dt)
        {
            //Clear listView
            lstView.Clear();
            int i = 0, j = 0;
            //Load Column Names to ListView headers
            foreach (DataColumn column in dt.Columns)
            {
                lstView.Columns.Add(column.ColumnName.ToString(), 10, HorizontalAlignment.Left);
                i++;
            }
            //Load content of first row to listView
            for (j = 0; j < dt.Rows.Count; j++)
            {
                lstView.Items.Add(dt.Rows[j].ItemArray[0].ToString());
                lstView.Items[j].BackColor = (j % 2 == 1) ? Color.Lavender : Color.White;
            }
            //Load contents of remain rows to listView
            for (i = 1; i < dt.Columns.Count; i++)
            {
                for (j = 0; j < dt.Rows.Count; j++)
                {
                    lstView.Items[j].SubItems.Add(dt.Rows[j].ItemArray[i].ToString());
                }
            }
            //Resize listView
            for (i = 0; i < dt.Columns.Count; i++)
            {
                lstView.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        //Show available comment of a match to a text box
        public void showComment(TextBox txtBx, string id_tran_dau)
        {
            DataTable dt = get_view("hr.viewBinhLuan_clientMode", id_tran_dau);
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                string name = dt.Rows[j].ItemArray[1].ToString();
                string time = dt.Rows[j].ItemArray[2].ToString();
                string content = dt.Rows[j].ItemArray[3].ToString();
                txtBx.Text += time + ", " + name + " : " + content + Environment.NewLine;
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

        public void insertBinhLuan(string id_tran_dau, string username, string noi_dung)
        {
            if (conn.State != ConnectionState.Open)
                    conn.Open();
            OracleCommand cmd = new OracleCommand("hr.insertBinhLuan", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_id_tran_dau = new OracleParameter();
            in_id_tran_dau.OracleDbType = OracleDbType.Varchar2;
            in_id_tran_dau.Direction = ParameterDirection.Input;
            in_id_tran_dau.Value = id_tran_dau;
            cmd.Parameters.Add(in_id_tran_dau);

            OracleParameter in_username = new OracleParameter();
            in_username.OracleDbType = OracleDbType.Varchar2;
            in_username.Direction = ParameterDirection.Input;
            in_username.Value = username;
            cmd.Parameters.Add(in_username);

            OracleParameter in_thoi_diem = new OracleParameter();
            in_thoi_diem.OracleDbType = OracleDbType.TimeStamp;
            in_thoi_diem.Direction = ParameterDirection.Input;
            in_thoi_diem.Value = OracleTimeStamp.GetSysDate();
            cmd.Parameters.Add(in_thoi_diem);

            OracleParameter in_noi_dung = new OracleParameter();
            in_noi_dung.OracleDbType = OracleDbType.Varchar2;
            in_noi_dung.Direction = ParameterDirection.Input;
            in_noi_dung.Value = noi_dung;
            cmd.Parameters.Add(in_noi_dung);

            OracleParameter in_duyet = new OracleParameter();
            in_duyet.OracleDbType = OracleDbType.Char;
            in_duyet.Direction = ParameterDirection.Input;
            in_duyet.Value = '-';
            cmd.Parameters.Add(in_duyet);
            cmd.ExecuteNonQuery();
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
            in_duyet.SourceColumn = "DUYET";
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

        #region PHAT_THE
        public void viewPhatThe(DataGridView dgv)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd = new OracleCommand("hr.viewPhatThe", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter out_cur = new OracleParameter();
                out_cur.OracleDbType = OracleDbType.RefCursor;
                out_cur.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(out_cur);

                da = new OracleDataAdapter(cmd);
                da.InsertCommand = getInsertPhatThe();
                da.DeleteCommand = getDeletePhatThe();
                da.UpdateCommand = getUpdatePhatThe();

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

        //public void update()
        //{
        //    try
        //    {
        //        da.Update(ds.Tables[0]);
        //        MessageBox.Show("Success", "Information", MessageBoxButtons.OK);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Invalid value");
        //    }
        //}

        private OracleCommand getInsertPhatThe()
        {
            OracleCommand cmd = new OracleCommand("hr.insertPhatThe", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_id_su_kien = new OracleParameter();
            in_id_su_kien.SourceColumn = "ID_SU_KIEN";
            in_id_su_kien.OracleDbType = OracleDbType.Varchar2;
            in_id_su_kien.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_su_kien);

            OracleParameter in_thoi_diem = new OracleParameter();
            in_thoi_diem.SourceColumn = "THOI_DIEM";
            in_thoi_diem.OracleDbType = OracleDbType.TimeStamp;
            in_thoi_diem.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_thoi_diem);

            OracleParameter in_loai = new OracleParameter();
            in_loai.SourceColumn = "LOAI";
            in_loai.OracleDbType = OracleDbType.Char;
            in_loai.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_loai);

            OracleParameter in_id_cau_thu = new OracleParameter();
            in_id_cau_thu.SourceColumn = "ID_CAU_THU";
            in_id_cau_thu.OracleDbType = OracleDbType.Varchar2;
            in_id_cau_thu.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_cau_thu);

            OracleParameter in_id_tran_dau = new OracleParameter();
            in_id_tran_dau.SourceColumn = "ID_TRAN_DAU";
            in_id_tran_dau.OracleDbType = OracleDbType.Varchar2;
            in_id_tran_dau.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_tran_dau);

            return cmd;
        }

        private OracleCommand getUpdatePhatThe()
        {
            OracleCommand cmd = new OracleCommand("hr.updatePhatThe", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_old_id_su_kien = new OracleParameter();
            in_old_id_su_kien.SourceColumn = "ID_SU_KIEN";
            in_old_id_su_kien.OracleDbType = OracleDbType.Varchar2;
            in_old_id_su_kien.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_old_id_su_kien);

            OracleParameter in_id_su_kien = new OracleParameter();
            in_id_su_kien.SourceColumn = "ID_SU_KIEN";
            in_id_su_kien.OracleDbType = OracleDbType.Varchar2;
            in_id_su_kien.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_su_kien);

            OracleParameter in_thoi_diem = new OracleParameter();
            in_thoi_diem.SourceColumn = "THOI_DIEM";
            in_thoi_diem.OracleDbType = OracleDbType.TimeStamp;
            in_thoi_diem.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_thoi_diem);

            OracleParameter in_loai = new OracleParameter();
            in_loai.SourceColumn = "LOAI";
            in_loai.OracleDbType = OracleDbType.Char;
            in_loai.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_loai);

            OracleParameter in_id_cau_thu = new OracleParameter();
            in_id_cau_thu.SourceColumn = "ID_CAU_THU";
            in_id_cau_thu.OracleDbType = OracleDbType.Varchar2;
            in_id_cau_thu.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_cau_thu);

            OracleParameter in_id_tran_dau = new OracleParameter();
            in_id_tran_dau.SourceColumn = "ID_TRAN_DAU";
            in_id_tran_dau.OracleDbType = OracleDbType.Varchar2;
            in_id_tran_dau.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_tran_dau);

            return cmd;
        }

        private OracleCommand getDeletePhatThe()
        {
            OracleCommand cmd = new OracleCommand("hr.deletePhatThe", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_id_su_kien = new OracleParameter();
            in_id_su_kien.SourceColumn = "ID_SU_KIEN";
            in_id_su_kien.OracleDbType = OracleDbType.Varchar2;
            in_id_su_kien.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_su_kien);

            return cmd;
        }
        #endregion

        #region BAN_THANG
        public void viewBanThang(DataGridView dgv)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd = new OracleCommand("hr.viewBanThang", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter out_cur = new OracleParameter();
                out_cur.OracleDbType = OracleDbType.RefCursor;
                out_cur.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(out_cur);

                da = new OracleDataAdapter(cmd);
                da.InsertCommand = getInsertBanThang();
                da.DeleteCommand = getDeleteBanThang();
                da.UpdateCommand = getUpdateBanThang();

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

        private OracleCommand getInsertBanThang()
        {
            OracleCommand cmd = new OracleCommand("hr.insertBanThang", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_id_su_kien = new OracleParameter();
            in_id_su_kien.SourceColumn = "ID_SU_KIEN";
            in_id_su_kien.OracleDbType = OracleDbType.Varchar2;
            in_id_su_kien.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_su_kien);

            OracleParameter in_thoi_diem = new OracleParameter();
            in_thoi_diem.SourceColumn = "THOI_DIEM";
            in_thoi_diem.OracleDbType = OracleDbType.TimeStamp;
            in_thoi_diem.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_thoi_diem);

            OracleParameter in_phan_luoi = new OracleParameter();
            in_phan_luoi.SourceColumn = "PHAN_LUOI";
            in_phan_luoi.OracleDbType = OracleDbType.Char;
            in_phan_luoi.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_phan_luoi);

            OracleParameter in_id_cau_thu_chuyen = new OracleParameter();
            in_id_cau_thu_chuyen.SourceColumn = "ID_CAU_THU_CHUYEN";
            in_id_cau_thu_chuyen.OracleDbType = OracleDbType.Varchar2;
            in_id_cau_thu_chuyen.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_cau_thu_chuyen);

            OracleParameter in_id_cau_thu_ghi_ban = new OracleParameter();
            in_id_cau_thu_ghi_ban.SourceColumn = "ID_CAU_THU_GHI_BAN";
            in_id_cau_thu_ghi_ban.OracleDbType = OracleDbType.Varchar2;
            in_id_cau_thu_ghi_ban.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_cau_thu_ghi_ban);

            OracleParameter in_id_tran_dau = new OracleParameter();
            in_id_tran_dau.SourceColumn = "ID_TRAN_DAU";
            in_id_tran_dau.OracleDbType = OracleDbType.Varchar2;
            in_id_tran_dau.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_tran_dau);

            return cmd;
        }

        private OracleCommand getUpdateBanThang()
        {
            OracleCommand cmd = new OracleCommand("hr.updateBanThang", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_old_id_su_kien = new OracleParameter();
            in_old_id_su_kien.SourceColumn = "ID_SU_KIEN";
            in_old_id_su_kien.OracleDbType = OracleDbType.Varchar2;
            in_old_id_su_kien.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_old_id_su_kien);

            OracleParameter in_id_su_kien = new OracleParameter();
            in_id_su_kien.SourceColumn = "ID_SU_KIEN";
            in_id_su_kien.OracleDbType = OracleDbType.Varchar2;
            in_id_su_kien.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_su_kien);

            OracleParameter in_thoi_diem = new OracleParameter();
            in_thoi_diem.SourceColumn = "THOI_DIEM";
            in_thoi_diem.OracleDbType = OracleDbType.TimeStamp;
            in_thoi_diem.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_thoi_diem);

            OracleParameter in_phan_luoi = new OracleParameter();
            in_phan_luoi.SourceColumn = "PHAN_LUOI";
            in_phan_luoi.OracleDbType = OracleDbType.Char;
            in_phan_luoi.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_phan_luoi);

            OracleParameter in_id_cau_thu_chuyen = new OracleParameter();
            in_id_cau_thu_chuyen.SourceColumn = "ID_CAU_THU_CHUYEN";
            in_id_cau_thu_chuyen.OracleDbType = OracleDbType.Varchar2;
            in_id_cau_thu_chuyen.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_cau_thu_chuyen);

            OracleParameter in_id_cau_thu_ghi_ban = new OracleParameter();
            in_id_cau_thu_ghi_ban.SourceColumn = "ID_CAU_THU_GHI_BAN";
            in_id_cau_thu_ghi_ban.OracleDbType = OracleDbType.Varchar2;
            in_id_cau_thu_ghi_ban.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_cau_thu_ghi_ban);

            OracleParameter in_id_tran_dau = new OracleParameter();
            in_id_tran_dau.SourceColumn = "ID_TRAN_DAU";
            in_id_tran_dau.OracleDbType = OracleDbType.Varchar2;
            in_id_tran_dau.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_tran_dau);

            return cmd;
        }

        private OracleCommand getDeleteBanThang()
        {
            OracleCommand cmd = new OracleCommand("hr.deleteBanThang", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_id_su_kien = new OracleParameter();
            in_id_su_kien.SourceColumn = "ID_SU_KIEN";
            in_id_su_kien.OracleDbType = OracleDbType.Varchar2;
            in_id_su_kien.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_su_kien);

            return cmd;
        }

        #endregion

        #region CHON_CAU_THU_XUAT_SAC
        public void viewChonCauThuXuatSac(DataGridView dgv)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd = new OracleCommand("hr.viewChonCauThuXuatSac", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter out_cur = new OracleParameter();
                out_cur.OracleDbType = OracleDbType.RefCursor;
                out_cur.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(out_cur);

                da = new OracleDataAdapter(cmd);
                da.InsertCommand = getInsertChonCauThuXuatSac();
                da.DeleteCommand = getDeleteChonCauThuXuatSac();
                da.UpdateCommand = getUpdateChonCauThuXuatSac();

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

        private OracleCommand getInsertChonCauThuXuatSac()
        {
            OracleCommand cmd = new OracleCommand("hr.insertChonCauThuXuatSac", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_id_su_kien = new OracleParameter();
            in_id_su_kien.SourceColumn = "ID_SU_KIEN";
            in_id_su_kien.OracleDbType = OracleDbType.Varchar2;
            in_id_su_kien.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_su_kien);

            OracleParameter in_thoi_diem = new OracleParameter();
            in_thoi_diem.SourceColumn = "THOI_DIEM";
            in_thoi_diem.OracleDbType = OracleDbType.TimeStamp;
            in_thoi_diem.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_thoi_diem);

            OracleParameter in_id_cau_thu = new OracleParameter();
            in_id_cau_thu.SourceColumn = "ID_CAU_THU";
            in_id_cau_thu.OracleDbType = OracleDbType.Varchar2;
            in_id_cau_thu.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_cau_thu);

            OracleParameter in_id_tran_dau = new OracleParameter();
            in_id_tran_dau.SourceColumn = "ID_TRAN_DAU";
            in_id_tran_dau.OracleDbType = OracleDbType.Varchar2;
            in_id_tran_dau.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_tran_dau);

            return cmd;
        }

        private OracleCommand getUpdateChonCauThuXuatSac()
        {
            OracleCommand cmd = new OracleCommand("hr.updateChonCauThuXuatSac", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_old_id_su_kien = new OracleParameter();
            in_old_id_su_kien.SourceColumn = "ID_SU_KIEN";
            in_old_id_su_kien.OracleDbType = OracleDbType.Varchar2;
            in_old_id_su_kien.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_old_id_su_kien);

            OracleParameter in_id_su_kien = new OracleParameter();
            in_id_su_kien.SourceColumn = "ID_SU_KIEN";
            in_id_su_kien.OracleDbType = OracleDbType.Varchar2;
            in_id_su_kien.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_su_kien);

            OracleParameter in_thoi_diem = new OracleParameter();
            in_thoi_diem.SourceColumn = "THOI_DIEM";
            in_thoi_diem.OracleDbType = OracleDbType.TimeStamp;
            in_thoi_diem.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_thoi_diem);

            OracleParameter in_id_cau_thu = new OracleParameter();
            in_id_cau_thu.SourceColumn = "ID_CAU_THU";
            in_id_cau_thu.OracleDbType = OracleDbType.Varchar2;
            in_id_cau_thu.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_cau_thu);

            OracleParameter in_id_tran_dau = new OracleParameter();
            in_id_tran_dau.SourceColumn = "ID_TRAN_DAU";
            in_id_tran_dau.OracleDbType = OracleDbType.Varchar2;
            in_id_tran_dau.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_tran_dau);

            return cmd;
        }

        private OracleCommand getDeleteChonCauThuXuatSac()
        {
            OracleCommand cmd = new OracleCommand("hr.deleteChonCauThuXuatSac", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_id_su_kien = new OracleParameter();
            in_id_su_kien.SourceColumn = "ID_SU_KIEN";
            in_id_su_kien.OracleDbType = OracleDbType.Varchar2;
            in_id_su_kien.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_su_kien);

            return cmd;
        }
    
        #endregion

        #region THAY_NGUOI
        public void viewThayNguoi(DataGridView dgv)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd = new OracleCommand("hr.viewThayNguoi", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter out_cur = new OracleParameter();
                out_cur.OracleDbType = OracleDbType.RefCursor;
                out_cur.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(out_cur);

                da = new OracleDataAdapter(cmd);
                da.InsertCommand = getInsertThayNguoi();
                da.DeleteCommand = getDeleteThayNguoi();
                da.UpdateCommand = getUpdateThayNguoi();

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

        private OracleCommand getInsertThayNguoi()
        {
            OracleCommand cmd = new OracleCommand("hr.insertThayNguoi", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_id_su_kien = new OracleParameter();
            in_id_su_kien.SourceColumn = "ID_SU_KIEN";
            in_id_su_kien.OracleDbType = OracleDbType.Varchar2;
            in_id_su_kien.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_su_kien);

            OracleParameter in_thoi_diem = new OracleParameter();
            in_thoi_diem.SourceColumn = "THOI_DIEM";
            in_thoi_diem.OracleDbType = OracleDbType.TimeStamp;
            in_thoi_diem.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_thoi_diem);

            OracleParameter in_id_cau_thu_ra_nghi = new OracleParameter();
            in_id_cau_thu_ra_nghi.SourceColumn = "ID_CAU_THU_RA_NGHI";
            in_id_cau_thu_ra_nghi.OracleDbType = OracleDbType.Varchar2;
            in_id_cau_thu_ra_nghi.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_cau_thu_ra_nghi);

            OracleParameter in_id_cau_thu_vao_thay = new OracleParameter();
            in_id_cau_thu_vao_thay.SourceColumn = "ID_CAU_THU_VAO_THAY";
            in_id_cau_thu_vao_thay.OracleDbType = OracleDbType.Varchar2;
            in_id_cau_thu_vao_thay.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_cau_thu_vao_thay);

            OracleParameter in_diem_cau_thu_vao_thay = new OracleParameter();
            in_diem_cau_thu_vao_thay.SourceColumn = "DIEM_CAU_THU_VAO_THAY";
            in_diem_cau_thu_vao_thay.OracleDbType = OracleDbType.Decimal;
            in_diem_cau_thu_vao_thay.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_diem_cau_thu_vao_thay);

            OracleParameter in_id_tran_dau = new OracleParameter();
            in_id_tran_dau.SourceColumn = "ID_TRAN_DAU";
            in_id_tran_dau.OracleDbType = OracleDbType.Varchar2;
            in_id_tran_dau.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_tran_dau);

            return cmd;
        }

        private OracleCommand getUpdateThayNguoi()
        {
            OracleCommand cmd = new OracleCommand("hr.updateThayNguoi", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_old_id_su_kien = new OracleParameter();
            in_old_id_su_kien.SourceColumn = "ID_SU_KIEN";
            in_old_id_su_kien.OracleDbType = OracleDbType.Varchar2;
            in_old_id_su_kien.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_old_id_su_kien);

            OracleParameter in_id_su_kien = new OracleParameter();
            in_id_su_kien.SourceColumn = "ID_SU_KIEN";
            in_id_su_kien.OracleDbType = OracleDbType.Varchar2;
            in_id_su_kien.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_su_kien);

            OracleParameter in_thoi_diem = new OracleParameter();
            in_thoi_diem.SourceColumn = "THOI_DIEM";
            in_thoi_diem.OracleDbType = OracleDbType.TimeStamp;
            in_thoi_diem.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_thoi_diem);

            OracleParameter in_id_cau_thu_ra_nghi = new OracleParameter();
            in_id_cau_thu_ra_nghi.SourceColumn = "ID_CAU_THU_RA_NGHI";
            in_id_cau_thu_ra_nghi.OracleDbType = OracleDbType.Varchar2;
            in_id_cau_thu_ra_nghi.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_cau_thu_ra_nghi);

            OracleParameter in_id_cau_thu_vao_thay = new OracleParameter();
            in_id_cau_thu_vao_thay.SourceColumn = "ID_CAU_THU_VAO_THAY";
            in_id_cau_thu_vao_thay.OracleDbType = OracleDbType.Varchar2;
            in_id_cau_thu_vao_thay.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_cau_thu_vao_thay);

            OracleParameter in_diem_cau_thu_vao_thay = new OracleParameter();
            in_diem_cau_thu_vao_thay.SourceColumn = "DIEM_CAU_THU_VAO_THAY";
            in_diem_cau_thu_vao_thay.OracleDbType = OracleDbType.Decimal;
            in_diem_cau_thu_vao_thay.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_diem_cau_thu_vao_thay);

            OracleParameter in_id_tran_dau = new OracleParameter();
            in_id_tran_dau.SourceColumn = "ID_TRAN_DAU";
            in_id_tran_dau.OracleDbType = OracleDbType.Varchar2;
            in_id_tran_dau.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_tran_dau);

            return cmd;
        }

        private OracleCommand getDeleteThayNguoi()
        {
            OracleCommand cmd = new OracleCommand("hr.deleteThayNguoi", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_id_su_kien = new OracleParameter();
            in_id_su_kien.SourceColumn = "ID_SU_KIEN";
            in_id_su_kien.OracleDbType = OracleDbType.Varchar2;
            in_id_su_kien.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_su_kien);

            return cmd;
        }
        #endregion

        #region LUAN_LUU
        public void viewLuanLuu(DataGridView dgv)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd = new OracleCommand("hr.viewLuanLuu", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter out_cur = new OracleParameter();
                out_cur.OracleDbType = OracleDbType.RefCursor;
                out_cur.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(out_cur);

                da = new OracleDataAdapter(cmd);
                da.InsertCommand = getInsertLuanLuu();
                da.DeleteCommand = getDeleteLuanLuu();
                da.UpdateCommand = getUpdateLuanLuu();

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

        private OracleCommand getInsertLuanLuu()
        {
            OracleCommand cmd = new OracleCommand("hr.insertLuanLuu", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_id_su_kien = new OracleParameter();
            in_id_su_kien.SourceColumn = "ID_SU_KIEN";
            in_id_su_kien.OracleDbType = OracleDbType.Varchar2;
            in_id_su_kien.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_su_kien);

            OracleParameter in_thoi_diem = new OracleParameter();
            in_thoi_diem.SourceColumn = "THOI_DIEM";
            in_thoi_diem.OracleDbType = OracleDbType.TimeStamp;
            in_thoi_diem.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_thoi_diem);

            OracleParameter in_so_thu_tu = new OracleParameter();
            in_so_thu_tu.SourceColumn = "SO_THU_TU";
            in_so_thu_tu.OracleDbType = OracleDbType.Int32;
            in_so_thu_tu.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_so_thu_tu);

            OracleParameter in_id_cau_thu_thuc_hien = new OracleParameter();
            in_id_cau_thu_thuc_hien.SourceColumn = "ID_CAU_THU_THUC_HIEN";
            in_id_cau_thu_thuc_hien.OracleDbType = OracleDbType.Varchar2;
            in_id_cau_thu_thuc_hien.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_cau_thu_thuc_hien);

            OracleParameter in_ket_qua = new OracleParameter();
            in_ket_qua.SourceColumn = "KET_QUA";
            in_ket_qua.OracleDbType = OracleDbType.Char;
            in_ket_qua.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_ket_qua);

            OracleParameter in_id_tran_dau = new OracleParameter();
            in_id_tran_dau.SourceColumn = "ID_TRAN_DAU";
            in_id_tran_dau.OracleDbType = OracleDbType.Varchar2;
            in_id_tran_dau.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_tran_dau);

            return cmd;
        }

        private OracleCommand getUpdateLuanLuu()
        {
            OracleCommand cmd = new OracleCommand("hr.updateLuanLuu", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_old_id_su_kien = new OracleParameter();
            in_old_id_su_kien.SourceColumn = "ID_SU_KIEN";
            in_old_id_su_kien.OracleDbType = OracleDbType.Varchar2;
            in_old_id_su_kien.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_old_id_su_kien);

            OracleParameter in_id_su_kien = new OracleParameter();
            in_id_su_kien.SourceColumn = "ID_SU_KIEN";
            in_id_su_kien.OracleDbType = OracleDbType.Varchar2;
            in_id_su_kien.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_su_kien);

            OracleParameter in_thoi_diem = new OracleParameter();
            in_thoi_diem.SourceColumn = "THOI_DIEM";
            in_thoi_diem.OracleDbType = OracleDbType.TimeStamp;
            in_thoi_diem.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_thoi_diem);

            OracleParameter in_so_thu_tu = new OracleParameter();
            in_so_thu_tu.SourceColumn = "SO_THU_TU";
            in_so_thu_tu.OracleDbType = OracleDbType.Int32;
            in_so_thu_tu.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_so_thu_tu);

            OracleParameter in_id_cau_thu_thuc_hien = new OracleParameter();
            in_id_cau_thu_thuc_hien.SourceColumn = "ID_CAU_THU_THUC_HIEN";
            in_id_cau_thu_thuc_hien.OracleDbType = OracleDbType.Varchar2;
            in_id_cau_thu_thuc_hien.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_cau_thu_thuc_hien);

            OracleParameter in_ket_qua = new OracleParameter();
            in_ket_qua.SourceColumn = "KET_QUA";
            in_ket_qua.OracleDbType = OracleDbType.Char;
            in_ket_qua.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_ket_qua);

            OracleParameter in_id_tran_dau = new OracleParameter();
            in_id_tran_dau.SourceColumn = "ID_TRAN_DAU";
            in_id_tran_dau.OracleDbType = OracleDbType.Varchar2;
            in_id_tran_dau.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_tran_dau);

            return cmd;
        }

        private OracleCommand getDeleteLuanLuu()
        {
            OracleCommand cmd = new OracleCommand("hr.deleteLuanLuu", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_id_su_kien = new OracleParameter();
            in_id_su_kien.SourceColumn = "ID_SU_KIEN";
            in_id_su_kien.OracleDbType = OracleDbType.Varchar2;
            in_id_su_kien.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_su_kien);

            return cmd;
        }

        #endregion

        #region DEO_BANG_DOI_TRUONG
        public void viewDeoBangDoiTruong(DataGridView dgv)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd = new OracleCommand("hr.viewDeobangDoiTruong", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter out_cur = new OracleParameter();
                out_cur.OracleDbType = OracleDbType.RefCursor;
                out_cur.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(out_cur);

                da = new OracleDataAdapter(cmd);
                da.InsertCommand = getInsertDeoBangDoiTruong();
                da.DeleteCommand = getDeleteDeoBangDoiTruong();
                da.UpdateCommand = getUpdateDeoBangDoiTruong();

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

        private OracleCommand getInsertDeoBangDoiTruong()
        {
            OracleCommand cmd = new OracleCommand("hr.insertDeoBangDoiTruong", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_id_su_kien = new OracleParameter();
            in_id_su_kien.SourceColumn = "ID_SU_KIEN";
            in_id_su_kien.OracleDbType = OracleDbType.Varchar2;
            in_id_su_kien.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_su_kien);

            OracleParameter in_thoi_diem = new OracleParameter();
            in_thoi_diem.SourceColumn = "THOI_DIEM";
            in_thoi_diem.OracleDbType = OracleDbType.TimeStamp;
            in_thoi_diem.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_thoi_diem);

            OracleParameter in_id_cau_thu = new OracleParameter();
            in_id_cau_thu.SourceColumn = "ID_CAU_THU";
            in_id_cau_thu.OracleDbType = OracleDbType.Varchar2;
            in_id_cau_thu.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_cau_thu);

            OracleParameter in_id_tran_dau = new OracleParameter();
            in_id_tran_dau.SourceColumn = "ID_TRAN_DAU";
            in_id_tran_dau.OracleDbType = OracleDbType.Varchar2;
            in_id_tran_dau.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_tran_dau);

            return cmd;
        }

        private OracleCommand getUpdateDeoBangDoiTruong()
        {
            OracleCommand cmd = new OracleCommand("hr.updateDeoBangDoiTruong", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_old_id_su_kien = new OracleParameter();
            in_old_id_su_kien.SourceColumn = "ID_SU_KIEN";
            in_old_id_su_kien.OracleDbType = OracleDbType.Varchar2;
            in_old_id_su_kien.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_old_id_su_kien);

            OracleParameter in_id_su_kien = new OracleParameter();
            in_id_su_kien.SourceColumn = "ID_SU_KIEN";
            in_id_su_kien.OracleDbType = OracleDbType.Varchar2;
            in_id_su_kien.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_su_kien);

            OracleParameter in_thoi_diem = new OracleParameter();
            in_thoi_diem.SourceColumn = "THOI_DIEM";
            in_thoi_diem.OracleDbType = OracleDbType.TimeStamp;
            in_thoi_diem.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_thoi_diem);

            OracleParameter in_id_cau_thu = new OracleParameter();
            in_id_cau_thu.SourceColumn = "ID_CAU_THU";
            in_id_cau_thu.OracleDbType = OracleDbType.Varchar2;
            in_id_cau_thu.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_cau_thu);

            OracleParameter in_id_tran_dau = new OracleParameter();
            in_id_tran_dau.SourceColumn = "ID_TRAN_DAU";
            in_id_tran_dau.OracleDbType = OracleDbType.Varchar2;
            in_id_tran_dau.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_tran_dau);

            return cmd;
        }

        private OracleCommand getDeleteDeoBangDoiTruong()
        {
            OracleCommand cmd = new OracleCommand("hr.deleteDeoBangDoiTruong", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_id_su_kien = new OracleParameter();
            in_id_su_kien.SourceColumn = "ID_SU_KIEN";
            in_id_su_kien.OracleDbType = OracleDbType.Varchar2;
            in_id_su_kien.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_su_kien);

            return cmd;
        }

        #endregion

        #region DOI_HINH_XUAT_PHAT
        public void viewDoiHinhXuatPhat(DataGridView dgv)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd = new OracleCommand("hr.viewDoiHinhXuatPhat", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter out_cur = new OracleParameter();
                out_cur.OracleDbType = OracleDbType.RefCursor;
                out_cur.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(out_cur);

                da = new OracleDataAdapter(cmd);
                da.InsertCommand = getInsertDoiHinhXuatPhat();
                da.DeleteCommand = getDeleteDoiHinhXuatPhat();
                da.UpdateCommand = getUpdateDoiHinhXuatPhat();

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

        private OracleCommand getInsertDoiHinhXuatPhat()
        {
            OracleCommand cmd = new OracleCommand("hr.insertDoiHinhXuatPhat", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_id_su_kien = new OracleParameter();
            in_id_su_kien.SourceColumn = "ID_SU_KIEN";
            in_id_su_kien.OracleDbType = OracleDbType.Varchar2;
            in_id_su_kien.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_su_kien);

            OracleParameter in_id_cau_thu = new OracleParameter();
            in_id_cau_thu.SourceColumn = "ID_CAU_THU";
            in_id_cau_thu.OracleDbType = OracleDbType.Varchar2;
            in_id_cau_thu.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_cau_thu);

            OracleParameter in_thoi_diem = new OracleParameter();
            in_thoi_diem.SourceColumn = "THOI_DIEM";
            in_thoi_diem.OracleDbType = OracleDbType.TimeStamp;
            in_thoi_diem.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_thoi_diem);

            OracleParameter in_diem_cau_thu_xuat_phat = new OracleParameter();
            in_diem_cau_thu_xuat_phat.SourceColumn = "ID_DIEM_CAU_THU_XUAT_PHAT";
            in_diem_cau_thu_xuat_phat.OracleDbType = OracleDbType.Decimal;
            in_diem_cau_thu_xuat_phat.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_diem_cau_thu_xuat_phat);

            OracleParameter in_id_tran_dau = new OracleParameter();
            in_id_tran_dau.SourceColumn = "ID_TRAN_DAU";
            in_id_tran_dau.OracleDbType = OracleDbType.Varchar2;
            in_id_tran_dau.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_tran_dau);

            return cmd;
        }

        private OracleCommand getUpdateDoiHinhXuatPhat()
        {
            OracleCommand cmd = new OracleCommand("hr.updateDoiHinhXuatPhat", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_old_id_su_kien = new OracleParameter();
            in_old_id_su_kien.SourceColumn = "ID_SU_KIEN";
            in_old_id_su_kien.OracleDbType = OracleDbType.Varchar2;
            in_old_id_su_kien.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_old_id_su_kien);

            OracleParameter in_old_id_cau_thu = new OracleParameter();
            in_old_id_cau_thu.SourceColumn = "ID_CAU_THU";
            in_old_id_cau_thu.OracleDbType = OracleDbType.Varchar2;
            in_old_id_cau_thu.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_old_id_cau_thu);

            OracleParameter in_id_su_kien = new OracleParameter();
            in_id_su_kien.SourceColumn = "ID_SU_KIEN";
            in_id_su_kien.OracleDbType = OracleDbType.Varchar2;
            in_id_su_kien.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_su_kien);

            OracleParameter in_id_cau_thu = new OracleParameter();
            in_id_cau_thu.SourceColumn = "ID_CAU_THU";
            in_id_cau_thu.OracleDbType = OracleDbType.Varchar2;
            in_id_cau_thu.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_cau_thu);

            OracleParameter in_thoi_diem = new OracleParameter();
            in_thoi_diem.SourceColumn = "THOI_DIEM";
            in_thoi_diem.OracleDbType = OracleDbType.TimeStamp;
            in_thoi_diem.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_thoi_diem);

            OracleParameter in_diem_cau_thu_xuat_phat = new OracleParameter();
            in_diem_cau_thu_xuat_phat.SourceColumn = "ID_DIEM_CAU_THU_XUAT_PHAT";
            in_diem_cau_thu_xuat_phat.OracleDbType = OracleDbType.Decimal;
            in_diem_cau_thu_xuat_phat.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_diem_cau_thu_xuat_phat);

            OracleParameter in_id_tran_dau = new OracleParameter();
            in_id_tran_dau.SourceColumn = "ID_TRAN_DAU";
            in_id_tran_dau.OracleDbType = OracleDbType.Varchar2;
            in_id_tran_dau.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_tran_dau);

            return cmd;
        }

        private OracleCommand getDeleteDoiHinhXuatPhat()
        {
            OracleCommand cmd = new OracleCommand("hr.deleteDoiHinhXuatPhat", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter in_id_su_kien = new OracleParameter();
            in_id_su_kien.SourceColumn = "ID_SU_KIEN";
            in_id_su_kien.OracleDbType = OracleDbType.Varchar2;
            in_id_su_kien.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_su_kien);

            OracleParameter in_id_cau_thu = new OracleParameter();
            in_id_cau_thu.SourceColumn = "ID_CAU_THU";
            in_id_cau_thu.OracleDbType = OracleDbType.Varchar2;
            in_id_cau_thu.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(in_id_cau_thu);

            return cmd;
        }


        #endregion

    }
}
