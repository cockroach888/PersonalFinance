USE [PF]
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



