using Aranda.TestBackend.Domain.Aggregates.Entities;
using Aranda.TestBackend.Domain.Aggregates.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aranda.TestBackend.Application.Commands
{
    public sealed class ProductCommandHandler :
        IRequestHandler<DeleteProductCommandRequest>,
        IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>,        
        IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>        
    {
        private readonly ILogger<ProductCommandHandler> _logger;
        private readonly IProductService<Product> _productService;

        public ProductCommandHandler(ILogger<ProductCommandHandler> logger, IProductService<Product> productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            _logger.Log(LogLevel.Information, "Method Handle [CreateProduct] - Application");

            try
            {
                await _productService.InsertProductAsync(request.product);
                return new CreateProductCommandResponse(request.product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while handling product creation.");
                throw; 
            }
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            _logger.Log(LogLevel.Information, "Method Handle [UpdateProduct] - Application");

            try
            {
                await _productService.UpdateProductAsync(request.product);
                return new UpdateProductCommandResponse(request.product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while handling product update.");
                throw;
            }
        }

        public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _productService.DeleteProductAsync(request.id);
                return new Unit();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while handling product delete.");
                throw;
            }
        }
    }
}
