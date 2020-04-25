// ======================================================================
// 产品规则（PFM.DawnXZ.Library.IDAL）项目
// ======================================================================
// 【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
// ======================================================================
// 文件名称：IPfmErrorDAL.cs
// 项目名称：请更改为实际项目名称
// 创建时间：2012年08月06日 16:15:25
// 创建人员：宋杰军
// 负 责 人：宋杰军
// ======================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ======================================================================
using System;
using System.Collections;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PFM.DawnXZ.Library.Entity;

namespace PFM.DawnXZ.Library.IDAL
{
    /// <summary>
    /// 数据层PfmError接口
    /// </summary>
    public interface IPfmErrorDAL : SQLitePaging<PfmErrorMDL>
    {

        #region 基本方法

        #region 添加

        /// <summary>
        /// 向数据表PfmError中插入一条新记录
        /// </summary>
        /// <param name="pfmError">PfmError实体</param>
        /// <returns></returns>
        int Insert(PfmErrorMDL pfmError);

        #endregion

        #region 删除

        /// <summary>
        /// 删除数据表PfmError中的一条记录
        /// </summary>
        /// <param name="errId">系统编号</param>
        /// <returns></returns>
        int Delete(long errId);

        /// <summary>
        /// 删除数据表PfmError中的所有记录
        /// </summary>
        /// <returns></returns>
        int DeleteAll();

        #endregion

        #region 实体对象

        /// <summary>
        /// 通过DataRow创建一个PfmError实体
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>PfmError数据实体</returns>
        PfmErrorMDL Select(DataRow row);
        /// <summary>
        /// 得到PfmError数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>PfmError数据实体</returns>
        PfmErrorMDL Select(IDataReader dr);
        /// <summary>
        /// 根据ID,返回一个PfmError对象
        /// </summary>
        /// <param name="errId">errId</param>
        /// <returns>PfmError数据实体</returns>
        PfmErrorMDL Select(long errId);

        #endregion

        #region 查询

        #region List
        /// <summary>
        /// 得到数据表PfmError所有记录
        /// </summary>
        /// <returns>数据实体</returns>
        List<PfmErrorMDL> LSelect();
        /// <summary>
        /// 得到数据表PfmError所有记录
        /// </summary>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        List<PfmErrorMDL> LSelect(string sortField);
        /// <summary>
        /// 得到数据表PfmError满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        List<PfmErrorMDL> LSelect(string where, string sortField);
        /// <summary>
        /// 得到数据表PfmError满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        List<PfmErrorMDL> LSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param);
        #endregion List

        #region IList
        /// <summary>
        /// 得到数据表PfmError所有记录
        /// </summary>
        /// <returns>数据实体</returns>
        IList<PfmErrorMDL> ISelect();
        /// <summary>
        /// 得到数据表PfmError所有记录
        /// </summary>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        IList<PfmErrorMDL> ISelect(string sortField);
        /// <summary>
        /// 得到数据表PfmError满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        IList<PfmErrorMDL> ISelect(string where, string sortField);
        /// <summary>
        /// 得到数据表PfmError满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        IList<PfmErrorMDL> ISelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param);
        #endregion IList

        #region Collection
        /// <summary>
        /// 得到数据表PfmError所有记录
        /// </summary>
        /// <returns>数据实体</returns>
        Collection<PfmErrorMDL> CSelect();
        /// <summary>
        /// 得到数据表PfmError所有记录
        /// </summary>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        Collection<PfmErrorMDL> CSelect(string sortField);
        /// <summary>
        /// 得到数据表PfmError满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        Collection<PfmErrorMDL> CSelect(string where, string sortField);
        /// <summary>
        /// 得到数据表PfmError满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        Collection<PfmErrorMDL> CSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param);
        #endregion Collection

        #region ObservableCollection
        /// <summary>
        /// 得到数据表PfmError所有记录
        /// </summary>
        /// <returns>数据实体</returns>
        ObservableCollection<PfmErrorMDL> OSelect();
        /// <summary>
        /// 得到数据表PfmError所有记录
        /// </summary>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        ObservableCollection<PfmErrorMDL> OSelect(string sortField);
        /// <summary>
        /// 得到数据表PfmError满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        ObservableCollection<PfmErrorMDL> OSelect(string where, string sortField);
        /// <summary>
        /// 得到数据表PfmError满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        ObservableCollection<PfmErrorMDL> OSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param);
        #endregion ObservableCollection

        /// <summary>
        /// 得到数据表PfmError满足查询条件的记录数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="recordCount">记录数</param>
        void Select(string where, out int recordCount);
        /// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="errId">系统编号</param>
        /// <returns>存在/不存在</returns>
        bool Exists(long errId);
        /// <summary>
        /// 根据指定条件检测是否存在该条记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>存在/不存在</returns>
        bool Exists(string where);

        #endregion

        #endregion 基本方法

    }
}
