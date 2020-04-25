// ===================================================================
// 工厂（PFM.DawnXZ.Library.DBFactory）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DALFactory.cs
// 项目名称：个人财务管理系统
// 创建时间：2012年06月04日 16:37:05
// 创建人员：宋杰军
// 负 责 人：宋杰军
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
using System;
using System.Reflection;
using PFM.DawnXZ.Library.IDAL;

namespace PFM.DawnXZ.Library.DBFactory
{
    /// <summary>
    /// 数据层工厂
    /// </summary>
    public class DALFactory
    {
        /// <summary>
        /// 通过反射机制，实例化接口对象
        /// </summary>
        //private static readonly string _path = System.Configuration.ConfigurationManager.AppSettings["pfmDAL"];
        private static readonly string _path = "PFM.DawnXZ.Library";

        /// <summary>
        /// 通过反射机制，实例化接口对象
        /// </summary>
        /// <param name="CacheKey">接口对象名称(键)</param>
        ///<returns>接口对象</returns>
        private static object GetInstance(string CacheKey)
        {
            object objType = DataCache.GetCache(CacheKey);
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(DALFactory._path).CreateInstance(CacheKey);
                    DataCache.SetCache(CacheKey, objType);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return objType;
        }

        /// <summary>
        /// 通过反射机制，实例化PfmAccounts接口对象
        /// </summary>
        ///<returns>PfmAccounts接口对象</returns>
        public static IPfmAccountsDAL PfmAccountsDALInstance()
        {
            string CacheKey = DALFactory._path + ".SqlServerDAL.PfmAccountsDAL";
            object objType = DALFactory.GetInstance(CacheKey);
            return (IPfmAccountsDAL)objType;
        }

        /// <summary>
        /// 通过反射机制，实例化PfmDictionary接口对象
        /// </summary>
        ///<returns>PfmDictionary接口对象</returns>
        public static IPfmDictionaryDAL PfmDictionaryDALInstance()
        {
            string CacheKey = DALFactory._path + ".SqlServerDAL.PfmDictionaryDAL";
            object objType = DALFactory.GetInstance(CacheKey);
            return (IPfmDictionaryDAL)objType;
        }

        /// <summary>
        /// 通过反射机制，实例化PfmError接口对象
        /// </summary>
        ///<returns>PfmError接口对象</returns>
        public static IPfmErrorDAL PfmErrorDALInstance()
        {
            string CacheKey = DALFactory._path + ".SqlServerDAL.PfmErrorDAL";
            object objType = DALFactory.GetInstance(CacheKey);
            return (IPfmErrorDAL)objType;
        }

        /// <summary>
        /// 通过反射机制，实例化PfmIaeCategory接口对象
        /// </summary>
        ///<returns>PfmIaeCategory接口对象</returns>
        public static IPfmIaeCategoryDAL PfmIaeCategoryDALInstance()
        {
            string CacheKey = DALFactory._path + ".SqlServerDAL.PfmIaeCategoryDAL";
            object objType = DALFactory.GetInstance(CacheKey);
            return (IPfmIaeCategoryDAL)objType;
        }

        /// <summary>
        /// 通过反射机制，实例化PfmIaeDetailed接口对象
        /// </summary>
        ///<returns>PfmIaeDetailed接口对象</returns>
        public static IPfmIaeDetailedDAL PfmIaeDetailedDALInstance()
        {
            string CacheKey = DALFactory._path + ".SqlServerDAL.PfmIaeDetailedDAL";
            object objType = DALFactory.GetInstance(CacheKey);
            return (IPfmIaeDetailedDAL)objType;
        }

        /// <summary>
        /// 通过反射机制，实例化PfmIaeItems接口对象
        /// </summary>
        ///<returns>PfmIaeItems接口对象</returns>
        public static IPfmIaeItemsDAL PfmIaeItemsDALInstance()
        {
            string CacheKey = DALFactory._path + ".SqlServerDAL.PfmIaeItemsDAL";
            object objType = DALFactory.GetInstance(CacheKey);
            return (IPfmIaeItemsDAL)objType;
        }

        /// <summary>
        /// 通过反射机制，实例化PfmLogs接口对象
        /// </summary>
        ///<returns>PfmLogs接口对象</returns>
        public static IPfmLogsDAL PfmLogsDALInstance()
        {
            string CacheKey = DALFactory._path + ".SqlServerDAL.PfmLogsDAL";
            object objType = DALFactory.GetInstance(CacheKey);
            return (IPfmLogsDAL)objType;
        }

        /// <summary>
        /// 通过反射机制，实例化PfmMember接口对象
        /// </summary>
        ///<returns>PfmMember接口对象</returns>
        public static IPfmMemberDAL PfmMemberDALInstance()
        {
            string CacheKey = DALFactory._path + ".SqlServerDAL.PfmMemberDAL";
            object objType = DALFactory.GetInstance(CacheKey);
            return (IPfmMemberDAL)objType;
        }

        /// <summary>
        /// 通过反射机制，实例化PfmReport接口对象
        /// </summary>
        ///<returns>PfmReport接口对象</returns>
        public static IPfmReportDAL PfmReportDALInstance()
        {
            string CacheKey = DALFactory._path + ".SqlServerDAL.PfmReportDAL";
            object objType = DALFactory.GetInstance(CacheKey);
            return (IPfmReportDAL)objType;
        }

        /// <summary>
        /// 通过反射机制，实例化PfmReportRecord接口对象
        /// </summary>
        ///<returns>PfmReportRecord接口对象</returns>
        public static IPfmReportRecordDAL PfmReportRecordDALInstance()
        {
            string CacheKey = DALFactory._path + ".SqlServerDAL.PfmReportRecordDAL";
            object objType = DALFactory.GetInstance(CacheKey);
            return (IPfmReportRecordDAL)objType;
        }
    }
}
