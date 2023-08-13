namespace Aranda.TestBackend.Domain.Aggregates.Interfaces
{
    public interface IProductService<T> : IProductFinder<T>, IProductRepository<T>
    {
    }
}
