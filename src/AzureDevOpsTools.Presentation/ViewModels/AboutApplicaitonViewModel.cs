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
            NavigateUrlCommand = ReactiveCommand.CreateFromTask<Uri>(NavigateToUrlCommand);
        }

        private async Task NavigateToUrlCommand(Uri link)
        {
            await Task<object>.Run(() => UriHelper.OpenExternalLink(link));
        }

        public string Title => ApplicationInfo.ProductName;

        public ICommand NavigateUrlCommand { get; }
    }
}
