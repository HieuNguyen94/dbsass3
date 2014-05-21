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
and upper(quan_ly_doi_bong.USERNAME)=upper(uname) 
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
grant execute on deleteQuanLyDoiBong to Admin;
grant execute on deleteTaiKhoan to Admin;
grant execute on deleteWorldCup to Admin;

grant execute on insertQuanLyDoiBong to Admin;
grant execute on insertTaiKhoan to Admin;
grant execute on insertWorldCup to Admin;

grant execute on updateQuanLyDoiBong to Admin;
grant execute on updateTaiKhoan to Admin;
grant execute on updateWorldCup to Admin;

grant execute on viewQuanLyDoiBong to Admin;
grant execute on viewTaiKhoan to Admin;
grant execute on viewWorldCup to Admin;



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

create or replace PROCEDURE deleteBinhLuan
(
  in_id_tran_dau in VARCHAR2,
  in_username in VARCHAR2,
  in_thoi_diem in timestamp
)
as
begin
  delete from binh_luan
  where id_tran_dau = in_id_tran_dau and username = in_username and thoi_diem = in_thoi_diem;
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

grant execute on viewBinhLuan to Admin;
grant execute on insertBinhLuan to Admin;
grant execute on deleteBinhLuan to Admin;
grant execute on updateBinhLuan to Admin;

grant execute on viewTranDau to Admin;


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
select a.ho_ten into hlv from huan_luyen_vien a,thoi_gian_huan_luyen b where
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

create or replace procedure v_dt_thamdu(name in varchar2, curs out SYS_REFCURSOR)
as
id_dt char(5);
cursor cur is
select id from doi_tuyen where ten=name;
begin
open cur;
fetch cur into id_dt;
open curs for
select * from doi_tuyen_tham_du where id_doi_tuyen = id_dt;
end;
/

create or replace procedure captain(name in varchar2, curs out SYS_REFCURSOR)
as
id_dt char(5);
cursor cur is
select id from doi_tuyen where ten=name;
begin
open cur;
fetch cur into id_dt;
open curs for
select * from doi_truong where id_doi_tuyen = id_dt;
end;
/

create or replace procedure trandau(name in varchar2, curs out SYS_refcursor)
as
id_dt char(5);
cursor cur is
select id from doi_tuyen where ten=name;
begin
open cur;
fetch cur into id_dt;
open curs for
select * from tran_dau where id_doi_tuyen_1=id_dt or id_doi_tuyen_2=id_dt;
end;
/

create or replace PROCEDURE deleteTeam(id_dt in VARCHAR2, y in int)
as
begin
  delete from doi_tuyen_tham_du
  where id_doi_tuyen =id_dt and nam=y;
  commit;
end;
/

create or replace PROCEDURE deleteMatch(id_td in VARCHAR2)
as
begin
  delete from tran_dau
  where id =id_td;
  commit;
end;
/

create or replace PROCEDURE deleteCap(id_ct in varchar2, id_dt in varchar2, st in timestamp, fi in TIMESTAMP)
as
begin
  delete from doi_truong
  where  id_cau_thu=id_ct and id_doi_tuyen=id_dt and bat_dau=st and ket_thuc=fi;
  commit;
end;
/

create or replace procedure insertTeam(in_id in doi_tuyen_tham_du.id_doi_tuyen%type,in_nam in doi_tuyen_tham_du.nam%type, 
in_ao_1 in varchar2, in_ao_2 in varchar2,in_dh in doi_tuyen_tham_du.id_doi_hinh%type)
as
begin
insert into doi_tuyen_tham_du values (in_id, in_nam, in_ao_1, in_ao_2,in_dh);
commit;
end;
/

create or replace procedure insertMatch(in_id in tran_dau.id%type,in_loai in tran_dau.loai_tran_dau%type, 
in_st in timestamp, in_fi in timestamp,in_svd in tran_dau.id_san_van_dong%type, in_ma in varchar2, in_ex in varchar2, 
in_pen in varchar2, in_dt1 in varchar2, in_dh1 in varchar2, in_dt2 in varchar2,in_dh2 in varchar2)
as
begin
insert into tran_dau values (in_id,in_loai,in_st, in_fi,in_svd, in_ma , in_ex, in_pen, in_dt1, in_dh1, in_dt2,in_dh2);
commit;
end;
/

create or replace procedure insertCap(in_id1 in varchar2,in_id2 in varchar2,in_st in date, in_fi in date)
as
begin
insert into doi_truong values (in_id1,in_id2,in_st, in_fi);
commit;
end;
/

create or replace procedure updateCap(in_old_id1 in varchar2,in_old_id2 in varchar2,in_old_st in date, in_old_fi in date,in_id1 in varchar2,in_id2 in varchar2,in_st in date, in_fi in date)
as
begin
update doi_truong
set
id_cau_thu=in_id1,id_doi_tuyen=in_id2,bat_dau=in_st,ket_thuc=in_fi
where 
(id_cau_thu=in_old_id1 and id_doi_tuyen=in_old_id2 and bat_dau=in_old_st and ket_thuc=in_old_fi);
commit;
end;
/

create or replace procedure updateMatch(in_old_id in tran_dau.id%type,in_id in tran_dau.id%type,in_loai in tran_dau.loai_tran_dau%type, 
in_st in timestamp, in_fi in timestamp,in_svd in tran_dau.id_san_van_dong%type, in_ma in varchar2, in_ex in varchar2, 
in_pen in varchar2, in_dt1 in varchar2, in_dh1 in varchar2, in_dt2 in varchar2,in_dh2 in varchar2)
as
begin
update tran_dau
set id=in_id, loai_tran_dau=in_loai, thoi_diem_bat_dau=in_st, thoi_diem_ket_thuc=in_fi, id_san_van_dong=in_svd, ti_so_hiep_chinh=in_ma, 
ti_so_hiep_phu=in_ex, ti_so_luan_luu=in_pen, id_doi_tuyen_1=in_dt1, id_doi_hinh_1=in_dh1, id_doi_tuyen_2=in_dt2, id_doi_hinh_2=in_dh2
where id=in_old_id;
commit;
end;
/

create or replace procedure updateTeam(in_old_id in doi_tuyen_tham_du.id_doi_tuyen%type,in_old_nam in doi_tuyen_tham_du.nam%type,
in_id in doi_tuyen_tham_du.id_doi_tuyen%type,in_nam in doi_tuyen_tham_du.nam%type, in_ao_1 in varchar2, 
in_ao_2 in varchar2,in_dh in doi_tuyen_tham_du.id_doi_hinh%type)
as
begin
update doi_tuyen_tham_du
set id_doi_tuyen=in_id, nam=in_nam, ao_1=in_ao_1, ao_2=in_ao_2,id_doi_hinh=in_dh
where id_doi_tuyen=in_old_id and nam=in_old_nam;
commit;
end;
/

grant execute on champ_t to TeamManager;
grant execute on view_ct to TeamManager;
grant execute on v_team to TeamManager;
grant execute on v_dt_thamdu to TeamManager;
grant execute on captain to TeamManager;
grant execute on trandau to TeamManager;
grant execute on deleteTeam to TeamManager;
grant execute on deleteCap to TeamManager;
grant execute on deleteMatch to TeamManager;
grant execute on insertTeam to TeamManager;
grant execute on insertCap to TeamManager;
grant execute on insertMatch to TeamManager;
grant execute on v_team_for to TeamManager;
grant execute on quan_ly to TeamManager;
grant execute on updateCap to TeamManager;
grant execute on updateMatch to TeamManager;
grant execute on updateTeam to TeamManager;
grant execute on show_country_flag to TeamManager;
