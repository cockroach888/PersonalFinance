USE [PF]
GO

/****** Object:  Table [dbo].[FinanceAccounts]  ’ ŒÒ’ ∫≈±Ì  Script Date: 02/10/2011 11:45:50 ******/
if exists (select * from sysobjects where id = object_id(N'[FinanceAccounts]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [FinanceAccounts] 

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

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'œµÕ≥±‡∫≈' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceAccounts', @level2type=N'COLUMN',@level2name=N'fiActId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'≥…‘±±‡∫≈' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceAccounts', @level2type=N'COLUMN',@level2name=N'fiMbrId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'◊¢≤·»’∆⁄' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceAccounts', @level2type=N'COLUMN',@level2name=N'fiActRegDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'’ ∫≈√˚≥∆' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceAccounts', @level2type=N'COLUMN',@level2name=N'fiActName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'’ ∫≈±‡¬Î' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceAccounts', @level2type=N'COLUMN',@level2name=N'fiActNo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'’ ∫≈◊¥Ã¨' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceAccounts', @level2type=N'COLUMN',@level2name=N'fiActStatus'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'’ ∫≈”√Õæ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceAccounts', @level2type=N'COLUMN',@level2name=N'fiActPurpose'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'’ ∫≈Àµ√˜' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceAccounts', @level2type=N'COLUMN',@level2name=N'fiActExplain'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'±£¡Ù◊÷∂Œ01' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceAccounts', @level2type=N'COLUMN',@level2name=N'fiActBkFd01'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'±£¡Ù◊÷∂Œ02' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceAccounts', @level2type=N'COLUMN',@level2name=N'fiActBkFd02'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'’ ŒÒ’ ∫≈±Ì' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FinanceAccounts'
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


