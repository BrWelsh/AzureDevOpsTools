using System.Windows.Input;
using AzureDevOpsTools.Framework.ViewModels;

namespace AzureDevOpsTools.Presentation.ViewModels
{
    public interface IMainViewModel : IViewModel
    {
        ICommand AboutDialogCommand { get; }
    }
}
