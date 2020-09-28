using AzureDevOpsTools.Model.Settings;
using AzureDevOpsTools.UnitTest.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AzureDevOpsTools.Model.Tests
{
    [TestClass]
    public class ApplicationSettingsTests : UnitTestBase<ApplicationSettingsTests>
    {
        private ApplicationSettings applicationSettings;


        [TestInitialize]
        public override void Initialize()
        {
            applicationSettings = new ApplicationSettings();
        }

        [TestMethod]
        public void CanCreateEmptyPoco()
        {
            Assert.AreNotEqual(null, applicationSettings);
        }
    }
}
