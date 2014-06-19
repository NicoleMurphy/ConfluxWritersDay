using ConfluxWritersDay.Models;

namespace ConfluxWritersDay.Repositories
{
    public interface IRegistrationRepository
    {
        Registration Get(string emailAddress);
        void Add(Registration model);
    }
}