//-----------------------------------------------------------------------
// <copyright file="IMainViewModel.cs" company="Brian Welsh, welshnson.com">
//     Copyright (c) Brian Welsh, welshnson.com. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System.Windows.Input;

using AzureDevOpsTools.Framework.ViewModels;

namespace AzureDevOpsTools.Presentation.ViewModels
{
    internal interface IMainViewModel : IViewModel
    {
        string Title { get; }

        ICommand AboutDialogCommand { get; }
    }
}
