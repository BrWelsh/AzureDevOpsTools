using System;

namespace AzureDevOpsTools.Model
{
    public class Credit
    {
        public Credit(string name, Uri uri)
        {
            this.Name = name;
            this.Uri = uri;
        }

        public Credit(string name, string uri)
            : this(name, new Uri(uri, UriKind.Absolute))
        {
        }

        public Uri Uri { get; set; }

        public string Name { get; set; }
    }
}
