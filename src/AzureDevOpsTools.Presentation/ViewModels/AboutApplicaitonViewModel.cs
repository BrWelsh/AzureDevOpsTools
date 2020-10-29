//-----------------------------------------------------------------------
// <copyright file="AboutApplicaitonViewModel.cs" company="Brian Welsh, welshnson.com">
//     Copyright (c) Brian Welsh, welshnson.com. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;

using AzureDevOpsTools.Framework.ViewModels;
using AzureDevOpsTools.Presentation.Utility;

using Microsoft.Extensions.Logging;

using ReactiveUI;

namespace AzureDevOpsTools.Presentation.ViewModels
{
    internal class AboutApplicaitonViewModel : ViewModelBase, IAboutApplicaitonViewModel
    {
        public AboutApplicaitonViewModel(ILogger<AboutApplicaitonViewModel> logger)
            : base(logger)
        {
            this.NavigateUriCommand = ReactiveCommand.CreateFromTask<Uri>(this.NavigateToUrlCommand);
        }

        public string Title => ApplicationInfo.ProductName;

        public ICommand NavigateUriCommand { get; }

        public Uri ProjectUri => ApplicationInfo.ProjectUri;

        public Uri RepositoryUri => ApplicationInfo.RepositoryUri;

        public Uri Website => ApplicationInfo.ProjectWebsite;

        public IEnumerable<Assembly> ApplicationAssemblies => ApplicationInfo.ApplicationAssemblies;

        private async Task NavigateToUrlCommand(Uri link)
        {
            this.Logger.LogInformation($"Navigating to {link}");
            await Task<object>.Run(() => UriHelper.OpenExternalLink(link));
        }
    }
}
