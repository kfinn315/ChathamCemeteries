
using Project.Core.Entities.Business;
using Project.Core.Entities.General;
using Project.Core.Interfaces.IMapper;
using Project.Core.Interfaces.IRepositories;
using Project.Core.Interfaces.IServices;

namespace Project.Core.Services;


public class GraveService : BaseService<Grave, GraveViewModel>, IGraveService
{
    public GraveService(
        IBaseMapper<Grave, GraveViewModel> viewModelMapper, 
        IGraveRepository repository) : base(viewModelMapper, repository)
    {
    }
}