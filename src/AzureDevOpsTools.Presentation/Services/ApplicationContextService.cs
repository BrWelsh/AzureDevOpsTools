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
        private readonly ApplicationSettings applicationSettings;
        private readonly UserPreferences userPreferences;

        public ApplicationContextService(
                IOptions<ApplicationSettings> appSettings,
                IOptions<UserPreferences> userPrefs,
                ILogger<ApplicationContextService> logger)
            : base(logger)
        {
            applicationSettings = appSettings?.Value;
            userPreferences = userPrefs?.Value;
        }

        public ApplicationSettings ApplicationSettings => applicationSettings;

        public UserPreferences UserPreferences => userPreferences;

        public void Save()
        {
            UserPreferencesRoot root = new UserPreferencesRoot
            {
                UserPreferences = userPreferences
            };
            string json = JsonSerializer.Serialize(root);
            System.IO.File.WriteAllText(ApplicationInfo.UserProfilePath, json);
        }

#pragma warning restore RCS1085 // Use auto-implemented property.
#pragma warning restore IDE0032 // Use auto property
    }
}
