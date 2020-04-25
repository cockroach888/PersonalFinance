// =================================================================== 
// 实体（PFM.DawnXZ.Library.Entity）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：PfmErrorMDL.cs
// 项目名称：请更改为实际项目名称
// 创建时间：2012年08月05日 21:17:52
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
    /// 错误信息
    /// </summary>
    [Serializable]
    public class PfmErrorMDL : EntityBase
    {

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public PfmErrorMDL()
        { }

        #endregion

        #region 公共属性

        /// <summary>
        /// 系统编号
        /// </summary>
        private long _errId;
        /// <summary>
        /// 系统编号
        /// </summary>
        public long ErrId
        {
            get { return this._errId; }
            set
            {
                this._errId = value;
                RaisePropertyChanged("ErrId");
            }
        }
        /// <summary>
        /// 页面名称
        /// </summary>
        private DateTime _errTime;
        /// <summary>
        /// 页面名称
        /// </summary>
        public DateTime ErrTime
        {
            get { return this._errTime; }
            set
            {
                this._errTime = value;
                RaisePropertyChanged("ErrTime");
            }
        }
        /// <summary>
        /// 页面名称
        /// </summary>
        private string _errPage;
        /// <summary>
        /// 页面名称
        /// </summary>
        public string ErrPage
        {
            get { return this._errPage; }
            set
            {
                this._errPage = value;
                RaisePropertyChanged("ErrPage");
            }
        }
        /// <summary>
        /// 错误信息
        /// </summary>
        private string _errMessage;
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrMessage
        {
            get { return this._errMessage; }
            set
            {
                this._errMessage = value;
                RaisePropertyChanged("ErrMessage");
            }
        }
        /// <summary>
        /// 错误目标
        /// </summary>
        private string _errTargetSite;
        /// <summary>
        /// 错误目标
        /// </summary>
        public string ErrTargetSite
        {
            get { return this._errTargetSite; }
            set
            {
                this._errTargetSite = value;
                RaisePropertyChanged("ErrTargetSite");
            }
        }
        /// <summary>
        /// 错误跟踪
        /// </summary>
        private string _errStackTrace;
        /// <summary>
        /// 错误跟踪
        /// </summary>
        public string ErrStackTrace
        {
            get { return this._errStackTrace; }
            set
            {
                this._errStackTrace = value;
                RaisePropertyChanged("ErrStackTrace");
            }
        }
        /// <summary>
        /// 错误数据
        /// </summary>
        private string _errSource;
        /// <summary>
        /// 错误数据
        /// </summary>
        public string ErrSource
        {
            get { return this._errSource; }
            set
            {
                this._errSource = value;
                RaisePropertyChanged("ErrSource");
            }
        }
        /// <summary>
        /// 用户IP
        /// </summary>
        private string _errIp;
        /// <summary>
        /// 用户IP
        /// </summary>
        public string ErrIp
        {
            get { return this._errIp; }
            set
            {
                this._errIp = value;
                RaisePropertyChanged("ErrIp");
            }
        }
        /// <summary>
        /// 操作用户
        /// </summary>
        private string _errName;
        /// <summary>
        /// 操作用户
        /// </summary>
        public string ErrName
        {
            get { return this._errName; }
            set
            {
                this._errName = value;
                RaisePropertyChanged("ErrName");
            }
        }

        #endregion

    }
}
