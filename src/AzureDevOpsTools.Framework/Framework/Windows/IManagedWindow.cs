//-----------------------------------------------------------------------
// <copyright file="IManagedWindow.cs" company="Brian Welsh, welshnson.com">
//     Copyright (c) Brian Welsh, welshnson.com. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace AzureDevOpsTools.Framework.Windows
{
    public interface IManagedWindow
    {
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

        object? DataContext { get; set; }

        void Close();

        void Show();

#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    }
}
