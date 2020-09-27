using System.IO;
using System.Threading.Tasks;
using AzureDevOpsTools.Model.Settings;
using AzureDevOpsTools.Presentation.Utility;
using AzureDevOpsTools.Service;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace AzureDevOpsTools.Presentation.Services
{
    public class ApplicationContextService : ServiceBase, IApplicationContextService
    {
        private readonly ApplicationSettings applicationSettings;
        private readonly UserPreferencesRoot userPreferences;

        public ApplicationContextService(
                IOptions<ApplicationSettings> appSettings,
                IOptions<UserPreferencesRoot> userPrefs,
                ILogger<ApplicationContextService> logger)
            : base(logger)
        {
            applicationSettings = appSettings.Value;
            userPreferences = userPrefs.Value;

            userPreferences.UserPreferences.DefaultOrganization = "foobar";
        }

        public ApplicationSettings ApplicationSettings => applicationSettings;

        public UserPreferences UserPreferences => userPreferences.UserPreferences;

        public Task Save()
        {
            string json = JsonConvert.SerializeObject(userPreferences);
            System.IO.File.WriteAllText(Path.Combine(ApplicationInfo.UserProfilePath, "userPreferences.json"), json);

            return Task.CompletedTask;


        }
    }
}
