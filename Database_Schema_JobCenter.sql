-- =============================================
-- Database Schema for Student Job Placement Center
-- Hệ thống quản lý trung tâm giới thiệu việc làm
-- =============================================

-- Tạo database
CREATE DATABASE JobPlacementCenter;
GO

USE JobPlacementCenter;
GO

-- =============================================
-- DROP TABLES
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TR_UngTuyen_CheckTinHopLe]') AND type in (N'TR'))
    DROP TRIGGER [dbo].[TR_UngTuyen_CheckTinHopLe];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_TinhTongTienHoaDon]') AND type in (N'FN', N'IF', N'TF'))
    DROP FUNCTION [dbo].[FN_TinhTongTienHoaDon];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_TinhTongTienUngTuyen]') AND type in (N'FN', N'IF', N'TF'))
    DROP FUNCTION [dbo].[FN_TinhTongTienUngTuyen];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FN_TinhTongTienTinTuyenDung]') AND type in (N'FN', N'IF', N'TF'))
    DROP FUNCTION [dbo].[FN_TinhTongTienTinTuyenDung];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_KiemTraTinHetHan]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[SP_KiemTraTinHetHan];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TR_HoaDon_UpdateTinThanhToan]') AND type in (N'TR'))
    DROP TRIGGER [dbo].[TR_HoaDon_UpdateTinThanhToan];
GO



IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HoaDon]') AND type in (N'U'))
    DROP TABLE [dbo].[HoaDon];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UngTuyen]') AND type in (N'U'))
    DROP TABLE [dbo].[UngTuyen];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TinTuyenDung_KyNang]') AND type in (N'U'))
    DROP TABLE [dbo].[TinTuyenDung_KyNang];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TinTuyenDung_ViTri]') AND type in (N'U'))
    DROP TABLE [dbo].[TinTuyenDung_ViTri];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TinTuyenDung]') AND type in (N'U'))
    DROP TABLE [dbo].[TinTuyenDung];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DoanhNghiep]') AND type in (N'U'))
    DROP TABLE [dbo].[DoanhNghiep];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UngVien]') AND type in (N'U'))
    DROP TABLE [dbo].[UngVien];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NhanVien]') AND type in (N'U'))
    DROP TABLE [dbo].[NhanVien];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VaiTro_QuyenHan]') AND type in (N'U'))
    DROP TABLE [dbo].[VaiTro_QuyenHan];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChucNang]') AND type in (N'U'))
    DROP TABLE [dbo].[ChucNang];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VaiTro]') AND type in (N'U'))
    DROP TABLE [dbo].[VaiTro];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ViTriChuyenMon]') AND type in (N'U'))
    DROP TABLE [dbo].[ViTriChuyenMon];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Nghe]') AND type in (N'U'))
    DROP TABLE [dbo].[Nghe];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NhomNghe]') AND type in (N'U'))
    DROP TABLE [dbo].[NhomNghe];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PhiDichVu]') AND type in (N'U'))
    DROP TABLE [dbo].[PhiDichVu];
GO

-- =============================================
-- 1. BẢNG MASTER DATA (Dữ liệu chuẩn)
-- =============================================

-- Trong nhóm nghề sẽ phân ra làm các nghề
-- Trong nghề sẽ phân ra làm các vị trí chuyên môn
-- Vị trí chuyên môn này cũng có thể hiểu là công việc/ vị trí làm việc

-- Bảng nhóm nghề (cấp 1)
CREATE TABLE NhomNghe (
    nhom_id INT IDENTITY(1,1) PRIMARY KEY, -- Mã nhóm nghề tự tăng
    ten_nhom NVARCHAR(100) NOT NULL UNIQUE, -- Tên nhóm nghề
    trang_thai VARCHAR(20) DEFAULT 'active' -- active, inactive
);

-- Bảng nghề (cấp 2)
CREATE TABLE Nghe (
    nghe_id INT IDENTITY(1,1) PRIMARY KEY, -- Mã nghề tự tăng
    nhom_id INT NOT NULL, -- Mã nhóm nghề
    ten_nghe NVARCHAR(100) NOT NULL, -- Tên nghề
    trang_thai VARCHAR(20) DEFAULT 'active', -- active, inactive
    FOREIGN KEY (nhom_id) REFERENCES NhomNghe(nhom_id),
    UNIQUE(nhom_id, ten_nghe)
);

