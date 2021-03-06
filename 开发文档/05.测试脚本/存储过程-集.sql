USE [PersonalFinance]
GO

/******************************【错误信息表】******************************/

----------------------------------------------------------------------------------------------
----【模板作者：宋杰军】----【联系ＱＱ：6808240】----【创建时间：2011年02月10日 11:31:51】----
----------------------------------------------------------------------------------------------

/********************数据表【FinanceError】添加存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceErrorInsert]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceErrorInsert]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@errorId  系统编号
@errorDate  记录时间 
@errorPage  页面名称 
@errorMessage  错误信息 
@errortargetSite  错误目标 
@errorstackTrace  错误跟踪 
@errorSource  错误数据 
@errorIp  用户IP 
@errorName  操作用户 
@errorbkFd01  保留字段01 
@errorbkFd02  保留字段02 
@errorbkFd03  保留字段03 
*/	
CREATE PROCEDURE [dbo].[FinanceErrorInsert]
	@errorId int output,
    @errorDate datetime,
    @errorPage varchar(2000),
    @errorMessage varchar(4000),
    @errortargetSite varchar(max),
    @errorstackTrace nvarchar(max),
    @errorSource nvarchar(max),
    @errorIp varchar(300),
    @errorName varchar(20),
    @errorbkFd01 int,
    @errorbkFd02 tinyint,
    @errorbkFd03 varchar(max)
AS
	SET NOCOUNT ON
	insert into FinanceError
	(
		[errorDate],
		[errorPage],
		[errorMessage],
		[errortargetSite],
		[errorstackTrace],
		[errorSource],
		[errorIp],
		[errorName],
		[errorbkFd01],
		[errorbkFd02],
		[errorbkFd03]
	) 
	values
	(
		@errorDate,
		@errorPage,
		@errorMessage,
		@errortargetSite,
		@errorstackTrace,
		@errorSource,
		@errorIp,
		@errorName,
		@errorbkFd01,
		@errorbkFd02,
		@errorbkFd03
	)
	set @errorId=scope_identity()
	return @@error
GO

/********************数据表【FinanceError】删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceErrorDelete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceErrorDelete]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@errorId  系统编号
*/	
CREATE PROCEDURE [dbo].[FinanceErrorDelete]
	@errorId int
AS
	SET NOCOUNT ON
	delete from [FinanceError] where  [errorId] = @errorId
	return @@error
GO

/********************数据表【FinanceError】删除所有数据存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceErrorDeleteAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceErrorDeleteAll]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@errorId  系统编号
*/	
CREATE PROCEDURE [dbo].[FinanceErrorDeleteAll]
	
AS
	SET NOCOUNT ON
	delete from [FinanceError]
	return @@error
GO

/********************查询数据表【FinanceError】所有记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceErrorSelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceErrorSelectAll]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[FinanceErrorSelectAll]
@sortField varchar(100) = ' [errorId] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[FinanceError] order by '
	exec ( @filter + @sortField  )
	RETURN @@Error
go

/********************查询数据表【FinanceError】某一条记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceErrorSelect]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceErrorSelect]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@errorId 
*/	
CREATE PROCEDURE [dbo].[FinanceErrorSelect]
@errorId int
AS
	SET NOCOUNT ON
	SELECT * FROM [dbo].[FinanceError]
		where [errorId] = @errorId
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【FinanceError】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceErrorSelectByParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceErrorSelectByParams]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[FinanceErrorSelectByParams]
@where varchar(8000) = ' 1=1 ',
@sortField varchar(100) = ' [errorId] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[FinanceError]	where '
	exec ( @filter + @where + ' ORDER BY ' + @sortField )
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【FinanceError】记录数********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceErrorCountByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceErrorCountByWhere]
GO
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@recordCount 记录数
*/	
CREATE PROCEDURE [dbo].[FinanceErrorCountByWhere]
@where varchar(8000) = ' 1=1 ',
@recordCount int output
AS
	SET NOCOUNT ON
	declare @sqlCount nvarchar(4000)
	set @sqlCount= 'SELECT @Count=count(-1) FROM [dbo].[FinanceError] WHERE ' + @where
	--print @sqlCount 
	exec sp_executesql @sqlCount,N'@Count int output',@recordCount output  
	RETURN @@Error
GO

