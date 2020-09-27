using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

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
        private PersonalAccessToken accessToken = null;

        public UserPreferences()
        {
            DefaultOrganization = string.Empty;
        }

        [JsonProperty("personalAccessToken")]
        public PersonalAccessToken PersonalAccessToken
        {
            get
            {
                if (accessToken == null)
                {
                    accessToken = new PersonalAccessToken();
                }
                return accessToken;
            }
            set
            {
                accessToken = value;
            }
        }

        [JsonProperty("defaultOrganization")]
        public string DefaultOrganization { get; set; }
    }

    public class UserPreferencesRoot
    {
        private UserPreferences userPreferences = null;
        [JsonProperty("userPreferences")]
        public UserPreferences UserPreferences
        {
            get
            {
                if (userPreferences == null)
                {
                    userPreferences = new UserPreferences();
                }
                return userPreferences;
            }
            set
            {
                userPreferences = value;
            }
        }
    }
}

