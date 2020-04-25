using DawnXZ.VerifyUtility;
using PFM.DawnXZ.Library.BLL;
using PFM.DawnXZ.Library.Entity;
using System;
using System.Windows;
using System.Windows.Controls;

namespace PFM.DawnXZ.WPF.UserControls {
    /// <summary>
    /// Interaction logic for CMemberAdd.xaml
    /// </summary>
    public partial class CMemberAdd : UserControl
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
        public CMemberAdd()
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
            this.txtName.Clear();
            this.txtRelation.Clear();
            this.txtDescription.Clear();
            this.InitDescName();
            this.InitDescRelation();
            this.InitDescDescription();
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
            if (IsVerify)
            {
                PfmMemberMDL mbrMdl = new PfmMemberMDL();
                mbrMdl.MbrAddTime = DateTime.Now;
                mbrMdl.MbrName = this.txtName.Text;
                mbrMdl.MbrRelation = this.txtRelation.Text;
                mbrMdl.MbrDescription = this.txtDescription.Text;
                PfmMemberBLL.Insert(mbrMdl);
                MessageBoxResult boxResult = MessageBox.Show("新数据添加成功！是否继续添加？", "提示：", MessageBoxButton.YesNo, MessageBoxImage.Information, MessageBoxResult.No);
                if (boxResult == MessageBoxResult.Yes)
                {
                    this.InitializeData();
                }
                else
                {
                    if (ModuleExtend != null) this.ModuleExtend(false, Library.Transit.NameItems.Member);
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
            if (ModuleExtend != null) this.ModuleExtend(false, Library.Transit.NameItems.Member);
        }
        #endregion 功能按钮事件

        #region private method & 私有方法

        #region 简述信息
        /// <summary>
        /// 初始化 [成员名称] 简述内容
        /// </summary>
        private void InitDescName()
        {
            this.txtDescName.Foreground = Codes.ToBrush.StrToBrush("#00FFFF");
            this.txtDescName.Text = "由中文组成，家庭组成（收支）成员";
        }
        /// <summary>
        /// 初始化 [成员关系] 简述内容
        /// </summary>
        private void InitDescRelation()
        {
            this.txtDescRelation.Foreground = Codes.ToBrush.StrToBrush("#00FFFF");
            this.txtDescRelation.Text = "由中文组成，成员之间的关系";
        }
        /// <summary>
        /// 初始化 [成员描述] 简述内容
        /// </summary>
        private void InitDescDescription()
        {
            this.txtDescDescription.Foreground = Codes.ToBrush.StrToBrush("#00FFFF");
            this.txtDescDescription.Text = "由中文、字母、数字组成，描述性文字表达";
        }
        #endregion 简述信息

        #region 成员名称
        /// <summary>
        /// 验证成员名称
        /// </summary>
        private void VerifyName()
        {
            this.txtName.Focus();
            this.IsVerify = false;
            this.txtDescName.Foreground = Codes.ToBrush.StrToBrush("#C80000");
            if (!ValidHelper.ChsIsChinese(this.txtName.Text))
            {
                this.txtDescName.Text = "成员名称输入不正确，只能由中文构成";
            }
            else if (this.txtName.Text.Length > 10)
            {
                this.txtDescName.Text = "成员名称输入长度超限，不能大于10个字符";
            }
            else
            {
                this.IsVerify = true;
                this.InitDescName();
            }
        }
        #endregion 成员名称

        #region 成员关系
        /// <summary>
        /// 验证成员关系
        /// </summary>
        private void VerifyRelation()
        {
            this.txtRelation.Focus();
            this.IsVerify = false;
            this.txtDescRelation.Foreground = Codes.ToBrush.StrToBrush("#C80000");
            if (!ValidHelper.ChsIsChinese(this.txtRelation.Text))
            {
                this.txtDescRelation.Text = "成员关系输入不正确，只能由中文构成";
            }
            else if (this.txtRelation.Text.Length > 50)
            {
                this.txtDescRelation.Text = "成员关系输入长度超限，不能大于50个字符";
            }
            else
            {
                this.IsVerify = true;
                this.InitDescRelation();
            }            
        }
        #endregion 成员关系

        #region 成员描述
        /// <summary>
        /// 验证成员描述
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
                    this.txtDescDescription.Text = "成员描述输入不正确，只能由中文、字母、数字构成";
                }
                else if (this.txtDescription.Text.Length > 500)
                {
                    this.txtDescDescription.Text = "成员描述输入长度超限，不能大于500个字符";
                }
                else
                {
                    this.IsVerify = true;
                    this.InitDescDescription();
                }
            }
        }
        #endregion 成员描述

        #region 验证数据
        /// <summary>
        /// 验证输入数据是否正确
        /// </summary>
        /// <returns></returns>
        private void DataVerify()
        {
            this.IsVerify = true;
            if (IsVerify) this.VerifyName();
            if (IsVerify) this.VerifyRelation();
            if (IsVerify) this.VerifyDescription();
        }
        #endregion 验证数据

        #endregion private method & 私有方法

        #region public method & 公共方法

        #endregion public method & 公共方法

    }
}
