using MediatR;
using SupermarketProducts.Core.Rest;

namespace SupermarketProducts.UseCases.CatalogUseCases.GetProductsById
{
    public class GetProductsByIdRequest : IRequest<ApiResponse<GetProductsByIdResponse>>
    {
        private object id;

        public GetProductsByIdRequest(object id)
        {
            this.id = id;
        }

        public Guid Id { get; set; }

    }
}
