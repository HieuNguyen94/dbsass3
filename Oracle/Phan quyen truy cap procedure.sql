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
grant execute on view_ct to TeamManager;
grant execute on v_team to TeamManager;
grant execute on v_team_for to TeamManager;
grant execute on champ_t to TeamManager;

-- Phan quyen su dung procedure cho Client
grant execute on getTranDau to Client;
grant execute on getBinhLuan to Client;
grant execute on insertBinhLuan to Client;
grant execute on viewWorldCup to Client;
grant execute on viewDoiTuyen to Client;
grant execute on viewCauThu to Client;
grant execute on viewHLV to Client;
grant execute on viewTranDau_clientMode to Client;
grant execute on viewSuKien to Client;
grant execute on viewBinhLuan_clientMode to Client;

-- Phan quyen su dung procedure cho TeamManager
grant execute on view_ct to TeamManager;

-- Phan quyen su dung procedure cho Reporter

GRANT EXECUTE ON VIEWTRANDAU TO Reporter;
GRANT EXECUTE ON VIEWPHATTHE TO Reporter;
GRANT EXECUTE ON VIEWBANTHANG TO Reporter;
GRANT EXECUTE ON VIEWCHONCAUTHUXUATSAC TO Reporter;
GRANT EXECUTE ON VIEWTHAYNGUOI TO Reporter;
GRANT EXECUTE ON VIEWLUANLUU TO Reporter;
GRANT EXECUTE ON VIEWDEOBANGDOITRUONG TO Reporter;
GRANT EXECUTE ON VIEWDOIHINHXUATPHAT TO Reporter;
GRANT EXECUTE ON VIEWBINHLUAN TO Reporter;

--GAN QUYEN THEM VAO CAC BANG CHO REPORTER
GRANT EXECUTE ON INSERTTRANDAU TO Reporter;
GRANT EXECUTE ON INSERTPHATTHE TO Reporter;
GRANT EXECUTE ON INSERTBANTHANG TO Reporter;
GRANT EXECUTE ON INSERTCHONCAUTHUXUATSAC TO Reporter;
GRANT EXECUTE ON INSERTTHAYNGUOI TO Reporter;
GRANT EXECUTE ON INSERTLUANLUU TO Reporter;
GRANT EXECUTE ON INSERTDEOBANGDOITRUONG TO Reporter;
GRANT EXECUTE ON INSERTDOIHINHXUATPHAT TO Reporter;

--GAN QUYEN SUA CAC BANG CHO REPORTER
GRANT EXECUTE ON UPDATETRANDAU TO Reporter;
GRANT EXECUTE ON UPDATEPHATTHE TO Reporter;
GRANT EXECUTE ON UPDATEBANTHANG TO Reporter;
GRANT EXECUTE ON UPDATECHONCAUTHUXUATSAC TO Reporter;
GRANT EXECUTE ON UPDATETHAYNGUOI TO Reporter;
GRANT EXECUTE ON UPDATELUANLUU TO Reporter;
GRANT EXECUTE ON UPDATEDEOBANGDOITRUONG TO Reporter;
GRANT EXECUTE ON UPDATEDOIHINHXUATPHAT TO Reporter;
GRANT EXECUTE ON UPDATEBINHLUAN TO Reporter;

--GAN QUYEN XOA CAC DONG TRONG BANG CHO REPORTER
GRANT EXECUTE ON DELETETRANDAU TO Reporter;
GRANT EXECUTE ON DELETEPHATTHE TO Reporter;
GRANT EXECUTE ON DELETEBANTHANG TO Reporter;
GRANT EXECUTE ON DELETECHONCAUTHUXUATSAC TO Reporter;
GRANT EXECUTE ON DELETETHAYNGUOI TO Reporter;
GRANT EXECUTE ON DELETELUANLUU TO Reporter;
GRANT EXECUTE ON DELETEDEOBANGDOITRUONG TO Reporter;
GRANT EXECUTE ON DELETEDOIHINHXUATPHAT TO Reporter;


