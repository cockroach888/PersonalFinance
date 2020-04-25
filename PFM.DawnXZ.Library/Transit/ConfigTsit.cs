// =================================================================== 
// 中转站（PFM.DawnXZ.Library.Transit）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DateTsit.cs
// 项目名称：个人财务管理系统
// 创建时间：2012年06月18日 18:22:16
// 创建人员：宋杰军
// 负 责 人：宋杰军
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
using System;
using System.IO;
using DawnXZ.FileUtility;
using DawnXZ.DawnUtility;

namespace PFM.DawnXZ.Library.Transit {
    public class ConfigTsit {
        /// <summary>
        /// 配置文件路径
        /// </summary>
        private static readonly string filePath = Path.Combine(Tools.AppPath, "config.ini");
        /// <summary>
        /// 每页显示记录数
        /// </summary>
        public static int PageSize {
            get {
                return IniHelper.ReadInt(filePath, "Pager", "PageSize", 200);
            }
        }
        /// <summary>
        /// 报表原始年份
        /// </summary>
        public static int YearOrigin {
            get {
                int year = IniHelper.ReadInt(filePath, "Date", "YearOrigin", 2012);
                return year > DateTime.Now.Year ? DateTime.Now.Year : year;
            }
        }
        /// <summary>
        /// 报表默认标题
        /// </summary>
        public static string ReprotTitle {
            get {
                return CryptoHelper.Decrypt(IniHelper.ReadString(filePath, "General", "report", "384E5A8021751039C11E917CD34F9D87"));
            }
        }
    }
}
