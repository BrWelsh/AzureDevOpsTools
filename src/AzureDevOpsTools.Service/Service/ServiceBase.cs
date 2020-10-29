﻿using Microsoft.Extensions.Logging;

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
