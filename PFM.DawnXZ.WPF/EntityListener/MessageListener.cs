// =================================================================== 
// 数据监听（PFM.DawnXZ.WPF.EntityListener）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：MessageListener.cs
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
    /// Message listener, singlton pattern.
    /// <remarks>
    /// Inherit from DependencyObject to implement DataBinding.
    /// </remarks>
    /// </summary>
    public class MessageListener : DependencyObject
    {
        #region 成员方法

        /// <summary>
        /// 消息监听
        /// </summary>
        private static MessageListener mInstance;
        /// <summary>
        /// Get MessageListener instance
        /// </summary>
        public static MessageListener Instance
        {
            get
            {
                if (mInstance == null) mInstance = new MessageListener();
                return mInstance;
            }
        }
        /// <summary>
        /// Get or set received message
        /// </summary>
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }
        /// <summary>
        /// 消息属性
        /// </summary>
        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(MessageListener), new UIPropertyMetadata(null));
        /// <summary>
        /// 构造函数
        /// </summary>
        private MessageListener()
        { }
        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="message">消息</param>
        public void Receive(string message)
        {
            Message = message;
            Debug.WriteLine(Message);
            DispatcherHelper.DoEvents();
        }

        #endregion 成员方法
    }
}
