USE JobPlacementCenter;
GO

-- =============================================
-- DỮ LIỆU MẪU (Sample Data)
 --) Chức năng hệ thống & Vai trò (tiếng Việt)
 -- Dữ liệu mẫu cho bảng VaiTro
 INSERT INTO VaiTro (vai_tro_id, ten_vai_tro) VALUES
 ('CSS', N'Chuyên viên hỗ trợ ứng viên'),
 ('ERS', N'Chuyên viên quan hệ doanh nghiệp'),
 ('FO',  N'Nhân viên tài chính'),
 ('SA',  N'Quản trị hệ thống'),
 ('CM',  N'Quản lý trung tâm');
 
 -- Dữ liệu mẫu cho bảng ChucNang (mã + tên + mô tả)
INSERT INTO ChucNang (chuc_nang_id, ten_chuc_nang, mo_ta) VALUES
('CN001', N'Đổi mật khẩu', N'Người dùng tự đổi mật khẩu đăng nhập'),
('CN002', N'Quản lý hồ sơ ứng viên', N'Tạo/sửa/xem hồ sơ ứng viên'),
('CN003', N'Lọc tin tuyển dụng', N'Lọc tin theo tiêu chí vị trí/khu vực'),
('CN004', N'Ghi nhận ứng tuyển ứng viên', N'Ghi nhận hồ sơ ứng tuyển cho tin'),
('CN005', N'Quản lý thông tin doanh nghiệp', N'Cập nhật thông tin doanh nghiệp đối tác'),
('CN006', N'Thêm tin tuyển dụng', N'Tạo mới tin tuyển dụng cho doanh nghiệp'),
('CN007', N'Quản lý danh sách ứng viên', N'Xem và quản lý danh sách ứng viên đã nộp'),
('CN008', N'Cập nhật kết quả tuyển dụng', N'Ghi nhận kết quả trúng/không trúng'),
('CN009', N'Thu phí ứng tuyển từ ứng viên', N'Thu phí ứng tuyển cho hồ sơ'),
('CN010', N'Thu phí đăng tin từ doanh nghiệp', N'Thu phí đăng tin tuyển dụng'),
 ('CN011', N'Lập hóa đơn', N'Phát hành hóa đơn thu phí'),
 ('CN012', N'Thống kê', N'Xem báo cáo thống kê tổng hợp'),
 ('CN013', N'Quản lý danh mục nghề nghiệp', N'Quản lý danh mục nhóm nghề/nghề/vị trí'),
 ('CN014', N'Tra cứu dữ liệu hệ thống', N'Tra cứu dữ liệu cho mục đích quản trị'),
 ('CN015', N'Quản lý tài khoản nhân viên', N'Tạo/sửa/tạm khóa tài khoản nhân viên'),
 ('CN016', N'Chỉnh sửa quyền hạn', N'Cấu hình quyền theo vai trò'),
 ('CN017', N'Thống kê và đánh giá', N'Báo cáo tổng hợp và đánh giá hiệu quả'),
 ('CN018', N'Đối giá dịch vụ', N'Điều chỉnh mức giá dịch vụ');

-- Phân quyền mẫu cho vai trò
-- Mapping quyền theo ma trận
-- CSS: Đổi mật khẩu; Quản lý hồ sơ ứng viên; Lọc tin tuyển dụng; Ghi nhận ứng tuyển ứng viên
INSERT INTO VaiTro_QuyenHan (vai_tro_id, chuc_nang_id, quyen_han)
SELECT 'CSS', chuc_nang_id, CASE WHEN ten_chuc_nang IN (
    N'Đổi mật khẩu', N'Quản lý hồ sơ ứng viên', N'Lọc tin tuyển dụng', N'Ghi nhận ứng tuyển ứng viên'
) THEN 1 ELSE 0 END FROM ChucNang;

-- ERS: Đổi mật khẩu; Quản lý thông tin doanh nghiệp; Thêm tin tuyển dụng; Quản lý danh sách ứng viên; Cập nhật kết quả tuyển dụng
INSERT INTO VaiTro_QuyenHan (vai_tro_id, chuc_nang_id, quyen_han)
SELECT 'ERS', chuc_nang_id, CASE WHEN ten_chuc_nang IN (
    N'Đổi mật khẩu', N'Quản lý thông tin doanh nghiệp', N'Thêm tin tuyển dụng', N'Quản lý danh sách ứng viên', N'Cập nhật kết quả tuyển dụng'
) THEN 1 ELSE 0 END FROM ChucNang;

