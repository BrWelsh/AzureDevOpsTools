using System.Threading.Tasks;

namespace AzureDevOpsTools.Presentation.ViewModels
{
    public interface IViewModel
    {
        Task InitializeAsync(object parameter);
    }
}
