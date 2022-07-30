using SocialMiner.SupermarketProducts.Domain.Product;

namespace SupermarketProducts.UseCases.CatalogUseCases.GetProductsUseCase
{
    public class GetProductsResponse
    {
       
            public GetProductsResponse(IEnumerable<Product> products)
            {
                Products = products;
            }

            public IEnumerable<Product> Products { get; set; }
        
    }
}