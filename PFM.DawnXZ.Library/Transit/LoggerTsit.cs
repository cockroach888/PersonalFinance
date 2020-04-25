// =================================================================== 
// 中转站（PFM.DawnXZ.Library.Transit）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：LoggerTsit.cs
// 项目名称：个人财务管理系统
// 创建时间：2012年06月08日 10:50:11
// 创建人员：宋杰军
// 负 责 人：宋杰军
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
using System;
using System.IO;

namespace PFM.DawnXZ.Library.Transit
{
    /// <summary>
    /// 文件日志类
    /// 默认：根目录logs文件夹
    /// </summary>
    public class LoggerTsit
    {
        #region Property
        /// <summary>
        /// 日志保存路径
        /// </summary>
        public static string LogPath
        {
            get { return Path.Combine(Tools.AppPath, "logs"); }
        }
        #endregion Property

        #region 构造函数
        /// <summary>
        /// 文件日志类
        /// </summary>
        public LoggerTsit()
        { }
        #endregion 构造函数

        #region 成员方法

        #region 错误信息
        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="ex">Exception</param>
        public static void Write(Exception ex)
        {
            Write(string.Format("发生错误：{0}\r\n错误描述：{1}", ex.Message, ex.StackTrace));
            //Write(string.Format("Error Message: {0}", ex.Message));
            //Write(string.Format("Error Description: {0}", ex.StackTrace));
        }
        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="logPath">日志路径</param>
        /// <param name="ex">Exception</param>
        public static void Write(string logPath, Exception ex)
        {
            Write(logPath, string.Format("发生错误：{0}\r\n错误描述：{1}", ex.Message, ex.StackTrace));
            //Write(logPath, string.Format("Error Message: {0}", ex.Message));
            //Write(logPath, string.Format("Error Description: {0}", ex.StackTrace));
        }
        #endregion 错误信息

        #region 记录日志
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="msg">内容</param>
        public static void Write(string msg)
        {
            if (!Directory.Exists(LogPath))
            {
                Directory.CreateDirectory(LogPath);
            }
            string fn = string.Format(@"{0}.log", DateTime.Now.ToString("yyyy-MM-dd"));
            fn = Path.Combine(LogPath, fn);
            if (!File.Exists(fn))
            {
                FileStream fs = File.Create(fn);
                fs.Close();
            }
            WriteMsg(fn, string.Format(@"{0} 【{1}】", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), msg));
        }
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="logPath">日志路径</param>
        /// <param name="msg">内容</param>
        public static void Write(string logPath, string msg)
        {
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
            string fn = string.Format(@"{0}.log", DateTime.Now.ToString("yyyy-MM-dd"));
            fn = Path.Combine(logPath, fn);
            if (!File.Exists(fn))
            {
                FileStream fs = File.Create(fn);
                fs.Close();
            }
            WriteMsg(fn, string.Format(@"{0} 【{1}】", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), msg));
        }
        #endregion 记录日志

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="fileName">文件</param>
        /// <param name="msg">内容</param>
        private static void WriteMsg(string fileName, string msg)
        {
            try
            {
                StreamWriter sw = File.AppendText(fileName);
                sw.WriteLine(msg);
                sw.Flush();
                sw.Close();
            }
            catch { }
        }

        #endregion 成员方法
    }
}