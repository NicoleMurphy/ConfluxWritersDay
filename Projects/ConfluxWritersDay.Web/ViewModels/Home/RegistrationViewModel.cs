using ConfluxWritersDay.Web.Models;
using NullGuard;

namespace ConfluxWritersDay.Web.ViewModels.Home
{
    [NullGuard(ValidationFlags.Methods | ValidationFlags.Arguments | ValidationFlags.OutValues | ValidationFlags.ReturnValues)]
    public class RegistrationViewModel : Registration
    { }
}
