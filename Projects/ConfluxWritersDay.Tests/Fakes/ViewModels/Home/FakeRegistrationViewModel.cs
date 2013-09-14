using ConfluxWritersDay.Web.Infrastructure;
using ConfluxWritersDay.Web.Repositories;
using ConfluxWritersDay.Web.ViewModels.Home;

namespace ConfluxWritersDay.Tests.Fakes.ViewModels.Home
{
    public class FakeRegistrationViewModel : RegistrationViewModel
    {
        public FakeRegistrationViewModel() : base(IoC.Resolve<IMembershipOrganisationRepository>(), IoC.Resolve<IPaymentMethodRepository>())
        {
        }
    }
}
