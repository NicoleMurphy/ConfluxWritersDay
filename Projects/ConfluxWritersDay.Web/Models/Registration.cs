using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

namespace ConfluxWritersDay.Web.Models
{
    public class Registration
    {
        public Registration()
        {
            throw new System.NotImplementedException();
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }

        [Required, Email]
        public string EmailAddress { get; set; }

        public string TelephoneNumber { get; set; }

        [Required, MembershipOrganisation]
        public string MembershipOrganisation { get; set; }

        public string DietaryRequirements { get; set; }
        public string SpecialRequirements { get; set; }

        [Required, PaymentMethod]
        public string PaymentMethod { get; set; }
    }
}