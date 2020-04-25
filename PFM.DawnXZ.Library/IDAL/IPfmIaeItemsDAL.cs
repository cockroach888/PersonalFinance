// =================================================================== 
// 产品规则（PFM.DawnXZ.Library.IDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：IPfmIaeItemsDAL.cs
// 项目名称：请更改为实际项目名称
// 创建时间：2012年08月06日 16:34:36
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
    /// 数据层PfmIaeItems接口
    /// </summary>
    public interface IPfmIaeItemsDAL : SQLitePaging<PfmIaeItemsMDL>
    {

        #region 基本方法

        #region 添加

        /// <summary>
        /// 向数据表PfmIaeItems中插入一条新记录
        /// </summary>
        /// <param name="pfmIaeItems">PfmIaeItems实体</param>
        /// <returns></returns>
        int Insert(PfmIaeItemsMDL pfmIaeItems);

        #endregion

        #region 修改

        /// <summary>
        /// 向数据表PfmIaeItems修改一条记录
        /// </summary>
        /// <param name="pfmIaeItems">PfmIaeItems实体</param>
        /// <returns></returns>
        int Update(PfmIaeItemsMDL pfmIaeItems);

        #endregion

        #region 删除

        /// <summary>
        /// 删除数据表PfmIaeItems中的一条记录
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        int Delete(long itemId);

        /// <summary>
        /// 删除数据表PfmIaeItems中的一条记录
        /// </summary>
        /// <param name="pfmIaeItems">PfmIaeItems实体</param>
        /// <returns></returns>
        int Delete(PfmIaeItemsMDL pfmIaeItems);

        #endregion

        #region 实体对象

        /// <summary>
        /// 通过DataRow创建一个PfmIaeItems实体
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>PfmIaeItems实体</returns>
        PfmIaeItemsMDL Select(DataRow row);
        /// <summary>
        /// 得到PfmIaeItems数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>PfmIaeItems数据实体</returns>
        PfmIaeItemsMDL Select(IDataReader dr);
        /// <summary>
        /// 根据ID,返回一个PfmIaeItems对象
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns>PfmIaeItems</returns>
        PfmIaeItemsMDL Select(long itemId);

        #endregion

        #region 查询

        #region List
        /// <summary>
        /// 得到数据表PfmIaeItems所有记录
        /// </summary>
        /// <returns>数据实体</returns>
        List<PfmIaeItemsMDL> LSelect();
        /// <summary>
        /// 得到数据表PfmIaeItems满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        List<PfmIaeItemsMDL> LSelect(string where);
        /// <summary>
        /// 得到数据表PfmIaeItems满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        List<PfmIaeItemsMDL> LSelect(string where, string sortField);
        /// <summary>
        /// 得到数据表PfmIaeItems满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        List<PfmIaeItemsMDL> LSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param);
        #endregion List

        #region IList
        /// <summary>
        /// 得到数据表PfmIaeItems所有记录
        /// </summary>
        /// <returns>数据实体</returns>
        IList<PfmIaeItemsMDL> ISelect();
        /// <summary>
        /// 得到数据表PfmIaeItems满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        IList<PfmIaeItemsMDL> ISelect(string where);
        /// <summary>
        /// 得到数据表PfmIaeItems满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        IList<PfmIaeItemsMDL> ISelect(string where, string sortField);
        /// <summary>
        /// 得到数据表PfmIaeItems满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        IList<PfmIaeItemsMDL> ISelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param);
        #endregion IList

        #region Collection
        /// <summary>
        /// 得到数据表PfmIaeItems所有记录
        /// </summary>
        /// <returns>数据实体</returns>
        Collection<PfmIaeItemsMDL> CSelect();
        /// <summary>
        /// 得到数据表PfmIaeItems满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        Collection<PfmIaeItemsMDL> CSelect(string where);
        /// <summary>
        /// 得到数据表PfmIaeItems满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        Collection<PfmIaeItemsMDL> CSelect(string where, string sortField);
        /// <summary>
        /// 得到数据表PfmIaeItems满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        Collection<PfmIaeItemsMDL> CSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param);
        #endregion Collection

        #region ObservableCollection
        /// <summary>
        /// 得到数据表PfmIaeItems所有记录
        /// </summary>
        /// <returns>数据实体</returns>
        ObservableCollection<PfmIaeItemsMDL> OSelect();
        /// <summary>
        /// 得到数据表PfmIaeItems满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        ObservableCollection<PfmIaeItemsMDL> OSelect(string where);
        /// <summary>
        /// 得到数据表PfmIaeItems满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        ObservableCollection<PfmIaeItemsMDL> OSelect(string where, string sortField);
        /// <summary>
        /// 得到数据表PfmIaeItems满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        ObservableCollection<PfmIaeItemsMDL> OSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param);
        #endregion ObservableCollection

        /// <summary>
        /// 得到数据表PfmIaeItems满足查询条件的记录数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="recordCount">记录数</param>
        void Select(string where, out int recordCount);
        /// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns>存在/不存在</returns>
        bool Exists(long itemId);
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
