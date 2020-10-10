using System;
using System.Collections.Generic;
using System.Text;

namespace AzureDevOpsTools.Model
{
    public class Credit
    {
        public Credit(string name, Uri uri)
        {
            Name = name;
            Uri = uri;
        }

        public Credit(string name, string uri)
            : this(name, new Uri(uri, UriKind.Absolute))
        {
        }

        public Uri Uri { get; set; }

        public string Name { get; set; }
    }
}
