using Project.Core.Entities.Business;
using Project.Core.Entities.General;

namespace Project.Core.Interfaces.IServices
{
    public interface IGraveService : IBaseService<GraveViewModel>
    {
        // Task<CemeteryModel> Create(ProductCreateViewModel model, CancellationToken cancellationToken);
        // Task Update(ProductUpdateViewModel model, CancellationToken cancellationToken);
        // Task Delete(int id, CancellationToken cancellationToken);
        // Task<double> PriceCheck(int productId, CancellationToken cancellationToken);
    }
}