using Project.Core.Entities.General;

namespace Project.Core.Interfaces.IRepositories;

public interface ICemeteryRepository : IBaseRepository<Cemetery>
{
    IQueryable<Cemetery> Get();
}
