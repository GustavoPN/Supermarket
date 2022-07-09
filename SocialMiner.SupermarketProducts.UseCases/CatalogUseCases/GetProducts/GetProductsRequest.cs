using MediatR;
using SupermarketProducts.Core.Rest;

namespace SupermarketProducts.UseCases.CatalogUseCases.GetProductsUseCase
{
    public class GetProductsRequest : IRequest<ApiResponse<GetProductsResponse>>
    {
        
    }

}
