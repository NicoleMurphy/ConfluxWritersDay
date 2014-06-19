using System.Collections.Generic;

namespace ConfluxWritersDay.Repositories
{
    public interface IMembershipOrganisationRepository
    {
        IEnumerable<KeyValuePair<string, string>> GetAll();
    }
}
