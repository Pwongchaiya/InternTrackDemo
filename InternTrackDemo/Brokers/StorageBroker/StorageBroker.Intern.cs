using System.Runtime.InteropServices;
using InternTrackDemo.Models.Interns;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace InternTrackDemo.Brokers.StorageBroker
{
    public partial class StorageBroker
    {
        public DbSet<Intern> Interns { get; set; }


        public async ValueTask<Intern> InsertInternAsync(Intern intern)
        {
            var broker = new StorageBroker(configuration);

            EntityEntry<Intern> internEntityEntry =
                await broker.AddAsync(intern);

            await broker.SaveChangesAsync();

            return internEntityEntry.Entity;
        }

        public IQueryable<Intern> SelectAllInternsAsync()
        {
            var broker = new StorageBroker(configuration);

            return broker.Interns;
        }

        public async ValueTask<Intern> SelectInternByIdAsync(Guid internId)
        {
            var broker = new StorageBroker(configuration);

            return await broker.Interns.FindAsync(internId);
        }

        public async ValueTask<Intern> UpdateInternAsync(Intern intern)
        {
            var broker = new StorageBroker(configuration);

            EntityEntry<Intern> internEntityEntry =
                broker.Interns.Update(intern);

            await broker.SaveChangesAsync();

            return internEntityEntry.Entity;
        }

        public async ValueTask<Intern> DeleteInternAsync(Intern intern)
        {
            var broker = new StorageBroker(configuration);

            EntityEntry<Intern> internEntityEntry =
                broker.Interns.Remove(intern);

            await broker.SaveChangesAsync();

            return internEntityEntry.Entity;
        }
    }
}
