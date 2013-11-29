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
    }
}