-- Bảng vị trí chuyên môn (cấp 3)
CREATE TABLE ViTriChuyenMon (
    vt_id INT IDENTITY(1,1) PRIMARY KEY, -- Mã vị trí chuyên môn tự tăng
    nghe_id INT NOT NULL, -- Mã nghề
    ten_vi_tri NVARCHAR(100) NOT NULL, -- Tên vị trí chuyên môn
    trang_thai VARCHAR(20) DEFAULT 'active', -- active, inactive
    FOREIGN KEY (nghe_id) REFERENCES Nghe(nghe_id),
    UNIQUE(nghe_id, ten_vi_tri)
);


-- Bảng phí dịch vụ: Còn 2 dịch vụ chính: Phí ứng tuyển (cố định) và Phí đăng tin (7k/ngày)
-- MẶC ĐỊNH TA CÓ 2 PHÍ THEO ID TƯƠNG ỨNG SAU:
-- Phí ứng tuyển: phi_id = 1
-- Phí đăng tin: phi_id = 2 (7k/ngày)

-- GIÁ TIỀN PHÍ DỊCH VỤ:
-- Phí ứng tuyển: 30k (cố định)

-- Tiền thu = Số ngày tồn tại tin × Giá/ngày
-- Số ngày tồn tại tin = (han_nop_ho_so - ngay_dang) + 1 (cộng 1 vì ngày đầu tiên đăng tin cũng tính)
CREATE TABLE PhiDichVu (
    phi_id INT PRIMARY KEY, -- Mã phí dịch vụ (1: ứng tuyển, 2: đăng tin)
    ten_dich_vu NVARCHAR(100) NOT NULL, -- Tên phí dịch vụ
    so_tien DECIMAL(10,0) NOT NULL -- Giá tiền: phí ứng tuyển (cố định) hoặc phí đăng tin theo ngày
);

-- =============================================
-- 2. BẢNG QUẢN LÝ NGƯỜI DÙNG & PHÂN QUYỀN
-- =============================================

-- Bảng nhân viên trung tâm
-- Bảng vai trò (RBAC Role)
-- Lưu danh sách vai trò hệ thống (CSS, ERS, FO, SA, CM)
CREATE TABLE VaiTro (
    vai_tro_id VARCHAR(20) PRIMARY KEY, -- Mã vai trò: CSS, ERS, FO, SA, CM
    ten_vai_tro NVARCHAR(100) NOT NULL -- Tên vai trò
);

-- Bảng chức năng (RBAC Permission/Feature)
-- Lưu danh sách chức năng có thể cấp quyền (tên tiếng Việt và mô tả ngắn)
CREATE TABLE ChucNang (
    chuc_nang_id VARCHAR(10) PRIMARY KEY, -- Mã chức năng: CN001, CN002, ...
    ten_chuc_nang NVARCHAR(100) UNIQUE NOT NULL, -- Tên chức năng
    mo_ta NVARCHAR(200) NULL -- Mô tả chức năng
);

-- Bảng phân quyền vai trò - chức năng
-- Xác định vai trò có quyền (0/1) trên từng chức năng
CREATE TABLE VaiTro_QuyenHan (
    vai_tro_id VARCHAR(20) NOT NULL, -- Tham chiếu VaiTro
    chuc_nang_id VARCHAR(10) NOT NULL, -- Tham chiếu ChucNang
    quyen_han BIT NOT NULL DEFAULT 0, -- 1: được phép sử dụng, 0: không được phép
    PRIMARY KEY (vai_tro_id, chuc_nang_id),
    FOREIGN KEY (vai_tro_id) REFERENCES VaiTro(vai_tro_id),
    FOREIGN KEY (chuc_nang_id) REFERENCES ChucNang(chuc_nang_id)
);

CREATE TABLE NhanVien (
    ma_nhan_vien INT IDENTITY(1,1) PRIMARY KEY,  -- Mã nhân viên tự tăng
    ho_ten NVARCHAR(100) NOT NULL, -- Họ tên
    email NVARCHAR(100) UNIQUE NOT NULL, -- Email
    so_dien_thoai VARCHAR(20), -- Số điện thoại
    username VARCHAR(50) UNIQUE NOT NULL, -- Tên đăng nhập
    password_hash VARCHAR(255) NOT NULL, -- Mã hóa MD5
    vai_tro_id VARCHAR(20) NOT NULL, -- Mã vai trò (CSS, ERS, FO, SA, CM) tham chiếu VaiTro
    trang_thai VARCHAR(20) DEFAULT 'active', -- active, inactive
    FOREIGN KEY (vai_tro_id) REFERENCES VaiTro(vai_tro_id)
);

