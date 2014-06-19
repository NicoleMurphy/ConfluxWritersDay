using System;
using System.ComponentModel.DataAnnotations;
using ConfluxWritersDay.DataAnnotations;
using DataAnnotationsExtensions;
using NullGuard;

namespace ConfluxWritersDay.Models
{
    [NullGuard(ValidationFlags.Methods | ValidationFlags.Arguments | ValidationFlags.OutValues | ValidationFlags.ReturnValues)]
    public class Registration
    {
        public Registration()
        {
            Id = Guid.NewGuid();
        }

        [Required]
        public Guid Id { get; private set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required, Email]
        public string EmailAddress { get; set; }

        [DataType(DataType.PhoneNumber)]
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