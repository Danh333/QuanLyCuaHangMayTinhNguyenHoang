/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     17/12/2023 11:11:27 SA                       */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BaoHanh') and o.name = 'FK_BAOHANH_BHHH_HANGHOA')
alter table BaoHanh
   drop constraint FK_BAOHANH_BHHH_HANGHOA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('HoaDon') and o.name = 'FK_HOADON_HDHH_HANGHOA')
alter table HoaDon
   drop constraint FK_HOADON_HDHH_HANGHOA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('HoaDon') and o.name = 'FK_HOADON_HDKH_KHACHHANG')
alter table HoaDon
   drop constraint FK_HOADON_HDKH_KHACHHANG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('HoaDon') and o.name = 'FK_HOADON_HDNV_NHANVIEN')
alter table HoaDon
   drop constraint FK_HOADON_HDNV_NHANVIEN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PhieuNhapXuat') and o.name = 'FK_PHIEUNHAPXUAT_NHAPXUATHH_HANGHOA')
alter table PhieuNhapXuat
   drop constraint FK_PHIEUNHAPXUAT_NHAPXUATHH_HANGHOA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('BaoHanh')
            and   name  = 'BhHh_FK'
            and   indid > 0
            and   indid < 255)
   drop index BaoHanh.BhHh_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BaoHanh')
            and   type = 'U')
   drop table BaoHanh
go

if exists (select 1
            from  sysobjects
           where  id = object_id('HangHoa')
            and   type = 'U')
   drop table HangHoa
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('HoaDon')
            and   name  = 'HdHh_FK'
            and   indid > 0
            and   indid < 255)
   drop index HoaDon.HdHh_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('HoaDon')
            and   name  = 'HdKh_FK'
            and   indid > 0
            and   indid < 255)
   drop index HoaDon.HdKh_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('HoaDon')
            and   name  = 'HdNv_FK'
            and   indid > 0
            and   indid < 255)
   drop index HoaDon.HdNv_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('HoaDon')
            and   type = 'U')
   drop table HoaDon
go

if exists (select 1
            from  sysobjects
           where  id = object_id('KhachHang')
            and   type = 'U')
   drop table KhachHang
go

if exists (select 1
            from  sysobjects
           where  id = object_id('NhanVien')
            and   type = 'U')
   drop table NhanVien
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PhieuNhapXuat')
            and   name  = 'NhapXuatHh_FK'
            and   indid > 0
            and   indid < 255)
   drop index PhieuNhapXuat.NhapXuatHh_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PhieuNhapXuat')
            and   type = 'U')
   drop table PhieuNhapXuat
go

/*==============================================================*/
/* Table: BaoHanh                                               */
/*==============================================================*/
create table BaoHanh (
   MaBH                 char(5)              not null,
   MaHH                 char(5)              not null,
   NgayBH               date                 null,
   NgayhetBH            date                 null,
   constraint PK_BAOHANH primary key (MaBH)
)
go

/*==============================================================*/
/* Index: BhHh_FK                                               */
/*==============================================================*/




create nonclustered index BhHh_FK on BaoHanh (MaHH ASC)
go

/*==============================================================*/
/* Table: HangHoa                                               */
/*==============================================================*/
create table HangHoa (
   MaHH                 char(5)              not null,
   TenHH                nvarchar(255)        null,
   Imei                 int                  null,
   Soluong              int                  null,
   Dongia               int                  null,
   Ngaycapnhat          date                 null,
   constraint PK_HANGHOA primary key (MaHH)
)
go

/*==============================================================*/
/* Table: HoaDon                                                */
/*==============================================================*/
create table HoaDon (
   MaHD                 char(5)              not null,
   MaHH                 char(5)              not null,
   MaKH                 char(5)              not null,
   MaNV                 char(5)              not null,
   Soluong              int                  null,
   Dongia               int                  null,
   Tongtien             int                  null,
   Ngaylap              date                 null,
   constraint PK_HOADON primary key (MaHD)
)
go

/*==============================================================*/
/* Index: HdNv_FK                                               */
/*==============================================================*/




create nonclustered index HdNv_FK on HoaDon (MaNV ASC)
go

/*==============================================================*/
/* Index: HdKh_FK                                               */
/*==============================================================*/




create nonclustered index HdKh_FK on HoaDon (MaKH ASC)
go

/*==============================================================*/
/* Index: HdHh_FK                                               */
/*==============================================================*/




create nonclustered index HdHh_FK on HoaDon (MaHH ASC)
go

/*==============================================================*/
/* Table: KhachHang                                             */
/*==============================================================*/
create table KhachHang (
   MaKH                 char(5)              not null,
   TenKH                nvarchar(255)        null,
   SoDT                 char(10)             null,
   Email                nvarchar(255)        null,
   Diachi               nvarchar(255)        null,
   Congno               bit                  null,
   constraint PK_KHACHHANG primary key (MaKH)
)
go

/*==============================================================*/
/* Table: NhanVien                                              */
/*==============================================================*/
create table NhanVien (
   MaNV                 char(5)              not null,
   TenNV                nvarchar(255)        null,
   CCCD                 char(12)             null,
   SoDT                 char(10)             null,
   Diachi               nvarchar(255)        null,
   Chucvu               nvarchar(255)        null,
   constraint PK_NHANVIEN primary key (MaNV)
)
go

