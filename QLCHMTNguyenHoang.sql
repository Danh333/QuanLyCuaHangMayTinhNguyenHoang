/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     11/12/2023 7:16:37 CH                        */
/*==============================================================*/
create database QLCHMaytinh
use QLCHMaytinh
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('QLbanhang') and o.name = 'FK_QLBANHAN_BANHANGKH_QLKHOHAN')
alter table QLbanhang
   drop constraint FK_QLBANHAN_BANHANGKH_QLKHOHAN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('QLhanghoa') and o.name = 'FK_QLHANGHO_HANGHOABA_QLBANHAN')
alter table QLhanghoa
   drop constraint FK_QLHANGHO_HANGHOABA_QLBANHAN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('QLhanghoa') and o.name = 'FK_QLHANGHO_HANGHOAKH_QLKHOHAN')
alter table QLhanghoa
   drop constraint FK_QLHANGHO_HANGHOAKH_QLKHOHAN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('QLhoadon') and o.name = 'FK_QLHOADON_HANGHOAHO_QLHANGHO')
alter table QLhoadon
   drop constraint FK_QLHOADON_HANGHOAHO_QLHANGHO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('QLhoadon') and o.name = 'FK_QLHOADON_HOADONKHA_QLKHACHH')
alter table QLhoadon
   drop constraint FK_QLHOADON_HOADONKHA_QLKHACHH
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('QLhoadon') and o.name = 'FK_QLHOADON_NHANVIENH_QLNHANVI')
alter table QLhoadon
   drop constraint FK_QLHOADON_NHANVIENH_QLNHANVI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('QLkhohang') and o.name = 'FK_QLKHOHAN_NHANVIENK_QLNHANVI')
alter table QLkhohang
   drop constraint FK_QLKHOHAN_NHANVIENK_QLNHANVI
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('QLbanhang')
            and   name  = 'BanhangKhohang_FK'
            and   indid > 0
            and   indid < 255)
   drop index QLbanhang.BanhangKhohang_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('QLbanhang')
            and   type = 'U')
   drop table QLbanhang
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('QLhanghoa')
            and   name  = 'HanghoaKhohang_FK'
            and   indid > 0
            and   indid < 255)
   drop index QLhanghoa.HanghoaKhohang_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('QLhanghoa')
            and   name  = 'HanghoaBanhang_FK'
            and   indid > 0
            and   indid < 255)
   drop index QLhanghoa.HanghoaBanhang_FK
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
            and   name  = 'NhanvienHoadon_FK'
            and   indid > 0
            and   indid < 255)
   drop index QLhoadon.NhanvienHoadon_FK
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
            and   name  = 'HanghoaHoadon_FK'
            and   indid > 0
            and   indid < 255)
   drop index QLhoadon.HanghoaHoadon_FK
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
            and   name  = 'NhanvienKhohang_FK'
            and   indid > 0
            and   indid < 255)
   drop index QLkhohang.NhanvienKhohang_FK
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
   Mahoadon             char(10)             not null,
   MaKho                char(10)             not null,
   MaKH                 char(10)             null,
   MaNV                 char(10)             null,
   MaHH                 char(10)             null,
   Soluong              int                  null,
   Giaban               int                  null,
   Thanhtien            int                  null,
   constraint PK_QLBANHANG primary key (Mahoadon)
)
go

/*==============================================================*/
/* Index: BanhangKhohang_FK                                     */
/*==============================================================*/




create nonclustered index BanhangKhohang_FK on QLbanhang (MaKho ASC)
go

/*==============================================================*/
/* Table: QLhanghoa                                             */
/*==============================================================*/
create table QLhanghoa (
   MaHH                 char(10)             not null,
   MaKho                char(10)             not null,
   Mahoadon             char(10)             not null,
   TenHH                char(255)            null,
   Soluong              int                  null,
   Giaban               int                  null,
   constraint PK_QLHANGHOA primary key (MaHH)
)
go

/*==============================================================*/
/* Index: HanghoaBanhang_FK                                     */
/*==============================================================*/




create nonclustered index HanghoaBanhang_FK on QLhanghoa (Mahoadon ASC)
go

