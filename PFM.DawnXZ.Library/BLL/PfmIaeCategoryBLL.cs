// =================================================================== 
// 业务逻辑（PFM.DawnXZ.Library.BLL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：PfmIaeCategoryBLL.cs
// 项目名称：请更改为实际项目名称
// 创建时间：2012年08月06日 16:30:18
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
    /// 业务逻辑层PfmIaeCategory
    /// </summary>
    public class PfmIaeCategoryBLL
    {

        #region ---------变量定义-----------

        ///<summary>
        ///得到数据工厂
        ///</summary>
        private static readonly IPfmIaeCategoryDAL _dal = DALFactory.PfmIaeCategoryDALInstance();

        #endregion

        #region ----------构造函数----------

        /// <summary>
        /// 构造函数
        /// </summary>
        public PfmIaeCategoryBLL()
        { }

        #endregion

        #region ---------函数定义-----------

        #region GetMaxId
        /// <summary>
        /// 获取当前最大系统编号
        /// </summary>
        /// <returns></returns>
        public static int GetMaxId()
        {
            return PfmIaeCategoryBLL._dal.GetMaxId();
        }
        #endregion

        #region 添加

        /// <summary>
        /// 向数据表PfmIaeCategory中插入一条新记录
        /// </summary>
        /// <param name="pfmIaeCategory">PfmIaeCategory实体对象</param>
        /// <param name="addFlag">添加标记：False  主分类，True 子分类</param>
        /// <returns></returns>
        public static int Insert(PfmIaeCategoryMDL pfmIaeCategory, bool addFlag)
        {
            if (pfmIaeCategory == null)
                return 0;
            return PfmIaeCategoryBLL._dal.Insert(pfmIaeCategory, addFlag);
        }

        #endregion

        #region 修改

        /// <summary>
        /// 向数据表PfmIaeCategory修改一条记录
        /// </summary>
        /// <param name="pfmIaeCategory">pfmIaeCategory实体对象</param>
        /// <returns></returns>
        public static int Update(PfmIaeCategoryMDL pfmIaeCategory)
        {
            if (pfmIaeCategory == null)
                return 0;
            return PfmIaeCategoryBLL._dal.Update(pfmIaeCategory);
        }

        #endregion

        #region 点击率

        /// <summary>
        /// 向数据表PfmIaeCategory更新点击率
        /// </summary>
        /// <param name="catId">系统编号</param>
        /// <returns></returns>
        public static int UpdateClick(int catId)
        {
            if (catId < 0)
                return 0;
            return PfmIaeCategoryBLL._dal.UpdateClick(catId);
        }

        #endregion

        #region 数据统计

        /// <summary>
        /// 向数据表PfmIaeCategory更新数据统计
        /// </summary>
        /// <param name="catId">系统编号</param>
        /// <param name="countFlag">数据统计标记：0添加，1删除</param>
        /// <returns></returns>
        public static int UpdateCounts(int catId, byte countFlag)
        {
            if (catId < 0)
                return 0;
            return PfmIaeCategoryBLL._dal.UpdateCounts(catId, countFlag);
        }

        #endregion

        #region 变更

        /// <summary>
        /// 向数据表PfmIaeCategory变更一条记录
        /// </summary>
        /// <param name="catId">系统编号</param>
        /// <param name="catFather">类别标识</param>
        /// <returns></returns>
        public static int Change(int catId, int catFather)
        {
            if (catId < 0)
                return 0;
            return PfmIaeCategoryBLL._dal.Change(catId, catFather);
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除数据表PfmIaeCategory中的一条记录
        /// </summary>
        /// <param name="catId">系统编号</param>
        /// <param name="delFlag">删除标记：False  删除指定，True 删除所有</param>
        /// <returns></returns>
        public static int Delete(int catId, bool delFlag)
        {
            if (catId < 0)
                return 0;
            return PfmIaeCategoryBLL._dal.Delete(catId, delFlag);
        }

        #endregion

        #region 实体对象

        /// <summary>
        /// 通过DataRow创建一个PfmIaeCategory实体对象
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>PfmIaeCategory实体对象</returns>
        public static PfmIaeCategoryMDL Select(DataRow row)
        {
            return PfmIaeCategoryBLL._dal.Select(row);
        }
        /// <summary>
        /// 通过DataReader创建一个PfmIaeCategory实体对象
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>PfmIaeCategory实体对象</returns>
        public static PfmIaeCategoryMDL Select(IDataReader dr)
        {
            return PfmIaeCategoryBLL._dal.Select(dr);
        }
        /// <summary>
        /// 根据ID,返回一个PfmIaeCategory实体对象
        /// </summary>
        /// <param name="catId"></param>
        /// <returns>PfmIaeCategory实体对象</returns>
        public static PfmIaeCategoryMDL Select(int catId)
        {
            return PfmIaeCategoryBLL._dal.Select(catId);
        }

        #endregion

        #region 查询

        #region List
        /// <summary>
        /// 得到数据表PfmIaeCategory所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public static List<PfmIaeCategoryMDL> LSelect()
        {
            return PfmIaeCategoryBLL._dal.LSelect();
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory所有父记录
        /// </summary>
        /// <returns>结果集</returns>
        public static List<PfmIaeCategoryMDL> LSelectFather()
        {
            return PfmIaeCategoryBLL._dal.LSelectFather();
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public static List<PfmIaeCategoryMDL> LSelect(string where)
        {
            return PfmIaeCategoryBLL._dal.LSelect(where);
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static List<PfmIaeCategoryMDL> LSelect(string where, string sortField)
        {
            return PfmIaeCategoryBLL._dal.LSelect(where, sortField);
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public static List<PfmIaeCategoryMDL> LSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            return PfmIaeCategoryBLL._dal.LSelect(commandType, sqlCommand, param);
        }
        #endregion List

        #region IList
        /// <summary>
        /// 得到数据表PfmIaeCategory所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public static IList<PfmIaeCategoryMDL> ISelect()
        {
            return PfmIaeCategoryBLL._dal.ISelect();
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory所有父记录
        /// </summary>
        /// <returns>结果集</returns>
        public static IList<PfmIaeCategoryMDL> ISelectFather()
        {
            return PfmIaeCategoryBLL._dal.ISelectFather();
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public static IList<PfmIaeCategoryMDL> ISelect(string where)
        {
            return PfmIaeCategoryBLL._dal.ISelect(where);
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static IList<PfmIaeCategoryMDL> ISelect(string where, string sortField)
        {
            return PfmIaeCategoryBLL._dal.ISelect(where, sortField);
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public static IList<PfmIaeCategoryMDL> ISelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            return PfmIaeCategoryBLL._dal.ISelect(commandType, sqlCommand, param);
        }
        #endregion IList

        #region Collection
        /// <summary>
        /// 得到数据表PfmIaeCategory所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public static Collection<PfmIaeCategoryMDL> CSelect()
        {
            return PfmIaeCategoryBLL._dal.CSelect();
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory所有父记录
        /// </summary>
        /// <returns>结果集</returns>
        public static Collection<PfmIaeCategoryMDL> CSelectFather()
        {
            return PfmIaeCategoryBLL._dal.CSelectFather();
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public static Collection<PfmIaeCategoryMDL> CSelect(string where)
        {
            return PfmIaeCategoryBLL._dal.CSelect(where);
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static Collection<PfmIaeCategoryMDL> CSelect(string where, string sortField)
        {
            return PfmIaeCategoryBLL._dal.CSelect(where, sortField);
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public static Collection<PfmIaeCategoryMDL> CSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            return PfmIaeCategoryBLL._dal.CSelect(commandType, sqlCommand, param);
        }
        #endregion Collection

        #region ObservableCollection
        /// <summary>
        /// 得到数据表PfmIaeCategory所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public static ObservableCollection<PfmIaeCategoryMDL> OSelect()
        {
            return PfmIaeCategoryBLL._dal.OSelect();
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory所有父记录
        /// </summary>
        /// <returns>结果集</returns>
        public static ObservableCollection<PfmIaeCategoryMDL> OSelectFather()
        {
            return PfmIaeCategoryBLL._dal.OSelectFather();
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public static ObservableCollection<PfmIaeCategoryMDL> OSelect(string where)
        {
            return PfmIaeCategoryBLL._dal.OSelect(where);
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public static ObservableCollection<PfmIaeCategoryMDL> OSelect(string where, string sortField)
        {
            return PfmIaeCategoryBLL._dal.OSelect(where, sortField);
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public static ObservableCollection<PfmIaeCategoryMDL> OSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            return PfmIaeCategoryBLL._dal.OSelect(commandType, sqlCommand, param);
        }
        #endregion ObservableCollection

        #region Recursive
        /// <summary>
        /// 递归数据表PfmIaeCategory所有记录
        /// </summary>
        /// <param name="mainMark">主制表符</param>
        /// <param name="childMark">子制表符</param>
        /// <returns>结果集</returns>
        public static IList<PfmIaeCategoryMDL> RecursiveI(string mainMark, string childMark)
        {
            return PfmIaeCategoryBLL._dal.RecursiveI(mainMark, childMark);
        }
        #endregion Recursive

        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件的记录数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="recordCount">记录数</param>
        public static void Select(string where, out int recordCount)
        {
            PfmIaeCategoryBLL._dal.Select(where, out recordCount);
        }

        #region Exists
        /// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="catId"></param>
        /// <returns>存在/不存在</returns>
        public static bool Exists(int catId)
        {
            return PfmIaeCategoryBLL._dal.Exists(catId);
        }
        /// <summary>
        /// 根据类别名称检测是否存在该条记录
        /// </summary>
        /// <param name="catName"></param>
        /// <returns>存在/不存在</returns>
        public static bool Exists(string catName)
        {
            return PfmIaeCategoryBLL._dal.Exists(catName);
        }
        /// <summary>
        /// 根据类别点击检测是否存在该条记录
        /// </summary>
        /// <param name="catClick"></param>
        /// <returns>存在/不存在</returns>
        public static bool ExistsClick(int catClick)
        {
            return PfmIaeCategoryBLL._dal.ExistsClick(catClick);
        }
        /// <summary>
        /// 根据父标识检测是否存在该条记录
        /// </summary>
        /// <param name="catFather"></param>
        /// <returns>存在/不存在</returns>
        public static bool ExistsFather(int catFather)
        {
            return PfmIaeCategoryBLL._dal.ExistsFather(catFather);
        }
        /// <summary>
        /// 根据类别名称和父标识检测是否存在该条记录
        /// </summary>
        /// <param name="catName"></param>
        /// <param name="catFather"></param>
        /// <returns>存在/不存在</returns>
        public static bool Exists(string catName, int catFather)
        {
            return PfmIaeCategoryBLL._dal.Exists(catName, catFather);
        }
        #endregion Exists

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
        public static List<PfmIaeCategoryMDL> LSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeCategoryBLL._dal.LSelectPaging(pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static List<PfmIaeCategoryMDL> LSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeCategoryBLL._dal.LSelectPaging(strWhere, pageSize, currentIndex, out recordCount);
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
        public static List<PfmIaeCategoryMDL> LSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeCategoryBLL._dal.LSelectPaging(strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static List<PfmIaeCategoryMDL> LSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeCategoryBLL._dal.LSelectPaging(strColumns, strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static IList<PfmIaeCategoryMDL> ISelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeCategoryBLL._dal.ISelectPaging(pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static IList<PfmIaeCategoryMDL> ISelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeCategoryBLL._dal.ISelectPaging(strWhere, pageSize, currentIndex, out recordCount);
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
        public static IList<PfmIaeCategoryMDL> ISelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeCategoryBLL._dal.ISelectPaging(strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static IList<PfmIaeCategoryMDL> ISelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeCategoryBLL._dal.ISelectPaging(strColumns, strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static Collection<PfmIaeCategoryMDL> CSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeCategoryBLL._dal.CSelectPaging(pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static Collection<PfmIaeCategoryMDL> CSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeCategoryBLL._dal.CSelectPaging(strWhere, pageSize, currentIndex, out recordCount);
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
        public static Collection<PfmIaeCategoryMDL> CSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeCategoryBLL._dal.CSelectPaging(strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static Collection<PfmIaeCategoryMDL> CSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeCategoryBLL._dal.CSelectPaging(strColumns, strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static ObservableCollection<PfmIaeCategoryMDL> OSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeCategoryBLL._dal.OSelectPaging(pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public static ObservableCollection<PfmIaeCategoryMDL> OSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeCategoryBLL._dal.OSelectPaging(strWhere, pageSize, currentIndex, out recordCount);
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
        public static ObservableCollection<PfmIaeCategoryMDL> OSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeCategoryBLL._dal.OSelectPaging(strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public static ObservableCollection<PfmIaeCategoryMDL> OSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            return PfmIaeCategoryBLL._dal.OSelectPaging(strColumns, strWhere, strOrder, pageSize, currentIndex, out recordCount);
        }
        #endregion ObservableCollection

        #endregion 数据分页处理·SQLite

    }
}
