using ConfluxWritersDay.Infrastructure;
using ConfluxWritersDay.Models;
using NullGuard;

namespace ConfluxWritersDay.Web.ViewModels.Home
{
    [NullGuard(ValidationFlags.Methods | ValidationFlags.Arguments | ValidationFlags.OutValues | ValidationFlags.ReturnValues)]
    public class RegistrationViewModel : Registration
    {
        public RegistrationViewModel()
        {
        }

        public RegistrationViewModel(ISettings settings)
            : this()
        {
            IsDeveloperMachine = settings.IsDeveloperMachine;
        }

        public bool IsDeveloperMachine { get; set; }

        public Registration ToModel()
        {
            return new Registration
            {
                Address = Address,
                DietaryRequirements = DietaryRequirements,
                EmailAddress = EmailAddress,
                FirstName = FirstName,
                LastName = LastName,
                MembershipOrganisation = MembershipOrganisation,
                PaymentMethod = PaymentMethod,
                SpecialRequirements = SpecialRequirements,
                TelephoneNumber = TelephoneNumber
            };
        }
    }
}
