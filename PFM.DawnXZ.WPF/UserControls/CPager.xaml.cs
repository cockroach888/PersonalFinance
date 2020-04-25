using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PFM.DawnXZ.WPF.UserControls
{    
    /// <summary>
    /// 申明委托
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    public delegate int EventPagingHandler(EventPagingArg e);
    /// <summary>
    /// 数据分页控件
    /// </summary>
    public partial class CPager : UserControl
    {
        /// <summary>
        /// EventPagingHandler
        /// </summary>
        public event EventPagingHandler EventPaging;

        #region Constructed function & 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public CPager()
        {
            InitializeComponent();
        }
        #endregion Constructed function & 构造函数        

        #region 每页显示记录数
        /// <summary>
        /// 每页显示记录数
        /// </summary>
        private int _pageSize = PFM.DawnXZ.Library.Transit.ConfigTsit.PageSize;
        /// <summary>
        /// 每页显示记录数
        /// </summary>
        public int PageSize
        {
            get { return this._pageSize; }
            set
            {
                this._pageSize = value;
                this.GetPageCount();
            }
        }
        #endregion 每页显示记录数

        #region 总记录数
        /// <summary>
        /// 总记录数
        /// </summary>
        private int _recordCount = 0;
        /// <summary>
        /// 总记录数
        /// </summary>
        public int RecordCount
        {
            get { return this._recordCount; }
            set
            {
                this._recordCount = value;
                this.GetPageCount();
            }
        }
        #endregion 总记录数

        #region 总页数
        /// <summary>
        /// 总页数
        /// </summary>
        private int _pageCount = 0;
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount
        {
            get { return this._pageCount; }
            set { this._pageCount = value; }
        }
        #endregion 总页数

        #region 当前页码
        /// <summary>
        /// 当前页码
        /// </summary>
        private int _pageCurrent = 1;
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageCurrent
        {
            get
            {
                if (this._pageCurrent <= 0)
                {
                    this._pageCurrent = 1;
                }
                else if (this._pageCurrent > this.PageCount)
                {
                    this._pageCurrent = PageCount;
                }
                return this._pageCurrent;
            }
            set
            {
                if (value <= 0)
                {
                    this._pageCurrent = 1;
                    return;
                }
                else if (value > PageCount)
                {
                    this._pageCurrent = PageCount;
                    return;
                }
                this._pageCurrent = value;
            }
        }
        #endregion 当前页码

        /// <summary>
        /// 当前页总记录数
        /// </summary>
        public int PageRecordCount { get; set; }

        #region 初始化
        /// <summary>
        ///  初始化
        /// </summary>
        public void InitializeThis()
        {
            
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
            this.InitializeThis();
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

        #region Property method
        /// <summary>
        /// 计算总页数
        /// </summary>
        public void GetPageCount()
        {
            //this.PageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(this.NMax) / Convert.ToDouble(this.PageSize)));
            if (this.RecordCount % this.PageSize == 0)
            {
                this.PageCount = this.RecordCount / this.PageSize;
            }
            else
            {
                this.PageCount = this.RecordCount / this.PageSize + 1;
            }
        }
        /// <summary>
        /// 翻页控件数据绑定的方法
        /// </summary>
        public void Bind()
        {
            //总记录数
            if (this.EventPaging != null)
            {
                this.RecordCount = this.EventPaging(new EventPagingArg(this.PageCurrent));
            }
            //当前页
            if (this.PageCurrent > this.PageCount)
            {
                this.PageCurrent = this.PageCount;
            }
            //总页数
            if (this.PageCount == 1)
            {
                this.PageCurrent = 1;
            }
            //页码状态
            this.lblPagerInfo.Content = string.Format("共{0}条，第{1}/{2}页", this.RecordCount, this.PageCurrent, this.PageCount);
            //页码输入器赋值
            this.txtPager.Text = this.PageCurrent.ToString();
            //按钮：首页、上一页
            if (this.PageCurrent == 1)
            {
                this.btnPrev.IsEnabled = false;
                this.btnFirst.IsEnabled = false;
            }
            else
            {
                btnPrev.IsEnabled = true;
                btnFirst.IsEnabled = true;
            }
            //按钮：末页、下一页
            if (this.PageCurrent == this.PageCount)
            {
                this.btnLast.IsEnabled = false;
                this.btnNext.IsEnabled = false;
            }
            else
            {
                btnLast.IsEnabled = true;
                btnNext.IsEnabled = true;
            }
            //记录数为零时，禁用所有按钮
            if (this.RecordCount == 0)
            {
                btnNext.IsEnabled = false;
                btnLast.IsEnabled = false;
                btnFirst.IsEnabled = false;
                btnPrev.IsEnabled = false;
            }
        }
        #endregion Property method

        #region 功能按钮事件
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            this.PageCurrent = 1;
            this.Bind();
        }
        /// <summary>
        /// 末页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            this.PageCurrent = this.PageCount;
            this.Bind();
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            this.PageCurrent -= 1;
            this.Bind();
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            this.PageCurrent += 1;
            if (this.PageCurrent > this.PageCount)
            {
                this.PageCurrent = this.PageCount;
            }
            this.Bind();
        }
        /// <summary>
        /// GO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPager_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtPager.Text))
            {
                if (Int32.TryParse(txtPager.Text.Trim(), out _pageCurrent))
                {
                    this.Bind();
                }
                else
                {
                    MessageBox.Show("请输入正确的数字！", "提示：", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
                }
            }
        }
        /// <summary>
        /// 文本框只能输入数字 1-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPager_KeyDown(object sender, KeyEventArgs e)
        {
            if (!((e.Key >= Key.D1 && e.Key <= Key.D9) || (e.Key >= Key.NumPad1 && e.Key <= Key.NumPad9)))
            {
                e.Handled = true;
            }
        }
        #endregion 功能按钮事件
    
    }
    /// <summary>
    /// 自定义事件数据基类
    /// </summary>
    public class EventPagingArg : EventArgs
    {
        private int _intPageIndex;
        public EventPagingArg(int PageIndex)
        {
            this._intPageIndex = PageIndex;
        }
    }
}
