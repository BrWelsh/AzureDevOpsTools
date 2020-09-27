using System.Threading.Tasks;

namespace AzureDevOpsTools.Presentation.Services
{
    public interface IApplicationContextService : IService
    {
        Task Save();
    }
}
