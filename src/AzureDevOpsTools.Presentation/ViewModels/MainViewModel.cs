//-----------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="Brian Welsh, welshnson.com">
//     Copyright (c) Brian Welsh, welshnson.com. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

using AzureDevOpsTools.Framework.ViewModels;
using AzureDevOpsTools.Presentation.Services;
using AzureDevOpsTools.Presentation.Utility;
using AzureDevOpsTools.Presentation.Views.Dialogs;

using MahApps.Metro.Controls.Dialogs;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using ReactiveUI;

namespace AzureDevOpsTools.Presentation.ViewModels
{
    internal class MainViewModel : ViewModelBase, IMainViewModel
    {
#pragma warning disable IDE0052 // Remove unread private members

        private readonly IHost host;
        private readonly IApplicationContextService applicationContextService;
        private readonly IDialogCoordinator dialogCoordinator;

        public MainViewModel(
                IHost host,
                IApplicationContextService applicationContextService,
                IDialogCoordinator dialogCoordinator,
                ILogger<MainViewModel> logger)
            : base(logger)
        {
            this.Logger.LogDebug("Constructing");
            this.host = host;
            this.applicationContextService = applicationContextService;
            this.dialogCoordinator = dialogCoordinator;

            this.AboutDialogCommand = ReactiveCommand.CreateFromTask(this.ShowAboutDialogExecute);
        }

        private Task ShowAboutDialogExecute()
        {
            AboutDialog dlg = this.host.Services.GetRequiredService<AboutDialog>();
            dlg.Owner = Application.Current.MainWindow;
            dlg.DataContext = this.host.Services.GetRequiredService<IAboutApplicaitonViewModel>();
            dlg.ShowDialog();

            return Task.CompletedTask;
        }

        public ICommand AboutDialogCommand { get; }

        public string Title => ApplicationInfo.ProductName;

        protected override Task DoInitializeAsync(object parameter)
        {
            this.Logger.LogInformation("Initializing");

            // return base.DoInitializeAsync(parameter);
            this.IsReady = true;
            this.IsBusy = false;
            return Task.CompletedTask;
        }

#pragma warning restore IDE0052
    }
}
