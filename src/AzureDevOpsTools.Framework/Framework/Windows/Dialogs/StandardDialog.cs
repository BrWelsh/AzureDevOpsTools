//-----------------------------------------------------------------------
// <copyright file="StandardDialog.cs" company="Brian Welsh, welshnson.com">
//     Copyright (c) Brian Welsh, welshnson.com. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Interop;

using AzureDevOpsTools.Interop;

namespace AzureDevOpsTools.Framework.Windows.Dialogs
{
#pragma warning disable CA1806 // Do not ignore method results
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable SA1600 // Elements should be documented

    public class StandardDialog : Window
    {
        public StandardDialog()
        {
            // Add window name to scope so that runtime properties can be referenced from XAML
            //  (Name setting must be done here and not in xaml because this is a base class)
            //  You probably won't need to, but working example is here in case you do.
            var ns = new NameScope();
            NameScope.SetNameScope(this, ns);
            ns["window"] = this;

            // Call Initialize Component via Reflection, so you do not need
            //  to call InitializeComponent() every time in your base class
            _ = GetType()
                .GetMethod(
                    "InitializeComponent",
                    System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .Invoke(this, null);

            // Set runtime DataContext - Designer mode will not run this code
            DataContext = this;
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            const int GWL_STYLE = -16;
            const int GWL_EXSTYLE = -20;
            const int WS_EX_DLGMODALFRAME = 0x0001;

            const int SWP_NOSIZE = 0x0001;
            const int SWP_NOMOVE = 0x0002;
            const int SWP_NOZORDER = 0x0004;
            const int SWP_FRAMECHANGED = 0x0020;

            IntPtr hwnd = new WindowInteropHelper(this).Handle;

            int value = NativeMethods.GetWindowLong(hwnd, GWL_STYLE);
            NativeMethods.SetWindowLong(hwnd, GWL_STYLE, value & -131073 & -65537);

            int extendedStyle = NativeMethods.GetWindowLong(hwnd, GWL_EXSTYLE);
            NativeMethods.SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | WS_EX_DLGMODALFRAME);

            // Update the window's non-client area to reflect the changes
            NativeMethods.SetWindowPos(
                hwnd,
                IntPtr.Zero,
                0,
                0,
                0,
                0,
                SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER | SWP_FRAMECHANGED);

            if (!Debugger.IsAttached)
            {
                NativeMethods.SendMessage(hwnd, NativeMethods.WM_SETICON, 0, (IntPtr)0);
                NativeMethods.SendMessage(hwnd, NativeMethods.WM_SETICON, 1, (IntPtr)0);
            }
        }

        // User-Defined UI Configuration class containing System.Drawing.Color
        //  and Brush properties (platform-agnostic styling in your Project.Core.dll assembly)
        //  public UIStyle UIStyle => Core.UIStyle.Current;

        // IValueConverter that converts System.Drawing.Color properties
        //  into WPF-equivalent Colors and Brushes
        //  You can skip this if you do not need or did not implement your own ValueConverter
        //  public static IValueConverter UniversalValueConverter { get; } = new UniversalValueConverter();

        // Remove unused private members
        // Add accessibility modifiers.
        // Remove unused member declaration.
#pragma warning disable IDE0051, RCS1018, RCS1213
#pragma warning disable SA1400 // Access modifier should be declared
        void InitializeComponent()
        {
        }
#pragma warning restore SA1400 // Access modifier should be declared
#pragma warning restore RCS1213, RCS1018, IDE0051

#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore CA1822 // Mark members as static
#pragma warning restore CA1806 // Do not ignore method results
    }
}
