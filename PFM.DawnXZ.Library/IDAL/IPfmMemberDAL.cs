// =================================================================== 
// 产品规则（PFM.DawnXZ.Library.IDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：IPfmMemberDAL.cs
// 项目名称：请更改为实际项目名称
// 创建时间：2012年08月06日 16:33:59
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
    /// 数据层PfmMember接口
    /// </summary>
    public interface IPfmMemberDAL : SQLitePaging<PfmMemberMDL>
    {

        #region 基本方法

        #region 添加

        /// <summary>
        /// 向数据表PfmMember中插入一条新记录
        /// </summary>
        /// <param name="pfmMember">PfmMember实体</param>
        /// <returns></returns>
        int Insert(PfmMemberMDL pfmMember);

        #endregion

        #region 修改

        /// <summary>
        /// 向数据表PfmMember修改一条记录
        /// </summary>
        /// <param name="pfmMember">PfmMember实体</param>
        /// <returns></returns>
        int Update(PfmMemberMDL pfmMember);

        #endregion

        #region 删除

        /// <summary>
        /// 删除数据表PfmMember中的一条记录
        /// </summary>
        /// <param name="mbrId"></param>
        /// <returns></returns>
        int Delete(long mbrId);

        /// <summary>
        /// 删除数据表PfmMember中的一条记录
        /// </summary>
        /// <param name="pfmMember">PfmMember实体</param>
        /// <returns></returns>
        int Delete(PfmMemberMDL pfmMember);

        #endregion

        #region 实体对象

        /// <summary>
        /// 通过DataRow创建一个PfmMember实体
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>PfmMember实体</returns>
        PfmMemberMDL Select(DataRow row);
        /// <summary>
        /// 得到PfmMember数据实体
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>PfmMember数据实体</returns>
        PfmMemberMDL Select(IDataReader dr);
        /// <summary>
        /// 根据ID,返回一个PfmMember对象
        /// </summary>
        /// <param name="mbrId"></param>
        /// <returns>PfmMember</returns>
        PfmMemberMDL Select(long mbrId);

        #endregion

        #region 查询

        #region List
        /// <summary>
        /// 得到数据表PfmMember所有记录
        /// </summary>
        /// <returns>数据实体</returns>
        List<PfmMemberMDL> LSelect();
        /// <summary>
        /// 得到数据表PfmMember满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        List<PfmMemberMDL> LSelect(string where);
        /// <summary>
        /// 得到数据表PfmMember满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        List<PfmMemberMDL> LSelect(string where, string sortField);
        /// <summary>
        /// 得到数据表PfmMember满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        List<PfmMemberMDL> LSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param);
        #endregion List

        #region IList
        /// <summary>
        /// 得到数据表PfmMember所有记录
        /// </summary>
        /// <returns>数据实体</returns>
        IList<PfmMemberMDL> ISelect();
        /// <summary>
        /// 得到数据表PfmMember满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        IList<PfmMemberMDL> ISelect(string where);
        /// <summary>
        /// 得到数据表PfmMember满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        IList<PfmMemberMDL> ISelect(string where, string sortField);
        /// <summary>
        /// 得到数据表PfmMember满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        IList<PfmMemberMDL> ISelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param);
        #endregion IList

        #region Collection
        /// <summary>
        /// 得到数据表PfmMember所有记录
        /// </summary>
        /// <returns>数据实体</returns>
        Collection<PfmMemberMDL> CSelect();
        /// <summary>
        /// 得到数据表PfmMember满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        Collection<PfmMemberMDL> CSelect(string where);
        /// <summary>
        /// 得到数据表PfmMember满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        Collection<PfmMemberMDL> CSelect(string where, string sortField);
        /// <summary>
        /// 得到数据表PfmMember满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        Collection<PfmMemberMDL> CSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param);
        #endregion Collection

        #region ObservableCollection
        /// <summary>
        /// 得到数据表PfmMember所有记录
        /// </summary>
        /// <returns>数据实体</returns>
        ObservableCollection<PfmMemberMDL> OSelect();
        /// <summary>
        /// 得到数据表PfmMember满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        ObservableCollection<PfmMemberMDL> OSelect(string where);
        /// <summary>
        /// 得到数据表PfmMember满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        ObservableCollection<PfmMemberMDL> OSelect(string where, string sortField);
        /// <summary>
        /// 得到数据表PfmMember满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        ObservableCollection<PfmMemberMDL> OSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param);
        #endregion ObservableCollection

        /// <summary>
        /// 得到数据表PfmMember满足查询条件的记录数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="recordCount">记录数</param>
        void Select(string where, out int recordCount);
        /// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="mbrId"></param>
        /// <returns>存在/不存在</returns>
        bool Exists(long mbrId);
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
