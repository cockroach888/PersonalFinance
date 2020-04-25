// =================================================================== 
// 产品（PFM.DawnXZ.Library.SqlServerDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：PfmIaeItemsDAL.cs
// 项目名称：请更改为实际项目名称
// 创建时间：2012年08月06日 16:54:35
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
    /// 数据访问层PfmIaeItems
    /// </summary>
    public partial class PfmIaeItemsDAL : IPfmIaeItemsDAL, SQLitePaging<PfmIaeItemsMDL>
    {

        #region 构造函数

        /// <summary>
        /// 数据层实例化
        /// </summary>
        public PfmIaeItemsDAL()
        { }

        #endregion 构造函数

        #region -----------实例化接口函数-----------

        #region 添加

        /// <summary>
        /// 向数据表PfmIaeItems中插入一条新记录
        /// </summary>
        /// <param name="pfmIaeItems">PfmIaeItems实体对象</param>
        /// <returns></returns>
        public int Insert(PfmIaeItemsMDL pfmIaeItems)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into ");
            sb.Append("pfm_iae_items");
            sb.Append("(");
            sb.Append("item_add_time");
            sb.Append(",");
            sb.Append("item_status");
            sb.Append(",");
            sb.Append("item_type");
            sb.Append(",");
            sb.Append("item_name");
            sb.Append(",");
            sb.Append("item_description");
            sb.Append(")");
            sb.Append(" values");
            sb.Append("(");
            sb.Append("@ItemAddTime");
            sb.Append(",");
            sb.Append("@ItemStatus");
            sb.Append(",");
            sb.Append("@ItemType");
            sb.Append(",");
            sb.Append("@ItemName");
            sb.Append(",");
            sb.Append("@ItemDescription");
            sb.Append(")");
            int res;
            SQLiteParameter[] param ={
				new SQLiteParameter("@ItemAddTime",DbType.DateTime),
				new SQLiteParameter("@ItemStatus",DbType.Byte),
				new SQLiteParameter("@ItemType",DbType.Byte),
				new SQLiteParameter("@ItemName",DbType.String,300),
				new SQLiteParameter("@ItemDescription",DbType.String,2000)
			};
            param[0].Value = pfmIaeItems.ItemAddTime;
            param[1].Value = pfmIaeItems.ItemStatus;
            param[2].Value = pfmIaeItems.ItemType;
            param[3].Value = pfmIaeItems.ItemName;
            param[4].Value = pfmIaeItems.ItemDescription;
            res = SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, sb.ToString(), param);
            return res;
        }

        #endregion

        #region 修改

        /// <summary>
        /// 向数据表PfmIaeItems修改一条记录
        /// </summary>
        /// <param name="pfmIaeItems">pfmIaeItems实体对象</param>
        /// <returns></returns>
        public int Update(PfmIaeItemsMDL pfmIaeItems)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update ");
            sb.Append("pfm_iae_items");
            sb.Append(" set ");
            sb.Append("item_add_time=@ItemAddTime");
            sb.Append(",");
            sb.Append("item_status=@ItemStatus");
            sb.Append(",");
            sb.Append("item_type=@ItemType");
            sb.Append(",");
            sb.Append("item_name=@ItemName");
            sb.Append(",");
            sb.Append("item_description=@ItemDescription");
            sb.Append(" where ");
            sb.Append("item_id=@ItemId");
            SQLiteParameter[] param ={
				new SQLiteParameter("@ItemId",DbType.Int32,8),
				new SQLiteParameter("@ItemAddTime",DbType.DateTime),
				new SQLiteParameter("@ItemStatus",DbType.Byte),
				new SQLiteParameter("@ItemType",DbType.Byte),
				new SQLiteParameter("@ItemName",DbType.String,300),
				new SQLiteParameter("@ItemDescription",DbType.String,2000)
			};
            param[0].Value = pfmIaeItems.ItemId;
            param[1].Value = pfmIaeItems.ItemAddTime;
            param[2].Value = pfmIaeItems.ItemStatus;
            param[3].Value = pfmIaeItems.ItemType;
            param[4].Value = pfmIaeItems.ItemName;
            param[5].Value = pfmIaeItems.ItemDescription;
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, sb.ToString(), param);
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除数据表PfmIaeItems中的一条记录
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public int Delete(long itemId)
        {
            string cmdSql = "delete from pfm_iae_items where item_id=@ItemId";
            SQLiteParameter[] param ={
				new SQLiteParameter("@ItemId",DbType.Int32)
			};
            param[0].Value = itemId;
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, cmdSql, param);
        }
        /// <summary>
        /// 删除数据表PfmIaeItems中的一条记录
        /// </summary>
        /// <param name="pfmIaeItems">pfmIaeItems实体对象</param>
        /// <returns></returns>
        public int Delete(PfmIaeItemsMDL pfmIaeItems)
        {
            string cmdSql = "delete from pfm_iae_items where item_id=@ItemId";
            SQLiteParameter[] param ={
				new SQLiteParameter("@ItemId",DbType.Int32)
			};
            param[0].Value = pfmIaeItems.ItemId;
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, cmdSql, param);
        }

        #endregion

        #region 实体对象

        /// <summary>
        /// 得到PfmIaeItems实体对象
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>PfmIaeItems实体对象</returns>
        public PfmIaeItemsMDL Select(DataRow row)
        {
            PfmIaeItemsMDL obj = new PfmIaeItemsMDL();
            if (row != null)
            {
                try
                {
                    obj.ItemId = (long)row["item_id"];
                }
                catch { }
                try
                {
                    obj.ItemAddTime = ((row["item_add_time"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["item_add_time"]);
                }
                catch { }
                try
                {
                    obj.ItemStatus = ((row["item_status"]) == DBNull.Value) ? Convert.ToByte(0) : Convert.ToByte(row["item_status"]);
                }
                catch { }
                try
                {
                    obj.ItemType = ((row["item_type"]) == DBNull.Value) ? Convert.ToByte(0) : Convert.ToByte(row["item_type"]);
                }
                catch { }
                try
                {
                    obj.ItemName = row["item_name"].ToString();
                }
                catch { }
                try
                {
                    obj.ItemDescription = row["item_description"].ToString();
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
        /// 得到PfmIaeItems实体对象
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>PfmIaeItemss实体对象</returns>
        public PfmIaeItemsMDL Select(IDataReader dr)
        {
            PfmIaeItemsMDL obj = new PfmIaeItemsMDL();
            try
            {
                obj.ItemId = (long)dr["item_id"];
            }
            catch { }
            try
            {
                obj.ItemAddTime = ((dr["item_add_time"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["item_add_time"]);
            }
            catch { }
            try
            {
                obj.ItemStatus = ((dr["item_status"]) == DBNull.Value) ? Convert.ToByte(0) : Convert.ToByte(dr["item_status"]);
            }
            catch { }
            try
            {
                obj.ItemType = ((dr["item_type"]) == DBNull.Value) ? Convert.ToByte(0) : Convert.ToByte(dr["item_type"]);
            }
            catch { }
            try
            {
                obj.ItemName = dr["item_name"].ToString();
            }
            catch { }
            try
            {
                obj.ItemDescription = dr["item_description"].ToString();
            }
            catch { }
            return obj;
        }
        /// <summary>
        /// 根据ID,返回一个PfmIaeItems实体对象
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns>PfmIaeItems实体对象</returns>
        public PfmIaeItemsMDL Select(long itemId)
        {
            string cmdSql = "select * from pfm_iae_items where item_id=@ItemId";
            PfmIaeItemsMDL obj = null;
            SQLiteParameter[] param ={
			    new SQLiteParameter("@ItemId",DbType.Int32)
			};
            param[0].Value = itemId;
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
        /// 得到数据表PfmIaeItems所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public List<PfmIaeItemsMDL> LSelect()
        {
            return this.LSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmIaeItems满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public List<PfmIaeItemsMDL> LSelect(string where)
        {
            return this.LSelect(where, " [item_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmIaeItems满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public List<PfmIaeItemsMDL> LSelect(string where, string sortField)
        {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = "item_id";
            string cmdSql = string.Format("select * from pfm_iae_items where {0} order by {1}", where, sortField);
            List<PfmIaeItemsMDL> list = new List<PfmIaeItemsMDL>();
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
        /// 得到数据表PfmIaeItems满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public List<PfmIaeItemsMDL> LSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            List<PfmIaeItemsMDL> list = new List<PfmIaeItemsMDL>();
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
        /// 得到数据表PfmIaeItems所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public IList<PfmIaeItemsMDL> ISelect()
        {
            return this.ISelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmIaeItems满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public IList<PfmIaeItemsMDL> ISelect(string where)
        {
            return this.ISelect(where, " [item_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmIaeItems满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public IList<PfmIaeItemsMDL> ISelect(string where, string sortField)
        {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = "item_id";
            string cmdSql = string.Format("select * from pfm_iae_items where {0} order by {1}", where, sortField);
            IList<PfmIaeItemsMDL> list = new List<PfmIaeItemsMDL>();
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
        /// 得到数据表PfmIaeItems满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public IList<PfmIaeItemsMDL> ISelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            IList<PfmIaeItemsMDL> list = new List<PfmIaeItemsMDL>();
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
        /// 得到数据表PfmIaeItems所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public Collection<PfmIaeItemsMDL> CSelect()
        {
            return this.CSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmIaeItems满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public Collection<PfmIaeItemsMDL> CSelect(string where)
        {
            return this.CSelect(where, " [item_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmIaeItems满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public Collection<PfmIaeItemsMDL> CSelect(string where, string sortField)
        {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = "item_id";
            string cmdSql = string.Format("select * from pfm_iae_items where {0} order by {1}", where, sortField);
            Collection<PfmIaeItemsMDL> list = new Collection<PfmIaeItemsMDL>();
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
        /// 得到数据表PfmIaeItems满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public Collection<PfmIaeItemsMDL> CSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            Collection<PfmIaeItemsMDL> list = new Collection<PfmIaeItemsMDL>();
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
        /// 得到数据表PfmIaeItems所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmIaeItemsMDL> OSelect()
        {
            return this.OSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmIaeItems满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmIaeItemsMDL> OSelect(string where)
        {
            return this.OSelect(where, " [item_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmIaeItems满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmIaeItemsMDL> OSelect(string where, string sortField)
        {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = "item_id";
            string cmdSql = string.Format("select * from pfm_iae_items where {0} order by {1}", where, sortField);
            ObservableCollection<PfmIaeItemsMDL> list = new ObservableCollection<PfmIaeItemsMDL>();
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
        /// 得到数据表PfmIaeItems满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmIaeItemsMDL> OSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            ObservableCollection<PfmIaeItemsMDL> list = new ObservableCollection<PfmIaeItemsMDL>();
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

        /// <summary>
        /// 得到数据表PfmIaeItems满足查询条件的记录数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="recordCount">记录数</param>
        public void Select(string where, out int recordCount)
        {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            string cmdSql = "select count(-1) from pfm_iae_items where @where";
            SQLiteParameter[] param ={
			    new SQLiteParameter("@where",DbType.String,8000)
			};
            param[0].Value = where;
            string tmpVal = SQLiteHelper.ExecuteScalar(Conn.SqlConn, CommandType.Text, cmdSql, param).ToString();
            int.TryParse(tmpVal, out recordCount);
        }
        /// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns>存在/不存在</returns>
        public bool Exists(long itemId)
        {
            string cmdSql = "select count(-1) from pfm_iae_items where item_id=@ItemId";
            SQLiteParameter[] param ={
            	new SQLiteParameter("@ItemId",DbType.Int32)
            };
            param[0].Value = itemId;
            string val = SQLiteHelper.ExecuteScalar(Conn.SqlConn, CommandType.Text, cmdSql, param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp > 0 ? true : false;
        }
        /// <summary>
        /// 根据指定条件检测是否存在该条记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>存在/不存在</returns>
        public bool Exists(string where)
        {
            if (string.IsNullOrEmpty(where)) return false;
            string cmdSql = @"select count(-1) from pfm_iae_items where @where";
            SQLiteParameter[] param ={
            	new SQLiteParameter("@where",DbType.String,8000)
            };
            param[0].Value = where;
            string val = SQLiteHelper.ExecuteScalar(Conn.SqlConn, CommandType.Text, cmdSql, param).ToString();
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp > 0 ? true : false;
        }

        #endregion

        #endregion -----------实例化接口函数-----------

        #region 数据分页处理·SQLite

        #region List
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public List<PfmIaeItemsMDL> LSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return LSelectPaging(null, " [item_type],[item_add_time] DESC ", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public List<PfmIaeItemsMDL> LSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return LSelectPaging(strWhere, " [item_type],[item_add_time] DESC ", pageSize, currentIndex, out recordCount);
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
        public List<PfmIaeItemsMDL> LSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("item_id");
            sb.Append(",item_add_time");
            sb.Append(",item_status");
            sb.Append(",item_type");
            sb.Append(",item_name");
            sb.Append(",item_description");
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
        public List<PfmIaeItemsMDL> LSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = " [item_type],[item_add_time] DESC ";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            List<PfmIaeItemsMDL> list = new List<PfmIaeItemsMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_iae_items where {1} order by {2} limit {3} offset {4}";
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
        public IList<PfmIaeItemsMDL> ISelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return ISelectPaging(null, " [item_type],[item_add_time] DESC ", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public IList<PfmIaeItemsMDL> ISelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return ISelectPaging(strWhere, " [item_type],[item_add_time] DESC ", pageSize, currentIndex, out recordCount);
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
        public IList<PfmIaeItemsMDL> ISelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("item_id");
            sb.Append(",item_add_time");
            sb.Append(",item_status");
            sb.Append(",item_type");
            sb.Append(",item_name");
            sb.Append(",item_description");
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
        public IList<PfmIaeItemsMDL> ISelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = " [item_type],[item_add_time] DESC ";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            IList<PfmIaeItemsMDL> list = new List<PfmIaeItemsMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_iae_items where {1} order by {2} limit {3} offset {4}";
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
        public Collection<PfmIaeItemsMDL> CSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return CSelectPaging(null, " [item_type],[item_add_time] DESC ", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public Collection<PfmIaeItemsMDL> CSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return CSelectPaging(strWhere, " [item_type],[item_add_time] DESC ", pageSize, currentIndex, out recordCount);
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
        public Collection<PfmIaeItemsMDL> CSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("item_id");
            sb.Append(",item_add_time");
            sb.Append(",item_status");
            sb.Append(",item_type");
            sb.Append(",item_name");
            sb.Append(",item_description");
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
        public Collection<PfmIaeItemsMDL> CSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = " [item_type],[item_add_time] DESC ";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            Collection<PfmIaeItemsMDL> list = new Collection<PfmIaeItemsMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_iae_items where {1} order by {2} limit {3} offset {4}";
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
        public ObservableCollection<PfmIaeItemsMDL> OSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return OSelectPaging(null, " [item_type],[item_add_time] DESC ", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public ObservableCollection<PfmIaeItemsMDL> OSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return OSelectPaging(strWhere, " [item_type],[item_add_time] DESC ", pageSize, currentIndex, out recordCount);
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
        public ObservableCollection<PfmIaeItemsMDL> OSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("item_id");
            sb.Append(",item_add_time");
            sb.Append(",item_status");
            sb.Append(",item_type");
            sb.Append(",item_name");
            sb.Append(",item_description");
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
        public ObservableCollection<PfmIaeItemsMDL> OSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = " [item_type],[item_add_time] DESC ";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            ObservableCollection<PfmIaeItemsMDL> list = new ObservableCollection<PfmIaeItemsMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_iae_items where {1} order by {2} limit {3} offset {4}";
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
