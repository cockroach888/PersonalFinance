// =================================================================== 
// 产品规则（PFM.DawnXZ.Library.IDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：IPfmReportDAL.cs
// 项目名称：请更改为实际项目名称
// 创建时间：2012年08月06日 16:33:21
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
    /// 数据层PfmReport接口
    /// </summary>
    public interface IPfmReportDAL : SQLitePaging<PfmReportMDL>
    {

        #region 基本方法

        #region 添加

        /// <summary>
        /// 向数据表PfmReport中插入一条新记录
        /// </summary>
        /// <param name="pfmReport">PfmReport实体</param>
        /// <returns></returns>
        int Insert(PfmReportMDL pfmReport);

        #endregion

        #region 修改

        /// <summary>
        /// 向数据表PfmReport修改一条记录
        /// </summary>
        /// <param name="pfmReport">PfmReport实体</param>
        /// <returns></returns>
        int Update(PfmReportMDL pfmReport);

        #endregion

        #region 删除

        /// <summary>
        /// 删除数据表PfmReport中的一条记录
        /// </summary>
        /// <param name="rptId"></param>
        /// <returns></returns>
        int Delete(long rptId);

        /// <summary>
        /// 删除数据表PfmReport中的一条记录
        /// </summary>
        /// <param name="pfmReport">PfmReport实体</param>
        /// <returns></returns>
        int Delete(PfmReportMDL pfmReport);

        #endregion

        #region 实体对象

        /// <summary>
        /// 通过DataRow创建一个PfmReport实体
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>PfmReport实体</returns>
        PfmReportMDL Select(DataRow row);
        /// <summary>
        /// 得到PfmReport数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>PfmReport数据实体</returns>
        PfmReportMDL Select(IDataReader dr);
        /// <summary>
        /// 根据ID,返回一个PfmReport对象
        /// </summary>
        /// <param name="rptId"></param>
        /// <returns>PfmReport</returns>
        PfmReportMDL Select(long rptId);

        #endregion

        #region 查询

        #region List
        /// <summary>
        /// 得到数据表PfmReport所有记录
        /// </summary>
        /// <returns>数据实体</returns>
        List<PfmReportMDL> LSelect();
        /// <summary>
        /// 得到数据表PfmReport满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        List<PfmReportMDL> LSelect(string where);
        /// <summary>
        /// 得到数据表PfmReport满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        List<PfmReportMDL> LSelect(string where, string sortField);
        /// <summary>
        /// 得到数据表PfmReport满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        List<PfmReportMDL> LSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param);
        #endregion List

        #region IList
        /// <summary>
        /// 得到数据表PfmReport所有记录
        /// </summary>
        /// <returns>数据实体</returns>
        IList<PfmReportMDL> ISelect();
        /// <summary>
        /// 得到数据表PfmReport满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        IList<PfmReportMDL> ISelect(string where);
        /// <summary>
        /// 得到数据表PfmReport满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        IList<PfmReportMDL> ISelect(string where, string sortField);
        /// <summary>
        /// 得到数据表PfmReport满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        IList<PfmReportMDL> ISelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param);
        #endregion IList

        #region Collection
        /// <summary>
        /// 得到数据表PfmReport所有记录
        /// </summary>
        /// <returns>数据实体</returns>
        Collection<PfmReportMDL> CSelect();
        /// <summary>
        /// 得到数据表PfmReport满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        Collection<PfmReportMDL> CSelect(string where);
        /// <summary>
        /// 得到数据表PfmReport满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        Collection<PfmReportMDL> CSelect(string where, string sortField);
        /// <summary>
        /// 得到数据表PfmReport满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        Collection<PfmReportMDL> CSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param);
        #endregion Collection

        #region ObservableCollection
        /// <summary>
        /// 得到数据表PfmReport所有记录
        /// </summary>
        /// <returns>数据实体</returns>
        ObservableCollection<PfmReportMDL> OSelect();
        /// <summary>
        /// 得到数据表PfmReport满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        ObservableCollection<PfmReportMDL> OSelect(string where);
        /// <summary>
        /// 得到数据表PfmReport满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        ObservableCollection<PfmReportMDL> OSelect(string where, string sortField);
        /// <summary>
        /// 得到数据表PfmReport满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        ObservableCollection<PfmReportMDL> OSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param);
        #endregion ObservableCollection

        /// <summary>
        /// 获取最大系统编号
        /// </summary>
        /// <returns></returns>
        int GetMaxId();
        /// <summary>
        /// 得到数据表PfmReport满足查询条件的记录数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="recordCount">记录数</param>
        void Select(string where, out int recordCount);
        /// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="rptId"></param>
        /// <returns>存在/不存在</returns>
        bool Exists(long rptId);
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
