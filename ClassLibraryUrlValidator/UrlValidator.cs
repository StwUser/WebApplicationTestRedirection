using System;
using System.Net.NetworkInformation;

namespace ClassLibraryUrlValidator
{
    public static class UrlValidator
    {
        public static bool Validate(string url)
        {
            return Uri.IsWellFormedUriString(url, UriKind.Absolute);
        }
    }
}