-- =============================================
-- 3. BẢNG ỨNG VIÊN
-- =============================================

-- Bảng ứng viên - CSS quản lý
CREATE TABLE UngVien (
    uv_id INT IDENTITY(1,1) PRIMARY KEY, -- id ứng viên tự tăng
    ho_ten NVARCHAR(100) NOT NULL, -- Họ tên
    email NVARCHAR(100) UNIQUE NOT NULL, -- Email
    so_dien_thoai VARCHAR(20), -- Số điện thoại
    cccd VARCHAR(12) UNIQUE NOT NULL, -- Căn cước công dân (12 số)
    ngay_sinh DATE NOT NULL, -- Ngày sinh
    que_quan NVARCHAR(200), -- Quê quán
    
    -- Khi ứng viên đến tìm việc thì chỉ cần nêu họ tên/cccd rồi hiển thị ra tin tương ứng với vị trí chuyên môn mong muốn
    vt_id INT NULL, -- Vị trí chuyên môn mong muốn (dùng để matching với tin tuyển dụng)
    
    ngay_tao DATETIME DEFAULT GETDATE(), -- Ngày tạo
    FOREIGN KEY (vt_id) REFERENCES ViTriChuyenMon(vt_id)
);

-- =============================================
-- 4. BẢNG QUẢN LÝ DOANH NGHIỆP
-- =============================================

-- Bảng doanh nghiệp - ERS quản lý
CREATE TABLE DoanhNghiep (
    dn_id INT IDENTITY(1,1) PRIMARY KEY, -- id doanh nghiệp tự tăng
    ten_doanh_nghiep NVARCHAR(200) NOT NULL, -- Tên doanh nghiệp
    dia_chi NVARCHAR(500), -- Địa chỉ cụ thể công ty để liên hệ
    so_dien_thoai VARCHAR(20), -- Số điện thoại
    email NVARCHAR(100), -- Email
    -- Theo tiêu chuẩn MST có thể là 10 số hoặc 13 số
    -- Đối với MST 13 số thì thường dấu gạch ngang phân cách giữa số thứ 10 và 11 (ví dụ: 1234567890-001)
    ma_so_thue VARCHAR(14) UNIQUE NOT NULL, -- MST 10 hoặc 13 chữ số (14 ký tự) theo MST tiêu chuẩn
    linh_vuc NVARCHAR(100), -- Lĩnh vực hoạt động
    ngay_tao DATETIME DEFAULT GETDATE() -- Ngày tạo
);

-- Bảng tin tuyển dụng - ERS quản lý
CREATE TABLE TinTuyenDung (
    tin_id INT IDENTITY(1,1) PRIMARY KEY, -- id tin tuyển dụng tự tăng

    -- Thông tin liên hệ của doanh nghiệp sẽ được lấy từ bảng DoanhNghiep
    dn_id INT NOT NULL, -- id doanh nghiệp để liên kết với các thông tin như địa chỉ sdt, email dựa vào bảng DoanhNghiep
    
    tieu_de NVARCHAR(200) NOT NULL, -- Tiêu đề tuyển dụng
    mo_ta_cong_viec NVARCHAR(2000), -- Mô tả công việc chi tiết cụ thể (tự nhập qua richtextbox)

    -- LƯU Ý:
    -- Vị trí chuyên môn của tin tuyển dụng này được lưu trong bảng TinTuyenDung_ViTri
    -- Tin tuyển dụng có thể chọn nhiều vị trí chuyên môn dựa vào bảng ViTriChuyenMon

    -- Kỹ năng yêu cầu của tin tuyển dụng này được lưu trong bảng TinTuyenDung_KyNang
    -- Tin tuyển dụng có thể add kỹ năng yêu cầu dựa vào nhu cầu chính doanh nghiệp


    so_luong_tuyen INT DEFAULT 1 CHECK (so_luong_tuyen > 0), -- Số lượng tuyển nhiều hơn 0
    muc_luong NVARCHAR(100), -- Mức lương: "8-12 triệu", "Thỏa thuận", "15-20 triệu"
    khu_vuc_lam_viec NVARCHAR(200), -- Khu vực thành phố làm việc (TP.HCM, Hà Nội, Đà Nẵng, ...)
    hinh_thuc_lam_viec NVARCHAR(50), -- Toàn thời gian/Bán thời gian/Thực tập
    kinh_nghiem_yeu_cau INT DEFAULT 0 CHECK (kinh_nghiem_yeu_cau >= 0), -- Yêu cầu kinh nghiệm (số năm)
    
    -- Doanh nghiệp được phép tùy chọn hạn nộp và tính tiền theo số ngày tồn tại = hạn nộp - ngày đăng
    han_nop_ho_so DATE NOT NULL, -- Hạn nộp hồ sơ/ Hạn tin tuyển dụng kết thúc
    ngay_dang DATETIME DEFAULT GETDATE(),
    
    -- Khi khởi tạo thì là inactive, sẽ active khi FO cập nhật (nghĩa là thanh toán hóa đơn)
    -- ERS tạo tin -> inactive -> FO cập nhật -> active -> Hiển thị lên trang tuyển dụng
    trang_thai VARCHAR(20) DEFAULT 'inactive', -- active khi FO cập nhật, inactive khi hết hạn nộp hồ sơ hoặc doanh nghiệp yêu cầu hủy sớm 
    
    -- Phí đăng tin cố định: phi_id = 2
    phi_id INT NOT NULL DEFAULT 2, -- ID phí dịch vụ đăng tin cho DOANH NGHIỆP (chỉ 2)
    da_thanh_toan BIT DEFAULT 0, -- Tin chỉ hiển thị sau khi FO cập nhật = 1 (thanh toán hóa đơn)

    FOREIGN KEY (dn_id) REFERENCES DoanhNghiep(dn_id),
    FOREIGN KEY (phi_id) REFERENCES PhiDichVu(phi_id)
);

