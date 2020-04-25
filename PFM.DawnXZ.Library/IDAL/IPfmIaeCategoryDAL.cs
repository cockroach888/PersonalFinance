// =================================================================== 
// 产品规则（PFM.DawnXZ.Library.IDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：IPfmIaeCategoryDAL.cs
// 项目名称：请更改为实际项目名称
// 创建时间：2012年08月06日 16:29:37
// 创建人员：宋杰军
// 负 责 人：宋杰军
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using PFM.DawnXZ.Library.Entity;

namespace PFM.DawnXZ.Library.IDAL
{
    /// <summary>
    /// 数据层PfmIaeCategory接口
    /// </summary>
    public interface IPfmIaeCategoryDAL : SQLitePaging<PfmIaeCategoryMDL>
    {

        #region 基本方法

        #region GetMaxId
        /// <summary>
        /// 获取当前最大系统编号
        /// </summary>
        /// <returns></returns>
        int GetMaxId();
        #endregion

        #region 添加

        /// <summary>
        /// 向数据表PfmIaeCategory中插入一条新记录
        /// </summary>
        /// <param name="pfmIaeCategory">PfmIaeCategory实体对象</param>
        /// <param name="addFlag">添加标记：False  主分类，True 子分类</param>
        /// <returns></returns>
        int Insert(PfmIaeCategoryMDL pfmIaeCategory, bool addFlag);

        #endregion

        #region 修改

        /// <summary>
        /// 向数据表PfmIaeCategory修改一条记录
        /// </summary>
        /// <param name="pfmIaeCategory">PfmIaeCategory实体</param>
        /// <returns></returns>
        int Update(PfmIaeCategoryMDL pfmIaeCategory);

        #endregion

        #region 点击率

        /// <summary>
        /// 向数据表PfmIaeCategory更新点击率
        /// </summary>
        /// <param name="catId">系统编号</param>
        /// <returns></returns>
        int UpdateClick(int catId);

        #endregion

        #region 数据统计

        /// <summary>
        /// 向数据表PfmIaeCategory更新数据统计
        /// </summary>
        /// <param name="catId">系统编号</param>
        /// <param name="countFlag">数据统计标记：0添加，1删除</param>
        /// <returns></returns>
        int UpdateCounts(int catId, byte countFlag);

        #endregion

        #region 变更

        /// <summary>
        /// 向数据表PfmIaeCategory变更一条记录
        /// </summary>
        /// <param name="catId">系统编号</param>
        /// <param name="catFather">类别标识</param>
        /// <returns></returns>
        int Change(int catId, int catFather);

        #endregion

        #region 删除

        /// <summary>
        /// 删除数据表PfmIaeCategory中的一条记录
        /// </summary>
        /// <param name="catId">系统编号</param>
        /// <param name="delFlag">删除标记：False  删除指定，True 删除所有</param>
        /// <returns></returns>
        int Delete(int catId, bool delFlag);

        #endregion

        #region 实体对象

        /// <summary>
        /// 通过DataRow创建一个PfmIaeCategory实体
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>PfmIaeCategory实体</returns>
        PfmIaeCategoryMDL Select(DataRow row);
        /// <summary>
        /// 得到PfmIaeCategory数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>PfmIaeCategory数据实体</returns>
        PfmIaeCategoryMDL Select(IDataReader dr);
        /// <summary>
        /// 根据ID,返回一个PfmIaeCategory对象
        /// </summary>
        /// <param name="catId"></param>
        /// <returns>PfmIaeCategory</returns>
        PfmIaeCategoryMDL Select(int catId);

        #endregion

        #region 查询

        #region List
        /// <summary>
        /// 得到数据表PfmIaeCategory所有记录
        /// </summary>
        /// <returns>结果集</returns>
        List<PfmIaeCategoryMDL> LSelect();
        /// <summary>
        /// 得到数据表PfmIaeCategory所有父模块记录
        /// </summary>
        /// <returns>结果集</returns>
        List<PfmIaeCategoryMDL> LSelectFather();
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        List<PfmIaeCategoryMDL> LSelect(string where);
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        List<PfmIaeCategoryMDL> LSelect(string where, string sortField);
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        List<PfmIaeCategoryMDL> LSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param);
        #endregion List

