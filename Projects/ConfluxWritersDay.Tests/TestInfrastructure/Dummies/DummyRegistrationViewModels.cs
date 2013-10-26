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
            var addressLine2 = RandomNumber.NextInt(0, 2) == 0 ? fields[3] + "\n" : null;

            return new RegistrationViewModel()
            {
                FirstName = fields[0],
                LastName = fields[1],
                Address = string.Format("{0}{1}\n{2} {3} {4}", fields[2], addressLine2, fields[4], fields[5], fields[6]),
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
            return File.ReadLines(GetDummyFullPath("DummyRegistrationViewModels.txt"));
        }

        private static string GetDummyFullPath(string dummyFileName)
        {
            var fullPath = Path.Combine(GetDummiesFolder(), dummyFileName);

            if (File.Exists(fullPath) == false)
            {
                throw new DirectoryNotFoundException(string.Format("Cannot find dummies file '{0}'.", fullPath));
            }

            return fullPath;
        }

        private static string GetDummiesFolder()
        {
            var projectFolder = GetProjectFolder();
            var dummiesFolder = Path.Combine(projectFolder, @"TestInfrastructure\Dummies\");

            if (Directory.Exists(dummiesFolder) == false)
            {
                throw new DirectoryNotFoundException(string.Format("Cannot find dummies folder '{0}'.", dummiesFolder));
            }

            return dummiesFolder;
        }

        private static string GetProjectFolder()
        {
            var folder = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Projects\ConfluxWritersDay.Tests"));

            if (Directory.Exists(folder) == false)
            {
                throw new DirectoryNotFoundException(string.Format("Cannot find project folder '{0}'.", folder));
            }

            return folder;
        }
    }
}