-- Bảng vị trí chuyên môn cho tin tuyển dụng, vị trí phải chọn từ danh sách có sẵn
-- Một bảng tin có thể có nhiều vị trí chuyên môn tùy nhu cầu doanh nghiệp
-- Mỗi vị trí chuyên môn phải chọn từ danh sách có sẵn
CREATE TABLE TinTuyenDung_ViTri (
    tin_id INT NOT NULL, -- id tin tuyển dụng
    vt_id INT NOT NULL, -- id vị trí chuyên môn
    PRIMARY KEY (tin_id, vt_id),
    FOREIGN KEY (tin_id) REFERENCES TinTuyenDung(tin_id),
    FOREIGN KEY (vt_id) REFERENCES ViTriChuyenMon(vt_id)
);

-- Bảng kỹ năng yêu cầu theo vị trí chuyên môn của tin tuyển dụng
-- Mỗi tin có thể gắn nhiều vị trí (TinTuyenDung_ViTri), và mỗi vị trí có thể yêu cầu nhiều kỹ năng
-- Lưu ý: Liên kết (tin_id, vt_id) tới bảng TinTuyenDung_ViTri để đảm bảo vị trí thuộc đúng tin
-- Kỹ năng được doanh nghiệp tự phép nhập thêm vào theo yêu cầu, không theo danh sách có sẵn
CREATE TABLE TinTuyenDung_KyNang (
    tin_id INT NOT NULL, -- id tin tuyển dụng
    vt_id INT NOT NULL, -- id vị trí chuyên môn trong tin
    ten_ky_nang NVARCHAR(50) NOT NULL, -- Tên kỹ năng yêu cầu (tự nhập qua textbox)
    PRIMARY KEY (tin_id, vt_id, ten_ky_nang),
    FOREIGN KEY (tin_id, vt_id) REFERENCES TinTuyenDung_ViTri(tin_id, vt_id)
);


-- =============================================
-- 5. BẢNG QUẢN LÝ ỨNG TUYỂN
-- =============================================

-- Bảng ứng tuyển - CSS ghi nhận, ERS cập nhật kết quả
CREATE TABLE UngTuyen (
    ut_id INT IDENTITY(1,1) PRIMARY KEY, -- id ứng tuyển tự tăng
    uv_id INT NOT NULL, -- id ứng viên nào ứng tuyển
    tin_id INT NOT NULL, -- id tin tuyển dụng nào được ứng tuyển

    -- Trạng thái ứng tuyển:
    -- DA_NOP: Đã nộp hồ sơ
    -- TRUNG_TUYEN: Trúng tuyển
    -- KHONG_TRUNG_TUYEN: Không trúng tuyển
    trang_thai VARCHAR(20) DEFAULT 'DA_NOP', -- DA_NOP, TRUNG_TUYEN, KHONG_TRUNG_TUYEN

    -- Mặc định phí ứng tuyển: phi_id = 1
    phi_id INT NOT NULL DEFAULT 1, -- ID phí dịch vụ ứng tuyển cho ỨNG VIÊN

    da_thanh_toan_phi BIT DEFAULT 0, -- FO cập nhật = 1 sau khi thu tiền
    ngay_nop DATETIME DEFAULT GETDATE(), -- Ngày nộp hồ sơ

    FOREIGN KEY (uv_id) REFERENCES UngVien(uv_id),
    FOREIGN KEY (tin_id) REFERENCES TinTuyenDung(tin_id),
    FOREIGN KEY (phi_id) REFERENCES PhiDichVu(phi_id),
    UNIQUE(uv_id, tin_id) -- Mỗi ứng viên chỉ ứng tuyển 1 lần cho 1 tin
);

