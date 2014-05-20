create or replace PROCEDURE deleteQuanLyDoiBong(in_username in VARCHAR2, in_id_doi_tuyen in VARCHAR2)
as
begin
  delete from quan_ly_doi_bong
  where username = in_username and id_doi_tuyen = in_id_doi_tuyen;
  commit;
end;
/

create or replace PROCEDURE deleteTaikhoan(in_username in VARCHAR2)
as
begin
  delete from tai_khoan
  where username = in_username;
  commit;
end;
/

create or replace PROCEDURE deleteWorldCup(in_nam in NUMBER)
as
begin
  delete from world_cup
  where nam = in_nam;
  commit;
end;
/

create or replace procedure insertQuanLyDoiBong(in_username in VARCHAR2, in_id_doi_tuyen in VARCHAR2)
as

begin
  insert into quan_ly_doi_bong
  values (in_username, in_id_doi_tuyen);
  commit;
end;
/

create or replace procedure insertTaikhoan(n_username in VARCHAR2, in_password in VARCHAR2, in_loai_tai_khoan in VARCHAR2)
as

begin
  insert into TAI_KHOAN
  values (n_username, in_password, in_loai_tai_khoan);
  commit;
end;
/

create or replace procedure insertWorldCup
(
  in_nam                        in number, 
  in_so_doi                     in number, 
  in_id_cau_thu_xuat_sac_nhat   in VARCHAR2, 
  in_id_doi_vo_dich             in VARCHAR2, 
  in_id_doi_a_quan              in VARCHAR2, 
  in_id_doi_hang_3              in VARCHAR2)
as

begin
  insert into world_cup
  values (in_nam, in_so_doi, in_id_cau_thu_xuat_sac_nhat, in_id_doi_vo_dich,in_id_doi_a_quan, in_id_doi_hang_3);
  commit;
end;
/

create or replace PROCEDURE isValidAccount(IN_USERNAME IN VARCHAR2, IN_PASSWORD IN VARCHAR2, IN_LOAI IN VARCHAR2, FLAG OUT NUMBER)
AS
  USER VARCHAR2(30);
  CURSOR CUR IS
    SELECT USERNAME 
    FROM TAI_KHOAN
    WHERE UPPER(USERNAME) = UPPER(IN_USERNAME) AND PASSWORD = IN_PASSWORD AND LOAI_TAI_KHOAN = IN_LOAI;
BEGIN
  FLAG := -1;
  OPEN CUR;
  FETCH CUR INTO USER;
  IF CUR%NOTFOUND THEN
    FLAG := 2;
  ELSE
    FLAG := 1;
  END IF;
  CLOSE CUR;
END;
/

create or replace procedure quan_ly(uname in varchar2, tenkhac in varchar2, flag out int)
as
begin
flag:=0;
select count(*) into flag
from quan_ly_doi_bong,DOI_TUYEN 
where DOI_TUYEN.ID=quan_ly_doi_bong.ID_DOI_TUYEN 
and quan_ly_doi_bong.USERNAME=uname 
and DOI_TUYEN.TEN=tenkhac;
if (flag > 0)
then
flag:=1;
end if;
end;
/

create or replace procedure updateQuanLyDoiBong
(
  in_old_username in VARCHAR2,
  in_old_id_doi_tuyen in VARCHAR2,
  in_username in VARCHAR2,
  in_id_doi_tuyen in VARCHAR2
)
as
begin
  update quan_ly_doi_bong
  set username = in_username, id_doi_tuyen = in_id_doi_tuyen
  where username = in_old_username and id_doi_tuyen = in_old_id_doi_tuyen;
  commit;
end;
/

create or replace procedure updateTaiKhoan (in_old_username in VARCHAR2, in_username in VARCHAR2, in_password in VARCHAR2, in_loai_tai_khoan in VARCHAR2)
as
begin
  update tai_khoan
  set username = in_username, password = in_password, loai_tai_khoan = in_loai_tai_khoan
  where username = in_old_username;
  commit;
end;
/

