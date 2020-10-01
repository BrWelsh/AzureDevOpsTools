using System;
using System.Windows;

using AzureDevOpsTools.Presentation.Internal;

namespace AzureDevOpsTools.Presentation.Extensions
{
    internal static class SplashScreenExtensions
    {
        public static void Close(this SplashScreen splashScreen, int ticks = ApplicationConstants.SplashScreenFadeTicks)
        {
            splashScreen.Close(new TimeSpan(ticks));
        }

        public static void Show(this SplashScreen splashScreen)
        {
            splashScreen.Show(false, true);
        }
    }
}
