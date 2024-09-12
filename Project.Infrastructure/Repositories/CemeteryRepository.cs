using Project.Core.Interfaces;
using Project.Core.Entities;
using Project.Infrastructure.Data;

namespace Project.Infrastructure.Repositories;

public class CemeteryRepository : ICemeteryRepository
{
    private readonly CemeteriesContext cemeteriesContext;

    public CemeteryRepository(CemeteriesContext cemeteriesContext)
    {
        this.cemeteriesContext = cemeteriesContext;
    }

    public IQueryable<CemeteryModel> Get()
    {
        return this.cemeteriesContext.Set<CemeteryModel>().AsQueryable();
    }
}