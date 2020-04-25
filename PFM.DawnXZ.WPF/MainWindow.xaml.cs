using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Threading;
using PFM.DawnXZ.Library.Transit;

namespace PFM.DawnXZ.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Variable & 变量

        #endregion Variable & 变量

        #region Instance variables & 实例变量
        /// <summary>
        /// 模块名称
        /// </summary>
        private NameItemsTsit _nameItems;
        /// <summary>
        /// 系统托盘图标
        /// </summary>
        //private System.Windows.Forms.NotifyIcon _notifyIcon;
        #endregion Instance variables & 实例变量

        #region UserControls & 用户控件
        /// <summary>
        /// 收支明细
        /// </summary>
        private UserControls.CIaeDetailed _cIaeDetailed;
        /// <summary>
        /// 收支项目
        /// </summary>
        private UserControls.CIaeItems _cIaeItems;
        /// <summary>
        /// 收支类别
        /// </summary>
        private UserControls.CIaeCategory _cIaeCategory;
        /// <summary>
        /// 账务账目
        /// </summary>
        private UserControls.CAccounts _cAccounts;
        /// <summary>
        /// 账务成员
        /// </summary>
        private UserControls.CMember _cMember;
        /// <summary>
        /// 报表信息
        /// </summary>
        private UserControls.CReport _cReport;
        /// <summary>
        /// 账务字典
        /// </summary>
        private UserControls.CDictionary _cDictionary;
        /// <summary>
        /// 日志信息
        /// </summary>
        private UserControls.CLogs _cLogs;
        /// <summary>
        /// 错误信息
        /// </summary>
        private UserControls.CError _cError;
        /// <summary>
        /// 关于系统
        /// </summary>
        private UserControls.CAbout _cAbout;
        /// <summary>
        /// 系统设置
        /// </summary>
        private UserControls.CSystem _cSystem;
        #endregion UserControls & 用户控件

        #region UserControls & 用户控件·添加界面
        /// <summary>
        /// 账务成员·添加界面
        /// </summary>
        private UserControls.CMemberAdd _cMemberAdd;
        /// <summary>
        /// 账务账目·添加界面
        /// </summary>
        private UserControls.CAccountsAdd _cAccountsAdd;
        /// <summary>
        /// 收支类别·添加界面
        /// </summary>
        private UserControls.CIaeCategoryAdd _cIaeCategoryAdd;
        /// <summary>
        /// 收支项目·添加界面
        /// </summary>
        private UserControls.CIaeItemsAdd _cIaeItemsAdd;
        /// <summary>
        /// 收支明细·添加界面
        /// </summary>
        private UserControls.CIaeDetailedAdd _cIaeDetailedAdd;
        /// <summary>
        /// 报表信息·添加界面
        /// </summary>
        private UserControls.CReportAdd _cReportAdd;
        /// <summary>
        /// 报表信息·详细信息
        /// </summary>
        private UserControls.CReportDetailed _cReportDetailed;
        #endregion UserControls & 用户控件·添加界面

        #region Constant & 常量

        #endregion Constant & 常量

        #region Attribute & 属性
        /// <summary>
        /// 窗口句柄
        /// </summary>
        public IntPtr Handle
        {
            get { return new System.Windows.Interop.WindowInteropHelper(this).Handle; }
        }
        #endregion Attribute & 属性

        #region Constructed function & 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public MainWindow()
        {
            Codes.Splasher.Splash = new SplashScreen();
            InitializeComponent();
        }
        #endregion Constructed function & 构造函数

        #region Error Handling
        /// <summary>
        /// Error Handling
        /// </summary>
        /// <param name="ex">Exception</param>
        private void ErrorHandling(Exception ex)
        {
            LoggerTsit.Write(string.Format("Error Message: {0}", ex.Message));
            LoggerTsit.Write(string.Format("Error Description: {0}", ex.StackTrace));
        }
        #endregion Error Handling

        #region private method & 私有方法
        /// <summary>
        /// 装载消息内容
        /// </summary>
        /// <param name="msgInfo">消息内容</param>
        private void LoadingMessage(string msgInfo)
        {
            EntityListener.MessageListener.Instance.Receive(msgInfo);
        }
        #endregion private method & 私有方法

        #region public method & 公共方法
        /// <summary>
        /// 获得窗口句柄
        /// </summary>
        /// <param name="widName">窗口名称</param>
        /// <returns></returns>
        public IntPtr GetHandle(Window widName)
        {
            return new System.Windows.Interop.WindowInteropHelper(widName).Handle;
        }
        #endregion public method & 公共方法

        #region 初始化

        #region 初始化窗体私有
        /// <summary>
        ///  初始化窗体私有
        /// </summary>
        private void InitializePrivate()
        {
            this.LoadingMessage("初始化模块放置画布...");
            Thread.Sleep(100);
            dplContorls.Width = 734;
            dplContorls.Height = 448;
            dplContorls.Margin = new Thickness(87, 62, 89, 66);
            dplContorls.Visibility = Visibility.Hidden;
        }
        #endregion 初始化窗体私有

        #region 初始化·值
        /// <summary>
        /// 初始化·值
        /// </summary>
        private void InitializeThis()
        {
            this.LoadingMessage("初始化主界面及获取软件版本号...");
            Thread.Sleep(100);
            lblVer.Content = Tools.GetVer;
            lblModelTitle.Content = this._nameItems[(int)NameItems.Main];
        }
        #endregion 初始化·值

        #region 初始化实例
        /// <summary>
        /// 初始化实例
        /// </summary>
        private void InitializeInstance()
        {
            //this.LoadingMessage("测试闪屏文本内容......初始实例");
            //Thread.Sleep(100);
            this._nameItems = new NameItemsTsit();
        }
        #endregion 初始化实例

        #region 初始化窗口
        /// <summary>
        /// 初始化窗口
        /// </summary>
        private void InitializeWindow()
        {
            //收支明细
            this.LoadingMessage("初始化用户控件《收支明细》...");
            Thread.Sleep(100);
            this._cIaeDetailed = new UserControls.CIaeDetailed();
            this._cIaeDetailed.ModuleExtend += new DelegateList.ModuleExtendEventHandler(ModuleExtend);
            //收支项目
            this.LoadingMessage("初始化用户控件《收支项目》...");
            Thread.Sleep(100);
            this._cIaeItems = new UserControls.CIaeItems();
            this._cIaeItems.ModuleExtend += new DelegateList.ModuleExtendEventHandler(ModuleExtend);
            //收支类别
            this.LoadingMessage("初始化用户控件《收支类别》...");
            Thread.Sleep(100);
            this._cIaeCategory = new UserControls.CIaeCategory();
            this._cIaeCategory.ModuleExtend += new DelegateList.ModuleExtendEventHandler(ModuleExtend);
            //账务账目
            this.LoadingMessage("初始化用户控件《账务账目》...");
            Thread.Sleep(100);
            this._cAccounts = new UserControls.CAccounts();
            this._cAccounts.ModuleExtend += new DelegateList.ModuleExtendEventHandler(ModuleExtend);
            //账务成员
            this.LoadingMessage("初始化用户控件《账务成员》...");
            Thread.Sleep(100);
            this._cMember = new UserControls.CMember();
            this._cMember.ModuleExtend += new DelegateList.ModuleExtendEventHandler(ModuleExtend);
            //报表信息
            this.LoadingMessage("初始化用户控件《报表信息》...");
            Thread.Sleep(100);
            this._cReport = new UserControls.CReport();
            this._cReport.ModuleExtend += new DelegateList.ModuleExtendEventHandler(ModuleExtend);
            this._cReport.ReportView += new DelegateList.ReportViewEventHandler(ReportView);
            //账务字典
            this.LoadingMessage("初始化用户控件《账务字典》...");
            Thread.Sleep(100);
            this._cDictionary = new UserControls.CDictionary();
            //日志信息
            this.LoadingMessage("初始化用户控件《日志信息》...");
            Thread.Sleep(100);
            this._cLogs = new UserControls.CLogs();
            //错误信息
            this.LoadingMessage("初始化用户控件《错误信息》...");
            Thread.Sleep(100);
            this._cError = new UserControls.CError();
            //关于系统
            this.LoadingMessage("初始化用户控件《关于系统》...");
            Thread.Sleep(100);
            this._cAbout = new UserControls.CAbout();
            //系统设置
            this.LoadingMessage("初始化用户控件《系统设置》...");
            Thread.Sleep(100);
            this._cSystem = new UserControls.CSystem();
        }
        #endregion 初始化窗口

        #region 初始化所有添加窗口
        /// <summary>
        /// 初始化所有添加窗口
        /// </summary>
        private void InitializeWindowByAdd()
        {
            //收支明细
            this.LoadingMessage("初始化用户控件《收支明细》添加界面...");
            Thread.Sleep(100);
            this._cIaeDetailedAdd = new UserControls.CIaeDetailedAdd();
            this._cIaeDetailedAdd.ModuleExtend += new DelegateList.ModuleExtendEventHandler(ModuleExtend);
            //收支项目
            this.LoadingMessage("初始化用户控件《收支项目》添加界面...");
            Thread.Sleep(100);
            this._cIaeItemsAdd = new UserControls.CIaeItemsAdd();
            this._cIaeItemsAdd.ModuleExtend += new DelegateList.ModuleExtendEventHandler(ModuleExtend);
            //收支类别
            this.LoadingMessage("初始化用户控件《收支类别》添加界面...");
            Thread.Sleep(100);
            this._cIaeCategoryAdd = new UserControls.CIaeCategoryAdd();
            this._cIaeCategoryAdd.ModuleExtend += new DelegateList.ModuleExtendEventHandler(ModuleExtend);
            //账务账目
            this.LoadingMessage("初始化用户控件《账务账目》添加界面...");
            Thread.Sleep(100);
            this._cAccountsAdd = new UserControls.CAccountsAdd();
            this._cAccountsAdd.ModuleExtend += new DelegateList.ModuleExtendEventHandler(ModuleExtend);
            //账务成员
            this.LoadingMessage("初始化用户控件《账务成员》添加界面...");
            Thread.Sleep(100);
            this._cMemberAdd = new UserControls.CMemberAdd();
            this._cMemberAdd.ModuleExtend += new DelegateList.ModuleExtendEventHandler(ModuleExtend);
            //报表信息
            this.LoadingMessage("初始化用户控件《报表信息》添加界面...");
            Thread.Sleep(100);
            this._cReportAdd = new UserControls.CReportAdd();
            this._cReportAdd.ModuleExtend += new DelegateList.ModuleExtendEventHandler(ModuleExtend);
            this.LoadingMessage("初始化用户控件《报表信息》详细信息界面...");
            Thread.Sleep(100);
            this._cReportDetailed = new UserControls.CReportDetailed();
            this._cReportDetailed.ModuleExtend += new DelegateList.ModuleExtendEventHandler(ModuleExtend);
        }
        #endregion 初始化所有添加窗口

        #region 初始化窗口大小
        /// <summary>
        /// 初始化窗口大小
        /// </summary>
        private void InitializeSize()
        {            
            //this.LoadingMessage("测试闪屏文本内容......初始本窗口");
            //Thread.Sleep(100);
        }
        #endregion 初始化窗口大小

        #endregion 初始化

        #region 系统托盘图标
        ///// <summary>
        ///// 初始化系统托盘图标
        ///// </summary>
        //private void InitializeNotifyIcon()
        //{
        //    //设置托盘的各个属性
        //    _notifyIcon = new System.Windows.Forms.NotifyIcon();
        //    _notifyIcon.BalloonTipText = "systray runnning...";
        //    _notifyIcon.Text = "systray";
        //    _notifyIcon.Icon = new System.Drawing.Icon("../../Icons/sys.ico");
        //    _notifyIcon.Visible = true;
        //    _notifyIcon.ShowBalloonTip(2000);
        //    _notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(notifyIcon_MouseClick);
        //    //设置菜单项
        //    System.Windows.Forms.MenuItem setting1 = new System.Windows.Forms.MenuItem("setting1");
        //    System.Windows.Forms.MenuItem setting2 = new System.Windows.Forms.MenuItem("setting2");
        //    System.Windows.Forms.MenuItem setting = new System.Windows.Forms.MenuItem("setting", new System.Windows.Forms.MenuItem[] { setting1, setting2 });
        //    //帮助选项
        //    System.Windows.Forms.MenuItem help = new System.Windows.Forms.MenuItem("help");
        //    //关于选项
        //    System.Windows.Forms.MenuItem about = new System.Windows.Forms.MenuItem("about");
        //    //退出菜单项
        //    System.Windows.Forms.MenuItem exit = new System.Windows.Forms.MenuItem("exit");
        //    exit.Click += new EventHandler(exit_Click);
        //    //关联托盘控件
        //    System.Windows.Forms.MenuItem[] childen = new System.Windows.Forms.MenuItem[] { setting, help, about, exit };
        //    _notifyIcon.ContextMenu = new System.Windows.Forms.ContextMenu(childen);
        //    //窗体状态改变时候触发
        //    this.StateChanged += new EventHandler(SysTray_StateChanged);
        //}
        ///// <summary>
        ///// 鼠标单击
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void notifyIcon_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        //{
        //    //如果鼠标左键单击
        //    if (e.Button == System.Windows.Forms.MouseButtons.Left)
        //    {
        //        if (this.Visibility == Visibility.Visible)
        //        {
        //            this.Visibility = Visibility.Hidden;
        //        }
        //        else
        //        {
        //            this.Visibility = Visibility.Visible;
        //            this.Activate();
        //        }
        //    }
        //}
        ///// <summary>
        ///// 窗体状态改变时候触发
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void SysTray_StateChanged(object sender, EventArgs e)
        //{
        //    if (this.WindowState == WindowState.Minimized)
        //    {
        //        this.Visibility = Visibility.Hidden;
        //    }
        //}
        ///// <summary>
        ///// 退出选项
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void exit_Click(object sender, EventArgs e)
        //{
        //    if (MessageBox.Show("您确定要退出个人账务管理系统吗？", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
        //    {
        //        LoggerTsit.Write("退出系统！");
        //        this.Close();
        //    }
        //}
        #endregion 系统托盘图标

        #region 窗体事件

        #region 窗体初始化
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Initialized(object sender, EventArgs e)
        {
            this.Hide();
            Codes.Splasher.ShowSplash();
            //this.InitializeNotifyIcon();
            this.InitializePrivate();
            this.InitializeInstance();
            this.InitializeThis();            
            this.InitializeWindow();
            this.InitializeWindowByAdd();
            this.InitializeSize();
            Codes.Splasher.CloseSplash();
            this.Show();
            //this.Activate();
        }
        #endregion 窗体初始化

        #region 窗体加载与关闭
        /// <summary>
        /// 窗体装载时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        /// <summary>
        /// 窗体关闭时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }
        /// <summary>
        /// 窗体关闭后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
        #endregion 窗体加载与关闭

        #region 窗体鼠标事件
        /// <summary>
        /// 窗体鼠标左键事件·Up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
        /// <summary>
        /// 窗体鼠标左键事件·Down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        #endregion 窗体鼠标事件

        #endregion 窗体事件

        #region 主窗体功能按钮事件
        /// <summary>
        /// 窗体最小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Minimized;
            }
            //this.Hide();
            //this.ShowInTaskbar = false;//窗体在任务标中隐藏
        }
        /// <summary>
        /// 窗体退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("您确定要退出个人账务管理系统吗？", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                LoggerTsit.Write("退出系统！");
                this.Close();
            }
        }
        #endregion 主窗体功能按钮事件

        #region 主窗体主控制按钮事件
        /// <summary>
        /// 鼠标离开主按钮区域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMainControl_MouseLeave(object sender, MouseEventArgs e)
        {
            ImageBrush ib;
            ib = (ImageBrush)this.FindResource("BtnMainUp");
            this.btnMainControl.Background = ib;
        }
        /// <summary>
        /// 鼠标进入主按钮区域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMainControl_MouseEnter(object sender, MouseEventArgs e)
        {
            ImageBrush ib;
            ib = (ImageBrush)this.FindResource("BtnMainDown");
            this.btnMainControl.Background = ib;
        }
        /// <summary>
        /// 鼠标点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMainControl_Click(object sender, RoutedEventArgs e)
        {
            this.lblModelTitle.Content = this._nameItems[(int)NameItems.Main];
            this.canvasButtons.Visibility = Visibility.Visible;
            this.dplContorls.Children.Clear();
            this.dplContorls.Visibility = Visibility.Hidden;
            //MessageBox.Show("您点击了主按钮！", "提示", MessageBoxButton.OK, MessageBoxImage.Question, MessageBoxResult.OK);
        }
        #endregion 主窗体主控制按钮事件

        #region 模块按钮事件
        /// <summary>
        /// 移动面板所有用户控件
        /// </summary>
        /// <param name="ui">要显示的用户控件名称</param>
        /// <param name="em">显示标题枚举名称</param>
        private void RemoveChildren(UIElement ui, NameItems em)
        {
            this.dplContorls.Children.Clear();
            this.dplContorls.Children.Add(ui);
            this.canvasButtons.Visibility = Visibility.Hidden;
            this.dplContorls.Visibility = Visibility.Visible;
            this.lblModelTitle.Content = this._nameItems[(int)em];
        }
        /// <summary>
        /// 收支明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIaeDetailed_Click(object sender, RoutedEventArgs e)
        {
            if (this._cIaeDetailed == null) return;
            this._cIaeDetailed.InitializePaging();
            this.RemoveChildren(this._cIaeDetailed, NameItems.IaeDetailed);
        }
        /// <summary>
        /// 收支项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIaeItems_Click(object sender, RoutedEventArgs e)
        {
            if (this._cIaeItems == null) return;
            this._cIaeItems.InitializePaging();
            this.RemoveChildren(this._cIaeItems, NameItems.IaeItems);
        }
        /// <summary>
        /// 收支类别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIaeCategory_Click(object sender, RoutedEventArgs e)
        {
            if (this._cIaeCategory == null) return;
            this._cIaeCategory.InitializePaging();
            this.RemoveChildren(this._cIaeCategory, NameItems.IaeCategory);
        }
        /// <summary>
        /// 账务账目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {
            if (this._cAccounts == null) return;
            this._cAccounts.InitializePaging();
            this.RemoveChildren(this._cAccounts, NameItems.Accounts);
        }
        /// <summary>
        /// 账务成员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMember_Click(object sender, RoutedEventArgs e)
        {
            if (this._cMember == null) return;
            this._cMember.InitializePaging();
            this.RemoveChildren(this._cMember, NameItems.Member);
        }
        /// <summary>
        /// 报表信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            if (this._cReport == null) return;
            this._cReport.InitializePaging();
            this.RemoveChildren(this._cReport, NameItems.Report);
        }
        /// <summary>
        /// 账务字典
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDictionary_Click(object sender, RoutedEventArgs e)
        {
            if (this._cDictionary == null) return;
            this._cDictionary.InitializePaging();
            this.RemoveChildren(this._cDictionary, NameItems.Dictionary);
        }
        /// <summary>
        /// 日志信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogs_Click(object sender, RoutedEventArgs e)
        {
            if (this._cLogs == null) return;
            this._cLogs.InitializePaging();
            this.RemoveChildren(this._cLogs, NameItems.Logs);
        }
        /// <summary>
        /// 错误信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnError_Click(object sender, RoutedEventArgs e)
        {
            if (this._cError == null) return;
            this._cError.InitializePaging();
            this.RemoveChildren(this._cError, NameItems.Error);
        }
        /// <summary>
        /// 关于系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            if (this._cAbout == null) return;
            this._cAbout.InitializePaging();
            this.RemoveChildren(this._cAbout, NameItems.About);
        }
        /// <summary>
        /// 系统设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSystem_Click(object sender, RoutedEventArgs e)
        {
            if (this._cSystem == null) return;
            this._cSystem.InitializePaging();
            this.RemoveChildren(this._cSystem, NameItems.System);
        }
        #endregion 模块按钮事件

        #region 模块按钮扩展事件
        /// <summary>
        /// 模块按钮扩展事件
        /// </summary>
        /// <param name="isChild">是否用户控件的子控件</param>
        /// <param name="mName">控件标识</param>
        private void ModuleExtend(bool isChild, NameItems mName)
        {
            if (isChild)
            {
                ModuleExtendByChild(mName);
            }
            else
            {
                ModuleExtendByMain(mName);
            }
        }

        #region 主模块
        /// <summary>
        /// 模块按钮扩展事件·主模块
        /// </summary>
        /// <param name="mName">控件标识</param>
        private void ModuleExtendByMain(NameItems mName)
        {
            switch (mName)
            {
                case NameItems.IaeDetailed:
                    this.btnIaeDetailed_Click(null, null);
                    break;
                case NameItems.IaeItems:
                    this.btnIaeItems_Click(null, null);
                    break;
                case NameItems.IaeCategory:
                    this.btnIaeCategory_Click(null, null);
                    break;
                case NameItems.Accounts:
                    this.btnAccount_Click(null, null);
                    break;
                case NameItems.Member:
                    this.btnMember_Click(null, null);
                    break;
                case NameItems.Report:
                    this.btnReport_Click(null, null);
                    break;
                case NameItems.Dictionary:
                    this.btnDictionary_Click(null, null);
                    break;
                case NameItems.Logs:
                    this.btnLogs_Click(null, null);
                    break;
                case NameItems.Error:
                    this.btnError_Click(null, null);
                    break;
                case NameItems.About:
                    this.btnAbout_Click(null, null);
                    break;
                case NameItems.System:
                    this.btnSystem_Click(null, null);
                    break;
                default:
                    break;
            }
        }
        #endregion 主模块

        #region 主模块子控件
        /// <summary>
        /// 模块按钮扩展事件·子模块
        /// </summary>
        /// <param name="mName">控件标识</param>
        private void ModuleExtendByChild(NameItems mName)
        {
            switch (mName)
            {
                case NameItems.IaeDetailed:
                    if (this._cIaeDetailedAdd == null) return;
                    this._cIaeDetailedAdd.InitializeData();
                    this.RemoveChildren(this._cIaeDetailedAdd, NameItems.IaeDetailed);
                    break;
                case NameItems.IaeItems:
                    if (this._cIaeItemsAdd == null) return;
                    this._cIaeItemsAdd.InitializeData();
                    this.RemoveChildren(this._cIaeItemsAdd, NameItems.IaeItems);
                    break;
                case NameItems.IaeCategory:
                    if (this._cIaeCategoryAdd == null) return;
                    this._cIaeCategoryAdd.InitializeData();
                    this.RemoveChildren(this._cIaeCategoryAdd, NameItems.IaeCategory);
                    break;
                case NameItems.Accounts:
                    if (this._cAccountsAdd == null) return;
                    this._cAccountsAdd.InitializeData();
                    this.RemoveChildren(this._cAccountsAdd, NameItems.Accounts);
                    break;
                case NameItems.Member:
                    if (this._cMemberAdd == null) return;
                    this._cMemberAdd.InitializeData();
                    this.RemoveChildren(this._cMemberAdd, NameItems.Member);
                    break;
                case NameItems.Report:
                    if (this._cReportAdd == null) return;
                    this._cReportAdd.InitializeData();
                    this.RemoveChildren(this._cReportAdd, NameItems.Report);
                    break;
                case NameItems.Dictionary:
                    break;
                case NameItems.Logs:
                    break;
                case NameItems.Error:
                    break;
                case NameItems.About:
                    break;
                case NameItems.System:
                    break;
                default:
                    break;
            }
        }
        #endregion 主模块子控件

        #endregion 模块按钮扩展事件

        #region 报表模块专用委托事件
        /// <summary>
        /// 报表模块专用委托事件
        /// </summary>
        /// <param name="rptId">报表编号</param>
        private void ReportView(long rptId)
        {
            if (this._cReportDetailed == null) return;
            this._cReportDetailed.InitializeData(rptId);
            this.RemoveChildren(this._cReportDetailed, NameItems.Report);
        }
        #endregion 报表模块专用委托事件

    }
}
