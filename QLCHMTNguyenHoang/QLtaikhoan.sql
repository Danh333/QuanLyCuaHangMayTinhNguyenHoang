CREATE DATABASE QLtaikhoan
USE QLtaikhoan
GO

/****** Object:  Table [dbo].[nguoidung]    Script Date: 12/12/2023 9:22:22 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[nguoidung](
	[username] [nvarchar](20) NULL,
	[password] [nvarchar](30) NULL,
	[quyen] [nvarchar](20) NULL
) ON [PRIMARY]

GO

Insert into nguoidung(username,password,quyen) values ('admin','12345','admin');
Insert into nguoidung(username,password,quyen) values ('Danh','12345',N'nhân viên kho hàng');