create or replace procedure updateWorldCup
(
  in_old_nam in NUMBER,
  in_nam in NUMBER,
  in_soi_doi in NUMBER,
  in_id_cau_thu_xuat_sac_nhat varchar2,
  in_id_doi_vo_dich in VARCHAR2,
  in_id_doi_a_quan in VARCHAR2,
  in_id_doi_hang_3 in VARCHAR2
)
as
begin
  update world_cup
  set 
    nam = in_nam, 
    so_doi = in_soi_doi, 
    id_cau_thu_xuat_sac_nhat = in_id_cau_thu_xuat_sac_nhat, 
    id_doi_vo_dich = in_id_doi_vo_dich, 
    id_doi_a_quan = in_id_doi_a_quan, 
    id_doi_hang_3 = in_id_doi_hang_3
  where nam = in_old_nam;
  commit;
end;
/

create or replace procedure viewQuanLyDoiBong(out_cur out sys_refcursor)
is
begin
  open out_cur for
  select * from quan_ly_doi_bong;
end;
/

create or replace procedure viewTaiKhoan(out_cur out sys_refcursor)
is
begin
  open out_cur for
  select * from tai_khoan;
end;
/

create or replace procedure viewWorldCup(out_cur out sys_refcursor)
is
begin
  open out_cur for
  select * from world_cup;
end;
/

create or replace procedure viewTranDau(out_cur out sys_refcursor)
is
begin
  open out_cur for
  select * from tran_dau;
end;
/

create or replace procedure viewBinhLuan(out_cur out sys_refcursor)
is
begin
  open out_cur for
  select * from binh_luan;
end;
/

create or replace
PROCEDURE deleteBinhLuan
(
  in_id_tran_dau in VARCHAR2,
  in_username in VARCHAR2,
  in_thoi_diem in timestamp
)
as
begin
  delete from binh_luan
  where id_tran_dau = in_id_tran_dau and upper(username) = upper(in_username) and thoi_diem = in_thoi_diem;
  commit;
end;
/

create or replace
procedure insertBinhLuan
(
  in_id_tran_dau in VARCHAR2,
  in_username in VARCHAR2,
  in_thoi_diem in TIMESTAMP,
  in_noi_dung in varchar,
  in_duyet in char
)
as

begin
  insert into binh_luan
  values (in_id_tran_dau, in_username, in_thoi_diem, in_noi_dung, in_duyet);
  commit;
end;

/

create or replace procedure updateBinhLuan
(
  in_old_id_tran_dau in VARCHAR2,
  in_old_username in VARCHAR2,
  in_old_thoi_diem in TIMESTAMP,
  in_id_tran_dau in VARCHAR2,
  in_username in VARCHAR2,
  in_thoi_diem in TIMESTAMP,
  in_noi_dung in varchar,
  in_duyet in char
)
as
begin
  update binh_luan
  set
    id_tran_dau = in_id_tran_dau,
    username = in_username,
    thoi_diem = in_thoi_diem,
    noi_dung = in_noi_dung,
    duyet = in_duyet
  where
  (
    id_tran_dau = in_old_id_tran_dau
    and username = in_old_username
    and thoi_diem = in_old_thoi_diem
  );
  commit;
end;
/

create or replace
procedure getTranDau(out_cur out sys_refcursor)
is
begin
  open out_cur for
  select td.id, dt1.ten as doi_tuyen_1, dt2.ten as doi_tuyen_2, td.ti_so_hiep_chinh, td.ti_so_hiep_phu, td.ti_so_luan_luu
  from tran_dau td, doi_tuyen dt1, doi_tuyen dt2
  where td.id_doi_tuyen_1 = dt1.id and td.id_doi_tuyen_2 = dt2.id;
end;
/

create or replace
procedure getBinhLuan(in_id_tran_dau in VARCHAR2, out_cur out sys_refcursor)
is
begin
  open out_cur for
  select *
  from binh_luan
  where id_tran_dau = in_id_tran_dau;
end;
/

create or replace procedure view_ct(p_name in varchar2, b_day out date, num out int, pos out cau_thu.vi_tri_so_truong%type, m_num out int)
as
begin
select ngay_sinh,so_ao,vi_tri_so_truong,so_tran_doi_tuyen_quoc_gia into b_day,num,pos,m_num
from cau_thu
where ho_ten=p_name;
end;
/