-- FO: Đổi mật khẩu; Thu phí ứng tuyển từ ứng viên; Thu phí đăng tin từ doanh nghiệp; Lập hóa đơn; Thống kê
INSERT INTO VaiTro_QuyenHan (vai_tro_id, chuc_nang_id, quyen_han)
SELECT 'FO', chuc_nang_id, CASE WHEN ten_chuc_nang IN (
    N'Đổi mật khẩu', N'Thu phí ứng tuyển từ ứng viên', N'Thu phí đăng tin từ doanh nghiệp', N'Lập hóa đơn', N'Thống kê'
) THEN 1 ELSE 0 END FROM ChucNang;

-- SA: Đổi mật khẩu; Quản lý danh mục nghề nghiệp; Tra cứu dữ liệu hệ thống; Quản lý tài khoản nhân viên; Chỉnh sửa quyền hạn
INSERT INTO VaiTro_QuyenHan (vai_tro_id, chuc_nang_id, quyen_han)
SELECT 'SA', chuc_nang_id, CASE WHEN ten_chuc_nang IN (
    N'Đổi mật khẩu', N'Quản lý danh mục nghề nghiệp', N'Tra cứu dữ liệu hệ thống', N'Quản lý tài khoản nhân viên', N'Chỉnh sửa quyền hạn'
) THEN 1 ELSE 0 END FROM ChucNang;

-- CM: Đổi mật khẩu; Thống kê và đánh giá; Đối giá dịch vụ
INSERT INTO VaiTro_QuyenHan (vai_tro_id, chuc_nang_id, quyen_han)
SELECT 'CM', chuc_nang_id, CASE WHEN ten_chuc_nang IN (
    N'Đổi mật khẩu', N'Thống kê và đánh giá', N'Đối giá dịch vụ'
) THEN 1 ELSE 0 END FROM ChucNang;
-- =============================================

-- phi_id là INT (không tự tăng)
INSERT INTO PhiDichVu (phi_id, ten_dich_vu, so_tien) VALUES
(1, N'Phí ứng tuyển', 30000), -- Cố định
(2, N'Phí đăng tin', 7000); -- 7k/ngày

-- Dữ liệu mẫu cho bảng NhomNghe (cấp 1)
INSERT INTO NhomNghe (ten_nhom) VALUES
(N'Công nghệ thông tin'),
(N'Tài chính - Kế toán'),
(N'Marketing - Quảng cáo'),
(N'Bán hàng - Dịch vụ'),
(N'Giáo dục - Đào tạo');

-- Dữ liệu mẫu cho bảng Nghe (cấp 2)
INSERT INTO Nghe (nhom_id, ten_nghe) VALUES
-- Nghề thuộc Nhóm nghề Công nghệ thông tin
(1, N'Phát triển phần mềm'),
(1, N'Thiết kế UI/UX'),
(1, N'Quản trị hệ thống'),

-- Nghề thuộc Nhóm nghề Tài chính - Kế toán
(2, N'Kế toán'),
(2, N'Tài chính'),

-- Nghề thuộc Nhóm nghề Marketing - Quảng cáo
(3, N'Digital Marketing'),
(3, N'Content Marketing'),

-- Nghề thuộc Nhóm nghề Bán hàng - Dịch vụ
(4, N'Bán hàng'),
(4, N'Chăm sóc khách hàng');

-- Dữ liệu mẫu cho bảng ViTriChuyenMon (cấp 3)
INSERT INTO ViTriChuyenMon (nghe_id, ten_vi_tri) VALUES
-- Vị trí thuộc Phát triển phần mềm
(1, N'Lập trình viên C#'),
(1, N'Lập trình viên Java'),
(1, N'Lập trình viên Python'),

-- Vị trí thuộc Thiết kế UI/UX
(2, N'UI/UX Designer'),
(2, N'Graphic Designer'),

-- Vị trí thuộc Kế toán
(4, N'Kế toán viên'),
(4, N'Kế toán trưởng'),

-- Vị trí thuộc Digital Marketing
(6, N'Digital Marketing Manager'),
(6, N'Chuyên viên Marketing'),

-- Vị trí thuộc Bán hàng
(8, N'Nhân viên bán hàng');

