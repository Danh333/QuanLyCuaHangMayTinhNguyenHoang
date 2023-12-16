/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     15/12/2023 10:45:00 CH                       */
/*==============================================================*/

Create Database QLCHMTNguyenHoang
Use QLCHMTNguyenHoang
Go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BanHang') and o.name = 'FK_BANHANG_BHHD_HOADON')
alter table BanHang
   drop constraint FK_BANHANG_BHHD_HOADON
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BanHang') and o.name = 'FK_BANHANG_BHHH_HANGHOA')
alter table BanHang
   drop constraint FK_BANHANG_BHHH_HANGHOA
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
   where r.fkeyid = object_id('KhoHang') and o.name = 'FK_KHOHANG_KHHH_HANGHOA')
alter table KhoHang
   drop constraint FK_KHOHANG_KHHH_HANGHOA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('BanHang')
            and   name  = 'BanhangHanghoa_FK'
            and   indid > 0
            and   indid < 255)
   drop index BanHang.BanhangHanghoa_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('BanHang')
            and   name  = 'BanhangHoadon_FK'
            and   indid > 0
            and   indid < 255)
   drop index BanHang.BanhangHoadon_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BanHang')
            and   type = 'U')
   drop table BanHang
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
            and   name  = 'HoadonKhachhang_FK'
            and   indid > 0
            and   indid < 255)
   drop index HoaDon.HoadonKhachhang_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('HoaDon')
            and   name  = 'HoadonNhanvien_FK'
            and   indid > 0
            and   indid < 255)
   drop index HoaDon.HoadonNhanvien_FK
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
            from  sysindexes
           where  id    = object_id('KhoHang')
            and   name  = 'KhohangHanghoa_FK'
            and   indid > 0
            and   indid < 255)
   drop index KhoHang.KhohangHanghoa_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('KhoHang')
            and   type = 'U')
   drop table KhoHang
go

if exists (select 1
            from  sysobjects
           where  id = object_id('NhanVien')
            and   type = 'U')
   drop table NhanVien
go

/*==============================================================*/
/* Table: BanHang                                               */
/*==============================================================*/
create table BanHang (
   Mabanhang            char(5)              not null,
   Mahoadon             char(5)              not null,
   MaHH                 char(5)              not null,
   Dongia               int                  null,
   Tongtien             int                  null,
   constraint PK_BANHANG primary key (Mabanhang)
)
go

/*==============================================================*/
/* Index: BanhangHoadon_FK                                      */
/*==============================================================*/




create nonclustered index BanhangHoadon_FK on BanHang (Mahoadon ASC)
go

/*==============================================================*/
/* Index: BanhangHanghoa_FK                                     */
/*==============================================================*/




create nonclustered index BanhangHanghoa_FK on BanHang (MaHH ASC)
go

/*==============================================================*/
/* Table: HangHoa                                               */
/*==============================================================*/
create table HangHoa (
   MaHH                 char(5)              not null,
   Imei                 int                  null,
   TenHH                nvarchar(255)        null,
   Soluong              int                  null,
   Chatluong            nvarchar(255)        null,
   Gia                  int                  null,
   constraint PK_HANGHOA primary key (MaHH)
)
go

/*==============================================================*/
/* Table: HoaDon                                                */
/*==============================================================*/
create table HoaDon (
   Mahoadon             char(5)              not null,
   MaKH                 char(5)              not null,
   MaNV                 char(5)              not null,
   Ngaylap              date                 null,
   Soluong              int                  null,
   constraint PK_HOADON primary key (Mahoadon)
)
go

/*==============================================================*/
/* Index: HoadonNhanvien_FK                                     */
/*==============================================================*/




create nonclustered index HoadonNhanvien_FK on HoaDon (MaNV ASC)
go

/*==============================================================*/
/* Index: HoadonKhachhang_FK                                    */
/*==============================================================*/




