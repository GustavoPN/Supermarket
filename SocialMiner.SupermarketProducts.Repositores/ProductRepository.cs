using MongoDB.Driver;
using SocialMiner.SupermarketProducts.Core.Repository;
using SocialMiner.SupermarketProducts.Core.Settings;
using SocialMiner.SupermarketProducts.Domain.Product;

namespace SocialMiner.SupermarketProducts.Repositores
{
    public class ProductRepository : IProductRepository
    {
        private readonly MongoDbSettings _settings;
        private readonly IMongoCollection<Product> _collection;
       
        public ProductRepository(MongoDbSettings settings)
        {
            _settings = settings;
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<Product>("product");
        }

        public async Task AddAsync(Product document)
        {
            await _collection
                    .ReplaceOneAsync(x => x.Id == document.Id,
                                       document,
                                       new ReplaceOptions { IsUpsert = true });
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _collection.DeleteOneAsync<Product>(x => x.Id == id);

            return result.DeletedCount > 0;
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            return (await _collection.FindAsync<Product>(x => x.Id != Guid.Empty)).ToList();
        }

        public async Task<Product> GetAsync(Guid id)
        {
            return (await _collection.FindAsync<Product>(x => x.Id != id)).First();
        }
    }
}