create or replace procedure v_team(name in VARCHAR2, hlv out VARCHAR2)
as
id_dt char(5);
cursor cur is
select id from doi_tuyen where ten=name;
begin
open cur;
fetch cur into id_dt;
select ho_ten into hlv from huan_luyen_vien a,thoi_gian_huan_luyen b where
a.id = b.id_huan_luyen_vien_truong and b.id_doi_tuyen = id_dt and b.thoi_gian_ket_thuc is null;
end;
/

create or replace procedure v_team_for(name in VARCHAR2, dh out VARCHAR2)
as
id_dh char(5);
cursor cur is
select id_doi_hinh from doi_tuyen_tham_du where nam = 2014 and id_doi_tuyen in
(select id from doi_tuyen where ten = name);
begin
open cur;
fetch cur into id_dh;
select ten into dh from doi_hinh where id=id_dh;
end;
/

create or replace procedure champ_t(c_name in varchar2, num out int) as
begin
select SO_LAN_VO_DICH into num from doi_tuyen where ten=c_name;
end;
/

--tao view

create or replace procedure viewTranDau(out_cur out sys_refcursor)
is
begin
  open out_cur for
  select * from tran_dau;
end;
/

create or replace procedure viewPhatThe(out_cur out sys_refcursor)
is
begin
  open out_cur for
  select * from phat_the;
end;
/

create or replace procedure viewThayNguoi(out_cur out sys_refcursor)
is
begin
  open out_cur for
  select * from thay_nguoi;
end;
/

create or replace procedure viewBanThang(out_cur out sys_refcursor)
is
begin
  open out_cur for
  select * from ban_thang;
end;
/

create or replace procedure viewChonCauThuXuatSac(out_cur out sys_refcursor)
is
begin
  open out_cur for
  select * from chon_cau_thu_xuat_sac;
end;
/

create or replace procedure viewLuanLuu(out_cur out sys_refcursor)
is
begin
  open out_cur for
  select * from luan_luu;
end;
/

create or replace procedure viewDeoBangDoiTruong(out_cur out sys_refcursor)
is
begin
  open out_cur for
  select * from deo_bang_doi_truong;
end;
/

create or replace procedure viewDoiHinhXuatPhat(out_cur out sys_refcursor)
is
begin
  open out_cur for
  select * from doi_hinh_xuat_phat;
end;
/

--tao insert

--insert vao bang tran dau
create or replace procedure insertTranDau
(
 in_id in varchar2,
 in_loai_tran_dau in VARCHAR2,
 in_thoi_diem_bat_dau in TIMESTAMP,
 in_thoi_diem_ket_thuc in TIMESTAMP,
 in_id_san_van_dong in VARCHAR2,
 in_ti_so_hiep_chinh in VARCHAR2,
 in_ti_so_hiep_phu in VARCHAR2,
 in_ti_so_luan_luu in VARCHAR2,
 in_id_doi_tuyen_1 in VARCHAR2,
 in_id_doi_hinh_1 in VARCHAR2,
 in_id_doi_tuyen_2 in VARCHAR2,
 in_id_doi_hinh_2 in VARCHAR2)
as

begin
  insert into tran_dau
  values (in_id, in_loai_tran_dau, in_thoi_diem_bat_dau, in_thoi_diem_ket_thuc, in_id_san_van_dong, in_ti_so_hiep_chinh, in_ti_so_hiep_phu, in_ti_so_luan_luu, in_id_doi_tuyen_1, in_id_doi_hinh_1, in_id_doi_tuyen_2, in_id_doi_hinh_2);
  commit;
end;
/

--insert vao bang Phat The
create or replace procedure insertPhatThe
(
  in_id_su_kien in VARCHAR2,
  in_thoi_diem in TIMESTAMP,
  in_loai in VARCHAR2,
  in_id_cau_thu in VARCHAR2,
  in_id_tran_dau in VARCHAR2
)
as

begin
  insert into phat_the
  values (in_id_su_kien, in_thoi_diem, in_loai, in_id_cau_thu, in_id_tran_dau);
  commit;
end;
/

-- insert vao bang Ban Thang
create or replace procedure insertBanThang
(
  in_id_su_kien in VARCHAR2,
  in_thoi_diem in TIMESTAMP,
  in_phan_luoi in CHAR,
  in_id_cau_thu_chuyen in VARCHAR2,
  in_id_cau_thu_ghi_ban in VARCHAR2,
  in_id_tran_dau in VARCHAR2
)
as

