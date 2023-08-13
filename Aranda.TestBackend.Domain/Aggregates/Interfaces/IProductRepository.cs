namespace Aranda.TestBackend.Domain.Aggregates.Interfaces
{
    public interface IProductRepository<in T>
    {
        public Task InsertProductAsync(T entity);
        public Task UpdateProductAsync(T entity);
        public Task DeleteProductAsync(int id);
    }
}
