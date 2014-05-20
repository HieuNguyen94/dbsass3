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
(select id from doi_tuyen where ten = nam);
begin
open cur;
fetch cur into id_dh;
select ten into dh from doi_hinh where id=id_dh;
end;
/