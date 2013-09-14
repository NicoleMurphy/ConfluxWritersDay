using BddMagic;
using ConfluxWritersDay.Tests.Fakes.ViewModels.Home;
using ConfluxWritersDay.Tests.Seleno;
using ConfluxWritersDay.Tests.Seleno.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConfluxWritersDay.Tests.Specifications
{
    [TestClass]
    public class RegistrationSpecifications : BddFeature
    {
        private RegistrationPage Page;
        private FakeRegistrationViewModel ViewModel = new FakeRegistrationViewModel();

        public RegistrationSpecifications()
            : base("Registration Page", "todo: story")
        {
        }

        [TestMethod]
        public void RegistrationDetails()
        {
            Assert.Inconclusive("todo");

            var s = this.Scenario("Registration Details");

            s["Given I am on the registration page"] = p => this.NavigateToRegistrationPage();
            s["And my first name is 'Tim'"] = p => this.ViewModel.FirstName = p[0];
            s["And my last name is 'Murphy'"] = p => this.ViewModel.LastName = p[0];
            s["And my address line 1 is '32 Black Street'"] = p => this.ViewModel.AddressLine1 = p[0];
            s["And my suburb is 'Under'"] = p => this.ViewModel.Suburb = p[0];
            s["And my state is 'Belly'"] = p => this.ViewModel.State = p[0];
            s["And my postcode is '666'"] = p => this.ViewModel.Postcode = p[0];
            s["And my telephone number is '(02) 6232 2304'"] = p => this.ViewModel.TelephoneNumber = p[0];
            s["And my email address is 'tim@example.com'"] = p => this.ViewModel.EmailAddress = p[0];
            s["And entered dietary requirements 'Meat'"] = p => this.ViewModel.DietaryRequirements = p[0];
            s["And entered special requirements 'Wheelchair access'"] = p => this.ViewModel.SpecialRequirements = p[0];
            s["And selected payment method of 'Cheque'"] = p => this.ViewModel.PaymentMethod = p[0];
            s["And selected membership organisation of 'Conflux9'"] = p => this.ViewModel.MembershipOrganisation = p[0];
            s["When I submit my registration"] = p => this.Page.Submit(this.ViewModel);
            s["Then I will see thank you page"] = null;
            s["And I will receive an email"] = null;

            s.Execute();
        }

        [TestMethod]
        public void FirstNameIsRequired()
        {
            Assert.Inconclusive("todo");

            var s = this.Scenario("First name is required");

            s["Given I am on the registration page"] = null;
            s["And I have not entered my first name"] = null;
            s["When I submit my registration"] = null;
            s["Then I will see warning message that first name is required"] = null;

            s.Execute();
        }

        [TestMethod]
        public void LastNameIsRequired()
        {
            Assert.Inconclusive("todo");

            var s = this.Scenario("Last name is required");

            s["Given I am on the registration page"] = null;
            s["And I have not entered my email address"] = null;
            s["When I submit my registration"] = null;
            s["Then I will see warning message that email address is required"] = null;

            s.Execute();
        }

        [TestMethod]
        public void EmailAddressIsRequired()
        {
            Assert.Inconclusive("todo");

            var s = this.Scenario("Email address is required");

            s["Given I am on the registration page"] = null;
            s["And I have not entered my first name"] = null;
            s["When I submit my registration"] = null;
            s["Then I will see warning message that first name is required"] = null;

            s.Execute();
        }

        [TestMethod]
        public void MembershipOrganisation()
        {
            Assert.Inconclusive("todo");

            var s = this.Scenario("Membership organisation");

            s["Given I am on the registration page"] = null;
            s["When I am a member"] = null;
            s["Then the price is '$120.00'"] = null;

            s.Execute();
        }

        [TestMethod]
        public void NoMembershipOrganisation()
        {
            Assert.Inconclusive("todo");

            var s = this.Scenario("Member organisation");

            s["Given I am on the registration page"] = null;
            s["When I am not a member"] = null;
            s["Then the price is '$150.00'"] = null;

            s.Execute();
        }

        [TestMethod]
        public void First30Registrations()
        {
            Assert.Inconclusive("todo");

            var s = this.Scenario("First 30 registration");

            s["Given I am on the registration page"] = null;
            s["When I am one of the first 30 registrations"] = null;
            s["Then the price is '$90.00'"] = null;

            s.Execute();
        }

        [TestMethod]
        public void ThirtyFirstOrGreaterRegistration()
        {
            Assert.Inconclusive("todo");

            var s = this.Scenario("31+ registration");

            s["Given I am on the registration page"] = null;
            s["And I was 30th to start registration"] = null;
            s["And someone else typed quicker than me"] = null;
            s["When I hit submit"] = null;
            s["Then I am told I missed out"] = null;

            s.Execute();
        }

        [TestMethod]
        public void PaymentByDirectDeposit()
        {
            Assert.Inconclusive("todo");

            var s = this.Scenario("direct deposit");

            s["Given I have completed registration "] = null;
            s["And the payment method is direct deposit payment"] = null;
            s["When I am sent an email"] = null;
            s["Then I the direct deposit invoice is attached"] = null;

            s.Execute();
        }

        [TestMethod]
        public void PaymentByPayPal()
        {
            Assert.Inconclusive("todo");

            var s = this.Scenario("paypal");

            s["Given I have completed registration "] = null;
            s["And the payment method is Paypal payment"] = null;
            s["When I am sent an email"] = null;
            s["Then I the paypal invoice is attached"] = null;

            s.Execute();
        }

        [TestMethod]
        public void PaymentByCheque()
        {
            Assert.Inconclusive("todo");

            var s = this.Scenario("cheque");

            s["Given I have completed registration "] = null;
            s["And the payment method is cheque payment"] = null;
            s["When I am sent an email"] = null;
            s["Then I the cheque invoice is attached"] = null;

            s.Execute();
        }

        private void NavigateToRegistrationPage()
        {
            this.Page = Host.Instance.NavigateToInitialPage<RegistrationPage>(RegistrationPage.Url);
        }

    }
}