begin
  insert into ban_thang
  values (in_id_su_kien, in_thoi_diem, in_phan_luoi, in_id_cau_thu_chuyen, in_id_cau_thu_ghi_ban, in_id_tran_dau);
  commit;
end;
/

--insert vao bang Chon Cau Thu Xuat Sac
create or replace procedure insertChonCauThuXuatSac
(
  in_id_su_kien in VARCHAR2,
  in_thoi_diem in TIMESTAMP,
  in_id_cau_thu in VARCHAR2,
  in_id_tran_dau in VARCHAR2
)
as

begin
  insert into chon_cau_thu_xuat_sac
  values (in_id_su_kien, in_thoi_diem, in_id_cau_thu, in_id_tran_dau);
  commit;
end;
/

--insert vao bang Thay Nguoi
create or replace procedure insertThayNguoi
(
  in_id_su_kien in VARCHAR2,
  in_thoi_diem in TIMESTAMP,
  in_id_cau_thu_ra_nghi in VARCHAR2,
  in_id_cau_thu_vao_thay in VARCHAR2,
  in_diem_cau_thu_vao_thay in NUMBER,
  in_id_tran_dau in VARCHAR2
)
as

begin
  insert into thay_nguoi
  values (in_id_su_kien, in_thoi_diem, in_id_cau_thu_ra_nghi, in_diem_cau_thu_vao_thay, in_diem_cau_thu_vao_thay, in_id_tran_dau);
  commit;
end;
/

--insert vao bang Luan Luu
create or replace procedure insertLuanLuu
(
  in_id_su_kien in VARCHAR2,
  in_thoi_diem in TIMESTAMP,
  in_so_thu_tu in NUMBER,
  in_id_cau_thu_thuc_hien in VARCHAR2,
  in_ket_qua CHAR,
  in_id_tran_dau in VARCHAR2
)
as

begin
  insert into luan_luu
  values (in_id_su_kien, in_thoi_diem, in_so_thu_tu, in_id_cau_thu_thuc_hien, in_ket_qua, in_id_tran_dau);
  commit;
end;
/

--insert vao bang Deo Bang Doi Truong
create or replace procedure insertDeoBangDoiTruong
(
  in_id_su_kien in VARCHAR2,
  in_thoi_diem in TIMESTAMP,
  in_id_cau_thu in VARCHAR2,
  in_id_tran_dau in VARCHAR2
)
as

begin
  insert into deo_bang_doi_truong
  values (in_id_su_kien, in_thoi_diem, in_id_cau_thu, in_id_tran_dau);
  commit;
end;
/

--insert vao bang Doi Hinh Xuat Phat
create or replace procedure insertDoiHinhXuatPhat
(
  in_id_su_kien in VARCHAR2,
  in_id_cau_thu in VARCHAR2,
  in_thoi_diem in TIMESTAMP,
  in_diem_cau_thu_xuat_phat in NUMBER,
  in_id_tran_dau in VARCHAR2
)
as

begin
  insert into doi_hinh_xuat_phat
  values (in_id_su_kien, in_id_cau_thu, in_thoi_diem, in_diem_cau_thu_xuat_phat, in_id_tran_dau);
  commit;
end;
/

--UPDATE
--update bang Tran Dau
create or replace procedure updateTranDau
(
 in_old_id in VARCHAR2,
 in_id in varchar2,
 in_loai_tran_dau in VARCHAR2,
 in_thoi_diem_bat_dau in TIMESTAMP,
 in_thoi_diem_ket_thuc in TIMESTAMP,
 in_id_san_van_dong in VARCHAR2,
 in_ti_so_hiep_chinh in VARCHAR2,
 in_ti_so_hiep_phu in VARCHAR2,
 in_ti_so_luan_luu in VARCHAR2,
 in_id_doi_tuyen_1 in VARCHAR2,
 in_id_doi_hinh_1 in VARCHAR2,
 in_id_doi_tuyen_2 in VARCHAR2,
 in_id_doi_hinh_2 in VARCHAR2)
as

