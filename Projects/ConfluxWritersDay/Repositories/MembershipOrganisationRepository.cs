using System.Collections.Generic;

namespace ConfluxWritersDay.Repositories
{
    public class MembershipOrganisationRepository : IMembershipOrganisationRepository
    {
        public IEnumerable<KeyValuePair<string, string>> GetAll()
        {
            return new KeyValuePair<string, string>[] 
            { 
                new KeyValuePair<string, string>("Conflux9", "Conflux 9 Member"), 
                new KeyValuePair<string, string>("CSFG", "CSFG Member"), 
                new KeyValuePair<string, string>("ACTWritersCentre", "ACT Writers Centre Member"), 
            };
        }
    }
}
