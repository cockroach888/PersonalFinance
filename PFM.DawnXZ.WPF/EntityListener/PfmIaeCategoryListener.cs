// =================================================================== 
// 数据监听（PFM.DawnXZ.WPF.EntityListener）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：PfmIaeCategoryListener.cs
// 项目名称：个人财务管理系统
// 创建时间：2012年08月01日 16:16:32
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
    /// 数据实体[PfmIaeCategory]监听类
    /// </summary>
    public class PfmIaeCategoryListener : DependencyObject
    {
        #region 成员方法

        /// <summary>
        /// 数据实体[PfmIaeCategory]监听实例
        /// </summary>
        private static PfmIaeCategoryListener _listener;
        /// <summary>
        /// 数据实体[PfmIaeCategory]监听实例
        /// </summary>
        public static PfmIaeCategoryListener Instance
        {
            get
            {
                if (_listener == null) _listener = new PfmIaeCategoryListener();
                return _listener;
            }
        }
        /// <summary>
        /// 数据实体[PfmIaeCategory]集合
        /// </summary>
        public IList<PfmIaeCategoryMDL> PfmIaeCategoryCollection
        {
            get { return GetValue(PfmIaeCategoryProperty) as IList<PfmIaeCategoryMDL>; }
            set { SetValue(PfmIaeCategoryProperty, value); }
        }
        /// <summary>
        /// 数据实体[PfmIaeCategory]依赖属性
        /// </summary>
        public static DependencyProperty PfmIaeCategoryProperty = DependencyProperty.Register("PfmIaeCategoryCollection", typeof(IList<PfmIaeCategoryMDL>), typeof(PfmIaeCategoryListener), new UIPropertyMetadata(null));
        /// <summary>
        /// 构造函数
        /// </summary>
        private PfmIaeCategoryListener()
        { }
        /// <summary>
        /// 接收数据实体[PfmIaeCategory]信息
        /// </summary>
        /// <param name="list">[PfmIaeCategory]数据实体</param>
        public void Receive(IList<PfmIaeCategoryMDL> list)
        {
            PfmIaeCategoryCollection = list;
            Debug.WriteLine(PfmIaeCategoryCollection);
            DispatcherHelper.DoEvents();
        }

        #endregion 成员方法
    }
}
