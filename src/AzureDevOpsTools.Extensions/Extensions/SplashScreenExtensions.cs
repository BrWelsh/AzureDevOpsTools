using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using AzureDevOpsTools.Internal;

namespace AzureDevOpsTools.Extensions
{
    internal static class SplashScreenExtensions
    {
        public static void Close(this SplashScreen splashScreen, int ticks = LibrryConstants.SplashScreenFadeTicks)
        {
            splashScreen.Close(new TimeSpan(ticks));
        }

        public static void Show(this SplashScreen splashScreen)
        {
            splashScreen.Show(false, true);
        }
    }
}
