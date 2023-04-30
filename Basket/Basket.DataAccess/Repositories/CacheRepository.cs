using Basket.DataAccess.Repositories.Interfaces;
using Basket.Entites.Common;
using Infrastructure.Services.Interfaces;
using StackExchange.Redis;

namespace Basket.DataAccess.Repositories
{
    public class CacheRepository : ICacheRepository
    {
        private readonly IJsonSerializer _jsonSerializer;
        private readonly IDatabase _database;

        public CacheRepository(IJsonSerializer jsonSerializer, IConnectionMultiplexer connectionMultiplexer)
        {
            _jsonSerializer = jsonSerializer;
            _database = connectionMultiplexer.GetDatabase();
        }

        public async Task<bool> AddOrUpdateAsync(Guid id, CustomerBasket customerBasket)
        {
            if (customerBasket == null)
            {
                throw new ArgumentNullException(nameof(customerBasket), "Customer basket cannot be null");
            }

            var basket = _jsonSerializer.Serialize(customerBasket);

            return await _database.StringSetAsync(id.ToString(), basket);
        }

        public async Task<CustomerBasket> GetAsync(Guid id)
        { 
           var basket = await _database.StringGetAsync(id.ToString());

            return basket.HasValue ?
                _jsonSerializer.Deserialize<CustomerBasket>(basket!)!
                : new CustomerBasket();
        }
    }
}