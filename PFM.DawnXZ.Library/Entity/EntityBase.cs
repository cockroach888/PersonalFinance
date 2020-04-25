// =================================================================== 
// 实体（PFM.DawnXZ.Library.Entity）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：EntityBase.cs
// 项目名称：个人财务管理系统
// 创建时间：2012年07月18日 17:35:56
// 创建人员：宋杰军
// 负 责 人：宋杰军
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;

namespace PFM.DawnXZ.Library.Entity
{
    /// <summary>
    /// IDataErrorInfo, INotifyPropertyChanged
    /// </summary>
    public abstract class EntityBase : IDataErrorInfo, INotifyPropertyChanged
    {
        #region 属性变化事件
        /// <summary>
        /// PropertyChangedEventHandler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// RaisePropertyChanged
        /// </summary>
        protected void RaisePropertyChanged(string propertyName)
        {
            this.VerifyPropertyName(propertyName);
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        #endregion 属性变化事件

        #region 属性验证事件
        /// <summary>
        /// ThrowOnInvalidPropertyName
        /// </summary>
        protected virtual bool ThrowOnInvalidPropertyName { get; private set; }
        /// <summary>
        /// VerifyPropertyName
        /// <param name="propertyName">属性名称</param>
        /// </summary>
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(string propertyName)
        {
            // If you raise PropertyChanged and do not specify a property name,
            // all properties on the object are considered to be changed by the binding system.
            if (String.IsNullOrEmpty(propertyName)) return;
            // Verify that the property name matches a real,  
            // public, instance property on this object.
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name: " + propertyName;
                if (this.ThrowOnInvalidPropertyName)
                {
                    throw new ArgumentException(msg);
                }
                else
                {
                    Debug.Fail(msg);
                }
            }
        }
        #endregion 属性验证事件

        #region 错误处理事件
        /// <summary>
        /// Dictionary<string, string>
        /// </summary>
        public Dictionary<string, string> Errors = new Dictionary<string, string>();

        #region IDataErrorInfo Members
        /// <summary>
        /// IDataErrorInfo Members
        /// </summary>
        public string this[string columnName]
        {
            get
            {
                if (Errors.ContainsKey(columnName))
                {
                    return Errors[columnName];
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        #endregion IDataErrorInfo Members

        /// <summary>
        /// SetError
        /// <param name="propertyName">属性名称</param>
        /// <param name="errorMessage">错误消息</param>
        /// </summary>
        public void SetError(string propertyName, string errorMessage)
        {
            Errors[propertyName] = errorMessage;
            RaisePropertyChanged(propertyName);
        }
        /// <summary>
        /// ClearError
        /// <param name="propertyName">属性名称</param>
        /// </summary>
        public void ClearError(string propertyName)
        {
            Errors.Remove(propertyName);
            RaisePropertyChanged(propertyName);
        }
        #endregion 错误处理事件

        #region 公共属性
        /// <summary>
        /// Error
        /// </summary>
        public string Error
        {
            get { return null; }
        }
        #endregion 公共属性
    }
}
