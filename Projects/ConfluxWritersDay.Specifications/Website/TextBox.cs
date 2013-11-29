using OpenQA.Selenium;

namespace ConfluxWritersDay.Specifications.Website
{
    public class TextBox
    {
        private readonly IWebElement WebElement;

        public TextBox(string id)
        {
            WebElement = Browser.FindElement(id);
        }

        public void SetValue(string value)
        {
            WebElement.Clear();
            WebElement.SendKeys(value);
        }
    }
}
