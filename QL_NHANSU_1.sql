﻿-- Tạo cơ sở dữ liệu QL_NHANSU
CREATE DATABASE QL_NHANSU;
GO

-- Sử dụng cơ sở dữ liệu QL_NHANSU
USE QL_NHANSU;
GO
--Bảng phòng ban
CREATE TABLE PhongBan (
    MaPhong VARCHAR(50) PRIMARY KEY,
    TenPhong NVARCHAR(100),
	MoTa NVARCHAR(255)
);
--Tạo bảng Bộ phận
CREATE TABLE BoPhan (
    MaBoPhan VARCHAR(50) PRIMARY KEY,
    TenBoPhan NVARCHAR(100),
	MaPhong VARCHAR(50) NOT NULL,
	MoTa NVARCHAR(255),
	CONSTRAINT FK_BOPHAN_PHONGBAN FOREIGN KEY (MaPhong) REFERENCES PhongBan(MaPhong)
);
--Bảng chức vụ:
CREATE TABLE ChucVu (
    MaChucVu VARCHAR(50) PRIMARY KEY,
    TenChucVu NVARCHAR(100)
);

-- Bảng trình độ năng lực
CREATE TABLE TrinhDoNangLuc (
    MaTrinhDo VARCHAR(50) PRIMARY KEY,
    TenTrinhDo NVARCHAR(100)
);

-- Tạo bảng Nhân Viên
CREATE TABLE NhanVien (
    MaNV VARCHAR(50) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(3) Check(GioiTinh in ('Nam', N'Nữ')),
    NgaySinh DATE,
    DiaChi NVARCHAR(255),
    CCCD VARCHAR(12),
	Hinhanh VARCHAR(255),
	MaChucVu VARCHAR(50),
    MaBoPhan VARCHAR(50),
    MaPhong VARCHAR(50),
    TrangThai NVARCHAR(100),
    MaTrinhDo VARCHAR(50),
	FOREIGN KEY (MaChucVu) REFERENCES ChucVu(MaChucVu),
	FOREIGN KEY (MaBoPhan) REFERENCES BoPhan(MaBoPhan),
	FOREIGN KEY (MaPhong) REFERENCES PhongBan(MaPhong),
	FOREIGN KEY (MaTrinhDo) REFERENCES TrinhDoNangLuc(MaTrinhDo),
);

-- Tạo bảng Hợp đồng
CREATE TABLE HopDong (
    SoHopDong INT PRIMARY KEY,
    NgayBatDau DATE,
    NgayKetThuc DATE,
	--HOTEN NVARCHAR(50),
	NoiDung NVARCHAR(255),
    ThoiHan INT,
    HeSoLuong DECIMAL(10, 2),
    MaNV VARCHAR(50),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);


-- Bảng bảo hiểm
CREATE TABLE BaoHiem (
    MaBaoHiem INT PRIMARY KEY,
    SoBaoHiem NVARCHAR(50),
    NgayCap DATE,
    NoiCap NVARCHAR(100),
    NoiKhamBenh NVARCHAR(100),
    MaNV VARCHAR(50),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);


-- Tạo bảng CHAMCONG
CREATE TABLE CHAMCONG
(
    ID_CHAMCONG CHAR(20) NOT NULL,
    NGAYVAO DATETIME,
	TRANGTHAIVAO BIT NULL,
	TRANGTHAIRA BIT NULL,
    MaNV VARCHAR(50) NOT NULL,
    CONSTRAINT PK_CHAMCONG PRIMARY KEY (ID_CHAMCONG, MaNV),
	CONSTRAINT FK_CHAMCONG_EMPLOYEE FOREIGN KEY (MANV) REFERENCES NhanVien(MANV)
);
GO
CREATE TRIGGER SET_NGAYVAO
ON CHAMCONG
FOR INSERT 
AS
BEGIN
    SET NOCOUNT ON;--Ngăn không cho SQL Server gửi thông báo về số dòng đã bị ảnh hưởng đến client.
	--Điều này có thể giúp cải thiện hiệu suất, đặc biệt khi trigger thực hiện nhiều lệnh.

    UPDATE CHAMCONG
    SET NGAYVAO = GETDATE() -- Lấy ngày và giờ hiện tại
    FROM CHAMCONG cc
    INNER JOIN inserted i ON cc.ID_CHAMCONG = i.ID_CHAMCONG AND cc.MANV = i.MANV;
END;
GO

CREATE TABLE BANGCONG
(
    ID_BANGCONG UNIQUEIDENTIFIER ,
    MaNV VARCHAR(50) NOT NULL,
    NGAY INT,
    THANG INT,
    NAM INT,
    ID_CHAMCONG CHAR(20),
    TRANGTHAI NVARCHAR(20),
	MOTA NVARCHAR(255),
	TONGNGAYCONG INT,
    CONSTRAINT PK_BANGCONG PRIMARY KEY (ID_BANGCONG),
    CONSTRAINT FK_BANGCONG_EMPLOYEE FOREIGN KEY (MANV) REFERENCES NhanVien(MANV),
    CONSTRAINT FK_BANGCONG_CHAMCONG FOREIGN KEY (ID_CHAMCONG, MANV) REFERENCES CHAMCONG(ID_CHAMCONG, MANV),
    CONSTRAINT CHK_NGAY CHECK 
    (
        (NGAY BETWEEN 1 AND 31) AND 
        (
            (THANG = 1 OR THANG = 3 OR THANG = 5 OR THANG = 7 OR THANG = 8 OR THANG = 10 OR THANG = 12) OR
            (THANG = 4 OR THANG = 6 OR THANG = 9 OR THANG = 11 AND NGAY <= 30) OR
            (THANG = 2 AND (
                (NAM % 4 = 0 AND NAM % 100 <> 0) OR NAM % 400 = 0) AND NGAY <= 29 OR
                (THANG = 2 AND NGAY <= 28)
            )
        )
    )
);
GO

ALTER TABLE BANGCONG
ADD THU AS 
    CASE DATEPART(WEEKDAY, CAST(CONCAT(NAM, '-', THANG, '-', NGAY) AS DATE))
        WHEN 1 THEN N'Chủ nhật'
        WHEN 2 THEN N'Thứ hai'
        WHEN 3 THEN N'Thứ ba'
        WHEN 4 THEN N'Thứ tư'
        WHEN 5 THEN N'Thứ năm'
        WHEN 6 THEN N'Thứ sáu'
        WHEN 7 THEN N'Thứ bảy'
    END;
GO


