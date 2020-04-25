// =================================================================== 
// 数据监听（PFM.DawnXZ.WPF.EntityListener）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：PfmIaeDetailedListener.cs
// 项目名称：个人财务管理系统
// 创建时间：2012年08月01日 16:16:46
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
    /// 数据实体[PfmIaeDetailed]监听类
    /// </summary>
    public class PfmIaeDetailedListener : DependencyObject
    {
        #region 成员方法

        /// <summary>
        /// 数据实体[PfmIaeDetailed]监听实例
        /// </summary>
        private static PfmIaeDetailedListener _listener;
        /// <summary>
        /// 数据实体[PfmIaeDetailed]监听实例
        /// </summary>
        public static PfmIaeDetailedListener Instance
        {
            get
            {
                if (_listener == null) _listener = new PfmIaeDetailedListener();
                return _listener;
            }
        }
        /// <summary>
        /// 数据实体[PfmIaeDetailed]集合
        /// </summary>
        public IList<PfmIaeDetailedMDL> PfmIaeDetailedCollection
        {
            get { return GetValue(PfmIaeDetailedProperty) as IList<PfmIaeDetailedMDL>; }
            set { SetValue(PfmIaeDetailedProperty, value); }
        }
        /// <summary>
        /// 数据实体[PfmIaeDetailed]依赖属性
        /// </summary>
        public static DependencyProperty PfmIaeDetailedProperty = DependencyProperty.Register("PfmIaeDetailedCollection", typeof(IList<PfmIaeDetailedMDL>), typeof(PfmIaeDetailedListener), new UIPropertyMetadata(null));
        /// <summary>
        /// 构造函数
        /// </summary>
        private PfmIaeDetailedListener()
        { }
        /// <summary>
        /// 接收数据实体[PfmIaeDetailed]信息
        /// </summary>
        /// <param name="list">[PfmIaeDetailed]数据实体</param>
        public void Receive(IList<PfmIaeDetailedMDL> list)
        {
            PfmIaeDetailedCollection = list;
            Debug.WriteLine(PfmIaeDetailedCollection);
            DispatcherHelper.DoEvents();
        }

        #endregion 成员方法
    }
}
