using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace AzureDevOpsTools.Service
{
    public interface IService
    {
        ILogger Logger { get; }
    }
}
