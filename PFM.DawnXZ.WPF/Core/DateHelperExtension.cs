using DawnXZ.DawnUtility;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PFM.DawnXZ.WPF.Core {
    public static class DateHelperExtension {

        #region 当前时间

        /// <summary>
        /// 返回当前时间的标准日期格式
        /// </summary>
        /// <returns>yyyy-MM-dd</returns>
        public static string GetDate() {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }
        /// <summary>
        /// 返回当前时间的标准时间格式string
        /// </summary>
        /// <returns>HH:mm:ss</returns>
        public static string GetTime() {
            return DateTime.Now.ToString("HH:mm:ss");
        }
        /// <summary>
        /// 返回当前时间的标准时间格式string
        /// </summary>
        /// <returns>yyyy-MM-dd HH:mm:ss</returns>
        public static string GetDateTime() {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        /// <summary>
        /// 返回相对于当前时间的相对天数
        /// </summary>
        /// <param name="relativeday">增加的天数</param>
        /// <returns>相对天数</returns>
        public static string GetDateTimeOfDay(int relativeday) {
            return DateTime.Now.AddDays(relativeday).ToString("yyyy-MM-dd HH:mm:ss");
        }
        /// <summary>
        /// 返回相对于当前时间的相对分钟数
        /// </summary>
        /// <param name="relativeday">增加的分钟数</param>
        /// <returns>相对分钟数</returns>
        public static string GetDateTimeOfMinutes(int relativeday) {
            return DateTime.Now.AddMinutes(relativeday).ToString("yyyy-MM-dd HH:mm:ss");
        }
        /// <summary>
        /// 返回当前时间的标准时间格式
        /// </summary>
        /// <returns>yyyy-MM-dd HH:mm:ss:fffffff</returns>
        public static string GetDateTimeF() {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffffff");
        }

        #endregion

        #region 时间转换

        /// <summary>
        /// 返回指定日期格式
        /// </summary>
        /// <param name="datetimestr">需要转换的时间</param>
        /// <param name="replacestr">指定格式</param>
        /// <returns>转换后的时间</returns>
        public static string GetDate(string datetimestr, string replacestr) {
            if (datetimestr == null) return replacestr;
            if (datetimestr.Equals("")) return replacestr;
            try {
                datetimestr = Convert.ToDateTime(datetimestr).ToString("yyyy-MM-dd").Replace("1900-01-01", replacestr);
            }
            catch {
                return replacestr;
            }
            return datetimestr;
        }
        /// <summary>
        /// 转换时间为unix时间戳
        /// </summary>
        /// <param name="date">需要传递UTC时间,避免时区误差,例:DataTime.UTCNow</param>
        /// <returns></returns>
        public static double ConvertToUnixTimestamp(DateTime date) {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan diff = date - origin;
            return Math.Floor(diff.TotalSeconds);
        }
        /// <summary>
        /// 将8位日期型整型数据转换为日期字符串数据
        /// 默认为英文格式
        /// </summary>
        /// <param name="date">整型日期</param>
        /// <returns></returns>
        public static string FormatDate(int date) {
            return FormatDate(date, false);
        }
        /// <summary>
        /// 将8位日期型整型数据转换为日期字符串数据
        /// </summary>
        /// <param name="date">整型日期</param>
        /// <param name="chnType">是否以中文年月日输出</param>
        /// <returns></returns>
        public static string FormatDate(int date, bool chnType) {
            string dateStr = date.ToString();
            if (date <= 0 || dateStr.Length != 8) return dateStr;
            if (chnType) return dateStr.Substring(0, 4) + "年" + dateStr.Substring(4, 2) + "月" + dateStr.Substring(6) + "日";
            return dateStr.Substring(0, 4) + "-" + dateStr.Substring(4, 2) + "-" + dateStr.Substring(6);
        }

        #endregion

        #region 标准时间

        /// <summary>
        /// 返回标准时间
        /// </summary>
        /// <param name="fDateTime">转换时间</param>
        /// <param name="formatStr">转换格式</param>
        /// <returns>转换后的时间</returns>
        public static string GetStandardDateTime(string fDateTime, string formatStr) {
            if (fDateTime == "0000-0-0 0:00:00") return fDateTime;
            DateTime time = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            if (DateTime.TryParse(fDateTime, out time)) {
                return time.ToString(formatStr);
            }
            else {
                return "N/A";
            }
        }
        /// <summary>
        /// 返回标准时间 yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="fDateTime">转换时间</param>
        /// <returns>yyyy-MM-dd HH:mm:ss</returns>
        public static string GetStandardDateTime(string fDateTime) {
            return GetStandardDateTime(fDateTime, "yyyy-MM-dd HH:mm:ss");
        }
        /// <summary>
        /// 返回标准时间 yyyy-MM-dd
        /// </summary>
        /// <param name="fDate">转换时间</param>
        /// <returns>yyyy-MM-dd</returns>
        public static string GetStandardDate(string fDate) {
            return GetStandardDateTime(fDate, "yyyy-MM-dd");
        }

        #endregion

        #region 返回相差 秒数、分钟数、小时数

        /// <summary>
        /// 返回相差的秒数
        /// </summary>
        /// <param name="time">时间</param>
        /// <param name="Sec">秒数</param>
        /// <returns></returns>
        public static int StrDateDiffSeconds(string time, int Sec) {
            if (string.IsNullOrEmpty(time)) return 1;
            DateTime dateTime = TypeHelper.StrToDateTime(time, DateTime.Parse("1900-01-01"));
            if (dateTime.ToString("yyyy-MM-dd") == "1900-01-01") return 1;
            TimeSpan ts = DateTime.Now - dateTime.AddSeconds(Sec);
            if (ts.TotalSeconds > int.MaxValue) {
                return int.MaxValue;
            }
            else if (ts.TotalSeconds < int.MinValue) {
                return int.MinValue;
            }
            return (int)ts.TotalSeconds;
        }
        /// <summary>
        /// 返回相差的分钟数
        /// </summary>
        /// <param name="time"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static int StrDateDiffMinutes(string time, int minutes) {
            if (string.IsNullOrEmpty(time)) return 1;
            DateTime dateTime = TypeHelper.StrToDateTime(time, DateTime.Parse("1900-01-01"));
            if (dateTime.ToString("yyyy-MM-dd") == "1900-01-01") return 1;
            TimeSpan ts = DateTime.Now - dateTime.AddMinutes(minutes);
            if (ts.TotalMinutes > int.MaxValue) {
                return int.MaxValue;
            }
            else if (ts.TotalMinutes < int.MinValue) {
                return int.MinValue;
            }
            return (int)ts.TotalMinutes;
        }
        /// <summary>
        /// 返回相差的小时数
        /// </summary>
        /// <param name="time"></param>
        /// <param name="hours"></param>
        /// <returns></returns>
        public static int StrDateDiffHours(string time, int hours) {
            if (string.IsNullOrEmpty(time)) return 1;
            DateTime dateTime = TypeHelper.StrToDateTime(time, DateTime.Parse("1900-01-01"));
            if (dateTime.ToString("yyyy-MM-dd") == "1900-01-01") return 1;
            TimeSpan ts = DateTime.Now - dateTime.AddHours(hours);
            if (ts.TotalHours > int.MaxValue) {
                return int.MaxValue;
            }
            else if (ts.TotalHours < int.MinValue) {
                return int.MinValue;
            }
            return (int)ts.TotalHours;
        }

        #endregion

        #region 时间格式检测

        /// <summary>
        /// 是否常规时间
        /// </summary>
        public static bool IsTime(string timeval) {
            return Regex.IsMatch(timeval, @"^((([0-1]?[0-9])|(2[0-3])):([0-5]?[0-9])(:[0-5]?[0-9])?)$");
        }
        /// <summary>
        /// 判断字符串是否是yy-mm-dd字符串
        /// </summary>
        /// <param name="str">待判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsDateString(string str) {
            return Regex.IsMatch(str, @"(\d{4})-(\d{1,2})-(\d{1,2})");
        }

        #endregion

        #region 年

        /// <summary>
        /// 年·某年是否为闰年
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns></returns>
        public static bool YearIsLeap(int year) {
            return DateTime.IsLeapYear(year);
        }
        /// <summary>
        /// 年·某年共有多少天
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns></returns>
        public static int YearDays(int year) {
            return DateTime.IsLeapYear(year) ? 366 : 365;
        }
        /// <summary>
        /// 计算某年的第一天
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns></returns>
        public static DateTime YearByFirstDay(int year) {
            return Convert.ToDateTime(string.Format("{0}-01-01", year));
        }
        /// <summary>
        /// 计算某年的最后一天
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns></returns>
        public static DateTime YearByLastDay(int year) {
            return Convert.ToDateTime(string.Format("{0}-12-31", year));
        }

        #endregion

        #region 月

        /// <summary>
        /// 当前月有多少天
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <returns></returns>
        public static int MonthDays(int year, int month) {
            return DateTime.DaysInMonth(year, month);
        }
        /// <summary>
        /// 计算某月的第一天
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns></returns>
        public static DateTime MonthByFirstDay(int year, int month) {
            return Convert.ToDateTime(string.Format("{0}-{1}-01", year, month));
        }
        /// <summary>
        /// 计算某月的最后一天
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns></returns>
        public static DateTime MonthByLastDay(int year, int month) {
            return Convert.ToDateTime(string.Format("{0}-{1}-{2}", year, month, MonthDays(year, month)));
        }

        #endregion

        #region 周

        /// <summary>
        /// 得到一年中的某周的起始日和截止日
        /// 年 nYear
        /// 周数 nNumWeek
        /// 周始 out dtWeekStart
        /// 周终 out dtWeekeEnd
        /// </summary>
        /// <param name="nYear">年份</param>
        /// <param name="nNumWeek">周数</param>
        /// <param name="dtWeekStart">起始日期</param>
        /// <param name="dtWeekeEnd">结束日期</param>
        public static void GetWeek(int nYear, int nNumWeek, out DateTime dtWeekStart, out DateTime dtWeekeEnd) {
            DateTime dt = new DateTime(nYear, 1, 1);
            dt = dt + new TimeSpan((nNumWeek - 1) * 7, 0, 0, 0);
            dtWeekStart = dt.AddDays(-(int)dt.DayOfWeek + (int)DayOfWeek.Monday);
            dtWeekeEnd = dt.AddDays((int)DayOfWeek.Saturday - (int)dt.DayOfWeek + 1);
        }
        /// <summary>
        /// 求某年有多少周
        /// 返回 int
        /// </summary>
        /// <param name="strYear">年份</param>
        /// <returns>int</returns>
        public static int GetYearWeekCount(int strYear) {
            System.DateTime fDt = DateTime.Parse(strYear.ToString() + "-01-01");
            int k = Convert.ToInt32(fDt.DayOfWeek);//得到该年的第一天是周几 
            if (k == 1) {
                int countDay = fDt.AddYears(1).AddDays(-1).DayOfYear;
                int countWeek = countDay / 7 + 1;
                return countWeek;
            }
            else {
                int countDay = fDt.AddYears(1).AddDays(-1).DayOfYear;
                int countWeek = countDay / 7 + 2;
                return countWeek;
            }
        }
        /// <summary>
        /// 求当前日期是一年的中第几周
        /// </summary>
        /// <param name="curDay">日期</param>
        /// <returns></returns>
        public static int WeekOfYear(DateTime curDay) {
            int firstdayofweek = Convert.ToInt32(Convert.ToDateTime(curDay.Year.ToString() + "- " + "1-1 ").DayOfWeek);
            int days = curDay.DayOfYear;
            int daysOutOneWeek = days - (7 - firstdayofweek);
            if (daysOutOneWeek <= 0) {
                return 1;
            }
            else {
                int weeks = daysOutOneWeek / 7;
                if (daysOutOneWeek % 7 != 0) weeks++;
                return weeks + 1;
            }
        }

        #endregion

        #region 季度

        /// <summary>
        /// 计算当前月份是第几季度
        /// </summary>
        /// <param name="month">月份</param>
        /// <returns></returns>
        public static int QuarterByThis(int month) {
            return (DateTime.Now.AddMonths(0 - (month - 1) % 3 + 3).Month / 3);
        }
        /// <summary>
        /// 得到一年中的某季度的起始日和截止日
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="quarter">第几季度</param>
        /// <param name="firstDay">起始日期</param>
        /// <param name="lastDay">结束日期</param>
        public static void QuarterByFirstDay(int year, int quarter, out DateTime firstDay, out DateTime lastDay) {
            switch (quarter) {
                case 1:
                    firstDay = Convert.ToDateTime(string.Format("{0}-01-01 0:00:00.000", year));
                    break;
                case 2:
                    firstDay = Convert.ToDateTime(string.Format("{0}-04-01 0:00:00.000", year));
                    break;
                case 3:
                    firstDay = Convert.ToDateTime(string.Format("{0}-07-01 0:00:00.000", year));
                    break;
                case 4:
                    firstDay = Convert.ToDateTime(string.Format("{0}-10-01 0:00:00.000", year));
                    break;
                default:
                    firstDay = YearByFirstDay(year);
                    break;
            }
            lastDay = firstDay.AddMonths(3).AddDays(-1);
        }

        #endregion

        #region 报表周期数据

        /// <summary>
        /// 报表周期数据·年
        /// </summary>
        /// <param name="yearOrigin">原始年份</param>
        /// <returns>Key / Value</returns>
        public static Dictionary<string, int> BuildPeriodicOfYear(int yearOrigin) {
            Dictionary<string, int> reriodic = new Dictionary<string, int>();
            for (; yearOrigin <= DateTime.Now.Year; yearOrigin++) {
                reriodic.Add(string.Format("{0}年", yearOrigin), yearOrigin);
            }
            return reriodic;
        }
        /// <summary>
        /// 报表周期数据·年
        /// </summary>
        /// <param name="yearOrigin">原始年份</param>
        /// <param name="yearFormat">年份格式</param>
        /// <returns>Key / Value</returns>
        public static Dictionary<string, int> BuildPeriodicOfYear(int yearOrigin, string yearFormat) {
            Dictionary<string, int> reriodic = new Dictionary<string, int>();
            for (; yearOrigin <= DateTime.Now.Year; yearOrigin++) {
                reriodic.Add(TypeHelper.StrToDateTime(yearOrigin).ToString(yearFormat), yearOrigin);
            }
            return reriodic;
        }
        /// <summary>
        /// 报表周期数据·月
        /// </summary>
        /// <returns>Key / Value</returns>
        public static Dictionary<string, int> BuildPeriodicOfMonth() {
            Dictionary<string, int> reriodic = new Dictionary<string, int>();
            for (int i = 1; i <= 12; i++) {
                if (i < 10) {
                    reriodic.Add(string.Format("0{0}月", i), i);
                }
                else {
                    reriodic.Add(string.Format("{0}月", i), i);
                }
            }
            return reriodic;
        }
        /// <summary>
        /// 报表周期数据·月
        /// </summary>
        /// <param name="monthFormat">月份格式</param>
        /// <returns>Key / Value</returns>
        public static Dictionary<string, int> BuildPeriodicOfMonth(string monthFormat) {
            Dictionary<string, int> reriodic = new Dictionary<string, int>();
            for (int i = 1; i <= 12; i++) {
                reriodic.Add(TypeHelper.StrToDateTime(DateTime.Now.Year, i).ToString(monthFormat), i);
            }
            return reriodic;
        }
        /// <summary>
        /// 报表周期数据·周
        /// <remarks>
        /// 默认为当前年份
        /// </remarks>
        /// </summary>
        /// <returns>Key / Value</returns>
        public static Dictionary<string, int> BuildPeriodicOfWeek() {
            Dictionary<string, int> reriodic = new Dictionary<string, int>();
            int weekCount = GetYearWeekCount(DateTime.Now.Year);
            for (int i = 1; i <= weekCount; i++) {
                reriodic.Add(string.Format("第{0}周", i), i);
            }
            return reriodic;
        }
        /// <summary>
        /// 报表周期数据·周
        /// <remarks>
        /// 指定年份周数
        /// </remarks>
        /// </summary>
        /// <returns>Key / Value</returns>
        public static Dictionary<string, int> BuildPeriodicOfWeek(int year) {
            Dictionary<string, int> reriodic = new Dictionary<string, int>();
            int weekCount = GetYearWeekCount(year);
            for (int i = 1; i <= weekCount; i++) {
                reriodic.Add(string.Format("第{0}周", i), i);
            }
            return reriodic;
        }
        /// <summary>
        /// 报表周期数据·季
        /// </summary>
        /// <returns>Key / Value</returns>
        public static Dictionary<string, int> BuildPeriodicOfSeason() {
            Dictionary<string, int> reriodic = new Dictionary<string, int>();
            for (int i = 1; i <= 4; i++) {
                reriodic.Add(string.Format("第{0}季度", i), i);
            }
            return reriodic;
        }

        #endregion

    }
}
