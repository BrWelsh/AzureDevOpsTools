using System.Threading.Tasks;
using AzureDevOpsTools.Service;

namespace AzureDevOpsTools.Presentation.Services
{
    public interface IApplicationContextService : IService
    {
        Task Save();
    }
}
