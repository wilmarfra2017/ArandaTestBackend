using Aranda.TestBackend.Api.Controllers;
using Aranda.TestBackend.Application.Commands;
using Aranda.TestBackend.Domain.Aggregates.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;

namespace Aranda.TestBackend.Api.Test.Controllers
{
    public class ProductControllerTest
    {
        [Fact]
        public async Task CreateProduct_ReturnsExpectedResult()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            var mockLogger = new Mock<ILogger<ProductController>>();

            var product = new Product();
            var request = new CreateProductCommandRequest(product);
            var response = new CreateProductCommandResponse(product);

            mockMediator
                .Setup(m => m.Send(It.IsAny<CreateProductCommandRequest>(), default(CancellationToken)))
                .ReturnsAsync(response);

            var controller = new ProductController(mockMediator.Object, mockLogger.Object);

            // Act
            var result = await controller.CreateProduct(request);

            // Assert
            Assert.NotNull(result.product);
            Assert.Equal(response, result);
            mockMediator.Verify(m => m.Send(It.IsAny<CreateProductCommandRequest>(), default(CancellationToken)), Times.Once());
        }
    }
}