-- =============================================
-- 6. BẢNG QUẢN LÝ TÀI CHÍNH
-- =============================================

-- Sau khi ỨNG VIÊN thực hiện ứng tuyển hoặc DOANH NGHIỆP thực hiện chọn tin đăng thì đến quầy hóa đơn
-- Sau khi thanh toán tiền thì sẽ cập nhật trạng thái da_thanh_toan = 1 cho tin tuyển dụng hoặc ứng tuyển
-- Hồ sơ ứng tuyển chỉ hợp lệ khi da_thanh_toan = 1 trong bảng UngTuyen; doanh nghiệp chỉ xem ứng viên đã thanh toán
-- Tin tuyển dụng chỉ hợp lệ khi da_thanh_toan = 1 trong bảng TinTuyenDung; ứng viên chỉ apply vào tin đã thanh toán

-- Bảng hóa đơn - FO quản lý
CREATE TABLE HoaDon (
    ma_hoa_don INT IDENTITY(1,1) PRIMARY KEY, -- id hóa đơn tự tăng

    loai_khach_hang VARCHAR(20) NOT NULL, -- ung_vien/doanh_nghiep
    uv_id INT NULL, -- ID ứng viên (NULL nếu là doanh nghiệp)
    ut_id INT NULL,  -- Link với ứng tuyển (nếu UV thanh toán)
    dn_id INT NULL, -- ID doanh nghiệp (NULL nếu là ứng viên)
    tin_id INT NULL, -- Link với tin tuyển dụng (nếu DN thanh toán)
    ten_khach_hang NVARCHAR(200) NOT NULL, -- Tên khách hàng

    -- Phí áp dụng:
    -- Ứng viên: phi_id = 1 (phí ứng tuyển cố định)
    -- Doanh nghiệp: phi_id = 2 (phí đăng tin theo ngày)
    phi_id INT NOT NULL, -- ID phí dịch vụ (1 hoặc 2)

    -- Số tiền THỰC TẾ THU (có thể khác PhiDichVu.so_tien nếu thực hiện thay đổi giá)
    so_tien DECIMAL(10,0) NOT NULL, -- Tiền Việt Nam đồng nên để DECIMAL(10,0)
    ngay_lap_hoa_don DATETIME DEFAULT GETDATE(), -- Ngày lập hóa đơn
    ma_nhan_vien_lap INT NOT NULL, -- Nhân viên tài chính lập hóa đơn

    FOREIGN KEY (uv_id) REFERENCES UngVien(uv_id),
    FOREIGN KEY (dn_id) REFERENCES DoanhNghiep(dn_id),
    FOREIGN KEY (ma_nhan_vien_lap) REFERENCES NhanVien(ma_nhan_vien),
    FOREIGN KEY (phi_id) REFERENCES PhiDichVu(phi_id),
    FOREIGN KEY (tin_id) REFERENCES TinTuyenDung(tin_id),
    FOREIGN KEY (ut_id) REFERENCES UngTuyen(ut_id)
);

-- Đảm bảo logic: Nếu là ứng viên thì phải có ut_id, nếu là doanh nghiệp thì phải có tin_id
ALTER TABLE HoaDon ADD CONSTRAINT CK_HoaDon_Logic 
CHECK (
    (loai_khach_hang = 'ung_vien' AND uv_id IS NOT NULL AND ut_id IS NOT NULL AND dn_id IS NULL AND tin_id IS NULL) OR
    (loai_khach_hang = 'doanh_nghiep' AND dn_id IS NOT NULL AND tin_id IS NOT NULL AND uv_id IS NULL AND ut_id IS NULL)
);


-- =============================================
-- 8. CONSTRAINTS VÀ INDEXES
-- =============================================

