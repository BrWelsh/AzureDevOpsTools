﻿using Newtonsoft.Json;

namespace AzureDevOpsTools.Model.Settings
{
    public class PersonalAccessToken
    {
        public PersonalAccessToken()
        {
            Name = string.Empty;
            Value = string.Empty;
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class UserPreferences
    {
        public UserPreferences()
        {
            DefaultOrganization = string.Empty;
        }

        [JsonProperty("personalAccessToken")]
        public PersonalAccessToken PersonalAccessToken { get; set; }

        [JsonProperty("defaultOrganization")]
        public string DefaultOrganization { get; set; }
    }

    public class UserPreferencesRoot
    {
        [JsonProperty("userPreferences")]
        public UserPreferences UserPreferences { get; set; }
    }
}

