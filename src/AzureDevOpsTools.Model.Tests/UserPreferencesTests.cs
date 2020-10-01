using AzureDevOpsTools.Model.Settings;
using AzureDevOpsTools.UnitTest.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AzureDevOpsTools.Model.Tests
{
    [TestClass]
    public class UserPreferencesTests : UnitTestBase<UserPreferencesTests>
    {
        private UserPreferencesRoot preferencesRoot;


        [TestInitialize]
        public override void Initialize()
        {
            preferencesRoot = new UserPreferencesRoot();
        }

        [TestMethod]
        public void CanCreateEmptyPoco()
        {
            Assert.IsNotNull(preferencesRoot);
            //Assert.AreEqual(null, preferencesRoot.UserPreferences);
            //Assert.AreEqual(null,preferencesRoot.UserPreferences.PersonalAccessToken);
            //Assert.AreEqual(preferencesRoot.UserPreferences.DefaultOrganization, string.Empty);
            //Assert.AreEqual(preferencesRoot.UserPreferences.PersonalAccessToken.Name, string.Empty);
            //Assert.AreEqual(preferencesRoot.UserPreferences.PersonalAccessToken.Value, string.Empty);
        }
    }
}