/********************通过指定的条件分页查询数据表【FinanceError】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceErrorSelectByPagerParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceErrorSelectByPagerParams]
GO
--参数说明
-------------------------------------------------------------
/*
@pageSize 每页显示的数量
@pageIndex ǰ当前显示第几页
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[FinanceErrorSelectByPagerParams]
@pageSize int = 10,
@pageIndex int = 1,
@where varchar(8000) = ' 1=1 ',
@sortField varchar(100) = ' [errorId] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)	
	set @filter = '
		SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize) + ' * FROM [dbo].[FinanceError]
		where [errorId] not in (SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize * (@pageIndex - 1)) 
		+ ' [errorId] FROM [dbo].[FinanceError]
		WHERE ' + @where + ' ORDER BY ' + @sortField + ' ) AND ' + @where + ' ORDER BY ' + @sortField
	--print @filter 
	exec ( @filter )
	RETURN @@Error
GO

/********************通过系统编号查询数据表【FinanceError】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceErrorIsExist]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceErrorIsExist]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@errorId 
*/	
CREATE PROCEDURE [dbo].[FinanceErrorIsExist]
@errorId int
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[FinanceError]
		where [errorId] = @errorId
	RETURN @@Error
GO



/******************************【日志信息表】******************************/

----------------------------------------------------------------------------------------------
----【模板作者：宋杰军】----【联系ＱＱ：6808240】----【创建时间：2011年02月10日 11:32:56】----
----------------------------------------------------------------------------------------------

/********************数据表【FinanceLog】添加存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceLogInsert]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceLogInsert]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@logId  系统编号
@logDate  记录时间 
@logTable  记录表名 
@logAction  记录动作 
@logRemark  记录备注 
@adminName  操作用户 
@logBkFd01  保留字段01 
@logBkFd02  保留字段02 
@logBkFd03  保留字段03 
*/	
CREATE PROCEDURE [dbo].[FinanceLogInsert]
	@logId int output,
    @logDate datetime,
    @logTable varchar(100),
    @logAction nvarchar(max),
    @logRemark nvarchar(max),
    @adminName varchar(20),
    @logBkFd01 int,
    @logBkFd02 tinyint,
    @logBkFd03 nvarchar(max)
AS
	SET NOCOUNT ON
	insert into FinanceLog
	(
		[logDate],
		[logTable],
		[logAction],
		[logRemark],
		[adminName],
		[logBkFd01],
		[logBkFd02],
		[logBkFd03]
	) 
	values
	(
		@logDate,
		@logTable,
		@logAction,
		@logRemark,
		@adminName,
		@logBkFd01,
		@logBkFd02,
		@logBkFd03
	)
	set @logId=scope_identity()
	return @@error
GO

/********************数据表【FinanceLog】删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceLogDelete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceLogDelete]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@logId  系统编号
*/	
CREATE PROCEDURE [dbo].[FinanceLogDelete]
	@logId int
AS
	SET NOCOUNT ON
	delete from [FinanceLog] where  [logId] = @logId
	return @@error
GO

/********************数据表【FinanceLog】删除所有数据存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceLogDeleteAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceLogDeleteAll]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@logId  系统编号
*/	
CREATE PROCEDURE [dbo].[FinanceLogDeleteAll]
	
AS
	SET NOCOUNT ON
	delete from [FinanceLog]
	return @@error
GO

/********************查询数据表【FinanceLog】所有记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceLogSelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceLogSelectAll]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[FinanceLogSelectAll]
@sortField varchar(100) = ' [logId] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[FinanceLog] order by '
	exec ( @filter + @sortField  )
	RETURN @@Error
go

/********************查询数据表【FinanceLog】某一条记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceLogSelect]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceLogSelect]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@logId 
*/	
CREATE PROCEDURE [dbo].[FinanceLogSelect]
@logId int
AS
	SET NOCOUNT ON
	SELECT * FROM [dbo].[FinanceLog]
		where [logId] = @logId
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【FinanceLog】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceLogSelectByParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceLogSelectByParams]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[FinanceLogSelectByParams]
@where varchar(8000) = ' 1=1 ',
@sortField varchar(100) = ' [logId] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[FinanceLog]	where '
	exec ( @filter + @where + ' ORDER BY ' + @sortField )
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【FinanceLog】记录数********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceLogCountByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceLogCountByWhere]
GO
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@recordCount 记录数
*/	
CREATE PROCEDURE [dbo].[FinanceLogCountByWhere]
@where varchar(8000) = ' 1=1 ',
@recordCount int output
AS
	SET NOCOUNT ON
	declare @sqlCount nvarchar(4000)
	set @sqlCount= 'SELECT @Count=count(-1) FROM [dbo].[FinanceLog] WHERE ' + @where
	--print @sqlCount 
	exec sp_executesql @sqlCount,N'@Count int output',@recordCount output  
	RETURN @@Error
