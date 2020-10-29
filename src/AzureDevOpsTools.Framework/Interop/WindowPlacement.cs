//-----------------------------------------------------------------------
// <copyright file="WindowPlacement.cs" company="Brian Welsh, welshnson.com">
//     Copyright (c) Brian Welsh, welshnson.com. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace AzureDevOpsTools.Interop
{
#pragma warning disable CA1815 // Override equals and operator equals on value types
#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable CA1051 // Do not declare visible instance fields
#pragma warning disable SA1307 // Accessible fields should begin with upper-case letter
#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1129 // Do not use default value type constructor

    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct WindowPlacement
    {
        public int length;
        public int flags;
        public int showCmd;

        public Point minPosition;
        public Point maxPosition;
        public Rect normalPosition;

        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0}|{1}|{2}|{3}|{4}|{5}",
                this.length,
                this.flags,
                this.showCmd,
                this.minPosition,
                this.maxPosition,
                this.normalPosition);
        }

        public static WindowPlacement Parse(string value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            string[] parts = value.Split('|');

            if (parts.Length != 6)
            {
                return new WindowPlacement();
            }

            int flength = int.Parse(parts[0], CultureInfo.InvariantCulture);
            int fflags = int.Parse(parts[1], CultureInfo.InvariantCulture);
            int fshowCmd = int.Parse(parts[2], CultureInfo.InvariantCulture);
            var fminPosition = Point.Parse(parts[3]);
            var fmaxPosition = Point.Parse(parts[4]);
            var fnormalPosition = Rect.Parse(parts[5]);

            return new WindowPlacement
            {
                length = flength,
                flags = fflags,
                showCmd = fshowCmd,
                minPosition = fminPosition,
                maxPosition = fmaxPosition,
                normalPosition = fnormalPosition,
            };
        }
    }

    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        public int Left;
        public int Top;
        public int Width;
        public int Height;

        public Rect(int left, int top, int width, int height)
        {
            this.Left = left;
            this.Top = top;
            this.Width = width;
            this.Height = height;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0};{1};{2};{3}", this.Left, this.Top, this.Width, this.Height);
        }

        public static Rect Parse(string value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            int[] ss = Array.ConvertAll(
                value.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries),
                v => int.Parse(v, CultureInfo.InvariantCulture));
            return ss.Length == 4 ? new Rect(ss[0], ss[1], ss[2], ss[3]) : new Rect();
        }
    }

    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Point Parse(string value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            int[] ss = Array.ConvertAll(
                value.Split(
                    new[] { ';' },
                    StringSplitOptions.RemoveEmptyEntries),
                v => int.Parse(v, CultureInfo.InvariantCulture));
            return ss.Length == 2 ? new Point(ss[0], ss[1]) : new Point();
        }


        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0};{1}", this.X, this.Y);
        }
    }

#pragma warning restore SA1129 // Do not use default value type constructor
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore SA1307 // Accessible fields should begin with upper-case letter
#pragma warning restore CA1051 // Do not declare visible instance fields
#pragma warning restore CA1815 // Override equals and operator equals on value types
#pragma warning restore IDE1006 // Naming Styles
}