-- Dữ liệu mẫu cho bảng NhanVien
INSERT INTO NhanVien (ho_ten, email, so_dien_thoai, username, password_hash, vai_tro_id) VALUES
(N'Nguyễn Thị Lan', 'lan.nguyen@jobcenter.com', '0901234567', 'css001', 'hashed_password_1', 'CSS'),
(N'Trần Văn Minh', 'minh.tran@jobcenter.com', '0901234568', 'css002', 'hashed_password_2', 'CSS'),
(N'Lê Thị Hoa', 'hoa.le@jobcenter.com', '0901234569', 'ers001', 'hashed_password_3', 'ERS'),
(N'Phạm Văn Đức', 'duc.pham@jobcenter.com', '0901234570', 'ers002', 'hashed_password_4', 'ERS'),
(N'Võ Thị Mai', 'mai.vo@jobcenter.com', '0901234571', 'fo001', 'hashed_password_5', 'FO'),
(N'Đặng Văn Nam', 'nam.dang@jobcenter.com', '0901234572', 'sa001', 'hashed_password_6', 'SA'),
(N'Bùi Thị Linh', 'linh.bui@jobcenter.com', '0901234573', 'cm001', 'hashed_password_7', 'CM');

-- Dữ liệu mẫu cho bảng UngVien
INSERT INTO UngVien (ho_ten, email, so_dien_thoai, cccd, ngay_sinh, que_quan, vt_id) VALUES
(N'Nguyễn Văn An', 'an.nguyen@email.com', '0901000001', '012345678901', '1999-01-15', N'TP.HCM', 1),
(N'Trần Thị Bình', 'binh.tran@email.com', '0901000002', '012345678902', '1998-03-20', N'Hà Nội', 6),
(N'Lê Văn Cường', 'cuong.le@email.com', '0901000003', '012345678903', '1997-07-12', N'Đà Nẵng', 2),
(N'Phạm Thị Dung', 'dung.pham@email.com', '0901000004', '012345678904', '2000-11-05', N'Cần Thơ', 9),
(N'Võ Văn Em', 'em.vo@email.com', '0901000005', '012345678905', '1998-05-30', N'Bình Dương', 5),
(N'Đặng Thị Phương', 'phuong.dang@email.com', '0901000006', '012345678906', '1999-09-09', N'Đồng Nai', 3),
(N'Bùi Văn Giang', 'giang.bui@email.com', '0901000007', '012345678907', '1997-02-18', N'Hải Phòng', 6),
(N'Hoàng Thị Hương', 'huong.hoang@email.com', '0901000008', '012345678908', '1998-08-22', N'Quảng Ninh', 10),
(N'Lý Văn Hùng', 'hung.ly@email.com', '0901000009', '012345678909', '1999-12-01', N'An Giang', 1),
(N'Vũ Thị Linh', 'linh.vu@email.com', '0901000010', '012345678910', '2000-04-14', N'Hà Nam', 6),
(N'Đỗ Văn Nam', 'nam.do@email.com', '0901000011', '012345678911', '1998-06-06', N'Nghệ An', 6),
(N'Ngô Thị Oanh', 'oanh.ngo@email.com', '0901000012', '012345678912', '1999-10-10', N'Thừa Thiên Huế', 8),
(N'Phan Văn Phúc', 'phuc.phan@email.com', '0901000013', '012345678913', '1997-01-25', N'Bình Thuận', 3),
(N'Trương Thị Quỳnh', 'quynh.truong@email.com', '0901000014', '012345678914', '1998-12-19', N'Bắc Ninh', 9),
(N'Lưu Văn Rồng', 'rong.luu@email.com', '0901000015', '012345678915', '1997-05-08', N'Long An', 2);


-- Dữ liệu mẫu cho bảng DoanhNghiep
INSERT INTO DoanhNghiep (ten_doanh_nghiep, dia_chi, so_dien_thoai, email, ma_so_thue, linh_vuc) VALUES
(N'Công ty TNHH ABC', N'123 Đường ABC, Quận 1, TP.HCM', '0281234567', 'contact@abc.com', '0312345678-001', N'Công nghệ thông tin'),
(N'Công ty CP XYZ', N'456 Đường XYZ, Quận 3, TP.HCM', '0281234568', 'hr@xyz.com', '0312345679', N'Tài chính'),
(N'Công ty TNHH DEF', N'789 Đường DEF, Quận 7, TP.HCM', '0281234569', 'info@def.com', '0312345680-002', N'Marketing'),
(N'Công ty CP GHI', N'321 Đường GHI, Quận 2, TP.HCM', '0281234570', 'contact@ghi.com', '0312345681', N'Thiết kế'),
(N'Công ty TNHH JKL', N'654 Đường JKL, Quận 10, TP.HCM', '0281234571', 'hr@jkl.com', '0312345682-003', N'Bán lẻ'),
(N'Công ty TNHH MNO', N'987 Đường MNO, Quận 5, TP.HCM', '0281234572', 'info@mno.com', '0312345683', N'Giáo dục'),
(N'Công ty CP PQR', N'147 Đường PQR, Quận 11, TP.HCM', '0281234573', 'hr@pqr.com', '0312345684-004', N'Y tế'),
(N'Công ty TNHH STU', N'258 Đường STU, Quận 4, TP.HCM', '0281234574', 'contact@stu.com', '0312345685', N'Du lịch'),
(N'Công ty CP VWX', N'369 Đường VWX, Quận 6, TP.HCM', '0281234575', 'info@vwx.com', '0312345686-005', N'Bất động sản'),
(N'Công ty TNHH YZA', N'741 Đường YZA, Quận 8, TP.HCM', '0281234576', 'hr@yza.com', '0312345687', N'Logistics');

