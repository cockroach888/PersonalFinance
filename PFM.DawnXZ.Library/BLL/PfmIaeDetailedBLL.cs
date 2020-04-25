// =================================================================== 
// 业务逻辑（PFM.DawnXZ.Library.BLL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：PfmIaeDetailedBLL.cs
// 项目名称：请更改为实际项目名称
// 创建时间：2012年08月06日 16:44:06
// 创建人员：宋杰军
// 负 责 人：宋杰军
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
using System;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using PFM.DawnXZ.Library.Entity;
using PFM.DawnXZ.Library.IDAL;
using PFM.DawnXZ.Library.DBFactory;

namespace PFM.DawnXZ.Library.BLL
{
    /// <summary>
    /// 业务逻辑层PfmIaeDetailed
    /// </summary>
    public class PfmIaeDetailedBLL
    {

        #region ---------变量定义-----------

        ///<summary>
        ///得到数据工厂
        ///</summary>
        private static readonly IPfmIaeDetailedDAL _dal = DALFactory.PfmIaeDetailedDALInstance();

        #endregion

        #region ----------构造函数----------

        /// <summary>
        /// 构造函数
        /// </summary>
        public PfmIaeDetailedBLL()
        { }

        #endregion

        #region ---------函数定义-----------

        #region 添加

        /// <summary>
        /// 向数据表PfmIaeDetailed中插入一条新记录
        /// </summary>
        /// <param name="pfmIaeDetailed">PfmIaeDetailed实体对象</param>
        /// <returns></returns>
        public static int Insert(PfmIaeDetailedMDL pfmIaeDetailed)
        {
            if (pfmIaeDetailed == null)
                return 0;
            return PfmIaeDetailedBLL._dal.Insert(pfmIaeDetailed);
        }

        #endregion

        #region 修改

        /// <summary>
        /// 向数据表PfmIaeDetailed修改一条记录
        /// </summary>
        /// <param name="pfmIaeDetailed">PfmIaeDetailed实体对象</param>
        /// <returns></returns>
        public static int Update(PfmIaeDetailedMDL pfmIaeDetailed)
        {
            if (pfmIaeDetailed == null)
                return 0;
            return PfmIaeDetailedBLL._dal.Update(pfmIaeDetailed);
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除数据表PfmIaeDetailed中的一条记录
        /// </summary>
        /// <param name="detId"></param>
        /// <returns></returns>
        public static int Delete(long detId)
        {
            if (detId < 0)
                return 0;
            return PfmIaeDetailedBLL._dal.Delete(detId);
        }
        /// <summary>
        /// 删除数据表PfmIaeDetailed中的一条记录
        /// </summary>
        /// <param name="pfmIaeDetailed">PfmIaeDetailed实体对象</param>
        /// <returns></returns>
        public static int Delete(PfmIaeDetailedMDL pfmIaeDetailed)
        {
            return PfmIaeDetailedBLL._dal.Delete(pfmIaeDetailed);
        }

        #endregion

        #region 数据实体

        /// <summary>
        /// 通过DataRow创建一个PfmIaeDetailed实体对象
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>PfmIaeDetailed实体对象</returns>
        public static PfmIaeDetailedMDL Select(DataRow row)
        {
            return PfmIaeDetailedBLL._dal.Select(row);
        }
        /// <summary>
        /// 通过DataReader创建一个PfmIaeDetailed实体对象
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>PfmIaeDetailed实体对象</returns>
        public static PfmIaeDetailedMDL Select(IDataReader dr)
        {
            return PfmIaeDetailedBLL._dal.Select(dr);
        }
        /// <summary>
        /// 根据ID,返回一个PfmIaeDetailed实体对象
        /// </summary>
        /// <param name="detId"></param>
        /// <returns>PfmIaeDetailed实体对象</returns>
        public static PfmIaeDetailedMDL Select(long detId)
        {
            return PfmIaeDetailedBLL._dal.Select(detId);
        }

        #endregion

        #region 查询

        #region List
        /// <summary>
        /// 得到数据表PfmIaeDetailed所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public static List<PfmIaeDetailedMDL> LSelect()
        {
            return PfmIaeDetailedBLL._dal.LSelect();
        }/// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public static List<PfmIaeDetailedMDL> LSelect(string where)
        {
            return PfmIaeDetailedBLL._dal.LSelect(where);
        }
        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static List<PfmIaeDetailedMDL> LSelect(string where, string sortField)
        {
            return PfmIaeDetailedBLL._dal.LSelect(where, sortField);
        }
        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public static List<PfmIaeDetailedMDL> LSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            return PfmIaeDetailedBLL._dal.LSelect(commandType, sqlCommand, param);
        }
        #endregion List

        #region IList
        /// <summary>
        /// 得到数据表PfmIaeDetailed所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public static IList<PfmIaeDetailedMDL> ISelect()
        {
            return PfmIaeDetailedBLL._dal.ISelect();
        }/// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public static IList<PfmIaeDetailedMDL> ISelect(string where)
        {
            return PfmIaeDetailedBLL._dal.ISelect(where);
        }
        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static IList<PfmIaeDetailedMDL> ISelect(string where, string sortField)
        {
            return PfmIaeDetailedBLL._dal.ISelect(where, sortField);
        }
        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public static IList<PfmIaeDetailedMDL> ISelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            return PfmIaeDetailedBLL._dal.ISelect(commandType, sqlCommand, param);
        }
        #endregion IList

