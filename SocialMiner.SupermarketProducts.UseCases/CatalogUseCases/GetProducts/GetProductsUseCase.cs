using MediatR;
using SocialMiner.SupermarketProducts.Core.Repository;
using SocialMiner.SupermarketProducts.Repositores;
using SupermarketProducts.Core.Reset;
using SupermarketProducts.UseCases.CatalogUseCases.GetProductsUseCase;

public class GetProductsUseCase : IRequestHandler<GetProductsRequest, ApiResponse<GetProductsResponse>>
{
    private readonly IProductRepository _ProductsRepository;

    public GetProductsUseCase(ProductRepository ProductsRepository)
    {
        _ProductsRepository = ProductsRepository;
    }

    public async Task<ApiResponse<GetProductsResponse>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
    {
        return new ApiResponse<GetProductsResponse>
        {
            Response = new GetProductsResponse(await _ProductsRepository.GetAsync())
        };
    }
}