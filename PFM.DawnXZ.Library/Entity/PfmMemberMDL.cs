// =================================================================== 
// 实体（PFM.DawnXZ.Library.Entity）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：PfmMemberMDL.cs
// 项目名称：请更改为实际项目名称
// 创建时间：2012年08月05日 21:11:50
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
    /// 账务成员
    /// </summary>
    [Serializable]
    public class PfmMemberMDL : EntityBase
    {

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public PfmMemberMDL()
        { }

        #endregion

        #region 公共属性

        /// <summary>
        /// 系统编号
        /// </summary>
        private long _mbrId;
        /// <summary>
        /// 系统编号
        /// </summary>
        public long MbrId
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
        private DateTime _mbrAddTime;
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime MbrAddTime
        {
            get { return this._mbrAddTime; }
            set
            {
                this._mbrAddTime = value;
                RaisePropertyChanged("MbrAddTime");
            }
        }
        /// <summary>
        /// 成员名称
        /// </summary>
        private string _mbrName;
        /// <summary>
        /// 成员名称
        /// </summary>
        public string MbrName
        {
            get { return this._mbrName; }
            set
            {
                this._mbrName = value;
                RaisePropertyChanged("MbrName");
            }
        }
        /// <summary>
        /// 成员关系
        /// </summary>
        private string _mbrRelation;
        /// <summary>
        /// 成员关系
        /// </summary>
        public string MbrRelation
        {
            get { return this._mbrRelation; }
            set
            {
                this._mbrRelation = value;
                RaisePropertyChanged("MbrRelation");
            }
        }
        /// <summary>
        /// 成员描述
        /// </summary>
        private string _mbrDescription;
        /// <summary>
        /// 成员描述
        /// </summary>
        public string MbrDescription
        {
            get { return this._mbrDescription; }
            set
            {
                this._mbrDescription = value;
                RaisePropertyChanged("MbrDescription");
            }
        }

        #endregion

    }
}
