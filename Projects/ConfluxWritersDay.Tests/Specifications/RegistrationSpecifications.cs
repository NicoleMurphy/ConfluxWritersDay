using System;
using System.Linq.Expressions;
using ConfluxWritersDay.Tests.TestInfrastructure;
using ConfluxWritersDay.Tests.TestInfrastructure.Seleno;
using ConfluxWritersDay.Tests.TestInfrastructure.Seleno.PageObjects;
using ConfluxWritersDay.Web.ViewModels.Home;
using FakeItEasy;
using FluentAssertions;
using Humanizer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenMagic.DataAnnotations;
using OpenQA.Selenium;

namespace ConfluxWritersDay.Tests.Specifications
{
    [TestClass]
    public class RegistrationSpecifications : BaseBddFeature
    {
        private RegistrationPage Page;
        private RegistrationViewModel ViewModel;

        public RegistrationSpecifications()
            : base("Registration Page", "todo: story")
        {
            this.NewTest();
        }

        private void NewTest()
        {
            this.ViewModel = A.Dummy<RegistrationViewModel>();
        }

        [TestMethod, TestCategory("/registration")]
        public void WhenJavaScriptIsNotEnabled()
        {
            Assert.Inconclusive("todo");
        }

        [TestMethod, TestCategory("/registration")]
        public void RegistrationDetails()
        {
            Assert.Inconclusive("todo");

            var s = this.Scenario("Registration Details");

            s["Given I am on the registration page"] = p => this.NavigateToRegistrationPage();
            s["And my first name is 'Tim'"] = p => this.ViewModel.FirstName = p[0];
            s["And my last name is 'Murphy'"] = p => this.ViewModel.LastName = p[0];
            s["And my address line 1 is '32 Black Street\nUnder Belly VIC 666'"] = p => this.ViewModel.Address = p[0];
            s["And my telephone number is '(02) 6232 2304'"] = p => this.ViewModel.TelephoneNumber = p[0];
            s["And my email address is 'tim@example.com'"] = p => this.ViewModel.EmailAddress = p[0];
            s["And entered dietary requirements 'Meat'"] = p => this.ViewModel.DietaryRequirements = p[0];
            s["And entered special requirements 'Wheelchair access'"] = p => this.ViewModel.SpecialRequirements = p[0];
            s["And selected payment method of 'Cheque'"] = p => this.ViewModel.PaymentMethod = p[0];
            s["And selected membership organisation of 'Conflux9'"] = p => this.ViewModel.MembershipOrganisation = p[0];
            s["When I submit my registration"] = p => this.Page.FillForm(this.ViewModel).Submit();
            s["Then I will see thank you page"] = null;
            s["And I will receive an email"] = null;

            s.Execute();
        }

        [TestCategory("... Under Development ...")]
        [TestMethod, TestCategory("/registration")]
        public void FirstNameIsRequired()
        {
            this.RequiredField(r => r.FirstName);
        }

        [TestMethod, TestCategory("/registration")]
        public void WhenFirstNameIsBlankAndFieldIsExited()
        {
            var s = this.Scenario();

            s["Given I am on the registration page"] = null;
            s["And I have entered the first name field"] = null;
            s["And I have left first name field empty"] = null;
            s["When I exit the first name field"] = null;
            s["Then I will see warning message that first name is required"] = null;

            s.Execute();

            Assert.Inconclusive("todo: the opposite to this");
        }

        [TestMethod, TestCategory("/registration")]
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

        [TestMethod, TestCategory("/registration")]
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

        [TestMethod, TestCategory("/registration")]
        public void MembershipOrganisation()
        {
            Assert.Inconclusive("todo");

            var s = this.Scenario("Membership organisation");

            s["Given I am on the registration page"] = null;
            s["When I am a member"] = null;
            s["Then the price is '$120.00'"] = null;

            s.Execute();
        }

        [TestMethod, TestCategory("/registration")]
        public void NoMembershipOrganisation()
        {
            Assert.Inconclusive("todo");

            var s = this.Scenario("Member organisation");

            s["Given I am on the registration page"] = null;
            s["When I am not a member"] = null;
            s["Then the price is '$150.00'"] = null;

            s.Execute();
        }

        [TestMethod, TestCategory("/registration")]
        public void First30Registrations()
        {
            Assert.Inconclusive("todo");

            var s = this.Scenario("First 30 registration");

            s["Given I am on the registration page"] = null;
            s["When I am one of the first 30 registrations"] = null;
            s["Then the price is '$90.00'"] = null;

            s.Execute();
        }

        [TestMethod, TestCategory("/registration")]
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

        [TestMethod, TestCategory("/registration")]
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

        [TestMethod, TestCategory("/registration")]
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

        [TestMethod, TestCategory("/registration")]
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

