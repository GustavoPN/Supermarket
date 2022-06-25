using MediatR;
using SupermarketProducts.Core.Reset;

namespace SupermarketProducts.UseCases.CatalogUseCases.PostProducts
{
    public class PostProductsRequest : IRequest<ApiResponse<PostProductsResponse>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string NutritionalInformation { get; set; }
        public string BarCode { get; set; }
    }
}
