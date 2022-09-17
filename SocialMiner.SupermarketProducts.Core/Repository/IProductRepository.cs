using SocialMiner.SupermarketProducts.Domain.Product;

namespace SocialMiner.SupermarketProducts.Core.Repository
{
    public interface IProductRepository
    {
        Task AddAsync(Product document);
        Task<IEnumerable<Product>> GetAsync();
        Task<Product> GetAsync(Guid id);
        Task<bool> DeleteAsync(Guid id);
        Task UpdateAsync(Product document);
    }
}
