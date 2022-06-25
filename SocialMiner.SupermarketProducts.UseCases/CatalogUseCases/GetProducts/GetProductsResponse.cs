using SocialMiner.SupermarketProducts.Domain.Product;

namespace SupermarketProducts.UseCases.CatalogUseCases.GetProductsUseCase
{
    public class GetProductsResponse
    {
       
            public GetProductsResponse(IEnumerable<Product> list)
            {
                List = list;
            }

            public IEnumerable<Product> List { get; set; }
        
    }
}