create table TAI_KHOAN
(
USERNAME VARCHAR(30),
PASSWORD VARCHAR(30) NOT NULL,
LOAI_TAI_KHOAN VARCHAR(15) NOT NULL,
PRIMARY KEY(USERNAME)
);

INSERT INTO TAI_KHOAN VALUES ('Admin_1','Nhom3','Admin');
INSERT INTO TAI_KHOAN VALUES ('Admin_2','Nhom3','Admin');
INSERT INTO TAI_KHOAN VALUES ('TeamManager_Eng','Nhom3','TeamManager');
INSERT INTO TAI_KHOAN VALUES ('TeamManager_Ned','Nhom3','TeamManager');
INSERT INTO TAI_KHOAN VALUES ('TeamManager_Bra','Nhom3','TeamManager');
INSERT INTO TAI_KHOAN VALUES ('TeamManager_Spa','Nhom3','TeamManager');
INSERT INTO TAI_KHOAN VALUES ('nhabao_1','Nhom3','Reporter');
INSERT INTO TAI_KHOAN VALUES ('nhabao_2','Nhom3','Reporter');
INSERT INTO TAI_KHOAN VALUES ('nhabao_3','Nhom3','Reporter');
INSERT INTO TAI_KHOAN VALUES ('nhabao_4','Nhom3','Reporter');
INSERT INTO TAI_KHOAN VALUES ('client_1','Nhom3','Client');
INSERT INTO TAI_KHOAN VALUES ('client_2','Nhom3','Client');
INSERT INTO TAI_KHOAN VALUES ('client_3','Nhom3','Client');
INSERT INTO TAI_KHOAN VALUES ('client_4','Nhom3','Client');

create table QUAN_LY_DOI_BONG 
(
USERNAME VARCHAR(30),
ID_DOI_TUYEN CHAR(5) CHECK (REGEXP_LIKE(ID_DOI_TUYEN,'DT[0-9]{3}')),
PRIMARY KEY (USERNAME,ID_DOI_TUYEN),
FOREIGN KEY (USERNAME) REFERENCES TAI_KHOAN(USERNAME),
FOREIGN KEY (ID_DOI_TUYEN) REFERENCES DOI_TUYEN(ID)
);

INSERT INTO QUAN_LY_DOI_BONG VALUES ('TeamManager_Eng','DT001');
INSERT INTO QUAN_LY_DOI_BONG VALUES ('TeamManager_Ned','DT002');
INSERT INTO QUAN_LY_DOI_BONG VALUES ('TeamManager_Bra','DT003');
INSERT INTO QUAN_LY_DOI_BONG VALUES ('TeamManager_Spa','DT004');

create table BINH_LUAN
(
ID_TRAN_DAU CHAR(7)     CHECK (REGEXP_LIKE(ID_TRAN_DAU,'TD[0-9]{5}')),
USERNAME VARCHAR(30),
THOI_DIEM  TIMESTAMP,
NOI_DUNG VARCHAR(4000),
DUYET CHAR CHECK(DUYET IN('Y','N','-')),
PRIMARY KEY (ID_TRAN_DAU, USERNAME, THOI_DIEM),
FOREIGN KEY (ID_TRAN_DAU) REFERENCES TRAN_DAU(ID),
FOREIGN KEY (USERNAME) REFERENCES TAI_KHOAN(USERNAME)
);

-----------------------------------------------------------------------------------------------
-------NEW Table SU KIEN-----------------------------------------------------------------------
-----------------------------------------------------------------------------------------------
--CREATE TABLE SU_KIEN
CREATE TABLE SU_KIEN
(
ID_SU_KIEN                    CHAR(8)     CHECK (REGEXP_LIKE(ID_SU_KIEN,'SK[0-9]{6}')),
ID_TRAN_DAU                   CHAR(7),
THOI_DIEM                     TIMESTAMP,
MO_TA                         VARCHAR(200),
PRIMARY KEY (ID_SU_KIEN),
FOREIGN KEY (ID_TRAN_DAU) REFERENCES TRAN_DAU(ID)
);
-----------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------