-- Thêm doanh nghiệp đa dạng
INSERT INTO DoanhNghiep (ten_doanh_nghiep, dia_chi, so_dien_thoai, email, ma_so_thue, linh_vuc) VALUES
(N'Công ty CP Alpha', N'12 Trần Hưng Đạo, Quận 1, TP.HCM', '0281111111', 'contact@alpha.com', '0312345688-006', N'Y tế'),
(N'Công ty TNHH Beta', N'34 Pasteur, Quận 3, TP.HCM', '0282222222', 'hr@beta.com', '0312345689', N'Giải trí'),
(N'Tập đoàn Gamma', N'56 Lê Lợi, Quận 1, TP.HCM', '0283333333', 'info@gamma.com', '0312345690-007', N'Bán lẻ'),
(N'Công ty CP Delta', N'78 Nguyễn Huệ, Quận 1, TP.HCM', '0284444444', 'contact@delta.com', '0312345691', N'Giáo dục'),
(N'Công ty TNHH Epsilon', N'90 Hai Bà Trưng, Quận 1, TP.HCM', '0285555555', 'hr@epsilon.com', '0312345692-008', N'Nông nghiệp');

-- Dữ liệu mẫu cho bảng TinTuyenDung
-- Lưu ý: Tất cả tin ban đầu chưa thanh toán, sẽ được active qua trigger khi insert HoaDon
INSERT INTO TinTuyenDung (dn_id, tieu_de, mo_ta_cong_viec, so_luong_tuyen, muc_luong, khu_vuc_lam_viec, hinh_thuc_lam_viec, kinh_nghiem_yeu_cau, han_nop_ho_so, ngay_dang) VALUES
-- Tin 1: 7k/ngày, 46 ngày
(1, N'Tuyển dụng lập trình viên', N'Tuyển dụng lập trình viên C# và Java cho dự án phát triển phần mềm.', 3, N'8-12 triệu', N'TP.HCM', N'Toàn thời gian', 0, '2024-02-15', '2024-01-01'),
-- Tin 2: 7k/ngày, 51 ngày
(1, N'Tuyển dụng lập trình viên Java', N'Phát triển ứng dụng backend sử dụng Java Spring. Ưu tiên có kinh nghiệm microservices.', 1, N'7-10 triệu', N'TP.HCM', N'Toàn thời gian', 0, '2024-02-20', '2024-01-01'),
-- Tin 3: 7k/ngày, 49 ngày
(2, N'Tuyển dụng kế toán', N'Xử lý các nghiệp vụ kế toán, báo cáo tài chính.', 1, N'6-8 triệu', N'TP.HCM', N'Toàn thời gian', 0, '2024-02-18', '2024-01-01'),
-- Tin 4: 7k/ngày, 56 ngày
(3, N'Tuyển dụng Marketing', N'Lập kế hoạch marketing, quản lý social media.', 2, N'Thỏa thuận', N'TP.HCM', N'Toàn thời gian', 0, '2024-02-25', '2024-01-01'),
-- Tin 5: 7k/ngày, 53 ngày
(4, N'Tuyển dụng thiết kế', N'Thiết kế logo, banner, ấn phẩm quảng cáo.', 1, N'6-8 triệu', N'TP.HCM', N'Bán thời gian', 0, '2024-02-22', '2024-01-01'),
-- Tin 6: 7k/ngày, 59 ngày
(5, N'Tuyển dụng bán hàng', N'Tư vấn và bán sản phẩm cho khách hàng.', 3, N'5-7 triệu', N'TP.HCM', N'Toàn thời gian', 0, '2024-02-28', '2024-01-01'),
-- Tin 7: 7k/ngày, 61 ngày
(6, N'Tuyển dụng lập trình viên Python', N'Phát triển ứng dụng AI/ML sử dụng Python.', 1, N'9-13 triệu', N'TP.HCM', N'Toàn thời gian', 0, '2024-03-01', '2024-01-01'),
-- Tin 8: 7k/ngày, 65 ngày
(7, N'Tuyển dụng kế toán trưởng', N'Quản lý bộ phận kế toán, báo cáo tài chính.', 1, N'10-15 triệu', N'TP.HCM', N'Toàn thời gian', 2, '2024-03-05', '2024-01-01'),
-- Tin 9: 7k/ngày, 70 ngày
(8, N'Tuyển dụng Digital Marketing Manager', N'Quản lý chiến dịch marketing online.', 1, N'8-12 triệu', N'TP.HCM', N'Toàn thời gian', 1, '2024-03-10', '2024-01-01'),
-- Tin 10: 7k/ngày, 75 ngày
(9, N'Tuyển dụng UI/UX Designer', N'Thiết kế giao diện người dùng và trải nghiệm.', 2, N'7-10 triệu', N'TP.HCM', N'Thực tập', 0, '2024-03-15', '2024-01-01');

