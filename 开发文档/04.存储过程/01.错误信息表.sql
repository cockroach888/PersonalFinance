USE [PF]
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