----------------------------------------------------------------------------------------------------------------
-------NEW Tao TRIGGER------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------
--TRIGGER SK_BAN_THANG
create or replace TRIGGER SK_BAN_THANG
AFTER INSERT OR DELETE OR UPDATE ON BAN_THANG
FOR EACH ROW
declare
X VARCHAR(20);
Y VARCHAR(20);
BEGIN
if(INSERTING OR UPDATING) THEN
  IF(UPDATING) THEN
     DELETE FROM SU_KIEN
     WHERE :OLD.ID_SU_KIEN = SU_KIEN.ID_SU_KIEN;
  END IF;
  SELECT DISTINCT CT.HO_TEN, DT.TEN INTO X, Y
  FROM CAU_THU CT, DOI_TUYEN DT, GOI_LEN_TUYEN G
  WHERE CT.ID = :NEW.ID_CAU_THU_GHI_BAN AND CT.ID = G.ID_CAU_THU AND DT.ID = G.ID_DOI_TUYEN;
  IF(:NEW.PHAN_LUOI = 'N') THEN
    INSERT INTO SU_KIEN
    VALUES (:NEW.ID_SU_KIEN,:NEW.ID_TRAN_DAU,:NEW.THOI_DIEM, CONCAT('VAOOO! ',CONCAT(CAST(X as varchar(20)),CONCAT(' da ghi ban cho doi ',CAST(Y as varchar(20))))));
  ELSE
    INSERT INTO SU_KIEN
    VALUES (:NEW.ID_SU_KIEN,:NEW.ID_TRAN_DAU,:NEW.THOI_DIEM, CONCAT('VAOOO! ',CONCAT(CAST(X as varchar(20)),CONCAT(' cua doi ',CONCAT(CAST(Y as varchar(20)),' vua da phan luoi nha')))));
  END IF;
ELSIF(DELETING) THEN
  DELETE FROM SU_KIEN
  WHERE :OLD.ID_SU_KIEN = SU_KIEN.ID_SU_KIEN;
END IF;
END;
/
--TRIGGER SK_PHAT_THE
create or replace TRIGGER SK_PHAT_THE
AFTER INSERT OR DELETE OR UPDATE ON PHAT_THE
FOR EACH ROW
declare
X VARCHAR(20);
Y VARCHAR(20);
BEGIN
if(INSERTING OR UPDATING) THEN
  IF(UPDATING) THEN
     DELETE FROM SU_KIEN
     WHERE :OLD.ID_SU_KIEN = SU_KIEN.ID_SU_KIEN;
  END IF;
  SELECT DISTINCT CT.HO_TEN, DT.TEN INTO X, Y
  FROM CAU_THU CT, DOI_TUYEN DT, GOI_LEN_TUYEN G
  WHERE CT.ID = :NEW.ID_CAU_THU AND CT.ID = G.ID_CAU_THU AND DT.ID = G.ID_DOI_TUYEN;
  IF(:NEW.LOAI = 'Y') THEN
    INSERT INTO SU_KIEN
    VALUES (:NEW.ID_SU_KIEN,:NEW.ID_TRAN_DAU,:NEW.THOI_DIEM, CONCAT('Cau thu ',CONCAT(CAST(X as varchar(20)),CONCAT(' cua doi ',CONCAT(CAST(Y as varchar(20)),' vua phai nhan the VANG')))));
  ELSE
    INSERT INTO SU_KIEN
    VALUES (:NEW.ID_SU_KIEN,:NEW.ID_TRAN_DAU,:NEW.THOI_DIEM, CONCAT('Oi khong! Cau thu ',CONCAT(CAST(X as varchar(20)),CONCAT(' cua doi ',CONCAT(CAST(Y as varchar(20)),' vua phai nhan the DO va roi san')))));
  END IF;
