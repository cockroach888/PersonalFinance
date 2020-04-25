using System;
using System.Windows;
using System.Windows.Controls;
using PFM.DawnXZ.Library.BLL;
using PFM.DawnXZ.Library.Entity;

namespace PFM.DawnXZ.WPF.UserControls
{
    /// <summary>
    /// Interaction logic for CLogs.xaml
    /// </summary>
    public partial class CLogs : UserControl
    {

        #region Variable & 变量

        /// <summary>
        /// 数据大小
        /// </summary>
        private int _dataTotal = 0;

        #endregion Variable & 变量

        #region Attribute & 属性
        /// <summary>
        /// 日志信息实体
        /// </summary>
        private PfmLogsMDL LogsEntity
        {
            get { return this.dgDataSource.CurrentItem as PfmLogsMDL; }
        }
        #endregion Attribute & 属性

        #region Constructed function & 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public CLogs()
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
            EntityListener.PfmLogsListener.Instance.Receive(PfmLogsBLL.ISelectPaging(pager.PageSize, pager.PageCurrent, out _dataTotal));
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
        /// 清空数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearAll_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult delFlg = MessageBox.Show("您确定要清空日志信息吗？", "提示：", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (delFlg == MessageBoxResult.Yes)
            {
                PfmLogsBLL.DeleteAll();
                this.InitializePaging();
            }
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
                if (LogsEntity == null) return;
                this.SetDetailed();
                this.DetailedShow();
            }
        }
        #endregion 功能按钮事件

        #region private method & 私有方法

        /// <summary>
        /// 设定详细信息内容项
        /// </summary>
        private void SetDetailed()
        {
            txtId.Text = string.Format("{0}", LogsEntity.LogId);
            txtTime.Text = string.Format("{0}", LogsEntity.LogTime.ToString("yyyy-MM-dd HH:mm:ss"));
            txtTable.Text = string.Format("{0}", LogsEntity.LogTable);
            txtAction.Text = string.Format("{0}", LogsEntity.LogAction);
            txtRemark.Text = string.Format("{0}", LogsEntity.LogRemark);
            txtUname.Text = string.Format("{0}", LogsEntity.LogUname);
        }
        /// <summary>
        /// 清除详细信息内容项
        /// </summary>
        private void ClearDetailed()
        {
            txtId.Text = string.Empty;
            txtTime.Text = string.Empty;
            txtTable.Text = string.Empty;
            txtAction.Text = string.Empty;
            txtRemark.Text = string.Empty;
            txtUname.Text = string.Empty;
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
