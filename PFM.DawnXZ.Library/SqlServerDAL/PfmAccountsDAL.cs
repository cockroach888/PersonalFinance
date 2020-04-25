// =================================================================== 
// 产品（PFM.DawnXZ.Library.SqlServerDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：PfmAccountsDAL.cs
// 项目名称：请更改为实际项目名称
// 创建时间：2012年08月06日 16:57:00
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

namespace PFM.DawnXZ.Library.SqlServerDAL {
    /// <summary>
    /// 数据访问层PfmAccounts
    /// </summary>
    public partial class PfmAccountsDAL : IPfmAccountsDAL, SQLitePaging<PfmAccountsMDL> {

        #region 构造函数

        /// <summary>
        /// 数据层实例化
        /// </summary>
        public PfmAccountsDAL() { }

        #endregion

        #region -----------实例化接口函数-----------

        #region 添加

        /// <summary>
        /// 向数据表PfmAccounts中插入一条新记录
        /// </summary>
        /// <param name="pfmAccounts">PfmAccounts实体对象</param>
        /// <returns></returns>
        public int Insert(PfmAccountsMDL pfmAccounts) {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into ");
            sb.Append("pfm_accounts");
            sb.Append("(");
            sb.Append("mbr_id");
            sb.Append(",");
            sb.Append("acc_add_time");
            sb.Append(",");
            sb.Append("acc_status");
            sb.Append(",");
            sb.Append("acc_name");
            sb.Append(",");
            sb.Append("acc_code");
            sb.Append(",");
            sb.Append("acc_card");
            sb.Append(",");
            sb.Append("acc_purpose");
            sb.Append(",");
            sb.Append("acc_description");
            sb.Append(")");
            sb.Append(" values");
            sb.Append("(");
            sb.Append("@MbrId");
            sb.Append(",");
            sb.Append("@AccAddTime");
            sb.Append(",");
            sb.Append("@AccStatus");
            sb.Append(",");
            sb.Append("@AccName");
            sb.Append(",");
            sb.Append("@AccCode");
            sb.Append(",");
            sb.Append("@AccCard");
            sb.Append(",");
            sb.Append("@AccPurpose");
            sb.Append(",");
            sb.Append("@AccDescription");
            sb.Append(")");
            int res;
            SQLiteParameter[] param ={
                new SQLiteParameter("@MbrId",DbType.Int32),
                new SQLiteParameter("@AccAddTime",DbType.DateTime),
                new SQLiteParameter("@AccStatus",DbType.Byte),
                new SQLiteParameter("@AccName",DbType.String,20),
                new SQLiteParameter("@AccCode",DbType.String,50),
                new SQLiteParameter("@AccCard",DbType.String,50),
                new SQLiteParameter("@AccPurpose",DbType.String,100),
                new SQLiteParameter("@AccDescription",DbType.String,500)
            };
            param[0].Value = pfmAccounts.MbrId;
            param[1].Value = pfmAccounts.AccAddTime;
            param[2].Value = pfmAccounts.AccStatus;
            param[3].Value = pfmAccounts.AccName;
            param[4].Value = pfmAccounts.AccCode;
            param[5].Value = pfmAccounts.AccCard;
            param[6].Value = pfmAccounts.AccPurpose;
            param[7].Value = pfmAccounts.AccDescription;
            res = SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, sb.ToString(), param);
            return res;
        }

        #endregion

        #region 修改

