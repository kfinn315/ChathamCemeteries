
using Project.Core.Entities.Business;
using Project.Core.Entities.General;
using Project.Core.Interfaces.IMapper;
using Project.Core.Interfaces.IRepositories;
using Project.Core.Interfaces.IServices;

namespace Project.Core.Services;

public class CemeteryService : BaseService<Cemetery, CemeteryViewModel>, ICemeteryService
{
    private readonly IBaseMapper<Cemetery, CemeteryViewModel> viewModelMapper;
    private readonly ICemeteryRepository cemeteryRepository;

    public CemeteryService(IBaseMapper<Cemetery, CemeteryViewModel> viewModelMapper, ICemeteryRepository cemeteryRepository) : base(viewModelMapper, cemeteryRepository)
    {
        this.viewModelMapper = viewModelMapper;
        this.cemeteryRepository = cemeteryRepository;
    }

    public async Task<CemeteryViewModel> GetByIdWithGraves(int id, CancellationToken cancellationToken)
    {
        return viewModelMapper.MapModel(await cemeteryRepository.GetWithGraves(id, cancellationToken));
    }

    public async Task<NodeViewModel> GetDecadeSummary(int cemeteryId, CancellationToken cancellationToken)
    {
        var cemetery = await cemeteryRepository.GetWithGraves(cemeteryId, cancellationToken);

        var decades = cemetery.Graves?.GroupBy(x =>
        {
            if (x.DeathYear.HasValue)
            {
                return x.DeathYear - x.DeathYear % 10;
            }
            return null;
        }).Select(group =>
        {
            return new NodeViewModel { Id = group.Key ?? -1, Size = group.Count(), Name = group.Key.ToString() ?? "Unknown", Children = GetChildren(group) };
        });

        if (decades == null)
        {
            throw new Exception();
        }

        return new NodeViewModel { Id = cemetery.Id, Children = decades?.ToArray(), Name = cemetery.Name, Size = cemetery?.Graves?.Count ?? 0 };
    }

    private static NodeViewModel[] GetChildren(IGrouping<int?, Grave> group)
    {
        return group.Select(x =>
        {
            if (x.BirthYear.HasValue && x.DeathYear.HasValue)
            {
                return (x.DeathYear - x.BirthYear) / 10 * 10;
            }
            return null;
        }).GroupBy(y => y).Select(x =>
        {
            return new NodeViewModel { Id = x.Key ?? -1, Name = "Age Range " + x.Key.ToString() ?? "Unknown", Size = x?.Count() ?? 0 };
        }).ToArray();
    }

    public async Task<IEnumerable<NameViewModel>> GetNameSummary(int cemeteryID, CancellationToken cancellationToken)
    {
        var cemetery = await GetByIdWithGraves(cemeteryID, cancellationToken);
        if (cemetery is null)
        {
            throw new Exception("Cemetery is null");
        }
        var graves = cemetery.Graves;
        if (graves is null)
        {
            throw new Exception("Graves are null");
        }

        return graves.GroupBy(x => x.LastName).Select(x => new NameViewModel { Name = x.Key, Graves = x.ToArray() });
    }
}
