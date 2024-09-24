using Project.Core.Entities.Business;

namespace Project.Core.Interfaces.IServices
{
    public interface ICemeteryService : IBaseService<CemeteryViewModel>
    {
        // Task<CemeteryModel> Create(ProductCreateViewModel model, CancellationToken cancellationToken);
        // Task Update(ProductUpdateViewModel model, CancellationToken cancellationToken);
        // Task Delete(int id, CancellationToken cancellationToken);
        // Task<double> PriceCheck(int productId, CancellationToken cancellationToken);
    }
}