GO

/********************通过指定的条件分页查询数据表【FinanceLog】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceLogSelectByPagerParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceLogSelectByPagerParams]
GO
--参数说明
-------------------------------------------------------------
/*
@pageSize 每页显示的数量
@pageIndex ǰ当前显示第几页
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[FinanceLogSelectByPagerParams]
@pageSize int = 10,
@pageIndex int = 1,
@where varchar(8000) = ' 1=1 ',
@sortField varchar(100) = ' [logId] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)	
	set @filter = '
		SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize) + ' * FROM [dbo].[FinanceLog]
		where [logId] not in (SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize * (@pageIndex - 1)) 
		+ ' [logId] FROM [dbo].[FinanceLog]
		WHERE ' + @where + ' ORDER BY ' + @sortField + ' ) AND ' + @where + ' ORDER BY ' + @sortField
	--print @filter 
	exec ( @filter )
	RETURN @@Error
GO

/********************通过系统编号查询数据表【FinanceLog】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceLogIsExist]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceLogIsExist]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@logId 
*/	
CREATE PROCEDURE [dbo].[FinanceLogIsExist]
@logId int
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[FinanceLog]
		where [logId] = @logId
	RETURN @@Error
GO



/******************************【帐务成员表】******************************/

----------------------------------------------------------------------------------------------
----【模板作者：宋杰军】----【联系ＱＱ：6808240】----【创建时间：2011年02月10日 11:38:20】----
----------------------------------------------------------------------------------------------

/********************数据表【FinanceMember】添加存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceMemberInsert]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceMemberInsert]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@fiMbrId  系统编号
@fiMbrRegDate  注册日期 
@fiMbrName  成员名称 
@fiMbrRelation  成员关系 
@fiMbrExplain  成员说明 
@fiMbrBkFd01  保留字段01 
@fiMbrBkFd02  保留字段02 
@fiMbrBkFd03  保留字段03 
*/	
CREATE PROCEDURE [dbo].[FinanceMemberInsert]
	@fiMbrId smallint output,
	@fiMbrRegDate datetime,
	@fiMbrName nvarchar(10),
	@fiMbrRelation nvarchar(50),
	@fiMbrExplain nvarchar(500),
	@fiMbrBkFd01 int,
	@fiMbrBkFd02 tinyint,
	@fiMbrBkFd03 varchar(50)
AS
	SET NOCOUNT ON
	insert into FinanceMember
	(
		[fiMbrRegDate],
		[fiMbrName],
		[fiMbrRelation],
		[fiMbrExplain],
		[fiMbrBkFd01],
		[fiMbrBkFd02],
		[fiMbrBkFd03]
	) 
	values
	(
		@fiMbrRegDate,
		@fiMbrName,
		@fiMbrRelation,
		@fiMbrExplain,
		@fiMbrBkFd01,
		@fiMbrBkFd02,
		@fiMbrBkFd03
	)
	set @fiMbrId=scope_identity()
	return @@error
GO

/********************数据表【FinanceMember】修改存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceMemberUpdate]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceMemberUpdate]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@fiMbrId  系统编号
@fiMbrRegDate  注册日期 
@fiMbrName  成员名称 
@fiMbrRelation  成员关系 
@fiMbrExplain  成员说明 
@fiMbrBkFd01  保留字段01 
@fiMbrBkFd02  保留字段02 
@fiMbrBkFd03  保留字段03 
*/	
CREATE PROCEDURE [dbo].[FinanceMemberUpdate]
	@fiMbrId smallint,
	@fiMbrRegDate datetime,
	@fiMbrName nvarchar(10),
	@fiMbrRelation nvarchar(50),
	@fiMbrExplain nvarchar(500),
	@fiMbrBkFd01 int,
	@fiMbrBkFd02 tinyint,
	@fiMbrBkFd03 varchar(50)
