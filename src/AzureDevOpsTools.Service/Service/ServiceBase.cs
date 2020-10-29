//-----------------------------------------------------------------------
// <copyright file="ServiceBase.cs" company="Brian Welsh, welshnson.com">
//     Copyright (c) Brian Welsh, welshnson.com. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using Microsoft.Extensions.Logging;

namespace AzureDevOpsTools.Service
{
    public abstract class ServiceBase : IService
    {
        private readonly ILogger logger;

        protected ServiceBase(ILogger logger)
        {
            this.logger = logger;
        }

        public virtual ILogger Logger { get => this.logger; }
    }
}
