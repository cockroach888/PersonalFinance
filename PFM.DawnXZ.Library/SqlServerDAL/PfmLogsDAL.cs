// =================================================================== 
// 产品（PFM.DawnXZ.Library.SqlServerDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：PfmLogsDAL.cs
// 项目名称：请更改为实际项目名称
// 创建时间：2012年08月06日 16:22:12
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
    /// 数据访问层PfmLogs
    /// </summary>
    public partial class PfmLogsDAL : IPfmLogsDAL, SQLitePaging<PfmLogsMDL>
    {

        #region ----------构造函数----------

        /// <summary>
        /// 数据层实例化
        /// </summary>
        public PfmLogsDAL()
        { }

        #endregion ----------构造函数----------

        #region -----------实例化接口函数-----------

        #region 添加

        /// <summary>
        /// 向数据表PfmLogs中插入一条新记录
        /// </summary>
        /// <param name="pfmLogs">PfmLogs实体对象</param>
        /// <returns></returns>
        public int Insert(PfmLogsMDL pfmLogs)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into ");
            sb.Append("pfm_logs");
            sb.Append("(");
            sb.Append("log_time");
            sb.Append(",");
            sb.Append("log_table");
            sb.Append(",");
            sb.Append("log_action");
            sb.Append(",");
            sb.Append("log_remark");
            sb.Append(",");
            sb.Append("log_uname");
            sb.Append(")");
            sb.Append(" values");
            sb.Append("(");
            sb.Append("@LogTime");
            sb.Append(",");
            sb.Append("@LogTable");
            sb.Append(",");
            sb.Append("@LogAction");
            sb.Append(",");
            sb.Append("@LogRemark");
            sb.Append(",");
            sb.Append("@LogUname");
            sb.Append(")");
            SQLiteParameter[] param ={
				new SQLiteParameter("@LogTime",DbType.DateTime),
				new SQLiteParameter("@LogTable",DbType.String,100),
				new SQLiteParameter("@LogAction",DbType.String,8000),
				new SQLiteParameter("@LogRemark",DbType.String,8000),
				new SQLiteParameter("@LogUname",DbType.String,20)
			};
            param[0].Value = pfmLogs.LogTime;
            param[1].Value = pfmLogs.LogTable;
            param[2].Value = pfmLogs.LogAction;
            param[3].Value = pfmLogs.LogRemark;
            param[4].Value = pfmLogs.LogUname;
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, sb.ToString(), param);
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除数据表PfmLogs中的一条记录
        /// </summary>
        /// <param name="logId"></param>
        /// <returns></returns>
        public int Delete(long logId)
        {
            string cmdSql = @"delete from pfm_logs where log_id = @LogId";
            SQLiteParameter[] param ={
				new SQLiteParameter("@LogId",DbType.Int32)
			};
            param[0].Value = logId;
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, cmdSql, param);
        }
        /// <summary>
        /// 删除数据表PfmLogs中的所有记录
        /// </summary>
        /// <returns></returns>
        public int DeleteAll()
        {
            string cmdSql = @"delete from pfm_logs";
            //string cmdSql=@"truncate table pfm_logs";
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, cmdSql);
        }

        #endregion

        #region 实体对象

        /// <summary>
        /// 得到PfmLogs实体对象
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>PfmLogs实体对象</returns>
        public PfmLogsMDL Select(DataRow row)
        {
            PfmLogsMDL obj = new PfmLogsMDL();
            if (row != null)
            {
                try
                {
                    obj.LogId = (long)row["log_id"];
                }
                catch { }
                try
                {
                    obj.LogTime = ((row["log_time"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["log_time"]);
                }
                catch { }
                try
                {
                    obj.LogTable = row["log_table"].ToString();
                }
                catch { }
                try
                {
                    obj.LogAction = row["log_action"].ToString();
                }
                catch { }
                try
                {
                    obj.LogRemark = row["log_remark"].ToString();
                }
                catch { }
                try
                {
                    obj.LogUname = row["log_uname"].ToString();
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
        /// 得到PfmLogs实体对象
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>PfmLogs实体对象</returns>
        public PfmLogsMDL Select(IDataReader dr)
        {
            PfmLogsMDL obj = new PfmLogsMDL();
            try
            {
                obj.LogId = (long)dr["log_id"];
            }
            catch { }
            try
            {
                obj.LogTime = ((dr["log_time"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["log_time"]);
            }
            catch { }
            try
            {
                obj.LogTable = dr["log_table"].ToString();
            }
            catch { }
            try
            {
                obj.LogAction = dr["log_action"].ToString();
            }
            catch { }
            try
            {
                obj.LogRemark = dr["log_remark"].ToString();
            }
            catch { }
            try
            {
                obj.LogUname = dr["log_uname"].ToString();
            }
            catch { }
            return obj;
        }

        /// <summary>
        /// 根据ID,返回一个PfmLogs实体对象
        /// </summary>
        /// <param name="logId"></param>
        /// <returns>PfmLogs实体对象</returns>
        public PfmLogsMDL Select(long logId)
        {
            PfmLogsMDL obj = null;
            string cmdSql = @"select * from pfm_logs where log_id = @LogId";
            SQLiteParameter[] param ={
			    new SQLiteParameter("@LogId",DbType.Int32)
			};
            param[0].Value = logId;
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
        /// 得到数据表PfmLogs所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public List<PfmLogsMDL> LSelect()
        {
            return this.LSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmLogs满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public List<PfmLogsMDL> LSelect(string where)
        {
            return this.LSelect(where, " [log_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmLogs满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public List<PfmLogsMDL> LSelect(string where, string sortField)
        {
            List<PfmLogsMDL> list = new List<PfmLogsMDL>();
            string cmdSql = @"select * from pfm_logs where @where order by @sortField";
            SQLiteParameter[] param ={
				new SQLiteParameter("@where",DbType.String,8000),
				new SQLiteParameter("@sortField",DbType.String,100)
			};
            param[0].Value = string.IsNullOrEmpty(where) ? "1=1" : where;
            param[1].Value = string.IsNullOrEmpty(sortField) ? "log_id" : sortField;
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, cmdSql, param))
            {
                while (dr.Read())
                {
                    list.Add(this.Select(dr));
                }
            }
            return list;
        }
        /// <summary>
        /// 得到数据表PfmLogs满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public List<PfmLogsMDL> LSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            List<PfmLogsMDL> list = new List<PfmLogsMDL>();
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
        /// 得到数据表PfmLogs所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public IList<PfmLogsMDL> ISelect()
        {
            return this.ISelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmLogs满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public IList<PfmLogsMDL> ISelect(string where)
        {
            return this.ISelect(where, " [log_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmLogs满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public IList<PfmLogsMDL> ISelect(string where, string sortField)
        {
            IList<PfmLogsMDL> list = new List<PfmLogsMDL>();
            string cmdSql = @"select * from pfm_logs where @where order by @sortField";
            SQLiteParameter[] param ={
				new SQLiteParameter("@where",DbType.String,8000),
				new SQLiteParameter("@sortField",DbType.String,100)
			};
            param[0].Value = string.IsNullOrEmpty(where) ? "1=1" : where;
            param[1].Value = string.IsNullOrEmpty(sortField) ? "log_id" : sortField;
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, cmdSql, param))
            {
                while (dr.Read())
                {
                    list.Add(this.Select(dr));
                }
            }
            return list;
        }
        /// <summary>
        /// 得到数据表PfmLogs满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public IList<PfmLogsMDL> ISelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            IList<PfmLogsMDL> list = new List<PfmLogsMDL>();
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
        /// 得到数据表PfmLogs所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public Collection<PfmLogsMDL> CSelect()
        {
            return this.CSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmLogs满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public Collection<PfmLogsMDL> CSelect(string where)
        {
            return this.CSelect(where, " [log_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmLogs满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public Collection<PfmLogsMDL> CSelect(string where, string sortField)
        {
            Collection<PfmLogsMDL> list = new Collection<PfmLogsMDL>();
            string cmdSql = @"select * from pfm_logs where @where order by @sortField";
            SQLiteParameter[] param ={
				new SQLiteParameter("@where",DbType.String,8000),
				new SQLiteParameter("@sortField",DbType.String,100)
			};
            param[0].Value = string.IsNullOrEmpty(where) ? "1=1" : where;
            param[1].Value = string.IsNullOrEmpty(sortField) ? "log_id" : sortField;
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, cmdSql, param))
            {
                while (dr.Read())
                {
                    list.Add(this.Select(dr));
                }
            }
            return list;
        }
        /// <summary>
        /// 得到数据表PfmLogs满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public Collection<PfmLogsMDL> CSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            Collection<PfmLogsMDL> list = new Collection<PfmLogsMDL>();
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
        /// 得到数据表PfmLogs所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmLogsMDL> OSelect()
        {
            return this.OSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmLogs满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmLogsMDL> OSelect(string where)
        {
            return this.OSelect(where, " [log_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmLogs满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmLogsMDL> OSelect(string where, string sortField)
        {
            ObservableCollection<PfmLogsMDL> list = new ObservableCollection<PfmLogsMDL>();
            string cmdSql = @"select * from pfm_logs where @where order by @sortField";
            SQLiteParameter[] param ={
				new SQLiteParameter("@where",DbType.String,8000),
				new SQLiteParameter("@sortField",DbType.String,100)
			};
            param[0].Value = string.IsNullOrEmpty(where) ? "1=1" : where;
            param[1].Value = string.IsNullOrEmpty(sortField) ? "log_id" : sortField;
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, cmdSql, param))
            {
                while (dr.Read())
                {
                    list.Add(this.Select(dr));
                }
            }
            return list;
        }
        /// <summary>
        /// 得到数据表PfmLogs满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmLogsMDL> OSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            ObservableCollection<PfmLogsMDL> list = new ObservableCollection<PfmLogsMDL>();
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
        /// 得到数据表PfmLogs满足查询条件的记录数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="recordCount">记录数</param>
        public void Select(string where, out int recordCount)
        {
            string cmdSql = @"select count(-1) from pfm_logs where @where";
            SQLiteParameter[] param ={
			    new SQLiteParameter("@where",DbType.String,8000)
			};
            param[0].Value = string.IsNullOrEmpty(where) ? "1=1" : where;
            string tmpVal = SQLiteHelper.ExecuteScalar(Conn.SqlConn, CommandType.Text, cmdSql, param).ToString();
            int.TryParse(tmpVal, out recordCount);
        }
        /// <summary>
        /// 根据主键检测是否存在该条记录
        /// </summary>
        /// <param name="logId"></param>
        /// <returns>存在/不存在</returns>
        public bool Exists(long logId)
        {
            string cmdSql = @"select count(-1) from pfm_logs where log_id = @LogId";
            SQLiteParameter[] param ={
            	new SQLiteParameter("@LogId",DbType.Int32)
            };
            param[0].Value = logId;
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
            string cmdSql = @"select count(-1) from pfm_logs where @where";
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
        public List<PfmLogsMDL> LSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return LSelectPaging(null, "log_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public List<PfmLogsMDL> LSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return LSelectPaging(strWhere, "log_time desc", pageSize, currentIndex, out recordCount);
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
        public List<PfmLogsMDL> LSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("log_id");
            sb.Append(",log_time");
            sb.Append(",log_table");
            sb.Append(",log_action");
            sb.Append(",log_remark");
            sb.Append(",log_uname");
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
        public List<PfmLogsMDL> LSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "log_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            List<PfmLogsMDL> list = new List<PfmLogsMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_logs where {1} order by {2} limit {3} offset {4}";
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
        public IList<PfmLogsMDL> ISelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return ISelectPaging(null, "log_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public IList<PfmLogsMDL> ISelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return ISelectPaging(strWhere, "log_time desc", pageSize, currentIndex, out recordCount);
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
        public IList<PfmLogsMDL> ISelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("log_id");
            sb.Append(",log_time");
            sb.Append(",log_table");
            sb.Append(",log_action");
            sb.Append(",log_remark");
            sb.Append(",log_uname");
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
        public IList<PfmLogsMDL> ISelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "log_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            IList<PfmLogsMDL> list = new List<PfmLogsMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_logs where {1} order by {2} limit {3} offset {4}";
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
        public Collection<PfmLogsMDL> CSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return CSelectPaging(null, "log_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public Collection<PfmLogsMDL> CSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return CSelectPaging(strWhere, "log_time desc", pageSize, currentIndex, out recordCount);
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
        public Collection<PfmLogsMDL> CSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("log_id");
            sb.Append(",log_time");
            sb.Append(",log_table");
            sb.Append(",log_action");
            sb.Append(",log_remark");
            sb.Append(",log_uname");
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
        public Collection<PfmLogsMDL> CSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "log_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            Collection<PfmLogsMDL> list = new Collection<PfmLogsMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_logs where {1} order by {2} limit {3} offset {4}";
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
        public ObservableCollection<PfmLogsMDL> OSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return OSelectPaging(null, "log_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public ObservableCollection<PfmLogsMDL> OSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return OSelectPaging(strWhere, "log_time desc", pageSize, currentIndex, out recordCount);
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
        public ObservableCollection<PfmLogsMDL> OSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("log_id");
            sb.Append(",log_time");
            sb.Append(",log_table");
            sb.Append(",log_action");
            sb.Append(",log_remark");
            sb.Append(",log_uname");
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
        public ObservableCollection<PfmLogsMDL> OSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "log_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            ObservableCollection<PfmLogsMDL> list = new ObservableCollection<PfmLogsMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_logs where {1} order by {2} limit {3} offset {4}";
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
