using System;
using System.Windows;

namespace PFM.DawnXZ.WPF.Codes
{
    /// <summary>
    /// General commissioned a single parameter
    /// </summary>
    public class DelegateSingle
    {
        #region Delegate & Event
        /// <summary>
        /// Declare a delegate
        /// </summary>
        /// <param name="sender">The delegate object</param>
        /// <param name="e">The delegate event</param>
        public delegate void UpdateInfoEventHandler(object sender, UpdateInfoEventArgs e);
        /// <summary>
        /// Declare a delegate event
        /// </summary>
        private event UpdateInfoEventHandler UpdateInfo;
        #endregion Delegate & Event

        #region Delegate event class
        /// <summary>
        /// Delegate event class
        /// </summary>
        public class UpdateInfoEventArgs : EventArgs
        {
            /// <summary>
            /// To update the information
            /// </summary>
            public readonly string _strInfo;
            /// <summary>
            /// Constructed function
            /// </summary>            
            /// <param name="strInfo">To update the information</param>
            public UpdateInfoEventArgs(string strInfo)
            {
                this._strInfo = strInfo;
            }
        }
        #endregion Delegate event class

        #region Register & UnRegister
        /// <summary>
        /// To register more than one method for an event
        /// </summary>
        /// <param name="method">Method name</param>
        public void Register(UpdateInfoEventHandler method)
        {
            UpdateInfo += method;
        }
        /// <summary>
        /// Registered with the event a unique method
        /// </summary>
        /// <param name="method">Method name</param>
        public void RegisterOnly(UpdateInfoEventHandler method)
        {
            UpdateInfo = method;
        }
        /// <summary>
        /// Registered with the event against method
        /// </summary>
        /// <param name="method">Method name</param>
        public void UnRegister(UpdateInfoEventHandler method)
        {
            UpdateInfo -= method;
        }
        /// <summary>
        /// Registered with the event against method
        /// </summary>
        public void UnRegister()
        {
            UpdateInfo = null;
        }
        #endregion Register & UnRegister

        #region Virtual
        /// <summary>
        /// Can be overridden execute method
        /// </summary>
        /// <param name="wid">System.Windows.Window</param>
        /// <param name="e">The delegate event</param>
        protected virtual void OnUpdateInfo(Window wid, UpdateInfoEventArgs e)
        {
            if (UpdateInfo != null && wid != null) wid.Dispatcher.Invoke(UpdateInfo, this, e);
        }
        #endregion Virtual

        #region Member method
        /// <summary>
        /// Executes a delegate method
        /// </summary>
        /// <param name="wid">System.Windows.Window</param>
        /// <param name="strInfo">To update the information</param>
        public void Executes(Window wid, string strInfo)
        {
            UpdateInfoEventArgs e = new UpdateInfoEventArgs(strInfo);
            OnUpdateInfo(wid, e);
            e = null;
        }
        #endregion Member method
    }
}