        #region IList
        /// <summary>
        /// 得到数据表PfmIaeCategory所有记录
        /// </summary>
        /// <returns>结果集</returns>
        IList<PfmIaeCategoryMDL> ISelect();
        /// <summary>
        /// 得到数据表PfmIaeCategory所有父模块记录
        /// </summary>
        /// <returns>结果集</returns>
        IList<PfmIaeCategoryMDL> ISelectFather();
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        IList<PfmIaeCategoryMDL> ISelect(string where);
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        IList<PfmIaeCategoryMDL> ISelect(string where, string sortField);
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        IList<PfmIaeCategoryMDL> ISelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param);
        #endregion IList

        #region Collection
        /// <summary>
        /// 得到数据表PfmIaeCategory所有记录
        /// </summary>
        /// <returns>结果集</returns>
        Collection<PfmIaeCategoryMDL> CSelect();
        /// <summary>
        /// 得到数据表PfmIaeCategory所有父模块记录
        /// </summary>
        /// <returns>结果集</returns>
        Collection<PfmIaeCategoryMDL> CSelectFather();
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        Collection<PfmIaeCategoryMDL> CSelect(string where);
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        Collection<PfmIaeCategoryMDL> CSelect(string where, string sortField);
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        Collection<PfmIaeCategoryMDL> CSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param);
        #endregion Collection

        #region ObservableCollection
        /// <summary>
        /// 得到数据表PfmIaeCategory所有记录
        /// </summary>
        /// <returns>结果集</returns>
        ObservableCollection<PfmIaeCategoryMDL> OSelect();
        /// <summary>
        /// 得到数据表PfmIaeCategory所有父模块记录
        /// </summary>
        /// <returns>结果集</returns>
        ObservableCollection<PfmIaeCategoryMDL> OSelectFather();
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        ObservableCollection<PfmIaeCategoryMDL> OSelect(string where);
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        ObservableCollection<PfmIaeCategoryMDL> OSelect(string where, string sortField);
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        ObservableCollection<PfmIaeCategoryMDL> OSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param);
        #endregion ObservableCollection

        #region Recursive
        /// <summary>
        /// 递归数据表PfmIaeCategory所有记录
        /// </summary>
        /// <param name="mainMark">主制表符</param>
        /// <param name="childMark">子制表符</param>
        /// <returns>结果集</returns>
        IList<PfmIaeCategoryMDL> RecursiveI(string mainMark, string childMark);
        #endregion Recursive

        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件的记录数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="recordCount">记录数</param>
        void Select(string where, out int recordCount);

        #region Exists
        /// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="catId">系统编号</param>
        /// <returns>存在/不存在</returns>
        bool Exists(int catId);
        /// <summary>
        /// 根据类别名称检测是否存在该条记录
        /// </summary>
        /// <param name="catName"></param>
        /// <returns>存在/不存在</returns>
        bool Exists(string catName);
        /// <summary>
        /// 根据类别点击检测是否存在该条记录
        /// </summary>
        /// <param name="catClick"></param>
        /// <returns>存在/不存在</returns>
        bool ExistsClick(int catClick);
        /// <summary>
        /// 根据父标识检测是否存在该条记录
        /// </summary>
        /// <param name="catFather"></param>
        /// <returns>存在/不存在</returns>
        bool ExistsFather(int catFather);
        /// <summary>
        /// 根据类别名称和父标识检测是否存在该条记录
        /// </summary>
        /// <param name="catName"></param>
        /// <param name="catFather"></param>
        /// <returns>存在/不存在</returns>
        bool Exists(string catName, int catFather);
        #endregion Exists

        #endregion

        #endregion

    }
}