begin
  update tran_dau
  set
    id = in_id,
    loai_tran_dau = in_loai_tran_dau,
    thoi_diem_bat_dau = in_thoi_diem_bat_dau,
    thoi_diem_ket_thuc = in_thoi_diem_ket_thuc,
    id_san_van_dong = in_id_san_van_dong,
    ti_so_hiep_chinh = in_ti_so_hiep_chinh,
    ti_so_hiep_phu = in_ti_so_hiep_phu,
    ti_so_luan_luu = in_ti_so_luan_luu,
    id_doi_tuyen_1 = in_id_doi_tuyen_1,
    id_doi_hinh_1 = in_id_doi_hinh_1,
    id_doi_tuyen_2 = in_id_doi_tuyen_2,
    id_doi_hinh_2 = in_id_doi_hinh_2
  where id = in_old_id;
  commit;
end;
/

--update bang Phat The
create or replace procedure updatePhatThe
(
  in_old_id_su_kien in VARCHAR2,
  in_id_su_kien in VARCHAR2,
  in_thoi_diem in TIMESTAMP,
  in_loai in VARCHAR2,
  in_id_cau_thu in VARCHAR2,
  in_id_tran_dau in VARCHAR2
)
as

begin
  update phat_the
  set
    id_su_kien = in_id_su_kien,
    thoi_diem = in_thoi_diem, 
    loai = in_loai,
    id_cau_thu = in_id_cau_thu,
    id_tran_dau = in_id_tran_dau
  where id_su_kien = in_old_id_su_kien;
  commit;
end;
/

--update Ban Thang
create or replace procedure updateBanThang
(
  in_old_id_su_kien in VARCHAR2,
  in_id_su_kien in VARCHAR2,
  in_thoi_diem in TIMESTAMP,
  in_phan_luoi in CHAR,
  in_id_cau_thu_chuyen in VARCHAR2,
  in_id_cau_thu_ghi_ban in VARCHAR2,
  in_id_tran_dau in VARCHAR2
)
as

begin
  UPDATE ban_thang
  set
    id_su_kien = in_id_su_kien,
    thoi_diem = in_thoi_diem,
    phan_luoi = in_phan_luoi,
    id_cau_thu_chuyen = in_id_cau_thu_chuyen,
    id_cau_thu_ghi_ban = in_id_cau_thu_ghi_ban,
    id_tran_dau = in_id_tran_dau
  where id_su_kien = in_old_id_su_kien;
  commit;
end;
/

--Update Chon Cau Thu Xuat Sac
create or replace procedure updateChonCauThuXuatSac
(
  in_old_id_su_kien in VARCHAR2,
  in_id_su_kien in VARCHAR2,
  in_thoi_diem in TIMESTAMP,
  in_id_cau_thu in VARCHAR2,
  in_id_tran_dau in VARCHAR2
)
as

begin
  update chon_cau_thu_xuat_sac
  set
    id_su_kien = in_id_su_kien,
    thoi_diem = in_thoi_diem,
    id_cau_thu = in_id_cau_thu,
    id_tran_dau = in_id_tran_dau
  where id_su_kien = in_old_id_su_kien;
  commit;
end;
/

--update Thay Nguoi
create or replace procedure updateThayNguoi
(
  in_old_id_su_kien in VARCHAR2,
  in_id_su_kien in VARCHAR2,
  in_thoi_diem in TIMESTAMP,
  in_id_cau_thu_ra_nghi in VARCHAR2,
  in_id_cau_thu_vao_thay in VARCHAR2,
  in_diem_cau_thu_vao_thay in NUMBER,
  in_id_tran_dau in VARCHAR2
)
as

begin
  update thay_nguoi
  set
    id_su_kien = in_id_su_kien,
    thoi_diem = in_thoi_diem,
    id_cau_thu_ra_nghi = in_id_cau_thu_ra_nghi,
    id_cau_thu_vao_thay = in_diem_cau_thu_vao_thay,
    diem_cau_thu_vao_thay = in_diem_cau_thu_vao_thay,
    id_tran_dau = in_id_tran_dau
  where id_su_kien = in_old_id_su_kien;
  commit;
end;
/

--update Luan Luu
create or replace procedure updateLuanLuu
(
  in_old_id_su_kien in VARCHAR2,
  in_id_su_kien in VARCHAR2,
  in_thoi_diem in TIMESTAMP,
  in_so_thu_tu in NUMBER,
  in_id_cau_thu_thuc_hien in VARCHAR2,
  in_ket_qua CHAR,
  in_id_tran_dau in VARCHAR2
)
as

