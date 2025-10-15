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
 
-- Dữ liệu mẫu cho bảng ChucNang (mã + tên + mô tả) theo yêu cầu mới
INSERT INTO ChucNang (chuc_nang_id, ten_chuc_nang, mo_ta) VALUES
('CN_DMK',  N'Đổi mật khẩu', N'Người dùng tự đổi mật khẩu đăng nhập'),
-- CSS
('CN_CSS01', N'Đăng ký hồ sơ ứng viên', N'Tạo hồ sơ ứng viên mới'),
('CN_CSS02', N'Chỉnh sửa thông tin ứng viên', N'Cập nhật hồ sơ ứng viên'),
('CN_CSS03', N'Ghi nhận ứng tuyển', N'Ghi nhận hồ sơ ứng tuyển cho tin'),
-- ERS
('CN_ERS01', N'Đăng ký hồ sơ doanh nghiệp', N'Tạo hồ sơ doanh nghiệp mới'),
('CN_ERS02', N'Chỉnh sửa hồ sơ doanh nghiệp', N'Cập nhật hồ sơ doanh nghiệp'),
('CN_ERS03', N'Đăng tin tuyển dụng', N'Tạo mới tin tuyển dụng cho doanh nghiệp'),
('CN_ERS04', N'Danh sách ứng viên', N'Xem và quản lý danh sách ứng viên đã nộp'),
('CN_ERS05', N'Cập nhật kết quả tuyển dụng', N'Ghi nhận kết quả trúng/không trúng'),
-- SA
('CN_SA01', N'Quản lý danh mục nghề nghiệp', N'Quản lý danh mục nhóm nghề/nghề/vị trí'),
('CN_SA02', N'Quản lý tài khoản nhân viên', N'Tạo/sửa/tạm khóa tài khoản nhân viên'),
('CN_SA03', N'Quản lý quyền hạn chức năng', N'Cấu hình quyền theo vai trò'),
-- CM
('CN_CM01', N'Thống kê số lượng ứng viên', N'Báo cáo tổng số ứng viên theo thời gian'),
('CN_CM02', N'Thống kê tỷ lệ ứng tuyển thành công', N'Báo cáo chuyển đổi ứng tuyển'),
('CN_CM03', N'Điều chỉnh giá dịch vụ', N'Điều chỉnh mức giá dịch vụ'),
-- FO
('CN_FO01', N'Thu phí ứng tuyển', N'Thu phí ứng tuyển cho hồ sơ'),
('CN_FO02', N'Thu phí doanh nghiệp', N'Thu phí đăng tin từ doanh nghiệp'),
('CN_FO03', N'Danh sách hóa đơn', N'Tra cứu danh sách hóa đơn'),
('CN_FO04', N'Báo cáo doanh thu tháng', N'Tổng hợp doanh thu theo tháng');

-- Phân quyền vai trò theo yêu cầu mới
-- CSS: Đăng ký hồ sơ UV, Chỉnh sửa UV, Ghi nhận ứng tuyển, Đổi mật khẩu
INSERT INTO VaiTro_QuyenHan (vai_tro_id, chuc_nang_id, quyen_han) VALUES
('CSS','CN_CSS01',1),('CSS','CN_CSS02',1),('CSS','CN_CSS03',1),('CSS','CN_DMK',1);

-- ERS: Đăng ký DN, Chỉnh sửa DN, Đăng tin tuyển dụng, Danh sách ứng viên, Cập nhật kết quả, Đổi mật khẩu
INSERT INTO VaiTro_QuyenHan (vai_tro_id, chuc_nang_id, quyen_han) VALUES
('ERS','CN_ERS01',1),('ERS','CN_ERS02',1),('ERS','CN_ERS03',1),('ERS','CN_ERS04',1),('ERS','CN_ERS05',1),('ERS','CN_DMK',1);

