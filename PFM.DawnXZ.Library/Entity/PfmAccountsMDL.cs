// =================================================================== 
// 实体（PFM.DawnXZ.Library.Entity）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：PfmAccountsMDL.cs
// 项目名称：请更改为实际项目名称
// 创建时间：2012年08月05日 21:19:43
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
    /// 账务账目
    /// </summary>
    [Serializable]
    public class PfmAccountsMDL : EntityBase
    {

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public PfmAccountsMDL()
        { }

        #endregion

        #region 公共属性

        /// <summary>
        /// 系统编号
        /// </summary>
        private long _accId;
        /// <summary>
        /// 系统编号
        /// </summary>
        public long AccId
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
        private int _mbrId;
        /// <summary>
        /// 添加时间
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
        /// 添加时间
        /// </summary>
        private DateTime _accAddTime;
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AccAddTime
        {
            get { return this._accAddTime; }
            set
            {
                this._accAddTime = value;
                RaisePropertyChanged("AccAddTime");
            }
        }
        /// <summary>
        /// 账目状态
        /// </summary>
        private byte _accStatus;
        /// <summary>
        /// 账目状态
        /// </summary>
        public byte AccStatus
        {
            get { return this._accStatus; }
            set
            {
                this._accStatus = value;
                RaisePropertyChanged("AccStatus");
            }
        }
        /// <summary>
        /// 账目名称
        /// </summary>
        private string _accName;
        /// <summary>
        /// 账目名称
        /// </summary>
        public string AccName
        {
            get { return this._accName; }
            set
            {
                this._accName = value;
                RaisePropertyChanged("AccName");
            }
        }
        /// <summary>
        /// 账目编码
        /// </summary>
        private string _accCode;
        /// <summary>
        /// 账目编码
        /// </summary>
        public string AccCode
        {
            get { return this._accCode; }
            set
            {
                this._accCode = value;
                RaisePropertyChanged("AccCode");
            }
        }
        /// <summary>
        /// 账目卡号
        /// </summary>
        private string _accCard;
        /// <summary>
        /// 账目卡号
        /// </summary>
        public string AccCard
        {
            get { return this._accCard; }
            set
            {
                this._accCard = value;
                RaisePropertyChanged("AccCard");
            }
        }
        /// <summary>
        /// 账目用途
        /// </summary>
        private string _accPurpose;
        /// <summary>
        /// 账目用途
        /// </summary>
        public string AccPurpose
        {
            get { return this._accPurpose; }
            set
            {
                this._accPurpose = value;
                RaisePropertyChanged("AccPurpose");
            }
        }
        /// <summary>
        /// 账目描述
        /// </summary>
        private string _accDescription;
        /// <summary>
        /// 账目描述
        /// </summary>
        public string AccDescription
        {
            get { return this._accDescription; }
            set
            {
                this._accDescription = value;
                RaisePropertyChanged("AccDescription");
            }
        }

        #endregion

    }
}
