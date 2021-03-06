using System;
using System.Globalization;
using System.IO;
using System.Runtime;
using System.Windows;
using System.Windows.Threading;

using AzureDevOpsTools.Presentation.Extensions;
using AzureDevOpsTools.Presentation.Internal;
using AzureDevOpsTools.Presentation.Models.Settings;
using AzureDevOpsTools.Presentation.Services;
using AzureDevOpsTools.Presentation.Utility;
using AzureDevOpsTools.Presentation.ViewModels;
using AzureDevOpsTools.Presentation.Views;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

/**********************************
 * Useful references: 
 *  https://andrewlock.net/avoiding-startup-service-injection-in-asp-net-core-3/
 *  https://github.com/Squirrel/Squirrel.Windows
 *  https://marcominerva.wordpress.com/2019/03/06/using-net-core-3-0-dependency-injection-and-service-provider-with-wpf/
 *  https://json2csharp.com/
***********************************/

namespace AzureDevOpsTools.Presentation
{
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost host;

        public App()
        {
            string profileRoot = Path.Combine(ApplicationInfo.AppDataPath, "ProfileOptimization");
            Directory.CreateDirectory(profileRoot);
            ProfileOptimization.SetProfileRoot(profileRoot);
            ProfileOptimization.StartProfile("Startup.profile");

            Directory.CreateDirectory(ApplicationInfo.UserProfilePath);

            host = ConfigureHost();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            SplashScreen splashScreen
                = new SplashScreen(ApplicationConstants.SplashScreenImageResourcePath);
            splashScreen.Show();

#if (!DEBUG)
            DispatcherUnhandledException += AppDispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += AppDomainUnhandledException;
#endif

            MainWindow = host.Services.GetRequiredService<MainWindow>();
            IMainViewModel vm = host.Services.GetRequiredService<IMainViewModel>();

            await vm.InitializeAsync(null);

            MainWindow.DataContext = vm;

            MainWindow.Show();


            base.OnStartup(e);

            splashScreen.Close();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await host.Services.GetService<IApplicationContextService>().Save();

            using (host)
            {
                await host.StopAsync();
            }
            base.OnExit(e);
        }


        private IHost ConfigureHost()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    ConfigureServices(context.Configuration, services);
                })
                .ConfigureLogging((context, configLogging) =>
                {
                    configLogging.AddConsole();
                    configLogging.AddDebug();
                })
                .ConfigureAppConfiguration((context, appConfig) =>
                {
                    appConfig.SetBasePath(ApplicationInfo.UserProfilePath);
                    appConfig.AddJsonFile(Path.Combine(ApplicationInfo.ApplicationPath, "appSettings.json"), optional: false);
                    appConfig.AddJsonFile(Path.Combine(ApplicationInfo.ApplicationPath, $"appSettings.{ context.HostingEnvironment.EnvironmentName}.json"), optional: true);
                    appConfig.AddJsonFile("userPreferences.json", optional: true);
                    appConfig.AddEnvironmentVariables();
                    appConfig.AddCommandLine(Environment.GetCommandLineArgs());
                })
                .ConfigureHostConfiguration((builder) =>
                {
                    builder.AddCommandLine(Environment.GetCommandLineArgs());
                })
                .Build();

        }

        private static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services
                .Configure<ApplicationSettings>(configuration.GetSection(nameof(ApplicationSettings)))
                .Configure<UserPreferences>(configuration.GetSection(nameof(UserPreferences)))
                .AddSingleton<IApplicationContextService, ApplicationContextService>()
                .AddTransient<IMainViewModel, MainViewModel>()
                .AddSingleton<MainWindow>();

            //.AddSingleton<IAzdoAuthenticationService, AzdoPatAuthenticationService>()
            //.AddSingleton<IUserContextService, UserContextService>()
            //.AddSingleton<IAzureDevOpsService, AzureDevOpsService>()
            //.AddSingleton<IOctopusService, OctopusService>()
            //.AddSingleton<IView, TabbedView>()
            //.AddScoped<IManagePreferencesService, ManagePreferencesService>()
            //.AddTransient<MainViewModel>()
            //.AddTransient<UserPreferencesViewModel>();
        }

        private void AppDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            HandleException(e.Exception, false);
        }

        private static void AppDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException(e.ExceptionObject as Exception, e.IsTerminating);
        }

        private static void HandleException(Exception? e, bool isTerminating)
        {
            if (e == null) return;

            if (!isTerminating)
            {
                MessageBox.Show(string.Format(CultureInfo.CurrentCulture, Presentation.Properties.Resources.UnknownError, e),
                    ApplicationInfo.ProductName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
}
