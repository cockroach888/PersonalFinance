// =================================================================== 
// 产品（PFM.DawnXZ.Library.SqlServerDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：PfmDictionaryDAL.cs
// 项目名称：请更改为实际项目名称
// 创建时间：2012年08月06日 16:56:04
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
    /// 数据访问层PfmDictionary
    /// </summary>
    public partial class PfmDictionaryDAL : IPfmDictionaryDAL, SQLitePaging<PfmDictionaryMDL>
    {

        #region 构造函数

        /// <summary>
        /// 数据层实例化
        /// </summary>
        public PfmDictionaryDAL()
        { }

        #endregion

        #region -----------实例化接口函数-----------

        #region 添加

        /// <summary>
        /// 向数据表PfmDictionary中插入一条新记录
        /// </summary>
        /// <param name="pfmDictionary">PfmDictionary实体对象</param>
        /// <returns></returns>
        public int Insert(PfmDictionaryMDL pfmDictionary)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into ");
            sb.Append("pfm_dictionary");
            sb.Append("(");
            sb.Append("dict_time");
            sb.Append(",");
            sb.Append("dict_state");
            sb.Append(",");
            sb.Append("dict_type");
            sb.Append(",");
            sb.Append("dict_name");
            sb.Append(",");
            sb.Append("dict_mark");
            sb.Append(",");
            sb.Append("dict_memo");
            sb.Append(")");
            sb.Append(" values");
            sb.Append("(");
            sb.Append("@DictTime");
            sb.Append(",");
            sb.Append("@DictState");
            sb.Append(",");
            sb.Append("@DictType");
            sb.Append(",");
            sb.Append("@DictName");
            sb.Append(",");
            sb.Append("@DictMark");
            sb.Append(",");
            sb.Append("@DictMemo");
            sb.Append(")");
            int res;
            SQLiteParameter[] param ={
				new SQLiteParameter("@DictTime",DbType.DateTime),
				new SQLiteParameter("@DictState",DbType.Byte),
				new SQLiteParameter("@DictType",DbType.Byte),
				new SQLiteParameter("@DictName",DbType.String,50),
				new SQLiteParameter("@DictMark",DbType.Byte),
				new SQLiteParameter("@DictMemo",DbType.String,200)
			};
            param[0].Value = pfmDictionary.DictTime;
            param[1].Value = pfmDictionary.DictState;
            param[2].Value = pfmDictionary.DictType;
            param[3].Value = pfmDictionary.DictName;
            param[4].Value = pfmDictionary.DictMark;
            param[5].Value = pfmDictionary.DictMemo;
            res = SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, sb.ToString(), param);
            return res;
        }

        #endregion

        #region 修改

        /// <summary>
        /// 向数据表PfmDictionary修改一条记录
        /// </summary>
        /// <param name="pfmDictionary">pfmDictionary实体对象</param>
        /// <returns></returns>
        public int Update(PfmDictionaryMDL pfmDictionary)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update ");
            sb.Append("pfm_dictionary");
            sb.Append(" set ");
            sb.Append("dict_time=@DictTime");
            sb.Append(",");
            sb.Append("dict_state=@DictState");
            sb.Append(",");
            sb.Append("dict_type=@DictType");
            sb.Append(",");
            sb.Append("dict_name=@DictName");
            sb.Append(",");
            sb.Append("dict_mark=@DictMark");
            sb.Append(",");
            sb.Append("dict_memo=@DictMemo");
            sb.Append(" where ");
            sb.Append("dict_id=@DictId");
            SQLiteParameter[] param ={
				new SQLiteParameter("@DictId",DbType.Int32,8),
				new SQLiteParameter("@DictTime",DbType.DateTime),
				new SQLiteParameter("@DictState",DbType.Byte),
				new SQLiteParameter("@DictType",DbType.Byte),
				new SQLiteParameter("@DictName",DbType.String,50),
				new SQLiteParameter("@DictMark",DbType.Byte),
				new SQLiteParameter("@DictMemo",DbType.String,200)
			};
            param[0].Value = pfmDictionary.DictId;
            param[1].Value = pfmDictionary.DictTime;
            param[2].Value = pfmDictionary.DictState;
            param[3].Value = pfmDictionary.DictType;
            param[4].Value = pfmDictionary.DictName;
            param[5].Value = pfmDictionary.DictMark;
            param[6].Value = pfmDictionary.DictMemo;
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, sb.ToString(), param);
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除数据表PfmDictionary中的一条记录
        /// </summary>
        /// <param name="dictId"></param>
        /// <returns></returns>
        public int Delete(long dictId)
        {
            string cmdSql = "delete from pfm_dictionary where dict_id=@DictId";
            SQLiteParameter[] param ={
				new SQLiteParameter("@DictId",DbType.Int32)
			};
            param[0].Value = dictId;
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, cmdSql, param);
        }
        /// <summary>
        /// 删除数据表PfmDictionary中的一条记录
        /// </summary>
        /// <param name="pfmDictionary">pfmDictionary实体对象</param>
        /// <returns></returns>
        public int Delete(PfmDictionaryMDL pfmDictionary)
        {
            string cmdSql = "delete from pfm_dictionary where dict_id=@DictId";
            SQLiteParameter[] param ={
				new SQLiteParameter("@DictId",DbType.Int32)
			};
            param[0].Value = pfmDictionary.DictId;
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, cmdSql, param);
        }

        #endregion

        #region 实体对象

        /// <summary>
        /// 得到PfmDictionary实体对象
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>PfmDictionary实体对象</returns>
        public PfmDictionaryMDL Select(DataRow row)
        {
            PfmDictionaryMDL obj = new PfmDictionaryMDL();
            if (row != null)
            {
                try
                {
                    obj.DictId = (long)row["dict_id"];
                }
                catch { }
                try
                {
                    obj.DictTime = ((row["dict_time"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["dict_time"]);
                }
                catch { }
                try
                {
                    obj.DictState = ((row["dict_state"]) == DBNull.Value) ? Convert.ToByte(0) : Convert.ToByte(row["dict_state"]);
                }
                catch { }
                try
                {
                    obj.DictType = ((row["dict_type"]) == DBNull.Value) ? Convert.ToByte(0) : Convert.ToByte(row["dict_type"]);
                }
                catch { }
                try
                {
                    obj.DictName = row["dict_name"].ToString();
                }
                catch { }
                try
                {
                    obj.DictMark = ((row["dict_mark"]) == DBNull.Value) ? Convert.ToByte(0) : Convert.ToByte(row["dict_mark"]);
                }
                catch { }
                try
                {
                    obj.DictMemo = row["dict_memo"].ToString();
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
        /// 得到PfmDictionary实体对象
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>PfmDictionarys实体对象</returns>
        public PfmDictionaryMDL Select(IDataReader dr)
        {
            PfmDictionaryMDL obj = new PfmDictionaryMDL();
            try
            {
                obj.DictId = (long)dr["dict_id"];
            }
            catch { }
            try
            {
                obj.DictTime = ((dr["dict_time"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["dict_time"]);
            }
            catch { }
            try
            {
                obj.DictState = ((dr["dict_state"]) == DBNull.Value) ? Convert.ToByte(0) : Convert.ToByte(dr["dict_state"]);
            }
            catch { }
            try
            {
                obj.DictType = ((dr["dict_type"]) == DBNull.Value) ? Convert.ToByte(0) : Convert.ToByte(dr["dict_type"]);
            }
            catch { }
            try
            {
                obj.DictName = dr["dict_name"].ToString();
            }
            catch { }
            try
            {
                obj.DictMark = ((dr["dict_mark"]) == DBNull.Value) ? Convert.ToByte(0) : Convert.ToByte(dr["dict_mark"]);
            }
            catch { }
            try
            {
                obj.DictMemo = dr["dict_memo"].ToString();
            }
            catch { }
            return obj;
        }
        /// <summary>
        /// 根据ID,返回一个PfmDictionary实体对象
        /// </summary>
        /// <param name="dictId"></param>
        /// <returns>PfmDictionary实体对象</returns>
        public PfmDictionaryMDL Select(long dictId)
        {
            string cmdSql = "select * from pfm_dictionary where dict_id=@DictId";
            PfmDictionaryMDL obj = null;
            SQLiteParameter[] param ={
			    new SQLiteParameter("@DictId",DbType.Int32)
			};
            param[0].Value = dictId;
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
        /// 得到数据表PfmDictionary所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public List<PfmDictionaryMDL> LSelect()
        {
            return this.LSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmDictionary满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public List<PfmDictionaryMDL> LSelect(string where)
        {
            return this.LSelect(where, " [dict_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmDictionary满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public List<PfmDictionaryMDL> LSelect(string where, string sortField)
        {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = "dict_id";
            string cmdSql = string.Format("select * from pfm_dictionary where {0} order by {1}", where, sortField);
            List<PfmDictionaryMDL> list = new List<PfmDictionaryMDL>();
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
        /// 得到数据表PfmDictionary满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public List<PfmDictionaryMDL> LSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            List<PfmDictionaryMDL> list = new List<PfmDictionaryMDL>();
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
        /// 得到数据表PfmDictionary所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public IList<PfmDictionaryMDL> ISelect()
        {
            return this.ISelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmDictionary满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public IList<PfmDictionaryMDL> ISelect(string where)
        {
            return this.ISelect(where, " [dict_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmDictionary满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public IList<PfmDictionaryMDL> ISelect(string where, string sortField)
        {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = "dict_id";
            string cmdSql = string.Format("select * from pfm_dictionary where {0} order by {1}", where, sortField);
            IList<PfmDictionaryMDL> list = new List<PfmDictionaryMDL>();
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
        /// 得到数据表PfmDictionary满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public IList<PfmDictionaryMDL> ISelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            IList<PfmDictionaryMDL> list = new List<PfmDictionaryMDL>();
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
        /// 得到数据表PfmDictionary所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public Collection<PfmDictionaryMDL> CSelect()
        {
            return this.CSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmDictionary满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public Collection<PfmDictionaryMDL> CSelect(string where)
        {
            return this.CSelect(where, " [dict_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmDictionary满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public Collection<PfmDictionaryMDL> CSelect(string where, string sortField)
        {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = "dict_id";
            string cmdSql = string.Format("select * from pfm_dictionary where {0} order by {1}", where, sortField);
            Collection<PfmDictionaryMDL> list = new Collection<PfmDictionaryMDL>();
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
        /// 得到数据表PfmDictionary满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public Collection<PfmDictionaryMDL> CSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            Collection<PfmDictionaryMDL> list = new Collection<PfmDictionaryMDL>();
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
        /// 得到数据表PfmDictionary所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmDictionaryMDL> OSelect()
        {
            return this.OSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmDictionary满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmDictionaryMDL> OSelect(string where)
        {
            return this.OSelect(where, " [dict_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmDictionary满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmDictionaryMDL> OSelect(string where, string sortField)
        {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = "dict_id";
            string cmdSql = string.Format("select * from pfm_dictionary where {0} order by {1}", where, sortField);
            ObservableCollection<PfmDictionaryMDL> list = new ObservableCollection<PfmDictionaryMDL>();
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
        /// 得到数据表PfmDictionary满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmDictionaryMDL> OSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            ObservableCollection<PfmDictionaryMDL> list = new ObservableCollection<PfmDictionaryMDL>();
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
        /// 得到数据表PfmDictionary满足查询条件的记录数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="recordCount">记录数</param>
        public void Select(string where, out int recordCount)
        {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            string cmdSql = "select count(-1) from pfm_dictionary where @where";
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
        /// <param name="dictId"></param>
        /// <returns>存在/不存在</returns>
        public bool Exists(long dictId)
        {
            string cmdSql = "select count(-1) from pfm_dictionary where dict_id=@DictId";
            SQLiteParameter[] param ={
            	new SQLiteParameter("@DictId",DbType.Int32)
            };
            param[0].Value = dictId;
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
            string cmdSql = @"select count(-1) from pfm_dictionary where @where";
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
        public List<PfmDictionaryMDL> LSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return LSelectPaging(null, "dict_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public List<PfmDictionaryMDL> LSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return LSelectPaging(strWhere, "dict_time desc", pageSize, currentIndex, out recordCount);
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
        public List<PfmDictionaryMDL> LSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("dict_id");
            sb.Append(",dict_time");
            sb.Append(",dict_state");
            sb.Append(",dict_type");
            sb.Append(",dict_name");
            sb.Append(",dict_mark");
            sb.Append(",dict_memo");
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
        public List<PfmDictionaryMDL> LSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "dict_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            List<PfmDictionaryMDL> list = new List<PfmDictionaryMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_dictionary where {1} order by {2} limit {3} offset {4}";
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
        public IList<PfmDictionaryMDL> ISelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return ISelectPaging(null, "dict_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public IList<PfmDictionaryMDL> ISelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return ISelectPaging(strWhere, "dict_time desc", pageSize, currentIndex, out recordCount);
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
        public IList<PfmDictionaryMDL> ISelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("dict_id");
            sb.Append(",dict_time");
            sb.Append(",dict_state");
            sb.Append(",dict_type");
            sb.Append(",dict_name");
            sb.Append(",dict_mark");
            sb.Append(",dict_memo");
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
        public IList<PfmDictionaryMDL> ISelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "dict_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            IList<PfmDictionaryMDL> list = new List<PfmDictionaryMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_dictionary where {1} order by {2} limit {3} offset {4}";
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
        public Collection<PfmDictionaryMDL> CSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return CSelectPaging(null, "dict_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public Collection<PfmDictionaryMDL> CSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return CSelectPaging(strWhere, "dict_time desc", pageSize, currentIndex, out recordCount);
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
        public Collection<PfmDictionaryMDL> CSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("dict_id");
            sb.Append(",dict_time");
            sb.Append(",dict_state");
            sb.Append(",dict_type");
            sb.Append(",dict_name");
            sb.Append(",dict_mark");
            sb.Append(",dict_memo");
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
        public Collection<PfmDictionaryMDL> CSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "dict_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            Collection<PfmDictionaryMDL> list = new Collection<PfmDictionaryMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_dictionary where {1} order by {2} limit {3} offset {4}";
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
        public ObservableCollection<PfmDictionaryMDL> OSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return OSelectPaging(null, "dict_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public ObservableCollection<PfmDictionaryMDL> OSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return OSelectPaging(strWhere, "dict_time desc", pageSize, currentIndex, out recordCount);
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
        public ObservableCollection<PfmDictionaryMDL> OSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("dict_id");
            sb.Append(",dict_time");
            sb.Append(",dict_state");
            sb.Append(",dict_type");
            sb.Append(",dict_name");
            sb.Append(",dict_mark");
            sb.Append(",dict_memo");
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
        public ObservableCollection<PfmDictionaryMDL> OSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "dict_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            ObservableCollection<PfmDictionaryMDL> list = new ObservableCollection<PfmDictionaryMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_dictionary where {1} order by {2} limit {3} offset {4}";
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
