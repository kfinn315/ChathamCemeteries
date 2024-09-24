
using Project.Core.Entities.Business;
using Project.Core.Entities.General;
using Project.Core.Interfaces.IMapper;
using Project.Core.Interfaces.IRepositories;
using Project.Core.Interfaces.IServices;

namespace Project.Core.Services;


public class CemeteryService : BaseService<Cemetery, CemeteryViewModel>, ICemeteryService
{
    public CemeteryService(IBaseMapper<Cemetery, CemeteryViewModel> viewModelMapper, ICemeteryRepository repository) : base(viewModelMapper, repository)
    {
    }

    // Task<IEnumerable<CemeteryViewModel>> IBaseService<CemeteryViewModel>.GetAll(CancellationToken cancellationToken)
    // {
    //     throw new NotImplementedException();
    // }

    // Task<CemeteryViewModel> IBaseService<CemeteryViewModel>.GetById<Tid>(Tid id, CancellationToken cancellationToken)
    // {
    //     throw new NotImplementedException();
    // }
}