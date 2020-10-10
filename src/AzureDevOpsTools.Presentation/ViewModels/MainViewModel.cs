using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

using AzureDevOpsTools.Framework.ViewModels;
using AzureDevOpsTools.Presentation.Services;
using AzureDevOpsTools.Presentation.Utility;
using AzureDevOpsTools.Presentation.Views.Dialogs;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using ReactiveUI;

namespace AzureDevOpsTools.Presentation.ViewModels
{
    internal class MainViewModel : ViewModelBase, IMainViewModel
    {
#pragma warning disable IDE0052 // Remove unread private members

        private readonly IApplicationContextService applicationContextService;
        private readonly IHost host;

        public MainViewModel(
                IHost host,
                IApplicationContextService applicationContextService,
                ILogger<MainViewModel> logger)
            : base(logger)
        {
            this.host = host;
            Logger.LogDebug("Constructing");
            this.applicationContextService = applicationContextService;

            AboutDialogCommand = ReactiveCommand.CreateFromTask(ShowAboutDialogExecute);
        }

        private Task ShowAboutDialogExecute()
        {
            AboutDialog dlg = host.Services.GetRequiredService<AboutDialog>();
            dlg.Owner = Application.Current.MainWindow;
            dlg.DataContext = host.Services.GetRequiredService<IAboutApplicaitonViewModel>();
            dlg.ShowDialog();

            return Task.CompletedTask;
        }

        public ICommand AboutDialogCommand { get; }

        public string Title => ApplicationInfo.ProductName;

        protected override Task DoInitializeAsync(object parameter)
        {
            Logger.LogInformation("Initializing");
            // return base.DoInitializeAsync(parameter);
            IsReady = true;
            IsBusy = false;
            return Task.CompletedTask;
        }

#pragma warning restore IDE0052
    }
}