        #region Collection
        /// <summary>
        /// 得到数据表PfmIaeDetailed所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public static Collection<PfmIaeDetailedMDL> CSelect()
        {
            return PfmIaeDetailedBLL._dal.CSelect();
        }/// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public static Collection<PfmIaeDetailedMDL> CSelect(string where)
        {
            return PfmIaeDetailedBLL._dal.CSelect(where);
        }
        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static Collection<PfmIaeDetailedMDL> CSelect(string where, string sortField)
        {
            return PfmIaeDetailedBLL._dal.CSelect(where, sortField);
        }
        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public static Collection<PfmIaeDetailedMDL> CSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            return PfmIaeDetailedBLL._dal.CSelect(commandType, sqlCommand, param);
        }
        #endregion Collection

        #region ObservableCollection
        /// <summary>
        /// 得到数据表PfmIaeDetailed所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public static ObservableCollection<PfmIaeDetailedMDL> OSelect()
        {
            return PfmIaeDetailedBLL._dal.OSelect();
        }/// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public static ObservableCollection<PfmIaeDetailedMDL> OSelect(string where)
        {
            return PfmIaeDetailedBLL._dal.OSelect(where);
        }
        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static ObservableCollection<PfmIaeDetailedMDL> OSelect(string where, string sortField)
        {
            return PfmIaeDetailedBLL._dal.OSelect(where, sortField);
        }
        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public static ObservableCollection<PfmIaeDetailedMDL> OSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            return PfmIaeDetailedBLL._dal.OSelect(commandType, sqlCommand, param);
        }
        #endregion ObservableCollection

        #region Report
        /// <summary>
        /// 报表数据检索
        /// </summary>
        /// <param name="begin">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public static DataTable Report(DateTime begin, DateTime end)
        {
            return PfmIaeDetailedBLL._dal.Report(begin, end);
        }
        #endregion Report

        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件的记录数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="recordCount">记录数</param>
        public static void Select(string where, out int recordCount)
        {
            PfmIaeDetailedBLL._dal.Select(where, out recordCount);
        }
        /// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="detId"></param>
        /// <returns>存在/不存在</returns>
        public static bool Exists(long detId)
        {
            return PfmIaeDetailedBLL._dal.Exists(detId);
        }
        /// <summary>
        /// 根据指定条件检测是否存在该条记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>存在/不存在</returns>
        public bool Exists(string where)
        {
            return PfmIaeDetailedBLL._dal.Exists(where);
        }

        #endregion

        #endregion

        #region 数据分页处理·SQLite

        #region List
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static List<PfmIaeDetailedMDL> LSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeDetailedBLL._dal.LSelectPaging(pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static List<PfmIaeDetailedMDL> LSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeDetailedBLL._dal.LSelectPaging(strWhere, pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="strOrder">排序字段</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static List<PfmIaeDetailedMDL> LSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeDetailedBLL._dal.LSelectPaging(strWhere, strOrder, pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strColumns">查询字段</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="strOrder">排序字段</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static List<PfmIaeDetailedMDL> LSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeDetailedBLL._dal.LSelectPaging(strColumns, strWhere, strOrder, pageSize, currentIndex, out recordCount);
        }
        #endregion List

        #region IList
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static IList<PfmIaeDetailedMDL> ISelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeDetailedBLL._dal.ISelectPaging(pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static IList<PfmIaeDetailedMDL> ISelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeDetailedBLL._dal.ISelectPaging(strWhere, pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="strOrder">排序字段</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static IList<PfmIaeDetailedMDL> ISelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeDetailedBLL._dal.ISelectPaging(strWhere, strOrder, pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strColumns">查询字段</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="strOrder">排序字段</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static IList<PfmIaeDetailedMDL> ISelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeDetailedBLL._dal.ISelectPaging(strColumns, strWhere, strOrder, pageSize, currentIndex, out recordCount);
        }
        #endregion IList

        #region Collection
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static Collection<PfmIaeDetailedMDL> CSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeDetailedBLL._dal.CSelectPaging(pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static Collection<PfmIaeDetailedMDL> CSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeDetailedBLL._dal.CSelectPaging(strWhere, pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="strOrder">排序字段</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static Collection<PfmIaeDetailedMDL> CSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeDetailedBLL._dal.CSelectPaging(strWhere, strOrder, pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strColumns">查询字段</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="strOrder">排序字段</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static Collection<PfmIaeDetailedMDL> CSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeDetailedBLL._dal.CSelectPaging(strColumns, strWhere, strOrder, pageSize, currentIndex, out recordCount);
        }
        #endregion Collection

        #region ObservableCollection
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static ObservableCollection<PfmIaeDetailedMDL> OSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeDetailedBLL._dal.OSelectPaging(pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static ObservableCollection<PfmIaeDetailedMDL> OSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeDetailedBLL._dal.OSelectPaging(strWhere, pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="strOrder">排序字段</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static ObservableCollection<PfmIaeDetailedMDL> OSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeDetailedBLL._dal.OSelectPaging(strWhere, strOrder, pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strColumns">查询字段</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="strOrder">排序字段</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static ObservableCollection<PfmIaeDetailedMDL> OSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeDetailedBLL._dal.OSelectPaging(strColumns, strWhere, strOrder, pageSize, currentIndex, out recordCount);
        }
        #endregion ObservableCollection

        #endregion 数据分页处理·SQLite

    }
}