-- Thêm 8 tin tuyển dụng mới (id 11-18)
INSERT INTO TinTuyenDung (dn_id, tieu_de, mo_ta_cong_viec, so_luong_tuyen, muc_luong, khu_vuc_lam_viec, hinh_thuc_lam_viec, kinh_nghiem_yeu_cau, han_nop_ho_so, ngay_dang) VALUES
(11, N'Bác sĩ đa khoa', N'Tư vấn và khám chữa bệnh tại phòng khám.', 2, N'Thỏa thuận', N'TP.HCM', N'Toàn thời gian', 2, '2024-03-20', '2024-01-01'),
(12, N'Chuyên viên tổ chức sự kiện', N'Lên kế hoạch và triển khai sự kiện.', 3, N'8-12 triệu', N'Hà Nội', N'Toàn thời gian', 1, '2024-03-18', '2024-01-01'),
(13, N'Quản lý cửa hàng bán lẻ', N'Quản lý vận hành cửa hàng bán lẻ.', 1, N'12-18 triệu', N'Đà Nẵng', N'Toàn thời gian', 2, '2024-03-25', '2024-01-01'),
(14, N'Giảng viên đại học', N'Giảng dạy môn CNTT cho sinh viên.', 2, N'Thỏa thuận', N'TP.HCM', N'Bán thời gian', 1, '2024-03-22', '2024-01-01'),
(15, N'Kỹ sư nông nghiệp', N'Quản lý trang trại công nghệ cao.', 2, N'10-15 triệu', N'Long An', N'Toàn thời gian', 1, '2024-03-28', '2024-01-01'),
(3, N'Chuyên viên SEO', N'Tối ưu hóa công cụ tìm kiếm.', 1, N'8-12 triệu', N'TP.HCM', N'Toàn thời gian', 1, '2024-03-12', '2024-01-01'),
(5, N'Nhân viên chăm sóc khách hàng', N'Hỗ trợ khách hàng đa kênh.', 4, N'7-10 triệu', N'Hà Nội', N'Toàn thời gian', 0, '2024-03-08', '2024-01-01'),
(8, N'Quản lý truyền thông', N'Lập kế hoạch truyền thông thương hiệu.', 1, N'15-20 triệu', N'TP.HCM', N'Toàn thời gian', 2, '2024-03-30', '2024-01-01');

-- Dữ liệu mẫu cho bảng TinTuyenDung_ViTri (vị trí chuyên môn cho tin tuyển dụng)
INSERT INTO TinTuyenDung_ViTri (tin_id, vt_id) VALUES
-- Tin 1: Tuyển dụng lập trình viên (nhiều vị trí)
(1, 1), -- Lập trình viên C#
(1, 2), -- Lập trình viên Java
-- Tin 2: Tuyển dụng lập trình viên Java
(2, 2), -- Lập trình viên Java
-- Tin 3: Tuyển dụng kế toán
(3, 6), -- Kế toán viên
-- Tin 4: Tuyển dụng Marketing
(4, 9), -- Chuyên viên Marketing
-- Tin 5: Tuyển dụng thiết kế
(5, 5), -- Graphic Designer
-- Tin 6: Tuyển dụng bán hàng
(6, 10), -- Nhân viên bán hàng
-- Tin 7: Tuyển dụng lập trình viên Python
(7, 3), -- Lập trình viên Python
-- Tin 8: Tuyển dụng kế toán trưởng
(8, 7), -- Kế toán trưởng
-- Tin 9: Tuyển dụng Digital Marketing Manager
(9, 9), -- Digital Marketing Manager
-- Tin 10: Tuyển dụng UI/UX Designer
(10, 4); -- UI/UX Designer

