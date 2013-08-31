using System.Collections.Generic;

namespace ConfluxWritersDay.Web.Repositories
{
    public class MembershipOrganisationRepository : IMembershipOrganisationRepository
    {
        private static KeyValuePair<string, string>[] MemberOrganisations = 
        { 
            new KeyValuePair<string, string>("Conflux9", "Conflux 9 Member"), 
            new KeyValuePair<string, string>("CSFG", "CSFG Member"), 
            new KeyValuePair<string, string>("ACTWriterCentre", "ACT Writers Centre Member"), 
            new KeyValuePair<string, string>("NonMember", "Non-Member")
        };

        public MembershipOrganisationRepository()
        {
        }

        public IEnumerable<KeyValuePair<string, string>> GetAll()
        {
            return MemberOrganisations;
        }
    }
}
