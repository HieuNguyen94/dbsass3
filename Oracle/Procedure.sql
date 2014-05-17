-- Lay thong tin doi tuyen cho truoc id (TeamManager)
create or replace PROCEDURE getDoiTuyen(ID_INPUT VARCHAR2, 
OUT_CURSOR OUT SYS_REFCURSOR)
IS 
BEGIN
  OPEN out_cursor FOR
  SELECT * FROM DOI_TUYEN
  WHERE ID = ID_INPUT;
END;

-- Cap nhat loai tai khoan (Admin)
create or replace PROCEDURE updateTaiKhoan(USERNAME_INPUT VARCHAR2, NEW_LOAI_TAI_KHOAN VARCHAR2)
AS
BEGIN
  UPDATE TAI_KHOAN
  SET LOAI_TAI_KHOAN = NEW_LOAI_TAI_KHOAN
  WHERE USERNAME = USERNAME_INPUT;
  COMMIT;
END;

-- Xem thong tin bang tai khoang (Admin)
create or replace PROCEDURE viewTaiKhoan(OUT_CURSOR OUT SYS_REFCURSOR)
AS
BEGIN
  OPEN OUT_CURSOR FOR
  SELECT *
  FROM TAI_KHOAN;
END;