CREATE TRIGGER THEMDULIEUVAOBANGCONG
ON CHAMCONG
FOR INSERT
AS
BEGIN
    BEGIN TRY
        -- Chèn dữ liệu vào bảng BANGCONG với các bản ghi vừa được thêm vào bảng CHAMCONG
        INSERT INTO BANGCONG (ID_BANGCONG, MANV, NGAY, THANG, NAM, ID_CHAMCONG)
        SELECT 
            NEWID(),  -- Sinh ID_BANGCONG mới
            i.MANV,  -- Lấy MANV từ bảng ảo INSERTED
            DAY(i.NGAYVAO) AS NGAY,  
            MONTH(i.NGAYVAO) AS THANG,  
            YEAR(i.NGAYVAO) AS NAM, 
            i.ID_CHAMCONG  -- Lấy ID_CHAMCONG từ bảng ảo INSERTED
        FROM 
            INSERTED i;  -- Lấy dữ liệu từ bảng ảo INSERTED (các bản ghi mới được thêm)
    END TRY
    BEGIN CATCH
        -- In thông báo lỗi
        PRINT 'Lỗi: ' + ERROR_MESSAGE();
    END CATCH
END;
GO
CREATE TRIGGER trg_UpdateTrangThai
ON CHAMCONG
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Cập nhật TRANGTHAI trong bảng BANGCONG
    UPDATE BANGCONG
    SET TRANGTHAI = CASE 
        WHEN CH.TRANGTHAIVAO = 0 AND CH.TRANGTHAIRA = 0 THEN N'Chưa Hoàn Thành'
		WHEN CH.TRANGTHAIVAO = 1 AND CH.TRANGTHAIRA = 0 THEN N'Chưa Hoàn Thành'
		WHEN CH.TRANGTHAIVAO = 0 AND CH.TRANGTHAIRA = 1 THEN N'Chưa Hoàn Thành'
		WHEN CH.TRANGTHAIVAO IS NULL AND CH.TRANGTHAIRA IS NULL THEN N'Chưa Hoàn Thành'
        ELSE N'Hoàn Thành'
    END
    FROM BANGCONG BG
    INNER JOIN inserted I ON I.ID_CHAMCONG = BG.ID_CHAMCONG
    INNER JOIN CHAMCONG CH ON I.ID_CHAMCONG = CH.ID_CHAMCONG AND I.MANV = CH.MANV;
END;
GO
CREATE TRIGGER trg_TinhTongNgayCong
ON BANGCONG
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Cập nhật tổng số ngày công dựa trên trạng thái
    UPDATE BG
    SET TONGNGAYCONG = (
        SELECT 
            SUM(CASE 
                WHEN TRANGTHAI = 'Hoàn Thành' THEN 1 
                WHEN TRANGTHAI = 'Không Hoàn Thành' THEN -1 
                ELSE 0 
            END)
        FROM BANGCONG
        WHERE MaNV = BG.MaNV
        AND THANG = BG.THANG
        AND NAM = BG.NAM
    )
    FROM BANGCONG BG
    INNER JOIN inserted I ON BG.MaNV = I.MaNV AND BG.THANG = I.THANG AND BG.NAM = I.NAM;
END;
GO

CREATE TRIGGER trg_updateMoTa
ON BANGCONG
AFTER INSERT
AS
BEGIN
   
    DECLARE @NgayLe TABLE (
        NGAY INT,
        THANG INT,
        NAM INT,
        TENLE NVARCHAR(100)
    );

    INSERT INTO @NgayLe
    SELECT NGAY, THANG, NAM, TENLE
    FROM NgayLe;

    UPDATE BANGCONG
    SET MOTA = COALESCE(
                   (SELECT TOP 1 NL.TENLE
                    FROM @NgayLe NL
                    WHERE BANGCONG.NGAY = NL.NGAY 
                      AND BANGCONG.THANG = NL.THANG 
                      AND BANGCONG.NAM = NL.NAM),
                   CASE WHEN BANGCONG.THU = N'Chủ nhật' THEN N'Chủ nhật' ELSE N'Bình thường' END)
    FROM BANGCONG
    INNER JOIN inserted i ON BANGCONG.ID_BANGCONG = i.ID_BANGCONG;
END;



CREATE TABLE NgayLe (
    ID INT PRIMARY KEY IDENTITY(1,1),
    NGAY INT NOT NULL,
    THANG INT NOT NULL,
	NAM INT NOT NULL,
    TENLE NVARCHAR(100) NOT NULL
);
GO
CREATE TRIGGER trg_CheckNgayLe
ON NgayLe
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra xem ngày lễ đã tồn tại hay chưa
    IF NOT EXISTS (
        SELECT 1
        FROM NgayLe NL
        INNER JOIN inserted I ON NL.NGAY = I.NGAY AND NL.THANG = I.THANG AND NL.NAM = I.NAM
    )
    BEGIN
        -- Nếu không tồn tại, cho phép thêm
        INSERT INTO NgayLe (NGAY, THANG, NAM, TENLE)
        SELECT NGAY, THANG, NAM, TENLE
        FROM inserted;
    END
    ELSE
    BEGIN
        -- Nếu đã tồn tại, không thêm và có thể thông báo
        RAISERROR('Ngày lễ đã tồn tại trong bảng NgayLe.', 16, 1);
    END
END;
GO

-- Bảng kỉ luật khen thưởng
CREATE TABLE KhenThuongKyLuat (
    MaKTKL INT PRIMARY KEY,
    TenKTKL NVARCHAR(100),
    NoiDung NVARCHAR(255),
    Ngay DATE,
    MaNV VARCHAR(50),
    Loai NVARCHAR(50),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);


-- Tạo bảng lương
CREATE TABLE Luong (
    MaLuong INT,
    MaNV VARCHAR(50),
    MaChucVu VARCHAR(50),
    MaPhong VARCHAR(50),
	MaBoPhan VARCHAR(50),
    LuongCoBan DECIMAL(18, 2), 
    HeSoPhuCap DECIMAL(4, 2),       -- Hệ số phụ cấp theo chức vụ
    PhuCapCoDinh DECIMAL(18, 2),      -- Phụ cấp khác (300.000 VND)
    LuongThucNhan DECIMAL(18, 2),
    PRIMARY KEY (MaNV,MaLuong),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    FOREIGN KEY (MaChucVu) REFERENCES ChucVu(MaChucVu),
	FOREIGN KEY (MaPhong) REFERENCES PhongBan(MaPhong)
);

