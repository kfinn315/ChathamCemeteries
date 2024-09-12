using Project.Core.Interfaces;
using Project.Core.Entities;
using Project.Infrastructure.Data;

namespace Project.Infrastructure.Repositories;

public class GraveRepository : IGraveRepository
{
    private readonly CemeteriesContext cemeteriesContext;

    public GraveRepository(CemeteriesContext cemeteriesContext)
    {
        this.cemeteriesContext = cemeteriesContext;
    }

    public IQueryable<GraveModel> Get()
    {
        return cemeteriesContext.Set<GraveModel>().AsQueryable();
    }
}