/*==============================================================*/
/* Index: HanghoaKhohang_FK                                     */
/*==============================================================*/




create nonclustered index HanghoaKhohang_FK on QLhanghoa (MaKho ASC)
go

/*==============================================================*/
/* Table: QLhoadon                                              */
/*==============================================================*/
create table QLhoadon (
   Mahoadon             char(10)             not null,
   MaHH                 char(10)             not null,
   MaNV                 char(10)             not null,
   MaKH                 char(10)             not null,
   Soluong              int                  null,
   Ngayban              datetime             null,
   Diachi               char(255)            null,
   SoDT                 int                  null,
   Giaban               int                  null,
   hinhanh              image                null,
   constraint PK_QLHOADON primary key (Mahoadon)
)
go

/*==============================================================*/
/* Index: HanghoaHoadon_FK                                      */
/*==============================================================*/




create nonclustered index HanghoaHoadon_FK on QLhoadon (MaHH ASC)
go

/*==============================================================*/
/* Index: HoadonKhachhang_FK                                    */
/*==============================================================*/




create nonclustered index HoadonKhachhang_FK on QLhoadon (MaKH ASC)
go

/*==============================================================*/
/* Index: NhanvienHoadon_FK                                     */
/*==============================================================*/




create nonclustered index NhanvienHoadon_FK on QLhoadon (MaNV ASC)
go

/*==============================================================*/
/* Table: QLkhachhang                                           */
/*==============================================================*/
create table QLkhachhang (
   MaKH                 char(10)             not null,
   TenKH                char(255)            null,
   Diachi               char(255)            null,
   SoDT                 int                  null,
   Ghichu               char(255)            null,
   Sohoadon             int                  null,
   constraint PK_QLKHACHHANG primary key (MaKH)
)
go

/*==============================================================*/
/* Table: QLkhohang                                             */
/*==============================================================*/
create table QLkhohang (
   MaKho                char(10)             not null,
   MaNV                 char(10)             not null,
   Mahoadon             char(10)             null,
   TenHH                char(255)            null,
   Soluong              int                  null,
   Hangton              int                  null,
   constraint PK_QLKHOHANG primary key (MaKho)
)
go

/*==============================================================*/
/* Index: NhanvienKhohang_FK                                    */
/*==============================================================*/




create nonclustered index NhanvienKhohang_FK on QLkhohang (MaNV ASC)
go

/*==============================================================*/
/* Table: QLnhanvien                                            */
/*==============================================================*/
create table QLnhanvien (
   MaNV                 char(10)             not null,
   TenNV                char(255)            null,
   gioitinh             bit                  null,
   chucvu               char(100)            null,
   Cccd                 int                  null,
   SoDT                 int                  null,
   Diachi               char(255)            null,
   constraint PK_QLNHANVIEN primary key (MaNV)
)
go

alter table QLbanhang
   add constraint FK_QLBANHAN_BANHANGKH_QLKHOHAN foreign key (MaKho)
      references QLkhohang (MaKho)
go

alter table QLhanghoa
   add constraint FK_QLHANGHO_HANGHOABA_QLBANHAN foreign key (Mahoadon)
      references QLbanhang (Mahoadon)
go

alter table QLhanghoa
   add constraint FK_QLHANGHO_HANGHOAKH_QLKHOHAN foreign key (MaKho)
      references QLkhohang (MaKho)
go

alter table QLhoadon
   add constraint FK_QLHOADON_HANGHOAHO_QLHANGHO foreign key (MaHH)
      references QLhanghoa (MaHH)
go

alter table QLhoadon
   add constraint FK_QLHOADON_HOADONKHA_QLKHACHH foreign key (MaKH)
      references QLkhachhang (MaKH)
go

alter table QLhoadon
   add constraint FK_QLHOADON_NHANVIENH_QLNHANVI foreign key (MaNV)
      references QLnhanvien (MaNV)
go

alter table QLkhohang
   add constraint FK_QLKHOHAN_NHANVIENK_QLNHANVI foreign key (MaNV)
      references QLnhanvien (MaNV)
go

insert into QLhoadon(Mahoadon,mahh,manv,makh) VALUES ('12','muoi8','haha','d47')