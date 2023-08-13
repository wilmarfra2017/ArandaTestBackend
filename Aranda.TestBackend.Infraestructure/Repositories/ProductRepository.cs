using Aranda.TestBackend.Domain.Aggregates.Entities;
using Aranda.TestBackend.Domain.Aggregates.Interfaces;
using Microsoft.Extensions.Logging;

namespace Aranda.TestBackend.Infraestructure.Repositories
{
    public class ProductRepository : IProductRepository<Product>
    {
        private readonly ILogger<ProductRepository> _logger;
        private readonly PersistenceContext _dbContext;

        public ProductRepository(ILogger<ProductRepository> logger, PersistenceContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
      

        public async Task InsertProductAsync(Product entity)
        {
            _logger.Log(LogLevel.Information, "Method InsertProductAsync - Repository - Infraestructure");
            try
            {
                if (entity.Category != null)
                {
                    _dbContext.Category.Add(entity.Category);
                }

                _dbContext.Product.Add(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error has occurred while saving the product");
                throw;
            }            
        }


        public async Task UpdateProductAsync(Product entity)
        {
            _logger.Log(LogLevel.Information, "Method UpdateProductAsync - Repository - Infraestructure");
            try
            {                                
                var existingProduct = await _dbContext.Product.FindAsync(entity.Id);                
                if (existingProduct == null) throw new Exception($"Product with ID {entity.Id} not found.");
                
                if (entity.Category != null)
                {                
                    var existingCategory = await _dbContext.Category.FindAsync(entity.Category.Id);
                    if (existingCategory == null)
                    {              
                        _dbContext.Category.Add(entity.Category);
                    }
                    else
                    {                     
                        _dbContext.Entry(existingCategory).CurrentValues.SetValues(entity.Category);
                    }
                }                
                _dbContext.Entry(existingProduct).CurrentValues.SetValues(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (ArgumentNullException argEx)
            {
                _logger.LogError(argEx, "A null product entity was provided.");
                throw;
            }
            catch (ArgumentException argEx)
            {
                _logger.LogError(argEx, "An invalid argument was provided.");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error has occurred while updating the product.");
                throw;
            }
        }



        public async Task DeleteProductAsync(int id)
        {
            _logger.Log(LogLevel.Information, "Method DeleteProductAsync - Repository - Infraestructure");
            try
            {                
                var existingProduct = await _dbContext.Product.FindAsync(id);

                if (existingProduct == null) throw new Exception($"Product with ID {id} not found.");
                _dbContext.Product.Remove(existingProduct);
                await _dbContext.SaveChangesAsync();
            }
            catch (ArgumentNullException argEx)
            {
                _logger.LogError(argEx, "A null product entity was provided.");
                throw;
            }
            catch (ArgumentException argEx)
            {
                _logger.LogError(argEx, "An invalid argument was provided.");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error has occurred while deleting the product.");
                throw;
            }
        }

    }
}
