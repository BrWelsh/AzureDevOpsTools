using System.Threading.Tasks;

using AzureDevOpsTools.Model.Settings;
using AzureDevOpsTools.Service;

namespace AzureDevOpsTools.Presentation.Services
{
    public interface IApplicationContextService : IService
    {
        ApplicationSettings ApplicationSettings { get; }

        UserPreferences UserPreferences { get; }

        Task Save();
    }
}
