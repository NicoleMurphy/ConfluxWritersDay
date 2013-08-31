using System.Collections.Generic;

namespace ConfluxWritersDay.Web.Repositories
{
    interface IPaymentMethodRepository
    {
        IEnumerable<KeyValuePair<string, string>> GetAll();
    }
}
