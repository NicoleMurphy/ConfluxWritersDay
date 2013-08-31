using ConfluxWritersDay.Web.ViewModels.Home;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace ConfluxWritersDay.Tests.Seleno.PageObjects
{
    public class RegistrationPage : Page<RegistrationViewModel>
    {
        public const string Url = "/registration";

        public void Submit(RegistrationViewModel viewModel)
        {
            this.Input().Model(viewModel);
            this.SubmitButton().Click();
        }

        private IWebElement SubmitButton()
        {
            var button = this.Find().Element(By.Id("Submit"));
            
            return button;
        }
    }
}
