//-----------------------------------------------------------------------
// <copyright file="ApplicationSettings.cs" company="Brian Welsh, welshnson.com">
//     Copyright (c) Brian Welsh, welshnson.com. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;

using Newtonsoft.Json;

namespace AzureDevOpsTools.Model.Settings
{
#pragma warning disable SA1402 // File may only contain a single type

    public class ApplicationSettings
    {
        [JsonProperty("AzureActiveDirectoryContext")]
        public AzureActiveDirectoryContext AzureActiveDirectoryContext { get; set; }
    }

    public class AzureActiveDirectoryContext
    {
        [JsonProperty("ClientIdentifier")]
        public Guid ClientIdentifier { get; set; }

        [JsonProperty("Tenant")]
        public string Tenant { get; set; }

        [JsonProperty("Instance")]
        public string Instance { get; set; }
    }

    public class LogLevel
    {
        [JsonProperty("Default")]
        public string Default { get; set; }

        [JsonProperty("Microsoft")]
        public string Microsoft { get; set; }

        [JsonProperty("Microsoft.Hosting.Lifetime")]
        public string MicrosoftHostingLifetime { get; set; }
    }

    public class Logging
    {
        [JsonProperty("LogLevel")]
        public LogLevel LogLevel { get; set; }
    }

    public class ApplicationSettingsRoot
    {
        [JsonProperty("applicationSettings")]
        public ApplicationSettings ApplicationSettings { get; set; }

        [JsonProperty("Logging")]
        public Logging Logging { get; set; }
    }
#pragma warning restore SA1402 // File may only contain a single type
}
