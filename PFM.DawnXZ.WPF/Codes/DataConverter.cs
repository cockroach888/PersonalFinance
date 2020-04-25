using DawnXZ.DawnUtility;
using PFM.DawnXZ.Library.Transit;
using System;
using System.Globalization;
using System.Windows.Data;

namespace PFM.DawnXZ.WPF.Codes {

    #region 字符串截断处理
    /// <summary>
    /// 字符串截断处理
    /// </summary>
    [ValueConversion(typeof(string), typeof(string))]
    public class StringTruncation : IValueConverter
    {
        /// <summary>
        /// 字符串截断处理
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int length = 0;
            int.TryParse(parameter.ToString(), out length);
            string strTemp = StringHelper.ClearBR(value.ToString());
            if (strTemp.Length <= length) return strTemp;
            strTemp = StringHelper.InterceptByTitle(strTemp, length, "…");
            return strTemp;
        }
        /// <summary>
        /// 字符串截断处理
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    #endregion 字符串截断处理

    #region 状态转换处理
    /// <summary>
    /// 状态转换处理
    /// </summary>
    [ValueConversion(typeof(string), typeof(byte))]
    public class StateTruncation : IValueConverter
    {
        /// <summary>
        /// 状态转换处理
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte state = 0;
            byte.TryParse(value.ToString(), out state);
            string strTemp = "禁用";
            switch (state)
            {
                case 1:
                    strTemp = "正常";
                    break;
                case 2:
                    break;
                default:
                    break;
            }
            return strTemp;
        }
        /// <summary>
        /// 状态转换处理
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    #endregion 状态转换处理

    #region 账务字典类型转换处理
    /// <summary>
    /// 账务字典类型转换处理
    /// </summary>
    [ValueConversion(typeof(string), typeof(byte))]
    public class TypeTruncation : IValueConverter
    {
        /// <summary>
        /// 账务字典类型转换处理
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte state = 0;
            byte.TryParse(value.ToString(), out state);
            string strTemp = "未知";
            switch (state)
            {
                case 1:
                    strTemp = "周期";
                    break;
                case 2:
                    strTemp = "单位";
                    break;
                default:
                    break;
            }
            return strTemp;
        }
        /// <summary>
        /// 账务字典类型转换处理
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    #endregion 账务字典类型转换处理

    #region 账务字典标识转换处理
    /// <summary>
    /// 账务字典标识转换处理
    /// </summary>
    [ValueConversion(typeof(string), typeof(byte))]
    public class DictMarkTruncation : IValueConverter
    {
        /// <summary>
        /// 账务字典标识转换处理
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte type = 0;
            byte.TryParse(parameter.ToString(), out type);
            byte mark = 0;
            byte.TryParse(value.ToString(), out mark);
            string strTemp = "未知";
            switch (type)
            {
                case 1:
                    switch (mark)
                    {
                        case 1:
                            strTemp = "年";
                            break;
                        case 2:
                            strTemp = "月";
                            break;
                        case 3:
                            strTemp = "周";
                            break;
                        case 4:
                            strTemp = "季度";
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
                    switch (mark)
                    {
                        case 1:
                            strTemp = "元";
                            break;
                        case 2:
                            strTemp = "角";
                            break;
                        case 3:
                            strTemp = "分";
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            return strTemp;
        }
        /// <summary>
        /// 账务字典标识转换处理
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    #endregion 账务字典标识转换处理

    #region 账务成员名称获得
    /// <summary>
    /// 账务成员名称获得
    /// </summary>
    [ValueConversion(typeof(string), typeof(int))]
    public class MemberNameTruncation : IValueConverter
    {
        /// <summary>
        /// 账务成员名称获得
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int mbrId = 0;
            int.TryParse(value.ToString(), out mbrId);
            if (mbrId <= 0) return "未知成员";
            return MemberTsit.GetName(mbrId);
        }
        /// <summary>
        /// 账务成员名称获得
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    #endregion 账务成员名称获得    

    #region 收支项目类型转换处理
    /// <summary>
    /// 收支项目类型转换处理
    /// </summary>
    [ValueConversion(typeof(string), typeof(byte))]
    public class ItemsTypeTruncation : IValueConverter
    {
        /// <summary>
        /// 收支项目类型转换处理
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int typeId = 0;
            string strTmp = "未知项目";
            int.TryParse(value.ToString(), out typeId);
            if (typeId <= 0) return strTmp;
            switch (typeId)
            {
                case 1:
                    strTmp = "名称";
                    break;
                case 2:
                    strTmp = "地址";
                    break;
                case 3:
                    strTmp = "描述";
                    break;
                default:
                    break;
            }
            return strTmp;
        }
        /// <summary>
        /// 收支项目类型转换处理
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    #endregion 收支项目类型转换处理

    #region 账务账目名称获得
    /// <summary>
    /// 账务账目名称获得
    /// </summary>
    [ValueConversion(typeof(string), typeof(int))]
    public class AccountNameTruncation : IValueConverter
    {
        /// <summary>
        /// 账务账目名称获得
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int accId = 0;
            int.TryParse(value.ToString(), out accId);
            if (accId <= 0) return "未知账目";
            return AccountTsit.GetName(accId);
        }
        /// <summary>
        /// 账务账目名称获得
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    #endregion 账务账目名称获得
    
    #region 收支类别名称获得
    /// <summary>
    /// 收支类别名称获得
    /// </summary>
    [ValueConversion(typeof(string), typeof(int))]
    public class IaeCategoryNameTruncation : IValueConverter
    {
        /// <summary>
        /// 收支类别名称获得
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int catId = 0;
            int.TryParse(value.ToString(), out catId);
            if (catId <= 0) return "未知类别";
            return IaeCategoryTsit.GetName(catId);
        }
        /// <summary>
        /// 账务账目名称获得
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    #endregion 收支类别名称获得
    
}