-- Tạo bảng dự án
CREATE TABLE DuAn (
    MaDuAn VARCHAR(50) PRIMARY KEY,
    TenDuAn NVARCHAR(100),
    NgayBatDau DATE,
    NgayKetThuc DATE,
    MoTa NVARCHAR(255),
    MaPhong VARCHAR(50),
    FOREIGN KEY (MaPhong) REFERENCES PhongBan(MaPhong)
);
-- Tạo bảng đầu việc dự án
CREATE TABLE DAUVIECDUAN
(
	MaDauViec VARCHAR(20),
	TenDauViec NVARCHAR(255),
	MaDuAn VARCHAR(50),
	MaNV VARCHAR(50),
	MoTa NVARCHAR(255),
	CONSTRAINT PK_DAUVIECDUAN PRIMARY KEY(MaDauViec,MaDuAn),
	CONSTRAINT FK_DAUVIECDUAN_NHANVIEN FOREIGN  KEY (MaNV) REFERENCES NhanVien(MaNV),
	CONSTRAINT FK_DAUVIECDUAN_DUAN FOREIGN  KEY (MaDuAn) REFERENCES DuAn(MaDuAn)
)
-- Tạo bảng Phân công
CREATE TABLE PhanCong (
    MaPhanCong VARCHAR(50) PRIMARY KEY,
    NgayThamGia DATE,
    NgayKetThuc DATE,
    MaNV VARCHAR(50),
    MaDuAn VARCHAR(50),
    VaiTro NVARCHAR(100),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    FOREIGN KEY (MaDuAn) REFERENCES DuAn(MaDuAn)
);


