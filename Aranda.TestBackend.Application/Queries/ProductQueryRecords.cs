using Aranda.TestBackend.Domain.Aggregates.Entities;
using MediatR;

namespace Aranda.TestBackend.Application.Queries
{
    public readonly record struct GetAllProductsQueryRequest() : IRequest<GetAllProductsQueryResponse>;
    public record struct GetAllProductsQueryResponse(List<Product>? product);

    public readonly record struct FindProductAscQueryRequest() : IRequest<FindProductAscQueryResponse>;
    public record struct FindProductAscQueryResponse(List<Product>? product);

    public readonly record struct FindProductDescQueryRequest() : IRequest<FindProductDescQueryResponse>;
    public record struct FindProductDescQueryResponse(List<Product>? product);

    public readonly record struct FindProductByCategoryAscQueryRequest() : IRequest<FindProductByCategoryAscQueryResponse>;
    public record struct FindProductByCategoryAscQueryResponse(List<Product>? product);

    public readonly record struct FindProductByCategoryDescQueryRequest() : IRequest<FindProductByCategoryDescQueryResponse>;
    public record struct FindProductByCategoryDescQueryResponse(List<Product>? product);

    public readonly record struct FindProductByDescriptionQueryRequest(string description) : IRequest<FindProductByDescriptionQueryResponse>;
    public record struct FindProductByDescriptionQueryResponse(Product? product);

    public readonly record struct FindProductByNameQueryRequest(string nameProduct) : IRequest<FindProductByNameQueryResponse>;
    public record struct FindProductByNameQueryResponse(Product? product);

    public readonly record struct FindProductByCategoryQueryRequest(int category) : IRequest<FindProductByCategoryQueryResponse>;
    public record struct FindProductByCategoryQueryResponse(List<Product>? product);
}
