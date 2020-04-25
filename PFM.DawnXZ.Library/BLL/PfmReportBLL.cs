// =================================================================== 
// 业务逻辑（PFM.DawnXZ.Library.BLL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：PfmReportBLL.cs
// 项目名称：请更改为实际项目名称
// 创建时间：2012年08月06日 16:41:59
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
    /// 业务逻辑层PfmReport
    /// </summary>
    public class PfmReportBLL
    {

        #region ---------变量定义-----------

        ///<summary>
        ///得到数据工厂
        ///</summary>
        private static readonly IPfmReportDAL _dal = DALFactory.PfmReportDALInstance();

        #endregion

        #region ----------构造函数----------

        /// <summary>
        /// 构造函数
        /// </summary>
        public PfmReportBLL()
        { }

        #endregion

        #region ---------函数定义-----------

        #region 添加

        /// <summary>
        /// 向数据表PfmReport中插入一条新记录
        /// </summary>
        /// <param name="pfmReport">PfmReport实体对象</param>
        /// <returns></returns>
        public static int Insert(PfmReportMDL pfmReport)
        {
            if (pfmReport == null)
                return 0;
            return PfmReportBLL._dal.Insert(pfmReport);
        }

        #endregion

        #region 修改

        /// <summary>
        /// 向数据表PfmReport修改一条记录
        /// </summary>
        /// <param name="pfmReport">PfmReport实体对象</param>
        /// <returns></returns>
        public static int Update(PfmReportMDL pfmReport)
        {
            if (pfmReport == null)
                return 0;
            return PfmReportBLL._dal.Update(pfmReport);
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除数据表PfmReport中的一条记录
        /// </summary>
        /// <param name="rptId"></param>
        /// <returns></returns>
        public static int Delete(long rptId)
        {
            if (rptId < 0)
                return 0;
            return PfmReportBLL._dal.Delete(rptId);
        }
        /// <summary>
        /// 删除数据表PfmReport中的一条记录
        /// </summary>
        /// <param name="pfmReport">PfmReport实体对象</param>
        /// <returns></returns>
        public static int Delete(PfmReportMDL pfmReport)
        {
            return PfmReportBLL._dal.Delete(pfmReport);
        }

        #endregion

        #region 数据实体

        /// <summary>
        /// 通过DataRow创建一个PfmReport实体对象
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>PfmReport实体对象</returns>
        public static PfmReportMDL Select(DataRow row)
        {
            return PfmReportBLL._dal.Select(row);
        }
        /// <summary>
        /// 通过DataReader创建一个PfmReport实体对象
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>PfmReport实体对象</returns>
        public static PfmReportMDL Select(IDataReader dr)
        {
            return PfmReportBLL._dal.Select(dr);
        }
        /// <summary>
        /// 根据ID,返回一个PfmReport实体对象
        /// </summary>
        /// <param name="rptId"></param>
        /// <returns>PfmReport实体对象</returns>
        public static PfmReportMDL Select(long rptId)
        {
            return PfmReportBLL._dal.Select(rptId);
        }

        #endregion

        #region 查询

        #region List
        /// <summary>
        /// 得到数据表PfmReport所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public static List<PfmReportMDL> LSelect()
        {
            return PfmReportBLL._dal.LSelect();
        }/// <summary>
        /// 得到数据表PfmReport满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public static List<PfmReportMDL> LSelect(string where)
        {
            return PfmReportBLL._dal.LSelect(where);
        }
        /// <summary>
        /// 得到数据表PfmReport满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static List<PfmReportMDL> LSelect(string where, string sortField)
        {
            return PfmReportBLL._dal.LSelect(where, sortField);
        }
        /// <summary>
        /// 得到数据表PfmReport满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public static List<PfmReportMDL> LSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            return PfmReportBLL._dal.LSelect(commandType, sqlCommand, param);
        }
        #endregion List

        #region IList
        /// <summary>
        /// 得到数据表PfmReport所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public static IList<PfmReportMDL> ISelect()
        {
            return PfmReportBLL._dal.ISelect();
        }/// <summary>
        /// 得到数据表PfmReport满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public static IList<PfmReportMDL> ISelect(string where)
        {
            return PfmReportBLL._dal.ISelect(where);
        }
        /// <summary>
        /// 得到数据表PfmReport满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static IList<PfmReportMDL> ISelect(string where, string sortField)
        {
            return PfmReportBLL._dal.ISelect(where, sortField);
        }
        /// <summary>
        /// 得到数据表PfmReport满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public static IList<PfmReportMDL> ISelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            return PfmReportBLL._dal.ISelect(commandType, sqlCommand, param);
        }
        #endregion IList

        #region Collection
        /// <summary>
        /// 得到数据表PfmReport所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public static Collection<PfmReportMDL> CSelect()
        {
            return PfmReportBLL._dal.CSelect();
        }/// <summary>
        /// 得到数据表PfmReport满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public static Collection<PfmReportMDL> CSelect(string where)
        {
            return PfmReportBLL._dal.CSelect(where);
        }
        /// <summary>
        /// 得到数据表PfmReport满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static Collection<PfmReportMDL> CSelect(string where, string sortField)
        {
            return PfmReportBLL._dal.CSelect(where, sortField);
        }
        /// <summary>
        /// 得到数据表PfmReport满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public static Collection<PfmReportMDL> CSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            return PfmReportBLL._dal.CSelect(commandType, sqlCommand, param);
        }
        #endregion Collection

        #region ObservableCollection
        /// <summary>
        /// 得到数据表PfmReport所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public static ObservableCollection<PfmReportMDL> OSelect()
        {
            return PfmReportBLL._dal.OSelect();
        }/// <summary>
        /// 得到数据表PfmReport满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public static ObservableCollection<PfmReportMDL> OSelect(string where)
        {
            return PfmReportBLL._dal.OSelect(where);
        }
        /// <summary>
        /// 得到数据表PfmReport满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static ObservableCollection<PfmReportMDL> OSelect(string where, string sortField)
        {
            return PfmReportBLL._dal.OSelect(where, sortField);
        }
        /// <summary>
        /// 得到数据表PfmReport满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public static ObservableCollection<PfmReportMDL> OSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            return PfmReportBLL._dal.OSelect(commandType, sqlCommand, param);
        }
        #endregion ObservableCollection

        /// <summary>
        /// 获取最大系统编号
        /// </summary>
        /// <returns></returns>
        public static int GetMaxId()
        {
            return PfmReportBLL._dal.GetMaxId();
        }
        /// <summary>
        /// 得到数据表PfmReport满足查询条件的记录数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="recordCount">记录数</param>
        public static void Select(string where, out int recordCount)
        {
            PfmReportBLL._dal.Select(where, out recordCount);
        }
        /// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="rptId"></param>
        /// <returns>存在/不存在</returns>
        public static bool Exists(long rptId)
        {
            return PfmReportBLL._dal.Exists(rptId);
        }
        /// <summary>
        /// 根据指定条件检测是否存在该条记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>存在/不存在</returns>
        public bool Exists(string where)
        {
            return PfmReportBLL._dal.Exists(where);
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
        public static List<PfmReportMDL> LSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportBLL._dal.LSelectPaging(pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static List<PfmReportMDL> LSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportBLL._dal.LSelectPaging(strWhere, pageSize, currentIndex, out recordCount);
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
        public static List<PfmReportMDL> LSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportBLL._dal.LSelectPaging(strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static List<PfmReportMDL> LSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportBLL._dal.LSelectPaging(strColumns, strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static IList<PfmReportMDL> ISelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportBLL._dal.ISelectPaging(pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static IList<PfmReportMDL> ISelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportBLL._dal.ISelectPaging(strWhere, pageSize, currentIndex, out recordCount);
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
        public static IList<PfmReportMDL> ISelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportBLL._dal.ISelectPaging(strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static IList<PfmReportMDL> ISelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportBLL._dal.ISelectPaging(strColumns, strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static Collection<PfmReportMDL> CSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportBLL._dal.CSelectPaging(pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static Collection<PfmReportMDL> CSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportBLL._dal.CSelectPaging(strWhere, pageSize, currentIndex, out recordCount);
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
        public static Collection<PfmReportMDL> CSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportBLL._dal.CSelectPaging(strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static Collection<PfmReportMDL> CSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportBLL._dal.CSelectPaging(strColumns, strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static ObservableCollection<PfmReportMDL> OSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportBLL._dal.OSelectPaging(pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static ObservableCollection<PfmReportMDL> OSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportBLL._dal.OSelectPaging(strWhere, pageSize, currentIndex, out recordCount);
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
        public static ObservableCollection<PfmReportMDL> OSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportBLL._dal.OSelectPaging(strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static ObservableCollection<PfmReportMDL> OSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmReportBLL._dal.OSelectPaging(strColumns, strWhere, strOrder, pageSize, currentIndex, out recordCount);
        }
        #endregion ObservableCollection

        #endregion 数据分页处理·SQLite

    }
}
