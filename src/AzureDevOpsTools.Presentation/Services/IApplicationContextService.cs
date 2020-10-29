//-----------------------------------------------------------------------
// <copyright file="IApplicationContextService.cs" company="Brian Welsh, welshnson.com">
//     Copyright (c) Brian Welsh, welshnson.com. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using AzureDevOpsTools.Model.Settings;
using AzureDevOpsTools.Service;

namespace AzureDevOpsTools.Presentation.Services
{
    public interface IApplicationContextService : IService
    {
        ApplicationSettings ApplicationSettings { get; }

        UserPreferences UserPreferences { get; }

        void Save();
    }
}
