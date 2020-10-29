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
    public class ApplicationSettingsTests : UnitTestBase<ApplicationSettingsTests>
    {
        private ApplicationSettings applicationSettings;

        [TestInitialize]
        public override void Initialize()
        {
            this.applicationSettings = new ApplicationSettings();
        }

        [TestMethod]
        public void CanCreateEmptyPoco()
        {
            Assert.AreNotEqual(null, this.applicationSettings);
        }
    }
}
