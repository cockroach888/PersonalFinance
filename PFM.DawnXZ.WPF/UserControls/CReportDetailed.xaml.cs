using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using PFM.DawnXZ.Library.Entity;
using PFM.DawnXZ.Library.BLL;
using PFM.DawnXZ.Library.Transit;

namespace PFM.DawnXZ.WPF.UserControls
{
    /// <summary>
    /// CReportDetailed.xaml 的交互逻辑
    /// </summary>
    public partial class CReportDetailed : UserControl
    {
        /// <summary>
        /// 模块扩展通用委托
        /// </summary>
        public event DelegateList.ModuleExtendEventHandler ModuleExtend;

        #region Variable & 变量

        #endregion Variable & 变量

        #region Attribute & 属性
        /// <summary>
        /// 报表信息
        /// </summary>
        private PfmReportMDL PfmReport;
        /// <summary>
        /// 报表记录
        /// </summary>
        private IList<PfmReportRecordMDL> PfmReportRecord;
        #endregion Attribute & 属性

        #region Constructed function & 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public CReportDetailed()
        {
            InitializeComponent();
        }
        #endregion Constructed function & 构造函数

        #region 初始化
        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="rptId">报表编号</param>
        public void InitializeData(long rptId)
        {
            PfmReport = PfmReportBLL.Select(rptId);
            PfmReportRecord = PfmReportRecordBLL.ISelect(string.Format("rpt_id = '{0}'", rptId));
            this.dgDataSource.DataContext = PfmReportRecord;
            this.txtTitle.Text = PfmReport.RptName;
            this.txtType.Text = DictionaryTsit.GetDictName(PfmReport.DictMark);
            this.txtDate.Text = PfmReport.RptDate.ToString("yyyy年MM月dd日");
            this.txtMemo.Text = PfmReport.RptMemo;
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
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (ModuleExtend != null) this.ModuleExtend(false, Library.Transit.NameItems.Report);
        }
        #endregion 功能按钮事件

        #region private method & 私有方法
        
        #endregion private method & 私有方法

    }
}
