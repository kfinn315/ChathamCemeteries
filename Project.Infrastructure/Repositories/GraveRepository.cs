using Project.Infrastructure.Data;
using Project.Core.Interfaces.IRepositories;
using System.Linq.Expressions;
using Project.Core.Entities.General;

namespace Project.Infrastructure.Repositories;

public class GraveRepository : BaseRepository<Grave>, IGraveRepository
{

    public GraveRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

}