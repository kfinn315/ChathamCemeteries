using Project.Core.Entities;

namespace Project.Core.Interfaces;

public interface IGraveRepository
{
    IQueryable<GraveModel> Get();
}
