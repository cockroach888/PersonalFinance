// =================================================================== 
// 业务逻辑（PFM.DawnXZ.Library.BLL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：PfmLogsBLL.cs
// 项目名称：请更改为实际项目名称
// 创建时间：2012年08月06日 16:20:55
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
    /// 业务逻辑层PfmLogs
    /// </summary>
    public class PfmLogsBLL
    {

        #region ---------变量定义-----------

        ///<summary>
        ///得到数据工厂
        ///</summary>
        private static readonly IPfmLogsDAL _dal = DALFactory.PfmLogsDALInstance();

        #endregion ---------变量定义-----------

        #region ----------构造函数----------

        /// <summary>
        /// 构造函数
        /// </summary>
        public PfmLogsBLL()
        { }

        #endregion ----------构造函数----------

        #region ---------函数定义-----------

        #region 添加

        /// <summary>
        /// 向数据表PfmLogs中插入一条新记录
        /// </summary>
        /// <param name="pfmLogs">PfmLogs实体对象</param>
        /// <returns></returns>
        public static int Insert(PfmLogsMDL pfmLogs)
        {
            if (pfmLogs == null)
                return 0;
            return PfmLogsBLL._dal.Insert(pfmLogs);
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除数据表PfmLogs中的一条记录
        /// </summary>
        /// <param name="logId"></param>
        /// <returns></returns>
        public static int Delete(long logId)
        {
            if (logId < 0)
                return 0;
            return PfmLogsBLL._dal.Delete(logId);
        }
        /// <summary>
        /// 删除数据表PfmLogs中的所有记录
        /// </summary>
        /// <returns></returns>
        public static int DeleteAll()
        {
            return PfmLogsBLL._dal.DeleteAll();
        }

        #endregion

        #region 实体对象

        /// <summary>
        /// 通过DataRow创建一个PfmLogs实体对象
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>PfmLogs实体对象</returns>
        public static PfmLogsMDL Select(DataRow row)
        {
            return PfmLogsBLL._dal.Select(row);
        }
        /// <summary>
        /// 通过DataReader创建一个PfmLogs实体对象
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>PfmLogs实体对象</returns>
        public static PfmLogsMDL Select(IDataReader dr)
        {
            return PfmLogsBLL._dal.Select(dr);
        }
        /// <summary>
        /// 根据ID,返回一个PfmLogs实体对象
        /// </summary>
        /// <param name="logId"></param>
        /// <returns>PfmLogs实体对象</returns>
        public static PfmLogsMDL Select(long logId)
        {
            return PfmLogsBLL._dal.Select(logId);
        }

        #endregion

        #region 查询

        #region List
        /// <summary>
        /// 得到数据表PfmLogs所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public static List<PfmLogsMDL> LSelect()
        {
            return PfmLogsBLL._dal.LSelect();
        }
        /// <summary>
        /// 得到数据表PfmLogs所有记录
        /// </summary>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static List<PfmLogsMDL> LSelect(string sortField)
        {
            return PfmLogsBLL._dal.LSelect(sortField);
        }
        /// <summary>
        /// 得到数据表PfmLogs满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static List<PfmLogsMDL> LSelect(string where, string sortField)
        {
            return PfmLogsBLL._dal.LSelect(where, sortField);
        }
        /// <summary>
        /// 得到数据表PfmLogs满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public static List<PfmLogsMDL> LSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            return PfmLogsBLL._dal.LSelect(commandType, sqlCommand, param);
        }
        #endregion List

        #region IList
        /// <summary>
        /// 得到数据表PfmLogs所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public static IList<PfmLogsMDL> ISelect()
        {
            return PfmLogsBLL._dal.ISelect();
        }
        /// <summary>
        /// 得到数据表PfmLogs所有记录
        /// </summary>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static IList<PfmLogsMDL> ISelect(string sortField)
        {
            return PfmLogsBLL._dal.ISelect(sortField);
        }
        /// <summary>
        /// 得到数据表PfmLogs满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static IList<PfmLogsMDL> ISelect(string where, string sortField)
        {
            return PfmLogsBLL._dal.ISelect(where, sortField);
        }
        /// <summary>
        /// 得到数据表PfmLogs满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public static IList<PfmLogsMDL> ISelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            return PfmLogsBLL._dal.ISelect(commandType, sqlCommand, param);
        }
        #endregion IList

        #region Collection
        /// <summary>
        /// 得到数据表PfmLogs所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public static Collection<PfmLogsMDL> CSelect()
        {
            return PfmLogsBLL._dal.CSelect();
        }
        /// <summary>
        /// 得到数据表PfmLogs所有记录
        /// </summary>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static Collection<PfmLogsMDL> CSelect(string sortField)
        {
            return PfmLogsBLL._dal.CSelect(sortField);
        }
        /// <summary>
        /// 得到数据表PfmLogs满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static Collection<PfmLogsMDL> CSelect(string where, string sortField)
        {
            return PfmLogsBLL._dal.CSelect(where, sortField);
        }
        /// <summary>
        /// 得到数据表PfmLogs满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public static Collection<PfmLogsMDL> CSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            return PfmLogsBLL._dal.CSelect(commandType, sqlCommand, param);
        }
        #endregion Collection

        #region ObservableCollection
        /// <summary>
        /// 得到数据表PfmLogs所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public static ObservableCollection<PfmLogsMDL> OSelect()
        {
            return PfmLogsBLL._dal.OSelect();
        }
        /// <summary>
        /// 得到数据表PfmLogs所有记录
        /// </summary>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static ObservableCollection<PfmLogsMDL> OSelect(string sortField)
        {
            return PfmLogsBLL._dal.OSelect(sortField);
        }
        /// <summary>
        /// 得到数据表PfmLogs满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static ObservableCollection<PfmLogsMDL> OSelect(string where, string sortField)
        {
            return PfmLogsBLL._dal.OSelect(where, sortField);
        }
        /// <summary>
        /// 得到数据表PfmLogs满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public static ObservableCollection<PfmLogsMDL> OSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            return PfmLogsBLL._dal.OSelect(commandType, sqlCommand, param);
        }
        #endregion ObservableCollection

        /// <summary>
        /// 得到数据表PfmLogs满足查询条件的记录数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="recordCount">记录数</param>
        public static void Select(string where, out int recordCount)
        {
            PfmLogsBLL._dal.Select(where, out recordCount);
        }
        /// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="logId"></param>
        /// <returns>存在/不存在</returns>
        public static bool Exists(long logId)
        {
            return PfmLogsBLL._dal.Exists(logId);
        }
        /// <summary>
        /// 根据指定条件检测是否存在该条记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>存在/不存在</returns>
        public bool Exists(string where)
        {
            return PfmLogsBLL._dal.Exists(where);
        }

        #endregion

        #endregion ---------函数定义-----------

        #region 数据分页处理·SQLite

        #region List
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static List<PfmLogsMDL> LSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return PfmLogsBLL._dal.LSelectPaging(pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static List<PfmLogsMDL> LSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmLogsBLL._dal.LSelectPaging(strWhere, pageSize, currentIndex, out recordCount);
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
        public static List<PfmLogsMDL> LSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmLogsBLL._dal.LSelectPaging(strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static List<PfmLogsMDL> LSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmLogsBLL._dal.LSelectPaging(strColumns, strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static IList<PfmLogsMDL> ISelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return PfmLogsBLL._dal.ISelectPaging(pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static IList<PfmLogsMDL> ISelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmLogsBLL._dal.ISelectPaging(strWhere, pageSize, currentIndex, out recordCount);
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
        public static IList<PfmLogsMDL> ISelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmLogsBLL._dal.ISelectPaging(strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static IList<PfmLogsMDL> ISelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmLogsBLL._dal.ISelectPaging(strColumns, strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static Collection<PfmLogsMDL> CSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return PfmLogsBLL._dal.CSelectPaging(pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static Collection<PfmLogsMDL> CSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmLogsBLL._dal.CSelectPaging(strWhere, pageSize, currentIndex, out recordCount);
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
        public static Collection<PfmLogsMDL> CSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmLogsBLL._dal.CSelectPaging(strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static Collection<PfmLogsMDL> CSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmLogsBLL._dal.CSelectPaging(strColumns, strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static ObservableCollection<PfmLogsMDL> OSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return PfmLogsBLL._dal.OSelectPaging(pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static ObservableCollection<PfmLogsMDL> OSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmLogsBLL._dal.OSelectPaging(strWhere, pageSize, currentIndex, out recordCount);
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
        public static ObservableCollection<PfmLogsMDL> OSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmLogsBLL._dal.OSelectPaging(strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static ObservableCollection<PfmLogsMDL> OSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmLogsBLL._dal.OSelectPaging(strColumns, strWhere, strOrder, pageSize, currentIndex, out recordCount);
        }
        #endregion ObservableCollection

        #endregion 数据分页处理·SQLite

    }
}
