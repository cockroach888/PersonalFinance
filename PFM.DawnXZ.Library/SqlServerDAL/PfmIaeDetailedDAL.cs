// =================================================================== 
// 产品（PFM.DawnXZ.Library.SqlServerDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：PfmIaeDetailedDAL.cs
// 项目名称：请更改为实际项目名称
// 创建时间：2012年08月06日 16:55:18
// 创建人员：宋杰军
// 负 责 人：宋杰军
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
using DawnXZ.DBUtility;
using PFM.DawnXZ.Library.Entity;
using PFM.DawnXZ.Library.IDAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Text;

namespace PFM.DawnXZ.Library.SqlServerDAL {
    /// <summary>
    /// 数据访问层PfmIaeDetailed
    /// </summary>
    public partial class PfmIaeDetailedDAL : IPfmIaeDetailedDAL, SQLitePaging<PfmIaeDetailedMDL>
    {

        #region 构造函数

        /// <summary>
        /// 数据层实例化
        /// </summary>
        public PfmIaeDetailedDAL()
        { }

        #endregion

        #region -----------实例化接口函数-----------

        #region 添加

        /// <summary>
        /// 向数据表PfmIaeDetailed中插入一条新记录
        /// </summary>
        /// <param name="pfmIaeDetailed">PfmIaeDetailed实体对象</param>
        /// <returns></returns>
        public int Insert(PfmIaeDetailedMDL pfmIaeDetailed)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into ");
            sb.Append("pfm_iae_detailed");
            sb.Append("(");
            sb.Append("mbr_id");
            sb.Append(",");
            sb.Append("acc_id");
            sb.Append(",");
            sb.Append("cat_id");
            sb.Append(",");
            sb.Append("det_add_time");
            sb.Append(",");
            sb.Append("det_name");
            sb.Append(",");
            sb.Append("det_money");
            sb.Append(",");
            sb.Append("det_address");
            sb.Append(",");
            sb.Append("det_description");
            sb.Append(",");
            sb.Append("det_memo");
            sb.Append(",");
            sb.Append("det_status");
            sb.Append(",");
            sb.Append("det_edit_time");
            sb.Append(",");
            sb.Append("det_edit_count");
            sb.Append(",");
            sb.Append("cat_bk_fd01");
            sb.Append(",");
            sb.Append("cat_bk_fd02");
            sb.Append(",");
            sb.Append("cat_bk_fd03");
            sb.Append(")");
            sb.Append(" values");
            sb.Append("(");
            sb.Append("@MbrId");
            sb.Append(",");
            sb.Append("@AccId");
            sb.Append(",");
            sb.Append("@CatId");
            sb.Append(",");
            sb.Append("@DetAddTime");
            sb.Append(",");
            sb.Append("@DetName");
            sb.Append(",");
            sb.Append("@DetMoney");
            sb.Append(",");
            sb.Append("@DetAddress");
            sb.Append(",");
            sb.Append("@DetDescription");
            sb.Append(",");
            sb.Append("@DetMemo");
            sb.Append(",");
            sb.Append("@DetStatus");
            sb.Append(",");
            sb.Append("@DetEditTime");
            sb.Append(",");
            sb.Append("@DetEditCount");
            sb.Append(",");
            sb.Append("@CatBkFd01");
            sb.Append(",");
            sb.Append("@CatBkFd02");
            sb.Append(",");
            sb.Append("@CatBkFd03");
            sb.Append(")");
            int res;
            SQLiteParameter[] param ={
				new SQLiteParameter("@MbrId",DbType.Int32),
				new SQLiteParameter("@AccId",DbType.Int32),
				new SQLiteParameter("@CatId",DbType.Int32),
				new SQLiteParameter("@DetAddTime",DbType.DateTime),
				new SQLiteParameter("@DetName",DbType.String,300),
				new SQLiteParameter("@DetMoney",DbType.Decimal),
				new SQLiteParameter("@DetAddress",DbType.String,300),
				new SQLiteParameter("@DetDescription",DbType.String,500),
				new SQLiteParameter("@DetMemo",DbType.String,2000),
				new SQLiteParameter("@DetStatus",DbType.Byte),
				new SQLiteParameter("@DetEditTime",DbType.DateTime),
				new SQLiteParameter("@DetEditCount",DbType.Int32),
				new SQLiteParameter("@CatBkFd01",DbType.Int32),
				new SQLiteParameter("@CatBkFd02",DbType.Byte),
				new SQLiteParameter("@CatBkFd03",DbType.String,50)
			};
            param[0].Value = pfmIaeDetailed.MbrId;
            param[1].Value = pfmIaeDetailed.AccId;
            param[2].Value = pfmIaeDetailed.CatId;
            param[3].Value = pfmIaeDetailed.DetAddTime;
            param[4].Value = pfmIaeDetailed.DetName;
            param[5].Value = pfmIaeDetailed.DetMoney;
            param[6].Value = pfmIaeDetailed.DetAddress;
            param[7].Value = pfmIaeDetailed.DetDescription;
            param[8].Value = pfmIaeDetailed.DetMemo;
            param[9].Value = pfmIaeDetailed.DetStatus;
            param[10].Value = pfmIaeDetailed.DetEditTime;
            param[11].Value = pfmIaeDetailed.DetEditCount;
            param[12].Value = pfmIaeDetailed.CatBkFd01;
            param[13].Value = pfmIaeDetailed.CatBkFd02;
            param[14].Value = pfmIaeDetailed.CatBkFd03;
            res = SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, sb.ToString(), param);
            return res;
        }

        #endregion

        #region 修改

        /// <summary>
        /// 向数据表PfmIaeDetailed修改一条记录
        /// </summary>
        /// <param name="pfmIaeDetailed">pfmIaeDetailed实体对象</param>
        /// <returns></returns>
        public int Update(PfmIaeDetailedMDL pfmIaeDetailed)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update ");
            sb.Append("pfm_iae_detailed");
            sb.Append(" set ");
            sb.Append("mbr_id=@MbrId");
            sb.Append(",");
            sb.Append("acc_id=@AccId");
            sb.Append(",");
            sb.Append("cat_id=@CatId");
            sb.Append(",");
            sb.Append("det_add_time=@DetAddTime");
            sb.Append(",");
            sb.Append("det_name=@DetName");
            sb.Append(",");
            sb.Append("det_money=@DetMoney");
            sb.Append(",");
            sb.Append("det_address=@DetAddress");
            sb.Append(",");
            sb.Append("det_description=@DetDescription");
            sb.Append(",");
            sb.Append("det_memo=@DetMemo");
            sb.Append(",");
            sb.Append("det_status=@DetStatus");
            sb.Append(",");
            sb.Append("det_edit_time=@DetEditTime");
            sb.Append(",");
            sb.Append("det_edit_count=@DetEditCount");
            sb.Append(",");
            sb.Append("cat_bk_fd01=@CatBkFd01");
            sb.Append(",");
            sb.Append("cat_bk_fd02=@CatBkFd02");
            sb.Append(",");
            sb.Append("cat_bk_fd03=@CatBkFd03");
            sb.Append(" where ");
            sb.Append("det_id=@DetId");
            SQLiteParameter[] param ={
				new SQLiteParameter("@DetId",DbType.Int32,8),
				new SQLiteParameter("@MbrId",DbType.Int32),
				new SQLiteParameter("@AccId",DbType.Int32),
				new SQLiteParameter("@CatId",DbType.Int32),
				new SQLiteParameter("@DetAddTime",DbType.DateTime),
				new SQLiteParameter("@DetName",DbType.String,300),
				new SQLiteParameter("@DetMoney",DbType.Decimal),
				new SQLiteParameter("@DetAddress",DbType.String,300),
				new SQLiteParameter("@DetDescription",DbType.String,500),
				new SQLiteParameter("@DetMemo",DbType.String,2000),
				new SQLiteParameter("@DetStatus",DbType.Byte),
				new SQLiteParameter("@DetEditTime",DbType.DateTime),
				new SQLiteParameter("@DetEditCount",DbType.Int32),
				new SQLiteParameter("@CatBkFd01",DbType.Int32),
				new SQLiteParameter("@CatBkFd02",DbType.Byte),
				new SQLiteParameter("@CatBkFd03",DbType.String,50)
			};
            param[0].Value = pfmIaeDetailed.DetId;
            param[1].Value = pfmIaeDetailed.MbrId;
            param[2].Value = pfmIaeDetailed.AccId;
            param[3].Value = pfmIaeDetailed.CatId;
            param[4].Value = pfmIaeDetailed.DetAddTime;
            param[5].Value = pfmIaeDetailed.DetName;
            param[6].Value = pfmIaeDetailed.DetMoney;
            param[7].Value = pfmIaeDetailed.DetAddress;
            param[8].Value = pfmIaeDetailed.DetDescription;
            param[9].Value = pfmIaeDetailed.DetMemo;
            param[10].Value = pfmIaeDetailed.DetStatus;
            param[11].Value = pfmIaeDetailed.DetEditTime;
            param[12].Value = pfmIaeDetailed.DetEditCount;
            param[13].Value = pfmIaeDetailed.CatBkFd01;
            param[14].Value = pfmIaeDetailed.CatBkFd02;
            param[15].Value = pfmIaeDetailed.CatBkFd03;
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, sb.ToString(), param);
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除数据表PfmIaeDetailed中的一条记录
        /// </summary>
        /// <param name="detId"></param>
        /// <returns></returns>
        public int Delete(long detId)
        {
            string cmdSql = "delete from pfm_iae_detailed where det_id=@DetId";
            SQLiteParameter[] param ={
				new SQLiteParameter("@DetId",DbType.Int32)
			};
            param[0].Value = detId;
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, cmdSql, param);
        }
        /// <summary>
        /// 删除数据表PfmIaeDetailed中的一条记录
        /// </summary>
        /// <param name="pfmIaeDetailed">pfmIaeDetailed实体对象</param>
        /// <returns></returns>
        public int Delete(PfmIaeDetailedMDL pfmIaeDetailed)
        {
            string cmdSql = "delete from pfm_iae_detailed where det_id=@DetId";
            SQLiteParameter[] param ={
				new SQLiteParameter("@DetId",DbType.Int32)
			};
            param[0].Value = pfmIaeDetailed.DetId;
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, cmdSql, param);
        }

        #endregion

        #region 实体对象

        /// <summary>
        /// 得到PfmIaeDetailed实体对象
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>PfmIaeDetailed实体对象</returns>
        public PfmIaeDetailedMDL Select(DataRow row)
        {
            PfmIaeDetailedMDL obj = new PfmIaeDetailedMDL();
            if (row != null)
            {
                try
                {
                    obj.DetId = (long)row["det_id"];
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
                    obj.CatId = ((row["cat_id"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["cat_id"]);
                }
                catch { }
                try
                {
                    obj.DetAddTime = ((row["det_add_time"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["det_add_time"]);
                }
                catch { }
                try
                {
                    obj.DetName = row["det_name"].ToString();
                }
                catch { }
                try
                {
                    obj.DetMoney = ((row["det_money"]) == DBNull.Value) ? 0 : Convert.ToDecimal(row["det_money"]);
                }
                catch { }
                try
                {
                    obj.DetAddress = row["det_address"].ToString();
                }
                catch { }
                try
                {
                    obj.DetDescription = row["det_description"].ToString();
                }
                catch { }
                try
                {
                    obj.DetMemo = row["det_memo"].ToString();
                }
                catch { }
                try
                {
                    obj.DetStatus = ((row["det_status"]) == DBNull.Value) ? Convert.ToByte(0) : Convert.ToByte(row["det_status"]);
                }
                catch { }
                try
                {
                    obj.DetEditTime = ((row["det_edit_time"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["det_edit_time"]);
                }
                catch { }
                try
                {
                    obj.DetEditCount = ((row["det_edit_count"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["det_edit_count"]);
                }
                catch { }
                try
                {
                    obj.CatBkFd01 = ((row["cat_bk_fd01"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["cat_bk_fd01"]);
                }
                catch { }
                try
                {
                    obj.CatBkFd02 = ((row["cat_bk_fd02"]) == DBNull.Value) ? Convert.ToByte(0) : Convert.ToByte(row["cat_bk_fd02"]);
                }
                catch { }
                try
                {
                    obj.CatBkFd03 = row["cat_bk_fd03"].ToString();
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
        /// 得到PfmIaeDetailed实体对象
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>PfmIaeDetaileds实体对象</returns>
        public PfmIaeDetailedMDL Select(IDataReader dr)
        {
            PfmIaeDetailedMDL obj = new PfmIaeDetailedMDL();
            try
            {
                obj.DetId = (long)dr["det_id"];
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
                obj.CatId = ((dr["cat_id"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["cat_id"]);
            }
            catch { }
            try
            {
                obj.DetAddTime = ((dr["det_add_time"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["det_add_time"]);
            }
            catch { }
            try
            {
                obj.DetName = dr["det_name"].ToString();
            }
            catch { }
            try
            {
                obj.DetMoney = ((dr["det_money"]) == DBNull.Value) ? 0 : Convert.ToDecimal(dr["det_money"]);
            }
            catch { }
            try
            {
                obj.DetAddress = dr["det_address"].ToString();
            }
            catch { }
            try
            {
                obj.DetDescription = dr["det_description"].ToString();
            }
            catch { }
            try
            {
                obj.DetMemo = dr["det_memo"].ToString();
            }
            catch { }
            try
            {
                obj.DetStatus = ((dr["det_status"]) == DBNull.Value) ? Convert.ToByte(0) : Convert.ToByte(dr["det_status"]);
            }
            catch { }
            try
            {
                obj.DetEditTime = ((dr["det_edit_time"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["det_edit_time"]);
            }
            catch { }
            try
            {
                obj.DetEditCount = ((dr["det_edit_count"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["det_edit_count"]);
            }
            catch { }
            try
            {
                obj.CatBkFd01 = ((dr["cat_bk_fd01"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["cat_bk_fd01"]);
            }
            catch { }
            try
            {
                obj.CatBkFd02 = ((dr["cat_bk_fd02"]) == DBNull.Value) ? Convert.ToByte(0) : Convert.ToByte(dr["cat_bk_fd02"]);
            }
            catch { }
            try
            {
                obj.CatBkFd03 = dr["cat_bk_fd03"].ToString();
            }
            catch { }
            return obj;
        }
        /// <summary>
        /// 根据ID,返回一个PfmIaeDetailed实体对象
        /// </summary>
        /// <param name="detId"></param>
        /// <returns>PfmIaeDetailed实体对象</returns>
        public PfmIaeDetailedMDL Select(long detId)
        {
            string cmdSql = "select * from pfm_iae_detailed where det_id=@DetId";
            PfmIaeDetailedMDL obj = null;
            SQLiteParameter[] param ={
			    new SQLiteParameter("@DetId",DbType.Int32)
			};
            param[0].Value = detId;
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
        /// 得到数据表PfmIaeDetailed所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public List<PfmIaeDetailedMDL> LSelect()
        {
            return this.LSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public List<PfmIaeDetailedMDL> LSelect(string where)
        {
            return this.LSelect(where, " [det_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public List<PfmIaeDetailedMDL> LSelect(string where, string sortField)
        {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = "det_id";
            string cmdSql = "select * from pfm_iae_detailed where @where order by @sortField";
            List<PfmIaeDetailedMDL> list = new List<PfmIaeDetailedMDL>();
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
        /// 得到数据表PfmIaeDetailed满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public List<PfmIaeDetailedMDL> LSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            List<PfmIaeDetailedMDL> list = new List<PfmIaeDetailedMDL>();
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
        /// 得到数据表PfmIaeDetailed所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public IList<PfmIaeDetailedMDL> ISelect()
        {
            return this.ISelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public IList<PfmIaeDetailedMDL> ISelect(string where)
        {
            return this.ISelect(where, " [det_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public IList<PfmIaeDetailedMDL> ISelect(string where, string sortField)
        {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = "det_id";
            string cmdSql = "select * from pfm_iae_detailed where @where order by @sortField";
            IList<PfmIaeDetailedMDL> list = new List<PfmIaeDetailedMDL>();
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
        /// 得到数据表PfmIaeDetailed满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public IList<PfmIaeDetailedMDL> ISelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            IList<PfmIaeDetailedMDL> list = new List<PfmIaeDetailedMDL>();
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
        /// 得到数据表PfmIaeDetailed所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public Collection<PfmIaeDetailedMDL> CSelect()
        {
            return this.CSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public Collection<PfmIaeDetailedMDL> CSelect(string where)
        {
            return this.CSelect(where, " [det_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public Collection<PfmIaeDetailedMDL> CSelect(string where, string sortField)
        {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = "det_id";
            string cmdSql = "select * from pfm_iae_detailed where @where order by @sortField";
            Collection<PfmIaeDetailedMDL> list = new Collection<PfmIaeDetailedMDL>();
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
        /// 得到数据表PfmIaeDetailed满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public Collection<PfmIaeDetailedMDL> CSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            Collection<PfmIaeDetailedMDL> list = new Collection<PfmIaeDetailedMDL>();
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
        /// 得到数据表PfmIaeDetailed所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmIaeDetailedMDL> OSelect()
        {
            return this.OSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmIaeDetailedMDL> OSelect(string where)
        {
            return this.OSelect(where, " [det_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmIaeDetailedMDL> OSelect(string where, string sortField)
        {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = "det_id";
            string cmdSql = "select * from pfm_iae_detailed where @where order by @sortField";
            ObservableCollection<PfmIaeDetailedMDL> list = new ObservableCollection<PfmIaeDetailedMDL>();
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
        /// 得到数据表PfmIaeDetailed满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmIaeDetailedMDL> OSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param)
        {
            ObservableCollection<PfmIaeDetailedMDL> list = new ObservableCollection<PfmIaeDetailedMDL>();
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

        #region Report
        /// <summary>
        /// 报表数据检索
        /// </summary>
        /// <param name="begin">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public DataTable Report(DateTime begin, DateTime end)
        {
            if (begin == null || end == null) return null;
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.Append("select ");
            sb.Append("mbr_id");
            sb.Append(",acc_id");
            sb.Append(",sum(case when det_money > 0 then det_money else 0 end) as 'Incomings'");
            sb.Append(",count(case when det_money > 0 then det_money end) as 'InCount'");
            sb.Append(",sum(case when det_money < 0 then det_money else 0 end) as 'Outgoings'");
            sb.Append(",count(case when det_money < 0 then det_money end) as 'OutCount'");
            sb.Append(",sum(case when det_money > 0 then det_money else 0 end) + sum(case when det_money < 0 then det_money else 0 end) as 'Sums'");
            sb.Append(" from pfm_iae_detailed");
            sb.Append(" where ");
            sb.AppendFormat("det_add_time >= '{0}'", begin.ToString("yyyy-MM-dd HH:mm:ss"));
            sb.AppendFormat(" and det_add_time < '{0}'", end.ToString("yyyy-MM-dd HH:mm:ss"));
            sb.Append(" group by ");
            sb.Append("mbr_id");
            sb.Append(",acc_id");
            sb.Append(" order by ");
            sb.Append("mbr_id");
            dt = SQLiteHelper.ExecuteDataset(Conn.SqlConn, CommandType.Text, sb.ToString()).Tables[0];
            return dt;
        }
        #endregion Report

        /// <summary>
        /// 得到数据表PfmIaeDetailed满足查询条件的记录数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="recordCount">记录数</param>
        public void Select(string where, out int recordCount)
        {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            string cmdSql = "select count(-1) from pfm_iae_detailed where @where";
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
        /// <param name="detId"></param>
        /// <returns>存在/不存在</returns>
        public bool Exists(long detId)
        {
            string cmdSql = "select count(-1) from pfm_iae_detailed where det_id=@DetId";
            SQLiteParameter[] param ={
            	new SQLiteParameter("@DetId",DbType.Int32)
            };
            param[0].Value = detId;
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
            string cmdSql = @"select count(-1) from pfm_iae_detailed where @where";
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
        public List<PfmIaeDetailedMDL> LSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return LSelectPaging(null, "det_add_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public List<PfmIaeDetailedMDL> LSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return LSelectPaging(strWhere, "det_add_time desc", pageSize, currentIndex, out recordCount);
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
        public List<PfmIaeDetailedMDL> LSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("det_id");
            sb.Append(",mbr_id");
            sb.Append(",acc_id");
            sb.Append(",cat_id");
            sb.Append(",det_add_time");
            sb.Append(",det_name");
            sb.Append(",det_money");
            sb.Append(",det_address");
            sb.Append(",det_description");
            sb.Append(",det_memo");
            sb.Append(",det_status");
            sb.Append(",det_edit_time");
            sb.Append(",det_edit_count");
            sb.Append(",cat_bk_fd01");
            sb.Append(",cat_bk_fd02");
            sb.Append(",cat_bk_fd03");
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
        public List<PfmIaeDetailedMDL> LSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "det_add_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            List<PfmIaeDetailedMDL> list = new List<PfmIaeDetailedMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_iae_detailed where {1} order by {2} limit {3} offset {4}";
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
        public IList<PfmIaeDetailedMDL> ISelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return ISelectPaging(null, "det_add_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public IList<PfmIaeDetailedMDL> ISelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return ISelectPaging(strWhere, "det_add_time desc", pageSize, currentIndex, out recordCount);
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
        public IList<PfmIaeDetailedMDL> ISelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("det_id");
            sb.Append(",mbr_id");
            sb.Append(",acc_id");
            sb.Append(",cat_id");
            sb.Append(",det_add_time");
            sb.Append(",det_name");
            sb.Append(",det_money");
            sb.Append(",det_address");
            sb.Append(",det_description");
            sb.Append(",det_memo");
            sb.Append(",det_status");
            sb.Append(",det_edit_time");
            sb.Append(",det_edit_count");
            sb.Append(",cat_bk_fd01");
            sb.Append(",cat_bk_fd02");
            sb.Append(",cat_bk_fd03");
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
        public IList<PfmIaeDetailedMDL> ISelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "det_add_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            IList<PfmIaeDetailedMDL> list = new List<PfmIaeDetailedMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_iae_detailed where {1} order by {2} limit {3} offset {4}";
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
        public Collection<PfmIaeDetailedMDL> CSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return CSelectPaging(null, "det_add_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public Collection<PfmIaeDetailedMDL> CSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return CSelectPaging(strWhere, "det_add_time desc", pageSize, currentIndex, out recordCount);
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
        public Collection<PfmIaeDetailedMDL> CSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("det_id");
            sb.Append(",mbr_id");
            sb.Append(",acc_id");
            sb.Append(",cat_id");
            sb.Append(",det_add_time");
            sb.Append(",det_name");
            sb.Append(",det_money");
            sb.Append(",det_address");
            sb.Append(",det_description");
            sb.Append(",det_memo");
            sb.Append(",det_status");
            sb.Append(",det_edit_time");
            sb.Append(",det_edit_count");
            sb.Append(",cat_bk_fd01");
            sb.Append(",cat_bk_fd02");
            sb.Append(",cat_bk_fd03");
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
        public Collection<PfmIaeDetailedMDL> CSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "det_add_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            Collection<PfmIaeDetailedMDL> list = new Collection<PfmIaeDetailedMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_iae_detailed where {1} order by {2} limit {3} offset {4}";
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
        public ObservableCollection<PfmIaeDetailedMDL> OSelectPaging(int pageSize, int currentIndex, out int recordCount)
        {
            return OSelectPaging(null, "det_add_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public ObservableCollection<PfmIaeDetailedMDL> OSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount)
        {
            return OSelectPaging(strWhere, "det_add_time desc", pageSize, currentIndex, out recordCount);
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
        public ObservableCollection<PfmIaeDetailedMDL> OSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("det_id");
            sb.Append(",mbr_id");
            sb.Append(",acc_id");
            sb.Append(",cat_id");
            sb.Append(",det_add_time");
            sb.Append(",det_name");
            sb.Append(",det_money");
            sb.Append(",det_address");
            sb.Append(",det_description");
            sb.Append(",det_memo");
            sb.Append(",det_status");
            sb.Append(",det_edit_time");
            sb.Append(",det_edit_count");
            sb.Append(",cat_bk_fd01");
            sb.Append(",cat_bk_fd02");
            sb.Append(",cat_bk_fd03");
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
        public ObservableCollection<PfmIaeDetailedMDL> OSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount)
        {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "det_add_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            ObservableCollection<PfmIaeDetailedMDL> list = new ObservableCollection<PfmIaeDetailedMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_iae_detailed where {1} order by {2} limit {3} offset {4}";
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
