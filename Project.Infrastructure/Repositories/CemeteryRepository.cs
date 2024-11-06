using Project.Infrastructure.Data;
using Project.Core.Interfaces.IRepositories;
using Project.Core.Entities.General;
using Microsoft.EntityFrameworkCore;

namespace Project.Infrastructure.Repositories;

public class CemeteryRepository : BaseRepository<Cemetery>, ICemeteryRepository
{
    public CemeteryRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    public async Task<Cemetery> GetWithGraves(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.Cemeteries.Include(x => x.Graves).FirstAsync(x => x.Id == id, cancellationToken);
    }
}