-- Vị trí cho các tin mới (11-18)
INSERT INTO TinTuyenDung_ViTri (tin_id, vt_id) VALUES
(11, 9), -- Chuyên viên Marketing (truyền thông y tế)
(12, 9), -- Chuyên viên Marketing (tổ chức sự kiện)
(13, 10), -- Nhân viên bán hàng (bán lẻ)
(14, 3), -- Lập trình viên Python (giảng dạy CNTT)
(15, 9), -- Chuyên viên Marketing (nông nghiệp công nghệ)
(16, 8), -- Digital Marketing Manager (SEO liên quan)
(17, 10), -- Nhân viên bán hàng (CSKH gần kênh bán)
(18, 9); -- Chuyên viên Marketing (quản lý truyền thông)

-- Dữ liệu mẫu cho bảng TinTuyenDung_KyNang (kỹ năng yêu cầu theo vị trí chuyên môn)
INSERT INTO TinTuyenDung_KyNang (tin_id, vt_id, ten_ky_nang) VALUES
-- Tin 1: vt 1 Lập trình viên C# và vt 2 Lập trình viên Java
(1, 1, 'C#'), (1, 1, 'HTML'), (1, 1, 'CSS'), (1, 1, 'SQL'),
(1, 2, 'Java'), (1, 2, 'Spring Boot'), (1, 2, 'SQL'), (1, 2, 'JavaScript'),
-- Tin 2: vt 2 Lập trình viên Java
(2, 2, 'Java'), (2, 2, 'Spring Boot'), (2, 2, 'MySQL'), (2, 2, 'Git'),
-- Tin 3: vt 6 Kế toán viên
(3, 6, 'Excel'), (3, 6, 'SQL'), (3, 6, N'Giao tiếp'), (3, 6, N'Làm việc nhóm'),
-- Tin 4: vt 9 Chuyên viên Marketing
(4, 9, 'Google Analytics'), (4, 9, 'Facebook Ads'), (4, 9, 'SEO'), (4, 9, 'Content Creation'), (4, 9, N'Tiếng Anh'),
-- Tin 5: vt 5 Graphic Designer
(5, 5, 'Photoshop'), (5, 5, 'Illustrator'), (5, 5, 'Figma'), (5, 5, N'Sáng tạo'),
-- Tin 6: vt 10 Nhân viên bán hàng
(6, 10, N'Giao tiếp'), (6, 10, N'Làm việc nhóm'), (6, 10, N'Tiếng Anh'),
-- Tin 7: vt 3 Lập trình viên Python
(7, 3, 'Python'), (7, 3, 'Machine Learning'), (7, 3, N'Tiếng Anh'),
-- Tin 8: vt 7 Kế toán trưởng
(8, 7, 'Excel'), (8, 7, 'SQL'), (8, 7, N'Giao tiếp'), (8, 7, N'Làm việc nhóm'),
-- Tin 9: vt 9 Digital Marketing Manager
(9, 9, 'Google Analytics'), (9, 9, 'Facebook Ads'), (9, 9, 'SEO'), (9, 9, 'Content Creation'),
-- Tin 10: vt 4 UI/UX Designer
(10, 4, 'Figma'), (10, 4, N'Giao tiếp'), (10, 4, N'Sáng tạo');

-- Kỹ năng cho các tin mới (11-18)
INSERT INTO TinTuyenDung_KyNang (tin_id, vt_id, ten_ky_nang) VALUES
-- Tin 11 dùng vt 9 (Chuyên viên Marketing)
(11, 9, N'Giao tiếp'), (11, 9, N'Làm việc nhóm'), (11, 9, N'Y đức'),
-- Tin 12 dùng vt 9 (Chuyên viên Marketing)
(12, 9, N'Tổ chức'), (12, 9, N'Giao tiếp'), (12, 9, 'SEO'),
-- Tin 13: vt 10 Nhân viên bán hàng
(13, 10, N'Quản lý'), (13, 10, N'Báo cáo'), (13, 10, N'Kỷ luật'),
-- Tin 14 dùng vt 3 (Lập trình viên Python)
(14, 3, N'Giảng dạy'), (14, 3, N'Nghiên cứu'), (14, 3, 'Python'),
-- Tin 15 dùng vt 9 (Chuyên viên Marketing)
(15, 9, N'Nông nghiệp công nghệ'), (15, 9, N'Quản lý'), (15, 9, N'An toàn lao động'),
-- Tin 16: vt 8 Digital Marketing Manager (SEO liên quan)
(16, 8, 'SEO'), (16, 8, 'Google Analytics'), (16, 8, 'Content'),
-- Tin 17: vt 10 Nhân viên bán hàng
(17, 10, N'Giao tiếp'), (17, 10, N'Kiên nhẫn'), (17, 10, N'Giải quyết vấn đề'),
-- Tin 18: vt 9 Chuyên viên Marketing
(18, 9, N'Chiến lược'), (18, 9, N'PR'), (18, 9, N'Quản trị thương hiệu');

