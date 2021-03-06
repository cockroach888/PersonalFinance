USE [PF]
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



