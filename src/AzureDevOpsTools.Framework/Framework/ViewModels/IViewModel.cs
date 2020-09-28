using System.Threading.Tasks;

namespace AzureDevOpsTools.Framework.ViewModels
{
    public interface IViewModel
    {
        Task InitializeAsync(object parameter);
    }
}
