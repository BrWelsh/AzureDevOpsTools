//-----------------------------------------------------------------------
// <copyright file="WindowPlacementExtensions.cs" company="Brian Welsh, welshnson.com">
//     Copyright (c) Brian Welsh, welshnson.com. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace AzureDevOpsTools.Interop
{
#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1119 // Statement should not use unnecessary parenthesis

    public static class WindowPlacementExtensions
    {
        public static void LoadWindowPlacementFromSettings(this Window window, string setting)
        {
            if (string.IsNullOrEmpty(setting))
            {
                return;
            }

            WindowPlacement wp = WindowPlacement.Parse(setting);
            wp.length = Marshal.SizeOf(typeof(WindowPlacement));
            wp.flags = 0;
            wp.showCmd = (wp.showCmd == NativeMethods.SW_SHOWMINIMIZED ? NativeMethods.SW_SHOWNORMAL : wp.showCmd);

            IntPtr hwnd = new WindowInteropHelper(window).Handle;
            NativeMethods.SetWindowPlacement(hwnd, ref wp);
        }

        public static string SaveWindowPlacementToSettings(this Window window)
        {
            IntPtr hwnd = new WindowInteropHelper(window).Handle;

            NativeMethods.GetWindowPlacement(hwnd, out WindowPlacement wp);

            return wp.ToString();
        }
    }
#pragma warning restore SA1119 // Statement should not use unnecessary parenthesis
#pragma warning restore SA1600 // Elements should be documented
}
