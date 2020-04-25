using System;
using System.Windows;
using System.Windows.Controls;
using PFM.DawnXZ.Library.BLL;
using PFM.DawnXZ.Library.Entity;

namespace PFM.DawnXZ.WPF.UserControls
{
    /// <summary>
    /// Interaction logic for CReport.xaml
    /// </summary>
    public partial class CReport : UserControl
    {
        /// <summary>
        /// 模块扩展通用委托
        /// </summary>
        public event DelegateList.ModuleExtendEventHandler ModuleExtend;
        /// <summary>
        /// 报表模块专用委托
        /// </summary>
        public event DelegateList.ReportViewEventHandler ReportView;

        #region Variable & 变量

        /// <summary>
        /// 数据大小
        /// </summary>
        private int _dataTotal = 0;

        #endregion Variable & 变量

        #region Attribute & 属性
        /// <summary>
        /// 报表信息实体
        /// </summary>
        private PfmReportMDL ReportEntity
        {
            get { return this.dgDataSource.CurrentItem as PfmReportMDL; }
        }
        #endregion Attribute & 属性

        #region Constructed function & 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public CReport()
        {
            InitializeComponent();
        }
        #endregion Constructed function & 构造函数        
       
        #region 初始化
        /// <summary>
        ///  初始化数据
        /// </summary>
        private void InitializeData()
        {
            if (this.svDetailed.Visibility == Visibility.Visible) this.DetailedBack();
            EntityListener.PfmReportListener.Instance.Receive(PfmReportBLL.ISelectPaging(pager.PageSize, pager.PageCurrent, out _dataTotal));
        }
        /// <summary>
        /// 初始化分页控件
        /// </summary>
        public void InitializePaging()
        {
            pager.PageCurrent = 1;
            this.InitializeData();
            pager.RecordCount = this._dataTotal;
            pager.Bind();
        }
        #endregion 初始化
        
        #region 窗体事件
        /// <summary>
        /// 窗体初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Initialized(object sender, EventArgs e)
        {
            this.svDetailed.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// 窗体加载时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
        #endregion 窗体事件        
        
        #region 功能按钮事件
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ModuleExtend != null) this.ModuleExtend(true, Library.Transit.NameItems.Report);
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            this.InitializePaging();
        }
        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.DetailedBack();
            this.ClearDetailed();
        }
        /// <summary>
        /// 显示详细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgDataSource_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ClickCount >= 2)
            {
                if (ReportEntity == null) return;
                if (ReportView != null) this.ReportView(ReportEntity.RptId);
                //this.SetDetailed();
                //this.DetailedShow();
            }
        }
        /// <summary>
        /// 删除报表信息数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mitmDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ReportEntity != null && ReportEntity.RptId > 0)
            {
                MessageBoxResult boxResult = MessageBox.Show(string.Format("您确定要删除数据【{0}】所包含的信息吗？", ReportEntity.RptName), "询问：", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (boxResult == MessageBoxResult.Yes)
                {
                    PfmReportBLL.Delete(ReportEntity.RptId);
                    PfmReportRecordBLL.DeleteAll(ReportEntity.RptId);
                    MessageBox.Show("数据删除成功！", "提示：", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                    this.InitializePaging();
                }
            }
        }
        #endregion 功能按钮事件

        #region private method & 私有方法

        /// <summary>
        /// 设定详细信息内容项
        /// </summary>
        private void SetDetailed()
        {
            //txtId.Text = string.Format("{0}", ErrorEntity.ErrId);
            //txtTime.Text = string.Format("{0}", ErrorEntity.ErrTime.ToString("yyyy-MM-dd HH:mm:ss"));
            //txtPage.Text = string.Format("{0}", ErrorEntity.ErrPage);
            //txtMessage.Text = string.Format("{0}", ErrorEntity.ErrMessage);
            //txtTargetSite.Text = string.Format("{0}", ErrorEntity.ErrTargetSite);
            //txtStackTrace.Text = string.Format("{0}", ErrorEntity.ErrStackTrace);
            //txtSource.Text = string.Format("{0}", ErrorEntity.ErrSource);
            //txtIp.Text = string.Format("{0}", ErrorEntity.ErrIp);
            //txtName.Text = string.Format("{0}", ErrorEntity.ErrName);
        }
        /// <summary>
        /// 清除详细信息内容项
        /// </summary>
        private void ClearDetailed()
        {
            txtId.Text = string.Empty;
            txtTime.Text = string.Empty;
            txtPage.Text = string.Empty;
            txtMessage.Text = string.Empty;
            txtTargetSite.Text = string.Empty;
            txtStackTrace.Text = string.Empty;
            txtSource.Text = string.Empty;
            txtIp.Text = string.Empty;
            txtName.Text = string.Empty;
        }
        /// <summary>
        /// 隐藏详细显示控件并显示其它
        /// </summary>
        private void DetailedBack()
        {
            foreach (UIElement uieChild in this.cplButtonPanel.Children)
            {
                if (uieChild.GetType().Name == "Button")
                {
                    if ((uieChild as Button).Name == "btnBack")
                    {
                        uieChild.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        uieChild.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    uieChild.Visibility = Visibility.Visible;
                }
            }
            this.dplDataPanel.Visibility = Visibility.Visible;
            this.svDetailed.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// 显示详细显示控件并隐藏其它
        /// </summary>
        private void DetailedShow()
        {
            foreach (UIElement uieChild in this.cplButtonPanel.Children)
            {
                if (uieChild.GetType().Name == "Button")
                {
                    if ((uieChild as Button).Name == "btnBack")
                    {
                        uieChild.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        uieChild.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    uieChild.Visibility = Visibility.Hidden;
                }
            }
            this.dplDataPanel.Visibility = Visibility.Hidden;
            this.svDetailed.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// EventPaging
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private int pager_EventPaging(EventPagingArg e)
        {
            int pagd = pager.PageCurrent;
            InitializeData();
            return this._dataTotal;
        }

        #endregion private method & 私有方法

    }
}