begin
  UPDATE luan_luu
  set
    id_su_kien = in_id_su_kien,
    thoi_diem = in_thoi_diem,
    so_thu_tu = in_so_thu_tu,
    id_cau_thu_thuc_hien = in_id_cau_thu_thuc_hien,
    ket_qua = in_ket_qua,
    id_tran_dau = in_id_tran_dau
  where id_su_kien = in_old_id_su_kien;
  commit;
end;
/

--update Deo Bang Doi Truong
create or replace procedure updateDeoBangDoiTruong
(
  in_old_id_su_kien in VARCHAR2,
  in_id_su_kien in VARCHAR2,
  in_thoi_diem in TIMESTAMP,
  in_id_cau_thu in VARCHAR2,
  in_id_tran_dau in VARCHAR2
)
as

begin
  UPDATE deo_bang_doi_truong
  set
    id_su_kien = in_id_su_kien,
    thoi_diem = in_thoi_diem,
    id_cau_thu = in_id_cau_thu,
    id_tran_dau = in_id_tran_dau
  where id_su_kien = in_old_id_su_kien;
  commit;
end;
/

--update Doi Hinh Xuat Phat
create or replace procedure updateDoiHinhXuatPhat
(
  in_old_id_su_kien in VARCHAR2,
  in_id_su_kien in VARCHAR2,
  in_id_cau_thu in VARCHAR2,
  in_thoi_diem in TIMESTAMP,
  in_diem_cau_thu_xuat_phat in NUMBER,
  in_id_tran_dau in VARCHAR2
)
as

begin
  UPDATE doi_hinh_xuat_phat
  set
    id_su_kien = in_id_su_kien,
    id_cau_thu = in_id_cau_thu,
    thoi_diem = in_thoi_diem,
    diem_cau_thu_xuat_phat = in_diem_cau_thu_xuat_phat,
    id_tran_dau = in_id_tran_dau
  where id_su_kien = in_old_id_su_kien;
  commit;
end;
/

--DELETE
--delete 1 dong trong bang tran dau
create or replace PROCEDURE deleteTranDau(in_id in VARCHAR2)
as
begin
  delete from tran_dau
  where ID = in_id;
  commit;
end;
/

--delete 1 dong trong bang Phat The
create or replace PROCEDURE deletePhatThe(in_id_su_kien in VARCHAR2)
as
begin
  delete from phat_the
  where id_su_kien = in_id_su_kien;
  commit;
end;
/

--delete 1 dong trong bang Ban Thang
create or replace PROCEDURE deleteBanThang(in_id_su_kien in VARCHAR2)
as
begin
  delete from ban_thang
  where id_su_kien = in_id_su_kien;
  commit;
end;
/

--delete 1 dong trong bang Chon Cau Thu Xuat Sac
create or replace PROCEDURE deleteChonCauThuXuatSac(in_id_su_kien in VARCHAR2)
as
begin
  delete from chon_cau_thu_xuat_sac
  where id_su_kien = in_id_su_kien;
  commit;
end;
/

--delete 1 dong trong bang Thay Nguoi
create or replace PROCEDURE deleteThayNguoi(in_id_su_kien in VARCHAR2)
as
begin
  delete from thay_nguoi
  where id_su_kien = in_id_su_kien;
  commit;
end;
/

--delete 1 dong trong bang Luan Luu
create or replace PROCEDURE deleteLuanLuu(in_id_su_kien in VARCHAR2)
as
begin
  delete from luan_luu
  where id_su_kien = in_id_su_kien;
  commit;
end;
/

--delete 1 dong trong bang Deo Bang Doi Truong
create or replace PROCEDURE deleteDeoBangDoiTruong(in_id_su_kien in VARCHAR2)
as
begin
  delete from deo_bang_doi_truong
  where id_su_kien = in_id_su_kien;
  commit;
end;
/

--delete 1 dong trong bang Doi Hinh Xuat Phat
create or replace PROCEDURE deleteDoiHinhXuatPhat(in_id_su_kien in VARCHAR2, in_id_cau_thu in VARCHAR2)
as
begin
  delete from doi_hinh_xuat_phat
  where id_su_kien = in_id_su_kien AND id_cau_thu = in_id_cau_thu;
  commit;
end;