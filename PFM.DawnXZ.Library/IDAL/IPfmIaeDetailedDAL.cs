// =================================================================== 
// 产品规则（PFM.DawnXZ.Library.IDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：IPfmIaeDetailedDAL.cs
// 项目名称：请更改为实际项目名称
// 创建时间：2012年08月06日 16:35:08
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
    /// 数据层PfmIaeDetailed接口
    /// </summary>
    public interface IPfmIaeDetailedDAL : SQLitePaging<PfmIaeDetailedMDL>
    {

        #region 基本方法

        #region 添加

        /// <summary>
        /// 向数据表PfmIaeDetailed中插入一条新记录
        /// </summary>
        /// <param name="pfmIaeDetailed">PfmIaeDetailed实体</param>
        /// <returns></returns>
        int Insert(PfmIaeDetailedMDL pfmIaeDetailed);

        #endregion

        #region 修改

        /// <summary>
        /// 向数据表PfmIaeDetailed修改一条记录
        /// </summary>
        /// <param name="pfmIaeDetailed">PfmIaeDetailed实体</param>
        /// <returns></returns>
        int Update(PfmIaeDetailedMDL pfmIaeDetailed);

        #endregion

        #region 删除

        /// <summary>
        /// 删除数据表PfmIaeDetailed中的一条记录
        /// </summary>
        /// <param name="detId"></param>
        /// <returns></returns>
        int Delete(long detId);

        /// <summary>
        /// 删除数据表PfmIaeDetailed中的一条记录
        /// </summary>
        /// <param name="pfmIaeDetailed">PfmIaeDetailed实体</param>
        /// <returns></returns>
        int Delete(PfmIaeDetailedMDL pfmIaeDetailed);

        #endregion

        #region 实体对象

        /// <summary>
        /// 通过DataRow创建一个PfmIaeDetailed实体
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>PfmIaeDetailed实体</returns>
        PfmIaeDetailedMDL Select(DataRow row);
        /// <summary>
        /// 得到PfmIaeDetailed数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>PfmIaeDetailed数据实体</returns>
        PfmIaeDetailedMDL Select(IDataReader dr);
        /// <summary>
        /// 根据ID,返回一个PfmIaeDetailed对象
        /// </summary>
        /// <param name="detId"></param>
        /// <returns>PfmIaeDetailed</returns>
        PfmIaeDetailedMDL Select(long detId);

        #endregion

        #region 查询

        #region List
        /// <summary>
        /// 得到数据表PfmIaeDetailed所有记录
        /// </summary>
        /// <returns>数据实体</returns>
        List<PfmIaeDetailedMDL> LSelect();
        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        List<PfmIaeDetailedMDL> LSelect(string where);
        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        List<PfmIaeDetailedMDL> LSelect(string where, string sortField);
        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        List<PfmIaeDetailedMDL> LSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param);
        #endregion List

        #region IList
        /// <summary>
        /// 得到数据表PfmIaeDetailed所有记录
        /// </summary>
        /// <returns>数据实体</returns>
        IList<PfmIaeDetailedMDL> ISelect();
        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        IList<PfmIaeDetailedMDL> ISelect(string where);
        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        IList<PfmIaeDetailedMDL> ISelect(string where, string sortField);
        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        IList<PfmIaeDetailedMDL> ISelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param);
        #endregion IList

        #region Collection
        /// <summary>
        /// 得到数据表PfmIaeDetailed所有记录
        /// </summary>
        /// <returns>数据实体</returns>
        Collection<PfmIaeDetailedMDL> CSelect();
        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        Collection<PfmIaeDetailedMDL> CSelect(string where);
        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        Collection<PfmIaeDetailedMDL> CSelect(string where, string sortField);
        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        Collection<PfmIaeDetailedMDL> CSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param);
        #endregion Collection

        #region ObservableCollection
        /// <summary>
        /// 得到数据表PfmIaeDetailed所有记录
        /// </summary>
        /// <returns>数据实体</returns>
        ObservableCollection<PfmIaeDetailedMDL> OSelect();
        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        ObservableCollection<PfmIaeDetailedMDL> OSelect(string where);
        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        ObservableCollection<PfmIaeDetailedMDL> OSelect(string where, string sortField);
        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        ObservableCollection<PfmIaeDetailedMDL> OSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param);
        #endregion ObservableCollection

        #region Report
        /// <summary>
        /// 报表数据检索
        /// </summary>
        /// <param name="begin">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        DataTable Report(DateTime begin, DateTime end);
        #endregion Report

        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件的记录数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="recordCount">记录数</param>
        void Select(string where, out int recordCount);
        /// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="detId"></param>
        /// <returns>存在/不存在</returns>
        bool Exists(long detId);
        /// <summary>
        /// 根据指定条件检测是否存在该条记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>存在/不存在</returns>
        bool Exists(string where);

        #endregion

        #endregion

    }
}
