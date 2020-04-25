using System;
using System.Windows;
using System.Windows.Controls;
using PFM.DawnXZ.Library.BLL;
using PFM.DawnXZ.Library.Entity;
using PFM.DawnXZ.Library.Transit;

namespace PFM.DawnXZ.WPF.UserControls
{
    /// <summary>
    /// Interaction logic for CDictionary.xaml
    /// </summary>
    public partial class CDictionary : UserControl
    {

        #region Variable & 变量

        /// <summary>
        /// 数据大小
        /// </summary>
        private int _dataTotal = 0;

        #endregion Variable & 变量

        #region Attribute & 属性
        /// <summary>
        /// 账务字典实体
        /// </summary>
        private PfmDictionaryMDL DictEntity
        {
            get { return this.dgDataSource.CurrentItem as PfmDictionaryMDL; }
        }
        #endregion Attribute & 属性

        #region Constructed function & 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public CDictionary()
        {
            InitializeComponent();
        }
        #endregion Constructed function & 构造函数

        #region private method & 私有方法
        
        #endregion private method & 私有方法

        #region public method & 公共方法
        
        #endregion public method & 公共方法
       
        #region 初始化
        /// <summary>
        ///  初始化数据
        /// </summary>
        private void InitializeData()
        {
            EntityListener.PfmDictionaryListener.Instance.Receive(PfmDictionaryBLL.ISelectPaging(pager.PageSize, pager.PageCurrent, out _dataTotal));
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
        /// 刷新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            this.InitializePaging();
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
