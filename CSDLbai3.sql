use master
CREATE DATABASE QL_DTDD1;
GO

USE QL_DTDD1;
GO

-- Bước 2: Tạo bảng Loai (Category)
CREATE TABLE Loai (
    MaLoai INT PRIMARY KEY,
    TenLoai NVARCHAR(50) NOT NULL
);
GO

-- Bước 3: Tạo bảng SanPham (Product)
CREATE TABLE SanPham (
    MaSP INT PRIMARY KEY,
    TenSP NVARCHAR(100) NOT NULL,
    DuongDan NVARCHAR(255),
    Gia INT NOT NULL,
    MoTa NVARCHAR(MAX),
    MaLoai INT NOT NULL,
    CONSTRAINT FK_SanPham_Loai FOREIGN KEY (MaLoai) REFERENCES Loai(MaLoai)
);

-- Bước 4: Tạo bảng KhachHang (Customer)
CREATE TABLE KhachHang (
    MaKH INT PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    DienThoai VARCHAR(15),
    GioiTinh NVARCHAR(10),
    SoThich NVARCHAR(255),
    Email VARCHAR(100) UNIQUE NOT NULL,
    MatKhau VARCHAR(100) NOT NULL
);

-- Bước 5: Tạo bảng GioHang (Cart/Order details)
CREATE TABLE GioHang (
    MaGH INT PRIMARY KEY,
    MaKH INT NOT NULL,
    MaSP INT NOT NULL,
    SoLuong INT NOT NULL,
    Ngay DATETIME DEFAULT GETDATE(),
    
    CONSTRAINT FK_GioHang_KhachHang FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
    CONSTRAINT FK_GioHang_SanPham FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);

-- Bước 6: Chèn dữ liệu mẫu (Tham khảo ảnh cecb6d và cecb8c)

-- Dữ liệu Loai
INSERT INTO Loai (MaLoai, TenLoai) VALUES
(1, N'Nokia'), (2, N'Samsung'), (3, N'Motorola'), (4, N'LG'), 
(5, N'Oppo'), (6, N'Iphone'), (7, N'BPhone');

-- Dữ liệu SanPham
INSERT INTO SanPham (MaSP, TenSP, DuongDan, Gia, MoTa, MaLoai) VALUES
(1, N'N701', 'N70.jpg', 2000000, N'Nâng cấp BN', 1),
(2, N'N72', 'N72.jpg', 2100000, N'Nâng cấp BN, 2 màu Đen, Xám', 1),
(5, N'GalaxyA6', 'GalaxyA6.jpg', 5200000, N'Nâng cấp BN, Màu Đen, Xám, Đỏ, Bạc', 2),
(24, N'Iphone4S', 'Iphone4S.jpg', 3000000, N'Không nâng cấp', 6),
(25, N'Iphone5S', 'Iphone5S.jpg', 5000000, N'Không nâng cấp', 6),
(28, N'Iphone8p', 'Iphone8p.jpg', 20000000, N'Không nâng cấp', 6);