ELSIF(DELETING) THEN
  DELETE FROM SU_KIEN
  WHERE :OLD.ID_SU_KIEN = SU_KIEN.ID_SU_KIEN;
END IF;
END;
/
--TRIGGER SK_THAY_NGUOI
create or replace TRIGGER SK_THAY_NGUOI
AFTER INSERT OR DELETE OR UPDATE ON THAY_NGUOI
FOR EACH ROW
declare
X VARCHAR(20);
Y VARCHAR(20);
Z VARCHAR(20);
BEGIN
if(INSERTING OR UPDATING) THEN
  IF(UPDATING) THEN
     DELETE FROM SU_KIEN
     WHERE :OLD.ID_SU_KIEN = SU_KIEN.ID_SU_KIEN;
  END IF;
  SELECT DISTINCT CT.HO_TEN,CT2.HO_TEN,DT.TEN INTO X, Y, Z
  FROM CAU_THU CT, CAU_THU CT2, DOI_TUYEN DT, GOI_LEN_TUYEN G
  WHERE CT.ID = :NEW.ID_CAU_THU_RA_NGHI 
  AND   CT2.ID = :NEW.ID_CAU_THU_VAO_THAY 
  AND   CT.ID = G.ID_CAU_THU
  AND   DT.ID = G.ID_DOI_TUYEN;
  INSERT INTO SU_KIEN
  VALUES (:NEW.ID_SU_KIEN,:NEW.ID_TRAN_DAU,:NEW.THOI_DIEM, CONCAT('Doi tuyen ',CONCAT(CAST(Z as varchar(20)),CONCAT(' vua co su thay doi nguoi. ',CONCAT(CAST(Y as varchar(20)),CONCAT(' vao thay cho ',CAST(X as varchar(20))))))));
ELSIF(DELETING) THEN
  DELETE FROM SU_KIEN
  WHERE :OLD.ID_SU_KIEN = SU_KIEN.ID_SU_KIEN;
END IF;
END;
/
--TRIGGER SK_LUAN_LUU
create or replace TRIGGER SK_LUAN_LUU
AFTER INSERT OR DELETE OR UPDATE ON LUAN_LUU
FOR EACH ROW
declare
X VARCHAR(20);
Y VARCHAR(20);
BEGIN
if(INSERTING OR UPDATING) THEN
  IF(UPDATING) THEN
     DELETE FROM SU_KIEN
     WHERE :OLD.ID_SU_KIEN = SU_KIEN.ID_SU_KIEN;
  END IF;
  SELECT DISTINCT CT.HO_TEN, DT.TEN INTO X, Y
  FROM CAU_THU CT, DOI_TUYEN DT, GOI_LEN_TUYEN G
  WHERE CT.ID = :NEW.ID_CAU_THU_THUC_HIEN AND CT.ID = G.ID_CAU_THU AND DT.ID = G.ID_DOI_TUYEN;
  IF(:NEW.KET_QUA = 'Y') THEN
    INSERT INTO SU_KIEN
    VALUES (:NEW.ID_SU_KIEN,:NEW.ID_TRAN_DAU,:NEW.THOI_DIEM, CONCAT('VAOOO! Cau thu ',CONCAT(CAST(X as varchar(20)),CONCAT(' cua doi ',CONCAT(CAST(Y as varchar(20)),' vua thuc hien THANH CONG luot da luan luu 11M')))));
  ELSE
    INSERT INTO SU_KIEN
    VALUES (:NEW.ID_SU_KIEN,:NEW.ID_TRAN_DAU,:NEW.THOI_DIEM, CONCAT('Rat tiec! Cau thu ',CONCAT(CAST(X as varchar(20)),CONCAT(' cua doi ',CONCAT(CAST(Y as varchar(20)),' da thuc hien KHONG THANH CONG luot da luan luu 11M')))));
  END IF;
ELSIF(DELETING) THEN
  DELETE FROM SU_KIEN
  WHERE :OLD.ID_SU_KIEN = SU_KIEN.ID_SU_KIEN;
END IF;
END;
/