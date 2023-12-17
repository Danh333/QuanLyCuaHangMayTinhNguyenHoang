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