AS
 SET NOCOUNT ON
 UPDATE [FinanceMember] SET
		[fiMbrRegDate] = @fiMbrRegDate,
		[fiMbrName] = @fiMbrName,
		[fiMbrRelation] = @fiMbrRelation,
		[fiMbrExplain] = @fiMbrExplain,
		[fiMbrBkFd01] = @fiMbrBkFd01,
		[fiMbrBkFd02] = @fiMbrBkFd02,
		[fiMbrBkFd03] = @fiMbrBkFd03
 WHERE
		
		[fiMbrId] = @fiMbrId
	return @@error
GO

/********************数据表【FinanceMember】删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceMemberDelete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceMemberDelete]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@fiMbrId  系统编号
*/	
CREATE PROCEDURE [dbo].[FinanceMemberDelete]
	@fiMbrId smallint
AS
	SET NOCOUNT ON
	delete from [FinanceMember] where  [fiMbrId] = @fiMbrId
	return @@error
GO

/********************查询数据表【FinanceMember】所有记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceMemberSelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceMemberSelectAll]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[FinanceMemberSelectAll]
@sortField varchar(100) = ' [fiMbrId] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[FinanceMember] order by '
	exec ( @filter + @sortField  )
	RETURN @@Error
go

/********************查询数据表【FinanceMember】某一条记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceMemberSelect]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceMemberSelect]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@fiMbrId 
*/	
CREATE PROCEDURE [dbo].[FinanceMemberSelect]
@fiMbrId smallint
AS
	SET NOCOUNT ON
	SELECT * FROM [dbo].[FinanceMember]
		where [fiMbrId] = @fiMbrId
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【FinanceMember】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceMemberSelectByParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceMemberSelectByParams]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[FinanceMemberSelectByParams]
@where varchar(8000) = ' 1=1 ',
@sortField varchar(100) = ' [fiMbrId] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[FinanceMember]	where '
	exec ( @filter + @where + ' ORDER BY ' + @sortField )
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【FinanceMember】记录数********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceMemberCountByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceMemberCountByWhere]
GO
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@recordCount 记录数
*/	
CREATE PROCEDURE [dbo].[FinanceMemberCountByWhere]
@where varchar(8000) = ' 1=1 ',
@recordCount int output
AS
	SET NOCOUNT ON
	declare @sqlCount nvarchar(4000)
	set @sqlCount= 'SELECT @Count=count(-1) FROM [dbo].[FinanceMember] WHERE ' + @where
	--print @sqlCount 
	exec sp_executesql @sqlCount,N'@Count int output',@recordCount output  
	RETURN @@Error
GO

/********************通过指定的条件分页查询数据表【FinanceMember】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceMemberSelectByPagerParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceMemberSelectByPagerParams]
GO
--参数说明
-------------------------------------------------------------
/*
@pageSize 每页显示的数量
@pageIndex ǰ当前显示第几页
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[FinanceMemberSelectByPagerParams]
@pageSize int = 10,
@pageIndex int = 1,
@where varchar(8000) = ' 1=1 ',
@sortField varchar(100) = ' [fiMbrId] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)	
	set @filter = '
		SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize) + ' * FROM [dbo].[FinanceMember]
		where [fiMbrId] not in (SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize * (@pageIndex - 1)) 
		+ ' [fiMbrId] FROM [dbo].[FinanceMember]
		WHERE ' + @where + ' ORDER BY ' + @sortField + ' ) AND ' + @where + ' ORDER BY ' + @sortField
	--print @filter 
	exec ( @filter )
	RETURN @@Error
GO

/********************通过系统编号查询数据表【FinanceMember】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceMemberIsExist]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceMemberIsExist]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@fiMbrId 
*/	
CREATE PROCEDURE [dbo].[FinanceMemberIsExist]
@fiMbrId smallint
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[FinanceMember]
		where [fiMbrId] = @fiMbrId
	RETURN @@Error
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



/******************************【收支类别表】******************************/

----------------------------------------------------------------------------------------------
----【模板作者：宋杰军】----【联系ＱＱ：6808240】----【创建时间：2011年02月10日 11:35:47】----
----------------------------------------------------------------------------------------------

