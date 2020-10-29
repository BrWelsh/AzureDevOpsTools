//-----------------------------------------------------------------------
// <copyright file="IAboutApplicaitonViewModel.cs" company="Brian Welsh, welshnson.com">
//     Copyright (c) Brian Welsh, welshnson.com. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Input;

using AzureDevOpsTools.Framework.ViewModels;

namespace AzureDevOpsTools.Presentation.ViewModels
{
    internal interface IAboutApplicaitonViewModel : IViewModel
    {
        string Title { get; }

        Uri ProjectUri { get; }

        Uri RepositoryUri { get; }

        Uri Website { get; }

        IEnumerable<Assembly> ApplicationAssemblies { get; }

        ICommand NavigateUriCommand { get; }
    }
}
