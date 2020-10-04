using System;
using System.IO;
using System.Reflection;
using AzureDevOpsTools.Presentation.Internal;

namespace AzureDevOpsTools.Presentation.Utility
{
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    /// <summary>This class provides information about the running application.</summary>
    public static class ApplicationInfo
    {
        private static readonly Lazy<string> productName = new Lazy<string>(GetProductName);
        private static readonly Lazy<string> version = new Lazy<string>(GetVersion);
        private static readonly Lazy<string> company = new Lazy<string>(GetCompany);
        private static readonly Lazy<string> copyright = new Lazy<string>(GetCopyright);
        private static readonly Lazy<string> applicationPath = new Lazy<string>(GetApplicationPath);
        private static readonly Lazy<string> appDataPath = new Lazy<string>(GetAppDataPath);
        private static readonly Lazy<string> userProfilePath = new Lazy<string>(GetUserProfilePath);

        /// <summary>Gets the product name of the application.</summary>
        public static string ProductName => productName.Value;

        /// <summary>Gets the version number of the application.</summary>
        public static string Version => version.Value;

        /// <summary>Gets the company of the application.</summary>
        public static string Company => company.Value;

        /// <summary>Gets the copyright information of the application.</summary>
        public static string Copyright => copyright.Value;

        /// <summary>Gets the path for the executable file that started the application, not including the executable name.</summary>
        public static string ApplicationPath => applicationPath.Value;

        public static string AppDataPath => appDataPath.Value;

        public static string UserProfilePath => userProfilePath.Value;

        private static string GetProductName()
        {
            Assembly entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly != null)
            {
                AssemblyProductAttribute attribute = (AssemblyProductAttribute?)Attribute.GetCustomAttribute(entryAssembly, typeof(AssemblyProductAttribute));
                return attribute?.Product ?? string.Empty;
            }
            return string.Empty;
        }

        private static string GetVersion()
        {
            return Assembly.GetEntryAssembly()?.GetName().Version?.ToString() ?? string.Empty;
        }

        private static string GetCompany()
        {
            Assembly entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly != null)
            {
                AssemblyCompanyAttribute attribute = (AssemblyCompanyAttribute?)Attribute.GetCustomAttribute(entryAssembly, typeof(AssemblyCompanyAttribute));
                return attribute?.Company ?? string.Empty;
            }
            return string.Empty;
        }

        private static string GetCopyright()
        {
            Assembly entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly != null)
            {
                AssemblyCopyrightAttribute attribute = (AssemblyCopyrightAttribute?)Attribute.GetCustomAttribute(entryAssembly, typeof(AssemblyCopyrightAttribute));
                return attribute?.Copyright ?? string.Empty;
            }
            return string.Empty;
        }

        private static string GetApplicationPath()
        {
            Assembly entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly != null)
            {
                return Path.GetDirectoryName(entryAssembly.Location) ?? string.Empty;
            }
            return string.Empty;
        }

        private static string GetUserProfilePath()
        {
            return Path.Combine(ApplicationInfo.ApplicationPath, ApplicationConstants.UserPreferencesFileName);
        }

        private static string GetAppDataPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ApplicationInfo.ProductName);
        }


    }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
}
