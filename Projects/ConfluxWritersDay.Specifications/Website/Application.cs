using System;
using OpenMagic;

namespace ConfluxWritersDay.Specifications.Website
{
    public static class Application
    {
        private const string RootUrl = "http://localhost:12116";

        static Application()
        {
        }

        public static Uri Uri(string url)
        {
            url.MustNotBeNullOrWhiteSpace("url");
            url.Must(url.StartsWith("/"), "Value must start with /.", "url");
            url.Must(!url.EndsWith("/"), "Value must not end with /.", "url");

            return new Uri(string.Format("{0}{1}", RootUrl, url));
        }
    }
}