/*==============================================================*/
/* Table: PhieuNhapXuat                                         */
/*==============================================================*/
create table PhieuNhapXuat (
   MaPhieu              char(5)              not null,
   MaHH                 char(5)              not null,
   Loai                 nvarchar(255)        null,
   Soluong              int                  null,
   Ngaylap              date                 null,
   constraint PK_PHIEUNHAPXUAT primary key (MaPhieu)
)
go

/*==============================================================*/
/* Index: NhapXuatHh_FK                                         */
/*==============================================================*/




create nonclustered index NhapXuatHh_FK on PhieuNhapXuat (MaHH ASC)
go

alter table BaoHanh
   add constraint FK_BAOHANH_BHHH_HANGHOA foreign key (MaHH)
      references HangHoa (MaHH)
go

alter table HoaDon
   add constraint FK_HOADON_HDHH_HANGHOA foreign key (MaHH)
      references HangHoa (MaHH)
go

alter table HoaDon
   add constraint FK_HOADON_HDKH_KHACHHANG foreign key (MaKH)
      references KhachHang (MaKH)
go

alter table HoaDon
   add constraint FK_HOADON_HDNV_NHANVIEN foreign key (MaNV)
      references NhanVien (MaNV)
go

alter table PhieuNhapXuat
   add constraint FK_PHIEUNHAPXUAT_NHAPXUATHH_HANGHOA foreign key (MaHH)
      references HangHoa (MaHH)
go


Insert into NhanVien(MaNV,TenNV,CCCD,SoDT,Diachi,Chucvu) values ('NV001',N'Trần Văn A','012345678910','0123456789',N'An Giang',N'Quản lý');
Insert into NhanVien(MaNV,TenNV,CCCD,SoDT,Diachi,Chucvu) values ('NV002',N'Lê Nguyễn Trần B','101112131415','9876543210',N'Bắc Giang',N'Nhân viên kho hàng');
Insert into NhanVien(MaNV,TenNV,CCCD,SoDT,Diachi,Chucvu) values ('NV003',N'Lê Thị C','161718192021','0000000000',N'Hà Giang',N'Nhân viên bán hàng');

Insert into KhachHang(MaKH,TenKH,SoDT,Email,Diachi,Congno) values ('KH001',N'Nguyễn Thị D','1234567890','nguyenthid@gmail.com','Hậu Giang',0);
Insert into KhachHang(MaKH,TenKH,SoDT,Email,Diachi,Congno) values ('KH002',N'Lê Văn E','1011121314','levane@gmail.com','Kiên Giang',0);
Insert into KhachHang(MaKH,TenKH,SoDT,Email,Diachi,Congno) values ('KH003',N'Bùi Văn F','1617181920','buivanf@gmail.com','Tiền Giang',0);

Insert into HangHoa(MaHH,TenHH,Imei,Soluong,Dongia,Ngaycapnhat) values ('HH001',N'USB Kingston 1TB','1122334455',3,1200000,'11-11-2023');
Insert into HangHoa(MaHH,TenHH,Imei,Soluong,Dongia,Ngaycapnhat) values ('HH002',N'Máy in laser trắng đen Canon','1234567890',2,3500000,'11-12-2023');
Insert into HangHoa(MaHH,TenHH,Imei,Soluong,Dongia,Ngaycapnhat) values ('HH003',N'Laptop Macbook Air M3 Pro','0011223344',1,120000000,'12-12-2023');

Insert into HoaDon(MaHD,MaHH,MaKH,MaNV,Soluong,Dongia,Tongtien,Ngaylap) values ('HD001','HH002','KH003','NV002',3,3500000,7500000,'11-22-2023');
Insert into HoaDon(MaHD,MaHH,MaKH,MaNV,Soluong,Dongia,Tongtien,Ngaylap) values ('HD002','HH001','KH002','NV003',2,1200000,2400000,'12-12-2023');
Insert into HoaDon(MaHD,MaHH,MaKH,MaNV,Soluong,Dongia,Tongtien,Ngaylap) values ('HD003','HH003','KH001','NV002',1,120000000,120000000,'1/19/2023');

Insert into PhieuNhapXuat(MaPhieu,MaHH,Loai,Soluong,Ngaylap) values ('N0001','HH001',N'Nhập Kho',30,'12-19-2023');
Insert into PhieuNhapXuat(MaPhieu,MaHH,Loai,Soluong,Ngaylap) values ('N0002','HH002',N'Nhập Kho',20,'12-19-2023');
Insert into PhieuNhapXuat(MaPhieu,MaHH,Loai,Soluong,Ngaylap) values ('N0003','HH003',N'Nhập Kho',10,'12-19-2023');

Insert into BaoHanh(MaBH,MaHH,NgayBH,NgayhetBH) values ('BH001','HH001','12-12-2023','06-12-2024');
Insert into BaoHanh(MaBH,MaHH,NgayBH,NgayhetBH) values ('BH002','HH002','11-22-2023','11-22-2024');
Insert into BaoHanh(MaBH,MaHH,NgayBH,NgayhetBH) values ('BH003','HH003','1-19-2023','1-19-2025');