using DawnXZ.DawnUtility;
using DawnXZ.VerifyUtility;
using PFM.DawnXZ.Library.BLL;
using PFM.DawnXZ.Library.Entity;
using PFM.DawnXZ.Library.Transit;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace PFM.DawnXZ.WPF.UserControls {
    /// <summary>
    /// CIaeCategoryAdd.xaml 的交互逻辑
    /// </summary>
    public partial class CIaeCategoryAdd : UserControl
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
        /// 是否为子类别添加
        /// </summary>
        private bool IsChild { get; set; }
        /// <summary>
        /// 收支类别
        /// </summary>
        private IList<PfmIaeCategoryMDL> DataIaeCategory;
        #endregion Attribute & 属性

        #region Constructed function & 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public CIaeCategoryAdd()
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
            this.txtName.Clear();
            this.txtDescription.Clear();
            this.InitDescName();
            this.InitDescDescription();
        }
        /// <summary>
        /// 初始化数据盒子
        /// </summary>
        private void InitBoxOfComboBox()
        {
            DataIaeCategory = PfmIaeCategoryBLL.RecursiveI("　", "　");
            if (DataIaeCategory.Count > 0)
            {
                this.BuildMain();
                this.btnChangeMode.Content = "主类别";
                this.btnChangeMode.IsEnabled = true;
            }
            else
            {
                this.BuildChild();
                this.btnChangeMode.Content = "子类别";
                this.btnChangeMode.IsEnabled = false;
            }
        }
        /// <summary>
        /// 子类别数据
        /// </summary>
        private void BuildMain()
        {
            this.cboxCategory.SelectedValuePath = "CatId";
            this.cboxCategory.DisplayMemberPath = "CatName";
            this.cboxCategory.DataContext = DataIaeCategory;
            if (this.cboxCategory.Items.Count > 0) this.cboxCategory.SelectedIndex = 0;
        }
        /// <summary>
        /// 主类别数据
        /// </summary>
        private void BuildChild()
        {
            this.cboxCategory.SelectedValuePath = "Value";
            this.cboxCategory.DisplayMemberPath = "Key";
            this.cboxCategory.DataContext = DictionaryTsit.DefCategory;
            if (this.cboxCategory.Items.Count > 0) this.cboxCategory.SelectedIndex = 0;
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
            this.txtName.Focus();
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
                PfmIaeCategoryMDL catMdl = new PfmIaeCategoryMDL();
                int catFlag = TypeHelper.TypeToInt32(this.cboxCategory.SelectedValue, 0);
                catMdl.CatName = this.txtName.Text;
                catMdl.CatFather = catFlag;
                catMdl.CatClick = 0;
                catMdl.CatCounts = 0;
                catMdl.CatDescription = string.IsNullOrEmpty(this.txtDescription.Text) ? null : this.txtDescription.Text;
                PfmIaeCategoryBLL.Insert(catMdl, catFlag == -1 ? false : true);
                MessageBoxResult boxResult = MessageBox.Show("新数据添加成功！是否继续添加？", "提示：", MessageBoxButton.YesNo, MessageBoxImage.Information, MessageBoxResult.No);
                if (boxResult == MessageBoxResult.Yes)
                {
                    this.InitializeData();
                }
                else
                {
                    if (ModuleExtend != null) this.ModuleExtend(false, Library.Transit.NameItems.IaeCategory);
                }
            }            
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (ModuleExtend != null) this.ModuleExtend(false, Library.Transit.NameItems.IaeCategory);
        }
        /// <summary>
        /// 主类别 / 子类别 模式转换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeMode_Click(object sender, RoutedEventArgs e)
        {
            if (IsChild)
            {
                this.BuildMain();
                this.btnChangeMode.Content = "主类别";
                IsChild = false;
            }
            else
            {
                this.BuildChild();
                this.btnChangeMode.Content = "子类别";
                IsChild = true;
            }
        }
        #endregion 功能按钮事件

        #region private method & 私有方法

        #region 简述信息
        /// <summary>
        /// 初始化 [隶属类别] 简述内容
        /// </summary>
        private void InitDescCategory()
        {
            this.txtDescCategory.Foreground = Codes.ToBrush.StrToBrush("#00FFFF");
            this.txtDescCategory.Text = "收支类别隶属于哪个父类别";
        }
        /// <summary>
        /// 初始化 [类别名称] 简述内容
        /// </summary>
        private void InitDescName()
        {
            this.txtDescName.Foreground = Codes.ToBrush.StrToBrush("#00FFFF");
            this.txtDescName.Text = "收支类别名称[由中文、字母、数字组成]";
        }
        /// <summary>
        /// 初始化 [类别描述] 简述内容
        /// </summary>
        private void InitDescDescription()
        {
            this.txtDescDescription.Foreground = Codes.ToBrush.StrToBrush("#00FFFF");
            this.txtDescDescription.Text = "由中文、字母、数字组成，描述性文字表达";
        }
        #endregion 简述信息
        
        #region 类别名称
        /// <summary>
        /// 验证类别名称
        /// </summary>
        private void VerifyName()
        {
            this.txtName.Focus();
            this.IsVerify = false;
            this.txtDescName.Foreground = Codes.ToBrush.StrToBrush("#C80000");
            if (!ValidHelper.ChsIsChineseOrEngOrNum(this.txtName.Text))
            {
                this.txtDescName.Text = "类别名称输入不正确，只能由中文、字母、数字构成";
            }
            else if (this.txtName.Text.Length > 50)
            {
                this.txtDescName.Text = "类别名称输入长度超限，不能大于50个字符";
            }
            else
            {
                this.IsVerify = true;
                this.InitDescName();
            }
        }
        #endregion 类别名称

        #region 类别描述
        /// <summary>
        /// 验证类别描述
        /// </summary>
        private void VerifyDescription()
        {
            if (!string.IsNullOrEmpty(this.txtDescription.Text))
            {
                this.txtDescription.Focus();
                this.IsVerify = false;
                this.txtDescDescription.Foreground = Codes.ToBrush.StrToBrush("#C80000");
                if (!ValidHelper.ChsIsChineseOrEngOrNum(this.txtDescription.Text))
                {
                    this.txtDescDescription.Text = "类别描述输入不正确，只能由中文、字母、数字构成";
                }
                else if (this.txtDescription.Text.Length > 300)
                {
                    this.txtDescDescription.Text = "类别描述输入长度超限，不能大于300个字符";
                }
                else
                {
                    this.IsVerify = true;
                    this.InitDescDescription();
                }
            }
        }
        #endregion 类别描述

        #region 验证数据
        /// <summary>
        /// 验证输入数据是否正确
        /// </summary>
        /// <returns></returns>
        private void DataVerify()
        {
            this.IsVerify = true;
            if (IsVerify) this.VerifyName();
            if (IsVerify) this.VerifyDescription();
        }
        #endregion 验证数据
        
        #endregion private method & 私有方法

        #region public method & 公共方法

        #endregion public method & 公共方法
    }
}
