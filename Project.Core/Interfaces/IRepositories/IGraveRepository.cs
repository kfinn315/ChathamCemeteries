using Project.Core.Entities.General;

namespace Project.Core.Interfaces.IRepositories;

public interface IGraveRepository : IBaseRepository<Grave>
{
    IQueryable<Grave> Get();
}
