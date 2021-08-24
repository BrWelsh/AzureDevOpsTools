//-----------------------------------------------------------------------
// <copyright file="SplashScreenExtensions.cs" company="Brian Welsh, welshnson.com">
//     Copyright (c) Brian Welsh, welshnson.com. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Windows;

using AzureDevOpsTools.Internal;

namespace AzureDevOpsTools.Extensions
{
    internal static class SplashScreenExtensions
    {
        public static void Close(this SplashScreen splashScreen, int ticks = LibraryConstants.SplashScreenFadeTicks)
        {
            splashScreen.Close(new TimeSpan(ticks));
        }

        public static void Show(this SplashScreen splashScreen)
        {
            splashScreen.Show(false, true);
        }
    }
}
