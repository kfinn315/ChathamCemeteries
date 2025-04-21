using Project.Core.Entities.Business;

namespace Project.Core.Interfaces.IServices
{
    public interface ICemeteryService : IBaseService<CemeteryViewModel>
    {
        public Task<CemeteryViewModel> GetByIdWithGraves(int cemeteryId, CancellationToken cancellationToken);
        public Task<NodeViewModel> GetDecadeSummary(int cemeteryId, CancellationToken cancellationToken);
        public Task<IEnumerable<NameViewModel>> GetNameSummary(int id, CancellationToken cancellationToken);
    }
}
