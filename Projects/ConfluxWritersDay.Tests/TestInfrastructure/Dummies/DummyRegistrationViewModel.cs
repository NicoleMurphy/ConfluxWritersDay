using System;
using System.Linq;
using ConfluxWritersDay.Web.ViewModels.Home;
using FakeItEasy;
using OpenMagic;

namespace ConfluxWritersDay.Tests.TestInfrastructure.Dummies
{
    public class DummyRegistrationViewModel : DummyDefinition<RegistrationViewModel>
    {
        private readonly static Lazy<RegistrationViewModel[]> DummyViewModels = new Lazy<RegistrationViewModel[]>(() => DummyRegistrationViewModels.ReadDummyViewModels().ToArray());

        protected override RegistrationViewModel CreateDummy()
        {
            return DummyViewModels.Value[RandomNumber.NextInt(0, DummyViewModels.Value.Length)];
        }
    }
}
