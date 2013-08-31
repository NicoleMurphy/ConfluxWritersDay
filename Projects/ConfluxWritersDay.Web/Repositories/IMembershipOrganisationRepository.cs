using System.Collections.Generic;

namespace ConfluxWritersDay.Web.Repositories
{
    interface IMembershipOrganisationRepository
    {
        IEnumerable<KeyValuePair<string, string>> GetAll();
    }
}
