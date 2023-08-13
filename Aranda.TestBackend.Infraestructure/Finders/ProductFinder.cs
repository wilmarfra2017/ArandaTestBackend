using Aranda.TestBackend.Domain.Aggregates.Entities;
using Aranda.TestBackend.Domain.Aggregates.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Aranda.TestBackend.Infraestructure.Finders
{
    public class ProductFinder : IProductFinder<Product>
    {
        private readonly ILogger<ProductFinder> _logger;
        private readonly PersistenceContext _dbContext;

        public ProductFinder(ILogger<ProductFinder> logger, PersistenceContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<List<Product>> FindNameProductAsc()
        {
            _logger.Log(LogLevel.Information, "Method FindNameProductAsc - Finder - Infraestructure");
            try
            {
                return await _dbContext.Product
                    .Include(p => p.Category)
                    .OrderBy(p => p.NameProduct)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error has occurred while querying products in ascending order by name");
                throw;
            }
        }

        public async Task<List<Product>> FindNameProductDesc()
        {
            _logger.Log(LogLevel.Information, "Method FindNameProductDesc - Finder - Infraestructure");
            try
            {
                return await _dbContext.Product
                    .Include(p => p.Category)
                    .OrderByDescending(p => p.NameProduct)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error has occurred while querying products in descending order by name");
                throw;
            }
        }
        
        public async Task<List<Product>> FindProductByCategoryAsc()
        {
            _logger.Log(LogLevel.Information, "Method FindProductByCategoryAsc - Finder - Infraestructure");
            try
            {
                return await _dbContext.Product
                    .Include(p => p.Category)
                    .OrderBy(p => p.Category != null ? p.Category.Name : string.Empty)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error has occurred while querying products in ascending order by category name");
                throw;
            }
        }



        public async Task<List<Product>> FindProductByCategoryDesc()
        {
            _logger.Log(LogLevel.Information, "Method FindProductByCategoryDesc - Finder - Infraestructure");
            try
            {
                return await _dbContext.Product
                    .Include(p => p.Category)
                    .OrderByDescending(p => p.Category != null ? p.Category.Name : string.Empty)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error has occurred while querying products in descending order by category name");
                throw;
            }
        }

        public async Task<Product?> FindProductByDescription(string description)
        {
            _logger.Log(LogLevel.Information, "Method FindProductByDescription - Finder - Infraestructure");
            try
            {
                return await _dbContext.Product
                    .Include(p => p.Category)
                    .Where(p => p.Description.Contains(description))
                    .OrderBy(p => p.Description)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error has occurred while querying products searching by description");
                throw;
            }
        }

        public async Task<Product?> FindProductByName(string nameProduct)
        {
            _logger.Log(LogLevel.Information, "Method FindProductByName - Finder - Infraestructure");
            try
            {
                return await _dbContext.Product
                    .Include(p => p.Category)
                    .Where(p => p.NameProduct.Contains(nameProduct))
                    .OrderBy(p => p.NameProduct)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error has occurred while querying products searching by name product");
                throw;
            }
        }

        public async Task<List<Product>> FindProductByCategory(int category)
        {
            _logger.Log(LogLevel.Information, "Method FindProductByCategory - Finder - Infraestructure");
            try
            {
                return await _dbContext.Product
                    .Include(p => p.Category)
                    .Where(p => p.CategoryId == category)
                    .OrderBy(p => p.NameProduct)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error has occurred while querying products searching by category product");
                throw;
            }
        }


        public async Task<List<Product>> SelectAllAsync()
        {
            _logger.Log(LogLevel.Information, "Method SelectAllAsync - Finder - Infraestructure");
            try
            {                
                return await _dbContext.Product.Include(p => p.Category).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error has occurred while querying all products");
                throw;
            }            
        }
    }
}
