using System;
using System.IO;
using ConfluxWritersDay.Infrastructure;
using ConfluxWritersDay.Infrastructure.Logging;
using ConfluxWritersDay.Models;
using Newtonsoft.Json;

namespace ConfluxWritersDay.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private static readonly ILogger Log = new Logger();

        private readonly DirectoryInfo DataFolder;

        public RegistrationRepository(ISettings settings)
        {
            DataFolder = new DirectoryInfo(Path.Combine(settings.AppDataFolder.FullName, "Registrations"));
            DataFolder.Create();
        }

        public Registration Get(string emailAddress)
        {
            throw new NotImplementedException();
        }

        public void Add(Registration model)
        {
            // todo: validate model
            var json = JsonConvert.SerializeObject(model,Formatting.Indented);
            var fileName = GetFileName(model.Id);

            File.WriteAllText(fileName, json);

            Log.Trace("Saved new registration model to {0}.", fileName);
        }

        private string GetFileName(Guid id)
        {
            var fileName = string.Format("{0:yyyy-MM-dd HH-mm-ss} {1}.json", DateTime.UtcNow, id);
            var fullFileName = Path.Combine(DataFolder.FullName, fileName);

            return fullFileName;
        }
    }
}
