using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using Newtonsoft.Json;

namespace AzureDevOpsTools.Model.Settings
{
    public class PersonalAccessToken
    {
        public static readonly PersonalAccessToken Empty = new PersonalAccessToken();

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

        public static readonly UserPreferences Empty = new UserPreferences();

        private PersonalAccessToken accessToken = PersonalAccessToken.Empty;

        public UserPreferences()
        {
            DefaultOrganization = string.Empty;
        }

        [JsonProperty("personalAccessToken")]
        public PersonalAccessToken PersonalAccessToken
        {
            get
            {
                if (accessToken == PersonalAccessToken.Empty)
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
        private UserPreferences userPreferences = UserPreferences.Empty;

        [JsonProperty("userPreferences")]
        public UserPreferences UserPreferences
        {
            get
            {
                if (userPreferences == UserPreferences.Empty)
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

