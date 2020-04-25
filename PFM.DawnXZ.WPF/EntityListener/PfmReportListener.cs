// =================================================================== 
// 数据监听（PFM.DawnXZ.WPF.EntityListener）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：PfmReportListener.cs
// 项目名称：个人财务管理系统
// 创建时间：2012年08月01日 16:17:45
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
    /// 数据实体[PfmReport]监听类
    /// </summary>
    public class PfmReportListener : DependencyObject
    {
        #region 成员方法

        /// <summary>
        /// 数据实体[PfmReport]监听实例
        /// </summary>
        private static PfmReportListener _listener;
        /// <summary>
        /// 数据实体[PfmReport]监听实例
        /// </summary>
        public static PfmReportListener Instance
        {
            get
            {
                if (_listener == null) _listener = new PfmReportListener();
                return _listener;
            }
        }
        /// <summary>
        /// 数据实体[PfmReport]集合
        /// </summary>
        public IList<PfmReportMDL> PfmReportCollection
        {
            get { return GetValue(PfmReportProperty) as IList<PfmReportMDL>; }
            set { SetValue(PfmReportProperty, value); }
        }
        /// <summary>
        /// 数据实体[PfmReport]依赖属性
        /// </summary>
        public static DependencyProperty PfmReportProperty = DependencyProperty.Register("PfmReportCollection", typeof(IList<PfmReportMDL>), typeof(PfmReportListener), new UIPropertyMetadata(null));
        /// <summary>
        /// 构造函数
        /// </summary>
        private PfmReportListener()
        { }
        /// <summary>
        /// 接收数据实体[PfmReport]信息
        /// </summary>
        /// <param name="list">[PfmReport]数据实体</param>
        public void Receive(IList<PfmReportMDL> list)
        {
            PfmReportCollection = list;
            Debug.WriteLine(PfmReportCollection);
            DispatcherHelper.DoEvents();
        }

        #endregion 成员方法
    }
}
