// =================================================================== 
// 数据监听（PFM.DawnXZ.WPF.EntityListener）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：PfmAccountsListener.cs
// 项目名称：个人财务管理系统
// 创建时间：2012年08月01日 16:16:00
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
    /// 数据实体[PfmAccounts]监听类
    /// </summary>
    public class PfmAccountsListener : DependencyObject
    {
        #region 成员方法

        /// <summary>
        /// 数据实体[PfmAccounts]监听实例
        /// </summary>
        private static PfmAccountsListener _listener;
        /// <summary>
        /// 数据实体[PfmAccounts]监听实例
        /// </summary>
        public static PfmAccountsListener Instance
        {
            get
            {
                if (_listener == null) _listener = new PfmAccountsListener();
                return _listener;
            }
        }
        /// <summary>
        /// 数据实体[PfmAccounts]集合
        /// </summary>
        public IList<PfmAccountsMDL> PfmAccountsCollection
        {
            get { return GetValue(PfmAccountsProperty) as IList<PfmAccountsMDL>; }
            set { SetValue(PfmAccountsProperty, value); }
        }
        /// <summary>
        /// 数据实体[PfmAccounts]依赖属性
        /// </summary>
        public static DependencyProperty PfmAccountsProperty = DependencyProperty.Register("PfmAccountsCollection", typeof(IList<PfmAccountsMDL>), typeof(PfmAccountsListener), new UIPropertyMetadata(null));
        /// <summary>
        /// 构造函数
        /// </summary>
        private PfmAccountsListener()
        { }
        /// <summary>
        /// 接收数据实体[PfmAccounts]信息
        /// </summary>
        /// <param name="list">[PfmAccounts]数据实体</param>
        public void Receive(IList<PfmAccountsMDL> list)
        {
            PfmAccountsCollection = list;
            Debug.WriteLine(PfmAccountsCollection);
            DispatcherHelper.DoEvents();
        }

        #endregion 成员方法
    }
}
