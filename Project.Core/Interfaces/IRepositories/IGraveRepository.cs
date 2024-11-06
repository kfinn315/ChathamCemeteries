using Project.Core.Entities.General;

namespace Project.Core.Interfaces.IRepositories;

public interface IGraveRepository : IBaseRepository<Grave>
{
    Task<IEnumerable<Grave>> GetCemetery(int cemeteryId, CancellationToken cancellationToken);
}