/********************数据表【FinanceCategory】添加存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceCategoryInsert]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceCategoryInsert]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@fiCatId  系统编号
@fiCatName  类别名称
@fiCatFather  类别标识
@fiCatClick  点击率
@fiCatCounts  数据统计
@fiCatDescribe  类别描述
@addFlag  添加标记
*/	
CREATE PROCEDURE [dbo].FinanceCategoryInsert
	@fiCatId int output,
	@fiCatName nvarchar(50),
	@fiCatFather int,
	@fiCatClick int,
	@fiCatCounts int,
	@fiCatDescribe nvarchar(300),
	@addFlag bit
AS
	SET NOCOUNT ON	
	--系统编号		
	DECLARE @objId varchar(10)
	set @objId=(select max(fiCatId)+1 from FinanceCategory)
	BEGIN
		if (SELECT count(-1) FROM FinanceCategory)=0
			set @fiCatId=1
		else
			set @fiCatId=@objId
	END
	--类别路径
	DECLARE @fiCatPath varchar(max)
	BEGIN
		if @addFlag=1
			set @fiCatPath=((select fiCatPath from FinanceCategory where fiCatId=@fiCatFather)+CONVERT(varchar(max),@fiCatId)+',')
		else
			set @fiCatPath=('0,'+CONVERT(varchar(max),@fiCatId)+',')
	END
	--开始执行
	insert into FinanceCategory
	(
		[fiCatId],
		[fiCatName],
		[fiCatFather],
		[fiCatPath],
		[fiCatClick],
		[fiCatCounts],
		[fiCatDescribe]
	) 
	values
	(
		@fiCatId,
		@fiCatName,
		@fiCatFather,
		@fiCatPath,
		@fiCatClick,
		@fiCatCounts,
		@fiCatDescribe
	)
	return @@error
GO

/********************数据表【FinanceCategory】修改存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceCategoryUpdate]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceCategoryUpdate]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@fiCatId  系统编号
@fiCatName  类别名称 
@fiCatClick  点击率 
@fiCatCounts  数据统计 
@fiCatDescribe  类别描述 
*/	
CREATE PROCEDURE [dbo].FinanceCategoryUpdate
	@fiCatId int,
	@fiCatName nvarchar(50),
	@fiCatClick int,
	@fiCatCounts int,
	@fiCatDescribe nvarchar(300)
AS
	SET NOCOUNT ON
	UPDATE [FinanceCategory] SET
		[fiCatName] = @fiCatName,
		[fiCatClick] = @fiCatClick,
		[fiCatCounts] = @fiCatCounts,
		[fiCatDescribe] = @fiCatDescribe
	WHERE
		[fiCatId] = @fiCatId
	return @@error
GO

/********************更新数据表【FinanceCategory】点击率********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceCategoryClick]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceCategoryClick]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@fiCatId  系统编号
*/	
CREATE PROCEDURE [dbo].FinanceCategoryClick
	@fiCatId int
AS
	SET NOCOUNT ON
	UPDATE [FinanceCategory] SET
		[fiCatClick] = [fiCatClick]+1
	WHERE
		[fiCatId] = @fiCatId
	return @@error
GO

/********************更新数据表【FinanceCategory】数据统计********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceCategoryCounts]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceCategoryCounts]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@fiCatId  系统编号
@countFlag  统计标记
*/	
CREATE PROCEDURE [dbo].FinanceCategoryCounts
	@fiCatId int,
	@countFlag tinyint
AS
	SET NOCOUNT ON
	BEGIN
		IF @countFlag=0
			UPDATE [FinanceCategory] SET
				[fiCatCounts] = [fiCatCounts]+1
			WHERE
				[fiCatId] = @fiCatId
		ELSE IF @countFlag=1
			UPDATE [FinanceCategory] SET
				[fiCatCounts] = [fiCatCounts]-1
			WHERE
				[fiCatId] = @fiCatId
	END	
	return @@error
GO

/********************数据表【FinanceCategory】变更存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceCategoryChange]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceCategoryChange]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@fiCatId  系统编号
@fiCatFather  类别标识 
*/	
CREATE PROCEDURE [dbo].FinanceCategoryChange
	@fiCatId int,
	@fiCatFather int
AS
	SET NOCOUNT ON
 	--类别路径
	DECLARE @fiCatPath varchar(max)
	BEGIN
		if @fiCatFather<>-1
			set @fiCatPath=((select fiCatPath from FinanceCategory where fiCatId=@fiCatFather)+CONVERT(varchar(max),@fiCatId)+',')
		else
			set @fiCatPath=('0,'+CONVERT(varchar(max),@fiCatId)+',')
	END
	--开始执行
	UPDATE [FinanceCategory] SET
		[fiCatFather] = @fiCatFather,
		[fiCatPath] = @fiCatPath
	WHERE
		[fiCatId] = @fiCatId
	return @@error
