using System.Collections.Generic;

namespace ConfluxWritersDay.Web.Repositories
{
    public class PaymentMethodRepository : ConfluxWritersDay.Web.Repositories.IPaymentMethodRepository
    {
        public IEnumerable<KeyValuePair<string, string>> GetAll()
        {
            return new KeyValuePair<string, string>[]             
            { 
                new KeyValuePair<string, string>("Cheque", "Cheque"), 
                new KeyValuePair<string, string>("PayPal", "PayPal"),
                new KeyValuePair<string, string>("DirectDeposit", "Direct Deposit")
            };
        }
    }
}
