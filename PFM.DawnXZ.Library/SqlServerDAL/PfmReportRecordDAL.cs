// =================================================================== 
// 产品（PFM.DawnXZ.Library.SqlServerDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：PfmReportRecordDAL.cs
// 项目名称：请更改为实际项目名称
// 创建时间：2012年08月06日 16:46:12
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
    /// 数据访问层PfmReportRecord
    /// </summary>
    public partial class PfmReportRecordDAL : IPfmReportRecordDAL, SQLitePaging<PfmReportRecordMDL>
    {

        #region 构造函数

        /// <summary>
        /// 数据层实例化
        /// </summary>
        public PfmReportRecordDAL()
        { }

        #endregion

        #region -----------实例化接口函数-----------

        #region 添加

        /// <summary>
        /// 向数据表PfmReportRecord中插入一条新记录
        /// </summary>
        /// <param name="pfmReportRecord">PfmReportRecord实体对象</param>
        /// <returns></returns>
        public int Insert(PfmReportRecordMDL pfmReportRecord)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into ");
            sb.Append("pfm_report_record");
            sb.Append("(");
            sb.Append("rpt_id");
            sb.Append(",");
            sb.Append("mbr_id");
            sb.Append(",");
            sb.Append("acc_id");
            sb.Append(",");
            sb.Append("rrd_add_time");
            sb.Append(",");
            sb.Append("rrd_in_sum");
            sb.Append(",");
            sb.Append("rrd_in_count");
            sb.Append(",");
            sb.Append("rrd_out_sum");
            sb.Append(",");
            sb.Append("rrd_out_count");
            sb.Append(",");
            sb.Append("rrd_sum");
            sb.Append(",");
            sb.Append("rrd_bk_fd01");
            sb.Append(",");
            sb.Append("rrd_bk_fd02");
            sb.Append(",");
            sb.Append("rrd_bk_fd03");
            sb.Append(",");
            sb.Append("rrd_bk_fd04");
            sb.Append(")");
            sb.Append(" values");
            sb.Append("(");
            sb.Append("@RptId");
            sb.Append(",");
            sb.Append("@MbrId");
            sb.Append(",");
            sb.Append("@AccId");
            sb.Append(",");
            sb.Append("@RrdAddTime");
            sb.Append(",");
            sb.Append("@RrdInSum");
            sb.Append(",");
            sb.Append("@RrdInCount");
            sb.Append(",");
            sb.Append("@RrdOutSum");
            sb.Append(",");
            sb.Append("@RrdOutCount");
            sb.Append(",");
            sb.Append("@RrdSum");
            sb.Append(",");
            sb.Append("@RrdBkFd01");
            sb.Append(",");
            sb.Append("@RrdBkFd02");
            sb.Append(",");
            sb.Append("@RrdBkFd03");
            sb.Append(",");
            sb.Append("@RrdBkFd04");
            sb.Append(")");
            int res;
            SQLiteParameter[] param ={
				new SQLiteParameter("@RptId",DbType.Int32),
				new SQLiteParameter("@MbrId",DbType.Int32),
				new SQLiteParameter("@AccId",DbType.Int32),
				new SQLiteParameter("@RrdAddTime",DbType.DateTime),
				new SQLiteParameter("@RrdInSum",DbType.Decimal),
				new SQLiteParameter("@RrdInCount",DbType.Int32),
				new SQLiteParameter("@RrdOutSum",DbType.Decimal),
				new SQLiteParameter("@RrdOutCount",DbType.Int32),
				new SQLiteParameter("@RrdSum",DbType.Decimal),
				new SQLiteParameter("@RrdBkFd01",DbType.Int32),
				new SQLiteParameter("@RrdBkFd02",DbType.Byte),
				new SQLiteParameter("@RrdBkFd03",DbType.String,50),
				new SQLiteParameter("@RrdBkFd04",DbType.String,8000)
			};
            param[0].Value = pfmReportRecord.RptId;
            param[1].Value = pfmReportRecord.MbrId;
            param[2].Value = pfmReportRecord.AccId;
            param[3].Value = pfmReportRecord.RrdAddTime;
            param[4].Value = pfmReportRecord.RrdInSum;
            param[5].Value = pfmReportRecord.RrdInCount;
            param[6].Value = pfmReportRecord.RrdOutSum;
            param[7].Value = pfmReportRecord.RrdOutCount;
            param[8].Value = pfmReportRecord.RrdSum;
            param[9].Value = pfmReportRecord.RrdBkFd01;
            param[10].Value = pfmReportRecord.RrdBkFd02;
            param[11].Value = pfmReportRecord.RrdBkFd03;
            param[12].Value = pfmReportRecord.RrdBkFd04;
            res = SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, sb.ToString(), param);
            return res;
        }

        #endregion

        #region 修改

        /// <summary>
        /// 向数据表PfmReportRecord修改一条记录
        /// </summary>
        /// <param name="pfmReportRecord">pfmReportRecord实体对象</param>
        /// <returns></returns>
        public int Update(PfmReportRecordMDL pfmReportRecord)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update ");
            sb.Append("pfm_report_record");
            sb.Append(" set ");
            sb.Append("rpt_id=@RptId");
            sb.Append(",");
            sb.Append("mbr_id=@MbrId");
            sb.Append(",");
            sb.Append("acc_id=@AccId");
            sb.Append(",");
            sb.Append("rrd_add_time=@RrdAddTime");
            sb.Append(",");
            sb.Append("rrd_in_sum=@RrdInSum");
            sb.Append(",");
            sb.Append("rrd_in_count=@RrdInCount");
            sb.Append(",");
            sb.Append("rrd_out_sum=@RrdOutSum");
            sb.Append(",");
            sb.Append("rrd_out_count=@RrdOutCount");
            sb.Append(",");
            sb.Append("rrd_sum=@RrdSum");
            sb.Append(",");
            sb.Append("rrd_bk_fd01=@RrdBkFd01");
            sb.Append(",");
            sb.Append("rrd_bk_fd02=@RrdBkFd02");
            sb.Append(",");
            sb.Append("rrd_bk_fd03=@RrdBkFd03");
            sb.Append(",");
            sb.Append("rrd_bk_fd04=@RrdBkFd04");
            sb.Append(" where ");
            sb.Append("rrd_id=@RrdId");
            SQLiteParameter[] param ={
				new SQLiteParameter("@RrdId",DbType.Int32),
				new SQLiteParameter("@RptId",DbType.Int32),
				new SQLiteParameter("@MbrId",DbType.Int32),
				new SQLiteParameter("@AccId",DbType.Int32),
				new SQLiteParameter("@RrdAddTime",DbType.DateTime),
				new SQLiteParameter("@RrdInSum",DbType.Decimal),
				new SQLiteParameter("@RrdInCount",DbType.Int32),
				new SQLiteParameter("@RrdOutSum",DbType.Decimal),
				new SQLiteParameter("@RrdOutCount",DbType.Int32),
				new SQLiteParameter("@RrdSum",DbType.Decimal),
				new SQLiteParameter("@RrdBkFd01",DbType.Int32),
				new SQLiteParameter("@RrdBkFd02",DbType.Byte),
				new SQLiteParameter("@RrdBkFd03",DbType.String,50),
				new SQLiteParameter("@RrdBkFd04",DbType.String,8000)
			};
            param[0].Value = pfmReportRecord.RrdId;
            param[1].Value = pfmReportRecord.RptId;
            param[2].Value = pfmReportRecord.MbrId;
            param[3].Value = pfmReportRecord.AccId;
            param[4].Value = pfmReportRecord.RrdAddTime;
            param[5].Value = pfmReportRecord.RrdInSum;
            param[6].Value = pfmReportRecord.RrdInCount;
            param[7].Value = pfmReportRecord.RrdOutSum;
            param[8].Value = pfmReportRecord.RrdOutCount;
            param[9].Value = pfmReportRecord.RrdSum;
            param[10].Value = pfmReportRecord.RrdBkFd01;
            param[11].Value = pfmReportRecord.RrdBkFd02;
            param[12].Value = pfmReportRecord.RrdBkFd03;
            param[13].Value = pfmReportRecord.RrdBkFd04;
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, sb.ToString(), param);
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除数据表PfmReportRecord中的一条记录
        /// </summary>
        /// <param name="rrdId"></param>
        /// <returns></returns>
        public int Delete(long rrdId)
        {
            string cmdSql = "delete from pfm_report_record where rrd_id=@RrdId";
            SQLiteParameter[] param ={
				new SQLiteParameter("@RrdId",DbType.Int32)
			};
            param[0].Value = rrdId;
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, cmdSql, param);
        }
        /// <summary>
        /// 删除数据表PfmReportRecord中的条件记录
        /// </summary>
        /// <param name="rptId"></param>
        /// <returns></returns>
        public int DeleteAll(long rptId)
        {
            string cmdSql = "delete from pfm_report_record where rpt_id=@RptId";
            SQLiteParameter[] param ={
				new SQLiteParameter("@RptId",DbType.Int32)
			};
            param[0].Value = rptId;
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, cmdSql, param);
        }
        /// <summary>
        /// 删除数据表PfmReportRecord中的一条记录
        /// </summary>
        /// <param name="pfmReportRecord">pfmReportRecord实体对象</param>
        /// <returns></returns>
        public int Delete(PfmReportRecordMDL pfmReportRecord)
        {
            string cmdSql = "delete from pfm_report_record where rrd_id=@RrdId";
            SQLiteParameter[] param ={
				new SQLiteParameter("@RrdId",DbType.Int32)
			};
            param[0].Value = pfmReportRecord.RrdId;
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, cmdSql, param);
        }

        #endregion

        #region 实体对象

        /// <summary>
        /// 得到PfmReportRecord实体对象
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>PfmReportRecord实体对象</returns>
        public PfmReportRecordMDL Select(DataRow row)
        {
            PfmReportRecordMDL obj = new PfmReportRecordMDL();
            if (row != null)
            {
                try
                {
                    obj.RrdId = (long)row["rrd_id"];
                }
                catch { }
                try
                {
                    obj.RptId = ((row["rpt_id"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["rpt_id"]);
                }
                catch { }
                try
                {
                    obj.MbrId = ((row["mbr_id"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["mbr_id"]);
                }
                catch { }
                try
                {
                    obj.AccId = ((row["acc_id"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["acc_id"]);
                }
                catch { }
                try
                {
                    obj.RrdAddTime = ((row["rrd_add_time"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["rrd_add_time"]);
                }
                catch { }
                try
                {
                    obj.RrdInSum = ((row["rrd_in_sum"]) == DBNull.Value) ? 0 : Convert.ToDecimal(row["rrd_in_sum"]);
                }
                catch { }
                try
                {
                    obj.RrdInCount = ((row["rrd_in_count"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["rrd_in_count"]);
                }
                catch { }
                try
                {
                    obj.RrdOutSum = ((row["rrd_out_sum"]) == DBNull.Value) ? 0 : Convert.ToDecimal(row["rrd_out_sum"]);
                }
                catch { }
                try
                {
                    obj.RrdOutCount = ((row["rrd_out_count"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["rrd_out_count"]);
                }
                catch { }
                try
                {
                    obj.RrdSum = ((row["rrd_sum"]) == DBNull.Value) ? 0 : Convert.ToDecimal(row["rrd_sum"]);
                }
                catch { }
                try
                {
                    obj.RrdBkFd01 = ((row["rrd_bk_fd01"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["rrd_bk_fd01"]);
                }
                catch { }
                try
                {
                    obj.RrdBkFd02 = ((row["rrd_bk_fd02"]) == DBNull.Value) ? Convert.ToByte(0) : Convert.ToByte(row["rrd_bk_fd02"]);
                }
                catch { }
                try
                {
                    obj.RrdBkFd03 = row["rrd_bk_fd03"].ToString();
                }
                catch { }
                try
                {
                    obj.RrdBkFd04 = row["rrd_bk_fd04"].ToString();
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
        /// 得到PfmReportRecord实体对象
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>PfmReportRecords实体对象</returns>
        public PfmReportRecordMDL Select(IDataReader dr)
        {
            PfmReportRecordMDL obj = new PfmReportRecordMDL();
            try
            {
                obj.RrdId = (long)dr["rrd_id"];
            }
            catch { }
            try
            {
                obj.RptId = ((dr["rpt_id"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["rpt_id"]);
            }
            catch { }
            try
            {
                obj.MbrId = ((dr["mbr_id"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["mbr_id"]);
            }
            catch { }
            try
            {
                obj.AccId = ((dr["acc_id"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["acc_id"]);
            }
            catch { }
            try
            {
                obj.RrdAddTime = ((dr["rrd_add_time"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["rrd_add_time"]);
            }
            catch { }
            try
            {
                obj.RrdInSum = ((dr["rrd_in_sum"]) == DBNull.Value) ? 0 : Convert.ToDecimal(dr["rrd_in_sum"]);
            }
            catch { }
            try
            {
                obj.RrdInCount = ((dr["rrd_in_count"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["rrd_in_count"]);
            }
            catch { }
            try
            {
                obj.RrdOutSum = ((dr["rrd_out_sum"]) == DBNull.Value) ? 0 : Convert.ToDecimal(dr["rrd_out_sum"]);
            }
            catch { }
            try
            {
                obj.RrdOutCount = ((dr["rrd_out_count"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["rrd_out_count"]);
            }
            catch { }
            try
            {
                obj.RrdSum = ((dr["rrd_sum"]) == DBNull.Value) ? 0 : Convert.ToDecimal(dr["rrd_sum"]);
            }
            catch { }
            try
            {
                obj.RrdBkFd01 = ((dr["rrd_bk_fd01"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["rrd_bk_fd01"]);
            }
            catch { }
            try
            {
                obj.RrdBkFd02 = ((dr["rrd_bk_fd02"]) == DBNull.Value) ? Convert.ToByte(0) : Convert.ToByte(dr["rrd_bk_fd02"]);
            }
            catch { }
            try
            {
                obj.RrdBkFd03 = dr["rrd_bk_fd03"].ToString();
            }
            catch { }
            try
            {
                obj.RrdBkFd04 = dr["rrd_bk_fd04"].ToString();
            }
            catch { }
            return obj;
        }
        /// <summary>
        /// 根据ID,返回一个PfmReportRecord实体对象
        /// </summary>
        /// <param name="rrdId"></param>
        /// <returns>PfmReportRecord实体对象</returns>
        public PfmReportRecordMDL Select(long rrdId)
        {
            string cmdSql = "select * from pfm_report_record where rrd_id=@RrdId";
            PfmReportRecordMDL obj = null;
            SQLiteParameter[] param ={
			    new SQLiteParameter("@RrdId",DbType.Int32)
			};
            param[0].Value = rrdId;
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
        /// 得到数据表PfmReportRecord所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public List<PfmReportRecordMDL> LSelect()
        {
            return this.LSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmReportRecord满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public List<PfmReportRecordMDL> LSelect(string where)
        {
            return this.LSelect(where, " [rrd_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmReportRecord满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public List<PfmReportRecordMDL> LSelect(string where, string sortField)
        {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = "rrd_id";
            string cmdSql = string.Format("select * from pfm_report_record where {0} order by {1}", where, sortField);
            List<PfmReportRecordMDL> list = new List<PfmReportRecordMDL>();
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
        /// 得到数据表PfmReportRecord满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public List<PfmReportRecordMDL> LSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            List<PfmReportRecordMDL> list = new List<PfmReportRecordMDL>();
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
        /// 得到数据表PfmReportRecord所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public IList<PfmReportRecordMDL> ISelect()
        {
            return this.ISelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmReportRecord满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public IList<PfmReportRecordMDL> ISelect(string where)
        {
            return this.ISelect(where, " [rrd_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmReportRecord满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public IList<PfmReportRecordMDL> ISelect(string where, string sortField)
        {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = "rrd_id";
            string cmdSql = string.Format("select * from pfm_report_record where {0} order by {1}", where, sortField);
            IList<PfmReportRecordMDL> list = new List<PfmReportRecordMDL>();
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
        /// 得到数据表PfmReportRecord满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public IList<PfmReportRecordMDL> ISelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            IList<PfmReportRecordMDL> list = new List<PfmReportRecordMDL>();
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
        /// 得到数据表PfmReportRecord所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public Collection<PfmReportRecordMDL> CSelect()
        {
            return this.CSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmReportRecord满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public Collection<PfmReportRecordMDL> CSelect(string where)
        {
            return this.CSelect(where, " [rrd_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmReportRecord满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public Collection<PfmReportRecordMDL> CSelect(string where, string sortField)
        {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = "rrd_id";
            string cmdSql = string.Format("select * from pfm_report_record where {0} order by {1}", where, sortField);
            Collection<PfmReportRecordMDL> list = new Collection<PfmReportRecordMDL>();
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
        /// 得到数据表PfmReportRecord满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public Collection<PfmReportRecordMDL> CSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            Collection<PfmReportRecordMDL> list = new Collection<PfmReportRecordMDL>();
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
        /// 得到数据表PfmReportRecord所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmReportRecordMDL> OSelect()
        {
            return this.OSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmReportRecord满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmReportRecordMDL> OSelect(string where)
        {
            return this.OSelect(where, " [rrd_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmReportRecord满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmReportRecordMDL> OSelect(string where, string sortField)
        {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = "rrd_id";
            string cmdSql = string.Format("select * from pfm_report_record where {0} order by {1}", where, sortField);
            ObservableCollection<PfmReportRecordMDL> list = new ObservableCollection<PfmReportRecordMDL>();
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
        /// 得到数据表PfmReportRecord满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmReportRecordMDL> OSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            ObservableCollection<PfmReportRecordMDL> list = new ObservableCollection<PfmReportRecordMDL>();
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
        /// 得到数据表PfmReportRecord满足查询条件的记录数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="recordCount">记录数</param>
        public void Select(string where, out int recordCount)
        {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            string cmdSql = "select count(-1) from pfm_report_record where @where";
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
        /// <param name="rrdId"></param>
        /// <returns>存在/不存在</returns>
        public bool Exists(long rrdId)
        {
            string cmdSql = "select count(-1) from pfm_report_record where rrd_id=@RrdId";
            SQLiteParameter[] param ={
            	new SQLiteParameter("@RrdId",DbType.Int32)
            };
            param[0].Value = rrdId;
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
            string cmdSql = @"select count(-1) from pfm_report_record where @where";
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
        public List<PfmReportRecordMDL> LSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return LSelectPaging(null, "rrd_add_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public List<PfmReportRecordMDL> LSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return LSelectPaging(strWhere, "rrd_add_time desc", pageSize, currentIndex, out recordCount);
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
        public List<PfmReportRecordMDL> LSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("rrd_id");
            sb.Append(",rpt_id");
            sb.Append(",acc_id");
            sb.Append(",rrd_add_time");
            sb.Append(",rrd_sum");
            sb.Append(",rrd_count");
            sb.Append(",rrd_bk_fd01");
            sb.Append(",rrd_bk_fd02");
            sb.Append(",rrd_bk_fd03");
            sb.Append(",rrd_bk_fd04");
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
        public List<PfmReportRecordMDL> LSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "rrd_add_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            List<PfmReportRecordMDL> list = new List<PfmReportRecordMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_report_record where {1} order by {2} limit {3} offset {4}";
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
        public IList<PfmReportRecordMDL> ISelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return ISelectPaging(null, "rrd_add_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public IList<PfmReportRecordMDL> ISelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return ISelectPaging(strWhere, "rrd_add_time desc", pageSize, currentIndex, out recordCount);
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
        public IList<PfmReportRecordMDL> ISelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("rrd_id");
            sb.Append(",rpt_id");
            sb.Append(",acc_id");
            sb.Append(",rrd_add_time");
            sb.Append(",rrd_sum");
            sb.Append(",rrd_count");
            sb.Append(",rrd_bk_fd01");
            sb.Append(",rrd_bk_fd02");
            sb.Append(",rrd_bk_fd03");
            sb.Append(",rrd_bk_fd04");
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
        public IList<PfmReportRecordMDL> ISelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "rrd_add_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            IList<PfmReportRecordMDL> list = new List<PfmReportRecordMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_report_record where {1} order by {2} limit {3} offset {4}";
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
        public Collection<PfmReportRecordMDL> CSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return CSelectPaging(null, "rrd_add_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public Collection<PfmReportRecordMDL> CSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return CSelectPaging(strWhere, "rrd_add_time desc", pageSize, currentIndex, out recordCount);
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
        public Collection<PfmReportRecordMDL> CSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("rrd_id");
            sb.Append(",rpt_id");
            sb.Append(",acc_id");
            sb.Append(",rrd_add_time");
            sb.Append(",rrd_sum");
            sb.Append(",rrd_count");
            sb.Append(",rrd_bk_fd01");
            sb.Append(",rrd_bk_fd02");
            sb.Append(",rrd_bk_fd03");
            sb.Append(",rrd_bk_fd04");
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
        public Collection<PfmReportRecordMDL> CSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "rrd_add_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            Collection<PfmReportRecordMDL> list = new Collection<PfmReportRecordMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_report_record where {1} order by {2} limit {3} offset {4}";
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
        public ObservableCollection<PfmReportRecordMDL> OSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return OSelectPaging(null, "rrd_add_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public ObservableCollection<PfmReportRecordMDL> OSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return OSelectPaging(strWhere, "rrd_add_time desc", pageSize, currentIndex, out recordCount);
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
        public ObservableCollection<PfmReportRecordMDL> OSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("rrd_id");
            sb.Append(",rpt_id");
            sb.Append(",acc_id");
            sb.Append(",rrd_add_time");
            sb.Append(",rrd_sum");
            sb.Append(",rrd_count");
            sb.Append(",rrd_bk_fd01");
            sb.Append(",rrd_bk_fd02");
            sb.Append(",rrd_bk_fd03");
            sb.Append(",rrd_bk_fd04");
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
        public ObservableCollection<PfmReportRecordMDL> OSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "rrd_add_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            ObservableCollection<PfmReportRecordMDL> list = new ObservableCollection<PfmReportRecordMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_report_record where {1} order by {2} limit {3} offset {4}";
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
