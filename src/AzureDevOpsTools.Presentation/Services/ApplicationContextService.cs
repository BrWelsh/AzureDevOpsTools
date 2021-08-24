//-----------------------------------------------------------------------
// <copyright file="ApplicationContextService.cs" company="Brian Welsh, welshnson.com">
//     Copyright (c) Brian Welsh, welshnson.com. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System.Text.Json;

using AzureDevOpsTools.Model.Settings;
using AzureDevOpsTools.Presentation.Utility;
using AzureDevOpsTools.Service;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AzureDevOpsTools.Presentation.Services
{
#pragma warning disable IDE0032 // Use auto property
#pragma warning disable RCS1085 // Use auto-implemented property.

    public class ApplicationContextService : ServiceBase, IApplicationContextService
    {
        private readonly AppSettings appSettings;
        private readonly UserPreferences userPreferences;

        public ApplicationContextService(
                IOptions<AppSettings> appSettings,
                IOptions<UserPreferences> userPrefs,
                ILogger<ApplicationContextService> logger)
            : base(logger)
        {
            this.appSettings = appSettings?.Value;
            userPreferences = userPrefs?.Value;
        }

        public AppSettings AppSettings => appSettings;

        public UserPreferences UserPreferences => userPreferences;

        public void Save()
        {
            UserPreferencesRoot root = new UserPreferencesRoot
            {
                UserPreferences = userPreferences,
            };
            string json = JsonSerializer.Serialize(root);
            System.IO.File.WriteAllText(ApplicationInfo.UserProfilePath, json);
        }

#pragma warning restore RCS1085 // Use auto-implemented property.
#pragma warning restore IDE0032 // Use auto property
    }
}
