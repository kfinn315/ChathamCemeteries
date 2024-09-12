using Project.Core.Entities;

namespace Project.Core.Interfaces;

public interface ICemeteryRepository
{
    IQueryable<CemeteryModel> Get();
}
