using System;
using System.Diagnostics;
using System.Threading;
using OpenMagic;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace ConfluxWritersDay.Specifications.Website
{
    public static class Browser
    {
        private static readonly IWebDriver WebDriver;

        static Browser()
        {
            WebDriver = new FirefoxDriver();
        }

        public static string Url
        {
            get { return WebDriver.Url; }
        }

        public static IWebElement FindElement(string id)
        {
            return WebDriver.FindElement(By.Id(id));
        }

        public static void NavigateTo(string url)
        {
            url.MustNotBeNullOrWhiteSpace("url");
            url.Must(url.StartsWith("/"), "Value must start with /.", "url");
            url.Must(!url.EndsWith("/"), "Value must not end with /.", "url");

            WebDriver.Navigate().GoToUrl(Application.Uri(url));
        }

        public static bool WaitForUrl(string url)
        {
            return WaitForUrl(url, TimeSpan.FromSeconds(2));
        }

        public static bool WaitForUrl(string url, TimeSpan maximumWaitTime)
        {
            var browserUrl = Application.Uri(url).ToString();
            var stopWatch = Stopwatch.StartNew();

            while (!WebDriver.Url.Equals(browserUrl) && stopWatch.Elapsed < maximumWaitTime)
            {
                Thread.Sleep(1);
            }

            return WebDriver.Url.Equals(browserUrl);
        }
    }
}
