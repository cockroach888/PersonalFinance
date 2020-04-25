using System;
using System.Windows;

namespace PFM.DawnXZ.WPF.Codes
{
    /// <summary>
    /// Helper to show or close given splash window
    /// </summary>
    public static class Splasher
    {
        /// <summary>
        /// Get or set the splash screen window
        /// </summary>
        public static Window Splash { get; set; }
        /// <summary>
        /// Show splash screen
        /// </summary>
        public static void ShowSplash()
        {
            if (Splash != null) Splash.Dispatcher.BeginInvoke(new Action(() => { Splash.Show(); }));
        }
        /// <summary>
        /// Hide splash screen
        /// </summary>
        public static void HideSplash()
        {
            if (Splash != null) Splash.Dispatcher.BeginInvoke(new Action(() => { Splash.Hide(); }));
        }
        /// <summary>
        /// Close splash screen
        /// </summary>
        public static void CloseSplash()
        {
            if (Splash != null)
            {
                Splash.Dispatcher.BeginInvoke(new Action(() => { Splash.Close(); }));
                Splash.Dispatcher.BeginInvoke(new Action(() => { if (Splash is IDisposable) (Splash as IDisposable).Dispose(); }));
            }
        }
    }
}
