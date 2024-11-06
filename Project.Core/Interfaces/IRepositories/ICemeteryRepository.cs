using Project.Core.Entities.General;

namespace Project.Core.Interfaces.IRepositories;

public interface ICemeteryRepository : IBaseRepository<Cemetery>
{
    public Task<Cemetery> GetWithGraves(int id, CancellationToken cancellationToken);
}
