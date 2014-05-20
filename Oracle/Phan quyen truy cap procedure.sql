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

-- Phan quyen su dung procedure cho Client
grant execute on getTranDau to Client;
grant execute on getBinhLuan to Client;
grant execute on insertBinhLuan to Client;

-- Phan quyen su dung procedure cho TeamManager
grant execute on view_ct to TeamManager;