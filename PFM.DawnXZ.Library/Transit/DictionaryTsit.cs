// =================================================================== 
// 中转站（PFM.DawnXZ.Library.Transit）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DictionaryTsit.cs
// 项目名称：个人财务管理系统
// 创建时间：2012年08月10日 14:51:21
// 创建人员：宋杰军
// 负 责 人：宋杰军
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
using System;
using System.Collections.Generic;
using PFM.DawnXZ.Library.Entity;
using PFM.DawnXZ.Library.BLL;

namespace PFM.DawnXZ.Library.Transit
{
    /// <summary>
    /// 账务字典
    /// </summary>
    public class DictionaryTsit
    {
        /// <summary>
        /// 获取所有数据
        /// <remarks>
        /// 排序：字典类型、字典标识
        /// </remarks>
        /// </summary>
        /// <returns></returns>
        public static IList<PfmDictionaryMDL> ISelect()
        {
            return PfmDictionaryBLL.ISelect(null, "dict_type,dict_mark");
        }
        /// <summary>
        /// 获得报表类型名称
        /// </summary>
        /// <param name="dictMark">类型编号</param>
        /// <returns></returns>
        public static string GetDictName(byte dictMark)
        {
            string dictName="未知类型";
            switch (dictMark)
            {
                case 1:
                    dictName = "年";
                    break;
                case 2:
                    dictName = "月";
                    break;
                case 3:
                    dictName = "周";
                    break;
                case 4:
                    dictName = "季度";
                    break;
                default:
                    break;
            }
            return dictName;
        }

        #region 键值对

        #region 数据状态
        /// <summary>
        /// 数据状态键值对
        /// <remarks>
        /// 1 正常 / 0 禁用，Key / Value
        /// </remarks>
        /// </summary>
        public static Dictionary<string, int> Status
        {
            get { return BuildStatus(); }
        }
        /// <summary>
        /// 数据状态键值对
        /// <remarks>
        /// 1 正常 / 0 禁用
        /// </remarks>
        /// </summary>
        /// <returns>Key / Value</returns>
        private static Dictionary<string, int> BuildStatus()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"正常",1}
                ,{"禁用",0}
            };
            return dict;
        }
        #endregion 数据状态

        #region 请选择
        /// <summary>
        /// 下拉框默认项键值对[请选择]
        /// <remarks>
        /// -1 请选择
        /// </remarks>
        /// </summary>
        public static Dictionary<string, int> DefSelect
        {
            get { return BuildDefSelect(); }
        }
        /// <summary>
        /// 下拉框默认项键值对[请选择]
        /// <remarks>
        /// -1 请选择
        /// </remarks>
        /// </summary>
        /// <returns>Key / Value</returns>
        private static Dictionary<string, int> BuildDefSelect()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"--请选择--",-1}
            };
            return dict;
        }
        #endregion 请选择

        #region 顶级分类
        /// <summary>
        /// 下拉框默认项键值对[顶级分类]
        /// <remarks>
        /// -1 顶级分类
        /// </remarks>
        /// </summary>
        public static Dictionary<string, int> DefCategory
        {
            get { return BuildDefCategory(); }
        }
        /// <summary>
        /// 下拉框默认项键值对[顶级分类]
        /// <remarks>
        /// -1 顶级分类
        /// </remarks>
        /// </summary>
        /// <returns>Key / Value</returns>
        private static Dictionary<string, int> BuildDefCategory()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"--顶级分类--",-1}
            };
            return dict;
        }
        #endregion 顶级分类

        #region 收支项目类型
        /// <summary>
        /// 收支项目类型键值对
        /// <remarks>
        /// 1名称/2地址/3描述
        /// </remarks>
        /// </summary>
        public static Dictionary<string, int> IaeItemsType
        {
            get { return BuildIaeItemsType(); }
        }
        /// <summary>
        /// 收支项目类型键值对
        /// <remarks>
        /// 1名称/2地址/3描述
        /// </remarks>
        /// </summary>
        /// <returns>Key / Value</returns>
        private static Dictionary<string, int> BuildIaeItemsType()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"名称",1}
                ,{"地址",2}
                ,{"描述",3}
            };
            return dict;
        }
        #endregion 收支项目类型

        #region 收支明细正负值
        /// <summary>
        /// 收支明细正负值键值对
        /// <remarks>
        /// 1 正常 / 0 禁用，Key / Value
        /// </remarks>
        /// </summary>
        public static Dictionary<string, int> IncomingsOrOutgoings
        {
            get { return BuildIncomingsOrOutgoings(); }
        }
        /// <summary>
        /// 收支明细正负值键值对
        /// <remarks>
        /// 1 正常 / 0 禁用
        /// </remarks>
        /// </summary>
        /// <returns>Key / Value</returns>
        private static Dictionary<string, int> BuildIncomingsOrOutgoings()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"支出",-1}
                ,{"收入",1}
            };
            return dict;
        }
        #endregion 收支明细正负值

        #endregion 键值对

    }
}
