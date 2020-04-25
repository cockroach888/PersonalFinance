// =================================================================== 
// 实体（PFM.DawnXZ.Library.Entity）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：PfmIaeItemsMDL.cs
// 项目名称：请更改为实际项目名称
// 创建时间：2012年08月05日 21:13:53
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
    /// 收支项目
    /// </summary>
    [Serializable]
    public class PfmIaeItemsMDL : EntityBase
    {

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public PfmIaeItemsMDL()
        { }

        #endregion

        #region 公共属性

        /// <summary>
        /// 系统编号
        /// </summary>
        private long _itemId;
        /// <summary>
        /// 系统编号
        /// </summary>
        public long ItemId
        {
            get { return this._itemId; }
            set
            {
                this._itemId = value;
                RaisePropertyChanged("ItemId");
            }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        private DateTime _itemAddTime;
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime ItemAddTime
        {
            get { return this._itemAddTime; }
            set
            {
                this._itemAddTime = value;
                RaisePropertyChanged("ItemAddTime");
            }
        }
        /// <summary>
        /// 项目状态
        /// </summary>
        private byte _itemStatus;
        /// <summary>
        /// 项目状态
        /// </summary>
        public byte ItemStatus
        {
            get { return this._itemStatus; }
            set
            {
                this._itemStatus = value;
                RaisePropertyChanged("ItemStatus");
            }
        }
        /// <summary>
        /// 项目类别
        /// </summary>
        private byte _itemType;
        /// <summary>
        /// 项目类别
        /// </summary>
        public byte ItemType
        {
            get { return this._itemType; }
            set
            {
                this._itemType = value;
                RaisePropertyChanged("ItemType");
            }
        }
        /// <summary>
        /// 项目名称
        /// </summary>
        private string _itemName;
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ItemName
        {
            get { return this._itemName; }
            set
            {
                this._itemName = value;
                RaisePropertyChanged("ItemName");
            }
        }
        /// <summary>
        /// 项目说明
        /// </summary>
        private string _itemDescription;
        /// <summary>
        /// 项目说明
        /// </summary>
        public string ItemDescription
        {
            get { return this._itemDescription; }
            set
            {
                this._itemDescription = value;
                RaisePropertyChanged("ItemDescription");
            }
        }

        #endregion

    }
}
