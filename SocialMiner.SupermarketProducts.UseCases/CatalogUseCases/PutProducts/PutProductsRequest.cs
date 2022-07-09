using MediatR;
using SupermarketProducts.Core.Rest;
using SupermarketProducts.UseCases.CatalogUseCases.GetProductsUseCase;

namespace SupermarketProducts.UseCases.CatalogUseCases.PutProducts
{
    public class PutProductsRequest : IRequest<ApiResponse<PutProductsResponse>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string NutritionalInformation { get; set; }
        public string BarCode { get; set; }
    }
}
