USE [PF]
GO

/****** Object:  Table [dbo].[FinanceCategory]  收支类别表  Script Date: 02/10/2011 11:46:15 ******/
if exists (select * from sysobjects where id = object_id(N'[FinanceCategory]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [FinanceCategory] 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FinanceCategory](
	[fiCatId] [int] NOT NULL,
	[fiCatName] [nvarchar](50) NOT NULL,
	[fiCatFather] [int] NOT NULL,
	[fiCatPath] [varchar](max) NOT NULL,
	[fiCatClick] [int] NULL,
	[fiCatCounts] [int] NOT NULL,
	[fiCatDescribe] [nvarchar](300) NULL,
	[fiCatBkFd01] [int] NULL,
	[fiCatBkFd02] [tinyint] NULL,
	[fiCatBkFd03] [varchar](50) NULL,
 CONSTRAINT [PK_FinanceCategory] PRIMARY KEY CLUSTERED 
(
	[fiCatId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceCategory', @level2type=N'COLUMN',@level2name=N'fiCatId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类别名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceCategory', @level2type=N'COLUMN',@level2name=N'fiCatName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类别标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceCategory', @level2type=N'COLUMN',@level2name=N'fiCatFather'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类别路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceCategory', @level2type=N'COLUMN',@level2name=N'fiCatPath'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'点击率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceCategory', @level2type=N'COLUMN',@level2name=N'fiCatClick'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据统计' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceCategory', @level2type=N'COLUMN',@level2name=N'fiCatCounts'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类别描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceCategory', @level2type=N'COLUMN',@level2name=N'fiCatDescribe'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保留字段01' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceCategory', @level2type=N'COLUMN',@level2name=N'fiCatBkFd01'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保留字段02' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceCategory', @level2type=N'COLUMN',@level2name=N'fiCatBkFd02'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保留字段03' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceCategory', @level2type=N'COLUMN',@level2name=N'fiCatBkFd03'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收支类别表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceCategory'
GO

ALTER TABLE [dbo].[FinanceCategory] ADD  CONSTRAINT [DF_FinanceCategory_fiCatClick]  DEFAULT ((0)) FOR [fiCatClick]
GO

ALTER TABLE [dbo].[FinanceCategory] ADD  CONSTRAINT [DF_FinanceCategory_fiCatCounts]  DEFAULT ((0)) FOR [fiCatCounts]
GO


