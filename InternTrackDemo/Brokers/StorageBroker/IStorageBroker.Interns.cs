using InternTrackDemo.Models.Interns;

namespace InternTrackDemo.Brokers.StorageBroker
{
    public partial interface IStorageBroker
    {
        ValueTask<Intern> InsertInternAsync(Intern intern); /*C*/
        IQueryable<Intern> SelectAllInternsAsync();/*R*/
        ValueTask<Intern> SelectInternByIdAsync(Guid internId);/*R*/
        ValueTask<Intern> UpdateInternAsync(Intern intern);/*U*/
        ValueTask<Intern> DeleteInternAsync(Intern intern);/*D*/
    }
}
