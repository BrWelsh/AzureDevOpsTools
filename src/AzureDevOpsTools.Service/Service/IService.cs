//-----------------------------------------------------------------------
// <copyright file="IService.cs" company="Brian Welsh, welshnson.com">
//     Copyright (c) Brian Welsh, welshnson.com. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using Microsoft.Extensions.Logging;

namespace AzureDevOpsTools.Service
{
    public interface IService
    {
        ILogger Logger { get; }
    }
}
