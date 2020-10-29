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
            this.host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.Configure<ApplicationSettings>(context.Configuration.GetSection(nameof(ApplicationSettings)));
                    services.Configure<UserPreferences>(context.Configuration.GetSection(nameof(UserPreferences)));
                    services.AddSingleton<IApplicationContextService, ApplicationContextService>();
                })
                .ConfigureLogging((_, configLogging) =>
                {
                    configLogging.AddConsole();
                    configLogging.AddDebug();
                })
                .ConfigureAppConfiguration((_, appConfig) =>
                {
                    string path = Path.GetDirectoryName(Assembly.GetAssembly(typeof(ApplicationContextTest)).Location);

                    appConfig.SetBasePath(path);
                    appConfig.AddJsonFile("appSettings.ApplicationContextTest.json", optional: false);
                    appConfig.AddJsonFile("userPreferences.ApplicationContextTest.json", optional: false);
                    appConfig.AddEnvironmentVariables();
                    appConfig.AddCommandLine(Environment.GetCommandLineArgs());
                })
                .ConfigureHostConfiguration((builder) => builder.AddCommandLine(Environment.GetCommandLineArgs()))
                .Build();

            this.applicationContextService = this.host.Services.GetRequiredService<IApplicationContextService>();
        }

        [TestMethod]
        public void HostBuilderCreationTest()
        {
            Assert.IsNotNull(this.host);
        }

        [TestMethod]
        public void ValidateApplicationContextServiceTest()
        {
            Assert.IsNotNull(this.applicationContextService);
        }

        [TestMethod]
        public void ValidateLoggerTest()
        {
            Assert.IsNotNull(this.applicationContextService.Logger);
        }

        [TestMethod]
        public void ValidateApplicationSettingsTest()
        {
            Assert.IsNotNull(this.applicationContextService.ApplicationSettings);
        }

        [TestMethod]
        public void ValidateUserPreferencesTest()
        {
            Assert.IsNotNull(this.applicationContextService.UserPreferences);
            Assert.IsNotNull(this.applicationContextService.UserPreferences);
            Assert.IsNotNull(this.applicationContextService.UserPreferences.DefaultOrganization);
            Assert.AreNotEqual(string.Empty, this.applicationContextService.UserPreferences.DefaultOrganization);
            Assert.IsNotNull(this.applicationContextService.UserPreferences.PersonalAccessToken);
            Assert.AreNotEqual(string.Empty, this.applicationContextService.UserPreferences.PersonalAccessToken.Name);
            Assert.AreNotEqual(string.Empty, this.applicationContextService.UserPreferences.PersonalAccessToken.Value);
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            using (this.host)
            {
                this.host.StopAsync().Wait();
            }
        }
    }
}
