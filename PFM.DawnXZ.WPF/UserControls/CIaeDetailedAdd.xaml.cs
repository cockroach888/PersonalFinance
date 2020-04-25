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
    /// CIaeDetailedAdd.xaml 的交互逻辑
    /// </summary>
    public partial class CIaeDetailedAdd : UserControl
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
        public CIaeDetailedAdd()
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
            if (this.cboxType.Items.Count > 0) this.cboxType.SelectedIndex = 0;
            if (this.cboxMember.Items.Count > 0) this.cboxMember.SelectedIndex = 0;
            if (this.cboxAccounts.Items.Count > 0) this.cboxAccounts.SelectedIndex = 0;
            if (this.cboxCategory.Items.Count > 0) this.cboxCategory.SelectedIndex = 0;
            if (this.cboxName.Items.Count > 0) this.cboxName.SelectedIndex = -1;
            if (this.cboxAddress.Items.Count > 0) this.cboxAddress.SelectedIndex = -1;
            if (this.cboxDescription.Items.Count > 0) this.cboxDescription.SelectedIndex = -1;
            this.txtName.Clear();
            this.txtMoney.Clear();
            this.txtAddress.Clear();            
            this.txtDescription.Clear();
            this.txtMemo.Clear();
            this.InitDescType();
            this.InitDescMember();
            this.InitDescAccounts();
            this.InitDescCategory();
            this.InitDescName();
            this.InitDescMoney();
            this.InitDescAddress();            
            this.InitDescDescription();
            this.InitDescMemo();
        }
        /// <summary>
        /// 初始化数据盒子
        /// </summary>
        private void InitBoxOfComboBox()
        {
            //收支类型
            this.cboxType.SelectedValuePath = "Value";
            this.cboxType.DisplayMemberPath = "Key";
            this.cboxType.DataContext = DictionaryTsit.IncomingsOrOutgoings;
            //账务成员
            IList<PfmMemberMDL> mbrList = PfmMemberBLL.ISelect();
            if (mbrList.Count > 0)
            {
                this.cboxMember.SelectedValuePath = "MbrId";
                this.cboxMember.DisplayMemberPath = "MbrName";
                this.cboxMember.DataContext = mbrList;
            }
            else
            {
                this.cboxMember.SelectedValuePath = "Value";
                this.cboxMember.DisplayMemberPath = "Key";
                this.cboxMember.DataContext = DictionaryTsit.DefSelect;
            }
            //账务账目
            IList<PfmAccountsMDL> accList = PfmAccountsBLL.ISelect();
            if (accList.Count > 0)
            {
                this.cboxAccounts.SelectedValuePath = "AccId";
                this.cboxAccounts.DisplayMemberPath = "AccName";
                this.cboxAccounts.DataContext = accList;
            }
            else
            {
                this.cboxAccounts.SelectedValuePath = "Value";
                this.cboxAccounts.DisplayMemberPath = "Key";
                this.cboxAccounts.DataContext = DictionaryTsit.DefSelect;
            }
            //收支类别
            IList<PfmIaeCategoryMDL> catList = PfmIaeCategoryBLL.RecursiveI("　", "　");
            if (catList.Count > 0)
            {
                this.cboxCategory.SelectedValuePath = "CatId";
                this.cboxCategory.DisplayMemberPath = "CatName";
                this.cboxCategory.DataContext = catList;
            }
            else
            {
                this.cboxCategory.SelectedValuePath = "Value";
                this.cboxCategory.DisplayMemberPath = "Key";
                this.cboxCategory.DataContext = DictionaryTsit.DefSelect;
            }
            //收支项目·名称
            IList<PfmIaeItemsMDL> itemName = PfmIaeItemsBLL.ISelect("item_type = 1 and item_status > 0");
            if (itemName.Count > 0)
            {
                this.cboxName.SelectedValuePath = "ItemName";
                this.cboxName.DisplayMemberPath = "ItemName";
                this.cboxName.DataContext = itemName;
            }
            else
            {
                this.cboxName.SelectedValuePath = "Value";
                this.cboxName.DisplayMemberPath = "Key";
                this.cboxName.DataContext = DictionaryTsit.DefSelect;
            }
            //收支项目·地址
            IList<PfmIaeItemsMDL> addrName = PfmIaeItemsBLL.ISelect("item_type = 2 and item_status > 0");
            if (addrName.Count > 0)
            {
                this.cboxAddress.SelectedValuePath = "ItemName";
                this.cboxAddress.DisplayMemberPath = "ItemName";
                this.cboxAddress.DataContext = addrName;
            }
            else
            {
                this.cboxAddress.SelectedValuePath = "Value";
                this.cboxAddress.DisplayMemberPath = "Key";
                this.cboxAddress.DataContext = DictionaryTsit.DefSelect;
            }
            //收支项目·描述
            IList<PfmIaeItemsMDL> descName = PfmIaeItemsBLL.ISelect("item_type = 3 and item_status > 0");
            if (descName.Count > 0)
            {
                this.cboxDescription.SelectedValuePath = "ItemName";
                this.cboxDescription.DisplayMemberPath = "ItemName";
                this.cboxDescription.DataContext = descName;
            }
            else
            {
                this.cboxDescription.SelectedValuePath = "Value";
                this.cboxDescription.DisplayMemberPath = "Key";
                this.cboxDescription.DataContext = DictionaryTsit.DefSelect;
            }
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
                PfmIaeDetailedMDL detMdl = new PfmIaeDetailedMDL();
                detMdl.DetAddTime = DateTime.Now;
                detMdl.MbrId = TypeHelper.TypeToInt32(this.cboxMember.SelectedValue, 0);
                detMdl.AccId = TypeHelper.TypeToInt32(this.cboxAccounts.SelectedValue, 0);
                detMdl.CatId = TypeHelper.TypeToInt32(this.cboxCategory.SelectedValue, 0);
                detMdl.DetName = this.txtName.Text;
                decimal tmpMoney = 0;
                decimal.TryParse(this.txtMoney.Text, out tmpMoney);
                detMdl.DetMoney = tmpMoney * TypeHelper.TypeToInt32(this.cboxType.SelectedValue, 1);
                detMdl.DetAddress = string.IsNullOrEmpty(this.txtAddress.Text) ? null : this.txtAddress.Text;
                detMdl.DetDescription = string.IsNullOrEmpty(this.txtDescription.Text) ? null : this.txtDescription.Text;
                detMdl.DetMemo = string.IsNullOrEmpty(this.txtMemo.Text) ? null : this.txtMemo.Text;
                detMdl.DetStatus = 1;
                PfmIaeDetailedBLL.Insert(detMdl);
                MessageBoxResult boxResult = MessageBox.Show("新数据添加成功！是否继续添加？", "提示：", MessageBoxButton.YesNo, MessageBoxImage.Information, MessageBoxResult.No);
                if (boxResult == MessageBoxResult.Yes)
                {
                    this.InitializeData();
                }
                else
                {
                    if (ModuleExtend != null) this.ModuleExtend(false, Library.Transit.NameItems.IaeDetailed);
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
            if (ModuleExtend != null) this.ModuleExtend(false, Library.Transit.NameItems.IaeDetailed);
        }

        #region 收支项目下拉选择事件
        /// <summary>
        /// 收支项目·名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboxName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.cboxName.SelectedValue.ToString() != "-1")
            {
                this.txtName.Text = this.cboxName.SelectedValue.ToString();
            }
        }
        /// <summary>
        /// 收支项目·地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboxAddress_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.cboxAddress.SelectedValue.ToString() != "-1")
            {
                this.txtAddress.Text = this.cboxAddress.SelectedValue.ToString();
            }
        }
        /// <summary>
        /// 收支项目·描述
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboxDescription_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.cboxDescription.SelectedValue.ToString() != "-1")
            {
                this.txtDescription.Text = this.cboxDescription.SelectedValue.ToString();
            }
        }
        #endregion 收支项目下拉选择事件

        #endregion 功能按钮事件

        #region private method & 私有方法

        #region 简述信息
        /// <summary>
        /// 初始化 [收支类型] 简述内容
        /// </summary>
        private void InitDescType()
        {
            this.txtDescType.Foreground = Codes.ToBrush.StrToBrush("#00FFFF");
            this.txtDescType.Text = "收支类型共分两种：收入与支出，正负值表示";
        }
        /// <summary>
        /// 初始化 [账务成员] 简述内容
        /// </summary>
        private void InitDescMember()
        {
            this.txtDescMember.Foreground = Codes.ToBrush.StrToBrush("#00FFFF");
            this.txtDescMember.Text = "请选择收支账务成员";
        }
        /// <summary>
        /// 初始化 [账务账目] 简述内容
        /// </summary>
        private void InitDescAccounts()
        {
            this.txtDescAccounts.Foreground = Codes.ToBrush.StrToBrush("#00FFFF");
            this.txtDescAccounts.Text = "请选择收支账务账目";
        }
        /// <summary>
        /// 初始化 [收支类别] 简述内容
        /// </summary>
        private void InitDescCategory()
        {
            this.txtDescCategory.Foreground = Codes.ToBrush.StrToBrush("#00FFFF");
            this.txtDescCategory.Text = "请选择收支类别";
        }
        /// <summary>
        /// 初始化 [收支名称] 简述内容
        /// </summary>
        private void InitDescName()
        {
            this.txtDescName.Foreground = Codes.ToBrush.StrToBrush("#00FFFF");
            this.txtDescName.Text = "收支发生时的标签名称[由中文、字母、数字组成]";
        }
        /// <summary>
        /// 初始化 [收支金额] 简述内容
        /// </summary>
        private void InitDescMoney()
        {
            this.txtDescMoney.Foreground = Codes.ToBrush.StrToBrush("#00FFFF");
            this.txtDescMoney.Text = "收支发生时的金额数目[由数字及小数点组成]";
        }
        /// <summary>
        /// 初始化 [收支地点] 简述内容
        /// </summary>
        private void InitDescAddress()
        {
            this.txtDescAddress.Foreground = Codes.ToBrush.StrToBrush("#00FFFF");
            this.txtDescAddress.Text = "收支发生时的详细地点[由数字组成]";
        }        
        /// <summary>
        /// 初始化 [收支描述] 简述内容
        /// </summary>
        private void InitDescDescription()
        {
            this.txtDescDescription.Foreground = Codes.ToBrush.StrToBrush("#00FFFF");
            this.txtDescDescription.Text = "描述性文字表达，由中文、字母、数字组成";
        }
        /// <summary>
        /// 初始化 [收支备忘] 简述内容
        /// </summary>
        private void InitDescMemo()
        {
            this.txtDescMemo.Foreground = Codes.ToBrush.StrToBrush("#00FFFF");
            this.txtDescMemo.Text = "收支备忘事项，由中文、字母、数字组成";
        }
        #endregion 简述信息

        #region 账务成员
        /// <summary>
        /// 验证账务成员
        /// </summary>
        private void VerifyMember()
        {
            this.cboxMember.Focus();
            if (TypeHelper.TypeToInt32(this.cboxMember.SelectedValue, 0) <= 0)
            {
                this.txtDescMember.Foreground = Codes.ToBrush.StrToBrush("#C80000");
                this.txtDescMember.Text = "请选择正确的收支账务成员";
                this.IsVerify = false;
            }
            else
            {
                this.IsVerify = true;
                this.InitDescMember();
            }
        }
        #endregion 账务成员

        #region 账务账目
        /// <summary>
        /// 验证账务账目
        /// </summary>
        private void VerifyAccounts()
        {
            this.cboxAccounts.Focus();
            if (TypeHelper.TypeToInt32(this.cboxAccounts.SelectedValue, 0) <= 0)
            {
                this.txtDescAccounts.Foreground = Codes.ToBrush.StrToBrush("#C80000");
                this.txtDescAccounts.Text = "请选择正确的收支账务账目";
                this.IsVerify = false;
            }
            else
            {
                this.IsVerify = true;
                this.InitDescAccounts();
            }
        }
        #endregion 账务账目

        #region 收支类别
        /// <summary>
        /// 验证收支类别
        /// </summary>
        private void VerifyCategory()
        {
            this.cboxCategory.Focus();
            if (TypeHelper.TypeToInt32(this.cboxCategory.SelectedValue, 0) <= 0)
            {
                this.txtDescCategory.Foreground = Codes.ToBrush.StrToBrush("#C80000");
                this.txtDescCategory.Text = "请选择正确的收支类别";
                this.IsVerify = false;
            }
            else
            {
                this.IsVerify = true;
                this.InitDescCategory();
            }
        }
        #endregion 收支类别

        #region 收支名称
        /// <summary>
        /// 验证收支名称
        /// </summary>
        private void VerifyName()
        {
            this.txtName.Focus();
            this.IsVerify = false;
            this.txtDescName.Foreground = Codes.ToBrush.StrToBrush("#C80000");
            if (!ValidHelper.ChsIsChineseOrEngOrNum(this.txtName.Text))
            {
                this.txtDescName.Text = "收支名称输入不正确，由中文、字母、数字组成";

            }
            else if (this.txtName.Text.Length > 300)
            {
                this.txtDescName.Text = "收支名称输入长度超限，不能大于300个字符";
            }
            else
            {
                this.IsVerify = true;
                this.InitDescName();
            }
        }
        #endregion 收支名称

        #region 收支金额
        /// <summary>
        /// 验证收支金额
        /// </summary>
        private void VerifyMoney()
        {
            if (!string.IsNullOrEmpty(this.txtMoney.Text))
            {
                this.txtMoney.Focus();
                this.IsVerify = false;
                this.txtDescMoney.Foreground = Codes.ToBrush.StrToBrush("#C80000");
                if (!ValidHelper.NumIsDouble(this.txtMoney.Text))
                {
                    this.txtDescMoney.Text = "收支金额输入不正确，只能由数字及小数点构成";
                }
                else
                {
                    this.IsVerify = true;
                    this.InitDescMoney();
                }
            }
        }
        #endregion 收支金额

        #region 收支地点
        /// <summary>
        /// 验证收支地点
        /// </summary>
        private void VerifyAddress()
        {
            if (!string.IsNullOrEmpty(this.txtAddress.Text))
            {
                this.txtAddress.Focus();
                this.IsVerify = false;
                this.txtDescAddress.Foreground = Codes.ToBrush.StrToBrush("#C80000");
                if (!ValidHelper.ChsIsChineseOrEngOrNum(this.txtAddress.Text))
                {
                    this.txtDescAddress.Text = "收支地点输入不正确，只能由中文、字母、数字构成";
                }
                else if (this.txtAddress.Text.Length > 300)
                {
                    this.txtDescAddress.Text = "收支地点输入长度超限，不能大于300个字符";
                }
                else
                {
                    this.IsVerify = true;
                    this.InitDescAddress();
                }
            }
        }
        #endregion 收支地点

        #region 收支描述
        /// <summary>
        /// 验证收支描述
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
                    this.txtDescDescription.Text = "收支描述输入不正确，只能由中文、字母、数字构成";
                }
                else if (this.txtDescription.Text.Length > 500)
                {
                    this.txtDescDescription.Text = "收支描述输入长度超限，不能大于500个字符";
                }
                else
                {
                    this.IsVerify = true;
                    this.InitDescDescription();
                }
            }
        }
        #endregion 收支描述

        #region 收支备忘
        /// <summary>
        /// 验证收支备忘
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
                    this.txtDescMemo.Text = "收支备忘输入不正确，只能由中文、字母、数字构成";
                }
                else if (this.txtMemo.Text.Length > 2000)
                {
                    this.txtDescMemo.Text = "收支备忘输入长度超限，不能大于2000个字符";
                }
                else
                {
                    this.IsVerify = true;
                    this.InitDescMemo();
                }
            }
        }
        #endregion 收支备忘

        #region 验证数据
        /// <summary>
        /// 验证输入数据是否正确
        /// </summary>
        /// <returns></returns>
        private void DataVerify()
        {
            this.IsVerify = true;
            if (IsVerify) this.VerifyMember();
            if (IsVerify) this.VerifyAccounts();
            if (IsVerify) this.VerifyCategory();
            if (IsVerify) this.VerifyName();
            if (IsVerify) this.VerifyMoney();
            if (IsVerify) this.VerifyAddress();
            if (IsVerify) this.VerifyDescription();
            if (IsVerify) this.VerifyMemo();
        }
        #endregion 验证数据        

        #endregion private method & 私有方法       

        #region public method & 公共方法

        #endregion public method & 公共方法

    }
}
