using System;
using System.Windows.Media;

namespace PFM.DawnXZ.WPF.Codes
{
    /// <summary>
    /// 将字符串颜色值转换成WPF识别颜色值
    /// </summary>
    public class ToBrush
    {
        /// <summary>
        /// 将字符串颜色值转换成WPF识别颜色值
        /// <remarks>
        /// Brush
        /// </remarks>
        /// </summary>
        /// <param name="color">字符串颜色值</param>
        /// <returns>WPF识别颜色值</returns>
        public static Brush StrToBrush(string color)
        {
            BrushConverter bc = new BrushConverter();
            Brush b = bc.ConvertFromString(color) as Brush;
            bc = null;
            if (b == null) b = Brushes.White;
            return b;
        }
    }
}
