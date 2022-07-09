using MediatR;
using SocialMiner.SupermarketProducts.Core.Repository;
using SocialMiner.SupermarketProducts.Domain.Product;
using SupermarketProducts.Core.Rest;

namespace SupermarketProducts.UseCases.CatalogUseCases.PutProducts
{
    public class PutProductsUseCase : IRequestHandler<PutProductsRequest, ApiResponse<PutProductsResponse>>
    {
        private IProductRepository _ProductRepository;

        public PutProductsUseCase(IProductRepository _productsRepository)
        {
            _ProductRepository = _ProductRepository;
        }

        public async Task<ApiResponse<PutProductsResponse>> Handle
                                                            (PutProductsRequest request,
                                                             CancellationToken cancellationToken)
        {
            var p = new Product(request.Name,
                                request.Description,
                                request.NutritionalInformation,
                                request.BarCode);

            await _ProductRepository.AddAsync(p);

            return new ApiResponse<PutProductsResponse>
            {
                Response = new PutProductsResponse
                {
                    Id = p.Id
                }
            };
        }
    }
}
