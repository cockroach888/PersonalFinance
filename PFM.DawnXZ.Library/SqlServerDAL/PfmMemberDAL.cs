// =================================================================== 
// 产品（PFM.DawnXZ.Library.SqlServerDAL）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：PfmMemberDAL.cs
// 项目名称：请更改为实际项目名称
// 创建时间：2012年08月06日 16:53:06
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
    /// 数据访问层PfmMember
    /// </summary>
    public partial class PfmMemberDAL : IPfmMemberDAL, SQLitePaging<PfmMemberMDL> {

        #region 构造函数

        /// <summary>
        /// 数据层实例化
        /// </summary>
        public PfmMemberDAL() { }

        #endregion

        #region -----------实例化接口函数-----------

        #region 添加

        /// <summary>
        /// 向数据表PfmMember中插入一条新记录
        /// </summary>
        /// <param name="pfmMember">PfmMember实体对象</param>
        /// <returns></returns>
        public int Insert(PfmMemberMDL pfmMember) {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into ");
            sb.Append("pfm_member");
            sb.Append("(");
            sb.Append("mbr_add_time");
            sb.Append(",");
            sb.Append("mbr_name");
            sb.Append(",");
            sb.Append("mbr_relation");
            sb.Append(",");
            sb.Append("mbr_description");
            sb.Append(")");
            sb.Append(" values");
            sb.Append("(");
            sb.Append("@MbrAddTime");
            sb.Append(",");
            sb.Append("@MbrName");
            sb.Append(",");
            sb.Append("@MbrRelation");
            sb.Append(",");
            sb.Append("@MbrDescription");
            sb.Append(")");
            int res;
            SQLiteParameter[] param ={
                new SQLiteParameter("@MbrAddTime",DbType.DateTime),
                new SQLiteParameter("@MbrName",DbType.String,10),
                new SQLiteParameter("@MbrRelation",DbType.String,50),
                new SQLiteParameter("@MbrDescription",DbType.String,500)
            };
            param[0].Value = pfmMember.MbrAddTime;
            param[1].Value = pfmMember.MbrName;
            param[2].Value = pfmMember.MbrRelation;
            param[3].Value = pfmMember.MbrDescription;
            res = SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, sb.ToString(), param);
            return res;
        }

        #endregion

        #region 修改

        /// <summary>
        /// 向数据表PfmMember修改一条记录
        /// </summary>
        /// <param name="pfmMember">pfmMember实体对象</param>
        /// <returns></returns>
        public int Update(PfmMemberMDL pfmMember) {
            StringBuilder sb = new StringBuilder();
            sb.Append("update ");
            sb.Append("pfm_member");
            sb.Append(" set ");
            sb.Append("mbr_add_time=@MbrAddTime");
            sb.Append(",");
            sb.Append("mbr_name=@MbrName");
            sb.Append(",");
            sb.Append("mbr_relation=@MbrRelation");
            sb.Append(",");
            sb.Append("mbr_description=@MbrDescription");
            sb.Append(" where ");
            sb.Append("mbr_id=@MbrId");
            SQLiteParameter[] param ={
                new SQLiteParameter("@MbrId",DbType.Int32,8),
                new SQLiteParameter("@MbrAddTime",DbType.DateTime),
                new SQLiteParameter("@MbrName",DbType.String,10),
                new SQLiteParameter("@MbrRelation",DbType.String,50),
                new SQLiteParameter("@MbrDescription",DbType.String,500)
            };
            param[0].Value = pfmMember.MbrId;
            param[1].Value = pfmMember.MbrAddTime;
            param[2].Value = pfmMember.MbrName;
            param[3].Value = pfmMember.MbrRelation;
            param[4].Value = pfmMember.MbrDescription;
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, sb.ToString(), param);
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除数据表PfmMember中的一条记录
        /// </summary>
        /// <param name="mbrId"></param>
        /// <returns></returns>
        public int Delete(long mbrId) {
            string cmdSql = "delete from pfm_member where mbr_id=@MbrId";
            SQLiteParameter[] param ={
                new SQLiteParameter("@MbrId",DbType.Int32)
            };
            param[0].Value = mbrId;
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, cmdSql, param);
        }
        /// <summary>
        /// 删除数据表PfmMember中的一条记录
        /// </summary>
        /// <param name="pfmMember">pfmMember实体对象</param>
        /// <returns></returns>
        public int Delete(PfmMemberMDL pfmMember) {
            string cmdSql = "delete from pfm_member where mbr_id=@MbrId";
            SQLiteParameter[] param ={
                new SQLiteParameter("@MbrId",DbType.Int32)
            };
            param[0].Value = pfmMember.MbrId;
            return SQLiteHelper.ExecuteNonQuery(Conn.SqlConn, CommandType.Text, cmdSql, param);
        }

        #endregion

        #region 实体对象

        /// <summary>
        /// 得到PfmMember实体对象
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>PfmMember实体对象</returns>
        public PfmMemberMDL Select(DataRow row) {
            PfmMemberMDL obj = new PfmMemberMDL();
            if (row != null) {
                try {
                    obj.MbrId = (long)row["mbr_id"];
                }
                catch { }
                try {
                    obj.MbrAddTime = ((row["mbr_add_time"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["mbr_add_time"]);
                }
                catch { }
                try {
                    obj.MbrName = row["mbr_name"].ToString();
                }
                catch { }
                try {
                    obj.MbrRelation = row["mbr_relation"].ToString();
                }
                catch { }
                try {
                    obj.MbrDescription = row["mbr_description"].ToString();
                }
                catch { }
            }
            else {
                return null;
            }
            return obj;
        }
        /// <summary>
        /// 得到PfmMember实体对象
        /// </summary>
        /// <param name="dr">dr</param>
        /// <returns>PfmMembers实体对象</returns>
        public PfmMemberMDL Select(IDataReader dr) {
            PfmMemberMDL obj = new PfmMemberMDL();
            try {
                obj.MbrId = (long)dr["mbr_id"];
            }
            catch { }
            try {
                obj.MbrAddTime = ((dr["mbr_add_time"]) == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["mbr_add_time"]);
            }
            catch { }
            try {
                obj.MbrName = dr["mbr_name"].ToString();
            }
            catch { }
            try {
                obj.MbrRelation = dr["mbr_relation"].ToString();
            }
            catch { }
            try {
                obj.MbrDescription = dr["mbr_description"].ToString();
            }
            catch { }
            return obj;
        }
        /// <summary>
        /// 根据ID,返回一个PfmMember实体对象
        /// </summary>
        /// <param name="mbrId"></param>
        /// <returns>PfmMember实体对象</returns>
        public PfmMemberMDL Select(long mbrId) {
            string cmdSql = "select * from pfm_member where mbr_id=@MbrId";
            PfmMemberMDL obj = null;
            SQLiteParameter[] param ={
                new SQLiteParameter("@MbrId",DbType.Int32)
            };
            param[0].Value = mbrId;
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
        /// 得到数据表PfmMember所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public List<PfmMemberMDL> LSelect() {
            return this.LSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmMember满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public List<PfmMemberMDL> LSelect(string where) {
            return this.LSelect(where, " [mbr_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmMember满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public List<PfmMemberMDL> LSelect(string where, string sortField) {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = "mbr_id";
            string cmdSql = "select * from pfm_member where @where order by @sortField";
            List<PfmMemberMDL> list = new List<PfmMemberMDL>();
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
        /// 得到数据表PfmMember满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public List<PfmMemberMDL> LSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param) {
            List<PfmMemberMDL> list = new List<PfmMemberMDL>();
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
        /// 得到数据表PfmMember所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public IList<PfmMemberMDL> ISelect() {
            return this.ISelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmMember满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public IList<PfmMemberMDL> ISelect(string where) {
            return this.ISelect(where, " [mbr_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmMember满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public IList<PfmMemberMDL> ISelect(string where, string sortField) {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = "mbr_id";
            string cmdSql = "select * from pfm_member where @where order by @sortField";
            IList<PfmMemberMDL> list = new List<PfmMemberMDL>();
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
        /// 得到数据表PfmMember满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public IList<PfmMemberMDL> ISelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param) {
            IList<PfmMemberMDL> list = new List<PfmMemberMDL>();
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
        /// 得到数据表PfmMember所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public Collection<PfmMemberMDL> CSelect() {
            return this.CSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmMember满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public Collection<PfmMemberMDL> CSelect(string where) {
            return this.CSelect(where, " [mbr_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmMember满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public Collection<PfmMemberMDL> CSelect(string where, string sortField) {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = "mbr_id";
            string cmdSql = "select * from pfm_member where @where order by @sortField";
            Collection<PfmMemberMDL> list = new Collection<PfmMemberMDL>();
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
        /// 得到数据表PfmMember满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public Collection<PfmMemberMDL> CSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param) {
            Collection<PfmMemberMDL> list = new Collection<PfmMemberMDL>();
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
        /// 得到数据表PfmMember所有记录
        /// </summary>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmMemberMDL> OSelect() {
            return this.OSelect(string.Empty);
        }
        /// <summary>
        /// 得到数据表PfmMember满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmMemberMDL> OSelect(string where) {
            return this.OSelect(where, " [mbr_id] DESC ");
        }
        /// <summary>
        /// 得到数据表PfmMember满足查询条件的记录
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="sortField">排序字段</param>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmMemberMDL> OSelect(string where, string sortField) {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            if (string.IsNullOrEmpty(sortField)) sortField = "mbr_id";
            string cmdSql = "select * from pfm_member where @where order by @sortField";
            ObservableCollection<PfmMemberMDL> list = new ObservableCollection<PfmMemberMDL>();
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
        /// 得到数据表PfmMember满足查询条件记录
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="sqlCommand">SQL命令</param>
        /// <param name="param">命令参数数组</param>
        /// <returns>结果集</returns>
        public ObservableCollection<PfmMemberMDL> OSelect(CommandType commandType, string sqlCommand, params SQLiteParameter[] param) {
            ObservableCollection<PfmMemberMDL> list = new ObservableCollection<PfmMemberMDL>();
            using (DbDataReader dr = SQLiteHelper.ExecuteReader(Conn.SqlConn, commandType, sqlCommand, param)) {
                while (dr.Read()) {
                    list.Add(this.Select(dr));
                }
            }
            return list;
        }
        #endregion ObservableCollection

        /// <summary>
        /// 得到数据表PfmMember满足查询条件的记录数
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="recordCount">记录数</param>
        public void Select(string where, out int recordCount) {
            if (string.IsNullOrEmpty(where)) where = " 1=1";
            string cmdSql = "select count(-1) from pfm_member where @where";
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
        /// <param name="mbrId"></param>
        /// <returns>存在/不存在</returns>
        public bool Exists(long mbrId) {
            string cmdSql = "select count(-1) from pfm_member where mbr_id=@MbrId";
            SQLiteParameter[] param ={
                new SQLiteParameter("@MbrId",DbType.Int32)
            };
            param[0].Value = mbrId;
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
            string cmdSql = @"select count(-1) from pfm_member where @where";
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
        public List<PfmMemberMDL> LSelectPaging(int pageSize, int currentIndex, out int recordCount) {
            return LSelectPaging(null, "mbr_add_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public List<PfmMemberMDL> LSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount) {
            return LSelectPaging(strWhere, "mbr_add_time desc", pageSize, currentIndex, out recordCount);
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
        public List<PfmMemberMDL> LSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount) {
            StringBuilder sb = new StringBuilder();
            sb.Append("mbr_id");
            sb.Append(",mbr_add_time");
            sb.Append(",mbr_name");
            sb.Append(",mbr_relation");
            sb.Append(",mbr_description");
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
        public List<PfmMemberMDL> LSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount) {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "mbr_add_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            List<PfmMemberMDL> list = new List<PfmMemberMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_member where {1} order by {2} limit {3} offset {4}";
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
        public IList<PfmMemberMDL> ISelectPaging(int pageSize, int currentIndex, out int recordCount) {
            return ISelectPaging(null, "mbr_add_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public IList<PfmMemberMDL> ISelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount) {
            return ISelectPaging(strWhere, "mbr_add_time desc", pageSize, currentIndex, out recordCount);
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
        public IList<PfmMemberMDL> ISelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount) {
            StringBuilder sb = new StringBuilder();
            sb.Append("mbr_id");
            sb.Append(",mbr_add_time");
            sb.Append(",mbr_name");
            sb.Append(",mbr_relation");
            sb.Append(",mbr_description");
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
        public IList<PfmMemberMDL> ISelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount) {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "mbr_add_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            IList<PfmMemberMDL> list = new List<PfmMemberMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_member where {1} order by {2} limit {3} offset {4}";
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
        public Collection<PfmMemberMDL> CSelectPaging(int pageSize, int currentIndex, out int recordCount) {
            return CSelectPaging(null, "mbr_add_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public Collection<PfmMemberMDL> CSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount) {
            return CSelectPaging(strWhere, "mbr_add_time desc", pageSize, currentIndex, out recordCount);
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
        public Collection<PfmMemberMDL> CSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount) {
            StringBuilder sb = new StringBuilder();
            sb.Append("mbr_id");
            sb.Append(",mbr_add_time");
            sb.Append(",mbr_name");
            sb.Append(",mbr_relation");
            sb.Append(",mbr_description");
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
        public Collection<PfmMemberMDL> CSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount) {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "mbr_add_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            Collection<PfmMemberMDL> list = new Collection<PfmMemberMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_member where {1} order by {2} limit {3} offset {4}";
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
        public ObservableCollection<PfmMemberMDL> OSelectPaging(int pageSize, int currentIndex, out int recordCount) {
            return OSelectPaging(null, "mbr_add_time desc", pageSize, currentIndex, out recordCount);
        }
        /// <summary>
        /// 数据分页处理·SQLite
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentIndex">当前页码</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public ObservableCollection<PfmMemberMDL> OSelectPaging(string strWhere, int pageSize, int currentIndex, out int recordCount) {
            return OSelectPaging(strWhere, "mbr_add_time desc", pageSize, currentIndex, out recordCount);
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
        public ObservableCollection<PfmMemberMDL> OSelectPaging(string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount) {
            StringBuilder sb = new StringBuilder();
            sb.Append("mbr_id");
            sb.Append(",mbr_add_time");
            sb.Append(",mbr_name");
            sb.Append(",mbr_relation");
            sb.Append(",mbr_description");
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
        public ObservableCollection<PfmMemberMDL> OSelectPaging(string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordCount) {
            if (string.IsNullOrEmpty(strColumns)) strColumns = "*";
            if (string.IsNullOrEmpty(strWhere)) strWhere = "1=1";
            if (string.IsNullOrEmpty(strOrder)) strOrder = "mbr_add_time desc";
            if (pageSize <= 0) pageSize = 200;
            if (currentIndex <= 0) currentIndex = 1;
            ObservableCollection<PfmMemberMDL> list = new ObservableCollection<PfmMemberMDL>();
            this.Select(strWhere, out recordCount);
            int offsetCount = (currentIndex - 1) * pageSize;
            string cmdSql = "select {0} from pfm_member where {1} order by {2} limit {3} offset {4}";
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
