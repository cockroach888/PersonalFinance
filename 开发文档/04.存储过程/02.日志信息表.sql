USE [PF]
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



