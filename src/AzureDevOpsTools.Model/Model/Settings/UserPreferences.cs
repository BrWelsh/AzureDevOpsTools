//-----------------------------------------------------------------------
// <copyright file="UserPreferences.cs" company="Brian Welsh, welshnson.com">
//     Copyright (c) Brian Welsh, welshnson.com. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using Newtonsoft.Json;

namespace AzureDevOpsTools.Model.Settings
{
#pragma warning disable SA1402 // File may only contain a single type

    public class UserPreferences
    {
        public UserPreferences()
        {
            this.DefaultOrganization = string.Empty;
        }

        [JsonProperty("personalAccessToken")]
        public PersonalAccessToken PersonalAccessToken { get; set; }

        [JsonProperty("defaultOrganization")]
        public string DefaultOrganization { get; set; }

        [JsonProperty("windowPlacement")]
        public string WindowPlacement { get; set; }
    }

    public class PersonalAccessToken
    {
        public PersonalAccessToken()
        {
            this.Name = string.Empty;
            this.Value = string.Empty;
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class UserPreferencesRoot
    {
        [JsonProperty("userPreferences")]
        public UserPreferences UserPreferences { get; set; }
    }
#pragma warning restore SA1402 // File may only contain a single type
}
