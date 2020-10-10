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
