using System.ComponentModel.DataAnnotations;
using ConfluxWritersDay.Web.Models;
using DataAnnotationsExtensions;
using NullGuard;

namespace ConfluxWritersDay.Web.ViewModels.Home
{
    [NullGuard(ValidationFlags.Methods | ValidationFlags.Arguments | ValidationFlags.OutValues | ValidationFlags.ReturnValues)]
    public class RegistrationViewModel
    {
        public RegistrationViewModel()
        { }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }

        [Required, Email]
        public string EmailAddress { get; set; }

        public string TelephoneNumber { get; set; }

        [Required, MembershipOrganisation]
        public string MembershipOrganisation { get; set; }

        [DataType(DataType.MultilineText)]
        public string DietaryRequirements { get; set; }

        [DataType(DataType.MultilineText)]
        public string SpecialRequirements { get; set; }

        [Required, PaymentMethod]
        public string PaymentMethod { get; set; }
    }
}
