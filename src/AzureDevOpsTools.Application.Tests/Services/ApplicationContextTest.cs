using System;
using System.IO;
using System.Reflection;
using AzureDevOpsTools.Model.Settings;
using AzureDevOpsTools.Presentation.Services;
using AzureDevOpsTools.UnitTest.Framework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AzureDevOpsTools.Application.Tests.Services
{
    [TestClass]
    public class ApplicationContextTest : UnitTestBase<ApplicationContextTest>
    {
        private IHost host;
        private IApplicationContextService applicationContextService;

        [TestInitialize]
        public override void Initialize()
        {
            host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.Configure<ApplicationSettings>(context.Configuration.GetSection(nameof(ApplicationSettings)));
                    services.Configure<UserPreferences>(context.Configuration.GetSection(nameof(UserPreferences)));
                    services.AddSingleton<IApplicationContextService, ApplicationContextService>();
                })
                .ConfigureLogging((context, configLogging) =>
                {
                    configLogging.AddConsole();
                    configLogging.AddDebug();
                })
                .ConfigureAppConfiguration((context, appConfig) =>
                {
                    string path = Path.GetDirectoryName(Assembly.GetAssembly(typeof(ApplicationContextTest)).Location);

                    appConfig.SetBasePath(path);
                    appConfig.AddJsonFile("appSettings.ApplicationContextTest.json", optional: false);
                    appConfig.AddJsonFile("userPreferences.ApplicationContextTest.json", optional: false);
                    appConfig.AddEnvironmentVariables();
                    appConfig.AddCommandLine(Environment.GetCommandLineArgs());
                })
                .ConfigureHostConfiguration((builder) =>
                {
                    builder.AddCommandLine(Environment.GetCommandLineArgs());
                })
                .Build();

            applicationContextService = host.Services.GetRequiredService<IApplicationContextService>();

        }

        [TestMethod]
        public void HostBuilderCreationTest()
        {
            Assert.IsNotNull(host);
        }

        [TestMethod]
        public void ValidateApplicationContextServiceTest()
        {
            Assert.IsNotNull(applicationContextService);
        }

        [TestMethod]
        public void ValidateLoggerTest()
        {
            Assert.IsNotNull(applicationContextService.Logger);
        }

        [TestMethod]
        public void ValidateApplicationSettingsTest()
        {
            Assert.IsNotNull(applicationContextService.ApplicationSettings);
        }

        [TestMethod]
        public void ValidateUserPreferencesTest()
        {
            Assert.IsNotNull(applicationContextService.UserPreferences);
            Assert.IsNotNull(applicationContextService.UserPreferences);
            Assert.IsNotNull(applicationContextService.UserPreferences.DefaultOrganization);
            Assert.AreNotEqual(string.Empty, applicationContextService.UserPreferences.DefaultOrganization);
            Assert.IsNotNull(applicationContextService.UserPreferences.PersonalAccessToken);
            Assert.AreNotEqual(string.Empty, applicationContextService.UserPreferences.PersonalAccessToken.Name);
            Assert.AreNotEqual(string.Empty, applicationContextService.UserPreferences.PersonalAccessToken.Value);


        }


        [TestCleanup]
        public override void TestCleanup()
        {
            using (host)
            {
                host.StopAsync().Wait();
            }
        }
    }
}
