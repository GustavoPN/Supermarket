using MediatR;
using SupermarketProducts.Core.Rest;

namespace SupermarketProducts.UseCases.CatalogUseCases.GetProductsById
{
    public class GetProductsByIdRequest : IRequest<ApiResponse<GetProductsByIdResponse>>
    {
        public Guid Id { get; set; }

    }
}
