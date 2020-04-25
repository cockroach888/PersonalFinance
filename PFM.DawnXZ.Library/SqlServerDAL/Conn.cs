using System;
using DawnXZ.DBUtility;

namespace PFM.DawnXZ.Library.SqlServerDAL
{
    /// <summary>
    /// The Conn class 
    /// </summary>
    public static class Conn
    {
        #region .
        //public static readonly string SqlConn = System.Configuration.ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;
        public static readonly string SqlConn =SQliteConnectionString.ConnectionString(@"Data\PFM.db3");
        #endregion
    }
}
