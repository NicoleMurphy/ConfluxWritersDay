using System.Collections.Generic;

namespace ConfluxWritersDay.Repositories
{
    public interface IPaymentMethodRepository
    {
        IEnumerable<KeyValuePair<string, string>> GetAll();
    }
}
