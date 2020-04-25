// =================================================================== 
// 产品（PFM.DawnXZ.Library.SqlServerDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：PfmIaeCategoryDAL.cs
// 项目名称：请更改为实际项目名称
// 创建时间：2012年08月06日 16:30:54
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
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using DawnXZ.DBUtility;
using PFM.DawnXZ.Library.Entity;
using PFM.DawnXZ.Library.IDAL;
using PFM.DawnXZ.Library.BLL;

namespace PFM.DawnXZ.Library.SqlServerDAL
{
    /// <summary>
    /// 数据访问层PfmIaeCategory
    /// </summary>
    public partial class PfmIaeCategoryDAL : IPfmIaeCategoryDAL, SQLitePaging<PfmIaeCategoryMDL>
    {

        #region 构造函数

        /// <summary>
        /// 数据层实例化
        /// </summary>
        public PfmIaeCategoryDAL()
        { }

        #endregion

        #region -----------实例化接口函数-----------

        #region GetMaxId
        /// <summary>
        /// 获取当前最大系统编号
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            string cmdSql = "select max(cat_id) from pfm_iae_category";
            int catId = 0;
            string tmpVal = SQLiteHelper.ExecuteScalar(Conn.SqlConn, CommandType.Text, cmdSql).ToString();
            int.TryParse(tmpVal, out catId);
            return catId;
        }
        #endregion

        #region 添加

