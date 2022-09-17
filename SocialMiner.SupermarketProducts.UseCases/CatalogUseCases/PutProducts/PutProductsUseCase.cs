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
            _ProductRepository = _productsRepository;
        }

        public async Task<ApiResponse<PutProductsResponse>> Handle
                                                            (PutProductsRequest request,
                                                             CancellationToken cancellationToken)
        {
            var product = await _ProductRepository.GetAsync(request.id);

            product.SetNutritionalInformation(request.NutritionalInformation);
            product.SetDescription(request.Description);
            product.SetBarCode(request.BarCode);
            product.SetName(request.Name);

            await _ProductRepository.UpdateAsync(product);

            return new ApiResponse<PutProductsResponse>
            {
                Response = new PutProductsResponse
                {
                    Id = product.Id
                }
            };
        }
    }
}  