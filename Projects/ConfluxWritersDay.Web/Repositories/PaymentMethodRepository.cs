using System.Collections.Generic;

namespace ConfluxWritersDay.Web.Repositories
{
    public class PaymentMethodRepository : ConfluxWritersDay.Web.Repositories.IPaymentMethodRepository
    {
        private static KeyValuePair<string, string>[] PaymentMethods = 
        { 
            new KeyValuePair<string, string>("Cheque", "Cheque"), 
            new KeyValuePair<string, string>("PayPal", "PayPal"),
            new KeyValuePair<string, string>("DirectDeposit", "Direct Deposit")
        };

        public PaymentMethodRepository()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<KeyValuePair<string, string>> GetAll()
        {
            return PaymentMethods;
        }
    }
}
