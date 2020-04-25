// =================================================================== 
// 业务逻辑（PFM.DawnXZ.Library.BLL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：PfmAccountsBLL.cs
// 项目名称：请更改为实际项目名称
// 创建时间：2012年08月06日 16:45:20
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
    /// 业务逻辑层PfmAccounts
    /// </summary>
    public class PfmAccountsBLL
    {

        #region ---------变量定义-----------

        ///<summary>
        ///得到数据工厂
        ///</summary>
        private static readonly IPfmAccountsDAL _dal = DALFactory.PfmAccountsDALInstance();

        #endregion

        #region ----------构造函数----------

        /// <summary>
        /// 构造函数
        /// </summary>
        public PfmAccountsBLL()
        { }

        #endregion

        #region ---------函数定义-----------

        #region 添加

        /// <summary>
        /// 向数据表PfmAccounts中插入一条新记录
        /// </summary>
        /// <param name="pfmAccounts">PfmAccounts实体对象</param>
        /// <returns></returns>
        public static int Insert(PfmAccountsMDL pfmAccounts)
        {
            if (pfmAccounts == null)
                return 0;
            return PfmAccountsBLL._dal.Insert(pfmAccounts);
        }

        #endregion

        #region 修改

        /// <summary>
        /// 向数据表PfmAccounts修改一条记录
        /// </summary>
        /// <param name="pfmAccounts">PfmAccounts实体对象</param>
        /// <returns></returns>
        public static int Update(PfmAccountsMDL pfmAccounts)
        {
            if (pfmAccounts == null)
                return 0;
            return PfmAccountsBLL._dal.Update(pfmAccounts);
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除数据表PfmAccounts中的一条记录
        /// </summary>
        /// <param name="accId"></param>
        /// <returns></returns>
        public static int Delete(long accId)
        {
            if (accId < 0)
                return 0;
            return PfmAccountsBLL._dal.Delete(accId);
        }
        /// <summary>
        /// 删除数据表PfmAccounts中的一条记录
        /// </summary>
        /// <param name="pfmAccounts">PfmAccounts实体对象</param>
        /// <returns></returns>
        public static int Delete(PfmAccountsMDL pfmAccounts)
        {
            return PfmAccountsBLL._dal.Delete(pfmAccounts);
        }

        #endregion

        #region 数据实体

        /// <summary>
        /// 通过DataRow创建一个PfmAccounts实体对象
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>PfmAccounts实体对象</returns>
        public static PfmAccountsMDL Select(DataRow row)
        {
            return PfmAccountsBLL._dal.Select(row);
        }
        /// <summary>
        /// 通过DataReader创建一个PfmAccounts实体对象
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>PfmAccounts实体对象</returns>
        public static PfmAccountsMDL Select(IDataReader dr)
        {
            return PfmAccountsBLL._dal.Select(dr);
        }
        /// <summary>
        /// 根据ID,返回一个PfmAccounts实体对象
        /// </summary>
        /// <param name="accId"></param>
        /// <returns>PfmAccounts实体对象</returns>
        public static PfmAccountsMDL Select(long accId)
        {
            return PfmAccountsBLL._dal.Select(accId);
        }

        #endregion

        #region 查询

        #region List
        /// <summary>
        /// 得到数据表PfmAccounts所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public static List<PfmAccountsMDL> LSelect()
        {
            return PfmAccountsBLL._dal.LSelect();
        }/// <summary>
        /// 得到数据表PfmAccounts满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public static List<PfmAccountsMDL> LSelect(string where)
        {
            return PfmAccountsBLL._dal.LSelect(where);
        }
        /// <summary>
        /// 得到数据表PfmAccounts满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static List<PfmAccountsMDL> LSelect(string where, string sortField)
        {
            return PfmAccountsBLL._dal.LSelect(where, sortField);
        }
        /// <summary>
        /// 得到数据表PfmAccounts满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public static List<PfmAccountsMDL> LSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            return PfmAccountsBLL._dal.LSelect(commandType, sqlCommand, param);
        }
        #endregion List

        #region IList
        /// <summary>
        /// 得到数据表PfmAccounts所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public static IList<PfmAccountsMDL> ISelect()
        {
            return PfmAccountsBLL._dal.ISelect();
        }/// <summary>
        /// 得到数据表PfmAccounts满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public static IList<PfmAccountsMDL> ISelect(string where)
        {
            return PfmAccountsBLL._dal.ISelect(where);
        }
        /// <summary>
        /// 得到数据表PfmAccounts满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static IList<PfmAccountsMDL> ISelect(string where, string sortField)
        {
            return PfmAccountsBLL._dal.ISelect(where, sortField);
        }
        /// <summary>
        /// 得到数据表PfmAccounts满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public static IList<PfmAccountsMDL> ISelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            return PfmAccountsBLL._dal.ISelect(commandType, sqlCommand, param);
        }
        #endregion IList

        #region Collection
        /// <summary>
        /// 得到数据表PfmAccounts所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public static Collection<PfmAccountsMDL> CSelect()
        {
            return PfmAccountsBLL._dal.CSelect();
        }/// <summary>
        /// 得到数据表PfmAccounts满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public static Collection<PfmAccountsMDL> CSelect(string where)
        {
            return PfmAccountsBLL._dal.CSelect(where);
        }
        /// <summary>
        /// 得到数据表PfmAccounts满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static Collection<PfmAccountsMDL> CSelect(string where, string sortField)
        {
            return PfmAccountsBLL._dal.CSelect(where, sortField);
        }
        /// <summary>
        /// 得到数据表PfmAccounts满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public static Collection<PfmAccountsMDL> CSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            return PfmAccountsBLL._dal.CSelect(commandType, sqlCommand, param);
        }
        #endregion Collection

        #region ObservableCollection
        /// <summary>
        /// 得到数据表PfmAccounts所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public static ObservableCollection<PfmAccountsMDL> OSelect()
        {
            return PfmAccountsBLL._dal.OSelect();
        }/// <summary>
        /// 得到数据表PfmAccounts满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public static ObservableCollection<PfmAccountsMDL> OSelect(string where)
        {
            return PfmAccountsBLL._dal.OSelect(where);
        }
        /// <summary>
        /// 得到数据表PfmAccounts满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static ObservableCollection<PfmAccountsMDL> OSelect(string where, string sortField)
        {
            return PfmAccountsBLL._dal.OSelect(where, sortField);
        }
        /// <summary>
        /// 得到数据表PfmAccounts满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public static ObservableCollection<PfmAccountsMDL> OSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            return PfmAccountsBLL._dal.OSelect(commandType, sqlCommand, param);
        }
        #endregion ObservableCollection

        /// <summary>
        /// 得到数据表PfmAccounts满足查询条件的记录数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="recordCount">记录数</param>
        public static void Select(string where, out int recordCount)
        {
            PfmAccountsBLL._dal.Select(where, out recordCount);
        }
        /// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="accId"></param>
        /// <returns>存在/不存在</returns>
        public static bool Exists(long accId)
        {
            return PfmAccountsBLL._dal.Exists(accId);
        }
        /// <summary>
        /// 根据指定条件检测是否存在该条记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>存在/不存在</returns>
        public bool Exists(string where)
        {
            return PfmAccountsBLL._dal.Exists(where);
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
        public static List<PfmAccountsMDL> LSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return PfmAccountsBLL._dal.LSelectPaging(pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static List<PfmAccountsMDL> LSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmAccountsBLL._dal.LSelectPaging(strWhere, pageSize, currentIndex, out recordCount);
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
        public static List<PfmAccountsMDL> LSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmAccountsBLL._dal.LSelectPaging(strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static List<PfmAccountsMDL> LSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmAccountsBLL._dal.LSelectPaging(strColumns, strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static IList<PfmAccountsMDL> ISelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return PfmAccountsBLL._dal.ISelectPaging(pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static IList<PfmAccountsMDL> ISelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmAccountsBLL._dal.ISelectPaging(strWhere, pageSize, currentIndex, out recordCount);
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
        public static IList<PfmAccountsMDL> ISelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmAccountsBLL._dal.ISelectPaging(strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static IList<PfmAccountsMDL> ISelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmAccountsBLL._dal.ISelectPaging(strColumns, strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static Collection<PfmAccountsMDL> CSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return PfmAccountsBLL._dal.CSelectPaging(pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static Collection<PfmAccountsMDL> CSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmAccountsBLL._dal.CSelectPaging(strWhere, pageSize, currentIndex, out recordCount);
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
        public static Collection<PfmAccountsMDL> CSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmAccountsBLL._dal.CSelectPaging(strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static Collection<PfmAccountsMDL> CSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmAccountsBLL._dal.CSelectPaging(strColumns, strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static ObservableCollection<PfmAccountsMDL> OSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return PfmAccountsBLL._dal.OSelectPaging(pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static ObservableCollection<PfmAccountsMDL> OSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmAccountsBLL._dal.OSelectPaging(strWhere, pageSize, currentIndex, out recordCount);
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
        public static ObservableCollection<PfmAccountsMDL> OSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmAccountsBLL._dal.OSelectPaging(strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static ObservableCollection<PfmAccountsMDL> OSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmAccountsBLL._dal.OSelectPaging(strColumns, strWhere, strOrder, pageSize, currentIndex, out recordCount);
        }
        #endregion ObservableCollection

        #endregion 数据分页处理·SQLite

    }
}
