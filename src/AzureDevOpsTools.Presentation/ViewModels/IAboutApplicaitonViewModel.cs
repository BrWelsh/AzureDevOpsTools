using System;
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
        ICommand NavigateUriCommand { get; }
    }
}
