using OpenQA.Selenium.Support.UI;

namespace ConfluxWritersDay.Specifications.Website.WebElements
{
    public class SelectBox : WebElement
    {
        public SelectBox(string id)
            : base(id)
        {
        }

        public void SelectByDisplayText(string displayText)
        {
            new SelectElement(Element).SelectByText(displayText);
        }
    }
}