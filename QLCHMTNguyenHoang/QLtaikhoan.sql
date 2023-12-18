CREATE DATABASE QLtaikhoan
USE QLtaikhoan
GO

/****** Object:  Table [dbo].[nguoidung]    Script Date: 12/15/2023 9:22:22 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE nguoidung(
	[username] [nvarchar](20) NOT NULL,
	[password] [nvarchar](30) NOT NULL,
	[quyen] [nvarchar](20) NOT NULL
) ON [PRIMARY]

GO

Insert into nguoidung(username,password,quyen) values ('admin','123','0');
Insert into nguoidung(username,password,quyen) values ('user1','123','1');
Insert into nguoidung(username,password,quyen) values ('user2','123','1');

delete from nguoidung

