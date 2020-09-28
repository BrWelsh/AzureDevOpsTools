using System.Threading.Tasks;
using AzureDevOpsTools.Model.Settings;
using AzureDevOpsTools.Service;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

#pragma warning disable IDE0032 // Use auto property
namespace AzureDevOpsTools.Presentation.Services
{
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

        public Task Save()
        {
            return Task.CompletedTask;
        }
    }
}
#pragma warning restore IDE0032 // Use auto property
