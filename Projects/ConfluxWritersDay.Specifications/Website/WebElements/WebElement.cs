using System;
using OpenQA.Selenium;

namespace ConfluxWritersDay.Specifications.Website.WebElements
{
    public class WebElement
    {
        private readonly Lazy<IWebElement> ElementFactory;

        public WebElement(string id)
        {
            ElementFactory = new Lazy<IWebElement>(() => Browser.FindElement(id));
        }

        public IWebElement Element { get { return ElementFactory.Value; } }
    }
}