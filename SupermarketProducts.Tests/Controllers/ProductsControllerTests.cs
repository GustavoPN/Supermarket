using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SocialMiner.SupermarketProducts.Domain.Product;
using SupermarketProducts.Core.Rest;
using SupermarketProducts.Rest.Controllers;
using SupermarketProducts.UseCases.CatalogUseCases.GetProductsUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using SupermarketProducts.UseCases.CatalogUseCases.GetProductsById;
using SupermarketProducts.UseCases.CatalogUseCases.PostProducts;
using SupermarketProducts.UseCases.CatalogUseCases.DeleteProducts;
using SupermarketProducts.UseCases.CatalogUseCases.PutProducts;

namespace SupermarketProducts.Tests.Controllers
{
    public class ProductsControllerTests
    {
        private ProductsController _controller;
        public Mock<IMediator> _mediator { get; set; }

        public ProductsControllerTests()
        {
            _mediator = new Mock<IMediator>();
            _controller = new ProductsController(_mediator.Object);
        }

        [Fact]
        public async Task When_GetProducts_Returns_Ok()
        {
            _mediator.Setup(m => m.Send(It.IsAny<GetProductsRequest>(), default))
                .ReturnsAsync(new ApiResponse<GetProductsResponse>());

            var result = await _controller.GetProducts();

            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task When_Get_WithId_Returns_Ok()
        {
            _mediator.Setup(m => m.Send(It.IsAny<GetProductsByIdRequest>(), default))
                .ReturnsAsync(new ApiResponse<GetProductsByIdResponse>());

            var result = await _controller.Get(Guid.NewGuid());

            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task When_PostProducts_Returns_Ok()
        {
            _mediator.Setup(m => m.Send(It.IsAny<PostProductsRequest>(), default))
                .ReturnsAsync(new ApiResponse<PostProductsResponse>());
            var request = new PostProductsRequest
            {
                Name = "Produto de teste",
                Description = "Produto de teste",
                BarCode = "Código de barra"
            };
            var result = await _controller.PostProducts(request);

            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task When_PostProducts_Returns_BadRequest()
        {
            _mediator.Setup(m => m.Send(It.IsAny<PostProductsRequest>(), default))
                .ReturnsAsync(new ApiResponse<PostProductsResponse>());
            var request = new PostProductsRequest
            {
                Name = "",
                Description = "Produto de teste",
                BarCode = "Código de barra"
            };
            var result = await _controller.PostProducts(request);

            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task When_DeleteProducts_Returns_Ok()
        {
            _mediator.Setup(m => m.Send(It.IsAny<DeleteProductsRequest>(), default))
                .ReturnsAsync(new ApiResponse<DeleteProductsResponse>());
            var request = new DeleteProductsRequest
            {
                Id = Guid.NewGuid()
            };
            var result = await _controller.Delete(request);

            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task When_DeleteProducts_Returns_BadRequest()
        {
            _mediator.Setup(m => m.Send(It.IsAny<DeleteProductsRequest>(), default))
                .ReturnsAsync(new ApiResponse<DeleteProductsResponse>());
            var request = new DeleteProductsRequest
            {
                Id = Guid.Empty
            };
            var result = await _controller.Delete(request);

            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task When_PutProducts_Returns_Ok()
        {
            _mediator.Setup(m => m.Send(It.IsAny<PutProductsRequest>(), default))
                .ReturnsAsync(new ApiResponse<PutProductsResponse>());
            var request = new PutProductsRequest
            {
                id = Guid.NewGuid(),
                Name = "Produto de teste",
                Description = "Produto de teste",
                BarCode = "Código de barra"
            };

            var result = await _controller.PutProducts(request);

            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task When_PutProducts_Returns_BadRequest()
        {
            _mediator.Setup(m => m.Send(It.IsAny<PutProductsRequest>(), default))
                .ReturnsAsync(new ApiResponse<PutProductsResponse>());
            var request = new PutProductsRequest
            {
                id = Guid.Empty
            };

            var result = await _controller.PutProducts(request);

            result.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}