-- SA: Quản lý danh mục nghề nghiệp, Quản lý tài khoản nhân viên, Quản lý quyền hạn chức năng, Đổi mật khẩu
INSERT INTO VaiTro_QuyenHan (vai_tro_id, chuc_nang_id, quyen_han) VALUES
('SA','CN_SA01',1),('SA','CN_SA02',1),('SA','CN_SA03',1),('SA','CN_DMK',1);

-- CM: Thống kê số lượng UV, Thống kê tỷ lệ thành công, Điều chỉnh giá dịch vụ, Đổi mật khẩu
INSERT INTO VaiTro_QuyenHan (vai_tro_id, chuc_nang_id, quyen_han) VALUES
('CM','CN_CM01',1),('CM','CN_CM02',1),('CM','CN_CM03',1),('CM','CN_DMK',1);

-- FO: Thu phí ứng tuyển, Thu phí doanh nghiệp, Danh sách hóa đơn, Báo cáo doanh thu tháng, Đổi mật khẩu
INSERT INTO VaiTro_QuyenHan (vai_tro_id, chuc_nang_id, quyen_han) VALUES
('FO','CN_FO01',1),('FO','CN_FO02',1),('FO','CN_FO03',1),('FO','CN_FO04',1),('FO','CN_DMK',1);
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
-- Sử dụng HASHBYTES để tự động tính SHA256
-- Mật khẩu: CSS/ERS/FO/CM = "123456", SA = "hello"
INSERT INTO NhanVien (ho_ten, email, so_dien_thoai, username, password_hash, vai_tro_id) VALUES
(N'Nguyễn Thị Lan', 'lan.nguyen@jobcenter.com', '0901234567', 'css001', CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', '123456'), 2), 'CSS'),
(N'Trần Văn Minh', 'minh.tran@jobcenter.com', '0901234568', 'css002', CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', '123456'), 2), 'CSS'),
(N'Lê Thị Hoa', 'hoa.le@jobcenter.com', '0901234569', 'ers001', CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', '123456'), 2), 'ERS'),
(N'Phạm Văn Đức', 'duc.pham@jobcenter.com', '0901234570', 'ers002', CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', '123456'), 2), 'ERS'),
(N'Võ Thị Mai', 'mai.vo@jobcenter.com', '0901234571', 'fo001', CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', '123456'), 2), 'FO'),
(N'Đặng Văn Nam', 'nam.dang@jobcenter.com', '0901234572', 'sa001', CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'hello'), 2), 'SA'),
(N'Bùi Thị Linh', 'linh.bui@jobcenter.com', '0901234573', 'cm001', CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', '123456'), 2), 'CM');

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
(1, N'Tuyển dụng lập trình viên', N'Mô tả công việc: Tham gia phát triển các module phần mềm theo kiến trúc nhiều lớp (WinForms/Web). Phối hợp review code, viết unit test cơ bản và tối ưu hiệu năng truy vấn.
Yêu cầu: Thành thạo C#, .NET, SQL Server; hiểu OOP, SOLID; có kinh nghiệm làm việc nhóm Agile/Scrum là lợi thế.
Quyền lợi: Lương thưởng cạnh tranh, review 2 lần/năm, bảo hiểm đầy đủ, phụ cấp máy tính.', 3, N'8-12 triệu', N'TP.HCM', N'Toàn thời gian', 0, '2025-02-15', '2025-01-01'),
-- Tin 2: 7k/ngày, 51 ngày
(1, N'Tuyển dụng lập trình viên Java', N'Mô tả công việc: Phát triển dịch vụ backend trên nền tảng Java Spring Boot, thiết kế RESTful API, tích hợp với hệ thống message queue và cache.
Yêu cầu: Java Core, Spring Boot, JPA/Hibernate, Microservices; ưu tiên có kinh nghiệm CI/CD và Docker/K8s.
Quyền lợi: Môi trường kỹ thuật cao, cơ hội học hỏi kiến trúc phân tán, trợ cấp chứng chỉ.', 1, N'7-10 triệu', N'TP.HCM', N'Toàn thời gian', 0, '2025-02-20', '2025-01-01'),
-- Tin 3: 7k/ngày, 49 ngày
(2, N'Tuyển dụng kế toán', N'Mô tả công việc: Thực hiện hạch toán, đối soát công nợ, lập báo cáo tài chính định kỳ, phối hợp kiểm toán nội bộ.
Yêu cầu: Tốt nghiệp chuyên ngành kế toán/kiểm toán, nắm vững chuẩn mực kế toán, thành thạo Excel và phần mềm kế toán.
Quyền lợi: Lộ trình thăng tiến rõ ràng, phụ cấp ăn trưa, thưởng hiệu suất.', 1, N'6-8 triệu', N'TP.HCM', N'Toàn thời gian', 0, '2025-09-20', '2025-07-20'),
-- Tin 4: 7k/ngày, 56 ngày
(3, N'Tuyển dụng Marketing', N'Mô tả công việc: Lập kế hoạch marketing tổng thể, triển khai digital campaign, quản lý nội dung social và báo cáo hiệu quả định kỳ.
Yêu cầu: Có kinh nghiệm chạy Ads (Facebook/Google), sử dụng công cụ phân tích (GA4), tư duy sáng tạo, kỹ năng viết tốt.
Quyền lợi: Thưởng theo KPI chiến dịch, làm việc linh hoạt, teambuilding hàng quý.', 2, N'Thỏa thuận', N'TP.HCM', N'Toàn thời gian', 0, '2025-10-10', '2025-09-01'),
-- Tin 5: 7k/ngày, 53 ngày
(4, N'Tuyển dụng thiết kế', N'Mô tả công việc: Thiết kế bộ nhận diện, banner, brochure, ấn phẩm truyền thông online/offline; phối hợp với team nội dung và marketing.
Yêu cầu: Thành thạo Photoshop/Illustrator/Figma; có portfolio; thẩm mỹ tốt, tỉ mỉ, đúng deadline.
Quyền lợi: Thiết bị làm việc đầy đủ, môi trường sáng tạo, thưởng dự án.', 1, N'6-8 triệu', N'TP.HCM', N'Bán thời gian', 0, '2025-09-05', '2025-07-30'),
-- Tin 6: 7k/ngày, 59 ngày
(5, N'Tuyển dụng bán hàng', N'Mô tả công việc: Tư vấn sản phẩm/dịch vụ, chăm sóc khách hàng hiện hữu, mở rộng tệp khách hàng mới, đạt chỉ tiêu doanh số.
Yêu cầu: Kỹ năng giao tiếp và đàm phán tốt, chịu được áp lực, sẵn sàng di chuyển.
Quyền lợi: Lương cứng + hoa hồng, thưởng quý, đào tạo kỹ năng bán hàng.', 3, N'5-7 triệu', N'TP.HCM', N'Toàn thời gian', 0, '2025-10-15', '2025-08-20'),
-- Tin 7: 7k/ngày, 61 ngày
(6, N'Tuyển dụng lập trình viên Python', N'Mô tả công việc: Phát triển mô-đun AI/ML, xây dựng pipeline xử lý dữ liệu, triển khai mô hình và tối ưu hiệu năng.
Yêu cầu: Python, thư viện ML (scikit-learn, pandas), có kiến thức về mô hình hóa dữ liệu; ưu tiên biết TensorFlow/PyTorch.
Quyền lợi: Môi trường nghiên cứu ứng dụng, ngân sách học tập, mentor giàu kinh nghiệm.', 1, N'9-13 triệu', N'TP.HCM', N'Toàn thời gian', 0, '2025-10-31', '2025-09-10'),
-- Tin 8: 7k/ngày, 65 ngày
(7, N'Tuyển dụng kế toán trưởng', N'Mô tả công việc: Quản lý phòng kế toán, chịu trách nhiệm lập và kiểm soát báo cáo tài chính, tham mưu chính sách tài chính.
Yêu cầu: Tối thiểu 5 năm kinh nghiệm, am hiểu luật thuế, kỹ năng lãnh đạo và ra quyết định.
Quyền lợi: Chế độ đãi ngộ cao, thưởng cuối năm, bảo hiểm sức khỏe.', 1, N'10-15 triệu', N'TP.HCM', N'Toàn thời gian', 2, '2025-11-05', '2025-09-05'),
-- Tin 9: 7k/ngày, 70 ngày
(8, N'Tuyển dụng Digital Marketing Manager', N'Mô tả công việc: Xây dựng chiến lược digital, quản lý ngân sách ads, tối ưu đa kênh, dẫn dắt team đạt mục tiêu đề ra.
Yêu cầu: 3+ năm kinh nghiệm quản lý, thành thạo SEO/SEM/Ads, sử dụng tốt GA4/Data Studio.
Quyền lợi: Thưởng theo hiệu quả, lộ trình lên Head of Marketing, môi trường năng động.', 1, N'8-12 triệu', N'TP.HCM', N'Toàn thời gian', 1, '2025-09-30', '2025-07-15'),
-- Tin 10: 7k/ngày, 75 ngày
(9, N'Tuyển dụng UI/UX Designer', N'Mô tả công việc: Nghiên cứu người dùng, thiết kế wireframe, prototype, phối hợp dev để triển khai giao diện chuẩn UX.
Yêu cầu: Figma, kiến thức UX writing, usability testing; có sản phẩm đã triển khai.
Quyền lợi: Review lương định kỳ, thời gian linh hoạt, văn hóa tôn trọng sự sáng tạo.', 2, N'7-10 triệu', N'TP.HCM', N'Thực tập', 0, '2025-10-05', '2025-08-10');

-- Thêm 8 tin tuyển dụng mới (id 11-18)
INSERT INTO TinTuyenDung (dn_id, tieu_de, mo_ta_cong_viec, so_luong_tuyen, muc_luong, khu_vuc_lam_viec, hinh_thuc_lam_viec, kinh_nghiem_yeu_cau, han_nop_ho_so, ngay_dang) VALUES
(11, N'Bác sĩ đa khoa', N'Mô tả công việc: Khám, tư vấn và điều trị cho bệnh nhân theo quy trình chuyên môn; phối hợp với điều dưỡng và các khoa liên quan.
Yêu cầu: Bằng bác sĩ đa khoa, chứng chỉ hành nghề, tối thiểu 2 năm kinh nghiệm; giao tiếp tốt, tận tâm.
Quyền lợi: Thu nhập cạnh tranh, hỗ trợ đào tạo liên tục, bảo hiểm sức khỏe.', 2, N'Thỏa thuận', N'TP.HCM', N'Toàn thời gian', 2, '2025-10-30', '2025-09-12'),
(12, N'Chuyên viên tổ chức sự kiện', N'Mô tả công việc: Lên kế hoạch, làm việc với nhà cung cấp, điều phối nhân sự, đảm bảo tiến độ và chất lượng sự kiện.
Yêu cầu: Khả năng tổ chức, giao tiếp, xử lý tình huống; ưu tiên biết thiết kế cơ bản và quay dựng.
Quyền lợi: Môi trường năng động, đi công tác, thưởng theo sự kiện.', 3, N'8-12 triệu', N'Hà Nội', N'Toàn thời gian', 1, '2025-10-05', '2025-08-25'),
(13, N'Quản lý cửa hàng bán lẻ', N'Mô tả công việc: Quản lý vận hành, nhân sự, hàng hóa, doanh thu và chăm sóc khách hàng; triển khai chương trình bán hàng.
Yêu cầu: 2+ năm quản lý bán lẻ, kỹ năng báo cáo, giải quyết vấn đề, kỷ luật cao.
Quyền lợi: Thưởng doanh số, lộ trình quản lý khu vực, đào tạo nội bộ.', 1, N'12-18 triệu', N'Đà Nẵng', N'Toàn thời gian', 2, '2025-11-10', '2025-09-20'),
(14, N'Giảng viên đại học', N'Mô tả công việc: Giảng dạy các học phần CNTT, hướng dẫn nghiên cứu khoa học, tham gia phát triển chương trình đào tạo.
Yêu cầu: Thạc sĩ trở lên ngành CNTT, có công bố khoa học là lợi thế; kỹ năng sư phạm tốt.
Quyền lợi: Chế độ nghiên cứu, giờ giảng linh hoạt, môi trường học thuật.', 2, N'Thỏa thuận', N'TP.HCM', N'Bán thời gian', 1, '2025-09-15', '2025-07-25'),
(15, N'Kỹ sư nông nghiệp', N'Mô tả công việc: Vận hành trang trại công nghệ cao, giám sát quy trình, ứng dụng IoT/automation nâng cao năng suất.
Yêu cầu: Hiểu biết nông nghiệp hiện đại, kỹ năng phân tích dữ liệu, sẵn sàng làm việc ngoài hiện trường.
Quyền lợi: Hỗ trợ nhà ở, phụ cấp đi lại, cơ hội phát triển quản lý trang trại.', 2, N'10-15 triệu', N'Long An', N'Toàn thời gian', 1, '2025-10-20', '2025-08-18'),
(3, N'Chuyên viên SEO', N'Mô tả công việc: Lập kế hoạch SEO tổng thể, tối ưu onpage/offpage, nghiên cứu từ khóa, phân tích dữ liệu để tăng trưởng traffic bền vững.
Yêu cầu: Thành thạo công cụ SEO, hiểu kỹ thuật web cơ bản, phối hợp tốt với content/dev.
Quyền lợi: Thưởng theo KPI organic, ngân sách tool, giờ làm linh hoạt.', 1, N'8-12 triệu', N'TP.HCM', N'Toàn thời gian', 1, '2025-10-25', '2025-09-01'),
(5, N'Nhân viên chăm sóc khách hàng', N'Mô tả công việc: Hỗ trợ khách hàng qua nhiều kênh (điện thoại/email/chat), theo dõi xử lý ticket, ghi nhận phản hồi để cải tiến dịch vụ.
Yêu cầu: Kiên nhẫn, giao tiếp tốt, đánh máy nhanh, tư duy dịch vụ.
Quyền lợi: Lương + thưởng hiệu suất, phụ cấp ca, cơ hội lên trưởng nhóm CSKH.', 4, N'7-10 triệu', N'Hà Nội', N'Toàn thời gian', 0, '2025-09-25', '2025-08-05'),
(8, N'Quản lý truyền thông', N'Mô tả công việc: Xây dựng kế hoạch truyền thông thương hiệu, quản trị kênh owned/earned media, giám sát hình ảnh nhất quán.
Yêu cầu: Kỹ năng lập kế hoạch, làm việc với báo chí/KOLs, tư duy chiến lược.
Quyền lợi: Phụ cấp truyền thông, thưởng dự án, cơ hội phát triển thành Brand Manager.', 1, N'15-20 triệu', N'TP.HCM', N'Toàn thời gian', 2, '2025-11-30', '2025-10-01');

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
-- Tin 1: so_tien tính động theo số ngày hiển thị tin
('doanh_nghiep', 1, N'Công ty TNHH ABC', 2, (DATEDIFF(DAY, (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 1), (SELECT han_nop_ho_so FROM TinTuyenDung WHERE tin_id = 1)) + 1) * 7000, 5, 1),
-- Tin 2
('doanh_nghiep', 1, N'Công ty TNHH ABC', 2, (DATEDIFF(DAY, (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 2), (SELECT han_nop_ho_so FROM TinTuyenDung WHERE tin_id = 2)) + 1) * 7000, 5, 2),
-- Tin 3
('doanh_nghiep', 2, N'Công ty CP XYZ', 2, (DATEDIFF(DAY, (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 3), (SELECT han_nop_ho_so FROM TinTuyenDung WHERE tin_id = 3)) + 1) * 7000, 5, 3),
-- Tin 4
('doanh_nghiep', 3, N'Công ty TNHH DEF', 2, (DATEDIFF(DAY, (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 4), (SELECT han_nop_ho_so FROM TinTuyenDung WHERE tin_id = 4)) + 1) * 7000, 5, 4),
-- Tin 5
('doanh_nghiep', 4, N'Công ty CP GHI', 2, (DATEDIFF(DAY, (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 5), (SELECT han_nop_ho_so FROM TinTuyenDung WHERE tin_id = 5)) + 1) * 7000, 5, 5),
-- Tin 6
('doanh_nghiep', 5, N'Công ty TNHH JKL', 2, (DATEDIFF(DAY, (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 6), (SELECT han_nop_ho_so FROM TinTuyenDung WHERE tin_id = 6)) + 1) * 7000, 5, 6),
-- Tin 7
('doanh_nghiep', 6, N'Công ty TNHH MNO', 2, (DATEDIFF(DAY, (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 7), (SELECT han_nop_ho_so FROM TinTuyenDung WHERE tin_id = 7)) + 1) * 7000, 5, 7),
-- Tin 8
('doanh_nghiep', 7, N'Công ty CP PQR', 2, (DATEDIFF(DAY, (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 8), (SELECT han_nop_ho_so FROM TinTuyenDung WHERE tin_id = 8)) + 1) * 7000, 5, 8),
-- Tin 9
('doanh_nghiep', 8, N'Công ty TNHH STU', 2, (DATEDIFF(DAY, (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 9), (SELECT han_nop_ho_so FROM TinTuyenDung WHERE tin_id = 9)) + 1) * 7000, 5, 9),
-- Tin 10
('doanh_nghiep', 9, N'Công ty CP VWX', 2, (DATEDIFF(DAY, (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 10), (SELECT han_nop_ho_so FROM TinTuyenDung WHERE tin_id = 10)) + 1) * 7000, 5, 10);

-- Hóa đơn DN cho các tin mới (11-18) – số tiền tính theo số ngày (7k/ngày)
INSERT INTO HoaDon (loai_khach_hang, dn_id, ten_khach_hang, phi_id, so_tien, ma_nhan_vien_lap, tin_id) VALUES
('doanh_nghiep', 11, N'Công ty CP Alpha', 2, (DATEDIFF(DAY, (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 11), (SELECT han_nop_ho_so FROM TinTuyenDung WHERE tin_id = 11)) + 1) * 7000, 5, 11),
('doanh_nghiep', 12, N'Công ty TNHH Beta', 2, (DATEDIFF(DAY, (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 12), (SELECT han_nop_ho_so FROM TinTuyenDung WHERE tin_id = 12)) + 1) * 7000, 5, 12),
('doanh_nghiep', 13, N'Tập đoàn Gamma', 2, (DATEDIFF(DAY, (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 13), (SELECT han_nop_ho_so FROM TinTuyenDung WHERE tin_id = 13)) + 1) * 7000, 5, 13),
('doanh_nghiep', 14, N'Công ty CP Delta', 2, (DATEDIFF(DAY, (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 14), (SELECT han_nop_ho_so FROM TinTuyenDung WHERE tin_id = 14)) + 1) * 7000, 5, 14),
('doanh_nghiep', 15, N'Công ty TNHH Epsilon', 2, (DATEDIFF(DAY, (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 15), (SELECT han_nop_ho_so FROM TinTuyenDung WHERE tin_id = 15)) + 1) * 7000, 5, 15),
('doanh_nghiep', 3, N'Công ty TNHH DEF', 2, (DATEDIFF(DAY, (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 16), (SELECT han_nop_ho_so FROM TinTuyenDung WHERE tin_id = 16)) + 1) * 7000, 5, 16),
('doanh_nghiep', 5, N'Công ty TNHH JKL', 2, (DATEDIFF(DAY, (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 17), (SELECT han_nop_ho_so FROM TinTuyenDung WHERE tin_id = 17)) + 1) * 7000, 5, 17),
('doanh_nghiep', 8, N'Công ty TNHH STU', 2, (DATEDIFF(DAY, (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 18), (SELECT han_nop_ho_so FROM TinTuyenDung WHERE tin_id = 18)) + 1) * 7000, 5, 18);

-- Dữ liệu mẫu cho bảng UngTuyen (insert SAU Hóa đơn DOANH NGHIỆP để tin active, TRƯỚC Hóa đơn ỨNG VIÊN)
INSERT INTO UngTuyen (uv_id, tin_id, trang_thai, da_thanh_toan_phi, ngay_nop) VALUES
(1, 1, 'DA_NOP', 0, DATEADD(DAY, 5,  (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 1))),
(2, 1, 'DA_NOP', 0, DATEADD(DAY, 8,  (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 1))),
(3, 2, 'DA_NOP', 0, DATEADD(DAY, 6,  (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 2))),
(4, 3, 'DA_NOP', 0, DATEADD(DAY, 7,  (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 3))),
(5, 4, 'DA_NOP', 0, DATEADD(DAY, 10, (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 4))),
(6, 1, 'TRUNG_TUYEN', 0, DATEADD(DAY, 12, (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 1))),
(7, 3, 'DA_NOP', 0, DATEADD(DAY, 4,  (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 3))),
(8, 5, 'DA_NOP', 0, DATEADD(DAY, 9,  (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 5))),
(9, 1, 'DA_NOP', 0, DATEADD(DAY, 14, (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 1))),
(10, 4, 'DA_NOP', 0, DATEADD(DAY, 6,  (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 4))),
(11, 2, 'DA_NOP', 0, DATEADD(DAY, 11, (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 2))),
(12, 6, 'DA_NOP', 0, DATEADD(DAY, 5,  (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 6))),
(13, 7, 'DA_NOP', 0, DATEADD(DAY, 8,  (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 7))),
(14, 8, 'DA_NOP', 0, DATEADD(DAY, 3,  (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 8))),
(15, 9, 'DA_NOP', 0, DATEADD(DAY, 13, (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 9)));

-- Thêm 10 hồ sơ ứng tuyển mới (ut_id dự kiến 16..25)
INSERT INTO UngTuyen (uv_id, tin_id, trang_thai, da_thanh_toan_phi, ngay_nop) VALUES
(1, 11, 'DA_NOP', 0, DATEADD(DAY, 6,  (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 11))),
(2, 12, 'DA_NOP', 0, DATEADD(DAY, 9,  (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 12))),
(3, 13, 'DA_NOP', 0, DATEADD(DAY, 4,  (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 13))),
(4, 14, 'DA_NOP', 0, DATEADD(DAY, 12, (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 14))),
(5, 15, 'DA_NOP', 0, DATEADD(DAY, 8,  (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 15))),
(6, 16, 'DA_NOP', 0, DATEADD(DAY, 3,  (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 16))),
(7, 17, 'DA_NOP', 0, DATEADD(DAY, 7,  (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 17))),
(8, 18, 'DA_NOP', 0, DATEADD(DAY, 10, (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 18))),
(9, 11, 'DA_NOP', 0, DATEADD(DAY, 11, (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 11))),
(10, 12, 'DA_NOP', 0, DATEADD(DAY, 5,  (SELECT ngay_dang FROM TinTuyenDung WHERE tin_id = 12)));

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