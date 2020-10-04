using System;
using System.Collections.Generic;
using System.Text;
using AzureDevOpsTools.Framework.ViewModels;

namespace AzureDevOpsTools.Presentation.ViewModels
{
    interface IAboutApplicaitonViewModel : IViewModel
    {
        string Title { get; }
    }
}
