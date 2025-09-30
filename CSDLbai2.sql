use master
CREATE DATABASE QLDuLieuPhongBan;
GO

USE QLDuLieuPhongBan;
GO

CREATE TABLE PhongBan (
    MaPhong INT PRIMARY KEY,
    TenPhong NVARCHAR(100) NOT NULL
);

CREATE TABLE NhanVien (
    MaNV INT PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(10),
    ThanhPho NVARCHAR(100),
    MaPhong INT NOT NULL,
    CONSTRAINT FK_NhanVien_PhongBan
        FOREIGN KEY (MaPhong)
        REFERENCES PhongBan (MaPhong)
);

---------------------------------------------------------------
INSERT INTO PhongBan (MaPhong, TenPhong) VALUES
(1, N'Khoa CNTT'),
(2, N'Khoa Ngoại Ngữ'),
(3, N'Khoa Tài Chính'),
(4, N'Khoa Thực Phẩm'),
(5, N'Phòng Đào Tạo');

INSERT INTO NhanVien (MaNV, HoTen, GioiTinh, ThanhPho, MaPhong) VALUES
(1, N'Nguyễn Văn A', N'Nam', N'Hà Nội', 1),
(2, N'Trần Thị B', N'Nữ', N'Hải Phòng', 1),
(3, N'Đinh Duy Minh', N'Nam', N'Thái Bình', 2),
(4, N'Ngô Thị Nguyệt', N'Nữ', N'Long An', 2),
(5, N'Lê Hoàng C', N'Nam', N'TP. HCM', 3),
(6, N'Phạm Thu D', N'Nữ', N'Đà Nẵng', 3),
(7, N'Bùi Văn E', N'Nam', N'Cần Thơ', 5);

select * from PhongBan
select * from NhanVien
