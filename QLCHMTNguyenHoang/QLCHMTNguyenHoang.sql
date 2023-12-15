/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     12/12/2023 12:12:12 SA                        */
/*==============================================================*/

Create Database QLCHMTNguyenHoang
use QLCHMTNguyenHoang
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('QLbanhang') and o.name = 'FK_QLBANHAN_BANHANGHA_QLHANGHO')
alter table QLbanhang
   drop constraint FK_QLBANHAN_BANHANGHA_QLHANGHO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('QLbanhang') and o.name = 'FK_QLBANHAN_BANHANGHO_QLHOADON')
alter table QLbanhang
   drop constraint FK_QLBANHAN_BANHANGHO_QLHOADON
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('QLhoadon') and o.name = 'FK_QLHOADON_HOADONKHA_QLKHACHH')
alter table QLhoadon
   drop constraint FK_QLHOADON_HOADONKHA_QLKHACHH
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('QLhoadon') and o.name = 'FK_QLHOADON_HOADONNHA_QLNHANVI')
alter table QLhoadon
   drop constraint FK_QLHOADON_HOADONNHA_QLNHANVI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('QLkhohang') and o.name = 'FK_QLKHOHAN_KHOHANGHA_QLHANGHO')
alter table QLkhohang
   drop constraint FK_QLKHOHAN_KHOHANGHA_QLHANGHO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('QLbanhang')
            and   name  = 'BanhangHanghoa_FK'
            and   indid > 0
            and   indid < 255)
   drop index QLbanhang.BanhangHanghoa_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('QLbanhang')
            and   name  = 'BanhangHoadon_FK'
            and   indid > 0
            and   indid < 255)
   drop index QLbanhang.BanhangHoadon_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('QLbanhang')
            and   type = 'U')
   drop table QLbanhang
go

if exists (select 1
            from  sysobjects
           where  id = object_id('QLhanghoa')
            and   type = 'U')
   drop table QLhanghoa
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('QLhoadon')
            and   name  = 'HoadonKhachhang_FK'
            and   indid > 0
            and   indid < 255)
   drop index QLhoadon.HoadonKhachhang_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('QLhoadon')
            and   name  = 'HoadonNhanvien_FK'
            and   indid > 0
            and   indid < 255)
   drop index QLhoadon.HoadonNhanvien_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('QLhoadon')
            and   type = 'U')
   drop table QLhoadon
go

if exists (select 1
            from  sysobjects
           where  id = object_id('QLkhachhang')
            and   type = 'U')
   drop table QLkhachhang
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('QLkhohang')
            and   name  = 'KhohangHanghoa_FK'
            and   indid > 0
            and   indid < 255)
   drop index QLkhohang.KhohangHanghoa_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('QLkhohang')
            and   type = 'U')
   drop table QLkhohang
go

if exists (select 1
            from  sysobjects
           where  id = object_id('QLnhanvien')
            and   type = 'U')
   drop table QLnhanvien
go

/*==============================================================*/
/* Table: QLbanhang                                             */
/*==============================================================*/
create table QLbanhang (
   Mabanhang            int                  not null,
   Mahoadon             int                  not null,
   MaHH                 int                  not null,
   Soluong              int                  null,
   Giaban               float                null,
   constraint PK_QLBANHANG primary key (Mabanhang)
)
go

/*==============================================================*/
/* Index: BanhangHoadon_FK                                      */
/*==============================================================*/




create nonclustered index BanhangHoadon_FK on QLbanhang (Mahoadon ASC)
go

/*==============================================================*/
/* Index: BanhangHanghoa_FK                                     */
/*==============================================================*/




create nonclustered index BanhangHanghoa_FK on QLbanhang (MaHH ASC)
go

/*==============================================================*/
/* Table: QLhanghoa                                             */
/*==============================================================*/
create table QLhanghoa (
   MaHH                 int                  not null,
   TenHH                nvarchar(255)        null,
   Imei                 int                  null,
   Soluong              int                  null,
   Giaban               float                null,
   constraint PK_QLHANGHOA primary key (MaHH)
)
go

/*==============================================================*/
/* Table: QLhoadon                                              */
/*==============================================================*/
create table QLhoadon (
   Mahoadon             int                  not null,
   MaKH                 int                  not null,
   MaNV                 int                  not null,
   Soluong              int                  null,
   Ngayban              datetime             null,
   constraint PK_QLHOADON primary key (Mahoadon)
)
go

/*==============================================================*/
/* Index: HoadonNhanvien_FK                                     */
/*==============================================================*/




create nonclustered index HoadonNhanvien_FK on QLhoadon (MaNV ASC)
go

/*==============================================================*/
/* Index: HoadonKhachhang_FK                                    */
/*==============================================================*/




create nonclustered index HoadonKhachhang_FK on QLhoadon (MaKH ASC)
go

/*==============================================================*/
/* Table: QLkhachhang                                           */
/*==============================================================*/
create table QLkhachhang (
   MaKH                 int                  not null,
   TenKH                nvarchar(255)        null,
   SoDT                 int                  null,
   Email                nvarchar(255)        null,
   Diachi               nvarchar(255)        null,
   constraint PK_QLKHACHHANG primary key (MaKH)
)
go

/*==============================================================*/
/* Table: QLkhohang                                             */
/*==============================================================*/
create table QLkhohang (
   MaKho                int                  not null,
   MaHH                 int                  not null,
   TenKho               nvarchar(255)        null,
   TenHH                nvarchar(255)        null,
   Mota                 nvarchar(255)        null,
   Soluongton           int                  null,
   constraint PK_QLKHOHANG primary key (MaKho)
)
go

/*==============================================================*/
/* Index: KhohangHanghoa_FK                                     */
/*==============================================================*/




create nonclustered index KhohangHanghoa_FK on QLkhohang (MaHH ASC)
go

/*==============================================================*/
/* Table: QLnhanvien                                            */
/*==============================================================*/
create table QLnhanvien (
   MaNV                 int                  not null,
   TenNV                nvarchar(255)        null,
   Gioitinh             bit                  null,
   CCCD                 int                  null,
   SoDT                 int                  null,
   Diachi               nvarchar(255)        null,
   Chucvu               nvarchar(255)        null,
   constraint PK_QLNHANVIEN primary key (MaNV)
)
go

alter table QLbanhang
   add constraint FK_QLBANHAN_BANHANGHA_QLHANGHO foreign key (MaHH)
      references QLhanghoa (MaHH)
go

alter table QLbanhang
   add constraint FK_QLBANHAN_BANHANGHO_QLHOADON foreign key (Mahoadon)
      references QLhoadon (Mahoadon)
go

alter table QLhoadon
   add constraint FK_QLHOADON_HOADONKHA_QLKHACHH foreign key (MaKH)
      references QLkhachhang (MaKH)
go

alter table QLhoadon
   add constraint FK_QLHOADON_HOADONNHA_QLNHANVI foreign key (MaNV)
      references QLnhanvien (MaNV)
go

alter table QLkhohang
   add constraint FK_QLKHOHAN_KHOHANGHA_QLHANGHO foreign key (MaHH)
      references QLhanghoa (MaHH)
go

