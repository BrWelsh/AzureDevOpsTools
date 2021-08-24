//-----------------------------------------------------------------------
// <copyright file="ApplicationSettingsTests.cs" company="Brian Welsh, welshnson.com">
//     Copyright (c) Brian Welsh, welshnson.com. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using AzureDevOpsTools.Model.Settings;
using AzureDevOpsTools.UnitTest.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AzureDevOpsTools.Model.Tests
{
    [TestClass]
    public class AppSettingsTests : UnitTestBase<AppSettingsTests>
    {
        private AppSettings appSettings;

        [TestInitialize]
        public override void Initialize()
        {
            appSettings = new AppSettings();
        }

        [TestMethod]
        public void CanCreateEmptyPoco()
        {
            Assert.AreNotEqual(null, appSettings);
        }
    }
}
