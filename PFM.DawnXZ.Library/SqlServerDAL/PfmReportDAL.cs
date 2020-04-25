// =================================================================== 
// 产品（PFM.DawnXZ.Library.SqlServerDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：PfmReportDAL.cs
// 项目名称：请更改为实际项目名称
// 创建时间：2012年08月06日 16:52:13
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
    /// 数据访问层PfmReport
    /// </summary>
    public partial class PfmReportDAL : IPfmReportDAL, SQLitePaging<PfmReportMDL>
    {

        #region 构造函数

        /// <summary>
        /// 数据层实例化
        /// </summary>
        public PfmReportDAL()
        { }

        #endregion

        #region -----------实例化接口函数-----------

        #region 添加

        /// <summary>
        /// 向数据表PfmReport中插入一条新记录
        /// </summary>
        /// <param name="pfmReport">PfmReport实体对象</param>
        /// <returns></returns>
        public int Insert(PfmReportMDL pfmReport)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into ");
            sb.Append("pfm_report");
            sb.Append("(");
            sb.Append("dict_mark");
            sb.Append(",");
            sb.Append("rpt_time");
            sb.Append(",");
            sb.Append("rpt_date");
            sb.Append(",");
            sb.Append("rpt_state");
            sb.Append(",");
            sb.Append("rpt_name");
            sb.Append(",");
            sb.Append("rpt_memo");
            sb.Append(",");
            sb.Append("rpt_bk_fd01");
            sb.Append(",");
            sb.Append("rpt_bk_fd02");
            sb.Append(",");
            sb.Append("rpt_bk_fd03");
            sb.Append(",");
            sb.Append("rpt_bk_fd04");
            sb.Append(")");
            sb.Append(" values");
            sb.Append("(");
            sb.Append("@DictMark");
            sb.Append(",");
            sb.Append("@RptTime");
            sb.Append(",");
            sb.Append("@RptDate");
            sb.Append(",");
            sb.Append("@RptState");
            sb.Append(",");
            sb.Append("@RptName");
            sb.Append(",");
            sb.Append("@RptMemo");
            sb.Append(",");
            sb.Append("@RptBkFd01");
            sb.Append(",");
            sb.Append("@RptBkFd02");
            sb.Append(",");
            sb.Append("@RptBkFd03");
            sb.Append(",");
            sb.Append("@RptBkFd04");
            sb.Append(")");
            int res;
            SQLiteParameter[] param ={
				new SQLiteParameter("@DictMark",DbType.Byte),
				new SQLiteParameter("@RptTime",DbType.DateTime),
				new SQLiteParameter("@RptDate",DbType.DateTime),
				new SQLiteParameter("@RptState",DbType.Byte),
				new SQLiteParameter("@RptName",DbType.String,300),
				new SQLiteParameter("@RptMemo",DbType.String,2000),
				new SQLiteParameter("@RptBkFd01",DbType.Int32),
				new SQLiteParameter("@RptBkFd02",DbType.Byte),
				new SQLiteParameter("@RptBkFd03",DbType.String,50),
				new SQLiteParameter("@RptBkFd04",DbType.String,8000)
			};
            param[0].Value = pfmReport.DictMark;
            param[1].Value = pfmReport.RptTime;
            param[2].Value = pfmReport.RptDate;
            param[3].Value = pfmReport.RptState;
            param[4].Value = pfmReport.RptName;
            param[5].Value = pfmReport.RptMemo;
            param[6].Value = pfmReport.RptBkFd01;
            param[7].Value = pfmReport.RptBkFd02;
            param[8].Value = pfmReport.RptBkFd03;
            param[9].Value = pfmReport.RptBkFd04;
            res = SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, sb.ToString(), param);
            return res;
        }

        #endregion

        #region 修改

        /// <summary>
        /// 向数据表PfmReport修改一条记录
        /// </summary>
        /// <param name="pfmReport">pfmReport实体对象</param>
        /// <returns></returns>
        public int Update(PfmReportMDL pfmReport)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update ");
            sb.Append("pfm_report");
            sb.Append(" set ");
            sb.Append("dict_mark=@DictMark");
            sb.Append(",");
            sb.Append("rpt_time=@RptTime");
            sb.Append(",");
            sb.Append("rpt_date=@RptDate");
            sb.Append(",");
            sb.Append("rpt_state=@RptState");
            sb.Append(",");
            sb.Append("rpt_name=@RptName");
            sb.Append(",");
            sb.Append("rpt_memo=@RptMemo");
            sb.Append(",");
            sb.Append("rpt_bk_fd01=@RptBkFd01");
            sb.Append(",");
            sb.Append("rpt_bk_fd02=@RptBkFd02");
            sb.Append(",");
            sb.Append("rpt_bk_fd03=@RptBkFd03");
            sb.Append(",");
            sb.Append("rpt_bk_fd04=@RptBkFd04");
            sb.Append(" where ");
            sb.Append("rpt_id=@RptId");
            SQLiteParameter[] param ={
				new SQLiteParameter("@RptId",DbType.Int32,8),
				new SQLiteParameter("@DictMark",DbType.Byte),
				new SQLiteParameter("@RptTime",DbType.DateTime),
				new SQLiteParameter("@RptDate",DbType.DateTime),
				new SQLiteParameter("@RptState",DbType.Byte),
				new SQLiteParameter("@RptName",DbType.String,300),
				new SQLiteParameter("@RptMemo",DbType.String,2000),
				new SQLiteParameter("@RptBkFd01",DbType.Int32),
				new SQLiteParameter("@RptBkFd02",DbType.Byte),
				new SQLiteParameter("@RptBkFd03",DbType.String,50),
				new SQLiteParameter("@RptBkFd04",DbType.String,8000)
			};
            param[0].Value = pfmReport.RptId;
            param[1].Value = pfmReport.DictMark;
            param[2].Value = pfmReport.RptTime;
            param[3].Value = pfmReport.RptDate;
            param[4].Value = pfmReport.RptState;
            param[5].Value = pfmReport.RptName;
            param[6].Value = pfmReport.RptMemo;
            param[7].Value = pfmReport.RptBkFd01;
            param[8].Value = pfmReport.RptBkFd02;
            param[9].Value = pfmReport.RptBkFd03;
            param[10].Value = pfmReport.RptBkFd04;
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, sb.ToString(), param);
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除数据表PfmReport中的一条记录
        /// </summary>
        /// <param name="rptId"></param>
        /// <returns></returns>
        public int Delete(long rptId)
        {
            string cmdSql = "delete from pfm_report where rpt_id=@RptId";
            SQLiteParameter[] param ={
				new SQLiteParameter("@RptId",DbType.Int32)
			};
            param[0].Value = rptId;
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, cmdSql, param);
        }
        /// <summary>
        /// 删除数据表PfmReport中的一条记录
        /// </summary>
        /// <param name="pfmReport">pfmReport实体对象</param>
        /// <returns></returns>
        public int Delete(PfmReportMDL pfmReport)
        {
            string cmdSql = "delete from pfm_report where rpt_id=@RptId";
            SQLiteParameter[] param ={
				new SQLiteParameter("@RptId",DbType.Int32)
			};
            param[0].Value = pfmReport.RptId;
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, cmdSql, param);
        }

        #endregion

        #region 实体对象

        /// <summary>
        /// 得到PfmReport实体对象
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>PfmReport实体对象</returns>
        public PfmReportMDL Select(DataRow row)
        {
            PfmReportMDL obj = new PfmReportMDL();
            if (row != null)
            {
                try
                {
                    obj.RptId = (long)row["rpt_id"];
                }
                catch { }
                try
                {
                    obj.DictMark = ((row["dict_mark"]) == DBNull.Value) ? Convert.ToByte(0) : Convert.ToByte(row["dict_mark"]);
                }
                catch { }
                try
                {
                    obj.RptTime = ((row["rpt_time"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["rpt_time"]);
                }
                catch { }
                try
                {
                    obj.RptDate = ((row["rpt_date"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["rpt_date"]);
                }
                catch { }
                try
                {
                    obj.RptState = ((row["rpt_state"]) == DBNull.Value) ? Convert.ToByte(0) : Convert.ToByte(row["rpt_state"]);
                }
                catch { }
                try
                {
                    obj.RptName = row["rpt_name"].ToString();
                }
                catch { }
                try
                {
                    obj.RptMemo = row["rpt_memo"].ToString();
                }
                catch { }
                try
                {
                    obj.RptBkFd01 = ((row["rpt_bk_fd01"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["rpt_bk_fd01"]);
                }
                catch { }
                try
                {
                    obj.RptBkFd02 = ((row["rpt_bk_fd02"]) == DBNull.Value) ? Convert.ToByte(0) : Convert.ToByte(row["rpt_bk_fd02"]);
                }
                catch { }
                try
                {
                    obj.RptBkFd03 = row["rpt_bk_fd03"].ToString();
                }
                catch { }
                try
                {
                    obj.RptBkFd04 = row["rpt_bk_fd04"].ToString();
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
        /// 得到PfmReport实体对象
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>PfmReports实体对象</returns>
        public PfmReportMDL Select(IDataReader dr)
        {
            PfmReportMDL obj = new PfmReportMDL();
            try
            {
                obj.RptId = (long)dr["rpt_id"];
            }
            catch { }
            try
            {
                obj.DictMark = ((dr["dict_mark"]) == DBNull.Value) ? Convert.ToByte(0) : Convert.ToByte(dr["dict_mark"]);
            }
            catch { }
            try
            {
                obj.RptTime = ((dr["rpt_time"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["rpt_time"]);
            }
            catch { }
            try
            {
                obj.RptDate = ((dr["rpt_date"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["rpt_date"]);
            }
            catch { }
            try
            {
                obj.RptState = ((dr["rpt_state"]) == DBNull.Value) ? Convert.ToByte(0) : Convert.ToByte(dr["rpt_state"]);
            }
            catch { }
            try
            {
                obj.RptName = dr["rpt_name"].ToString();
            }
            catch { }
            try
            {
                obj.RptMemo = dr["rpt_memo"].ToString();
            }
            catch { }
            try
            {
                obj.RptBkFd01 = ((dr["rpt_bk_fd01"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["rpt_bk_fd01"]);
            }
            catch { }
            try
            {
                obj.RptBkFd02 = ((dr["rpt_bk_fd02"]) == DBNull.Value) ? Convert.ToByte(0) : Convert.ToByte(dr["rpt_bk_fd02"]);
            }
            catch { }
            try
            {
                obj.RptBkFd03 = dr["rpt_bk_fd03"].ToString();
            }
            catch { }
            try
            {
                obj.RptBkFd04 = dr["rpt_bk_fd04"].ToString();
            }
            catch { }
            return obj;
        }
        /// <summary>
        /// 根据ID,返回一个PfmReport实体对象
        /// </summary>
        /// <param name="rptId"></param>
        /// <returns>PfmReport实体对象</returns>
        public PfmReportMDL Select(long rptId)
        {
            string cmdSql = "select * from pfm_report where rpt_id=@RptId";
            PfmReportMDL obj = null;
            SQLiteParameter[] param ={
			    new SQLiteParameter("@RptId",DbType.Int32)
			};
            param[0].Value = rptId;
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
        /// 得到数据表PfmReport所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public List<PfmReportMDL> LSelect()
        {
            return this.LSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmReport满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public List<PfmReportMDL> LSelect(string where)
        {
            return this.LSelect(where, " [rpt_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmReport满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public List<PfmReportMDL> LSelect(string where, string sortField)
        {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = "rpt_id";
            string cmdSql = "select * from pfm_report where @where order by @sortField";
            List<PfmReportMDL> list = new List<PfmReportMDL>();
            SQLiteParameter[] param ={
				new SQLiteParameter("@where",DbType.String,8000),
				new SQLiteParameter("@sortField",DbType.String,100)
			};
            param[0].Value = where;
            param[1].Value = sortField;
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
        /// 得到数据表PfmReport满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public List<PfmReportMDL> LSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            List<PfmReportMDL> list = new List<PfmReportMDL>();
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
        /// 得到数据表PfmReport所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public IList<PfmReportMDL> ISelect()
        {
            return this.ISelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmReport满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public IList<PfmReportMDL> ISelect(string where)
        {
            return this.ISelect(where, " [rpt_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmReport满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public IList<PfmReportMDL> ISelect(string where, string sortField)
        {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = "rpt_id";
            string cmdSql = "select * from pfm_report where @where order by @sortField";
            IList<PfmReportMDL> list = new List<PfmReportMDL>();
            SQLiteParameter[] param ={
				new SQLiteParameter("@where",DbType.String,8000),
				new SQLiteParameter("@sortField",DbType.String,100)
			};
            param[0].Value = where;
            param[1].Value = sortField;
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
        /// 得到数据表PfmReport满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public IList<PfmReportMDL> ISelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            IList<PfmReportMDL> list = new List<PfmReportMDL>();
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
        /// 得到数据表PfmReport所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public Collection<PfmReportMDL> CSelect()
        {
            return this.CSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmReport满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public Collection<PfmReportMDL> CSelect(string where)
        {
            return this.CSelect(where, " [rpt_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmReport满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public Collection<PfmReportMDL> CSelect(string where, string sortField)
        {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = "rpt_id";
            string cmdSql = "select * from pfm_report where @where order by @sortField";
            Collection<PfmReportMDL> list = new Collection<PfmReportMDL>();
            SQLiteParameter[] param ={
				new SQLiteParameter("@where",DbType.String,8000),
				new SQLiteParameter("@sortField",DbType.String,100)
			};
            param[0].Value = where;
            param[1].Value = sortField;
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
        /// 得到数据表PfmReport满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public Collection<PfmReportMDL> CSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            Collection<PfmReportMDL> list = new Collection<PfmReportMDL>();
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
        /// 得到数据表PfmReport所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmReportMDL> OSelect()
        {
            return this.OSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmReport满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmReportMDL> OSelect(string where)
        {
            return this.OSelect(where, " [rpt_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmReport满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmReportMDL> OSelect(string where, string sortField)
        {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = "rpt_id";
            string cmdSql = "select * from pfm_report where @where order by @sortField";
            ObservableCollection<PfmReportMDL> list = new ObservableCollection<PfmReportMDL>();
            SQLiteParameter[] param ={
				new SQLiteParameter("@where",DbType.String,8000),
				new SQLiteParameter("@sortField",DbType.String,100)
			};
            param[0].Value = where;
            param[1].Value = sortField;
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
        /// 得到数据表PfmReport满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmReportMDL> OSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            ObservableCollection<PfmReportMDL> list = new ObservableCollection<PfmReportMDL>();
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
        /// 获取最大系统编号
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            string cmdSql = @"select max(rpt_id) from pfm_report";
            string val = string.Format("{0}", SQLiteHelper.ExecuteScalar(Conn.SqlConn, CommandType.Text, cmdSql));
            int valTmp = 0;
            int.TryParse(val, out valTmp);
            return valTmp;
        }
        /// <summary>
        /// 得到数据表PfmReport满足查询条件的记录数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="recordCount">记录数</param>
        public void Select(string where, out int recordCount)
        {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            string cmdSql = "select count(-1) from pfm_report where @where";
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
        /// <param name="rptId"></param>
        /// <returns>存在/不存在</returns>
        public bool Exists(long rptId)
        {
            string cmdSql = "select count(-1) from pfm_report where rpt_id=@RptId";
            SQLiteParameter[] param ={
            	new SQLiteParameter("@RptId",DbType.Int32)
            };
            param[0].Value = rptId;
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
            string cmdSql = @"select count(-1) from pfm_report where @where";
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
        public List<PfmReportMDL> LSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return LSelectPaging(null, "rpt_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public List<PfmReportMDL> LSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return LSelectPaging(strWhere, "rpt_time desc", pageSize, currentIndex, out recordCount);
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
        public List<PfmReportMDL> LSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("rpt_id");
            sb.Append(",dict_mark");
            sb.Append(",rpt_time");
            sb.Append(",rpt_date");
            sb.Append(",rpt_state");
            sb.Append(",rpt_name");
            sb.Append(",rpt_memo");
            sb.Append(",rpt_bk_fd01");
            sb.Append(",rpt_bk_fd02");
            sb.Append(",rpt_bk_fd03");
            sb.Append(",rpt_bk_fd04");
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
        public List<PfmReportMDL> LSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "rpt_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            List<PfmReportMDL> list = new List<PfmReportMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_report where {1} order by {2} limit {3} offset {4}";
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
        public IList<PfmReportMDL> ISelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return ISelectPaging(null, "rpt_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public IList<PfmReportMDL> ISelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return ISelectPaging(strWhere, "rpt_time desc", pageSize, currentIndex, out recordCount);
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
        public IList<PfmReportMDL> ISelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("rpt_id");
            sb.Append(",dict_mark");
            sb.Append(",rpt_time");
            sb.Append(",rpt_date");
            sb.Append(",rpt_state");
            sb.Append(",rpt_name");
            sb.Append(",rpt_memo");
            sb.Append(",rpt_bk_fd01");
            sb.Append(",rpt_bk_fd02");
            sb.Append(",rpt_bk_fd03");
            sb.Append(",rpt_bk_fd04");
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
        public IList<PfmReportMDL> ISelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "rpt_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            IList<PfmReportMDL> list = new List<PfmReportMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_report where {1} order by {2} limit {3} offset {4}";
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
        public Collection<PfmReportMDL> CSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return CSelectPaging(null, "rpt_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public Collection<PfmReportMDL> CSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return CSelectPaging(strWhere, "rpt_time desc", pageSize, currentIndex, out recordCount);
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
        public Collection<PfmReportMDL> CSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("rpt_id");
            sb.Append(",dict_mark");
            sb.Append(",rpt_time");
            sb.Append(",rpt_date");
            sb.Append(",rpt_state");
            sb.Append(",rpt_name");
            sb.Append(",rpt_memo");
            sb.Append(",rpt_bk_fd01");
            sb.Append(",rpt_bk_fd02");
            sb.Append(",rpt_bk_fd03");
            sb.Append(",rpt_bk_fd04");
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
        public Collection<PfmReportMDL> CSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "rpt_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            Collection<PfmReportMDL> list = new Collection<PfmReportMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_report where {1} order by {2} limit {3} offset {4}";
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
        public ObservableCollection<PfmReportMDL> OSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return OSelectPaging(null, "rpt_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public ObservableCollection<PfmReportMDL> OSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return OSelectPaging(strWhere, "rpt_time desc", pageSize, currentIndex, out recordCount);
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
        public ObservableCollection<PfmReportMDL> OSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("rpt_id");
            sb.Append(",dict_mark");
            sb.Append(",rpt_time");
            sb.Append(",rpt_date");
            sb.Append(",rpt_state");
            sb.Append(",rpt_name");
            sb.Append(",rpt_memo");
            sb.Append(",rpt_bk_fd01");
            sb.Append(",rpt_bk_fd02");
            sb.Append(",rpt_bk_fd03");
            sb.Append(",rpt_bk_fd04");
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
        public ObservableCollection<PfmReportMDL> OSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "rpt_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            ObservableCollection<PfmReportMDL> list = new ObservableCollection<PfmReportMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_report where {1} order by {2} limit {3} offset {4}";
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
