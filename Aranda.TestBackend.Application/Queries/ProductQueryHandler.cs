using Aranda.TestBackend.Domain.Aggregates.Entities;
using Aranda.TestBackend.Domain.Aggregates.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aranda.TestBackend.Application.Queries
{
    public class ProductQueryHandler :
        IRequestHandler<GetAllProductsQueryRequest, GetAllProductsQueryResponse>,
        IRequestHandler<FindProductAscQueryRequest, FindProductAscQueryResponse>,
        IRequestHandler<FindProductDescQueryRequest, FindProductDescQueryResponse>,
        IRequestHandler<FindProductByCategoryAscQueryRequest, FindProductByCategoryAscQueryResponse>,
        IRequestHandler<FindProductByCategoryDescQueryRequest, FindProductByCategoryDescQueryResponse>,
        IRequestHandler<FindProductByDescriptionQueryRequest, FindProductByDescriptionQueryResponse>,
        IRequestHandler<FindProductByNameQueryRequest, FindProductByNameQueryResponse>,
        IRequestHandler<FindProductByCategoryQueryRequest, FindProductByCategoryQueryResponse>
    {
        private readonly ILogger<ProductQueryHandler> _logger;
        private readonly IProductService<Product> _productService;

        public ProductQueryHandler(ILogger<ProductQueryHandler> logger, IProductService<Product> productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<GetAllProductsQueryResponse> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.Log(LogLevel.Information, "Method QueryHandle [SelectAllAsync] - Application");
            try
            {
                var productsAll = await _productService.SelectAllAsync();
                return new GetAllProductsQueryResponse(productsAll);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while handling products consulting all.");
                throw;
            }
        }

        public async Task<FindProductAscQueryResponse> Handle(FindProductAscQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.Log(LogLevel.Information, "Method QueryHandle [FindNameProductAsc] - Application");
            try
            {
                var productsAsc = await _productService.FindNameProductAsc();
                return new FindProductAscQueryResponse(productsAsc);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while handling products ascending consulting.");
                throw;
            }
        }

        public async Task<FindProductDescQueryResponse> Handle(FindProductDescQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.Log(LogLevel.Information, "Method QueryHandle [FindNameProductDesc] - Application");
            try
            {
                var productsDesc = await _productService.FindNameProductDesc();
                return new FindProductDescQueryResponse(productsDesc);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while handling products descending consulting.");
                throw;
            }
        }

        public async Task<FindProductByCategoryAscQueryResponse> Handle(FindProductByCategoryAscQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.Log(LogLevel.Information, "Method QueryHandle [FindProductByCategoryAsc] - Application");
            try
            {
                var productsAscByCategory = await _productService.FindProductByCategoryAsc();
                return new FindProductByCategoryAscQueryResponse(productsAscByCategory);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while handling products by category ascending consulting.");
                throw;
            }
        }

        public async Task<FindProductByCategoryDescQueryResponse> Handle(FindProductByCategoryDescQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.Log(LogLevel.Information, "Method QueryHandle [FindProductByCategoryDesc] - Application");
            try
            {
                var productsDescByCategory = await _productService.FindProductByCategoryDesc();
                return new FindProductByCategoryDescQueryResponse(productsDescByCategory);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while handling products by category descending consulting.");
                throw;
            }
        }

        public async Task<FindProductByDescriptionQueryResponse> Handle(FindProductByDescriptionQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.Log(LogLevel.Information, "Method QueryHandle [FindProductByDescription] - Application");
            try
            {
                var productByDescription = await _productService.FindProductByDescription(request.description);
                return new FindProductByDescriptionQueryResponse(productByDescription);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while handling products by description consulting.");
                throw;
            }
        }

        public async Task<FindProductByNameQueryResponse> Handle(FindProductByNameQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.Log(LogLevel.Information, "Method QueryHandle [FindProductByName] - Application");
            try
            {
                var productByName = await _productService.FindProductByName(request.nameProduct);
                return new FindProductByNameQueryResponse(productByName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while handling products by name product consulting.");
                throw;
            }
        }

        public async Task<FindProductByCategoryQueryResponse> Handle(FindProductByCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.Log(LogLevel.Information, "Method QueryHandle [FindProductByCategory] - Application");
            try
            {
                var productByCategory = await _productService.FindProductByCategory(request.category);
                return new FindProductByCategoryQueryResponse(productByCategory);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while handling products by category product consulting.");
                throw;
            }
        }
    }
}