create nonclustered index HoadonKhachhang_FK on HoaDon (MaKH ASC)
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
   CongNo                   bit              null,
   constraint PK_KHACHHANG primary key (MaKH)
)
go

/*==============================================================*/
/* Table: KhoHang                                               */
/*==============================================================*/
create table KhoHang (
   MaKho                char(5)              not null,
   MaHH                 char(5)              not null,
   TenKho               nvarchar(255)        null,
   Diachi               nvarchar(255)        null,
   SoDT                 char(10)             null,
   Soluongton           int                  null,
   constraint PK_KHOHANG primary key (MaKho)
)
go

/*==============================================================*/
/* Index: KhohangHanghoa_FK                                     */
/*==============================================================*/




create nonclustered index KhohangHanghoa_FK on KhoHang (MaHH ASC)
go

/*==============================================================*/
/* Table: NhanVien                                              */
/*==============================================================*/
create table NhanVien (
   MaNV                 char(5)              not null,
   TenNV                nvarchar(255)        null,
   Gioitinh             bit                  null,
   CCCD                 char(12)             null,
   SoDT                 char(10)             null,
   Diachi               nvarchar(255)        null,
   Chucvu               nvarchar(255)        null,
   constraint PK_NHANVIEN primary key (MaNV)
)
go

alter table BanHang
   add constraint FK_BANHANG_BHHD_HOADON foreign key (Mahoadon)
      references HoaDon (Mahoadon)
go

alter table BanHang
   add constraint FK_BANHANG_BHHH_HANGHOA foreign key (MaHH)
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

alter table KhoHang
   add constraint FK_KHOHANG_KHHH_HANGHOA foreign key (MaHH)
      references HangHoa (MaHH)
go



Insert into KhachHang(MaKH,TenKH,SoDT,Email,Diachi) values ('KH001',N'Nguyễn Thị A','0909080807','nguyenthia@gmail.com','An Giang');
Insert into KhachHang(MaKH,TenKH,SoDT,Email,Diachi) values ('KH002',N'Trần Văn B','0707060605','tranvanb@gmail.com','Bắc Giang');
Insert into KhachHang(MaKH,TenKH,SoDT,Email,Diachi) values ('KH003',N'Lê Thị C','0505040403','lethic@gmail.com','Hà Giang');

Insert into NhanVien(MaNV,TenNV,Gioitinh,CCCD,SoDT,Diachi,Chucvu) values ('NV001',N'Bùi Văn A',1,'123456789012','0123456789','Hậu Giang','Nhân viên kho hàng');
Insert into NhanVien(MaNV,TenNV,Gioitinh,CCCD,SoDT,Diachi,Chucvu) values ('NV002',N'Kim Thị B',0,'123456789012','0123456789','Kiên Giang','Nhân viên kho hàng');
Insert into NhanVien(MaNV,TenNV,Gioitinh,CCCD,SoDT,Diachi,Chucvu) values ('NV003',N'Lý Minh C',1,'123456789012','0123456789','Tiền Giang','Nhân viên kho hàng');

Insert into HoaDon(Mahoadon,MaKH,MaNV,Ngaylap,Soluong) values ('HD001','KH001','NV003','2023-12-15',1);
Insert into HoaDon(Mahoadon,MaKH,MaNV,Ngaylap,Soluong) values ('HD002','KH002','NV002','2023-11-15',2);
Insert into HoaDon(Mahoadon,MaKH,MaNV,Ngaylap,Soluong) values ('HD003','KH003','NV001','2023-10-15',3);

Insert into HangHoa(MaHH,Imei,Soluong,Chatluong,Gia) values ('HH001','1122334455','10','Mới',10000000);

Insert into BanHang(Mabanhang,MaHH,Mahoadon) values ('BH001','HH001','HD001');

Insert into KhoHang(MaKho,MaHH,TenKho,Diachi,SoDT,Soluongton) values ('KHO01','HH001','Kho A','TP HCM','0690967531',20);