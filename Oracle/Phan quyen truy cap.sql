-- Tao user bang tai khoan [system]
CREATE USER Admin IDENTIFIED BY Nhom3;
CREATE USER TeamManager IDENTIFIED BY Nhom3;
CREATE USER Reporter IDENTIFIED BY Nhom3;
CREATE USER Client IDENTIFIED BY Nhom3;
GRANT GRANT ANY PRIVILEGE TO hr;

-- Phan quyen truy cap, su dung bang tai khoan [hr]
-- Gan quuyen ket noi vao CSDL
GRANT CREATE SESSION TO Admin;
GRANT CREATE SESSION TO TeamManager;
GRANT CREATE SESSION TO Reporter;
GRANT CREATE SESSION TO Client;

-- Gan quyen cho admin tren tat ca cac bang
GRANT SELECT, INSERT, DELETE, UPDATE ON HUAN_LUYEN_VIEN TO Admin;                
GRANT SELECT, INSERT, DELETE, UPDATE ON CAU_THU TO Admin;                        
GRANT SELECT, INSERT, DELETE, UPDATE ON KHACH_SAN TO Admin;                      
GRANT SELECT, INSERT, DELETE, UPDATE ON DOI_TUYEN TO Admin;                      
GRANT SELECT, INSERT, DELETE, UPDATE ON WORLD_CUP TO Admin;                      
GRANT SELECT, INSERT, DELETE, UPDATE ON DOI_HINH TO Admin;                       
GRANT SELECT, INSERT, DELETE, UPDATE ON SAN_VAN_DONG TO Admin;                   
GRANT SELECT, INSERT, DELETE, UPDATE ON LOAI_TRAN_DAU TO Admin;                  
GRANT SELECT, INSERT, DELETE, UPDATE ON TRAN_DAU TO Admin;                       
GRANT SELECT, INSERT, DELETE, UPDATE ON DOI_TUYEN_THAM_DU TO Admin;              
GRANT SELECT, INSERT, DELETE, UPDATE ON PHAT_THE TO Admin;                       
GRANT SELECT, INSERT, DELETE, UPDATE ON BAN_THANG TO Admin;                      
GRANT SELECT, INSERT, DELETE, UPDATE ON CHON_CAU_THU_XUAT_SAC TO Admin;          
GRANT SELECT, INSERT, DELETE, UPDATE ON THAY_NGUOI TO Admin;                     
GRANT SELECT, INSERT, DELETE, UPDATE ON LUAN_LUU TO Admin;                       
GRANT SELECT, INSERT, DELETE, UPDATE ON DEO_BANG_DOI_TRUONG TO Admin;            
GRANT SELECT, INSERT, DELETE, UPDATE ON DOI_HINH_XUAT_PHAT TO Admin;             
GRANT SELECT, INSERT, DELETE, UPDATE ON PHU_TA TO Admin;                         
GRANT SELECT, INSERT, DELETE, UPDATE ON GOI_LEN_TUYEN TO Admin;                  
GRANT SELECT, INSERT, DELETE, UPDATE ON DOI_TRUONG TO Admin;                     
GRANT SELECT, INSERT, DELETE, UPDATE ON O_KHACH_SAN TO Admin;                    
GRANT SELECT, INSERT, DELETE, UPDATE ON VUA_PHA_LUOI TO Admin;                   
GRANT SELECT, INSERT, DELETE, UPDATE ON HUAN_LUYEN TO Admin;                     
GRANT SELECT, INSERT, DELETE, UPDATE ON THOI_GIAN_HUAN_LUYEN TO Admin;           
GRANT SELECT, INSERT, DELETE, UPDATE ON TAI_KHOAN TO Admin;                      
GRANT SELECT, INSERT, DELETE, UPDATE ON QUAN_LY_DOI_BONG TO Admin;
GRANT SELECT, INSERT, DELETE, UPDATE ON BINH_LUAN TO Admin;

