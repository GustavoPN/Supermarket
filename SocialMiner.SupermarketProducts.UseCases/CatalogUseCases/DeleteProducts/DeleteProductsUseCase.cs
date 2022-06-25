using MediatR;
using SocialMiner.SupermarketProducts.Core.Repository;
using SocialMiner.SupermarketProducts.Repositores;
using SupermarketProducts.Core.Reset;

namespace SupermarketProducts.UseCases.CatalogUseCases.DeleteProducts
{
    public class DeleteProductsUseCase : IRequestHandler<DeleteProductsRequest, ApiResponse<DeleteProductsResponse>>
    {
        private readonly IProductRepository _productsRepository;

        public DeleteProductsUseCase(ProductRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<ApiResponse<DeleteProductsResponse>> Handle(DeleteProductsRequest request, CancellationToken cancellationToken)
        {
            return new ApiResponse<DeleteProductsResponse>
            {
                Response = new DeleteProductsResponse(await _productsRepository.DeleteAsync(request.Id))
            };
        }
    }
}
