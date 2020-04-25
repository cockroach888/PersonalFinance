using System;
using System.Windows;
using System.Windows.Threading;

namespace PFM.DawnXZ.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// 应用程序获得焦点的时候触发
        /// </summary>
        /// <param name="e"></param>
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            //TODO  your code
        }
        /// <summary>
        /// 应用程序失去焦点的时候触发
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);

            //TODO  your code
        }
        /// <summary>
        /// 应用程序关闭前调用
        /// </summary>
        /// <param name="e"></param>
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            //TODO  your code
        }
        /// <summary>
        /// app.Run()的时候触发
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //TODO  your code
            //注册Application_Error
            this.DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);
        }
        /// <summary>
        /// 系统关机前调用
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSessionEnding(SessionEndingCancelEventArgs e)
        {
            base.OnSessionEnding(e);

            //TODO  your code
        }

        /// <summary>
        /// 全局异常处理逻辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            int rec = PFM.DawnXZ.Library.Transit.ErrorTsit.Insert(e.Exception);
            PFM.DawnXZ.Library.Transit.LoggerTsit.Write(e.Exception);
            MessageBox.Show("发生异常，请确认操作是否正确！详情请于《错误消息》浏览。", "错误", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            //处理完后，我们需要将Handler=true表示已此异常已处理过
            e.Handled = true;
        }

    }
}
