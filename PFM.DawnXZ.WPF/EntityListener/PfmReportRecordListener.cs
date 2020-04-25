// =================================================================== 
// 数据监听（PFM.DawnXZ.WPF.EntityListener）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：PfmReportRecordListener.cs
// 项目名称：个人财务管理系统
// 创建时间：2012年08月01日 16:18:00
// 创建人员：宋杰军
// 负 责 人：宋杰军
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
using System.Windows;
using System.Diagnostics;
using System.Collections.Generic;
using PFM.DawnXZ.Library.Entity;

namespace PFM.DawnXZ.WPF.EntityListener
{
    /// <summary>
    /// 数据实体[PfmReportRecord]监听类
    /// </summary>
    public class PfmReportRecordListener : DependencyObject
    {
        #region 成员方法

        /// <summary>
        /// 数据实体[PfmReportRecord]监听实例
        /// </summary>
        private static PfmReportRecordListener _listener;
        /// <summary>
        /// 数据实体[PfmReportRecord]监听实例
        /// </summary>
        public static PfmReportRecordListener Instance
        {
            get
            {
                if (_listener == null) _listener = new PfmReportRecordListener();
                return _listener;
            }
        }
        /// <summary>
        /// 数据实体[PfmReportRecord]集合
        /// </summary>
        public IList<PfmReportRecordMDL> PfmReportRecordCollection
        {
            get { return GetValue(PfmReportRecordProperty) as IList<PfmReportRecordMDL>; }
            set { SetValue(PfmReportRecordProperty, value); }
        }
        /// <summary>
        /// 数据实体[PfmReportRecord]依赖属性
        /// </summary>
        public static DependencyProperty PfmReportRecordProperty = DependencyProperty.Register("PfmReportRecordCollection", typeof(IList<PfmReportRecordMDL>), typeof(PfmReportRecordListener), new UIPropertyMetadata(null));
        /// <summary>
        /// 构造函数
        /// </summary>
        private PfmReportRecordListener()
        { }
        /// <summary>
        /// 接收数据实体[PfmReportRecord]信息
        /// </summary>
        /// <param name="list">[PfmReportRecord]数据实体</param>
        public void Receive(IList<PfmReportRecordMDL> list)
        {
            PfmReportRecordCollection = list;
            Debug.WriteLine(PfmReportRecordCollection);
            DispatcherHelper.DoEvents();
        }

        #endregion 成员方法
    }
}
