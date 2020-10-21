using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using AzureDevOpsTools.Model;
using AzureDevOpsTools.Presentation.Internal;

using Microsoft.VisualBasic.CompilerServices;

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
        private static readonly Lazy<string> informationalVersion = new Lazy<string>(GetInformationalVersion);
        private static readonly Lazy<string> configuration = new Lazy<string>(GetConfiguration);
        private static readonly Lazy<string> description = new Lazy<string>(GetDescription);
        private static readonly Lazy<IEnumerable<Assembly>> applicationAssemblies = new Lazy<IEnumerable<Assembly>>(GetApplicationAssemblies);
        private static readonly Lazy<Uri> repositoryUri = new Lazy<Uri>(GetRepositoryUri);
        private static readonly Lazy<Uri> projectUri = new Lazy<Uri>(GetProjectUri);
        private static readonly Lazy<Uri> projectWebsite = new Lazy<Uri>(GetProjectWebsite);
        private static readonly Lazy<IEnumerable<Credit>> credits = new Lazy<IEnumerable<Credit>>(GetCredits);

        public static IEnumerable<Credit> Credits => credits.Value;

        public static Uri ProjectWebsite => projectWebsite.Value;

        public static Uri ProjectUri => projectUri.Value;

        /// <summary>Gets the Repository Uri</summary>
        public static Uri RepositoryUri => repositoryUri.Value;

        /// <summary>Gets the product name of the application.</summary>
        public static string ProductName => productName.Value;

        /// <summary>Gets the version number of the application.</summary>
        public static string Version => version.Value;

        /// <summary>Gets the applicaiton assemblies</summary>
        public static IEnumerable<Assembly> ApplicationAssemblies => applicationAssemblies.Value;

        /// <summary>Gets teh description</summary>
        public static string Description => description.Value;

        /// <summary>Gets the company of the application.</summary>
        public static string Company => company.Value;

        /// <summary>Gets the copyright information of the application.</summary>
        public static string Copyright => copyright.Value;

        /// <summary>Gets the configuration</summary>
        public static string Configuration => configuration.Value;

        /// <summary>Gets the informational version</summary>
        public static string InformationalVersion => informationalVersion.Value;

        /// <summary>Gets the path for the executable file that started the application, not including the executable name.</summary>
        public static string ApplicationPath => applicationPath.Value;

        /// <summary>Gets the AppData path</summary>
        public static string AppDataPath => appDataPath.Value;

        /// <summary>Gets the user profile path</summary>
        public static string UserProfilePath => userProfilePath.Value;

        private static string GetConfiguration()
        {
            Assembly entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly != null)
            {
                AssemblyConfigurationAttribute attribute = (AssemblyConfigurationAttribute?)Attribute.GetCustomAttribute(entryAssembly, typeof(AssemblyConfigurationAttribute));
                return attribute?.Configuration ?? string.Empty;
            }
            return string.Empty;
        }

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

        private static string GetInformationalVersion()
        {
            Assembly entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly != null)
            {
                AssemblyInformationalVersionAttribute attribute = (AssemblyInformationalVersionAttribute?)Attribute.GetCustomAttribute(entryAssembly, typeof(AssemblyInformationalVersionAttribute));
                return attribute?.InformationalVersion ?? string.Empty;
            }
            return string.Empty;
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

        private static IEnumerable<Assembly> GetApplicationAssemblies()
        {
            Assembly entryAssembly = Assembly.GetEntryAssembly();
            string assemblyName = entryAssembly.GetName().Name;
            string[] result = Directory.GetFiles(ApplicationPath, $"{assemblyName}*.dll");
            return result.Select(name => Assembly.LoadFrom(name)).ToArray();
        }

        private static Uri GetProjectUri()
        {
            return new Uri(GetMetaDataValue(ApplicationConstants.PackageProjectUrlKey), UriKind.Absolute);
        }

        private static Uri GetRepositoryUri()
        {
            return new Uri(GetMetaDataValue(ApplicationConstants.RepositoryUrlKey), UriKind.Absolute);
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

        private static string GetDescription()
        {
            Assembly entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly != null)
            {
                AssemblyDescriptionAttribute attribute = (AssemblyDescriptionAttribute?)Attribute.GetCustomAttribute(entryAssembly, typeof(AssemblyDescriptionAttribute));
                return attribute?.Description ?? string.Empty;
            }
            return string.Empty;
        }

        private static string GetMetaDataValue(string param)
        {
            Assembly entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly != null)
            {
                AssemblyMetadataAttribute[] attribute = (AssemblyMetadataAttribute[]?)Attribute.GetCustomAttributes(entryAssembly, typeof(AssemblyMetadataAttribute));
                return Array.Find(attribute, x => x.Key.Equals(param, StringComparison.OrdinalIgnoreCase))?.Value ?? string.Empty;
            }
            return string.Empty;
        }

        private static Uri GetProjectWebsite()
        {
            string metadata = GetMetaDataValue(ApplicationConstants.ProjectWebsiteKey);
            if (string.IsNullOrEmpty(metadata))
            {
                metadata = "https://welshnson.github.io/";
            }
            return new Uri(metadata, UriKind.Absolute);
        }

        private static IEnumerable<Credit> GetCredits()
        {
            List<Credit> result = new List<Credit>
            {
                new Credit("Welsh N Son", "http://www.welshnson.com/"),
                new Credit("MahApps", "https://mahapps.com/")
            };
            return result;
        }
    }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
}
