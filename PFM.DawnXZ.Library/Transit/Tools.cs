// =================================================================== 
// 中转站（PFM.DawnXZ.Library.Transit）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：Tools.cs
// 项目名称：个人财务管理系统
// 创建时间：2012年06月16日 18:22:16
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
    /// 工具类
    /// </summary>
    public class Tools
    {
        #region Variable & 变量

        #endregion Variable & 变量

        #region Instance variables & 实例变量

        #endregion Instance variables & 实例变量

        #region Constant & 常量

        #endregion Constant & 常量

        #region Attribute & 属性

        #region Path & 路径
        /// <summary>
        /// 应用程序路径·WPF
        /// </summary>
        public static string AppPath
        {
            get { return System.AppDomain.CurrentDomain.BaseDirectory; }
        }
        public static string PathByFileName
        {
            get
            {
                return System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            }
        }
        public static string PathByCurrentDirectory
        {
            get
            {
                return System.Environment.CurrentDirectory;
            }
        }
        public static string PathByGetCurrentDirectory
        {
            get
            {
                return System.IO.Directory.GetCurrentDirectory();
            }
        }
        public static string PathByBaseDirectory
        {
            get
            {
                return System.AppDomain.CurrentDomain.BaseDirectory;
            }
        }
        public static string PathByApplicationBase
        {
            get
            {
                return AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            }
        }
        #endregion Path & 路径

        /// <summary>
        /// 软件版本号·格式：v 0.0
        /// </summary>
        public static string GetVer
        {
            get
            {
                return string.Format("v {0}", GetVersion);
            }
        }
        /// <summary>
        /// 软件版本号·格式：0.0
        /// </summary>
        public static string GetVersion
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(2);
            }
        }
        #endregion Attribute & 属性

        #region Constructed function & 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public Tools()
        { }
        #endregion Constructed function & 构造函数

        #region Member method & 成员方法

        #region public method & 公共方法
        /// <summary>
        /// <函数：Encode>
        /// 作用：将字符串内容转化为16进制数据编码，其逆过程是Decode
        /// 参数说明：
        /// strEncode 需要转化的原始字符串
        /// 转换的过程是直接把字符转换成Unicode字符,比如数字"3"-->0033,汉字"我"-->U+6211
        /// 函数decode的过程是encode的逆过程.
        /// </summary>
        /// <param name="strEncode"></param>
        /// <returns></returns>
        public static string EncodeHex(string strEncode)
        {
            string strReturn = "";//  存储转换后的编码
            foreach (short shortx in strEncode.ToCharArray())
            {
                strReturn += shortx.ToString("X4");
            }
            return strReturn;
        }
        /// <summary>
        /// <函数：Decode>
        /// 作用：将16进制数据编码转化为字符串，是Encode的逆过程
        /// </summary>
        /// <param name="strDecode"></param>
        /// <returns></returns>
        public static string DecodeHex(string strDecode)
        {
            string sResult = "";
            for (int i = 0; i < strDecode.Length / 4; i++)
            {
                sResult += (char)short.Parse(strDecode.Substring(i * 4, 4), global::System.Globalization.NumberStyles.HexNumber);
            }
            return sResult;
        }
        #endregion public method & 公共方法

        #region private method & 私有方法

        #endregion private method & 私有方法

        #endregion Member method & 成员方法
    }
}
