using System;
using System.Windows;
using System.Windows.Controls;
using PFM.DawnXZ.Library.BLL;
using PFM.DawnXZ.Library.Entity;

namespace PFM.DawnXZ.WPF.UserControls
{
    /// <summary>
    /// Interaction logic for CIaeItems.xaml
    /// </summary>
    public partial class CIaeItems : UserControl
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
        /// 收支项目实体
        /// </summary>
        private PfmIaeItemsMDL IaeItemsEntity
        {
            get { return this.dgDataSource.CurrentItem as PfmIaeItemsMDL; }
        }
        #endregion Attribute & 属性

        #region Constructed function & 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public CIaeItems()
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
            EntityListener.PfmIaeItemsListener.Instance.Receive(PfmIaeItemsBLL.ISelectPaging(pager.PageSize, pager.PageCurrent, out _dataTotal));
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
        /// 控件初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Initialized(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 控件加载时
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
            if (ModuleExtend != null) this.ModuleExtend(true, Library.Transit.NameItems.IaeItems);
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
        /// 删除收支项目数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mitmDelete_Click(object sender, RoutedEventArgs e)
        {
            if (IaeItemsEntity != null && IaeItemsEntity.ItemId > 0)
            {
                MessageBoxResult boxResult = MessageBox.Show(string.Format("您确定要删除数据【{0}】所包含的信息吗？", IaeItemsEntity.ItemName), "询问：", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (boxResult == MessageBoxResult.Yes)
                {
                    PfmIaeItemsBLL.Delete(IaeItemsEntity.ItemId);
                    MessageBox.Show("数据删除成功！", "提示：", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                    this.InitializePaging();
                }
            }
        }
        #endregion 功能按钮事件

        #region private method & 私有方法

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
