//-----------------------------------------------------------------------
// <copyright file="UserPreferencesTests.cs" company="Brian Welsh, welshnson.com">
//     Copyright (c) Brian Welsh, welshnson.com. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
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
            this.preferencesRoot = new UserPreferencesRoot();
        }

        [TestMethod]
        public void CanCreateEmptyPoco()
        {
            Assert.IsNotNull(this.preferencesRoot);

            // Assert.AreEqual(null, preferencesRoot.UserPreferences);
            // Assert.AreEqual(null,preferencesRoot.UserPreferences.PersonalAccessToken);
            // Assert.AreEqual(preferencesRoot.UserPreferences.DefaultOrganization, string.Empty);
            // Assert.AreEqual(preferencesRoot.UserPreferences.PersonalAccessToken.Name, string.Empty);
            // Assert.AreEqual(preferencesRoot.UserPreferences.PersonalAccessToken.Value, string.Empty);
        }
    }
}