-- Dữ liệu mẫu cho bảng HoaDon DOANH NGHIỆP (insert sau TinTuyenDung)
INSERT INTO HoaDon (loai_khach_hang, dn_id, ten_khach_hang, phi_id, so_tien, ma_nhan_vien_lap, tin_id) VALUES
-- Tin 1: 7k/ngày, 46 ngày = 322,000 VNĐ
('doanh_nghiep', 1, N'Công ty TNHH ABC', 2, 322000, 5, 1),
-- Tin 2: 7k/ngày, 51 ngày = 357,000 VNĐ  
('doanh_nghiep', 1, N'Công ty TNHH ABC', 2, 357000, 5, 2),
-- Tin 3: 7k/ngày, 49 ngày = 343,000 VNĐ
('doanh_nghiep', 2, N'Công ty CP XYZ', 2, 343000, 5, 3),
-- Tin 4: 7k/ngày, 56 ngày = 392,000 VNĐ
('doanh_nghiep', 3, N'Công ty TNHH DEF', 2, 392000, 5, 4),
-- Tin 5: 7k/ngày, 53 ngày = 371,000 VNĐ
('doanh_nghiep', 4, N'Công ty CP GHI', 2, 371000, 5, 5),
-- Tin 6: 7k/ngày, 59 ngày = 413,000 VNĐ
('doanh_nghiep', 5, N'Công ty TNHH JKL', 2, 413000, 5, 6),
-- Tin 7: 7k/ngày, 61 ngày = 427,000 VNĐ
('doanh_nghiep', 6, N'Công ty TNHH MNO', 2, 427000, 5, 7),
-- Tin 8: 7k/ngày, 65 ngày = 455,000 VNĐ
('doanh_nghiep', 7, N'Công ty CP PQR', 2, 455000, 5, 8),
-- Tin 9: 7k/ngày, 70 ngày = 490,000 VNĐ
('doanh_nghiep', 8, N'Công ty TNHH STU', 2, 490000, 5, 9),
-- Tin 10: 7k/ngày, 75 ngày = 525,000 VNĐ
('doanh_nghiep', 9, N'Công ty CP VWX', 2, 525000, 5, 10);

-- Hóa đơn DN cho các tin mới (11-18) – số tiền tính theo số ngày (7k/ngày)
INSERT INTO HoaDon (loai_khach_hang, dn_id, ten_khach_hang, phi_id, so_tien, ma_nhan_vien_lap, tin_id) VALUES
('doanh_nghiep', 11, N'Công ty CP Alpha', 2, 560000, 5, 11), -- 80 ngày * 7k
('doanh_nghiep', 12, N'Công ty TNHH Beta', 2, 546000, 5, 12), -- 78 ngày * 7k
('doanh_nghiep', 13, N'Tập đoàn Gamma', 2, 595000, 5, 13), -- 85 ngày * 7k
('doanh_nghiep', 14, N'Công ty CP Delta', 2, 574000, 5, 14), -- 82 ngày * 7k
('doanh_nghiep', 15, N'Công ty TNHH Epsilon', 2, 616000, 5, 15), -- 88 ngày * 7k
('doanh_nghiep', 3, N'Công ty TNHH DEF', 2, 504000, 5, 16), -- 72 ngày * 7k
('doanh_nghiep', 5, N'Công ty TNHH JKL', 2, 476000, 5, 17), -- 68 ngày * 7k
('doanh_nghiep', 8, N'Công ty TNHH STU', 2, 630000, 5, 18); -- 90 ngày * 7k

