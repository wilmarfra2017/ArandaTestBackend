using Aranda.TestBackend.Domain.Aggregates.Entities;
using Aranda.TestBackend.Domain.Aggregates.Interfaces;
using Microsoft.Extensions.Logging;

namespace Aranda.TestBackend.Domain.Services
{
    public class ProductService : IProductService<Product>
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IProductFinder<Product> _productFinder;
        private readonly IProductRepository<Product> _productRepository;

        public ProductService(ILogger<ProductService> logger, IProductFinder<Product> productFinder, IProductRepository<Product> productRepository)
        {
            _logger = logger;
            _productFinder = productFinder;
            _productRepository = productRepository;
        }

        #region Methods Repositories
            public async Task InsertProductAsync(Product entity)
            {
                _logger.Log(LogLevel.Information, "Method InsertProductAsync - Service - Domain");
                if (entity == null) { throw new ArgumentNullException(nameof(entity)); }

                await _productRepository.InsertProductAsync(entity);
            }

            public async Task UpdateProductAsync(Product entity)
            {
                _logger.Log(LogLevel.Information, "Method UpdateProductAsync - Service - Domain");

                if (entity == null) throw new ArgumentNullException(nameof(entity));
                if (entity.Id <= 0) throw new ArgumentException("Invalid Product ID.");

                await _productRepository.UpdateProductAsync(entity);
            }

            public async Task DeleteProductAsync(int id)
            {
               _logger.Log(LogLevel.Information, "Method DeleteProductAsync - Service - Domain");                
                if (id <= 0) throw new ArgumentException("Invalid Product ID.");

                await _productRepository.DeleteProductAsync(id);
            }
        #endregion


        #region Methods Querys
            public async Task<List<Product>> SelectAllAsync()
            {
                _logger.Log(LogLevel.Information, "Method SelectAllAsync - Service - Domain");
                return await _productFinder.SelectAllAsync();
            }

            public async Task<List<Product>> FindNameProductAsc()
            {
                _logger.Log(LogLevel.Information, "Method FindNameProductAsc - Service - Domain");
                return await _productFinder.FindNameProductAsc();
            }

            public async Task<List<Product>> FindNameProductDesc()
            {
               _logger.Log(LogLevel.Information, "Method FindNameProductDesc - Service - Domain");
               return await _productFinder.FindNameProductDesc();
            }

            public async Task<List<Product>> FindProductByCategoryAsc()
            {
                _logger.Log(LogLevel.Information, "Method FindProductByCategoryAsc - Service - Domain");
                return await _productFinder.FindProductByCategoryAsc();
            }

            public async Task<List<Product>> FindProductByCategoryDesc()
            {
                _logger.Log(LogLevel.Information, "Method FindProductByCategoryDesc - Service - Domain");
                return await _productFinder.FindProductByCategoryDesc();
            }

            public async Task<Product?> FindProductByDescription(string description)
            {
                _logger.Log(LogLevel.Information, "Method FindProductByDescription - Service - Domain");
                return await _productFinder.FindProductByDescription(description);
            }

            public async Task<Product?> FindProductByName(string nameProduct)
            {
                _logger.Log(LogLevel.Information, "Method FindProductByName - Service - Domain");
                return await _productFinder.FindProductByName(nameProduct);
            }

            public async Task<List<Product>> FindProductByCategory(int category)
            {
                _logger.Log(LogLevel.Information, "Method FindProductByCategory - Service - Domain");
                return await _productFinder.FindProductByCategory(category);
            }

        #endregion


    }
}
