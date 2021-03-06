USE [PF]
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



