// =================================================================== 
// 中转站（PFM.DawnXZ.Library.Transit）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：IaeCategoryTsit.cs
// 项目名称：个人财务管理系统
// 创建时间：2012年08月10日 16:42:23
// 创建人员：宋杰军
// 负 责 人：宋杰军
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
using System;
using PFM.DawnXZ.Library.BLL;

namespace PFM.DawnXZ.Library.Transit
{
    /// <summary>
    /// 收支类别
    /// </summary>
    public class IaeCategoryTsit
    {
        /// <summary>
        /// 取得收支类别名称
        /// </summary>
        /// <param name="catId">类别编号</param>
        /// <returns></returns>
        public static string GetName(int catId)
        {
            return PfmIaeCategoryBLL.Select(catId).CatName;
        }
    }
}
