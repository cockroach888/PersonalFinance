USE [PF]
GO

/******************************【帐务帐号表】******************************/

----------------------------------------------------------------------------------------------
----【模板作者：宋杰军】----【联系ＱＱ：6808240】----【创建时间：2011年02月10日 11:38:42】----
----------------------------------------------------------------------------------------------

/********************数据表【FinanceAccounts】添加存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceAccountsInsert]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceAccountsInsert]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@fiActId  系统编号
@fiMbrId  成员编号 
@fiActRegDate  注册日期 
@fiActName  帐号名称 
@fiActNo  帐号编码 
@fiActStatus  帐号状态 
@fiActPurpose  帐号用途 
@fiActExplain  帐号说明 
@fiActBkFd01  保留字段01 
@fiActBkFd02  保留字段02 
*/	
CREATE PROCEDURE [dbo].[FinanceAccountsInsert]
	@fiActId smallint output,
	@fiMbrId smallint,
	@fiActRegDate datetime,
	@fiActName nvarchar(20),
	@fiActNo varchar(50),
	@fiActStatus tinyint,
	@fiActPurpose nvarchar(100),
	@fiActExplain nvarchar(500),
	@fiActBkFd01 int,
	@fiActBkFd02 tinyint
AS
	SET NOCOUNT ON
	insert into FinanceAccounts
	(
		[fiMbrId],
		[fiActRegDate],
		[fiActName],
		[fiActNo],
		[fiActStatus],
		[fiActPurpose],
		[fiActExplain],
		[fiActBkFd01],
		[fiActBkFd02]
	) 
	values
	(
		@fiMbrId,
		@fiActRegDate,
		@fiActName,
		@fiActNo,
		@fiActStatus,
		@fiActPurpose,
		@fiActExplain,
		@fiActBkFd01,
		@fiActBkFd02
	)
	set @fiActId=scope_identity()
	return @@error
GO

/********************数据表【FinanceAccounts】修改存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceAccountsUpdate]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceAccountsUpdate]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@fiActId  系统编号
@fiMbrId  成员编号 
@fiActRegDate  注册日期 
@fiActName  帐号名称 
@fiActNo  帐号编码 
@fiActStatus  帐号状态 
@fiActPurpose  帐号用途 
@fiActExplain  帐号说明 
@fiActBkFd01  保留字段01 
@fiActBkFd02  保留字段02 
*/	
CREATE PROCEDURE [dbo].[FinanceAccountsUpdate]
	@fiActId smallint,
	@fiMbrId smallint,
	@fiActRegDate datetime,
	@fiActName nvarchar(20),
	@fiActNo varchar(50),
	@fiActStatus tinyint,
	@fiActPurpose nvarchar(100),
	@fiActExplain nvarchar(500),
	@fiActBkFd01 int,
	@fiActBkFd02 tinyint
AS
 SET NOCOUNT ON
 UPDATE [FinanceAccounts] SET
		[fiMbrId] = @fiMbrId,
		[fiActRegDate] = @fiActRegDate,
		[fiActName] = @fiActName,
		[fiActNo] = @fiActNo,
		[fiActStatus] = @fiActStatus,
		[fiActPurpose] = @fiActPurpose,
		[fiActExplain] = @fiActExplain,
		[fiActBkFd01] = @fiActBkFd01,
		[fiActBkFd02] = @fiActBkFd02
 WHERE
		
		[fiActId] = @fiActId
	return @@error
GO

/********************数据表【FinanceAccounts】删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceAccountsDelete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceAccountsDelete]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@fiActId  系统编号
*/	
CREATE PROCEDURE [dbo].[FinanceAccountsDelete]
	@fiActId smallint
AS
	SET NOCOUNT ON
	delete from [FinanceAccounts] where  [fiActId] = @fiActId
	return @@error
GO

/********************查询数据表【FinanceAccounts】所有记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceAccountsSelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceAccountsSelectAll]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[FinanceAccountsSelectAll]
@sortField varchar(100) = ' [fiActId] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[FinanceAccounts] order by '
	exec ( @filter + @sortField  )
	RETURN @@Error
go

/********************查询数据表【FinanceAccounts】某一条记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceAccountsSelect]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceAccountsSelect]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@fiActId 
*/	
CREATE PROCEDURE [dbo].[FinanceAccountsSelect]
@fiActId smallint
AS
	SET NOCOUNT ON
	SELECT * FROM [dbo].[FinanceAccounts]
		where [fiActId] = @fiActId
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【FinanceAccounts】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceAccountsSelectByParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceAccountsSelectByParams]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[FinanceAccountsSelectByParams]
@where varchar(8000) = ' 1=1 ',
@sortField varchar(100) = ' [fiActId] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[FinanceAccounts]	where '
	exec ( @filter + @where + ' ORDER BY ' + @sortField )
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【FinanceAccounts】记录数********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceAccountsCountByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceAccountsCountByWhere]
GO
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@recordCount 记录数
*/	
CREATE PROCEDURE [dbo].[FinanceAccountsCountByWhere]
@where varchar(8000) = ' 1=1 ',
@recordCount int output
AS
	SET NOCOUNT ON
	declare @sqlCount nvarchar(4000)
	set @sqlCount= 'SELECT @Count=count(-1) FROM [dbo].[FinanceAccounts] WHERE ' + @where
	--print @sqlCount 
	exec sp_executesql @sqlCount,N'@Count int output',@recordCount output  
	RETURN @@Error
GO

/********************通过指定的条件分页查询数据表【FinanceAccounts】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceAccountsSelectByPagerParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceAccountsSelectByPagerParams]
GO
--参数说明
-------------------------------------------------------------
/*
@pageSize 每页显示的数量
@pageIndex ǰ当前显示第几页
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[FinanceAccountsSelectByPagerParams]
@pageSize int = 10,
@pageIndex int = 1,
@where varchar(8000) = ' 1=1 ',
@sortField varchar(100) = ' [fiActId] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)	
	set @filter = '
		SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize) + ' * FROM [dbo].[FinanceAccounts]
		where [fiActId] not in (SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize * (@pageIndex - 1)) 
		+ ' [fiActId] FROM [dbo].[FinanceAccounts]
		WHERE ' + @where + ' ORDER BY ' + @sortField + ' ) AND ' + @where + ' ORDER BY ' + @sortField
	--print @filter 
	exec ( @filter )
	RETURN @@Error
GO

/********************通过系统编号查询数据表【FinanceAccounts】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceAccountsIsExist]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceAccountsIsExist]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@fiActId 
*/	
CREATE PROCEDURE [dbo].[FinanceAccountsIsExist]
@fiActId smallint
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[FinanceAccounts]
		where [fiActId] = @fiActId
	RETURN @@Error
GO



