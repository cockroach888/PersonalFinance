// =================================================================== 
// 数据监听（PFM.DawnXZ.WPF.EntityListener）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：PfmDictionaryListener.cs
// 项目名称：个人财务管理系统
// 创建时间：2012年08月01日 16:16:15
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
    /// 数据实体[PfmDictionary]监听类
    /// </summary>
    public class PfmDictionaryListener : DependencyObject
    {
        #region 成员方法

        /// <summary>
        /// 数据实体[PfmDictionary]监听实例
        /// </summary>
        private static PfmDictionaryListener _listener;
        /// <summary>
        /// 数据实体[PfmDictionary]监听实例
        /// </summary>
        public static PfmDictionaryListener Instance
        {
            get
            {
                if (_listener == null) _listener = new PfmDictionaryListener();
                return _listener;
            }
        }
        /// <summary>
        /// 数据实体[PfmDictionary]集合
        /// </summary>
        public IList<PfmDictionaryMDL> PfmDictionaryCollection
        {
            get { return GetValue(PfmDictionaryProperty) as IList<PfmDictionaryMDL>; }
            set { SetValue(PfmDictionaryProperty, value); }
        }
        /// <summary>
        /// 数据实体[PfmDictionary]依赖属性
        /// </summary>
        public static DependencyProperty PfmDictionaryProperty = DependencyProperty.Register("PfmDictionaryCollection", typeof(IList<PfmDictionaryMDL>), typeof(PfmDictionaryListener), new UIPropertyMetadata(null));
        /// <summary>
        /// 构造函数
        /// </summary>
        private PfmDictionaryListener()
        { }
        /// <summary>
        /// 接收数据实体[PfmDictionary]信息
        /// </summary>
        /// <param name="list">[PfmDictionary]数据实体</param>
        public void Receive(IList<PfmDictionaryMDL> list)
        {
            PfmDictionaryCollection = list;
            Debug.WriteLine(PfmDictionaryCollection);
            DispatcherHelper.DoEvents();
        }

        #endregion 成员方法
    }
}
