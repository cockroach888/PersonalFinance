// =================================================================== 
// 中转站（PFM.DawnXZ.Library.Transit）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：StatusTsit.cs
// 项目名称：个人财务管理系统
// 创建时间：2012年08月10日 14:52:45
// 创建人员：宋杰军
// 负 责 人：宋杰军
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PFM.DawnXZ.Library.Transit
{
    /// <summary>
    /// 状态转换
    /// </summary>
    public class StatusTsit
    {
        /// <summary>
        /// 将对应状态值转换为中文显示
        /// </summary>
        /// <param name="status">状态值</param>
        /// <returns></returns>
        public static string StatusConvert(byte status)
        {
            string strTmp = "未知";
            switch (status)
            {
                case 0:
                    strTmp = "禁用";
                    break;
                case 1:
                    strTmp = "正常";
                    break;
                default:
                    break;
            }
            return strTmp;
        }
    }
}
