using MediatR;
using SocialMiner.SupermarketProducts.Core.Repository;
using SocialMiner.SupermarketProducts.Domain.Product;
using SupermarketProducts.Core.Reset;

namespace SupermarketProducts.UseCases.CatalogUseCases.PostProducts
{
    public class PostProductsUseCase : IRequestHandler<PostProductsRequest, ApiResponse<PostProductsResponse>>
    {
        private IProductRepository _ProductRepository;

        public PostProductsUseCase(IProductRepository _productsRepository)
        {
            _ProductRepository = _ProductRepository;
        }

        public async Task<ApiResponse<PostProductsResponse>> Handle
                                                            (PostProductsRequest request, 
                                                             CancellationToken cancellationToken)
        {
            var p = new Product(request.Name, 
                                request.Description,
                                request.NutritionalInformation,
                                request.BarCode);

            await _ProductRepository.AddAsync(p);

            return new ApiResponse<PostProductsResponse>
            {
                Response = new PostProductsResponse
                {
                    Id = p.Id
                }
            };
        }
    }
}
