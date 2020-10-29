using System;
using System.Diagnostics;

namespace AzureDevOpsTools.Presentation.Utility
{
    internal static class UriHelper
    {
#pragma warning disable CA1031 // Do not catch general exception types

        static UriHelper()
        {

        }

        public static void OpenExternalLink(string link)
        {
            try
            {
                if (link != null)
                {
                    OpenExternalLink(new Uri(link));
                }
            }
            catch { } // Possible error but nothing we can do
        }

        public static void OpenExternalLink(Uri link)
        {
            try
            {
                if (IsRemoteUri(link))
                {
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = link.AbsoluteUri,
                        UseShellExecute = true
                    };
                    Process.Start(psi);
                }
            }
            catch // Possible Win32 exception: operation was canceled by the user. Nothing we can do.
            {
            }

        }

        public static bool IsRemoteUri(this Uri url)
        {
            if (url == null)
            {
                return false;
            }

            // mitigate security risk
            if (url.IsFile || url.IsLoopback || url.IsUnc)
            {
                return false;
            }

            string scheme = url.Scheme;
            return (scheme.Equals(Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase) ||
                    scheme.Equals(Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase));
        }

#pragma warning restore CA1031 // Do not catch general exception types
    }
}
