using Basket.DataAccess.Entities.Common;

namespace Basket.DataAccess.Repositories.Interfaces;

public interface ICacheRepository
{
    Task<CustomerBasket> GetAsync(Guid id);

    Task<bool> UpdateAsync(Guid id, CustomerBasket customerBasket);
}