GO

/********************数据表【FinanceCategory】删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceCategoryDelete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceCategoryDelete]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@fiCatId  系统编号
@delFlag		删除标记
*/	
CREATE PROCEDURE [dbo].FinanceCategoryDelete
	@fiCatId int,
	@delFlag bit
AS
	SET NOCOUNT ON
	BEGIN
		IF @delFlag=1			
			DELETE FROM [FinanceCategory] WHERE charindex(','+CONVERT(varchar(max),@fiCatId)+',',fiCatPath)>0
		ELSE
			DELETE FROM [FinanceCategory] WHERE [fiCatId] = @fiCatId
	END
	return @@error
GO

/********************查询数据表【FinanceCategory】所有记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceCategorySelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceCategorySelectAll]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[FinanceCategorySelectAll]
@sortField varchar(100) = ' [fiCatId] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[FinanceCategory] order by '
	exec ( @filter + @sortField  )
	RETURN @@Error
go

/********************查询数据表【FinanceCategory】某一条记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceCategorySelect]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceCategorySelect]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@fiCatId 
*/	
CREATE PROCEDURE [dbo].[FinanceCategorySelect]
@fiCatId int
AS
	SET NOCOUNT ON
	SELECT * FROM [dbo].[FinanceCategory] where [fiCatId] = @fiCatId
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【FinanceCategory】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceCategorySelectByParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceCategorySelectByParams]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[FinanceCategorySelectByParams]
@where varchar(8000) = ' 1=1 ',
@sortField varchar(100) = ' [fiCatId] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[FinanceCategory]	where '
	exec ( @filter + @where + ' ORDER BY ' + @sortField )
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【FinanceCategory】记录数********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceCategoryCountByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceCategoryCountByWhere]
GO
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@recordCount 记录数
*/	
CREATE PROCEDURE [dbo].[FinanceCategoryCountByWhere]
@where varchar(8000) = ' 1=1 ',
@recordCount int output
AS
	SET NOCOUNT ON
	declare @sqlCount nvarchar(4000)
	set @sqlCount= 'SELECT @Count=count(-1) FROM [dbo].[FinanceCategory] WHERE ' + @where
	--print @sqlCount 
	exec sp_executesql @sqlCount,N'@Count int output',@recordCount output  
	RETURN @@Error
GO

/********************通过指定的条件分页查询数据表【FinanceCategory】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceCategorySelectByPagerParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceCategorySelectByPagerParams]
GO
--参数说明
-------------------------------------------------------------
/*
@pageSize 每页显示的数量
@pageIndex ǰ当前显示第几页
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[FinanceCategorySelectByPagerParams]
@pageSize int = 10,
@pageIndex int = 1,
@where varchar(8000) = ' 1=1 ',
@sortField varchar(100) = ' [fiCatId] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)	
	set @filter = '
		SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize) + ' * FROM [dbo].[FinanceCategory]
		where [fiCatId] not in (SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize * (@pageIndex - 1)) 
		+ ' [fiCatId] FROM [dbo].[FinanceCategory]
		WHERE ' + @where + ' ORDER BY ' + @sortField + ' ) AND ' + @where + ' ORDER BY ' + @sortField
	--print @filter 
	exec ( @filter )
	RETURN @@Error
GO

/********************通过系统编号查询数据表【FinanceCategory】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceCategoryIsExist]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceCategoryIsExist]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@fiCatId 
*/	
CREATE PROCEDURE [dbo].[FinanceCategoryIsExist]
@fiCatId int
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[FinanceCategory]
		where [fiCatId] = @fiCatId
	RETURN @@Error
GO



/******************************【收支明细表】******************************/

----------------------------------------------------------------------------------------------
----【模板作者：宋杰军】----【联系ＱＱ：6808240】----【创建时间：2011年02月10日 11:39:03】----
----------------------------------------------------------------------------------------------