-- Constraints cho giá trị hợp lệ
ALTER TABLE HoaDon ADD CONSTRAINT CK_LoaiKhachHang 
CHECK (loai_khach_hang IN ('ung_vien', 'doanh_nghiep'));

ALTER TABLE UngTuyen ADD CONSTRAINT CK_TrangThaiUngTuyen 
CHECK (trang_thai IN ('DA_NOP', 'TRUNG_TUYEN', 'KHONG_TRUNG_TUYEN'));

-- Đảm bảo hạn nộp sau ngày đăng
ALTER TABLE TinTuyenDung ADD CONSTRAINT CK_TinTuyenDung_HanNop 
CHECK (han_nop_ho_so >= CAST(ngay_dang AS DATE));

-- Đảm bảo phi_id cho tin tuyển dụng chỉ là 2
ALTER TABLE TinTuyenDung ADD CONSTRAINT CK_TinTuyenDung_PhiID 
CHECK (phi_id = 2);

-- Đảm bảo UngTuyen chỉ dùng phi_id = 1
ALTER TABLE UngTuyen ADD CONSTRAINT CK_UngTuyen_PhiID 
CHECK (phi_id = 1);

ALTER TABLE HoaDon ADD CONSTRAINT CK_HoaDon_PhiTheoLoai
CHECK (
 (loai_khach_hang='ung_vien' AND phi_id=1)
 OR
 (loai_khach_hang='doanh_nghiep' AND phi_id = 2)
);

ALTER TABLE TinTuyenDung ADD CONSTRAINT CK_TTD_HinhThuc
CHECK (hinh_thuc_lam_viec IN (N'Toàn thời gian', N'Bán thời gian', N'Thực tập'));

ALTER TABLE DoanhNghiep 
ADD CONSTRAINT CK_DoanhNghiep_MST
CHECK (
    (LEN(ma_so_thue) = 10  AND ma_so_thue NOT LIKE '%[^0-9]%')
 OR (LEN(ma_so_thue) = 14 AND ma_so_thue LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]-[0-9][0-9][0-9]')
);


ALTER TABLE NhomNghe        ADD CONSTRAINT CK_NhomNghe_TrangThai        CHECK (trang_thai IN ('active','inactive'));
ALTER TABLE Nghe            ADD CONSTRAINT CK_Nghe_TrangThai            CHECK (trang_thai IN ('active','inactive'));
ALTER TABLE ViTriChuyenMon  ADD CONSTRAINT CK_VTCM_TrangThai            CHECK (trang_thai IN ('active','inactive'));
ALTER TABLE TinTuyenDung    ADD CONSTRAINT CK_TinTuyenDung_TrangThai    CHECK (trang_thai IN ('active', 'inactive'));
ALTER TABLE UngVien         ADD CONSTRAINT CK_UngVien_CCCD              CHECK (LEN(cccd)=12 AND cccd NOT LIKE '%[^0-9]%');

-- Indexes cho performance
CREATE INDEX IX_UngVien_CCCD ON UngVien(cccd);
CREATE INDEX IX_UngVien_ViTri ON UngVien(vt_id);

CREATE INDEX IX_TinTuyenDung_KyNang_TinViTri ON TinTuyenDung_KyNang(tin_id, vt_id);
CREATE INDEX IX_TinTuyenDung_KyNang_Ten ON TinTuyenDung_KyNang(ten_ky_nang);

CREATE INDEX IX_DoanhNghiep_Email ON DoanhNghiep(email);

CREATE INDEX IX_TinTuyenDung_TrangThai ON TinTuyenDung(trang_thai);
CREATE INDEX IX_TinTuyenDung_DoanhNghiep ON TinTuyenDung(dn_id);
CREATE INDEX IX_TinTuyenDung_HanNop ON TinTuyenDung(han_nop_ho_so);
CREATE INDEX IX_TinTuyenDung_DaThanhToan ON TinTuyenDung(da_thanh_toan);
CREATE INDEX IX_TinTuyenDung_KhuVuc ON TinTuyenDung(khu_vuc_lam_viec);
CREATE INDEX IX_TinTuyenDung_MucLuong ON TinTuyenDung(muc_luong);
CREATE INDEX IX_TinTuyenDung_HinhThuc ON TinTuyenDung(hinh_thuc_lam_viec);
CREATE INDEX IX_TinTuyenDung_ViTri_Tin ON TinTuyenDung_ViTri(tin_id);
CREATE INDEX IX_TinTuyenDung_ViTri_ViTri ON TinTuyenDung_ViTri(vt_id);

