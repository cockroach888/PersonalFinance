using DawnXZ.DawnUtility;
using DawnXZ.VerifyUtility;
using PFM.DawnXZ.Library.BLL;
using PFM.DawnXZ.Library.Entity;
using PFM.DawnXZ.Library.Transit;
using System;
using System.Windows;
using System.Windows.Controls;

namespace PFM.DawnXZ.WPF.UserControls {
    /// <summary>
    /// CIaeItemsAdd.xaml 的交互逻辑
    /// </summary>
    public partial class CIaeItemsAdd : UserControl
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
        #endregion Attribute & 属性

        #region Constructed function & 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public CIaeItemsAdd()
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
            if (this.cboxStatus.Items.Count > 0) this.cboxStatus.SelectedIndex = 0;
            if (this.cboxType.Items.Count > 0) this.cboxType.SelectedIndex = 0;
            this.txtName.Clear();
            this.txtDescription.Clear();
            this.InitDescType();
            this.InitDescName();
            this.InitDescDescription();
        }
        /// <summary>
        /// 初始化数据盒子
        /// </summary>
        private void InitBoxOfComboBox()
        {            
            this.cboxStatus.SelectedValuePath = "Value";
            this.cboxStatus.DisplayMemberPath = "Key";
            this.cboxStatus.DataContext = DictionaryTsit.Status;
            this.cboxType.SelectedValuePath = "Value";
            this.cboxType.DisplayMemberPath = "Key";
            this.cboxType.DataContext = DictionaryTsit.IaeItemsType;
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
                PfmIaeItemsMDL itemMdl = new PfmIaeItemsMDL();
                itemMdl.ItemAddTime = DateTime.Now;                
                itemMdl.ItemStatus = TypeHelper.TypeToTinyInt(this.cboxStatus.SelectedValue, 0);
                itemMdl.ItemType = TypeHelper.TypeToTinyInt(this.cboxType.SelectedValue, 0);
                itemMdl.ItemName = this.txtName.Text;
                itemMdl.ItemDescription = string.IsNullOrEmpty(this.txtDescription.Text) ? null : this.txtDescription.Text;
                PfmIaeItemsBLL.Insert(itemMdl);
                MessageBoxResult boxResult = MessageBox.Show("新数据添加成功！是否继续添加？", "提示：", MessageBoxButton.YesNo, MessageBoxImage.Information, MessageBoxResult.No);
                if (boxResult == MessageBoxResult.Yes)
                {
                    this.InitializeData();
                }
                else
                {
                    if (ModuleExtend != null) this.ModuleExtend(false, Library.Transit.NameItems.IaeItems);
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
            if (ModuleExtend != null) this.ModuleExtend(false, Library.Transit.NameItems.IaeItems);
        }
        #endregion 功能按钮事件

        #region private method & 私有方法

        #region 简述信息
        /// <summary>
        /// 初始化 [项目类型] 简述内容
        /// </summary>
        private void InitDescType()
        {
            this.txtDescType.Foreground = Codes.ToBrush.StrToBrush("#00FFFF");
            this.txtDescType.Text = "用于区分各项目的类型";
        }
        /// <summary>
        /// 初始化 [项目名称] 简述内容
        /// </summary>
        private void InitDescName()
        {
            this.txtDescName.Foreground = Codes.ToBrush.StrToBrush("#00FFFF");
            this.txtDescName.Text = "常用的明细名称[由中文、字母、数字组成]";
        }        
        /// <summary>
        /// 初始化 [项目描述] 简述内容
        /// </summary>
        private void InitDescDescription()
        {
            this.txtDescDescription.Foreground = Codes.ToBrush.StrToBrush("#00FFFF");
            this.txtDescDescription.Text = "由中文、字母、数字组成，描述性文字表达";
        }
        #endregion 简述信息

        #region 项目名称
        /// <summary>
        /// 验证项目名称
        /// </summary>
        private void VerifyName()
        {
            this.txtName.Focus();
            this.IsVerify = false;
            this.txtDescName.Foreground = Codes.ToBrush.StrToBrush("#C80000");
            if (!ValidHelper.ChsIsChineseOrEngOrNum(this.txtName.Text))
            {
                this.txtDescName.Text = "项目名称输入不正确，只能由中文、字母、数字构成";
            }
            else if (this.txtName.Text.Length > 300)
            {
                this.txtDescName.Text = "项目名称输入长度超限，不能大于300个字符";
            }
            else
            {
                this.IsVerify = true;
                this.InitDescName();
            }
        }
        #endregion 项目名称

        #region 项目描述
        /// <summary>
        /// 验证项目描述
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
                    this.txtDescDescription.Text = "项目描述输入不正确，只能由中文、字母、数字构成";
                }
                else if (this.txtDescription.Text.Length > 2000)
                {
                    this.txtDescDescription.Text = "项目描述输入长度超限，不能大于2000个字符";
                }
                else
                {
                    this.IsVerify = true;
                    this.InitDescDescription();
                }
            }
        }
        #endregion 项目描述

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
