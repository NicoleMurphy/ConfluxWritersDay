using ConfluxWritersDay.Repositories;
using ConfluxWritersDay.Specifications.Infrastructure;
using ConfluxWritersDay.Specifications.Pages;
using ConfluxWritersDay.Specifications.Website;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ConfluxWritersDay.Specifications.Steps
{
    [Binding]
    public class RegistrationSteps
    {
        private readonly RegistrationPage RegistrationPage;
        private readonly IRegistrationRepository RegistrationRepository;

        public RegistrationSteps(RegistrationPage registrationPage,IRegistrationRepository registrationRepository)
        {
            RegistrationPage = registrationPage;
            RegistrationRepository = registrationRepository;
        }

        [Given(@"I am on the registration page")]
        public void GivenIAmOnTheRegistrationPage()
        {
            Browser.NavigateTo("/registration");
        }
        
        [Given(@"my first name is entered")]
        public void GivenMyFirstNameIsEntered()
        {
            RegistrationPage.FirstName.Type("Tim");
        }

        [Given(@"my last name is entered")]
        public void GivenMyLastNameIsEntered()
        {
            RegistrationPage.LastName.Type("Murphy");
        }
        
        [Given(@"my address is entered")]
        public void GivenMyAddressIsEntered()
        {
            RegistrationPage.Address.Type("1 Fake Street\r\nDummy Suburb NSW 2000");
        }
        
        [Given(@"my telephone number is entered")]
        public void GivenMyPhoneIsEntered()
        {
            RegistrationPage.TelephoneNumber.Type("02 9999 8888");
        }
        
        [Given(@"my email address is entered")]
        public void GivenMyEmailAddressIsEntered()
        {
            RegistrationPage.EmailAddress.Type("tim@26tp.com");
        }

        [Given(@"my dietary requirements are entered")]
        public void GivenEnteredDietaryRequirements()
        {
            RegistrationPage.DietaryRequirements.Type("Dummy dietary requirements.");
        }

        [Given(@"my special requirements are entered")]
        public void GivenEnteredSpecialRequirements()
        {
            RegistrationPage.SpecialRequirements.Type("Dummy special requirements.");
        }

        [Given(@"I have selected a payment method:")]
        public void GivenSelectedAPaymentMethod(Table table)
        {
            var paymentMethods = table.CreateSet<KeyValueStringPair>();
            var paymentMethod = paymentMethods.RandomItem().Value;

            RegistrationPage.PaymentMethod.SelectByDisplayText(paymentMethod);
        }

        [Given(@"I have selected a membership organisation:")]
        public void GivenSelectedAMembershipOrganisation(Table table)
        {
            var membershipOrganisations = table.CreateSet<KeyValueStringPair>();
            var membershipOrganisation = membershipOrganisations.RandomItem().Value;

            RegistrationPage.MembershipOrganisation.SelectByDisplayText(membershipOrganisation);
        }

        [When(@"I submit my registration")]
        public void WhenISubmitMyRegistration()
        {
            RegistrationPage.Submit.Click();
        }
        
        [Then(@"I will see thank you page")]
        public void ThenIWillSeeThankYouPage()
        {
            Browser.WaitForUrl("/successful-registration").Should().BeTrue();
        }
        
        [Then(@"I will receive an email")]
        public void ThenIWillReceiveAnEmail()
        {
            //var emailAddress = RegistrationPage.EmailAddress.Typed;
            //var attendee = new AttendeeRepository().Get(emailAddress);

            //// todo: hack
            //json.Contains(string.Format("\"To\": \"{0}\"", emailAddress)).Should().BeTrue();
            //json.Contains(string.Format("\"Subject\": \"{0}\"", "Conflux Writers Day - Registration")).Should().BeTrue();
        }
    }
}
