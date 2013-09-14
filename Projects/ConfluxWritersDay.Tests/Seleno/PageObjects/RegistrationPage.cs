using ConfluxWritersDay.Tests.Fakes.ViewModels.Home;
using ConfluxWritersDay.Web.ViewModels.Home;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace ConfluxWritersDay.Tests.Seleno.PageObjects
{
    public class RegistrationPage : Page<FakeRegistrationViewModel>
    {
        public const string Url = "/registration";

        public void Submit(FakeRegistrationViewModel viewModel)
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
