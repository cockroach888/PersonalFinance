using DawnXZ.DawnUtility;
using DawnXZ.VerifyUtility;
using PFM.DawnXZ.Library.BLL;
using PFM.DawnXZ.Library.Entity;
using PFM.DawnXZ.Library.Transit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace PFM.DawnXZ.WPF.UserControls {
    /// <summary>
    /// CReportAdd.xaml 的交互逻辑
    /// </summary>
    public partial class CReportAdd : UserControl
    {
        /// <summary>
        /// 模块扩展通用委托
        /// </summary>
        public event DelegateList.ModuleExtendEventHandler ModuleExtend;

        #region Attribute & 属性
        /// <summary>
        /// 数据验证是否通过
        /// </summary>
        private bool IsVerify { get; set; }
        /// <summary>
        /// 当前年份
        /// </summary>
        private int NowYear
        {
            get { return DateTime.Now.Year; }
        }
        /// <summary>
        /// 当前选择年份
        /// </summary>
        private int ThisYear
        {
            get
            {
                return TypeHelper.TypeToInt32(this.cboxYear.SelectedValue, DateTime.Now.Year);
            }
        }
        /// <summary>
        /// 开始日期
        /// </summary>
        private DateTime DateBegin { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        private DateTime DateEnd { get; set; }
        /// <summary>
        /// 报表类型
        /// </summary>
        private byte DictMark
        {
            get
            {
                return TypeHelper.TypeToTinyInt(this.cboxType.SelectedValue, 0);
            }
        }
        /// <summary>
        /// 报表周期
        /// </summary>
        private int ReportReriodic
        {
            get
            {
                return TypeHelper.TypeToInt32(this.cboxReriod.SelectedValue);
            }
        }
        /// <summary>
        /// 旧报表名称
        /// </summary>
        private string OldReportName { get; set; }
        #endregion Attribute & 属性

        #region Constructed function & 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public CReportAdd()
        {
            InitializeComponent();
        }
        #endregion Constructed function & 构造函数

        #region 初始化
        /// <summary>
        ///  初始化数据
        /// </summary>
        public void InitializeData()
        {
            this.InitBoxOfComboBox();
            if (this.cboxType.Items.Count > 0) this.cboxType.SelectedIndex = -1;
            if (this.cboxYear.Items.Count > 0) this.cboxYear.SelectedValue = DateTime.Now.Year;
            if (this.cboxReriod.Items.Count > 0) this.cboxReriod.SelectedIndex = 0;
            this.cboxYear.IsEnabled = false;
            this.cboxReriod.IsEnabled = false;
            this.txtName.Text = ConfigTsit.ReprotTitle;
            this.txtMemo.Clear();
            this.InitDescType();
            this.InitDescReriod();
            this.InitDescName();
            this.InitDescMemo();
        }
        /// <summary>
        /// 初始化数据盒子
        /// </summary>
        private void InitBoxOfComboBox()
        {
            this.cboxType.SelectedValuePath = "DictMark";
            this.cboxType.DisplayMemberPath = "DictName";
            this.cboxType.DataContext = PfmDictionaryBLL.ISelect("dict_type=1");
            this.cboxYear.SelectedValuePath = "Value";
            this.cboxYear.DisplayMemberPath = "Key";
            this.cboxYear.DataContext = BuildPeriodicOfYear(ConfigTsit.YearOrigin);
            this.cboxReriod.SelectedValuePath = "Value";
            this.cboxReriod.DisplayMemberPath = "Key";
            this.cboxReriod.DataContext = DictionaryTsit.DefSelect;
        }
        /// <summary>
        /// 报表周期数据·年
        /// </summary>
        /// <param name="yearOrigin">原始年份</param>
        /// <returns>Key / Value</returns>
        private Dictionary<string, int> BuildPeriodicOfYear(int yearOrigin) {
            Dictionary<string, int> reriodic = new Dictionary<string, int>();
            for (; yearOrigin <= DateTime.Now.Year; yearOrigin++) {
                reriodic.Add(string.Format("{0}年", yearOrigin), yearOrigin);
            }
            return reriodic;
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
            this.cboxType.Focus();
        }
        #endregion 窗体事件

        #region 功能按钮事件
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            this.DataVerify();
            if (this.IsVerify)
            {
                this.ReportDate();
                PfmReportMDL rptMdl = new PfmReportMDL();
                rptMdl.DictMark = DictMark;
                rptMdl.RptTime = DateTime.Now;
                rptMdl.RptDate = DateBegin;
                rptMdl.RptState = 1;
                rptMdl.RptName = this.txtName.Text;
                rptMdl.RptMemo = string.IsNullOrEmpty(this.txtMemo.Text) ? null : this.txtMemo.Text;
                PfmReportBLL.Insert(rptMdl);
                this.ReportRecordSave(PfmReportBLL.GetMaxId());
                MessageBoxResult boxResult = MessageBox.Show("新数据添加成功！是否继续添加？", "提示：", MessageBoxButton.YesNo, MessageBoxImage.Information, MessageBoxResult.No);
                if (boxResult == MessageBoxResult.Yes)
                {
                    this.InitializeData();
                }
                else
                {
                    if (ModuleExtend != null) this.ModuleExtend(false, Library.Transit.NameItems.Report);
                }
            }
        }
        /// <summary>
        /// 保存报表明细数据
        /// </summary>
        /// <param name="rptId">报表编号</param>
        private void ReportRecordSave(int rptId)
        {
            DataTable dt = PfmIaeDetailedBLL.Report(DateBegin, DateEnd);
            PfmReportRecordMDL recMdl = new PfmReportRecordMDL();
            foreach (DataRow dr in dt.Rows)
            {
                recMdl.RptId = rptId;
                recMdl.MbrId = TypeHelper.TypeToInt32(dr["mbr_id"]);
                recMdl.AccId = TypeHelper.TypeToInt32(dr["acc_id"]);
                recMdl.RrdAddTime = DateTime.Now;
                recMdl.RrdInSum = TypeHelper.TypeToDecimal(dr["Incomings"]);
                recMdl.RrdInCount = TypeHelper.TypeToInt32(dr["InCount"]);
                recMdl.RrdOutSum = TypeHelper.TypeToDecimal(dr["Outgoings"]);
                recMdl.RrdOutCount = TypeHelper.TypeToInt32(dr["OutCount"]);
                recMdl.RrdSum = TypeHelper.TypeToDecimal(dr["Sums"]);
                PfmReportRecordBLL.Insert(recMdl);
            }
            recMdl = null;
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (ModuleExtend != null) this.ModuleExtend(false, Library.Transit.NameItems.Report);
        }

        #region 下拉框选择事件
        /// <summary>
        /// 报表类型选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DictMark <= 0) return;
            if (DictMark != 1)
            {
                this.cboxYear.IsEnabled = true;
            }
            else
            {
                this.cboxYear.IsEnabled = false;
            }
            this.cboxReriod.IsEnabled = true;
            switch (DictMark)
            {
                case 1:
                    this.cboxReriod.DataContext = Core.DateHelperExtension.BuildPeriodicOfYear(ConfigTsit.YearOrigin);
                    this.cboxReriod.SelectedValue = DateTime.Now.Year;
                    break;
                case 2:
                    this.cboxReriod.DataContext = Core.DateHelperExtension.BuildPeriodicOfMonth();
                    this.cboxReriod.SelectedValue = DateTime.Now.Month;
                    break;
                case 3:
                    this.cboxReriod.DataContext = Core.DateHelperExtension.BuildPeriodicOfWeek(ThisYear);
                    this.cboxReriod.SelectedValue = Core.DateHelperExtension.WeekOfYear(DateTime.Now);
                    break;
                case 4:
                    this.cboxReriod.DataContext = Core.DateHelperExtension.BuildPeriodicOfSeason();
                    this.cboxReriod.SelectedValue = Core.DateHelperExtension.QuarterByThis(DateTime.Now.Month);
                    break;
                default:
                    this.cboxReriod.DataContext = DictionaryTsit.DefSelect;
                    this.cboxReriod.SelectedIndex = 0;
                    break;
            }
            if (this.cboxYear.Items.Count > 0) this.cboxYear.SelectedValue = DateTime.Now.Year;
            this.SetReportTitle();
        }
        /// <summary>
        /// 报表年份选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboxYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ThisYear <= 0 || DictMark <= 0) return;
            switch (DictMark)
            {
                case 2:
                    if (ThisYear != NowYear)
                    {
                        this.cboxReriod.SelectedIndex = 0;
                    }
                    else
                    {
                        this.cboxReriod.SelectedValue = DateTime.Now.Month;
                    }
                    break;
                case 3:
                    this.cboxReriod.DataContext = Core.DateHelperExtension.BuildPeriodicOfWeek(ThisYear);
                    if (ThisYear != NowYear)
                    {
                        this.cboxReriod.SelectedIndex = 0;
                    }
                    else
                    {
                        this.cboxReriod.SelectedValue = Core.DateHelperExtension.WeekOfYear(DateTime.Now);
                    }
                    break;
                case 4:
                    if (ThisYear != NowYear)
                    {
                        this.cboxReriod.SelectedIndex = 0;
                    }
                    else
                    {
                        this.cboxReriod.SelectedValue = Core.DateHelperExtension.QuarterByThis(DateTime.Now.Month);
                    }
                    break;
                default:
                    this.cboxReriod.DataContext = DictionaryTsit.DefSelect;
                    this.cboxReriod.SelectedIndex = 0;
                    break;
            }
            this.SetReportTitle();
        }
        /// <summary>
        /// 报表周期数据变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboxReriod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.SetReportTitle();
        }
        #endregion 下拉框选择事件

        #endregion 功能按钮事件

        #region private method & 私有方法

        #region 简述信息
        /// <summary>
        /// 初始化 [报表类型] 简述内容
        /// </summary>
        private void InitDescType()
        {
            this.txtDescType.Foreground = Codes.ToBrush.StrToBrush("#00FFFF");
            this.txtDescType.Text = "请选择生成报表的类型";
        }
        /// <summary>
        /// 初始化 [报表周期] 简述内容
        /// </summary>
        private void InitDescReriod()
        {
            this.txtDescReriod.Foreground = Codes.ToBrush.StrToBrush("#00FFFF");
            this.txtDescReriod.Text = "请选择生成报表的周期项";
        }        
        /// <summary>
        /// 初始化 [报表名称] 简述内容
        /// </summary>
        private void InitDescName()
        {
            this.txtDescName.Foreground = Codes.ToBrush.StrToBrush("#00FFFF");
            this.txtDescName.Text = "报表名称[由中文、字母、数字组成]";
        }
        /// <summary>
        /// 初始化 [报表备忘] 简述内容
        /// </summary>
        private void InitDescMemo()
        {
            this.txtDescMemo.Foreground = Codes.ToBrush.StrToBrush("#00FFFF");
            this.txtDescMemo.Text = "报表备忘事项，由中文、字母、数字组成";
        }
        #endregion 简述信息

        #region 报表类型
        /// <summary>
        /// 验证报表类型
        /// </summary>
        private void VerifyType()
        {
            this.cboxType.Focus();
            if (TypeHelper.TypeToInt32(this.cboxType.SelectedValue, 0) <= 0)
            {
                this.txtDescType.Foreground = Codes.ToBrush.StrToBrush("#C80000");
                this.txtDescType.Text = "请选择正确的报表类型";
                this.IsVerify = false;
            }
            else
            {
                this.IsVerify = true;
                this.InitDescType();
            }
        }
        #endregion 报表类型

        #region 报表名称
        /// <summary>
        /// 验证报表名称
        /// </summary>
        private void VerifyName()
        {
            this.txtName.Focus();
            this.IsVerify = false;
            this.txtDescName.Foreground = Codes.ToBrush.StrToBrush("#C80000");
            if (!ValidHelper.ChsIsChineseOrEngOrNum(this.txtName.Text))
            {
                this.txtDescName.Text = "报表名称输入不正确，只能由中文、字母、数字构成";
            }
            else if (this.txtName.Text.Length > 300)
            {
                this.txtDescName.Text = "报表名称输入长度超限，不能大于300个字符";
            }
            else
            {
                this.IsVerify = true;
                this.InitDescName();
            }
        }
        #endregion 报表名称

        #region 报表备忘
        /// <summary>
        /// 验证报表备忘
        /// </summary>
        private void VerifyMemo()
        {
            if (!string.IsNullOrEmpty(this.txtMemo.Text))
            {
                this.txtMemo.Focus();
                this.IsVerify = false;
                this.txtDescMemo.Foreground = Codes.ToBrush.StrToBrush("#C80000");
                if (!ValidHelper.ChsIsChineseOrEngOrNum(this.txtMemo.Text))
                {
                    this.txtDescMemo.Text = "报表备忘输入不正确，只能由中文、字母、数字构成";
                }
                else if (this.txtMemo.Text.Length > 2000)
                {
                    this.txtDescMemo.Text = "报表备忘输入长度超限，不能大于2000个字符";
                }
                else
                {
                    this.IsVerify = true;
                    this.InitDescMemo();
                }
            }
        }
        #endregion 报表备忘

        #region 验证数据
        /// <summary>
        /// 验证输入数据是否正确
        /// </summary>
        /// <returns></returns>
        private void DataVerify()
        {
            this.IsVerify = true;
            if (IsVerify) this.VerifyType();
            if (IsVerify) this.VerifyName();
            if (IsVerify) this.VerifyMemo();
        }
        #endregion 验证数据        

        #region 计算报表日期
        /// <summary>
        /// 计算报表日期
        /// </summary>
        private void ReportDate()
        {
            switch (DictMark)
            {
                case 1://年
                    DateBegin = Core.DateHelperExtension.YearByFirstDay(ReportReriodic);
                    DateEnd = Core.DateHelperExtension.YearByLastDay(ReportReriodic);
                    break;
                case 2://月
                    DateBegin = Core.DateHelperExtension.MonthByFirstDay(ThisYear, ReportReriodic);
                    DateEnd = Core.DateHelperExtension.MonthByLastDay(ThisYear, ReportReriodic);
                    break;
                case 3://周
                    DateTime wBegin, wEnd;
                    Core.DateHelperExtension.GetWeek(ThisYear, Core.DateHelperExtension.GetYearWeekCount(ThisYear), out wBegin, out wEnd);
                    DateBegin = wBegin;
                    DateEnd = wEnd;
                    break;
                case 4://季                    
                    DateTime qBegin, qEnd;
                    Core.DateHelperExtension.QuarterByFirstDay(ThisYear, ReportReriodic, out qBegin, out qEnd);
                    DateBegin = qBegin;
                    DateEnd = qEnd;
                    break;
                default:
                    break;
            }
        }
        #endregion 计算报表日期

        #region 设定报表名称
        /// <summary>
        /// 设定报表名称
        /// </summary>
        private void SetReportTitle()
        {
            if (this.cboxYear.SelectedValue == null) return;
            if (this.cboxReriod.SelectedValue == null) return;
            string year = ((KeyValuePair<string, int>)this.cboxYear.SelectedItem).Key;
            if (DictMark == 1) year = string.Empty;
            string text = ((KeyValuePair<string, int>)this.cboxReriod.SelectedItem).Key;
            string headerName = year + text;
            string newTitle = null;
            if (!string.IsNullOrEmpty(OldReportName) && this.txtName.Text.Contains(OldReportName))
            {
                newTitle = this.txtName.Text.Replace(OldReportName, headerName);
            }
            else
            {
                newTitle = string.Format("{0}{1}", headerName, this.txtName.Text);
            }
            OldReportName = headerName;
            this.txtName.Text = newTitle;
        }
        #endregion 设定报表名称

        #endregion private method & 私有方法

        #region public method & 公共方法

        #endregion public method & 公共方法

    }
}
