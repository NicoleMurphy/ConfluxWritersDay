using System;
using System.Linq;
using ConfluxWritersDay.Web.ViewModels.Home;
using FakeItEasy;
using OpenMagic;

namespace ConfluxWritersDay.Tests.TestInfrastructure.Dummies
{
    public class DummyRegistrationViewModel : DummyDefinition<RegistrationViewModel>
    {
        private static RegistrationViewModel[] DummyViewModels;

        static DummyRegistrationViewModel()
        {
            DummyViewModels = DummyRegistrationViewModels.ReadDummyViewModels().ToArray();
        }

        protected override RegistrationViewModel CreateDummy()
        {
            return DummyViewModels[RandomNumber.NextInt(0, DummyViewModels.Length)];
        }
    }
}
