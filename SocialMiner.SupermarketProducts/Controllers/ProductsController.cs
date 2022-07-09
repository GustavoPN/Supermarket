using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMiner.SupermarketProducts.Core.Repository;
using SocialMiner.SupermarketProducts.Repositores;
using SupermarketProducts.UseCases.CatalogUseCases.GetProductsUseCase;
using SupermarketProducts.UseCases.CatalogUseCases.PutProducts;

namespace SupermarketProducts.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var request = new GetProductsRequest();
            var response = _mediator.Send(request);
            return Ok(response);
        }
    }
}
