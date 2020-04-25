USE [PersonalFinance]
GO

/*********************************** 首先执行删除表操作 ***********************************/

/* 错误信息表 */
if exists (select * from sysobjects where id = object_id(N'[FinanceError]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [FinanceError]

/* 日志信息表 */
if exists (select * from sysobjects where id = object_id(N'[FinanceLog]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [FinanceLog]

/* 收支明细表 */
if exists (select * from sysobjects where id = object_id(N'[FinanceExpenditure]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [FinanceExpenditure]

/* 帐务帐号表 */
if exists (select * from sysobjects where id = object_id(N'[FinanceAccounts]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [FinanceAccounts]

/* 帐务成员表 */
if exists (select * from sysobjects where id = object_id(N'[FinanceMember]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [FinanceMember]

/* 收支类别表 */
if exists (select * from sysobjects where id = object_id(N'[FinanceCategory]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [FinanceCategory]


/*********************************** 开始执行建立表脚本 ***********************************/

/****** Object:  Table [dbo].[FinanceError]  错误信息表  Script Date: 02/10/2011 11:43:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FinanceError](
	[errorId] [int] IDENTITY(1,1) NOT NULL,
	[errorDate] [datetime] NOT NULL,
	[errorPage] [varchar](2000) NOT NULL,
	[errorMessage] [varchar](4000) NOT NULL,
	[errortargetSite] [varchar](max) NOT NULL,
	[errorstackTrace] [nvarchar](max) NOT NULL,
	[errorSource] [nvarchar](max) NOT NULL,
	[errorIp] [varchar](300) NOT NULL,
	[errorName] [varchar](20) NOT NULL,
	[errorbkFd01] [int] NULL,
	[errorbkFd02] [tinyint] NULL,
	[errorbkFd03] [varchar](max) NULL,
 CONSTRAINT [PK_FinanceError] PRIMARY KEY CLUSTERED 
(
	[errorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceError', @level2type=N'COLUMN',@level2name=N'errorId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceError', @level2type=N'COLUMN',@level2name=N'errorDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'页面名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceError', @level2type=N'COLUMN',@level2name=N'errorPage'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'错误信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceError', @level2type=N'COLUMN',@level2name=N'errorMessage'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'错误目标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceError', @level2type=N'COLUMN',@level2name=N'errortargetSite'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'错误跟踪' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceError', @level2type=N'COLUMN',@level2name=N'errorstackTrace'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'错误数据' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceError', @level2type=N'COLUMN',@level2name=N'errorSource'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceError', @level2type=N'COLUMN',@level2name=N'errorIp'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceError', @level2type=N'COLUMN',@level2name=N'errorName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保留字段01' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceError', @level2type=N'COLUMN',@level2name=N'errorbkFd01'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保留字段02' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceError', @level2type=N'COLUMN',@level2name=N'errorbkFd02'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保留字段03' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceError', @level2type=N'COLUMN',@level2name=N'errorbkFd03'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'错误信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceError'
GO

ALTER TABLE [dbo].[FinanceError] ADD  CONSTRAINT [DF_FinanceError_errorDate]  DEFAULT (getdate()) FOR [errorDate]
GO

ALTER TABLE [dbo].[FinanceError] ADD  CONSTRAINT [DF_FinanceError_errorIp]  DEFAULT ('0.0.0.0') FOR [errorIp]
GO

ALTER TABLE [dbo].[FinanceError] ADD  CONSTRAINT [DF_FinanceError_errorName]  DEFAULT ('none') FOR [errorName]
GO



/****** Object:  Table [dbo].[FinanceLog]  日志信息表  Script Date: 05/19/2011 16:40:53 ******/
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



/****** Object:  Table [dbo].[FinanceMember]  帐务成员表  Script Date: 02/10/2011 11:45:18 ******/
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



/****** Object:  Table [dbo].[FinanceAccounts]  帐务帐号表  Script Date: 02/10/2011 11:45:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FinanceAccounts](
	[fiActId] [smallint] IDENTITY(1,1) NOT NULL,
	[fiMbrId] [smallint] NOT NULL,
	[fiActRegDate] [datetime] NOT NULL,
	[fiActName] [nvarchar](20) NOT NULL,
	[fiActNo] [varchar](50) NULL,
	[fiActStatus] [tinyint] NOT NULL,
	[fiActPurpose] [nvarchar](100) NULL,
	[fiActExplain] [nvarchar](500) NULL,
	[fiActBkFd01] [int] NULL,
	[fiActBkFd02] [tinyint] NULL,
 CONSTRAINT [PK_FinanceAccounts] PRIMARY KEY CLUSTERED 
(
	[fiActId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceAccounts', @level2type=N'COLUMN',@level2name=N'fiActId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成员编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceAccounts', @level2type=N'COLUMN',@level2name=N'fiMbrId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'注册日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceAccounts', @level2type=N'COLUMN',@level2name=N'fiActRegDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帐号名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceAccounts', @level2type=N'COLUMN',@level2name=N'fiActName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帐号编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceAccounts', @level2type=N'COLUMN',@level2name=N'fiActNo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帐号状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceAccounts', @level2type=N'COLUMN',@level2name=N'fiActStatus'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帐号用途' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceAccounts', @level2type=N'COLUMN',@level2name=N'fiActPurpose'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帐号说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceAccounts', @level2type=N'COLUMN',@level2name=N'fiActExplain'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保留字段01' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceAccounts', @level2type=N'COLUMN',@level2name=N'fiActBkFd01'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保留字段02' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceAccounts', @level2type=N'COLUMN',@level2name=N'fiActBkFd02'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帐务帐号表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceAccounts'
GO

ALTER TABLE [dbo].[FinanceAccounts]  WITH CHECK ADD  CONSTRAINT [FK_FinanceAccounts_FinanceMember] FOREIGN KEY([fiMbrId])
REFERENCES [dbo].[FinanceMember] ([fiMbrId])
GO

ALTER TABLE [dbo].[FinanceAccounts] CHECK CONSTRAINT [FK_FinanceAccounts_FinanceMember]
GO

ALTER TABLE [dbo].[FinanceAccounts] ADD  CONSTRAINT [DF_FinanceAccounts_fiActRegDate]  DEFAULT (getdate()) FOR [fiActRegDate]
GO

ALTER TABLE [dbo].[FinanceAccounts] ADD  CONSTRAINT [DF_FinanceAccounts_fiActStatus]  DEFAULT ((1)) FOR [fiActStatus]
GO



/****** Object:  Table [dbo].[FinanceCategory]  收支类别表  Script Date: 02/10/2011 11:46:15 ******/
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



/****** Object:  Table [dbo].[FinanceExpenditure]  收支明细表  Script Date: 02/10/2011 11:46:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FinanceExpenditure](
	[fiExpId] [int] IDENTITY(1,1) NOT NULL,
	[fiMbrId] [smallint] NOT NULL,
	[fiActId] [smallint] NOT NULL,
	[fiCatId] [int] NOT NULL,
	[fiExpDate] [datetime] NOT NULL,
	[fiExpName] [nvarchar](50) NULL,
	[fiExpMoney] [money] NOT NULL,
	[fiExpAddress] [nvarchar](200) NULL,
	[fiExpDescription] [nvarchar](500) NULL,
	[fiExpRemark] [nvarchar](2000) NULL,
	[fiExpStatus] [tinyint] NULL,
	[fiExpEditDate] [datetime] NULL,
	[fiExpEditCount] [int] NULL,
	[fiExpBkFd01] [int] NULL,
	[fiExpBkFd02] [tinyint] NULL,
	[fiExpBkFd03] [varchar](50) NULL,
 CONSTRAINT [PK_FinanceExpenditure] PRIMARY KEY CLUSTERED 
(
	[fiExpId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceExpenditure', @level2type=N'COLUMN',@level2name=N'fiExpId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成员编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceExpenditure', @level2type=N'COLUMN',@level2name=N'fiMbrId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帐务编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceExpenditure', @level2type=N'COLUMN',@level2name=N'fiActId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收支编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceExpenditure', @level2type=N'COLUMN',@level2name=N'fiCatId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceExpenditure', @level2type=N'COLUMN',@level2name=N'fiExpDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收支名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceExpenditure', @level2type=N'COLUMN',@level2name=N'fiExpName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收支金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceExpenditure', @level2type=N'COLUMN',@level2name=N'fiExpMoney'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收支地点' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceExpenditure', @level2type=N'COLUMN',@level2name=N'fiExpAddress'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收支描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceExpenditure', @level2type=N'COLUMN',@level2name=N'fiExpDescription'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收支备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceExpenditure', @level2type=N'COLUMN',@level2name=N'fiExpRemark'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收支状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceExpenditure', @level2type=N'COLUMN',@level2name=N'fiExpStatus'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceExpenditure', @level2type=N'COLUMN',@level2name=N'fiExpEditDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceExpenditure', @level2type=N'COLUMN',@level2name=N'fiExpEditCount'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保留字段01' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceExpenditure', @level2type=N'COLUMN',@level2name=N'fiExpBkFd01'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保留字段02' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceExpenditure', @level2type=N'COLUMN',@level2name=N'fiExpBkFd02'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保留字段03' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceExpenditure', @level2type=N'COLUMN',@level2name=N'fiExpBkFd03'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收支明细表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceExpenditure'
GO

ALTER TABLE [dbo].[FinanceExpenditure]  WITH CHECK ADD  CONSTRAINT [FK_FinanceExpenditure_FinanceAccounts] FOREIGN KEY([fiActId])
REFERENCES [dbo].[FinanceAccounts] ([fiActId])
GO

ALTER TABLE [dbo].[FinanceExpenditure] CHECK CONSTRAINT [FK_FinanceExpenditure_FinanceAccounts]
GO

ALTER TABLE [dbo].[FinanceExpenditure]  WITH CHECK ADD  CONSTRAINT [FK_FinanceExpenditure_FinanceCategory] FOREIGN KEY([fiCatId])
REFERENCES [dbo].[FinanceCategory] ([fiCatId])
GO

ALTER TABLE [dbo].[FinanceExpenditure] CHECK CONSTRAINT [FK_FinanceExpenditure_FinanceCategory]
GO

ALTER TABLE [dbo].[FinanceExpenditure]  WITH CHECK ADD  CONSTRAINT [FK_FinanceExpenditure_FinanceMember] FOREIGN KEY([fiMbrId])
REFERENCES [dbo].[FinanceMember] ([fiMbrId])
GO

ALTER TABLE [dbo].[FinanceExpenditure] CHECK CONSTRAINT [FK_FinanceExpenditure_FinanceMember]
GO

ALTER TABLE [dbo].[FinanceExpenditure] ADD  CONSTRAINT [DF_FinanceExpenditure_fiExpDate]  DEFAULT (getdate()) FOR [fiExpDate]
GO

ALTER TABLE [dbo].[FinanceExpenditure] ADD  CONSTRAINT [DF_FinanceExpenditure_fiExpStatus]  DEFAULT ((1)) FOR [fiExpStatus]
GO

ALTER TABLE [dbo].[FinanceExpenditure] ADD  CONSTRAINT [DF_FinanceExpenditure_fiExpEditDate]  DEFAULT (getdate()) FOR [fiExpEditDate]
GO



