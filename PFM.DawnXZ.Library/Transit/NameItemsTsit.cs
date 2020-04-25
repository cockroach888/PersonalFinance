// =================================================================== 
// 中转站（PFM.DawnXZ.Library.Transit）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：NameItemsTsit.cs
// 项目名称：个人财务管理系统
// 创建时间：2012年07月13日 15:15:15
// 创建人员：宋杰军
// 负 责 人：宋杰军
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
using System;
using System.Collections;

namespace PFM.DawnXZ.Library.Transit
{
    /// <summary>
    /// 模块名称枚举
    /// </summary>
    public enum NameItems
    {
        /// <summary>
        /// 主程序名称
        /// </summary>
        Main,
        /// <summary>
        /// 收支明细
        /// </summary>
        IaeDetailed,
        /// <summary>
        /// 收支项目
        /// </summary>
        IaeItems,
        /// <summary>
        /// 收支类别
        /// </summary>
        IaeCategory,
        /// <summary>
        /// 账务账目
        /// </summary>
        Accounts,
        /// <summary>
        /// 账务成员
        /// </summary>
        Member,
        /// <summary>
        /// 账务报表
        /// </summary>
        Report,
        /// <summary>
        /// 账务字典
        /// </summary>
        Dictionary,
        /// <summary>
        /// 日志信息
        /// </summary>
        Logs,
        /// <summary>
        /// 错误信息
        /// </summary>
        Error,
        /// <summary>
        /// 关于系统
        /// </summary>
        About,
        /// <summary>
        /// 系统设置
        /// </summary>
        System
    }
    /// <summary>
    /// 模块名称
    /// </summary>
    public class NameItemsTsit
    {
        /// <summary>
        /// 模块名称列表项
        /// </summary>
        private string[] arrayNames = new string[] {
            "个人账务管理系统[生财版] —— 我的好帮手！"
            ,"个人账务管理系统[生财版] —— 收支明细管理"
            ,"个人账务管理系统[生财版] —— 收支项目管理"
            ,"个人账务管理系统[生财版] —— 收支类别管理"
            ,"个人账务管理系统[生财版] —— 账务账目管理"
            ,"个人账务管理系统[生财版] —— 账务成员管理"
            ,"个人账务管理系统[生财版] —— 账务报表管理"
            ,"个人账务管理系统[生财版] —— 账务字典管理"
            ,"个人账务管理系统[生财版] —— 日志信息管理"
            ,"个人账务管理系统[生财版] —— 错误信息管理"
            ,"个人账务管理系统[生财版] —— 关于系统"
            ,"个人账务管理系统[生财版] —— 系统设置"
        };
        /// <summary>
        /// 模块名称
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        public string this[int index]
        {
            get { return arrayNames[index]; }
        }
        /// <summary>
        /// 模块名称
        /// </summary>
        public NameItemsTsit()
        { }        
    }
}
