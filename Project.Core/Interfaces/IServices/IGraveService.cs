using Project.Core.Entities.Business;

namespace Project.Core.Interfaces.IServices
{
    public interface IGraveService : IBaseService<GraveViewModel>
    {

        public Task<IEnumerable<GraveViewModel>> GetCemetery(int cemeteryId, CancellationToken cancellationToken);
    }
}