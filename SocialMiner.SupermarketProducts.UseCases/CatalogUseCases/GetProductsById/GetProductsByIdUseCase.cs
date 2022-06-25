using MediatR;
using SocialMiner.SupermarketProducts.Core.Repository;
using SocialMiner.SupermarketProducts.Repositores;
using SupermarketProducts.Core.Reset;

namespace SupermarketProducts.UseCases.CatalogUseCases.GetProductsById
{
    public class GetProductsByIdUseCase : IRequestHandler<GetProductsByIdRequest, ApiResponse<GetProductsByIdResponse>>
    {
        private readonly IProductRepository _productsRepository;

        public GetProductsByIdUseCase(ProductRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<ApiResponse<GetProductsByIdResponse>> Handle(GetProductsByIdRequest request, CancellationToken cancellationToken)
        {
            return new ApiResponse<GetProductsByIdResponse>
            {
                Response = new GetProductsByIdResponse(await _productsRepository.GetAsync(request.Id))
            };
        } 
    }
}
