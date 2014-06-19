namespace ConfluxWritersDay.Specifications.Website.WebElements
{
    public class TextBox : WebElement
    {
        public TextBox(string id)
            : base(id)
        {
        }

        public void Type(string value)
        {
            Element.SendKeys(value);
            Typed = value;
        }

        public string Typed { get; private set; }
    }
}
