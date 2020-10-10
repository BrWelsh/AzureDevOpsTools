using System;
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
            NavigateUriCommand = ReactiveCommand.CreateFromTask<Uri>(NavigateToUrlCommand);
        }

        private async Task NavigateToUrlCommand(Uri link)
        {
            Logger.LogInformation($"Navigating to {link}");
            await Task<object>.Run(() => UriHelper.OpenExternalLink(link));
        }

        public string Title => ApplicationInfo.ProductName;

        public ICommand NavigateUriCommand { get; }

        public Uri ProjectUri => ApplicationInfo.ProjectUri;

        public Uri RepositoryUri => ApplicationInfo.RepositoryUri;

        public Uri Website => ApplicationInfo.ProjectWebsite;
    }
}
