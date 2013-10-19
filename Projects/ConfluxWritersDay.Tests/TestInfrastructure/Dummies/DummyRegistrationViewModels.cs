using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ConfluxWritersDay.Web.Infrastructure;
using ConfluxWritersDay.Web.Repositories;
using ConfluxWritersDay.Web.ViewModels.Home;
using FakeItEasy;
using OpenMagic;

namespace ConfluxWritersDay.Tests.TestInfrastructure.Dummies
{
    class DummyRegistrationViewModels
    {
        public static IEnumerable<RegistrationViewModel> ReadDummyViewModels()
        {
            var membershipOrganisations = IoC.Resolve<IMembershipOrganisationRepository>().GetAll().ToArray();
            var paymentMethods = IoC.Resolve<IPaymentMethodRepository>().GetAll().ToArray();

            return ReadTextFile().Skip(1).Select(line => Deserialize(line, membershipOrganisations, paymentMethods));
        }

        private static RegistrationViewModel Deserialize(string line, KeyValuePair<string, string>[] membershipOrganisations, KeyValuePair<string, string>[] paymentMethods)
        {
            var fields = line.Split(new char[] { '\t' });

            return new RegistrationViewModel(membershipOrganisations, paymentMethods)
            {
                FirstName = fields[0],
                LastName = fields[1],
                AddressLine1 = fields[2],
                AddressLine2 = RandomNumber.NextInt(0, 2) == 0 ? fields[3] : null,
                Suburb = fields[4],
                State = fields[5],
                Postcode = fields[6],
                EmailAddress = fields[7],
                TelephoneNumber = fields[8],
                MembershipOrganisation = membershipOrganisations[RandomNumber.NextInt(0, membershipOrganisations.Length)].Key,
                DietaryRequirements = RandomNumber.NextInt(0, 2) == 0 ? "No chicken\r\nDiabetic" : null,
                SpecialRequirements = RandomNumber.NextInt(0, 2) == 0 ? "Wheelchair\r\nDon't mention George Costanza" : null,
                PaymentMethod = paymentMethods[RandomNumber.NextInt(0, paymentMethods.Length)].Key
            };
        }

        private static IEnumerable<string> ReadTextFile()
        {
            // DummyRegistrationViewModels.txt created by http://www.mockaroo.com/schemas/276
            return File.ReadLines("DummyRegistrationViewModels.txt");
        }
    }
}