CREATE INDEX IX_UngTuyen_UngVien ON UngTuyen(uv_id);
CREATE INDEX IX_UngTuyen_TinTuyenDung ON UngTuyen(tin_id);
CREATE INDEX IX_UngTuyen_TrangThai ON UngTuyen(trang_thai);
CREATE INDEX IX_UngTuyen_DaThanhToan ON UngTuyen(da_thanh_toan_phi);

CREATE INDEX IX_HoaDon_UngVien ON HoaDon(uv_id);
CREATE INDEX IX_HoaDon_DoanhNghiep ON HoaDon(dn_id);
CREATE INDEX IX_HoaDon_NgayLap ON HoaDon(ngay_lap_hoa_don);
CREATE INDEX IX_HoaDon_TinTuyenDung ON HoaDon(tin_id);
CREATE INDEX IX_HoaDon_UngTuyen ON HoaDon(ut_id);

CREATE INDEX IX_NhanVien_VaiTroId ON NhanVien(vai_tro_id);

CREATE INDEX IX_VaiTro_Ten ON VaiTro(ten_vai_tro);
CREATE INDEX IX_ChucNang_Ten ON ChucNang(ten_chuc_nang);
CREATE INDEX IX_VaiTroQuyen_VaiTro ON VaiTro_QuyenHan(vai_tro_id);
CREATE INDEX IX_VaiTroQuyen_ChucNang ON VaiTro_QuyenHan(chuc_nang_id);

CREATE INDEX IX_PhiDichVu_TenDichVu ON PhiDichVu(ten_dich_vu);

CREATE INDEX IX_Nghe_Nhom ON Nghe(nhom_id);
CREATE INDEX IX_ViTri_Nghe ON ViTriChuyenMon(nghe_id);


