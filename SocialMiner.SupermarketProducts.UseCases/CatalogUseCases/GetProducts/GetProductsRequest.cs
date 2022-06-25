using MediatR;
using SupermarketProducts.Core.Reset;

namespace SupermarketProducts.UseCases.CatalogUseCases.GetProductsUseCase
{
    public class GetProductsRequest : IRequest<ApiResponse<GetProductsResponse>>
    {
        public string Tag { get; set; }
    }

}
