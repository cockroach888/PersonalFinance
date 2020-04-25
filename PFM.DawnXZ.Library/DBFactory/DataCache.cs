// =================================================================== 
// 工厂（PFM.DawnXZ.Library.DBFactory）项目
//====================================================================
//【宋杰军 @Copy Right 2008+】--【联系ＱＱ：6808240】--【请保留此注释】
//====================================================================
// 文件名称：DataCache.cs
// 项目名称：个人财务管理系统
// 创建时间：2012年06月04日 15:48:11
// 创建人员：宋杰军
// 负 责 人：宋杰军
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
using System;
using System.Collections;

namespace PFM.DawnXZ.Library.DBFactory
{
    /// <summary>
    /// 数据缓存对象
    /// </summary>
    public class DataCache
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DataCache()
        { }

        /// <summary>
        /// 缓存对象的集合
        /// </summary>
        private static Hashtable Hashtable = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        /// 获得缓存对象
        /// </summary>
        /// <param name="CacheKey">键</param>
        /// <returns>缓存对象</returns>
        public static object GetCache(string CacheKey)
        {
            return DataCache.Hashtable[CacheKey];
        }

        /// <summary>
        /// 设置缓存对象
        /// </summary>
        /// <param name="CacheKey">键</param>
        /// <param name="objObject">要被缓存的对象</param>
        public static void SetCache(string CacheKey, object objObject)
        {
            if (!DataCache.Hashtable.Contains(CacheKey))
                DataCache.Hashtable.Add(CacheKey, objObject);
        }
    }
}
