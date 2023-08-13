using Aranda.TestBackend.Domain.Aggregates.Entities;
using MediatR;

namespace Aranda.TestBackend.Application.Commands
{
    public readonly record struct CreateProductCommandRequest(Product product) : IRequest<CreateProductCommandResponse>;
    public record struct CreateProductCommandResponse(Product? product);

    public readonly record struct UpdateProductCommandRequest(Product product) : IRequest<UpdateProductCommandResponse>;
    public record struct UpdateProductCommandResponse(Product? product);

    public readonly record struct DeleteProductCommandRequest(int id) : IRequest;

}