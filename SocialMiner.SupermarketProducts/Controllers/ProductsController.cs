using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMiner.SupermarketProducts.Core.Repository;
using SocialMiner.SupermarketProducts.Repositores;
using SupermarketProducts.UseCases.CatalogUseCases.DeleteProducts;
using SupermarketProducts.UseCases.CatalogUseCases.GetProductsById;
using SupermarketProducts.UseCases.CatalogUseCases.GetProductsUseCase;
using SupermarketProducts.UseCases.CatalogUseCases.PostProducts;
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
        public async Task<IActionResult> GetProducts()
        {
            var request = new GetProductsRequest();
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var request = new GetProductsByIdRequest(id);
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostProducts(PostProductsRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteProductsRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> PutProducts(PutProductsRequest request)
        {
            if (request.id == Guid.Empty)
            {
                return BadRequest();
            }
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