-- Gan quyen cho TeamManager tren cac bang co lien quan den doi bong (chua id doi bong)
GRANT SELECT, INSERT, DELETE, UPDATE ON WORLD_CUP TO TeamManager;
GRANT SELECT, INSERT, DELETE, UPDATE ON DOI_TUYEN TO TeamManager;
GRANT SELECT, INSERT, DELETE, UPDATE ON DOI_TUYEN_THAM_DU TO TeamManager;
GRANT SELECT, INSERT, DELETE, UPDATE ON GOI_LEN_TUYEN TO TeamManager;
GRANT SELECT, INSERT, DELETE, UPDATE ON DOI_TRUONG TO TeamManager;
GRANT SELECT, INSERT, DELETE, UPDATE ON O_KHACH_SAN TO TeamManager;
GRANT SELECT, INSERT, DELETE, UPDATE ON HUAN_LUYEN TO TeamManager;
GRANT SELECT, INSERT, DELETE, UPDATE ON THOI_GIAN_HUAN_LUYEN TO TeamManager;

-- Gan quyen cho Report tren cac bang co lien quan den tran dau (chua id tran dau)
GRANT SELECT, INSERT, DELETE, UPDATE ON TRAN_DAU TO Reporter;
GRANT SELECT, INSERT, DELETE, UPDATE ON PHAT_THE TO Reporter;
GRANT SELECT, INSERT, DELETE, UPDATE ON BAN_THANG TO Reporter;
GRANT SELECT, INSERT, DELETE, UPDATE ON CHON_CAU_THU_XUAT_SAC TO Reporter;
GRANT SELECT, INSERT, DELETE, UPDATE ON THAY_NGUOI TO Reporter;
GRANT SELECT, INSERT, DELETE, UPDATE ON LUAN_LUU TO Reporter;
GRANT SELECT, INSERT, DELETE, UPDATE ON DEO_BANG_DOI_TRUONG TO Reporter;
GRANT SELECT, INSERT, DELETE, UPDATE ON DOI_HINH_XUAT_PHAT TO Reporter;
GRANT SELECT, DELETE ON BINH_LUAN TO Reporter;
GRANT UPDATE(DUYET) ON BINH_LUAN TO Reporter;

-- Gan quyen cho Client
GRANT SELECT ON HUAN_LUYEN_VIEN TO Client;                
GRANT SELECT ON CAU_THU TO Client;                        
GRANT SELECT ON KHACH_SAN TO Client;                      
GRANT SELECT ON DOI_TUYEN TO Client;                      
GRANT SELECT ON WORLD_CUP TO Client;                      
GRANT SELECT ON DOI_HINH TO Client;                       
GRANT SELECT ON SAN_VAN_DONG TO Client;                   
GRANT SELECT ON LOAI_TRAN_DAU TO Client;                  
GRANT SELECT ON TRAN_DAU TO Client;                       
GRANT SELECT ON DOI_TUYEN_THAM_DU TO Client;              
GRANT SELECT ON PHAT_THE TO Client;                       
GRANT SELECT ON BAN_THANG TO Client;                      
GRANT SELECT ON CHON_CAU_THU_XUAT_SAC TO Client;          
GRANT SELECT ON THAY_NGUOI TO Client;                     
GRANT SELECT ON LUAN_LUU TO Client;                       
GRANT SELECT ON DEO_BANG_DOI_TRUONG TO Client;            
GRANT SELECT ON DOI_HINH_XUAT_PHAT TO Client;             
GRANT SELECT ON PHU_TA TO Client;                         
GRANT SELECT ON GOI_LEN_TUYEN TO Client;                  
GRANT SELECT ON DOI_TRUONG TO Client;                     
GRANT SELECT ON O_KHACH_SAN TO Client;                    
GRANT SELECT ON VUA_PHA_LUOI TO Client;                   
GRANT SELECT ON HUAN_LUYEN TO Client;                     
GRANT SELECT ON THOI_GIAN_HUAN_LUYEN TO Client;           
GRANT SELECT ON TAI_KHOAN TO Client;                      
GRANT SELECT ON QUAN_LY_DOI_BONG TO Client;
GRANT SELECT, INSERT, DELETE, UPDATE ON BINH_LUAN TO Client;

-- Phan quyen su dung procedure cho Admin
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

grant execute on viewBinhLuan to Admin;
grant execute on insertBinhLuan to Admin;
grant execute on deleteBinhLuan to Admin;
grant execute on updateBinhLuan to Admin;

grant execute on viewTranDau to Admin;
-- Phan quyen su dung procedure cho TeamManager
grant execute on quan_ly to TeamManager;