//-----------------------------------------------------------------------
// <copyright file="ApplicationConstants.cs" company="Brian Welsh, welshnson.com">
//     Copyright (c) Brian Welsh, welshnson.com. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace AzureDevOpsTools.Presentation.Internal
{
    internal static class ApplicationConstants
    {
        public const int SplashScreenFadeTicks = 300;
        public const string SplashScreenImageResourcePath = "/Resources/Images/splashscreen.png";
        public const string UserPreferencesFileName = "userPreferences.json";

        public const string PackageProjectUrlKey = "PackageProjectUrl";
        public const string RepositoryUrlKey = "RepositoryUrl";
        public const string ProjectWebsiteKey = "ProjectWebsite";

        static ApplicationConstants()
        {
        }
    }
}
