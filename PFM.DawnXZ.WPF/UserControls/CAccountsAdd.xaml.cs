using DawnXZ.DawnUtility;
using PFM.DawnXZ.Library.BLL;
using PFM.DawnXZ.Library.Entity;
using PFM.DawnXZ.Library.Transit;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DawnXZ.VerifyUtility;

namespace PFM.DawnXZ.WPF.UserControls {
    /// <summary>
    /// CAccountsAdd.xaml 的交互逻辑
    /// </summary>
    public partial class CAccountsAdd : UserControl
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
        public CAccountsAdd()
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
            if (this.cboxMember.Items.Count > 0) this.cboxMember.SelectedIndex = 0;
            if (this.cboxStatus.Items.Count > 0) this.cboxStatus.SelectedIndex = 0;
            this.txtName.Clear();
            this.txtCode.Clear();
            this.txtCard.Clear();
            this.txtPurpose.Clear();
            this.txtDescription.Clear();
            this.InitDescMember();
            this.InitDescName();
            this.InitDescCode();
            this.InitDescCard();
            this.InitDescPurpose();
            this.InitDescDescription();
        }
        /// <summary>
        /// 初始化数据盒子
        /// </summary>
        private void InitBoxOfComboBox()
        {
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
            this.cboxStatus.SelectedValuePath = "Value";
            this.cboxStatus.DisplayMemberPath = "Key";
            this.cboxStatus.DataContext = DictionaryTsit.Status;
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
                PfmAccountsMDL accMdl = new PfmAccountsMDL();
                accMdl.AccAddTime = DateTime.Now;
                accMdl.MbrId = TypeHelper.TypeToInt32(this.cboxMember.SelectedValue, 0);
                accMdl.AccStatus = TypeHelper.TypeToTinyInt(this.cboxStatus.SelectedValue, 0);
                accMdl.AccName = this.txtName.Text;
                accMdl.AccCode = string.IsNullOrEmpty(this.txtCode.Text) ? null : this.txtCode.Text;
                accMdl.AccCard = string.IsNullOrEmpty(this.txtCard.Text) ? null : this.txtCard.Text;
                accMdl.AccPurpose = string.IsNullOrEmpty(this.txtPurpose.Text) ? null : this.txtPurpose.Text;
                accMdl.AccDescription = string.IsNullOrEmpty(this.txtDescription.Text) ? null : this.txtDescription.Text;
                PfmAccountsBLL.Insert(accMdl);
                MessageBoxResult boxResult = MessageBox.Show("新数据添加成功！是否继续添加？", "提示：", MessageBoxButton.YesNo, MessageBoxImage.Information, MessageBoxResult.No);
                if (boxResult == MessageBoxResult.Yes)
                {
                    this.InitializeData();
                }
                else
                {
                    if (ModuleExtend != null) this.ModuleExtend(false, Library.Transit.NameItems.Accounts);
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
            if (ModuleExtend != null) this.ModuleExtend(false, Library.Transit.NameItems.Accounts);
        }
        #endregion 功能按钮事件

        #region private method & 私有方法

        #region 简述信息
        /// <summary>
        /// 初始化 [隶属成员] 简述内容
        /// </summary>
        private void InitDescMember()
        {
            this.txtDescMember.Foreground = Codes.ToBrush.StrToBrush("#00FFFF");
            this.txtDescMember.Text = "账目隶属于哪个成员";
        }
        /// <summary>
        /// 初始化 [账目名称] 简述内容
        /// </summary>
        private void InitDescName()
        {
            this.txtDescName.Foreground = Codes.ToBrush.StrToBrush("#00FFFF");
            this.txtDescName.Text = "用于快速识别的账目名称[由中文、字母、数字组成]";
        }
        /// <summary>
        /// 初始化 [账目编码] 简述内容
        /// </summary>
        private void InitDescCode()
        {
            this.txtDescCode.Foreground = Codes.ToBrush.StrToBrush("#00FFFF");
            this.txtDescCode.Text = "账目唯一标识编码[由字母、数字组成，且字母开头]";
        }
        /// <summary>
        /// 初始化 [账目卡号] 简述内容
        /// </summary>
        private void InitDescCard()
        {
            this.txtDescCard.Foreground = Codes.ToBrush.StrToBrush("#00FFFF");
            this.txtDescCard.Text = "账目所涉及的银行卡号或相关卡号[由数字组成]";
        }
        /// <summary>
        /// 初始化 [账目用途] 简述内容
        /// </summary>
        private void InitDescPurpose()
        {
            this.txtDescPurpose.Foreground = Codes.ToBrush.StrToBrush("#00FFFF");
            this.txtDescPurpose.Text = "账目的用途[由中文、字母、数字组成]";
        }
        /// <summary>
        /// 初始化 [账目描述] 简述内容
        /// </summary>
        private void InitDescDescription()
        {
            this.txtDescDescription.Foreground = Codes.ToBrush.StrToBrush("#00FFFF");
            this.txtDescDescription.Text = "由中文、字母、数字组成，描述性文字表达";
        }
        #endregion 简述信息

        #region 隶属成员
        /// <summary>
        /// 验证隶属成员
        /// </summary>
        private void VerifyMember()
        {
            this.cboxMember.Focus();
            if (TypeHelper.TypeToInt32(this.cboxMember.SelectedValue, 0) <= 0)
            {
                this.txtDescMember.Foreground = Codes.ToBrush.StrToBrush("#C80000");
                this.txtDescMember.Text = "请选择正确的账目隶属成员";
                this.IsVerify = false;
            }
            else
            {
                this.IsVerify = true;
                this.InitDescMember();
            }
        }
        #endregion 隶属成员

        #region 账目名称
        /// <summary>
        /// 验证账目名称
        /// </summary>
        private void VerifyName()
        {
            this.txtName.Focus();
            this.IsVerify = false;
            this.txtDescName.Foreground = Codes.ToBrush.StrToBrush("#C80000");
            if (!ValidHelper.ChsIsChineseOrEngOrNum(this.txtName.Text))
            {                
                this.txtDescName.Text = "账目名称输入不正确，只能由中文、字母、数字构成";
            }
            else if (this.txtName.Text.Length > 20)
            {
                this.txtDescName.Text = "账目名称输入长度超限，不能大于20个字符";
            }
            else
            {
                this.IsVerify = true;
                this.InitDescName();
            }
        }
        #endregion 账目名称

        #region 账目编码
        /// <summary>
        /// 验证账目编码
        /// </summary>
        private void VerifyCode()
        {
            if (!string.IsNullOrEmpty(this.txtCode.Text))
            {
                this.txtCode.Focus();
                this.IsVerify = false;
                this.txtDescCode.Foreground = Codes.ToBrush.StrToBrush("#C80000");
                if (!ValidHelper.EngIsEngAndNums(this.txtCode.Text))
                {                    
                    this.txtDescCode.Text = "账目编码输入不正确，只能由字母、数字构成，且字母开头";
                    
                }
                else if (StringHelper.GetStringLength(this.txtCode.Text) > 50)
                {
                    this.txtDescCode.Text = "账目编码输入长度超限，不能大于50个字符";
                }
                else
                {
                    this.IsVerify = true;
                    this.InitDescCode();
                }
            }
        }
        #endregion 账目编码

        #region 账目卡号
        /// <summary>
        /// 验证账目卡号
        /// </summary>
        private void VerifyCard()
        {
            if (!string.IsNullOrEmpty(this.txtCard.Text))
            {
                this.txtCard.Focus();
                this.IsVerify = false;
                this.txtDescCard.Foreground = Codes.ToBrush.StrToBrush("#C80000");
                if (!ValidHelper.NumIsNumeric(this.txtCard.Text))
                {
                    this.txtDescCard.Text = "账目卡号输入不正确，只能由数字构成";
                }
                else if (this.txtCard.Text.Length > 50)
                {
                    this.txtDescCard.Text = "账目卡号输入长度超限，不能大于50个字符";
                }
                else
                {
                    this.IsVerify = true;
                    this.InitDescCard();
                }
            }
        }
        #endregion 账目卡号

        #region 账目用途
        /// <summary>
        /// 验证账目用途
        /// </summary>
        private void VerifyPurpose()
        {
            if (!string.IsNullOrEmpty(this.txtPurpose.Text))
            {
                this.txtPurpose.Focus();
                this.IsVerify = false;
                this.txtDescPurpose.Foreground = Codes.ToBrush.StrToBrush("#C80000");
                if (!ValidHelper.ChsIsChineseOrEngOrNum(this.txtPurpose.Text))
                {
                    this.txtDescPurpose.Text = "账目用途输入不正确，只能由中文、字母、数字构成";
                }
                else if (this.txtPurpose.Text.Length > 100)
                {
                    this.txtDescPurpose.Text = "账目用途输入长度超限，不能大于100个字符";
                }
                else
                {
                    this.IsVerify = true;
                    this.InitDescPurpose();
                }
            }
        }
        #endregion 账目用途

        #region 账目描述
        /// <summary>
        /// 验证账目描述
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
                    this.txtDescDescription.Text = "账目描述输入不正确，只能由中文、字母、数字构成";
                }
                else if (this.txtDescription.Text.Length > 500)
                {
                    this.txtDescDescription.Text = "账目描述输入长度超限，不能大于500个字符";
                }
                else
                {
                    this.IsVerify = true;
                    this.InitDescDescription();
                }
            }
        }
        #endregion 账目描述

        #region 验证数据
        /// <summary>
        /// 验证输入数据是否正确
        /// </summary>
        /// <returns></returns>
        private void DataVerify()
        {
            this.IsVerify = true;
            if (IsVerify) this.VerifyMember();
            if (IsVerify) this.VerifyName();
            if (IsVerify) this.VerifyCode();
            if (IsVerify) this.VerifyCard();
            if (IsVerify) this.VerifyPurpose();
            if (IsVerify) this.VerifyDescription();
        }
        #endregion 验证数据

        #endregion private method & 私有方法

        #region public method & 公共方法

        #endregion public method & 公共方法

    }
}