-- Tạo bảng DaoTao
CREATE TABLE DaoTao (
    MaDaoTao VARCHAR(50) ,
    TenKhoaHoc NVARCHAR(100),
    ThoiGianBatDau DATE,
    ThoiGianKetThuc DATE,
    NoiDung NVARCHAR(255),
    MaNV VARCHAR(50),
	CONSTRAINT PK_DAOTAO PRIMARY KEY(MaDaoTao,MaNV),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

--Tạo bảng tiêu chí
CREATE TABLE TieuChi (
	STT INT IDENTITY,
	NguoiLap NVARCHAR(100),
	MaTieuChi VARCHAR(50),
	TenTieuChi NVARCHAR(100),
	LoaiTieuChi NVARCHAR(50),
	TyTrong NVARCHAR(50),
	CONSTRAINT PK_TieuChi PRIMARY KEY(MaTieuChi)
);


--Tạo bảng kế hoạch đánh giá
CREATE TABLE KeHoachDanhGia (
	STT INT IDENTITY,
	MaKeHoachDanhGia VARCHAR(50),
	TenKeHoach NVARCHAR(50),
	NguoiLap NVARCHAR(50),
	SoNguoiDanhGia INT,
	SoDoiTuong INT,
	SoTieuChi INT,
	ThangDiem DECIMAL(2,1),
	XepLoai NVARCHAR(50),
	ThoiGianBatDau DATE,
	ThoiGianKetThuc DATE,
	TrangThai NVARCHAR(50),
	CONSTRAINT PK_KeHoachDanhGia PRIMARY KEY(MaKeHoachDanhGia)
);
--Tạo bảng phiếu đánh giá
CREATE TABLE PhieuDanhGia(
	STT INT IDENTITY,
	MaPhieuDanhGia VARCHAR(50),
	MaKeHoachDanhGia VARCHAR(50), 
	TenKeHoachDanhGia NVARCHAR(50),
	SoDoiTuong INT,
	NguoiDanhGia NVARCHAR(50),
	NgayDanhGia DATE,
	TienDo NVARCHAR(50),
	MaNV VARCHAR(50),
	CONSTRAINT PK_PhieuDanhGia PRIMARY KEY(MaPhieuDanhGia),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
	FOREIGN KEY (MaKeHoachDanhGia) REFERENCES KeHoachDanhGia(MaKeHoachDanhGia)
);
--Tạo bảng kết quả đánh giá nhân viên
CREATE TABLE KetQuaDanhGia(
	STT INT IDENTITY,
	MaNV VARCHAR(50),
	MaKeHoachDanhGia VARCHAR(50),
	HoTen NVARCHAR(100) NOT NULL,
	TenPhong NVARCHAR(100),
	TenChucVu NVARCHAR(100),
	TenPhieuDanhGia NVARCHAR(50),
	ThangDiem DECIMAL,
	XepLoai NVARCHAR(50),
	MaPhong VARCHAR(50),
	MaChucVu VARCHAR(50),
    CONSTRAINT FK_KetQuaDanhGia_NhanVien FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
	CONSTRAINT FK_KetQuaDanhGia_ChucVu FOREIGN KEY (MaChucVu) REFERENCES ChucVu(MaChucVu),
	CONSTRAINT FK_KetQuaDanhGia_KeHoachDanhGia FOREIGN KEY (MaKeHoachDanhGia) REFERENCES KeHoachDanhGia(MaKeHoachDanhGia),
    CONSTRAINT FK_KetQuaDanhGia_PhongBan FOREIGN KEY (MaPhong) REFERENCES PhongBan(MaPhong)
);

CREATE TABLE ACCOUNTS (
    ACC_ID INT IDENTITY(1,1) PRIMARY KEY,
	TENDANGNHAP VARCHAR(50),
    MATKHAU NVARCHAR(50) NOT NULL,
    PHANQUYEN NVARCHAR(10) CHECK(PHANQUYEN IN('ADMIN', 'QLCHAMCONG','QLLUONG')),
    EMAIL NVARCHAR(50),
);
GO

-- ================================================================================
-- INSERT INTO PhongBan (sửa lại mã phòng ban cho tính duy nhất)
INSERT INTO PhongBan (MaPhong, TenPhong, MoTa)
VALUES 
('P001', N'Phòng Nhân sự', N'Quản lý nhân sự toàn công ty'),
('P002', N'Phòng Kế toán', N'Xử lý các nghiệp vụ kế toán và tài chính'),
('P003', N'Phòng Kỹ thuật', N'Hỗ trợ kỹ thuật và phát triển sản phẩm'),
('P004', N'Phòng Kinh doanh', N'Triển khai các hoạt động kinh doanh và bán hàng'),
('P005', N'Phòng IT', N'Quản lý hệ thống công nghệ thông tin'),
('P006', N'Phòng Marketing', N'Phụ trách chiến lược và quảng bá thương hiệu'),
('P007', N'Phòng Pháp chế', N'Xử lý các vấn đề pháp lý của công ty'),
('P008', N'Phòng Sản xuất', N'Triển khai các hoạt động sản xuất sản phẩm'),
('P009', N'Phòng Hậu cần', N'Quản lý vận hành và kho bãi'),
('P010', N'Phòng Nghiên cứu và Phát triển', N'Nghiên cứu cải tiến sản phẩm và dịch vụ');

-- Thêm dữ liệu vào bảng BoPhan
INSERT INTO BoPhan (MaBoPhan, TenBoPhan, MaPhong, MoTa)
VALUES 
('BP001', N'Bộ phận Tuyển dụng', 'P001', N'Phụ trách tuyển dụng nhân sự mới'),
('BP002', N'Bộ phận Đào tạo', 'P001', N'Đào tạo và phát triển nhân sự'),
('BP003', N'Bộ phận Kế toán thuế', 'P002', N'Xử lý các vấn đề liên quan đến thuế'),
('BP004', N'Bộ phận Kế toán tài chính', 'P002', N'Quản lý tài chính công ty'),
('BP005', N'Bộ phận Hỗ trợ kỹ thuật', 'P003', N'Hỗ trợ kỹ thuật cho khách hàng'),
('BP006', N'Bộ phận Phát triển sản phẩm', 'P003', N'Nghiên cứu và phát triển sản phẩm mới'),
('BP007', N'Bộ phận Kinh doanh B2B', 'P004', N'Triển khai các hoạt động kinh doanh B2B'),
('BP008', N'Bộ phận Kinh doanh B2C', 'P004', N'Triển khai các hoạt động kinh doanh B2C'),
('BP009', N'Bộ phận Phần mềm', 'P005', N'Phát triển và duy trì phần mềm công ty'),
('BP010', N'Bộ phận Quản trị hệ thống', 'P005', N'Quản lý hệ thống công nghệ thông tin công ty');
-- INSERT INTO ChucVu (sửa mã chức vụ duy nhất)
INSERT INTO ChucVu (MaChucVu, TenChucVu)
VALUES
('CV01', N'Giám đốc'), -- Hệ số lương trong hợp đồng sẽ là 2.0
('CV02', N'Trưởng phòng'), -- Hệ số lương trong hợp đồng sẽ là 1.4
('CV03', N'Nhân viên'), -- Hệ số lương trong hợp đồng sẽ là 1.2
('CV04', N'Thư ký') --- Hệ số lương trong hợp đồng sẽ là 1.6

-- INSERT INTO TrinhDoNangLuc (sửa lại mã trình độ duy nhất)
INSERT INTO TrinhDoNangLuc (MaTrinhDo, TenTrinhDo)
VALUES
('TD01', N'Cử nhân'),
('TD02', N'Thạc sĩ'),
('TD03', N'Kỹ sư'),
('TD04', N'Tiến sĩ')

INSERT INTO ACCOUNTS(TENDANGNHAP,MATKHAU,PHANQUYEN,EMAIL)
VALUES
('Thachbao',N'1234567','ADMIN','thachbao2910@gmail.com'),
('Hoanghai',N'2345678','QLCHAMCONG','hoanghai@gmail.com'),
('Trongduc',N'3456789','QLLUONG','trongduc@gmail.com')

SET DATEFORMAT DMY
INSERT INTO NhanVien (MaNV, HoTen, GioiTinh, NgaySinh, DiaChi, CCCD, Hinhanh,MaChucVu, MaBoPhan, MaPhong, TrangThai, MaTrinhDo)
VALUES
--NV001: Giám Đốc
('NV001', N'Nguyễn Văn A', N'Nam', '01/01/1990', N'Hà Nội', N'205456240539', 'C:\Running DotNet\DA_CNNET\HMresourcemanagementsystem\HMresourcemanagementsystem\Image\hinh1.jpg','CV01', 'BP001', 'P001', N'Đang làm việc', 'TD01'),
--NV002: Trưởng Phòng
('NV002', N'Trần Thị B', N'Nữ', '15/02/1992', N'Hà Nội', N'177186313065', 'C:\Running DotNet\DA_CNNET\HMresourcemanagementsystem\HMresourcemanagementsystem\Image\hinh2.png','CV02', 'BP001', 'P001', N'Đang làm việc', 'TD02'),
--NV003: Nhân Viên
('NV003', N'Nguyễn Văn C', N'Nam', '10/03/1995', N'TP.HCM', N'072146665526','C:\Running DotNet\DA_CNNET\HMresourcemanagementsystem\HMresourcemanagementsystem\Image\hinh2.png', 'CV03', 'BP001', 'P001', N'Đang làm việc', 'TD03'),
--NV004: Thư Ký
('NV004', N'Phạm Thị D', N'Nữ', '20/04/1994', N'TP.HCM', N'887073099882','C:\Running DotNet\DA_CNNET\HMresourcemanagementsystem\HMresourcemanagementsystem\Image\hinh2.png', 'CV04', 'BP001', 'P001', N'Đang làm việc', 'TD01'),
--NV005: Giám Đốc
('NV005', N'Hoàng Văn E', N'Nam', '25/05/1998', N'Hải Phòng', N'368003773012','C:\Running DotNet\DA_CNNET\HMresourcemanagementsystem\HMresourcemanagementsystem\Image\hinh2.png', 'CV01', 'BP004', 'P002', N'Đang làm việc', 'TD02'),
--NV006: Trưởng Phòng
('NV006', N'Phạm Văn F', N'Nam', '30/06/1989', N'Đà Nẵng', N'925615126393','C:\Running DotNet\DA_CNNET\HMresourcemanagementsystem\HMresourcemanagementsystem\Image\hinh2.png', 'CV02', 'BP004', 'P002', N'Nghỉ việc', 'TD03'),
--NV007: Nhân viên
('NV007', N'Lê Thị G', N'Nữ', '12/07/1993', N'Quảng Ninh', N'934076430789','C:\Running DotNet\DA_CNNET\HMresourcemanagementsystem\HMresourcemanagementsystem\Image\hinh2.png', 'CV03', 'BP004', 'P002', N'Đang làm việc', 'TD01'),
--NV008: Thư Ký
('NV008', N'Vũ Văn H', N'Nam', '18/08/1991', N'Vũng Tàu', N'981000009525','C:\Running DotNet\DA_CNNET\HMresourcemanagementsystem\HMresourcemanagementsystem\Image\hinh2.png', 'CV04', 'BP004', 'P002', N'Nghỉ việc', 'TD02'),
--NV009: Giám Đốc
('NV009', N'Ngô Thị I', N'Nữ', '21/09/1996', N'Huế', N'831113591270','C:\Running DotNet\DA_CNNET\HMresourcemanagementsystem\HMresourcemanagementsystem\Image\hinh1.jpg', 'CV01', 'BP003', 'P003', N'Đang làm việc', 'TD03'),
--NV010: Trưởng Phòng
('NV010', N'Phan Văn K', N'Nam', '11/10/1997', N'Cần Thơ', N'407323696288','C:\Running DotNet\DA_CNNET\HMresourcemanagementsystem\HMresourcemanagementsystem\Image\hinh1.jpg', 'CV02', 'BP003', 'P003', N'Đang làm việc', 'TD01');

--- Insert HopDong
SET DATEFORMAT DMY
INSERT INTO HopDong (SoHopDong, NgayBatDau, NgayKetThuc, NoiDung, ThoiHan, HeSoLuong, MaNV)
VALUES
(1, '01/01/2021', '01/01/2023', N'Hợp đồng lao động 3 năm', 36, 2.0, 'NV001'),
(2, '01/01/2021', '01/01/2022', N'Hợp đồng lao động 1 năm', 12, 1.4, 'NV002'),
(3, '15/06/2020', '15/06/2023', N'Hợp đồng lao động 3 năm', 36, 1.2, 'NV003'),
(4, '01/03/2019', '01/03/2022', N'Hợp đồng lao động 3 năm', 36, 1.6, 'NV004'),
(5, '01/04/2022', '01/04/2025', N'Hợp đồng lao động 3 năm', 36, 2.0, 'NV005'),
(6, '10/09/2021', '10/09/2024', N'Hợp đồng lao động 3 năm', 36, 1.4, 'NV006'),
(7, '20/12/2021', '20/12/2024', N'Hợp đồng lao động 3 năm', 36, 1.2, 'NV007'),
(8, '01/07/2021', '01/07/2022', N'Hợp đồng lao động 1 năm', 12, 1.6, 'NV008'),
(9, '15/08/2020', '15/08/2023', N'Hợp đồng lao động 3 năm', 36, 2.0, 'NV009'),
(10, '05/05/2019', '05/05/2022', N'Hợp đồng lao động 3 năm', 36, 1.4, 'NV010')



SET DATEFORMAT DMY
INSERT INTO BaoHiem (MaBaoHiem, SoBaoHiem, NgayCap, NoiCap, NoiKhamBenh, MaNV)
VALUES
(1, N'1234567890', '01/01/2021', N'TP.HCM', N'Bệnh viện Chợ Rẫy', 'NV001'),
(2, N'1234567891', '01/01/2021', N'TP.HCM', N'Bệnh viện Bình Dân', 'NV002'),
(3, N'1234567892', '15/06/2020', N'TP.HCM', N'Bệnh viện Nhân dân 115', 'NV003'),
(4, N'1234567893', '01/03/2019', N'TP.HCM', N'Bệnh viện Nhi đồng 1', 'NV004'),
(5, N'1234567894', '01/04/2022', N'TP.HCM', N'Bệnh viện Đại học Y Dược', 'NV005'),
(6, N'1234567895', '10/09/2021', N'TP.HCM', N'Bệnh viện Gia Định', 'NV006'),
(7, N'1234567896', '20/12/2021', N'TP.HCM', N'Bệnh viện Phạm Ngọc Thạch', 'NV007'),
(8, N'1234567897', '01/07/2021', N'TP.HCM', N'Bệnh viện Thống Nhất', 'NV008'),
(9, N'1234567898', '15/08/2020', N'TP.HCM', N'Bệnh viện Ung Bướu', 'NV009'),
(10, N'1234567899', '05/05/2019', N'TP.HCM', N'Bệnh viện Trưng Vương', 'NV010')


-- Chèn dữ liệu chấm công cho NV01, loại trừ thứ bảy và chủ nhật
SET DATEFORMAT DMY;
INSERT INTO CHAMCONG (ID_CHAMCONG, NGAYVAO, TRANGTHAIVAO, TRANGTHAIRA, MaNV)
VALUES
('CC001', '01/11/2023 08:00:00', 1, 1, 'NV001'),  -- Thứ tư
('CC002', '02/11/2023 08:00:00', 1, 1, 'NV001'),  -- Thứ năm
('CC003', '03/11/2023 08:00:00', 1, 1, 'NV001'),  -- Thứ sáu
-- Bỏ qua ngày 4 (thứ bảy) và ngày 5 (chủ nhật)
('CC004', '06/11/2023 08:00:00', 1, 1, 'NV001'),  -- Thứ hai
('CC005', '07/11/2023 08:00:00', 1, 1, 'NV001'),  -- Thứ ba
('CC006', '08/11/2023 08:00:00', 1, 1, 'NV001'),  -- Thứ tư
('CC007', '09/11/2023 08:00:00', 1, 1, 'NV001'),  -- Thứ năm
('CC008', '10/11/2023 08:00:00', 1, 1, 'NV001'),  -- Thứ sáu
-- Bỏ qua ngày 11 (thứ bảy) và ngày 12 (chủ nhật)
('CC009', '13/11/2023 08:00:00', 1, 1, 'NV001'),  -- Thứ hai
('CC010', '14/11/2023 08:00:00', 1, 1, 'NV001'),  -- Thứ ba
('CC011', '15/11/2023 08:00:00', 1, 1, 'NV001'),  -- Thứ tư
('CC012', '16/11/2023 08:00:00', 1, 1, 'NV001'),  -- Thứ năm
('CC013', '17/11/2023 08:00:00', 1, 1, 'NV001'),  -- Thứ sáu
-- Bỏ qua ngày 18 (thứ bảy) và ngày 19 (chủ nhật)
('CC014', '20/11/2023 08:00:00', 1, 1, 'NV001'),  -- Thứ hai
('CC015', '21/11/2023 08:00:00', 1, 1, 'NV001'),  -- Thứ ba
('CC016', '22/11/2023 08:00:00', 1, 1, 'NV001'),  -- Thứ tư
('CC017', '23/11/2023 08:00:00', 1, 1, 'NV001'),  -- Thứ năm
('CC018', '24/11/2023 08:00:00', 1, 1, 'NV001'),  -- Thứ sáu
-- Bỏ qua ngày 25 (thứ bảy) và ngày 26 (chủ nhật)
('CC019', '27/11/2023 08:00:00', 1, 1, 'NV001'),  -- Thứ hai
('CC020', '28/11/2023 08:00:00', 1, 1, 'NV001'),  -- Thứ ba
('CC021', '29/11/2023 08:00:00', 1, 1, 'NV001'),  -- Thứ tư
('CC022', '30/11/2023 08:00:00', 1, 1, 'NV001'),  -- Thứ năm

('CC023', '01/11/2023 08:10:00', 1, 1, 'NV002'),
('CC024', '02/11/2023 08:20:00', 1, 1, 'NV002'),
('CC025', '03/11/2023 08:00:00', 1, 1, 'NV002'),
('CC026', '01/11/2023 08:05:00', 1, 1, 'NV003'),
('CC027', '02/11/2023 08:10:00', 1, 1, 'NV003'),
('CC028', '03/11/2023 08:15:00', 1, 1, 'NV003');
GO

SET DATEFORMAT DMY
INSERT INTO KhenThuongKyLuat (MaKTKL, TenKTKL, NoiDung, Ngay, MaNV, Loai)
VALUES
(1, N'Khen thưởng tháng 1', N'Hoàn thành xuất sắc công việc', '31/01/2023', 'NV001', N'Khen thưởng'),
(2, N'Khen thưởng tháng 2', N'Đóng góp tích cực vào dự án', '28/02/2023', 'NV002', N'Khen thưởng'),
(3, N'Kỉ luật tháng 3', N'Đi làm muộn 3 ngày liên tiếp', '15/03/2023', 'NV003', N'Kỉ luật'),
(4, N'Khen thưởng tháng 4', N'Đề xuất giải pháp cải tiến quy trình', '30/04/2023', 'NV004', N'Khen thưởng'),
(5, N'Khen thưởng tháng 5', N'Hỗ trợ dự án vượt qua khó khăn', '31/05/2023', 'NV005', N'Khen thưởng'),
(6, N'Kỉ luật tháng 6', N'Vi phạm quy định công ty', '30/06/2023', 'NV006', N'Kỉ luật'),
(7, N'Khen thưởng tháng 7', N'Tích cực tham gia hoạt động công ty', '31/12/2024', 'NV007', N'Khen thưởng'),
(8, N'Kỉ luật tháng 8', N'Không hoàn thành nhiệm vụ đúng hạn', '12/12/2024', 'NV008', N'Kỉ luật'),
(9, N'Khen thưởng tháng 9', N'Hỗ trợ đồng nghiệp trong dự án', '19/12/2024', 'NV009', N'Khen thưởng'),
(10, N'Khen thưởng tháng 10', N'Đóng góp lớn vào doanh số quý 3', '31/10/2023', 'NV010', N'Khen thưởng'),
(11, N'Khen thưởng tháng 11', N'Đóng góp vào công tác từ thiện', '11/12/2024', 'NV010', N'Khen thưởng')


INSERT INTO Luong (MaLuong, MaNV, MaChucVu, MaPhong, MaBoPhan, LuongCoBan, HeSoPhuCap, PhuCapCoDinh, LuongThucNhan)
VALUES
    (1, 'NV001', 'CV01', 'P001', 'BP001', 16000000, 1.8, 300000, 0),
    (2, 'NV002', 'CV02', 'P001', 'BP001', 10000000, 1.5, 300000, 0),
    (3, 'NV003', 'CV03', 'P001', 'BP001', 5000000, 1.2, 300000, 0),
    (4, 'NV004', 'CV04', 'P001', 'BP001', 6500000, 1.3, 300000, 0),
    (5, 'NV005', 'CV01', 'P002', 'BP004', 16000000, 1.8, 300000, 0),
    (6, 'NV006', 'CV02', 'P002', 'BP004', 10000000, 1.5, 300000, 0),
    (7, 'NV007', 'CV03', 'P002', 'BP004', 5000000, 1.2, 300000, 0),
    (8, 'NV008', 'CV04', 'P002', 'BP004', 6500000, 1.3, 300000, 0),
    (9, 'NV009', 'CV01', 'P003', 'BP003', 16000000, 1.8, 300000, 0),
    (10, 'NV010', 'CV02', 'P003', 'BP003', 10000000, 1.5, 300000, 0);


--Dự Án
SET DATEFORMAT DMY
INSERT INTO DuAn (MaDuAn, TenDuAn, NgayBatDau, NgayKetThuc, MoTa, MaPhong)
VALUES
('DA01', N'Dự án A', '01/01/2023', '30/06/2023', N'Dự án phát triển phần mềm quản lý', 'P001'),
('DA02', N'Dự án B', '01/02/2023', '31/07/2023', N'Dự án thiết kế hệ thống mạng', 'P002'),
('DA03', N'Dự án C', '01/03/2023', '31/08/2023', N'Dự án xây dựng cơ sở dữ liệu', 'P003'),
('DA04', N'Dự án D', '01/04/2023', '30/09/2023', N'Dự án cải tiến quy trình làm việc', 'P004'),
('DA05', N'Dự án E', '01/05/2023', '31/10/2023', N'Dự án phát triển ứng dụng di động', 'P001'),
('DA06', N'Dự án F', '01/06/2023', '30/11/2023', N'Dự án nâng cấp hệ thống bảo mật', 'P002'),
('DA07', N'Dự án G', '01/07/2023', '31/12/2023', N'Dự án tối ưu hóa quy trình sản xuất', 'P003'),
('DA08', N'Dự án H', '01/08/2023', '31/01/2024', N'Dự án xây dựng chiến lược marketing', 'P004'),
('DA09', N'Dự án I', '01/09/2023', '28/02/2024', N'Dự án phát triển website', 'P001'),
('DA10', N'Dự án J', '01/10/2023', '31/03/2024', N'Dự án đào tạo nhân viên', 'P002')

INSERT INTO PhanCong (MaPhanCong, NgayThamGia, NgayKetThuc, MaNV, MaDuAn, VaiTro)
VALUES
-- Dự án A (DA01)
('PC01', '10/01/2023', '20/06/2023', 'NV001', 'DA01', N'Trưởng nhóm'),
('PC02', '10/01/2023', '20/06/2023', 'NV002', 'DA01', N'Nhân viên'),
('PC03', '10/01/2023', '20/06/2023', 'NV003', 'DA01', N'Nhân viên'),
('PC04', '10/01/2023', '20/06/2023', 'NV004', 'DA01', N'Nhân viên'),
('PC05', '10/01/2023', '20/06/2023', 'NV005', 'DA01', N'Nhân viên'),

-- Dự án B (DA02)
('PC06', '10/01/2023', '20/06/2023', 'NV006', 'DA02', N'Trưởng nhóm'),
('PC07', '10/01/2023', '20/06/2023', 'NV007', 'DA02', N'Nhân viên'),
('PC08', '10/01/2023', '20/06/2023', 'NV008', 'DA02', N'Nhân viên'),
('PC09', '10/01/2023', '20/06/2023', 'NV009', 'DA02', N'Nhân viên'),
('PC10', '10/01/2023', '20/06/2023', 'NV010', 'DA02', N'Nhân viên');


-- Thêm đầu mục cho Dự án A
INSERT INTO DAUVIECDUAN (MaDauViec, TenDauViec, MaDuAn, MaNV) VALUES
('DV001', N'Phân tích yêu cầu', 'DA01', 'NV001'),
('DV002', N'Thiết kế hệ thống', 'DA01', 'NV002'),
('DV003', N'Phát triển ứng dụng', 'DA01', 'NV003'),
('DV004', N'Kiểm thử', 'DA01', 'NV004'),
('DV005', N'Bàn giao dự án', 'DA01', 'NV005');

-- Thêm đầu mục cho Dự án B
INSERT INTO DAUVIECDUAN (MaDauViec, TenDauViec, MaDuAn, MaNV) VALUES
('DV006', N'Phân tích yêu cầu', 'DA02', 'NV006'),
('DV007', N'Thiết kế hệ thống', 'DA02', 'NV007'),
('DV008', N'Phát triển ứng dụng', 'DA02', 'NV008'),
('DV009', N'Kiểm thử', 'DA02', 'NV009'),
('DV010', N'Bàn giao dự án', 'DA02', 'NV010');



INSERT INTO DaoTao (MaDaoTao, TenKhoaHoc, ThoiGianBatDau, ThoiGianKetThuc, NoiDung, MaNV)
VALUES
-- Khóa đào tạo 1: Kỹ năng lãnh đạo
('DT001', N'Kỹ năng lãnh đạo', '2023-01-01', '2023-01-05', N'Nâng cao kỹ năng quản lý và lãnh đạo', 'NV001'),
('DT001', N'Kỹ năng lãnh đạo', '2023-01-01', '2023-01-05', N'Nâng cao kỹ năng quản lý và lãnh đạo', 'NV002'),
('DT001', N'Kỹ năng lãnh đạo', '2023-01-01', '2023-01-05', N'Nâng cao kỹ năng quản lý và lãnh đạo', 'NV003'),
('DT001', N'Kỹ năng lãnh đạo', '2023-01-01', '2023-01-05', N'Nâng cao kỹ năng quản lý và lãnh đạo', 'NV004'),
('DT001', N'Kỹ năng lãnh đạo', '2023-01-01', '2023-01-05', N'Nâng cao kỹ năng quản lý và lãnh đạo', 'NV005'),

-- Khóa đào tạo 2: Giao tiếp hiệu quả
('DT002', N'Giao tiếp hiệu quả', '2023-02-10', '2023-02-15', N'Phát triển kỹ năng giao tiếp và thuyết phục', 'NV006'),
('DT002', N'Giao tiếp hiệu quả', '2023-02-10', '2023-02-15', N'Phát triển kỹ năng giao tiếp và thuyết phục', 'NV007'),
('DT002', N'Giao tiếp hiệu quả', '2023-02-10', '2023-02-15', N'Phát triển kỹ năng giao tiếp và thuyết phục', 'NV008'),
('DT002', N'Giao tiếp hiệu quả', '2023-02-10', '2023-02-15', N'Phát triển kỹ năng giao tiếp và thuyết phục', 'NV009'),
('DT002', N'Giao tiếp hiệu quả', '2023-02-10', '2023-02-15', N'Phát triển kỹ năng giao tiếp và thuyết phục', 'NV010')


INSERT INTO TieuChi (NguoiLap, MaTieuChi, TenTieuChi, LoaiTieuChi, TyTrong) VALUES
(N'Nguyễn Thế Duy','TC001',N'Đánh giá nhân viên toàn diện',N'KPI đơn','3'),
(N'Trương Văn Thạch Bảo','TC002',N'Báo cáo',N'KPI đơn','2'),
(N'Lê Hoàng Hải','TC003',N'Đào tạo nhân viên mới',N'KPI tổng hợp','1'),
(N'Dương Trọng Đức','TC004',N'Kiểm soát chi phí',N'KPI đơn','5'),
(N'Nguyễn Thế Duy','TC005',N'Đánh giá mục tiêu phát triển',N'KPI đơn','4'),
(N'Nguyễn Thế Duy','TC006',N'Khả năng lãnh đạo đội nhóm',N'KPI đơn','2'),
(N'Nguyễn Thế Duy','TC007',N'Đánh giá, kiểm soát và xử lý rủi ro',N'KPI đơn','2'),
(N'Nguyễn Thế Duy','TC008',N'Giúp đỡ nhân viên khác',N'KPI đơn','5'),
(N'Nguyễn Thế Duy','TC009',N'Tuân thủ nội quy công ty',N'KPI đơn','1'),
(N'Nguyễn Thế Duy','TC010',N'Đánh giá nhân viên từ cao đến thấp',N'KPI đơn','3')

SET DATEFORMAT DMY
INSERT INTO KeHoachDanhGia(MaKeHoachDanhGia, TenKeHoach, NguoiLap, SoNguoiDanhGia, SoDoiTuong, SoTieuChi,ThangDiem,XepLoai, ThoiGianBatDau, ThoiGianKetThuc, TrangThai) VALUES
('KH001',N'Đánh giá cuối năm',N'Lê Hoàng Hải',5,2,4,7.5,N'Khá','17/07/2019','18/08/2019',N'Đã hoàn thành'),
('KH002',N'Đánh giá nhân viên tháng 12',N'Nguyễn Thế Duy',3,4,2,8.5,N'Giỏi','01/12/2019','31/12/2019',N'Đã hoàn thành'),
('KH003',N'Đánh giá Quý đầu năm',N'Dương Trọng Đức',7,6,1,6.5,N'Khá','01/01/2020','01/04/2020',N'Chưa hoàn thành'),
('KH004',N'Đánh giá khen thưởng',N'Trương Văn Thạch Bảo',3,1,2,5.5,N'Trung Bình','05/09/2018','11/04/2019',N'Đã hoàn thành'),
('KH005',N'Đánh giá doanh thu tháng 7',N'Trương Văn Thạch Bảo',3,3,2,2.6,N'Trung Bình','15/07/2021','22/04/2021',N'Đã hoàn thành'),
('KH006',N'Đánh giá nhân viên',N'Dương Trọng Đức',4,2,1,9.2,N'Giỏi','05/10/2022','05/10/2023',N'Đã hoàn thành'),
('KH007',N'Đánh giá thưởng cuối năm',N'Nguyễn Thế Duy',4,2,3,8.3,N'Giỏi','15/12/2023','25/12/2023',N'Chưa hoàn thành'),
('KH008',N'Đánh giá cuối năm',N'Nguyễn Thế Duy',5,1,1,4.5,N'Trung Bình','17/07/2019','18/08/2019',N'Chưa hoàn thành'),
('KH009',N'Đánh giá cuối năm',N'Lê Hoàng Hải',3,1,4,3,N'Kém','09/02/2017','15/07/2017',N'Chưa hoàn thành'),
('KH010',N'Đánh giá quản lý nhân sự',N'Dương Trọng Đức',2,3,1,5,N'Trung Bình','15/07/2023','20/09/2024',N'Đã hoàn thành')
SET DATEFORMAT DMY
INSERT INTO PhieuDanhGia(MaPhieuDanhGia,MaKeHoachDanhGia,TenKeHoachDanhGia, SoDoiTuong, NguoiDanhGia,NgayDanhGia, TienDo, MaNV) VALUES
('PDG001','KH001',N'Đánh giá cuối năm',5,N'Trương Văn Thạch Bảo','17/12/2019',N'Đã hoàn thành','NV001'),
('PDG002','KH002',N'Đánh giá quý tháng 4',5,N'Lê Hoàng Hải','12/04/2019',N'Chưa hoàn thành','NV002'),
('PDG003','KH003',N'Đánh giá nhân viên tháng 8',5,N'Nguyễn Thế Duy','20/08/2019',N'Đã hoàn thành','NV003'),
('PDG004','KH004',N'Đánh giá cửa hàng tháng 7',5,N'Dương Trọng Đức','01/07/2019',N'Đã hoàn thành','NV004'),
('PDG005','KH005',N'Đánh giá phòng kinh doanh tháng 5',5,N'Lê Hoàng Hải','15/05/2019',N'Chưa hoàn thành','NV005'),
('PDG006','KH006',N'Đánh giá nhân viên tháng 1',5,N'Trương Văn Thạch Bảo','11/01/2019',N'Đã hoàn thành','NV006'),
('PDG007','KH007',N'Đánh giá khen thưởng tháng 6',5,N'Nguyễn Thế Duy','02/06/2019',N'Đã hoàn thành','NV007'),
('PDG008','KH008',N'Đánh giá khen thưởng cuối năm',5,N'Dương Trọng Đức','20/12/2019',N'Chưa hoàn thành','NV008'),
('PDG009','KH009',N'Đánh giá nhân viên tháng 3',5,N'Lê Hoàng Hải','28/03/2019',N'Đã hoàn thành','NV009'),
('PDG010','KH010',N'Đánh giá nhân viên tháng 9',5,N'Dương Trọng Đức','25/09/2019',N'Chưa hoàn thành','NV010')


INSERT INTO KetQuaDanhGia(MaNV, MaKeHoachDanhGia, HoTen, TenPhong, TenChucVu, TenPhieuDanhGia, ThangDiem, XepLoai, MaPhong, MaChucVu) VALUES
('NV001', 'KH001', N'Nguyễn Thị A', N'Phòng Kỹ Thuật', NULL, N'Đánh giá cuối năm', DEFAULT, DEFAULT, 'P001', 'CV01'),
('NV002', 'KH002', N'Lê Văn Bưởi', N'Phòng Kế toán', NULL, N'Đánh giá quý tháng 4', DEFAULT, DEFAULT, 'P001', 'CV04'),
('NV003', 'KH003', N'Nguyễn Hoàng C', N'Phòng Kỹ Thuật', NULL, N'Đánh giá nhân viên tháng 8', DEFAULT, DEFAULT, 'P001', 'CV02'),
('NV004', 'KH004', N'Lô Văn Lầu', N'Phòng Nhân Sự', NULL, N'Đánh giá cửa hàng tháng 7', DEFAULT, DEFAULT, 'P001', 'CV02'),
('NV005', 'KH005', N'Đỗ Xuân D', N'Phòng Marketing', NULL, N'Đánh giá phòng kinh doanh tháng 5', DEFAULT, DEFAULT, 'P002', 'CV02'),
('NV006', 'KH006', N'Mai Phương Thúy', N'Phòng Kỹ Thuật', NULL, N'Đánh giá nhân viên tháng 1', DEFAULT, DEFAULT, 'P002', 'CV03'),
('NV007', 'KH007', N'Hồ Xuân Hương', N'Phòng Nhân Sự', NULL, N'Đánh giá khen thưởng tháng 6', DEFAULT, DEFAULT, 'P002', 'CV03'),
('NV008', 'KH008', N'Tần Thủy X', N'Phòng Marketing', NULL, N'Đánh giá khen thưởng cuối năm', DEFAULT, DEFAULT, 'P002', 'CV03'),
('NV009', 'KH009', N'Khinh Thị Hồng Gấm', N'Phòng Kỹ Thuật', NULL, N'Đánh giá nhân viên tháng 3', DEFAULT, DEFAULT, 'P003', 'CV04'),
('NV010', 'KH010', N'Văn Lê N', N'Phòng Marketing', NULL, N'Đánh giá nhân viên tháng 9', DEFAULT, DEFAULT, 'P003', 'CV03');

SELECT
    KQDG.STT,
    NV.MaNV,
    NV.HoTen,
    PB.TenPhong AS TenPhongNhanVien,
    CV.TenChucVu AS TenChucVuNhanVien,
    KQDG.MaKeHoachDanhGia,
    KQDG.TenKeHoach,
    KQDG.NguoiLap AS NguoiLapKeHoach,
    FORMAT(KQDG.ThangDiem, '0.0') AS ThangDiemKeHoach,
    KQDG.XepLoai AS XepLoaiKeHoach
FROM
    KetQuaDanhGia KQ
    INNER JOIN NhanVien NV ON KQ.MaNV = NV.MaNV
    INNER JOIN KeHoachDanhGia KQDG ON KQ.MaKeHoachDanhGia = KQDG.MaKeHoachDanhGia
    INNER JOIN PhongBan PB ON NV.MaPhong = PB.MaPhong
	INNER JOIN ChucVu CV ON NV.MaChucVu = CV.MaChucVu;

SELECT * FROM NhanVien
SELECT * FROM Luong
SELECT * FROM HopDong
SELECT * FROM BaoHiem
SELECT * FROM BoPhan
SELECT * FROM CHAMCONG
SELECT * FROM ChucVu
SELECT * FROM DuAn
SELECT * FROM KhenThuongKyLuat
SELECT * FROM PhanCong
SELECT * FROM PhongBan
SELECT * FROM TrinhDoNangLuc
SELECT * FROM BANGCONG
SELECT * FROM NgayLe

drop table BaoHiem
drop table BoPhan
drop table CHAMCONG
drop table BANGCONG
drop table ChucVu
drop table DuAn
drop table HopDong
drop table NhanVien
drop table KhenThuongKyLuat
drop table Luong
drop table PhanCong
drop table PhongBan
drop table TrinhDoNangLuc
drop table NgayLe



--import 1 nhân viên trong 30 ngày

DECLARE @CurrentDate DATETIME = '01/12/2024';  -- Ngày bắt đầu tháng
DECLARE @EndDate DATETIME = '31/12/2024';      -- Ngày kết thúc tháng
DECLARE @EmployeeID NVARCHAR(10) = 'NV010';    -- Mã nhân viên

-- Vòng lặp để thêm bản ghi cho mỗi ngày trong tháng
WHILE @CurrentDate <= @EndDate
BEGIN
    -- Thêm bản ghi vào bảng CHAMCONG cho mỗi ngày với NGAYVAO thay đổi theo ngày
    IF DATEPART(WEEKDAY, @CurrentDate) <> 1
    BEGIN
        INSERT INTO CHAMCONG (ID_CHAMCONG, NGAYVAO, MANV, TRANGTHAIVAO, TRANGTHAIRA)
        VALUES (LEFT(@EmployeeID + FORMAT(@CurrentDate, 'yyyyMMdd'), 20), @CurrentDate, @EmployeeID, 1, 1);
    END

    -- Tiến tới ngày tiếp theo
    SET @CurrentDate = DATEADD(DAY, 1, @CurrentDate);
END

SELECT * FROM BangCong WHERE THANG = 12 AND NAM = 2024;
SELECT * FROM Luong;
SELECT * FROM NhanVien;
SELECT * FROM KhenThuongKyLuat;

UPDATE Luong
SET LuongThucNhan = 0

