// =================================================================== 
// 实体（PFM.DawnXZ.Library.Entity）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：PfmIaeDetailedMDL.cs
// 项目名称：请更改为实际项目名称
// 创建时间：2012年08月05日 21:15:01
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
    /// 收支明细
    /// </summary>
    [Serializable]
    public class PfmIaeDetailedMDL : EntityBase
    {

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public PfmIaeDetailedMDL()
        { }

        #endregion

        #region 公共属性

        /// <summary>
        /// 系统编号
        /// </summary>
        private long _detId;
        /// <summary>
        /// 系统编号
        /// </summary>
        public long DetId
        {
            get { return this._detId; }
            set
            {
                this._detId = value;
                RaisePropertyChanged("DetId");
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
        /// 类别编号
        /// </summary>
        private int _accId;
        /// <summary>
        /// 类别编号
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
        /// 类别编号
        /// </summary>
        private int _catId;
        /// <summary>
        /// 类别编号
        /// </summary>
        public int CatId
        {
            get { return this._catId; }
            set
            {
                this._catId = value;
                RaisePropertyChanged("CatId");
            }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        private DateTime _detAddTime;
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime DetAddTime
        {
            get { return this._detAddTime; }
            set
            {
                this._detAddTime = value;
                RaisePropertyChanged("DetAddTime");
            }
        }
        /// <summary>
        /// 收支名称
        /// </summary>
        private string _detName;
        /// <summary>
        /// 收支名称
        /// </summary>
        public string DetName
        {
            get { return this._detName; }
            set
            {
                this._detName = value;
                RaisePropertyChanged("DetName");
            }
        }
        /// <summary>
        /// 收支金额
        /// </summary>
        private decimal _detMoney;
        /// <summary>
        /// 收支金额
        /// </summary>
        public decimal DetMoney
        {
            get { return this._detMoney; }
            set
            {
                this._detMoney = value;
                RaisePropertyChanged("DetMoney");
            }
        }
        /// <summary>
        /// 收支地点
        /// </summary>
        private string _detAddress;
        /// <summary>
        /// 收支地点
        /// </summary>
        public string DetAddress
        {
            get { return this._detAddress; }
            set
            {
                this._detAddress = value;
                RaisePropertyChanged("DetAddress");
            }
        }
        /// <summary>
        /// 收支描述
        /// </summary>
        private string _detDescription;
        /// <summary>
        /// 收支描述
        /// </summary>
        public string DetDescription
        {
            get { return this._detDescription; }
            set
            {
                this._detDescription = value;
                RaisePropertyChanged("DetDescription");
            }
        }
        /// <summary>
        /// 收支备忘
        /// </summary>
        private string _detMemo;
        /// <summary>
        /// 收支备忘
        /// </summary>
        public string DetMemo
        {
            get { return this._detMemo; }
            set
            {
                this._detMemo = value;
                RaisePropertyChanged("DetMemo");
            }
        }
        /// <summary>
        /// 收支状态
        /// </summary>
        private byte _detStatus;
        /// <summary>
        /// 收支状态
        /// </summary>
        public byte DetStatus
        {
            get { return this._detStatus; }
            set
            {
                this._detStatus = value;
                RaisePropertyChanged("DetStatus");
            }
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        private DateTime _detEditTime;
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime DetEditTime
        {
            get { return this._detEditTime; }
            set
            {
                this._detEditTime = value;
                RaisePropertyChanged("DetEditTime");
            }
        }
        /// <summary>
        /// 修改次数
        /// </summary>
        private int _detEditCount;
        /// <summary>
        /// 修改次数
        /// </summary>
        public int DetEditCount
        {
            get { return this._detEditCount; }
            set
            {
                this._detEditCount = value;
                RaisePropertyChanged("DetEditCount");
            }
        }
        /// <summary>
        /// 保留字段01
        /// </summary>
        private int _catBkFd01;
        /// <summary>
        /// 保留字段01
        /// </summary>
        public int CatBkFd01
        {
            get { return this._catBkFd01; }
            set
            {
                this._catBkFd01 = value;
                RaisePropertyChanged("CatBkFd01");
            }
        }
        /// <summary>
        /// 保留字段02
        /// </summary>
        private byte _catBkFd02;
        /// <summary>
        /// 保留字段02
        /// </summary>
        public byte CatBkFd02
        {
            get { return this._catBkFd02; }
            set
            {
                this._catBkFd02 = value;
                RaisePropertyChanged("CatBkFd02");
            }
        }
        /// <summary>
        /// 保留字段03
        /// </summary>
        private string _catBkFd03;
        /// <summary>
        /// 保留字段03
        /// </summary>
        public string CatBkFd03
        {
            get { return this._catBkFd03; }
            set
            {
                this._catBkFd03 = value;
                RaisePropertyChanged("CatBkFd03");
            }
        }

        #endregion

    }
}
