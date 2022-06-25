using MediatR;
using SupermarketProducts.Core.Reset;

namespace SupermarketProducts.UseCases.CatalogUseCases.DeleteProducts
{
    public class DeleteProductsRequest : IRequest<ApiResponse<DeleteProductsResponse>>
    {
        public Guid Id { get; set; }
    }
}