/********************数据表【FinanceExpenditure】添加存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceExpenditureInsert]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceExpenditureInsert]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@fiExpId  系统编号
@fiMbrId  成员编号 
@fiActId  帐务编号 
@fiCatId  收支编号 
@fiExpDate  记录时间 
@fiExpName  收支名称 
@fiExpMoney  收支金额 
@fiExpAddress  收支地点 
@fiExpDescription  收支描述 
@fiExpRemark  收支备注 
@fiExpStatus  收支状态 
@fiExpEditDate  修改时间 
@fiExpEditCount  修改次数 
@fiExpBkFd01  保留字段01 
@fiExpBkFd02  保留字段02 
@fiExpBkFd03  保留字段03 
*/	
CREATE PROCEDURE [dbo].[FinanceExpenditureInsert]
	@fiExpId int output,
	@fiMbrId smallint,
	@fiActId smallint,
	@fiCatId int,
	@fiExpDate datetime,
	@fiExpName nvarchar(50),
	@fiExpMoney money,
	@fiExpAddress nvarchar(200),
	@fiExpDescription nvarchar(500),
	@fiExpRemark nvarchar(2000),
	@fiExpStatus tinyint,
	@fiExpEditDate datetime,
	@fiExpEditCount int,
	@fiExpBkFd01 int,
	@fiExpBkFd02 tinyint,
	@fiExpBkFd03 varchar(50)
AS
	SET NOCOUNT ON
	insert into FinanceExpenditure
	(
		[fiMbrId],
		[fiActId],
		[fiCatId],
		[fiExpDate],
		[fiExpName],
		[fiExpMoney],
		[fiExpAddress],
		[fiExpDescription],
		[fiExpRemark],
		[fiExpStatus],
		[fiExpEditDate],
		[fiExpEditCount],
		[fiExpBkFd01],
		[fiExpBkFd02],
		[fiExpBkFd03]
	) 
	values
	(
		@fiMbrId,
		@fiActId,
		@fiCatId,
		@fiExpDate,
		@fiExpName,
		@fiExpMoney,
		@fiExpAddress,
		@fiExpDescription,
		@fiExpRemark,
		@fiExpStatus,
		@fiExpEditDate,
		@fiExpEditCount,
		@fiExpBkFd01,
		@fiExpBkFd02,
		@fiExpBkFd03
	)
	set @fiExpId=scope_identity()
	return @@error
GO

/********************数据表【FinanceExpenditure】修改存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceExpenditureUpdate]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceExpenditureUpdate]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@fiExpId  系统编号
@fiMbrId  成员编号 
@fiActId  帐务编号 
@fiCatId  收支编号 
@fiExpDate  记录时间 
@fiExpName  收支名称 
@fiExpMoney  收支金额 
@fiExpAddress  收支地点 
@fiExpDescription  收支描述 
@fiExpRemark  收支备注 
@fiExpStatus  收支状态 
@fiExpEditDate  修改时间 
@fiExpEditCount  修改次数 
@fiExpBkFd01  保留字段01 
@fiExpBkFd02  保留字段02 
@fiExpBkFd03  保留字段03 
*/	
CREATE PROCEDURE [dbo].[FinanceExpenditureUpdate]
	@fiExpId int,
	@fiMbrId smallint,
	@fiActId smallint,
	@fiCatId int,
	@fiExpDate datetime,
	@fiExpName nvarchar(50),
	@fiExpMoney money,
	@fiExpAddress nvarchar(200),
	@fiExpDescription nvarchar(500),
	@fiExpRemark nvarchar(2000),
	@fiExpStatus tinyint,
	@fiExpEditDate datetime,
	@fiExpEditCount int,
	@fiExpBkFd01 int,
	@fiExpBkFd02 tinyint,
	@fiExpBkFd03 varchar(50)
AS
 SET NOCOUNT ON
 UPDATE [FinanceExpenditure] SET
		[fiMbrId] = @fiMbrId,
		[fiActId] = @fiActId,
		[fiCatId] = @fiCatId,
		[fiExpDate] = @fiExpDate,
		[fiExpName] = @fiExpName,
		[fiExpMoney] = @fiExpMoney,
		[fiExpAddress] = @fiExpAddress,
		[fiExpDescription] = @fiExpDescription,
		[fiExpRemark] = @fiExpRemark,
		[fiExpStatus] = @fiExpStatus,
		[fiExpEditDate] = @fiExpEditDate,
		[fiExpEditCount] = @fiExpEditCount,
		[fiExpBkFd01] = @fiExpBkFd01,
		[fiExpBkFd02] = @fiExpBkFd02,
		[fiExpBkFd03] = @fiExpBkFd03
 WHERE
		
		[fiExpId] = @fiExpId
	return @@error
