using SocialMiner.SupermarketProducts.Domain.Product;

namespace SupermarketProducts.UseCases.CatalogUseCases.GetProductsById
{
    public class GetProductsByIdResponse
    {
        public GetProductsByIdResponse(Product list)
        {
           List = list;
        }

        public Product List { get; set; }
    }
}
