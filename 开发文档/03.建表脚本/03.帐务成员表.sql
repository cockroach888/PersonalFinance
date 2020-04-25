USE [PF]
GO

/****** Object:  Table [dbo].[FinanceMember]  帐务成员表  Script Date: 02/10/2011 11:45:18 ******/
if exists (select * from sysobjects where id = object_id(N'[FinanceMember]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [FinanceMember] 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FinanceMember](
	[fiMbrId] [smallint] IDENTITY(1,1) NOT NULL,
	[fiMbrRegDate] [datetime] NOT NULL,
	[fiMbrName] [nvarchar](10) NOT NULL,
	[fiMbrRelation] [nvarchar](50) NOT NULL,
	[fiMbrExplain] [nvarchar](500) NULL,
	[fiMbrBkFd01] [int] NULL,
	[fiMbrBkFd02] [tinyint] NULL,
	[fiMbrBkFd03] [varchar](50) NULL,
 CONSTRAINT [PK_FinanceMember] PRIMARY KEY CLUSTERED 
(
	[fiMbrId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceMember', @level2type=N'COLUMN',@level2name=N'fiMbrId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'注册日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceMember', @level2type=N'COLUMN',@level2name=N'fiMbrRegDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成员名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceMember', @level2type=N'COLUMN',@level2name=N'fiMbrName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成员关系' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceMember', @level2type=N'COLUMN',@level2name=N'fiMbrRelation'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成员说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceMember', @level2type=N'COLUMN',@level2name=N'fiMbrExplain'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保留字段01' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceMember', @level2type=N'COLUMN',@level2name=N'fiMbrBkFd01'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保留字段02' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceMember', @level2type=N'COLUMN',@level2name=N'fiMbrBkFd02'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保留字段03' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceMember', @level2type=N'COLUMN',@level2name=N'fiMbrBkFd03'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帐务成员表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceMember'
GO

ALTER TABLE [dbo].[FinanceMember] ADD  CONSTRAINT [DF_FinanceMember_fiMbrRegDate]  DEFAULT (getdate()) FOR [fiMbrRegDate]
GO


