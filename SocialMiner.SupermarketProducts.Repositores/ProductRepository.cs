using MongoDB.Bson.Serialization;
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
        private readonly IMongoClient _client;
       
        public ProductRepository(MongoDbSettings settings)
        {
            _settings = settings;
            _client = new MongoClient(settings.ConnectionString);
            var database = _client.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<Product>("product");
            if (!BsonClassMap.IsClassMapRegistered(typeof(Product)))
                BsonClassMap.RegisterClassMap<Product>(cm =>
                {
                    cm.AutoMap();
                    cm.UnmapMember(m => m.Errors);
                });
        }

        public async Task AddAsync(Product document)
        {
            using(var session = await _client.StartSessionAsync())
            {
                //session.StartTransaction();
                await _collection.InsertOneAsync(document);
               // await session.CommitTransactionAsync();
            }
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
            return (await _collection.FindAsync<Product>(x => x.Id == id)).First();
        }

        public async Task UpdateAsync(Product document)
        {
            await _collection.ReplaceOneAsync<Product>(x => x.Id == document.Id,
                                                       document,
                                                       new ReplaceOptions  
                                                       { 
                                                           IsUpsert = true
                                                       });
        }
    }
}
