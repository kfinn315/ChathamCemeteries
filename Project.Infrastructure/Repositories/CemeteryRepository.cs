using Project.Infrastructure.Data;
using Project.Core.Interfaces.IRepositories;
using Project.Core.Entities.General;

namespace Project.Infrastructure.Repositories;

public class CemeteryRepository : BaseRepository<Cemetery>, ICemeteryRepository
{
    public CemeteryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<Cemetery> Get()
    {
        return _dbContext.Set<Cemetery>().AsQueryable();
    }
}