-- Dữ liệu mẫu cho bảng UngTuyen (insert SAU Hóa đơn DOANH NGHIỆP để tin active, TRƯỚC Hóa đơn ỨNG VIÊN)
INSERT INTO UngTuyen (uv_id, tin_id, trang_thai, da_thanh_toan_phi, ngay_nop) VALUES
(1, 1, 'DA_NOP', 0, '2024-01-15'),
(2, 1, 'DA_NOP', 0, '2024-01-15'),
(3, 2, 'DA_NOP', 0, '2024-01-15'),
(4, 3, 'DA_NOP', 0, '2024-01-15'),
(5, 4, 'DA_NOP', 0, '2024-01-15'),
(6, 1, 'TRUNG_TUYEN', 0, '2024-01-15'),
(7, 3, 'DA_NOP', 0, '2024-01-15'),
(8, 5, 'DA_NOP', 0, '2024-01-15'),
(9, 1, 'DA_NOP', 0, '2024-01-15'),
(10, 4, 'DA_NOP', 0, '2024-01-15'),
(11, 2, 'DA_NOP', 0, '2024-01-15'),
(12, 6, 'DA_NOP', 0, '2024-01-15'),
(13, 7, 'DA_NOP', 0, '2024-01-15'),
(14, 8, 'DA_NOP', 0, '2024-01-15'),
(15, 9, 'DA_NOP', 0, '2024-01-15');

-- Thêm 10 hồ sơ ứng tuyển mới (ut_id dự kiến 16..25)
INSERT INTO UngTuyen (uv_id, tin_id, trang_thai, da_thanh_toan_phi, ngay_nop) VALUES
(1, 11, 'DA_NOP', 0, '2024-01-20'),
(2, 12, 'DA_NOP', 0, '2024-01-20'),
(3, 13, 'DA_NOP', 0, '2024-01-20'),
(4, 14, 'DA_NOP', 0, '2024-01-20'),
(5, 15, 'DA_NOP', 0, '2024-01-20'),
(6, 16, 'DA_NOP', 0, '2024-01-20'),
(7, 17, 'DA_NOP', 0, '2024-01-20'),
(8, 18, 'DA_NOP', 0, '2024-01-20'),
(9, 11, 'DA_NOP', 0, '2024-01-20'),
(10, 12, 'DA_NOP', 0, '2024-01-20');

-- Dữ liệu mẫu cho bảng HoaDon ứng viên (insert sau UngTuyen)
INSERT INTO HoaDon (loai_khach_hang, uv_id, ten_khach_hang, phi_id, so_tien, ma_nhan_vien_lap, ut_id) VALUES
('ung_vien', 2, N'Trần Thị Bình', 1, 30000, 5, 2),
('ung_vien', 3, N'Lê Văn Cường', 1, 30000, 5, 3),
('ung_vien', 5, N'Võ Văn Em', 1, 30000, 5, 5),
('ung_vien', 6, N'Đặng Thị Phương', 1, 30000, 5, 6),
('ung_vien', 7, N'Bùi Văn Giang', 1, 30000, 5, 7),
('ung_vien', 9, N'Lý Văn Hùng', 1, 30000, 5, 9),
('ung_vien', 10, N'Vũ Thị Linh', 1, 30000, 5, 10),
('ung_vien', 12, N'Ngô Thị Oanh', 1, 30000, 5, 12),
('ung_vien', 13, N'Phan Văn Phúc', 1, 30000, 5, 13),
('ung_vien', 15, N'Lưu Văn Rồng', 1, 30000, 5, 15);

-- Hóa đơn ứng viên mới (ứng với ut_id 16..21)
INSERT INTO HoaDon (loai_khach_hang, uv_id, ten_khach_hang, phi_id, so_tien, ma_nhan_vien_lap, ut_id) VALUES
('ung_vien', 1, N'Nguyễn Văn An', 1, 30000, 5, 16),
('ung_vien', 2, N'Trần Thị Bình', 1, 30000, 5, 17),
('ung_vien', 3, N'Lê Văn Cường', 1, 30000, 5, 18),
('ung_vien', 4, N'Phạm Thị Dung', 1, 30000, 5, 19),
('ung_vien', 5, N'Võ Văn Em', 1, 30000, 5, 20),
('ung_vien', 6, N'Đặng Thị Phương', 1, 30000, 5, 21);

-- THỨ TỰ INSERT ĐÚNG:
-- Bước 1: TinTuyenDung (chưa thanh toán)
-- Bước 2: HoaDon DOANH NGHIỆP (kích hoạt tin qua trigger)
-- Bước 3: UngTuyen (ứng viên ứng tuyển)
-- Bước 4: HoaDon ỨNG VIÊN (thanh toán phí ứng tuyển)