        /// <summary>
        /// 向数据表PfmAccounts修改一条记录
        /// </summary>
        /// <param name="pfmAccounts">pfmAccounts实体对象</param>
        /// <returns></returns>
        public int Update(PfmAccountsMDL pfmAccounts) {
            StringBuilder sb = new StringBuilder();
            sb.Append("update ");
            sb.Append("pfm_accounts");
            sb.Append(" set ");
            sb.Append("mbr_id=@MbrId");
            sb.Append(",");
            sb.Append("acc_add_time=@AccAddTime");
            sb.Append(",");
            sb.Append("acc_status=@AccStatus");
            sb.Append(",");
            sb.Append("acc_name=@AccName");
            sb.Append(",");
            sb.Append("acc_code=@AccCode");
            sb.Append(",");
            sb.Append("acc_card=@AccCard");
            sb.Append(",");
            sb.Append("acc_purpose=@AccPurpose");
            sb.Append(",");
            sb.Append("acc_description=@AccDescription");
            sb.Append(" where ");
            sb.Append("acc_id=@AccId");
            SQLiteParameter[] param ={
                new SQLiteParameter("@AccId",DbType.Int32,8),
                new SQLiteParameter("@MbrId",DbType.Int32),
                new SQLiteParameter("@AccAddTime",DbType.DateTime),
                new SQLiteParameter("@AccStatus",DbType.Byte),
                new SQLiteParameter("@AccName",DbType.String,20),
                new SQLiteParameter("@AccCode",DbType.String,50),
                new SQLiteParameter("@AccCard",DbType.String,50),
                new SQLiteParameter("@AccPurpose",DbType.String,100),
                new SQLiteParameter("@AccDescription",DbType.String,500)
            };
            param[0].Value = pfmAccounts.AccId;
            param[1].Value = pfmAccounts.MbrId;
            param[2].Value = pfmAccounts.AccAddTime;
            param[3].Value = pfmAccounts.AccStatus;
            param[4].Value = pfmAccounts.AccName;
            param[5].Value = pfmAccounts.AccCode;
            param[6].Value = pfmAccounts.AccCard;
            param[7].Value = pfmAccounts.AccPurpose;
            param[8].Value = pfmAccounts.AccDescription;
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, sb.ToString(), param);
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除数据表PfmAccounts中的一条记录
        /// </summary>
        /// <param name="accId"></param>
        /// <returns></returns>
        public int Delete(long accId) {
            string cmdSql = "delete from pfm_accounts where acc_id=@AccId";
            SQLiteParameter[] param ={
                new SQLiteParameter("@AccId",DbType.Int32)
            };
            param[0].Value = accId;
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, cmdSql, param);
        }
        /// <summary>
        /// 删除数据表PfmAccounts中的一条记录
        /// </summary>
        /// <param name="pfmAccounts">pfmAccounts实体对象</param>
        /// <returns></returns>
        public int Delete(PfmAccountsMDL pfmAccounts) {
            string cmdSql = "delete from pfm_accounts where acc_id=@AccId";
            SQLiteParameter[] param ={
                new SQLiteParameter("@AccId",DbType.Int32)
            };
            param[0].Value = pfmAccounts.AccId;
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, cmdSql, param);
        }

        #endregion

        #region 实体对象

        /// <summary>
        /// 得到PfmAccounts实体对象
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>PfmAccounts实体对象</returns>
        public PfmAccountsMDL Select(DataRow row) {
            PfmAccountsMDL obj = new PfmAccountsMDL();
            if (row != null) {
                try {
                    obj.AccId = (long)row["acc_id"];
                }
                catch { }
                try {
                    obj.MbrId = ((row["mbr_id"]) == DBNull.Value) ? 0 : Convert.ToInt32(row["mbr_id"]);
                }
                catch { }
                try {
                    obj.AccAddTime = ((row["acc_add_time"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["acc_add_time"]);
                }
                catch { }
                try {
                    obj.AccStatus = ((row["acc_status"]) == DBNull.Value) ? Convert.ToByte(0) : Convert.ToByte(row["acc_status"]);
                }
                catch { }
                try {
                    obj.AccName = row["acc_name"].ToString();
                }
                catch { }
                try {
                    obj.AccCode = row["acc_code"].ToString();
                }
                catch { }
                try {
                    obj.AccCard = row["acc_card"].ToString();
                }
                catch { }
                try {
                    obj.AccPurpose = row["acc_purpose"].ToString();
                }
                catch { }
                try {
                    obj.AccDescription = row["acc_description"].ToString();
                }
                catch { }
            }
            else {
                return null;
            }
            return obj;
        }
        /// <summary>
        /// 得到PfmAccounts实体对象
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>PfmAccountss实体对象</returns>
        public PfmAccountsMDL Select(IDataReader dr) {
            PfmAccountsMDL obj = new PfmAccountsMDL();
            try {
                obj.AccId = (long)dr["acc_id"];
            }
            catch { }
            try {
                obj.MbrId = ((dr["mbr_id"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["mbr_id"]);
            }
            catch { }
            try {
                obj.AccAddTime = ((dr["acc_add_time"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["acc_add_time"]);
            }
            catch { }
            try {
                obj.AccStatus = ((dr["acc_status"]) == DBNull.Value) ? Convert.ToByte(0) : Convert.ToByte(dr["acc_status"]);
            }
            catch { }
            try {
                obj.AccName = dr["acc_name"].ToString();
            }
            catch { }
            try {
                obj.AccCode = dr["acc_code"].ToString();
            }
            catch { }
            try {
                obj.AccCard = dr["acc_card"].ToString();
            }
            catch { }
            try {
                obj.AccPurpose = dr["acc_purpose"].ToString();
            }
            catch { }
            try {
                obj.AccDescription = dr["acc_description"].ToString();
            }
            catch { }
            return obj;
        }
        /// <summary>
        /// 根据ID,返回一个PfmAccounts实体对象
        /// </summary>
        /// <param name="accId"></param>
        /// <returns>PfmAccounts实体对象</returns>
        public PfmAccountsMDL Select(long accId) {
            string cmdSql = "select * from pfm_accounts where acc_id=@AccId";
            PfmAccountsMDL obj = null;
            SQLiteParameter[] param ={
                new SQLiteParameter("@AccId",DbType.Int32)
            };
            param[0].Value = accId;
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, cmdSql, param)) {
                while (dr.Read()) {
                    obj = this.Select(dr);
                }
            }
            return obj;
        }

        #endregion

        #region 查询

        #region List
        /// <summary>
        /// 得到数据表PfmAccounts所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public List<PfmAccountsMDL> LSelect() {
            return this.LSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmAccounts满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public List<PfmAccountsMDL> LSelect(string where) {
            return this.LSelect(where, " [acc_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmAccounts满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public List<PfmAccountsMDL> LSelect(string where, string sortField) {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = "acc_id";
            string cmdSql = "select * from pfm_accounts where @where order by @sortField";
            List<PfmAccountsMDL> list = new List<PfmAccountsMDL>();
            SQLiteParameter[] param ={
                new SQLiteParameter("@where",DbType.String,8000),
                new SQLiteParameter("@sortField",DbType.String,100)
            };
            param[0].Value = where;
            param[1].Value = sortField;
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, cmdSql, param)) {
                while (dr.Read()) {
                    list.Add(this.Select(dr));
                }
            }
            return list;
        }
        /// <summary>
        /// 得到数据表PfmAccounts满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public List<PfmAccountsMDL> LSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param) {
            List<PfmAccountsMDL> list = new List<PfmAccountsMDL>();
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, commandType, sqlCommand, param)) {
                while (dr.Read()) {
                    list.Add(this.Select(dr));
                }
            }
            return list;
        }
        #endregion List

        #region IList
        /// <summary>
        /// 得到数据表PfmAccounts所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public IList<PfmAccountsMDL> ISelect() {
            return this.ISelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmAccounts满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public IList<PfmAccountsMDL> ISelect(string where) {
            return this.ISelect(where, " [acc_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmAccounts满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public IList<PfmAccountsMDL> ISelect(string where, string sortField) {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = "acc_id";
            string cmdSql = "select * from pfm_accounts where @where order by @sortField";
            IList<PfmAccountsMDL> list = new List<PfmAccountsMDL>();
            SQLiteParameter[] param ={
                new SQLiteParameter("@where",DbType.String,8000),
                new SQLiteParameter("@sortField",DbType.String,100)
            };
            param[0].Value = where;
            param[1].Value = sortField;
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, cmdSql, param)) {
                while (dr.Read()) {
                    list.Add(this.Select(dr));
                }
            }
            return list;
        }
        /// <summary>
        /// 得到数据表PfmAccounts满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public IList<PfmAccountsMDL> ISelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param) {
            IList<PfmAccountsMDL> list = new List<PfmAccountsMDL>();
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, commandType, sqlCommand, param)) {
                while (dr.Read()) {
                    list.Add(this.Select(dr));
                }
            }
            return list;
        }
        #endregion IList

        #region Collection
        /// <summary>
        /// 得到数据表PfmAccounts所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public Collection<PfmAccountsMDL> CSelect() {
            return this.CSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmAccounts满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public Collection<PfmAccountsMDL> CSelect(string where) {
            return this.CSelect(where, " [acc_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmAccounts满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public Collection<PfmAccountsMDL> CSelect(string where, string sortField) {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = "acc_id";
            string cmdSql = "select * from pfm_accounts where @where order by @sortField";
            Collection<PfmAccountsMDL> list = new Collection<PfmAccountsMDL>();
            SQLiteParameter[] param ={
                new SQLiteParameter("@where",DbType.String,8000),
                new SQLiteParameter("@sortField",DbType.String,100)
            };
            param[0].Value = where;
            param[1].Value = sortField;
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, cmdSql, param)) {
                while (dr.Read()) {
                    list.Add(this.Select(dr));
                }
            }
            return list;
        }
        /// <summary>
        /// 得到数据表PfmAccounts满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public Collection<PfmAccountsMDL> CSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param) {
            Collection<PfmAccountsMDL> list = new Collection<PfmAccountsMDL>();
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, commandType, sqlCommand, param)) {
                while (dr.Read()) {
                    list.Add(this.Select(dr));
                }
            }
            return list;
        }
        #endregion Collection

        #region ObservableCollection
        /// <summary>
        /// 得到数据表PfmAccounts所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmAccountsMDL> OSelect() {
            return this.OSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmAccounts满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmAccountsMDL> OSelect(string where) {
            return this.OSelect(where, " [acc_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmAccounts满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmAccountsMDL> OSelect(string where, string sortField) {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = "acc_id";
            string cmdSql = "select * from pfm_accounts where @where order by @sortField";
            ObservableCollection<PfmAccountsMDL> list = new ObservableCollection<PfmAccountsMDL>();
            SQLiteParameter[] param ={
                new SQLiteParameter("@where",DbType.String,8000),
                new SQLiteParameter("@sortField",DbType.String,100)
            };
            param[0].Value = where;
            param[1].Value = sortField;
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, cmdSql, param)) {
                while (dr.Read()) {
                    list.Add(this.Select(dr));
                }
            }
            return list;
        }
        /// <summary>
        /// 得到数据表PfmAccounts满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmAccountsMDL> OSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param) {
            ObservableCollection<PfmAccountsMDL> list = new ObservableCollection<PfmAccountsMDL>();
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, commandType, sqlCommand, param)) {
                while (dr.Read()) {
                    list.Add(this.Select(dr));
                }
            }
            return list;
        }
        #endregion ObservableCollection

        /// <summary>
        /// 得到数据表PfmAccounts满足查询条件的记录数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="recordCount">记录数</param>
        public void Select(string where, out int recordCount) {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            string cmdSql = "select count(-1) from pfm_accounts where @where";
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
        /// <param name="accId"></param>
        /// <returns>存在/不存在</returns>
        public bool Exists(long accId) {
            string cmdSql = "select count(-1) from pfm_accounts where acc_id=@AccId";
            SQLiteParameter[] param ={
                new SQLiteParameter("@AccId",DbType.Int32)
            };
            param[0].Value = accId;
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
        public bool Exists(string where) {
            if (string.IsNullOrEmpty(where)) return false;
            string cmdSql = @"select count(-1) from pfm_accounts where @where";
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
        public List<PfmAccountsMDL> LSelectPaging(int pageSize, int currentIndex, out int recordCount) {
            return LSelectPaging(null, "acc_add_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public List<PfmAccountsMDL> LSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount) {
            return LSelectPaging(strWhere, "acc_add_time desc", pageSize, currentIndex, out recordCount);
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
        public List<PfmAccountsMDL> LSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount) {
            StringBuilder sb = new StringBuilder();
            sb.Append("acc_id");
            sb.Append(",mbr_id");
            sb.Append(",acc_add_time");
            sb.Append(",acc_status");
            sb.Append(",acc_name");
            sb.Append(",acc_code");
            sb.Append(",acc_card");
            sb.Append(",acc_purpose");
            sb.Append(",acc_description");
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
        public List<PfmAccountsMDL> LSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount) {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "acc_add_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            List<PfmAccountsMDL> list = new List<PfmAccountsMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_accounts where {1} order by {2} limit {3} offset {4}";
            cmdSql = string.Format(cmdSql, strColumns, strWhere, strOrder, pageSize, offsetCount);
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, cmdSql)) {
                while (dr.Read()) {
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
        public IList<PfmAccountsMDL> ISelectPaging(int pageSize, int currentIndex, out int recordCount) {
            return ISelectPaging(null, "acc_add_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public IList<PfmAccountsMDL> ISelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount) {
            return ISelectPaging(strWhere, "acc_add_time desc", pageSize, currentIndex, out recordCount);
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
        public IList<PfmAccountsMDL> ISelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount) {
            StringBuilder sb = new StringBuilder();
            sb.Append("acc_id");
            sb.Append(",mbr_id");
            sb.Append(",acc_add_time");
            sb.Append(",acc_status");
            sb.Append(",acc_name");
            sb.Append(",acc_code");
            sb.Append(",acc_card");
            sb.Append(",acc_purpose");
            sb.Append(",acc_description");
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
        public IList<PfmAccountsMDL> ISelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount) {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "acc_add_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            IList<PfmAccountsMDL> list = new List<PfmAccountsMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_accounts where {1} order by {2} limit {3} offset {4}";
            cmdSql = string.Format(cmdSql, strColumns, strWhere, strOrder, pageSize, offsetCount);
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, cmdSql)) {
                while (dr.Read()) {
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
        public Collection<PfmAccountsMDL> CSelectPaging(int pageSize, int currentIndex, out int recordCount) {
            return CSelectPaging(null, "acc_add_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public Collection<PfmAccountsMDL> CSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount) {
            return CSelectPaging(strWhere, "acc_add_time desc", pageSize, currentIndex, out recordCount);
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
        public Collection<PfmAccountsMDL> CSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount) {
            StringBuilder sb = new StringBuilder();
            sb.Append("acc_id");
            sb.Append(",mbr_id");
            sb.Append(",acc_add_time");
            sb.Append(",acc_status");
            sb.Append(",acc_name");
            sb.Append(",acc_code");
            sb.Append(",acc_card");
            sb.Append(",acc_purpose");
            sb.Append(",acc_description");
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
        public Collection<PfmAccountsMDL> CSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount) {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "acc_add_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            Collection<PfmAccountsMDL> list = new Collection<PfmAccountsMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_accounts where {1} order by {2} limit {3} offset {4}";
            cmdSql = string.Format(cmdSql, strColumns, strWhere, strOrder, pageSize, offsetCount);
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, cmdSql)) {
                while (dr.Read()) {
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
        public ObservableCollection<PfmAccountsMDL> OSelectPaging(int pageSize, int currentIndex, out int recordCount) {
            return OSelectPaging(null, "acc_add_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public ObservableCollection<PfmAccountsMDL> OSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount) {
            return OSelectPaging(strWhere, "acc_add_time desc", pageSize, currentIndex, out recordCount);
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
        public ObservableCollection<PfmAccountsMDL> OSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount) {
            StringBuilder sb = new StringBuilder();
            sb.Append("acc_id");
            sb.Append(",mbr_id");
            sb.Append(",acc_add_time");
            sb.Append(",acc_status");
            sb.Append(",acc_name");
            sb.Append(",acc_code");
            sb.Append(",acc_card");
            sb.Append(",acc_purpose");
            sb.Append(",acc_description");
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
        public ObservableCollection<PfmAccountsMDL> OSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount) {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "acc_add_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            ObservableCollection<PfmAccountsMDL> list = new ObservableCollection<PfmAccountsMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_accounts where {1} order by {2} limit {3} offset {4}";
            cmdSql = string.Format(cmdSql, strColumns, strWhere, strOrder, pageSize, offsetCount);
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, CommandType.Text, cmdSql)) {
                while (dr.Read()) {
                    list.Add(this.Select(dr));
                }
            }
            return list;
        }
        #endregion ObservableCollection

        #endregion 数据分页处理·SQLite

    }
}
