using System.Windows.Input;
using AzureDevOpsTools.Framework.ViewModels;

namespace AzureDevOpsTools.Presentation.ViewModels
{
    internal interface IAboutApplicaitonViewModel : IViewModel
    {
        string Title { get; }

        ICommand NavigateUrlCommand { get; }
    }
}
