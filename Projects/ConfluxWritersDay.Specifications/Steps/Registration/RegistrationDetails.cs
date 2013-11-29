using ConfluxWritersDay.Specifications.Pages;
using ConfluxWritersDay.Specifications.Website;
using TechTalk.SpecFlow;

namespace ConfluxWritersDay.Specifications.Steps.Registration
{
    [Binding]
    public class RegistrationDetails
    {
        private string FirstName;

        [Given(@"I am on the registration page")]
        public void GivenIAmOnTheRegistrationPage()
        {
            Browser.NavigateTo("/registration");
        }
        
        [Given(@"my first name is entered")]
        public void GivenMyFirstNameIsEntered()
        {
            FirstName = "Tim";
            RegistrationPage.FirstName.SetValue(FirstName);
        }
        
        [Given(@"my last name is entered")]
        public void GivenMyLastNameIsEntered()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"my address is entered")]
        public void GivenMyAddressIsEntered()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"my phone is entered")]
        public void GivenMyPhoneIsEntered()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"my email address is entered")]
        public void GivenMyEmailAddressIsEntered()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"entered special dietary requirements")]
        public void GivenEnteredSpecialDietaryRequirements()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"selected a")]
        public void GivenSelectedA(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I submit my registration")]
        public void WhenISubmitMyRegistration()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I will see thank you page")]
        public void ThenIWillSeeThankYouPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I will receive an email")]
        public void ThenIWillReceiveAnEmail()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
