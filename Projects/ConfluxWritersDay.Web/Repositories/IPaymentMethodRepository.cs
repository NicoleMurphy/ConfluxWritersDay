using System.Collections.Generic;

namespace ConfluxWritersDay.Web.Repositories
{
    public interface IPaymentMethodRepository
    {
        IEnumerable<KeyValuePair<string, string>> GetAll();
    }
}
