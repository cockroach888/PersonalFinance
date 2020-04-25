// =================================================================== 
// 业务逻辑（PFM.DawnXZ.Library.BLL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：PfmReportRecordBLL.cs
// 项目名称：请更改为实际项目名称
// 创建时间：2012年08月06日 16:37:06
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
    /// 业务逻辑层PfmReportRecord
    /// </summary>
    public class PfmReportRecordBLL
    {

        #region ---------变量定义-----------

        ///<summary>
        ///得到数据工厂
        ///</summary>
        private static readonly IPfmReportRecordDAL _dal = DALFactory.PfmReportRecordDALInstance();

        #endregion

        #region ----------构造函数----------

        /// <summary>
        /// 构造函数
        /// </summary>
        public PfmReportRecordBLL()
        { }

        #endregion

        #region ---------函数定义-----------

        #region 添加

        /// <summary>
        /// 向数据表PfmReportRecord中插入一条新记录
        /// </summary>
        /// <param name="pfmReportRecord">PfmReportRecord实体对象</param>
        /// <returns></returns>
        public static int Insert(PfmReportRecordMDL pfmReportRecord)
        {
            if (pfmReportRecord == null)
                return 0;
            return PfmReportRecordBLL._dal.Insert(pfmReportRecord);
        }

        #endregion

        #region 修改

        /// <summary>
        /// 向数据表PfmReportRecord修改一条记录
        /// </summary>
        /// <param name="pfmReportRecord">PfmReportRecord实体对象</param>
        /// <returns></returns>
        public static int Update(PfmReportRecordMDL pfmReportRecord)
        {
            if (pfmReportRecord == null)
                return 0;
            return PfmReportRecordBLL._dal.Update(pfmReportRecord);
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除数据表PfmReportRecord中的一条记录
        /// </summary>
        /// <param name="rrdId"></param>
        /// <returns></returns>
        public static int Delete(long rrdId)
        {
            if (rrdId < 0)
                return 0;
            return PfmReportRecordBLL._dal.Delete(rrdId);
        }
        /// <summary>
        /// 删除数据表PfmReportRecord中的条件记录
        /// </summary>
        /// <param name="rptId"></param>
        /// <returns></returns>
        public static int DeleteAll(long rptId)
        {
            if (rptId < 0) return 0;
            return PfmReportRecordBLL._dal.DeleteAll(rptId);
        }
        /// <summary>
        /// 删除数据表PfmReportRecord中的一条记录
        /// </summary>
        /// <param name="pfmReportRecord">PfmReportRecord实体对象</param>
        /// <returns></returns>
        public static int Delete(PfmReportRecordMDL pfmReportRecord)
        {
            return PfmReportRecordBLL._dal.Delete(pfmReportRecord);
        }

        #endregion

        #region 数据实体

        /// <summary>
        /// 通过DataRow创建一个PfmReportRecord实体对象
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>PfmReportRecord实体对象</returns>
        public static PfmReportRecordMDL Select(DataRow row)
        {
            return PfmReportRecordBLL._dal.Select(row);
        }
        /// <summary>
        /// 通过DataReader创建一个PfmReportRecord实体对象
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>PfmReportRecord实体对象</returns>
        public static PfmReportRecordMDL Select(IDataReader dr)
        {
            return PfmReportRecordBLL._dal.Select(dr);
        }
        /// <summary>
        /// 根据ID,返回一个PfmReportRecord实体对象
        /// </summary>
        /// <param name="rrdId"></param>
        /// <returns>PfmReportRecord实体对象</returns>
        public static PfmReportRecordMDL Select(long rrdId)
        {
            return PfmReportRecordBLL._dal.Select(rrdId);
        }

        #endregion

        #region 查询

        #region List
        /// <summary>
        /// 得到数据表PfmReportRecord所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public static List<PfmReportRecordMDL> LSelect()
        {
            return PfmReportRecordBLL._dal.LSelect();
        }/// <summary>
        /// 得到数据表PfmReportRecord满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public static List<PfmReportRecordMDL> LSelect(string where)
        {
            return PfmReportRecordBLL._dal.LSelect(where);
        }
        /// <summary>
        /// 得到数据表PfmReportRecord满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static List<PfmReportRecordMDL> LSelect(string where, string sortField)
        {
            return PfmReportRecordBLL._dal.LSelect(where, sortField);
        }
        /// <summary>
        /// 得到数据表PfmReportRecord满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public static List<PfmReportRecordMDL> LSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            return PfmReportRecordBLL._dal.LSelect(commandType, sqlCommand, param);
        }
        #endregion List

        #region IList
        /// <summary>
        /// 得到数据表PfmReportRecord所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public static IList<PfmReportRecordMDL> ISelect()
        {
            return PfmReportRecordBLL._dal.ISelect();
        }/// <summary>
        /// 得到数据表PfmReportRecord满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public static IList<PfmReportRecordMDL> ISelect(string where)
        {
            return PfmReportRecordBLL._dal.ISelect(where);
        }
        /// <summary>
        /// 得到数据表PfmReportRecord满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static IList<PfmReportRecordMDL> ISelect(string where, string sortField)
        {
            return PfmReportRecordBLL._dal.ISelect(where, sortField);
        }
        /// <summary>
        /// 得到数据表PfmReportRecord满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public static IList<PfmReportRecordMDL> ISelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            return PfmReportRecordBLL._dal.ISelect(commandType, sqlCommand, param);
        }
        #endregion IList

        #region Collection
        /// <summary>
        /// 得到数据表PfmReportRecord所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public static Collection<PfmReportRecordMDL> CSelect()
        {
            return PfmReportRecordBLL._dal.CSelect();
        }/// <summary>
        /// 得到数据表PfmReportRecord满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public static Collection<PfmReportRecordMDL> CSelect(string where)
        {
            return PfmReportRecordBLL._dal.CSelect(where);
        }
        /// <summary>
        /// 得到数据表PfmReportRecord满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static Collection<PfmReportRecordMDL> CSelect(string where, string sortField)
        {
            return PfmReportRecordBLL._dal.CSelect(where, sortField);
        }
        /// <summary>
        /// 得到数据表PfmReportRecord满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public static Collection<PfmReportRecordMDL> CSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            return PfmReportRecordBLL._dal.CSelect(commandType, sqlCommand, param);
        }
        #endregion Collection

        #region ObservableCollection
        /// <summary>
        /// 得到数据表PfmReportRecord所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public static ObservableCollection<PfmReportRecordMDL> OSelect()
        {
            return PfmReportRecordBLL._dal.OSelect();
        }/// <summary>
        /// 得到数据表PfmReportRecord满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public static ObservableCollection<PfmReportRecordMDL> OSelect(string where)
        {
            return PfmReportRecordBLL._dal.OSelect(where);
        }
        /// <summary>
        /// 得到数据表PfmReportRecord满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static ObservableCollection<PfmReportRecordMDL> OSelect(string where, string sortField)
        {
            return PfmReportRecordBLL._dal.OSelect(where, sortField);
        }
        /// <summary>
        /// 得到数据表PfmReportRecord满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public static ObservableCollection<PfmReportRecordMDL> OSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            return PfmReportRecordBLL._dal.OSelect(commandType, sqlCommand, param);
        }
        #endregion ObservableCollection

        /// <summary>
        /// 得到数据表PfmReportRecord满足查询条件的记录数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="recordCount">记录数</param>
        public static void Select(string where, out int recordCount)
        {
            PfmReportRecordBLL._dal.Select(where, out recordCount);
        }
        /// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="rrdId"></param>
        /// <returns>存在/不存在</returns>
        public static bool Exists(long rrdId)
        {
            return PfmReportRecordBLL._dal.Exists(rrdId);
        }
        /// <summary>
        /// 根据指定条件检测是否存在该条记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>存在/不存在</returns>
        public bool Exists(string where)
        {
            return PfmReportRecordBLL._dal.Exists(where);
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
        public static List<PfmReportRecordMDL> LSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportRecordBLL._dal.LSelectPaging(pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static List<PfmReportRecordMDL> LSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportRecordBLL._dal.LSelectPaging(strWhere, pageSize, currentIndex, out recordCount);
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
        public static List<PfmReportRecordMDL> LSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportRecordBLL._dal.LSelectPaging(strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static List<PfmReportRecordMDL> LSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportRecordBLL._dal.LSelectPaging(strColumns, strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static IList<PfmReportRecordMDL> ISelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportRecordBLL._dal.ISelectPaging(pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static IList<PfmReportRecordMDL> ISelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportRecordBLL._dal.ISelectPaging(strWhere, pageSize, currentIndex, out recordCount);
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
        public static IList<PfmReportRecordMDL> ISelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportRecordBLL._dal.ISelectPaging(strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static IList<PfmReportRecordMDL> ISelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportRecordBLL._dal.ISelectPaging(strColumns, strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static Collection<PfmReportRecordMDL> CSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportRecordBLL._dal.CSelectPaging(pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static Collection<PfmReportRecordMDL> CSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportRecordBLL._dal.CSelectPaging(strWhere, pageSize, currentIndex, out recordCount);
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
        public static Collection<PfmReportRecordMDL> CSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportRecordBLL._dal.CSelectPaging(strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static Collection<PfmReportRecordMDL> CSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportRecordBLL._dal.CSelectPaging(strColumns, strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static ObservableCollection<PfmReportRecordMDL> OSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportRecordBLL._dal.OSelectPaging(pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static ObservableCollection<PfmReportRecordMDL> OSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportRecordBLL._dal.OSelectPaging(strWhere, pageSize, currentIndex, out recordCount);
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
        public static ObservableCollection<PfmReportRecordMDL> OSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportRecordBLL._dal.OSelectPaging(strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static ObservableCollection<PfmReportRecordMDL> OSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportRecordBLL._dal.OSelectPaging(strColumns, strWhere, strOrder, pageSize, currentIndex, out recordCount);
        }
        #endregion ObservableCollection

        #endregion 数据分页处理·SQLite

    }
}
