USE [TBItem]
GO
/****** Object:  Table [dbo].[TBItems]    Script Date: 29/06/2021 17:53:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBItems](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Price] [float] NOT NULL,
	[Size] [nchar](10) NOT NULL
) ON [PRIMARY]
GO
