using Microsoft.Extensions.Logging;

namespace AzureDevOpsTools.Presentation.Services
{
    public interface IService
    {
        ILogger Logger { get; }
    }
}
