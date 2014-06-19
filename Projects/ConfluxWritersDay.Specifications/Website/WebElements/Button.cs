namespace ConfluxWritersDay.Specifications.Website.WebElements
{
    public class Button : WebElement
    {
        public Button(string id)
            : base(id)
        {
        }

        public void Click()
        {
            Element.Click();
        }
    }
}
