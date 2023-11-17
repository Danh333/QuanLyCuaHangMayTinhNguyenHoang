USE [nguoidung]
GO

/****** Object:  Table [dbo].[hoadon]    Script Date: 17/11/2023 2:19:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[hoadon](
	[mahd] [nvarchar](50) NULL,
	[tenhd] [nvarchar](50) NULL,
	[tensp] [nvarchar](50) NULL,
	[gia] [float] NULL,
	[ngayhd] [datetime] NULL,
	[tinhtrang] [nvarchar](50) NULL
) ON [PRIMARY]

GO