GO

/********************数据表【FinanceExpenditure】删除存储过程********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceExpenditureDelete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceExpenditureDelete]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@fiExpId  系统编号
*/	
CREATE PROCEDURE [dbo].[FinanceExpenditureDelete]
	@fiExpId int
AS
	SET NOCOUNT ON
	delete from [FinanceExpenditure] where  [fiExpId] = @fiExpId
	return @@error
GO

/********************查询数据表【FinanceExpenditure】所有记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceExpenditureSelectAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceExpenditureSelectAll]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[FinanceExpenditureSelectAll]
@sortField varchar(100) = ' [fiExpId] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[FinanceExpenditure] order by '
	exec ( @filter + @sortField  )
	RETURN @@Error
go

/********************查询数据表【FinanceExpenditure】某一条记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceExpenditureSelect]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceExpenditureSelect]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@fiExpId 
*/	
CREATE PROCEDURE [dbo].[FinanceExpenditureSelect]
@fiExpId int
AS
	SET NOCOUNT ON
	SELECT * FROM [dbo].[FinanceExpenditure]
		where [fiExpId] = @fiExpId
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【FinanceExpenditure】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceExpenditureSelectByParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceExpenditureSelectByParams]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[FinanceExpenditureSelectByParams]
@where varchar(8000) = ' 1=1 ',
@sortField varchar(100) = ' [fiExpId] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)
	set @filter = 'SELECT * FROM [dbo].[FinanceExpenditure]	where '
	exec ( @filter + @where + ' ORDER BY ' + @sortField )
	RETURN @@Error
GO

/********************通过指定的条件查询数据表【FinanceExpenditure】记录数********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceExpenditureCountByWhere]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceExpenditureCountByWhere]
GO
--参数说明
-------------------------------------------------------------
/*
@where 查询条件
@recordCount 记录数
*/	
CREATE PROCEDURE [dbo].[FinanceExpenditureCountByWhere]
@where varchar(8000) = ' 1=1 ',
@recordCount int output
AS
	SET NOCOUNT ON
	declare @sqlCount nvarchar(4000)
	set @sqlCount= 'SELECT @Count=count(-1) FROM [dbo].[FinanceExpenditure] WHERE ' + @where
	--print @sqlCount 
	exec sp_executesql @sqlCount,N'@Count int output',@recordCount output  
	RETURN @@Error
GO

/********************通过指定的条件分页查询数据表【FinanceExpenditure】记录********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceExpenditureSelectByPagerParams]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceExpenditureSelectByPagerParams]
GO
--参数说明
-------------------------------------------------------------
/*
@pageSize 每页显示的数量
@pageIndex ǰ当前显示第几页
@where 查询条件
@sortField 排序字段
*/	
CREATE PROCEDURE [dbo].[FinanceExpenditureSelectByPagerParams]
@pageSize int = 10,
@pageIndex int = 1,
@where varchar(8000) = ' 1=1 ',
@sortField varchar(100) = ' [fiExpId] DESC '
AS
	SET NOCOUNT ON
	declare @filter varchar(8000)	
	set @filter = '
		SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize) + ' * FROM [dbo].[FinanceExpenditure]
		where [fiExpId] not in (SELECT TOP ' + CONVERT(VARCHAR(8),@pageSize * (@pageIndex - 1)) 
		+ ' [fiExpId] FROM [dbo].[FinanceExpenditure]
		WHERE ' + @where + ' ORDER BY ' + @sortField + ' ) AND ' + @where + ' ORDER BY ' + @sortField
	--print @filter 
	exec ( @filter )
	RETURN @@Error
GO

/********************通过系统编号查询数据表【FinanceExpenditure】记录是否存在********************/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[FinanceExpenditureIsExist]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[FinanceExpenditureIsExist]
GO
-------------------------------------------------------------
--参数说明
-------------------------------------------------------------
/*
@fiExpId 
*/	
CREATE PROCEDURE [dbo].[FinanceExpenditureIsExist]
@fiExpId int
AS
	SET NOCOUNT ON
	SELECT count(-1) FROM [dbo].[FinanceExpenditure]
		where [fiExpId] = @fiExpId
	RETURN @@Error
GO