        private string GetLabel(IPropertyMetadata metadata)
        {
            var name = metadata.Display.GetName();

            if (string.IsNullOrWhiteSpace(name))
            {
                name = metadata.PropertyInfo.Name.Dehumanize();
            }

            return name;
        }

        private string GetHumanFieldName(IPropertyMetadata metadata)
        {
            return this.GetLabel(metadata).ToLower();
        }

        private string GetPropertyId(IPropertyMetadata metadata)
        {
            return metadata.PropertyInfo.Name;
        }

        private IWebElement GetRequiredValidationMesssage(IPropertyMetadata metadata)
        {
            var elementId = (metadata.PropertyInfo.Name + "-required-validation-message").ToHtmlNamingConvention();
            var element = this.Page.Find.Element(By.Id(elementId));

            return element;
        }

        private void NavigateToRegistrationPage()
        {
            this.Page = Host.Instance.NavigateToInitialPage<RegistrationPage>(RegistrationPage.Url);
        }

        private void RequiredField(Expression<Func<RegistrationViewModel, object>> property)
        {
            var metadata = ClassMetadata<RegistrationViewModel>.GetProperty(property);

            this.WhenRequiredFieldIsBlankAndSubmitButtonIsClicked(metadata);
            this.WhenRequiredFieldIsNotBlankAndSubmitButtonIsClicked(metadata);
            this.WhenRequiredFieldIsNotBlankAndExited(metadata);
            this.WhenRequiredFieldIsBlankAndExited(metadata);
        }

        private void WhenRequiredFieldIsBlankAndSubmitButtonIsClicked(IPropertyMetadata metadata)
        {
            this.NewTest();

            var propertyId = this.GetPropertyId(metadata);
            var humanFieldName = this.GetHumanFieldName(metadata);
            var s = this.Scenario();

            s[string.Format("Given I am on the registration page")] = p => this.NavigateToRegistrationPage();
            s[string.Format("And I have not entered my {0}", humanFieldName)] = p => this.Page.SetElement(metadata, null);
            s[string.Format("When I submit my registration")] = p => this.Page.Submit();
            s[string.Format("Then I will see validation message that {0} is required", humanFieldName)] = p => this.GetRequiredValidationMesssage(metadata).Displayed.Should().BeTrue();

            s.Execute();
        }

        private void WhenRequiredFieldIsNotBlankAndSubmitButtonIsClicked(IPropertyMetadata metadata)
        {
            this.NewTest();

            var propertyId = this.GetPropertyId(metadata);
            var humanFieldName = this.GetHumanFieldName(metadata);
            var value = metadata.PropertyInfo.GetValue(this.ViewModel, null);
            var s = this.Scenario();

            s[string.Format("Given I am on the registration page")] = p => this.NavigateToRegistrationPage();
            s[string.Format("And I have entered my {0}", humanFieldName)] = p => this.Page.SetElement(metadata, value);
            s[string.Format("When I submit my registration")] = p => this.Page.Submit();
            s[string.Format("Then I will not see required validation message for my {0}", humanFieldName)] = p => this.GetRequiredValidationMesssage(metadata).Displayed.Should().BeFalse();

            s.Execute();
        }

        private void WhenRequiredFieldIsBlankAndExited(IPropertyMetadata metadata)
        {
            this.NewTest();

            IWebElement element = null;
            var propertyId = this.GetPropertyId(metadata);
            var humanFieldName = this.GetHumanFieldName(metadata);
            var s = this.Scenario();

            s[string.Format("Given I am on the registration page")] = p => { this.NavigateToRegistrationPage(); element = this.Page.GetElement(metadata); };
            s[string.Format("And I have not entered my {0}", humanFieldName)] = p => element.Click();
            s[string.Format("When I exit the control")] = p => element.SendKeys("\t");
            s[string.Format("Then I will see validation message that {0} is required", humanFieldName)] = p => this.GetRequiredValidationMesssage(metadata).Displayed.Should().BeTrue();

            s.Execute();
        }

        private void WhenRequiredFieldIsNotBlankAndExited(IPropertyMetadata metadata)
        {
            this.NewTest();

            IWebElement element = null;
            var propertyId = this.GetPropertyId(metadata);
            var humanFieldName = this.GetHumanFieldName(metadata);
            var value = metadata.PropertyInfo.GetValue(this.ViewModel, null);
            var s = this.Scenario();

            s[string.Format("Given I am on the registration page")] = p => { this.NavigateToRegistrationPage(); element = this.Page.GetElement(metadata); };
            s[string.Format("And I have not entered my {0}", humanFieldName)] = p => { element.Click(); element.SendKeys(value.ToString()); };
            s[string.Format("When I exit the control")] = p => element.SendKeys("\t");
            s[string.Format("Then I will see validation message that {0} is required", humanFieldName)] = p => this.GetRequiredValidationMesssage(metadata).Displayed.Should().BeFalse();

            s.Execute();
        }
    }
}
