using System.Windows.Input;

using AzureDevOpsTools.Framework.ViewModels;

namespace AzureDevOpsTools.Presentation.ViewModels
{
    internal interface IMainViewModel : IViewModel
    {
        ICommand AboutDialogCommand { get; }
    }
}
