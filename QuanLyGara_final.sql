CREATE DATABASE QuanLyGara_final

create table QUYENHAN(
 MaQH int primary key,
 TenQH varchar(50),
)

CREATE TABLE TAIKHOAN(
   MaTK int primary key,
   MaQH int,
   HoTen varchar(50),
   TenDangNhap varchar(50),
   MatKhau varchar(50) ,
)

alter table TAIKHOAN add foreign key (MaQH) references QUYENHAN(MaQH)  



CREATE TABLE THAMSO(
 TenThamSo varchar(50) primary key,
 GiaTri int,
)

create table HIEUXE
(
	MaHX int PRIMARY KEY,
	TenHieuXe varchar(30)
)

CREATE TABLE TIENCONG(
 MaTC int primary key,
 TenTienCong varchar(50),
 ChiPhi int,
) 

CREATE TABLE XE(
 BienSo int primary key,
 MaHX int,
 MaKH int,
 TienNo int,
 NgayTiepNhan date,
)

CREATE TABLE KHACHHANG(
 MaKH int primary key,
 TenKH varchar(50),
 DienThoai int,
 DiaChi varchar(100),
)

alter table XE add foreign key (MaHX) references HIEUXE(MaHX)
alter table XE add foreign key (MaKH) references KHACHHANG(MaKH)




Create table PHIEUTHUTIEN(
 MaPhieuThuTien int primary key,
 BienSo int,
 TienThu int,
 NgayThuTien date,
)

alter table PHIEUTHUTIEN add foreign key (BienSo) references Xe(BienSo)

create table PHIEUSUACHUA(
 MaPhieuSuaChua int primary key,
 BienSo int,
 NgayLap date,
 TongTien int,
)

alter table PHIEUSUACHUA add foreign key (BienSo) references Xe(BienSo)

create table CT_PHIEUSUACHUA(
 MaCTPSC int,
 MaPhieuSuaChua int,
 NoiDung varchar(100),
 MaTC int,
 ThanhTien int,
 primary key(MaCTPSC)
)

alter table CT_PHIEUSUACHUA add foreign key (MaPhieuSuaChua) references PHIEUSUACHUA(MaPhieuSuaChua)
alter table CT_PHIEUSUACHUA add foreign key (MaTC) references TIENCONG(MaTC)

create table VATTUPHUTUNG(
 MaVTPT int primary key,
 TenVTPT varchar(50),
 DonGiaNhap int,
 DonGiaBan int,
 SoLuongTon int,
)

create table CT_SUDUNGVTPT(
 MaCTPSC int,
 MaVTPT int,
 SuDung int,
 DonGia int,
 ThanhTien int,
 primary key ( MaCTPSC, MaVTPT)
)

alter table CT_SUDUNGVTPT add foreign key (MaCTPSC) references CT_PHIEUSUACHUA(MaCTPSC)
alter table CT_SUDUNGVTPT add foreign key (MaVTPT) references VATTUPHUTUNG(MaVTPT)

create table BAOCAODOANHSO(
 MaBCDS int,
 Thang int,
 Nam int,
 TongDoanhThu int,
 primary key (MaBCDS)
)


create table CT_BAOCAODOANHSO(
 MaBCDS int,
 MaHX int,
 SoLuotSua int,
 ThanhTien int,
 TiLe int,
 primary key (MaBCDS, MaHX)
)

alter table CT_BAOCAODOANHSO add constraint A foreign key (MaBCDS) references BAOCAODOANHSO(MaBCDS)
alter table CT_BAOCAODOANHSO add foreign key (MaHX) references HIEUXE(MaHX)

create table BAOCAOTON(
 MaVTPT int,
 Thang int, 
 Nam int,
 TonDau int,
 TonCuoi int,
 PhatSinh int,
 primary key (MaVTPT, Thang, Nam)
)
alter table BAOCAOTON add foreign key (MaVTPT) references VATTUPHUTUNG(MaVTPT)
GO

CREATE PROC USP_GetListVTPTbyMaVTPT
@maVTPT varchar(50)
AS
BEGIN
SELECT * FROM VATTUPHUTUNG WHERE MaVTPT=@maVTPT
END
GO

INSERT INTO VATTUPHUTUNG VALUES (101, 'Banh xe', 100000, 200000,1)
INSERT INTO VATTUPHUTUNG VALUES (102, 'Dau nhot', 200000, 250000,2)
INSERT INTO VATTUPHUTUNG VALUES (103, 'Son xe 1L', 100000, 150000,3)
GO

DELETE FROM VATTUPHUTUNG WHERE MaVTPT=0