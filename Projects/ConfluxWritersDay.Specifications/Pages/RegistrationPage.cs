using ConfluxWritersDay.Specifications.Website.WebElements;

namespace ConfluxWritersDay.Specifications.Pages
{
    public class RegistrationPage : Page
    {
        public readonly TextBox FirstName;
        public readonly TextBox LastName;
        public readonly MultilineTextBox Address;
        public readonly TextBox TelephoneNumber;
        public readonly EmailTextBox EmailAddress;
        public readonly MultilineTextBox DietaryRequirements;
        public readonly MultilineTextBox SpecialRequirements;
        public readonly SelectBox PaymentMethod;
        public readonly SelectBox MembershipOrganisation;

        public RegistrationPage()
        {
            InitializeWebElements("Registration-");
        }
    }
}