-- Trigger: Chỉ cho phép ứng tuyển tin đã thanh toán
-- Chỉ ứng tuyển (INSERT) tin đã thanh toán và đang active
-- Chỉ UPDATE sau khi biết ứng viên TRUNG_TUYEN hoặc KHONG_TRUNG_TUYEN
GO
CREATE TRIGGER TR_UngTuyen_CheckTinHopLe
ON UngTuyen
FOR INSERT, UPDATE
AS
BEGIN

    -- Chỉ check khi INSERT (ứng tuyển mới)
    IF EXISTS (SELECT 1 FROM inserted) AND NOT EXISTS (SELECT 1 FROM deleted)
    BEGIN
        -- Check tin hợp lệ tại thời điểm ứng tuyển
        IF EXISTS (
            SELECT 1 
            FROM inserted i
            INNER JOIN TinTuyenDung t ON i.tin_id = t.tin_id
            WHERE t.da_thanh_toan = 0 
               OR t.trang_thai != 'active'
               -- Kiểm tra ngày nộp <= hạn nộp hồ sơ
               -- VD: Hạn 29/10, nộp 29/10 → OK, nộp 30/10 → KHÔNG OK
               OR CAST(i.ngay_nop AS DATE) > t.han_nop_ho_so -- So với ngày nộp, không phải ngày hiện tại
               -- Ví dụ hạn nộp ngày 29/10/2025, ngày nộp 30/10/2025 thì không hợp lệ
               -- Ví dụ hạn nộp ngày 29/10/2025, ngày nộp 28/10/2025 thì hợp lệ
               -- Ví dụ hạn nộp ngày 29/10/2025, ngày nộp 29/10/2025 thì hợp lệ
        )
        BEGIN
            RAISERROR(N'Không thể ứng tuyển tin không hợp lệ hoặc đã hết hạn!', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
    END
    
    -- UPDATE: chỉ chặn khi đổi tin_id; còn lại (trang_thai cho việc Cập nhật kết quả tuyển dụng) cho phép
    -- Điều này sẽ giúp việc chỉnh trạng thái thành TRUNG_TUYEN, KHONG_TRUNG_TUYEN
    IF EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
    BEGIN
        IF EXISTS (
            SELECT 1
            FROM inserted i
            JOIN deleted d ON d.ut_id = i.ut_id
            WHERE i.tin_id != d.tin_id
        )
        BEGIN
            RAISERROR(N'Không được phép đổi tin tuyển dụng của hồ sơ ứng tuyển.', 16, 1);
            ROLLBACK TRANSACTION; 
            RETURN;
        END
    END
END;


-- Trigger này để tự động cập nhật trạng thái thanh toán và active tin
-- Khi tạo tin thì chưa thanh toán, vì vậy khi thanh toán hóa đơn rồi thì da_thanh_toan = 1
GO
CREATE TRIGGER TR_HoaDon_UpdateTinThanhToan
ON HoaDon
FOR INSERT
AS
BEGIN
    -- Cập nhật tin tuyển dụng đã thanh toán và active khi có hóa đơn doanh nghiệp
    UPDATE TinTuyenDung 
    SET da_thanh_toan = 1, trang_thai = 'active'
    WHERE da_thanh_toan = 0 AND tin_id IN (
        SELECT tin_id 
        FROM inserted 
        WHERE loai_khach_hang = 'doanh_nghiep' AND tin_id IS NOT NULL
    );
    
    -- Cập nhật ứng tuyển đã thanh toán khi có hóa đơn sinh viên
    UPDATE UngTuyen 
    SET da_thanh_toan_phi = 1
    WHERE da_thanh_toan_phi = 0 AND ut_id IN (
        SELECT ut_id 
        FROM inserted 
        WHERE loai_khach_hang = 'ung_vien' AND ut_id IS NOT NULL
    );
END;

-- Procedure đơn giản chỉ inactive tin hết hạn
GO
CREATE PROCEDURE SP_KiemTraTinHetHan
AS
BEGIN
    UPDATE TinTuyenDung 
    SET trang_thai = 'inactive'
    WHERE han_nop_ho_so < CAST(GETDATE() AS DATE) 
      AND trang_thai = 'active';
      
    SELECT @@ROWCOUNT as SoTinDaInactive;
END;

-- =============================================
-- FUNCTION TÍNH TỔNG TIỀN
-- =============================================

-- Function tính tổng tiền cho tin tuyển dụng dựa trên logic theo ngày
GO
CREATE FUNCTION FN_TinhTongTienTinTuyenDung(
    @phi_id INT,
    @ngay_dang DATETIME,
    @han_nop_ho_so DATE
)
RETURNS DECIMAL(10,0)
AS
BEGIN
    DECLARE @so_tien DECIMAL(10,0) = 0;
    DECLARE @so_ngay INT = 0;
    
    -- Tính số ngày tồn tại tin
    SET @so_ngay = DATEDIFF(DAY, CAST(@ngay_dang AS DATE), @han_nop_ho_so) + 1;
    
    -- Lấy giá theo ngày từ bảng PhiDichVu
    SELECT @so_tien = so_tien 
    FROM PhiDichVu 
    WHERE phi_id = @phi_id;
    
    -- Tính tổng tiền = số ngày × giá/ngày
    SET @so_tien = @so_ngay * @so_tien;
    RETURN @so_tien;
END;

-- Function tính tổng tiền cho phí ứng tuyển dựa trên phi_id
GO
CREATE FUNCTION FN_TinhTongTienUngTuyen(
    @phi_id INT
)
RETURNS DECIMAL(10,0)
AS
BEGIN
    DECLARE @so_tien DECIMAL(10,0) = 0;
    -- Lấy giá cố định cúa phí ứng tuyển dựa trên bảng PhiDichVu
    SELECT @so_tien = so_tien 
    FROM PhiDichVu 
    WHERE phi_id = @phi_id;
    RETURN @so_tien;
END;

-- Function tổng hợp tính tiền cho hóa đơn CHO ỨNG VIÊN VÀ DOANH NGHIỆP
GO
CREATE FUNCTION FN_TinhTongTienHoaDon(
    @loai_khach_hang VARCHAR(20),
    @phi_id INT,
    @ngay_dang DATETIME = NULL,
    @han_nop_ho_so DATE = NULL
)
RETURNS DECIMAL(10,0)
AS
BEGIN
    DECLARE @so_tien DECIMAL(10,0) = 0;
    -- Nếu là phí ứng tuyển (phi_id = 1) thì dùng giá cố định
    IF @phi_id = 1
    BEGIN
        SET @so_tien = dbo.FN_TinhTongTienUngTuyen(@phi_id);
    END
    -- Nếu là phí đăng tin thì tính theo ngày
    ELSE
    BEGIN
        -- Kiểm tra tham số bắt buộc
        IF @ngay_dang IS NULL OR @han_nop_ho_so IS NULL
        BEGIN
            RETURN 0;
        END
        SET @so_tien = dbo.FN_TinhTongTienTinTuyenDung(@phi_id, @ngay_dang, @han_nop_ho_so);
    END
    RETURN @so_tien;
END;