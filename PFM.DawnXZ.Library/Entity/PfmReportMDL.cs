// =================================================================== 
// 实体（PFM.DawnXZ.Library.Entity）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：PfmReportMDL.cs
// 项目名称：请更改为实际项目名称
// 创建时间：2012年08月05日 21:10:27
// 创建人员：宋杰军
// 负 责 人：宋杰军
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
using System;
using System.Collections.Generic;

namespace PFM.DawnXZ.Library.Entity
{
    /// <summary>
    /// 报表信息
    /// </summary>
    [Serializable]
    public class PfmReportMDL : EntityBase
    {

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public PfmReportMDL()
        { }

        #endregion

        #region 公共属性

        /// <summary>
        /// 系统编号
        /// </summary>
        private long _rptId;
        /// <summary>
        /// 系统编号
        /// </summary>
        public long RptId
        {
            get { return this._rptId; }
            set
            {
                this._rptId = value;
                RaisePropertyChanged("RptId");
            }
        }
        /// <summary>
        /// 账务字典标识
        /// </summary>
        private byte _dictMark;
        /// <summary>
        /// 账务字典标识
        /// </summary>
        public byte DictMark
        {
            get { return this._dictMark; }
            set
            {
                this._dictMark = value;
                RaisePropertyChanged("DictMark");
            }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime _rptTime;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime RptTime
        {
            get { return this._rptTime; }
            set
            {
                this._rptTime = value;
                RaisePropertyChanged("RptTime");
            }
        }
        /// <summary>
        /// 报表日期
        /// </summary>
        private DateTime _rptDate;
        /// <summary>
        /// 报表日期
        /// </summary>
        public DateTime RptDate
        {
            get { return this._rptDate; }
            set
            {
                this._rptDate = value;
                RaisePropertyChanged("RptDate");
            }
        }
        /// <summary>
        /// 报表状态
        /// </summary>
        private byte _rptState;
        /// <summary>
        /// 报表状态
        /// </summary>
        public byte RptState
        {
            get { return this._rptState; }
            set
            {
                this._rptState = value;
                RaisePropertyChanged("RptState");
            }
        }
        /// <summary>
        /// 报表名称
        /// </summary>
        private string _rptName;
        /// <summary>
        /// 报表名称
        /// </summary>
        public string RptName
        {
            get { return this._rptName; }
            set
            {
                this._rptName = value;
                RaisePropertyChanged("RptName");
            }
        }
        /// <summary>
        /// 报表备忘
        /// </summary>
        private string _rptMemo;
        /// <summary>
        /// 报表备忘
        /// </summary>
        public string RptMemo
        {
            get { return this._rptMemo; }
            set
            {
                this._rptMemo = value;
                RaisePropertyChanged("RptMemo");
            }
        }
        /// <summary>
        /// 保留字段01
        /// </summary>
        private int _rptBkFd01;
        /// <summary>
        /// 保留字段01
        /// </summary>
        public int RptBkFd01
        {
            get { return this._rptBkFd01; }
            set
            {
                this._rptBkFd01 = value;
                RaisePropertyChanged("RptBkFd01");
            }
        }
        /// <summary>
        /// 保留字段02
        /// </summary>
        private byte _rptBkFd02;
        /// <summary>
        /// 保留字段02
        /// </summary>
        public byte RptBkFd02
        {
            get { return this._rptBkFd02; }
            set
            {
                this._rptBkFd02 = value;
                RaisePropertyChanged("RptBkFd02");
            }
        }
        /// <summary>
        /// 保留字段03
        /// </summary>
        private string _rptBkFd03;
        /// <summary>
        /// 保留字段03
        /// </summary>
        public string RptBkFd03
        {
            get { return this._rptBkFd03; }
            set
            {
                this._rptBkFd03 = value;
                RaisePropertyChanged("RptBkFd03");
            }
        }
        /// <summary>
        /// 保留字段04
        /// </summary>
        private string _rptBkFd04;
        /// <summary>
        /// 保留字段04
        /// </summary>
        public string RptBkFd04
        {
            get { return this._rptBkFd04; }
            set
            {
                this._rptBkFd04 = value;
                RaisePropertyChanged("RptBkFd04");
            }
        }

        #endregion

    }
}
