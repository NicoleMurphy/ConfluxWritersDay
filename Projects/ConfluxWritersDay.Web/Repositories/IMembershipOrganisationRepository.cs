using System.Collections.Generic;

namespace ConfluxWritersDay.Web.Repositories
{
    public interface IMembershipOrganisationRepository
    {
        IEnumerable<KeyValuePair<string, string>> GetAll();
    }
}
