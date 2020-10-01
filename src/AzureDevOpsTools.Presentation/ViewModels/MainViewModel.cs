using System.Threading.Tasks;

using AzureDevOpsTools.Framework.ViewModels;
using AzureDevOpsTools.Presentation.Services;

using Microsoft.Extensions.Logging;

namespace AzureDevOpsTools.Presentation.ViewModels
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
#pragma warning disable IDE0052 // Remove unread private members
        private readonly IApplicationContextService applicationContextService;
#pragma warning restore IDE0052

        public MainViewModel(
                IApplicationContextService applicationContextService,
                ILogger<MainViewModel> logger)
            : base(logger)
        {
            Logger.LogDebug("Constructing");
            this.applicationContextService = applicationContextService;
        }

        protected override Task DoInitializeAsync(object parameter)
        {
            Logger.LogInformation("Initializing");
            // return base.DoInitializeAsync(parameter);
            return Task.CompletedTask;
        }
    }
}