        /// <summary>
        /// 向数据表PfmIaeCategory中插入一条新记录
        /// </summary>
        /// <param name="pfmIaeCategory">PfmIaeCategory实体对象</param>
        /// <param name="addFlag">添加标记：False  主分类，True 子分类</param>
        /// <returns></returns>
        public int Insert(PfmIaeCategoryMDL pfmIaeCategory, bool addFlag)
        {
            //系统编号
            int catId = this.GetMaxId() + 1;
            pfmIaeCategory.CatId = catId;
            //类别路径
            string catPath = string.Empty;
            if (addFlag)
            {
                string cmdSql = "select cat_path from pfm_iae_category where cat_id=@CatFather";
                SQLiteParameter[] spPath ={
                    new SQLiteParameter("@CatFather",DbType.Int32)
                };
                spPath[0].Value = pfmIaeCategory.CatFather;
                catPath = SQLiteHelper.ExecuteScalar(Conn.SqlConn, CommandType.Text, cmdSql, spPath).ToString();
                catPath += string.Format("{0},", catId);
            }
            else
            {
                catPath = string.Format("0,{0},", catId);
            }
            pfmIaeCategory.CatPath = catPath;
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into ");
            sb.Append("pfm_iae_category");
            sb.Append("(");
            sb.Append("cat_id");
            sb.Append(",");
            sb.Append("cat_name");
            sb.Append(",");
            sb.Append("cat_father");
            sb.Append(",");
            sb.Append("cat_path");
            sb.Append(",");
            sb.Append("cat_click");
            sb.Append(",");
            sb.Append("cat_counts");
            sb.Append(",");
            sb.Append("cat_description");
            sb.Append(")");
            sb.Append(" values");
            sb.Append("(");
            sb.Append("@CatId");
            sb.Append(",");
            sb.Append("@CatName");
            sb.Append(",");
            sb.Append("@CatFather");
            sb.Append(",");
            sb.Append("@CatPath");
            sb.Append(",");
            sb.Append("@CatClick");
            sb.Append(",");
            sb.Append("@CatCounts");
            sb.Append(",");
            sb.Append("@CatDescription");
            sb.Append(")");
            int res;
            SQLiteParameter[] param ={
                new SQLiteParameter("@CatId",DbType.Int32),
                new SQLiteParameter("@CatName",DbType.String,50),
                new SQLiteParameter("@CatFather",DbType.Int32),
                new SQLiteParameter("@CatPath",DbType.String,8000),
                new SQLiteParameter("@CatClick",DbType.Int32),
                new SQLiteParameter("@CatCounts",DbType.Int32),
                new SQLiteParameter("@CatDescription",DbType.String,300)
			};
            param[0].Value = pfmIaeCategory.CatId;
            param[1].Value = pfmIaeCategory.CatName;
            param[2].Value = pfmIaeCategory.CatFather;
            param[3].Value = pfmIaeCategory.CatPath;
            param[4].Value = pfmIaeCategory.CatClick;
            param[5].Value = pfmIaeCategory.CatCounts;
            param[6].Value = pfmIaeCategory.CatDescription;
            res = SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, sb.ToString(), param);
            return res;
        }

        #endregion

        #region 修改

        /// <summary>
        /// 向数据表PfmIaeCategory修改一条记录
        /// </summary>
        /// <param name="pfmIaeCategory">PfmIaeCategory实体对象</param>
        /// <returns></returns>
        public int Update(PfmIaeCategoryMDL pfmIaeCategory)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update ");
            sb.Append("pfm_iae_category");
            sb.Append(" set ");
            sb.Append("cat_name=@CatName");
            sb.Append(",cat_click=@CatClick");
            sb.Append(",cat_counts=@CatCounts");
            sb.Append(",cat_description=@CatDescription");
            sb.Append(" where ");
            sb.Append("cat_id=@CatId");
            SQLiteParameter[] param ={
				new SQLiteParameter("@CatId",DbType.Int32),
				new SQLiteParameter("@CatName",DbType.String,50),
				new SQLiteParameter("@CatClick",DbType.Int32),
				new SQLiteParameter("@CatCounts",DbType.Int32),
				new SQLiteParameter("@CatDescription",DbType.String,300)
			};
            param[0].Value = pfmIaeCategory.CatId;
            param[1].Value = pfmIaeCategory.CatName;
            param[2].Value = pfmIaeCategory.CatClick;
            param[3].Value = pfmIaeCategory.CatCounts;
            param[4].Value = pfmIaeCategory.CatDescription;
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, sb.ToString(), param);
        }

        #endregion

        #region 点击率

        /// <summary>
        /// 向数据表PfmIaeCategory更新点击率
        /// </summary>
        /// <param name="catId">系统编号</param>
        /// <returns></returns>
        public int UpdateClick(int catId)
        {
            string cmdSql = "update pfm_iae_category set cat_click=cat_click+1 where cat_id=@CatId";
            SQLiteParameter[] param ={
				new SQLiteParameter("@CatId",DbType.Int32)
			};
            param[0].Value = catId;
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, cmdSql, param);
        }

        #endregion

        #region 数据统计

        /// <summary>
        /// 向数据表PfmIaeCategory更新数据统计
        /// </summary>
        /// <param name="catId">系统编号</param>
        /// <param name="countFlag">数据统计标记：0添加，1删除</param>
        /// <returns></returns>
        public int UpdateCounts(int catId, byte countFlag)
        {
            string cmdSql = string.Empty;
            if (countFlag == 0)
            {
                cmdSql = "update pfm_iae_category set cat_counts=cat_counts+1 where cat_id=@CatId";
            }
            else if (countFlag == 1)
            {
                cmdSql = "update pfm_iae_category set cat_counts=cat_counts-1 where cat_id=@CatId";
            }
            SQLiteParameter[] param ={
				new SQLiteParameter("@CatId",DbType.Int32)
			};
            param[0].Value = catId;
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, cmdSql, param);
        }

        #endregion

        #region 变更

        /// <summary>
        /// 向数据表PfmIaeCategory变更一条记录
        /// </summary>
        /// <param name="catId">系统编号</param>
        /// <param name="catFather">类别标识</param>
        /// <returns></returns>
        public int Change(int catId, int catFather)
        {
            string cmdSql = string.Empty;
            string catPath = string.Empty;
            if (catFather != -1)
            {
                cmdSql = "select cat_path from pfm_iae_category where cat_id=@CatFather";
                SQLiteParameter[] spPath ={
                    new SQLiteParameter("@CatFather",DbType.Int32)
                };
                spPath[0].Value = catFather;
                catPath = SQLiteHelper.ExecuteScalar(Conn.SqlConn, CommandType.Text, cmdSql, spPath).ToString();
                catPath += string.Format("{0},", catId);
            }
            else
            {
                catPath = string.Format("0,{0},", catId);
            }
            cmdSql = "update pfm_iae_category set cat_path=@CatPath where cat_id=@CatId";
            SQLiteParameter[] param ={
				new SQLiteParameter("@CatId",DbType.Int32),
				new SQLiteParameter("@CatPath",DbType.String,8000)
			};
            param[0].Value = catId;
            param[1].Value = catPath;
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, cmdSql, param);
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除数据表PfmIaeCategory中的一条记录
        /// </summary>
        /// <param name="catId">系统编号</param>
        /// <param name="delFlag">删除标记：False  删除指定，True 删除所有</param>
        /// <returns></returns>
        public int Delete(int catId, bool delFlag)
        {
            string cmdSql = string.Empty;
            if (delFlag)
            {
                cmdSql = string.Format("delete from pfm_iae_category where cat_path like '%,{0},%'", catId);
            }
            else
            {
                cmdSql = string.Format("delete from pfm_iae_category where cat_id={0}", catId);
            }
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, cmdSql);
        }

        #endregion

        #region 实体对象

        /// <summary>
        /// 得到PfmIaeCategory实体对象
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>PfmIaeCategory实体对象</returns>
        public PfmIaeCategoryMDL Select(DataRow row)
        {
            PfmIaeCategoryMDL obj = new PfmIaeCategoryMDL();
            if (row != null)
            {
                try
                {
                    obj.CatId = ((row["cat_id"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["cat_id"]);
                }
                catch { }
                try
                {
                    obj.CatName = row["cat_name"].ToString();
                }
                catch { }
                try
                {
                    obj.CatFather = ((row["cat_father"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["cat_father"]);
                }
                catch { }
                try
                {
                    obj.CatPath = row["cat_path"].ToString();
                }
                catch { }
                try
                {
                    obj.CatClick = ((row["cat_click"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["cat_click"]);
                }
                catch { }
                try
                {
                    obj.CatCounts = ((row["cat_counts"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["cat_counts"]);
                }
                catch { }
                try
                {
                    obj.CatDescription = row["cat_description"].ToString();
                }
                catch { }
            }
            else
            {
                return null;
            }
            return obj;
        }

        /// <summary>
        /// 得到PfmIaeCategory实体对象
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>PfmIaeCategory实体对象</returns>
        public PfmIaeCategoryMDL Select(IDataReader dr)
        {
            PfmIaeCategoryMDL obj = new PfmIaeCategoryMDL();
            try
            {
                obj.CatId = ((dr["cat_id"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["cat_id"]);
            }
            catch { }
            try
            {
                obj.CatName = dr["cat_name"].ToString();
            }
            catch { }
            try
            {
                obj.CatFather = ((dr["cat_father"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["cat_father"]);
            }
            catch { }
            try
            {
                obj.CatPath = dr["cat_path"].ToString();
            }
            catch { }
            try
            {
                obj.CatClick = ((dr["cat_click"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["cat_click"]);
            }
            catch { }
            try
            {
                obj.CatCounts = ((dr["cat_counts"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["cat_counts"]);
            }
            catch { }
            try
            {
                obj.CatDescription = dr["cat_description"].ToString();
            }
            catch { }
            return obj;
        }
        /// <summary>
        /// 根据ID,返回一个PfmIaeCategory实体对象
        /// </summary>
        /// <param name="catId"></param>
        /// <returns>PfmIaeCategory实体对象</returns>
        public PfmIaeCategoryMDL Select(int catId)
        {
            PfmIaeCategoryMDL obj = null;
            string cmdSql = "select * from pfm_iae_category where cat_id=@CatId";
            SQLiteParameter[] param ={
			    new SQLiteParameter("@CatId",DbType.Int32)
			};
            param[0].Value = catId;
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, cmdSql, param))
            {
                while (dr.Read())
                {
                    obj = this.Select(dr);
                }
            }
            return obj;
        }

        #endregion

        #region 查询

        #region List
        /// <summary>
        /// 得到数据表PfmIaeCategory所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public List<PfmIaeCategoryMDL> LSelect()
        {
            return this.LSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory所有父记录
        /// </summary>
        /// <returns>结果集</returns>
        public List<PfmIaeCategoryMDL> LSelectFather()
        {
            return this.LSelect(" cat_father = -1");
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public List<PfmIaeCategoryMDL> LSelect(string where)
        {
            return this.LSelect(where, " [cat_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public List<PfmIaeCategoryMDL> LSelect(string where, string sortField)
        {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = " [cat_id]";
            List<PfmIaeCategoryMDL> list = new List<PfmIaeCategoryMDL>();
            string cmdSql = string.Format("select * from pfm_iae_category where {0} order by {1}", where, sortField);
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, cmdSql))
            {
                while (dr.Read())
                {
                    list.Add(this.Select(dr));
                }
            }
            return list;
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public List<PfmIaeCategoryMDL> LSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            List<PfmIaeCategoryMDL> list = new List<PfmIaeCategoryMDL>();
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, commandType, sqlCommand, param))
            {
                while (dr.Read())
                {
                    list.Add(this.Select(dr));
                }
            }
            return list;
        }
        #endregion List

        #region IList
        /// <summary>
        /// 得到数据表PfmIaeCategory所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public IList<PfmIaeCategoryMDL> ISelect()
        {
            return this.ISelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory所有父记录
        /// </summary>
        /// <returns>结果集</returns>
        public IList<PfmIaeCategoryMDL> ISelectFather()
        {
            return this.ISelect(" cat_father = -1");
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public IList<PfmIaeCategoryMDL> ISelect(string where)
        {
            return this.ISelect(where, " [cat_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public IList<PfmIaeCategoryMDL> ISelect(string where, string sortField)
        {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = " [cat_id]";
            IList<PfmIaeCategoryMDL> list = new List<PfmIaeCategoryMDL>();
            string cmdSql = string.Format("select * from pfm_iae_category where {0} order by {1}", where, sortField);
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, cmdSql))
            {
                while (dr.Read())
                {
                    list.Add(this.Select(dr));
                }
            }
            return list;
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public IList<PfmIaeCategoryMDL> ISelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            IList<PfmIaeCategoryMDL> list = new List<PfmIaeCategoryMDL>();
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, commandType, sqlCommand, param))
            {
                while (dr.Read())
                {
                    list.Add(this.Select(dr));
                }
            }
            return list;
        }
        #endregion IList

        #region Collection
        /// <summary>
        /// 得到数据表PfmIaeCategory所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public Collection<PfmIaeCategoryMDL> CSelect()
        {
            return this.CSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory所有父记录
        /// </summary>
        /// <returns>结果集</returns>
        public Collection<PfmIaeCategoryMDL> CSelectFather()
        {
            return this.CSelect(" cat_father = -1");
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public Collection<PfmIaeCategoryMDL> CSelect(string where)
        {
            return this.CSelect(where, " [cat_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public Collection<PfmIaeCategoryMDL> CSelect(string where, string sortField)
        {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = " [cat_id]";
            Collection<PfmIaeCategoryMDL> list = new Collection<PfmIaeCategoryMDL>();
            string cmdSql = string.Format("select * from pfm_iae_category where {0} order by {1}", where, sortField);
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, cmdSql))
            {
                while (dr.Read())
                {
                    list.Add(this.Select(dr));
                }
            }
            return list;
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public Collection<PfmIaeCategoryMDL> CSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            Collection<PfmIaeCategoryMDL> list = new Collection<PfmIaeCategoryMDL>();
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, commandType, sqlCommand, param))
            {
                while (dr.Read())
                {
                    list.Add(this.Select(dr));
                }
            }
            return list;
        }
        #endregion Collection

        #region ObservableCollection
        /// <summary>
        /// 得到数据表PfmIaeCategory所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmIaeCategoryMDL> OSelect()
        {
            return this.OSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory所有父记录
        /// </summary>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmIaeCategoryMDL> OSelectFather()
        {
            return this.OSelect(" cat_father = -1");
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmIaeCategoryMDL> OSelect(string where)
        {
            return this.OSelect(where, " [cat_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmIaeCategoryMDL> OSelect(string where, string sortField)
        {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = " [cat_id]";
            ObservableCollection<PfmIaeCategoryMDL> list = new ObservableCollection<PfmIaeCategoryMDL>();
            string cmdSql = string.Format("select * from pfm_iae_category where {0} order by {1}", where, sortField);
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, cmdSql))
            {
                while (dr.Read())
                {
                    list.Add(this.Select(dr));
                }
            }
            return list;
        }
        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmIaeCategoryMDL> OSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            ObservableCollection<PfmIaeCategoryMDL> list = new ObservableCollection<PfmIaeCategoryMDL>();
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, commandType, sqlCommand, param))
            {
                while (dr.Read())
                {
                    list.Add(this.Select(dr));
                }
            }
            return list;
        }
        #endregion ObservableCollection

        #region Recursive
        /// <summary>
        /// 递归数据表PfmIaeCategory所有记录
        /// </summary>
        /// <param name="mainMark">主制表符</param>
        /// <param name="childMark">子制表符</param>
        /// <returns>结果集</returns>
        public IList<PfmIaeCategoryMDL> RecursiveI(string mainMark, string childMark)
        {
            IList<PfmIaeCategoryMDL> treeList = new List<PfmIaeCategoryMDL>();
            IList<PfmIaeCategoryMDL> fatherList = this.ISelectFather();
            foreach (PfmIaeCategoryMDL rootMdl in fatherList)
            {
                treeList.Add(rootMdl);
                RecursiveIByNode(treeList, rootMdl.CatId, mainMark, childMark);
            }
            return treeList;
        }
        /// <summary>
        /// 递归数据表PfmIaeCategory所有记录
        /// <param name="treeList">递归树集合</param>
        /// <param name="mainMark">主制表符</param>
        /// <param name="childMark">子制表符</param>
        /// </summary>
        private void RecursiveIByNode(IList<PfmIaeCategoryMDL> treeList, int fatherId, string mainMark, string childMark)
        {
            IList<PfmIaeCategoryMDL> childList = this.ISelect(string.Format("cat_father = {0}", fatherId));
            if (childList == null || childList.Count <= 0) return;
            foreach (PfmIaeCategoryMDL nodeMdl in childList)
            {
                nodeMdl.CatName = mainMark + nodeMdl.CatName;
                treeList.Add(nodeMdl);
                string mainMark2 = mainMark + childMark;
                RecursiveIByNode(treeList, nodeMdl.CatId, mainMark2, childMark);
            }
        }

        #endregion Recursive

        /// <summary>
        /// 得到数据表PfmIaeCategory满足查询条件的记录数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="recordCount">记录数</param>
        public void Select(string where, out int recordCount)
        {
            if (string.IsNullOrEmpty(where)) where = " 1<>1";
            string cmdSql = "select count(-1) from pfm_iae_category where @where";
            SQLiteParameter[] param ={
                new SQLiteParameter("@where",DbType.String,8000)
			};
            param[0].Value = where;
            string tmpVal = SQLiteHelper.ExecuteScalar(Conn.SqlConn, CommandType.Text, cmdSql, param).ToString();
            int.TryParse(tmpVal, out recordCount);
        }

        #region Exists
        /// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="catId"></param>
        /// <returns>存在/不存在</returns>
        public bool Exists(int catId)
        {
            string cmdSql = "select count(-1) from pfm_iae_category where cat_id=@CatId";
            SQLiteParameter[] param ={
                new SQLiteParameter("@CatId",DbType.Int32)
            };
            param[0].Value = catId;
            string val = SQLiteHelper.ExecuteScalar(Conn.SqlConn, CommandType.Text, cmdSql, param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp > 0 ? true : false;
        }
        /// <summary>
        /// 根据类别名称检测是否存在该条记录
        /// </summary>
        /// <param name="catName"></param>
        /// <returns>存在/不存在</returns>
        public bool Exists(string catName)
        {
            string cmdSql = "select count(-1) from pfm_iae_category where cat_name=@CatName";
            SQLiteParameter[] param = {
                new SQLiteParameter("@CatName",DbType.String,50)
            };
            param[0].Value = catName;
            string val = SQLiteHelper.ExecuteScalar(Conn.SqlConn, CommandType.Text, cmdSql, param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp > 0 ? true : false;
        }
        /// <summary>
        /// 根据类别点击检测是否存在该条记录
        /// </summary>
        /// <param name="catClick"></param>
        /// <returns>存在/不存在</returns>
        public bool ExistsClick(int catClick)
        {
            string cmdSql = "select count(-1) from pfm_iae_category where cat_click=@CatClick";
            SQLiteParameter[] param = {
                new SQLiteParameter("@CatClick",DbType.Int32)
            };
            param[0].Value = catClick;
            string val = SQLiteHelper.ExecuteScalar(Conn.SqlConn, CommandType.Text, cmdSql, param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp > 0 ? true : false;
        }
        /// <summary>
        /// 根据父标识检测是否存在该条记录
        /// </summary>
        /// <param name="catFather"></param>
        /// <returns>存在/不存在</returns>
        public bool ExistsFather(int catFather)
        {
            string cmdSql = "select count(-1) from pfm_iae_category where cat_father=@CatFather";
            SQLiteParameter[] param = {
                new SQLiteParameter("@CatFather",DbType.Int32)
            };
            param[0].Value = catFather;
            string val = SQLiteHelper.ExecuteScalar(Conn.SqlConn, CommandType.Text, cmdSql, param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp > 0 ? true : false;
        }
        /// <summary>
        /// 根据类别名称和父标识检测是否存在该条记录
        /// </summary>
        /// <param name="catName"></param>
        /// <param name="catFather"></param>
        /// <returns>存在/不存在</returns>
        public bool Exists(string catName, int catFather)
        {
            string cmdSql = "select count(-1) from pfm_iae_category where cat_name=@CatName and cat_father=@CatFather";
            SQLiteParameter[] param ={
				new SQLiteParameter("@CatName",DbType.String,50),
				new SQLiteParameter("@CatFather",DbType.Int32)
			};
            param[0].Value = catName;
            param[1].Value = catFather;
            string val = SQLiteHelper.ExecuteScalar(Conn.SqlConn, CommandType.Text, cmdSql, param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp > 0 ? true : false;
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
        public List<PfmIaeCategoryMDL> LSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return LSelectPaging(null, " [cat_id] DESC ", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public List<PfmIaeCategoryMDL> LSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return LSelectPaging(strWhere, " [cat_id] DESC ", pageSize, currentIndex, out recordCount);
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
        public List<PfmIaeCategoryMDL> LSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("cat_id");
            sb.Append(",cat_name");
            sb.Append(",cat_father");
            sb.Append(",cat_path");
            sb.Append(",cat_click");
            sb.Append(",cat_counts");
            sb.Append(",cat_description");
            return LSelectPaging(sb.ToString(), strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public List<PfmIaeCategoryMDL> LSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = " [cat_id] DESC ";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            List<PfmIaeCategoryMDL> list = new List<PfmIaeCategoryMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_iae_category where {1} order by {2} limit {3} offset {4}";
            cmdSql = string.Format(cmdSql, strColumns, strWhere, strOrder, pageSize, offsetCount);
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, cmdSql))
            {
                while (dr.Read())
                {
                    list.Add(this.Select(dr));
                }
            }
            return list;
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
        public IList<PfmIaeCategoryMDL> ISelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return ISelectPaging(null, " [cat_id] DESC ", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public IList<PfmIaeCategoryMDL> ISelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return ISelectPaging(strWhere, " [cat_id] DESC ", pageSize, currentIndex, out recordCount);
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
        public IList<PfmIaeCategoryMDL> ISelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("cat_id");
            sb.Append(",cat_name");
            sb.Append(",cat_father");
            sb.Append(",cat_path");
            sb.Append(",cat_click");
            sb.Append(",cat_counts");
            sb.Append(",cat_description");
            return ISelectPaging(sb.ToString(), strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public IList<PfmIaeCategoryMDL> ISelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = " [cat_id] DESC ";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            IList<PfmIaeCategoryMDL> list = new List<PfmIaeCategoryMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_iae_category where {1} order by {2} limit {3} offset {4}";
            cmdSql = string.Format(cmdSql, strColumns, strWhere, strOrder, pageSize, offsetCount);
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, cmdSql))
            {
                while (dr.Read())
                {
                    list.Add(this.Select(dr));
                }
            }
            return list;
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
        public Collection<PfmIaeCategoryMDL> CSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return CSelectPaging(null, " [cat_id] DESC ", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public Collection<PfmIaeCategoryMDL> CSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return CSelectPaging(strWhere, " [cat_id] DESC ", pageSize, currentIndex, out recordCount);
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
        public Collection<PfmIaeCategoryMDL> CSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("cat_id");
            sb.Append(",cat_name");
            sb.Append(",cat_father");
            sb.Append(",cat_path");
            sb.Append(",cat_click");
            sb.Append(",cat_counts");
            sb.Append(",cat_description");
            return CSelectPaging(sb.ToString(), strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public Collection<PfmIaeCategoryMDL> CSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = " [cat_id] DESC ";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            Collection<PfmIaeCategoryMDL> list = new Collection<PfmIaeCategoryMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_iae_category where {1} order by {2} limit {3} offset {4}";
            cmdSql = string.Format(cmdSql, strColumns, strWhere, strOrder, pageSize, offsetCount);
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, cmdSql))
            {
                while (dr.Read())
                {
                    list.Add(this.Select(dr));
                }
            }
            return list;
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
        public ObservableCollection<PfmIaeCategoryMDL> OSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return OSelectPaging(null, " [cat_id] DESC ", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public ObservableCollection<PfmIaeCategoryMDL> OSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return OSelectPaging(strWhere, " [cat_id] DESC ", pageSize, currentIndex, out recordCount);
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
        public ObservableCollection<PfmIaeCategoryMDL> OSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("cat_id");
            sb.Append(",cat_name");
            sb.Append(",cat_father");
            sb.Append(",cat_path");
            sb.Append(",cat_click");
            sb.Append(",cat_counts");
            sb.Append(",cat_description");
            return OSelectPaging(sb.ToString(), strWhere, strOrder, pageSize, currentIndex, out recordCount);
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
        public ObservableCollection<PfmIaeCategoryMDL> OSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = " [cat_id] DESC ";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            ObservableCollection<PfmIaeCategoryMDL> list = new ObservableCollection<PfmIaeCategoryMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_iae_category where {1} order by {2} limit {3} offset {4}";
            cmdSql = string.Format(cmdSql, strColumns, strWhere, strOrder, pageSize, offsetCount);
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, cmdSql))
            {
                while (dr.Read())
                {
                    list.Add(this.Select(dr));
                }
            }
            return list;
        }
        #endregion ObservableCollection

        #endregion 数据分页处理·SQLite

    }
}
