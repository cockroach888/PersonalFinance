USE [PF]
GO

/****** Object:  Table [dbo].[FinanceLog]  日志信息表  Script Date: 05/19/2011 16:40:53 ******/
if exists (select * from sysobjects where id = object_id(N'[FinanceLog]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [FinanceLog]  

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FinanceLog](
	[logId] [uniqueidentifier] NOT NULL,
	[logDate] [datetime] NOT NULL,
	[logTable] [varchar](100) NOT NULL,
	[logAction] [nvarchar](max) NOT NULL,
	[logRemark] [nvarchar](max) NULL,
	[adminName] [varchar](20) NOT NULL,
	[logBkFd01] [int] NULL,
	[logBkFd02] [tinyint] NULL,
	[logBkFd03] [nvarchar](max) NULL,
 CONSTRAINT [PK_FinanceLog] PRIMARY KEY CLUSTERED 
(
	[logId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceLog', @level2type=N'COLUMN',@level2name=N'logId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceLog', @level2type=N'COLUMN',@level2name=N'logDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录表名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceLog', @level2type=N'COLUMN',@level2name=N'logTable'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录动作' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceLog', @level2type=N'COLUMN',@level2name=N'logAction'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceLog', @level2type=N'COLUMN',@level2name=N'logRemark'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceLog', @level2type=N'COLUMN',@level2name=N'adminName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保留字段01' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceLog', @level2type=N'COLUMN',@level2name=N'logBkFd01'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保留字段02' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceLog', @level2type=N'COLUMN',@level2name=N'logBkFd02'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保留字段03' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceLog', @level2type=N'COLUMN',@level2name=N'logBkFd03'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceLog'
GO

ALTER TABLE [dbo].[FinanceLog] ADD  CONSTRAINT [DF_FinanceLog_logDate]  DEFAULT (getdate()) FOR [logDate]
GO


