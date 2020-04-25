// =================================================================== 
// 实体（PFM.DawnXZ.Library.Entity）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：PfmReportRecordMDL.cs
// 项目名称：请更改为实际项目名称
// 创建时间：2012年08月05日 21:07:31
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
	/// 报表记录
	/// </summary>
	[Serializable]
	public class PfmReportRecordMDL : EntityBase
	{
		
		#region 构造函数
		
		/// <summary>
		/// 构造函数
		/// </summary>
		public PfmReportRecordMDL()
		{ }
		
		#endregion

        #region 公共属性

        /// <summary>
        /// 系统编号
        /// </summary>
        private long _rrdId;
        /// <summary>
        /// 系统编号
        /// </summary>
        public long RrdId
        {
            get { return this._rrdId; }
            set
            {
                this._rrdId = value;
                RaisePropertyChanged("RrdId");
            }
        }
        /// <summary>
        /// 报表编号
        /// </summary>
        private int _rptId;
        /// <summary>
        /// 报表编号
        /// </summary>
        public int RptId
        {
            get { return this._rptId; }
            set
            {
                this._rptId = value;
                RaisePropertyChanged("RptId");
            }
        }
        /// <summary>
        /// 成员编号
        /// </summary>
        private int _mbrId;
        /// <summary>
        /// 成员编号
        /// </summary>
        public int MbrId
        {
            get { return this._mbrId; }
            set
            {
                this._mbrId = value;
                RaisePropertyChanged("MbrId");
            }
        }
        /// <summary>
        /// 成员编号
        /// </summary>
        private int _accId;
        /// <summary>
        /// 成员编号
        /// </summary>
        public int AccId
        {
            get { return this._accId; }
            set
            {
                this._accId = value;
                RaisePropertyChanged("AccId");
            }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        private DateTime _rrdAddTime;
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime RrdAddTime
        {
            get { return this._rrdAddTime; }
            set
            {
                this._rrdAddTime = value;
                RaisePropertyChanged("RrdAddTime");
            }
        }
        /// <summary>
        /// 收入总额
        /// </summary>
        private decimal _rrdInSum;
        /// <summary>
        /// 收入总额
        /// </summary>
        public decimal RrdInSum
        {
            get { return this._rrdInSum; }
            set
            {
                this._rrdInSum = value;
                RaisePropertyChanged("RrdInSum");
            }
        }
        /// <summary>
        /// 收入次数
        /// </summary>
        private int _rrdInCount;
        /// <summary>
        /// 收入次数
        /// </summary>
        public int RrdInCount
        {
            get { return this._rrdInCount; }
            set
            {
                this._rrdInCount = value;
                RaisePropertyChanged("RrdInCount");
            }
        }
        /// <summary>
        /// 支出总额
        /// </summary>
        private decimal _rrdOutSum;
        /// <summary>
        /// 支出总额
        /// </summary>
        public decimal RrdOutSum
        {
            get { return this._rrdOutSum; }
            set
            {
                this._rrdOutSum = value;
                RaisePropertyChanged("RrdOutSum");
            }
        }
        /// <summary>
        /// 支出次数
        /// </summary>
        private int _rrdOutCount;
        /// <summary>
        /// 支出次数
        /// </summary>
        public int RrdOutCount
        {
            get { return this._rrdOutCount; }
            set
            {
                this._rrdOutCount = value;
                RaisePropertyChanged("RrdOutCount");
            }
        }
        /// <summary>
        /// 收支总额
        /// </summary>
        private decimal _rrdSum;
        /// <summary>
        /// 收支总额
        /// </summary>
        public decimal RrdSum
        {
            get { return this._rrdSum; }
            set
            {
                this._rrdSum = value;
                RaisePropertyChanged("RrdSum");
            }
        }
        /// <summary>
        /// 保留字段01
        /// </summary>
        private int _rrdBkFd01;
        /// <summary>
        /// 保留字段01
        /// </summary>
        public int RrdBkFd01
        {
            get { return this._rrdBkFd01; }
            set
            {
                this._rrdBkFd01 = value;
                RaisePropertyChanged("RrdBkFd01");
            }
        }
        /// <summary>
        /// 保留字段02
        /// </summary>
        private byte _rrdBkFd02;
        /// <summary>
        /// 保留字段02
        /// </summary>
        public byte RrdBkFd02
        {
            get { return this._rrdBkFd02; }
            set
            {
                this._rrdBkFd02 = value;
                RaisePropertyChanged("RrdBkFd02");
            }
        }
        /// <summary>
        /// 保留字段03
        /// </summary>
        private string _rrdBkFd03;
        /// <summary>
        /// 保留字段03
        /// </summary>
        public string RrdBkFd03
        {
            get { return this._rrdBkFd03; }
            set
            {
                this._rrdBkFd03 = value;
                RaisePropertyChanged("RrdBkFd03");
            }
        }
        /// <summary>
        /// 保留字段04
        /// </summary>
        private string _rrdBkFd04;
        /// <summary>
        /// 保留字段04
        /// </summary>
        public string RrdBkFd04
        {
            get { return this._rrdBkFd04; }
            set
            {
                this._rrdBkFd04 = value;
                RaisePropertyChanged("RrdBkFd04");
            }
        }

        #endregion
		
	}
}
