using System;
using System.Windows;
using System.Windows.Controls;
using PFM.DawnXZ.Library.BLL;
using PFM.DawnXZ.Library.Entity;
using PFM.DawnXZ.Library.Transit;

namespace PFM.DawnXZ.WPF.UserControls
{
    /// <summary>
    /// Interaction logic for CIaeDetailed.xaml
    /// </summary>
    public partial class CIaeDetailed : UserControl
    {
        /// <summary>
        /// 模块扩展通用委托
        /// </summary>
        public event DelegateList.ModuleExtendEventHandler ModuleExtend;

        #region Variable & 变量

        /// <summary>
        /// 数据大小
        /// </summary>
        private int _dataTotal = 0;

        #endregion Variable & 变量

        #region Attribute & 属性
        /// <summary>
        /// 收支明细实体
        /// </summary>
        private PfmIaeDetailedMDL IaeDetailedEntity
        {
            get { return this.dgDataSource.CurrentItem as PfmIaeDetailedMDL; }
        }
        #endregion Attribute & 属性

        #region Constructed function & 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public CIaeDetailed()
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
            EntityListener.PfmIaeDetailedListener.Instance.Receive(PfmIaeDetailedBLL.ISelectPaging(pager.PageSize, pager.PageCurrent, out _dataTotal));
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
            if (ModuleExtend != null) this.ModuleExtend(true, Library.Transit.NameItems.IaeDetailed);
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
                if (IaeDetailedEntity == null) return;
                this.SetDetailed();
                this.DetailedShow();
            }
        }
        /// <summary>
        /// 删除收支明细数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mitmDelete_Click(object sender, RoutedEventArgs e)
        {
            if (IaeDetailedEntity != null && IaeDetailedEntity.DetId > 0)
            {
                MessageBoxResult boxResult = MessageBox.Show(string.Format("您确定要删除数据【{0}】所包含的信息吗？", IaeDetailedEntity.DetName), "询问：", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (boxResult == MessageBoxResult.Yes)
                {
                    PfmIaeDetailedBLL.Delete(IaeDetailedEntity.DetId);
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
            txtId.Text = string.Format("{0}", IaeDetailedEntity.DetId);
            txtMember.Text = string.Format("{0}", MemberTsit.GetName(IaeDetailedEntity.MbrId));
            txtAccount.Text = string.Format("{0}", AccountTsit.GetName(IaeDetailedEntity.AccId));
            txtCategory.Text = string.Format("{0}", IaeCategoryTsit.GetName(IaeDetailedEntity.CatId));
            txtTime.Text = string.Format("{0}", IaeDetailedEntity.DetAddTime.ToString("yyyy-MM-dd HH:mm:ss"));
            txtName.Text = string.Format("{0}", IaeDetailedEntity.DetName);
            txtMoney.Text = string.Format("{0}", IaeDetailedEntity.DetMoney);
            txtAddress.Text = string.Format("{0}", IaeDetailedEntity.DetAddress);
            txtDescription.Text = string.Format("{0}", IaeDetailedEntity.DetDescription);
            txtMemo.Text = string.Format("{0}", IaeDetailedEntity.DetMemo);
        }
        /// <summary>
        /// 清除详细信息内容项
        /// </summary>
        private void ClearDetailed()
        {
            txtId.Text = string.Empty;
            txtMember.Text = string.Empty;
            txtAccount.Text = string.Empty;
            txtCategory.Text = string.Empty;
            txtTime.Text = string.Empty;
            txtName.Text = string.Empty;
            txtMoney.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtMemo.Text = string.Empty;
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
