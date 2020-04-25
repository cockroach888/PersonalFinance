// =================================================================== 
// 产品（PFM.DawnXZ.Library.SqlServerDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：PfmErrorDAL.cs
// 项目名称：请更改为实际项目名称
// 创建时间：2012年08月06日 16:21:42
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
    /// 数据访问层PfmError
    /// </summary>
    public partial class PfmErrorDAL : IPfmErrorDAL, SQLitePaging<PfmErrorMDL>
    {

        #region ----------构造函数----------

        /// <summary>
        /// 数据层实例化
        /// </summary>
        public PfmErrorDAL()
        { }

        #endregion ----------构造函数----------

        #region -----------实例化接口函数-----------

        #region 添加

        /// <summary>
        /// 向数据表PfmError中插入一条新记录
        /// </summary>
        /// <param name="pfmError">PfmError实体对象</param>
        /// <returns></returns>
        public int Insert(PfmErrorMDL pfmError)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into ");
            sb.Append("pfm_error");
            sb.Append("(");
            sb.Append("err_time");
            sb.Append(",");
            sb.Append("err_page");
            sb.Append(",");
            sb.Append("err_message");
            sb.Append(",");
            sb.Append("err_target_site");
            sb.Append(",");
            sb.Append("err_stack_trace");
            sb.Append(",");
            sb.Append("err_source");
            sb.Append(",");
            sb.Append("err_ip");
            sb.Append(",");
            sb.Append("err_name");
            sb.Append(")");
            sb.Append(" values");
            sb.Append("(");
            sb.Append("@ErrTime");
            sb.Append(",");
            sb.Append("@ErrPage");
            sb.Append(",");
            sb.Append("@ErrMessage");
            sb.Append(",");
            sb.Append("@ErrTargetSite");
            sb.Append(",");
            sb.Append("@ErrStackTrace");
            sb.Append(",");
            sb.Append("@ErrSource");
            sb.Append(",");
            sb.Append("@ErrIp");
            sb.Append(",");
            sb.Append("@ErrName");
            sb.Append(")");
            SQLiteParameter[] param ={
				new SQLiteParameter("@ErrTime",DbType.DateTime),
				new SQLiteParameter("@ErrPage",DbType.String,2000),
				new SQLiteParameter("@ErrMessage",DbType.String,4000),
				new SQLiteParameter("@ErrTargetSite",DbType.String,8000),
				new SQLiteParameter("@ErrStackTrace",DbType.String,8000),
				new SQLiteParameter("@ErrSource",DbType.String,8000),
				new SQLiteParameter("@ErrIp",DbType.String,300),
				new SQLiteParameter("@ErrName",DbType.String,20)
			};
            param[0].Value = pfmError.ErrTime;
            param[1].Value = pfmError.ErrPage;
            param[2].Value = pfmError.ErrMessage;
            param[3].Value = pfmError.ErrTargetSite;
            param[4].Value = pfmError.ErrStackTrace;
            param[5].Value = pfmError.ErrSource;
            param[6].Value = pfmError.ErrIp;
            param[7].Value = pfmError.ErrName;
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, sb.ToString(), param);
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除数据表PfmError中的一条记录
        /// </summary>
        /// <param name="errId"></param>
        /// <returns></returns>
        public int Delete(long errId)
        {
            string cmdSql = @"delete from pfm_error where err_id = @ErrId";
            SQLiteParameter[] param ={
				new SQLiteParameter("@ErrId",DbType.Int32)
			};
            param[0].Value = errId;
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, cmdSql, param);
        }
        /// <summary>
        /// 删除数据表PfmError中的所有记录
        /// </summary>
        /// <returns></returns>
        public int DeleteAll()
        {
            string cmdSql = @"delete from pfm_error";
            //string cmdSql=@"truncate table pfm_error";
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, cmdSql);
        }

        #endregion

        #region 实体对象

        /// <summary>
        /// 得到PfmError实体对象
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>PfmError实体对象</returns>
        public PfmErrorMDL Select(DataRow row)
        {
            PfmErrorMDL obj = new PfmErrorMDL();
            if (row != null)
            {
                try
                {
                    obj.ErrId = (long)row["err_id"];
                }
                catch { }
                try
                {
                    obj.ErrTime = ((row["err_time"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["err_time"]);
                }
                catch { }
                try
                {
                    obj.ErrPage = row["err_page"].ToString();
                }
                catch { }
                try
                {
                    obj.ErrMessage = row["err_message"].ToString();
                }
                catch { }
                try
                {
                    obj.ErrTargetSite = row["err_target_site"].ToString();
                }
                catch { }
                try
                {
                    obj.ErrStackTrace = row["err_stack_trace"].ToString();
                }
                catch { }
                try
                {
                    obj.ErrSource = row["err_source"].ToString();
                }
                catch { }
                try
                {
                    obj.ErrIp = row["err_ip"].ToString();
                }
                catch { }
                try
                {
                    obj.ErrName = row["err_name"].ToString();
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
        /// 得到PfmError实体对象
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>PfmError实体对象</returns>
        public PfmErrorMDL Select(IDataReader dr)
        {
            PfmErrorMDL obj = new PfmErrorMDL();
            try
            {
                obj.ErrId = (long)dr["err_id"];
            }
            catch { }
            try
            {
                obj.ErrTime = ((dr["err_time"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["err_time"]);
            }
            catch { }
            try
            {
                obj.ErrPage = dr["err_page"].ToString();
            }
            catch { }
            try
            {
                obj.ErrMessage = dr["err_message"].ToString();
            }
            catch { }
            try
            {
                obj.ErrTargetSite = dr["err_target_site"].ToString();
            }
            catch { }
            try
            {
                obj.ErrStackTrace = dr["err_stack_trace"].ToString();
            }
            catch { }
            try
            {
                obj.ErrSource = dr["err_source"].ToString();
            }
            catch { }
            try
            {
                obj.ErrIp = dr["err_ip"].ToString();
            }
            catch { }
            try
            {
                obj.ErrName = dr["err_name"].ToString();
            }
            catch { }
            return obj;
        }

        /// <summary>
        /// 根据ID,返回一个PfmError实体对象
        /// </summary>
        /// <param name="errId"></param>
        /// <returns>PfmError实体对象</returns>
        public PfmErrorMDL Select(long errId)
        {
            PfmErrorMDL obj = null;
            string cmdSql = @"select * from pfm_error where err_id = @ErrId";
            SQLiteParameter[] param ={
			    new SQLiteParameter("@ErrId",DbType.Int32)
			};
            param[0].Value = errId;
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
        /// 得到数据表PfmError所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public List<PfmErrorMDL> LSelect()
        {
            return this.LSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmError满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public List<PfmErrorMDL> LSelect(string where)
        {
            return this.LSelect(where, " [err_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmError满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public List<PfmErrorMDL> LSelect(string where, string sortField)
        {
            List<PfmErrorMDL> list = new List<PfmErrorMDL>();
            string cmdSql = @"select * from pfm_error where @where order by @sortField";
            SQLiteParameter[] param ={
				new SQLiteParameter("@where",DbType.String,8000),
				new SQLiteParameter("@sortField",DbType.String,100)
			};
            param[0].Value = string.IsNullOrEmpty(where) ? "1=1" : where;
            param[1].Value = string.IsNullOrEmpty(sortField) ? "err_id" : sortField;
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
        /// 得到数据表PfmError满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public List<PfmErrorMDL> LSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            List<PfmErrorMDL> list = new List<PfmErrorMDL>();
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
        /// 得到数据表PfmError所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public IList<PfmErrorMDL> ISelect()
        {
            return this.ISelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmError满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public IList<PfmErrorMDL> ISelect(string where)
        {
            return this.ISelect(where, " [err_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmError满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public IList<PfmErrorMDL> ISelect(string where, string sortField)
        {
            IList<PfmErrorMDL> list = new List<PfmErrorMDL>();
            string cmdSql = @"select * from pfm_error where @where order by @sortField";
            SQLiteParameter[] param ={
				new SQLiteParameter("@where",DbType.String,8000),
				new SQLiteParameter("@sortField",DbType.String,100)
			};
            param[0].Value = string.IsNullOrEmpty(where) ? "1=1" : where;
            param[1].Value = string.IsNullOrEmpty(sortField) ? "err_id" : sortField;
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
        /// 得到数据表PfmError满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public IList<PfmErrorMDL> ISelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            IList<PfmErrorMDL> list = new List<PfmErrorMDL>();
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
        /// 得到数据表PfmError所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public Collection<PfmErrorMDL> CSelect()
        {
            return this.CSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmError满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public Collection<PfmErrorMDL> CSelect(string where)
        {
            return this.CSelect(where, " [err_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmError满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public Collection<PfmErrorMDL> CSelect(string where, string sortField)
        {
            Collection<PfmErrorMDL> list = new Collection<PfmErrorMDL>();
            string cmdSql = @"select * from pfm_error where @where order by @sortField";
            SQLiteParameter[] param ={
				new SQLiteParameter("@where",DbType.String,8000),
				new SQLiteParameter("@sortField",DbType.String,100)
			};
            param[0].Value = string.IsNullOrEmpty(where) ? "1=1" : where;
            param[1].Value = string.IsNullOrEmpty(sortField) ? "err_id" : sortField;
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
        /// 得到数据表PfmError满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public Collection<PfmErrorMDL> CSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            Collection<PfmErrorMDL> list = new Collection<PfmErrorMDL>();
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
        /// 得到数据表PfmError所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmErrorMDL> OSelect()
        {
            return this.OSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmError满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmErrorMDL> OSelect(string where)
        {
            return this.OSelect(where, " [err_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmError满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmErrorMDL> OSelect(string where, string sortField)
        {
            ObservableCollection<PfmErrorMDL> list = new ObservableCollection<PfmErrorMDL>();
            string cmdSql = @"select * from pfm_error where @where order by @sortField";
            SQLiteParameter[] param ={
				new SQLiteParameter("@where",DbType.String,8000),
				new SQLiteParameter("@sortField",DbType.String,100)
			};
            param[0].Value = string.IsNullOrEmpty(where) ? "1=1" : where;
            param[1].Value = string.IsNullOrEmpty(sortField) ? "err_id" : sortField;
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
        /// 得到数据表PfmError满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmErrorMDL> OSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            ObservableCollection<PfmErrorMDL> list = new ObservableCollection<PfmErrorMDL>();
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
        /// 得到数据表PfmError满足查询条件的记录数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="recordCount">记录数</param>
        public void Select(string where, out int recordCount)
        {
            string cmdSql = @"select count(-1) from pfm_error where @where";
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
        /// <param name="errId"></param>
        /// <returns>存在/不存在</returns>
        public bool Exists(long errId)
        {
            string cmdSql = @"select count(-1) from pfm_error where err_id = @ErrId";
            SQLiteParameter[] param ={
            	new SQLiteParameter("@ErrId",DbType.Int32)
            };
            param[0].Value = errId;
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
            string cmdSql = @"select count(-1) from pfm_error where @where";
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
        public List<PfmErrorMDL> LSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return LSelectPaging(null, "err_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public List<PfmErrorMDL> LSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return LSelectPaging(strWhere, "err_time desc", pageSize, currentIndex, out recordCount);
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
        public List<PfmErrorMDL> LSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("err_id");
            sb.Append(",err_time");
            sb.Append(",err_page");
            sb.Append(",err_message");
            sb.Append(",err_target_site");
            sb.Append(",err_stack_trace");
            sb.Append(",err_source");
            sb.Append(",err_ip");
            sb.Append(",err_name");
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
        public List<PfmErrorMDL> LSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "err_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            List<PfmErrorMDL> list = new List<PfmErrorMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_error where {1} order by {2} limit {3} offset {4}";
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
        public IList<PfmErrorMDL> ISelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return ISelectPaging(null, "err_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public IList<PfmErrorMDL> ISelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return ISelectPaging(strWhere, "err_time desc", pageSize, currentIndex, out recordCount);
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
        public IList<PfmErrorMDL> ISelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("err_id");
            sb.Append(",err_time");
            sb.Append(",err_page");
            sb.Append(",err_message");
            sb.Append(",err_target_site");
            sb.Append(",err_stack_trace");
            sb.Append(",err_source");
            sb.Append(",err_ip");
            sb.Append(",err_name");
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
        public IList<PfmErrorMDL> ISelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "err_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            IList<PfmErrorMDL> list = new List<PfmErrorMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_error where {1} order by {2} limit {3} offset {4}";
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
        public Collection<PfmErrorMDL> CSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return CSelectPaging(null, "err_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public Collection<PfmErrorMDL> CSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return CSelectPaging(strWhere, "err_time desc", pageSize, currentIndex, out recordCount);
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
        public Collection<PfmErrorMDL> CSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("err_id");
            sb.Append(",err_time");
            sb.Append(",err_page");
            sb.Append(",err_message");
            sb.Append(",err_target_site");
            sb.Append(",err_stack_trace");
            sb.Append(",err_source");
            sb.Append(",err_ip");
            sb.Append(",err_name");
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
        public Collection<PfmErrorMDL> CSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "err_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            Collection<PfmErrorMDL> list = new Collection<PfmErrorMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_error where {1} order by {2} limit {3} offset {4}";
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
        public ObservableCollection<PfmErrorMDL> OSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return OSelectPaging(null, "err_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public ObservableCollection<PfmErrorMDL> OSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return OSelectPaging(strWhere, "err_time desc", pageSize, currentIndex, out recordCount);
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
        public ObservableCollection<PfmErrorMDL> OSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("err_id");
            sb.Append(",err_time");
            sb.Append(",err_page");
            sb.Append(",err_message");
            sb.Append(",err_target_site");
            sb.Append(",err_stack_trace");
            sb.Append(",err_source");
            sb.Append(",err_ip");
            sb.Append(",err_name");
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
        public ObservableCollection<PfmErrorMDL> OSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "err_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            ObservableCollection<PfmErrorMDL> list = new ObservableCollection<PfmErrorMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_error where {1} order by {2} limit {3} offset {4}";
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
