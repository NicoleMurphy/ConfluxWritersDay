using System.ComponentModel.DataAnnotations;

namespace ConfluxWritersDay.Web.ViewModels.Home
{
    public class RegistrationViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        public string TelephoneNumber { get; set; }

        [Required]
        public string RegistrationType { get; set; }
        public string DietaryRequirements { get; set; }
        public string SpecialRequirements { get; set; }

        [Required]
        public string PaymentMethod { get; set; }
    }
}