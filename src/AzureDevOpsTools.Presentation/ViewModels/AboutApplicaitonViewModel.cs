using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AzureDevOpsTools.Framework.ViewModels;
using AzureDevOpsTools.Presentation.Utility;
using Microsoft.Extensions.Logging;

namespace AzureDevOpsTools.Presentation.ViewModels
{
    internal class AboutApplicaitonViewModel : ViewModelBase, IAboutApplicaitonViewModel
    {
        public AboutApplicaitonViewModel(ILogger<AboutApplicaitonViewModel> logger)
            : base(logger)
        {
        }

        public string Title => ApplicationInfo.ProductName;


    }
}
