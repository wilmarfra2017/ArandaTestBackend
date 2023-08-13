using Aranda.TestBackend.Domain.Aggregates.Entities;

namespace Aranda.TestBackend.Domain.Aggregates.Interfaces
{
    public interface IProductFinder<T>
    {
        public Task<List<Product>> SelectAllAsync();
        public Task<List<Product>> FindNameProductAsc();        
        public Task<List<Product>> FindNameProductDesc();
        public Task<List<Product>> FindProductByCategoryAsc();
        public Task<List<Product>> FindProductByCategoryDesc();
        public Task<Product?> FindProductByDescription(string description);
        public Task<Product?> FindProductByName(string nameProduct);
        public Task<List<Product>> FindProductByCategory(int category);
    }
}
