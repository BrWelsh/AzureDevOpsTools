using Microsoft.Extensions.Logging;

namespace AzureDevOpsTools.Service
{
    public interface IService
    {
        ILogger Logger { get; }
    }
}
