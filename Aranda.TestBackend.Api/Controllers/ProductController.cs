using Aranda.TestBackend.Application.Commands;
using Aranda.TestBackend.Application.Queries;
using Google.Protobuf.WellKnownTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aranda.TestBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProductController> _logger;
        
        public ProductController(IMediator mediator, ILogger<ProductController> logger)
        {
            _mediator = mediator;
            _logger = logger;            
        }

        [HttpPost("CreateProduct")]
        public async Task<CreateProductCommandResponse> CreateProduct(CreateProductCommandRequest request)
        {            
            _logger.Log(LogLevel.Information, "Method CreateProduct - Controller - Api");
            try
            {


                var response = await _mediator.Send(new CreateProductCommandRequest(request.product));
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating product");
                return new CreateProductCommandResponse(null);
            }            
        }
        

        [HttpPut]
        public async Task<UpdateProductCommandResponse> UpdateProduct(UpdateProductCommandRequest request)
        {
            _logger.Log(LogLevel.Information, "Method UpdateProduct - Controller - Api");
            try
            {
                var response = await _mediator.Send(new UpdateProductCommandRequest(request.product));
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error update product");
                return new UpdateProductCommandResponse(null);
            }
        }

        [HttpDelete]
        public async Task<Empty> DeleteProduct(DeleteProductCommandRequest request)
        {
            _logger.Log(LogLevel.Information, "Method DeleteProduct - Controller - Api");
            try
            {
                await _mediator.Send(new DeleteProductCommandRequest(request.id));
                return new Empty();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error delete product");
                throw;
            }
        }


        [HttpGet("GetAllProducts")]
        public async Task<GetAllProductsQueryResponse> GetAllProducts()
        {
            _logger.Log(LogLevel.Information, "Method GetAllProducts - Controller - Api");
            try
            {
                var response = await _mediator.Send(new GetAllProductsQueryRequest());
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error consulting all products");
                return new GetAllProductsQueryResponse(null);
            }
        }

        [HttpGet("AllProductAsc")]
        public async Task<FindProductAscQueryResponse> GetAllProductsAsc()
        {
            _logger.Log(LogLevel.Information, "Method GetAllProductsAsc - Controller - Api");
            try
            {
                var response = await _mediator.Send(new FindProductAscQueryRequest());
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error consulting all products ascending");
                return new FindProductAscQueryResponse(null);
            }
        }

        [HttpGet("AllProductDesc")]
        public async Task<FindProductDescQueryResponse> GetAllProductsDesc()
        {
            _logger.Log(LogLevel.Information, "Method GetAllProductsDesc - Controller - Api");
            try
            {
                var response = await _mediator.Send(new FindProductDescQueryRequest());
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error consulting all products descending");
                return new FindProductDescQueryResponse(null);
            }
        }

        [HttpGet("AllProductByCategoryAsc")]
        public async Task<FindProductByCategoryAscQueryResponse> GetAllProductsByCategoryAsc()
        {
            _logger.Log(LogLevel.Information, "Method GetAllProductsByCategoryAsc - Controller - Api");
            try
            {
                var response = await _mediator.Send(new FindProductByCategoryAscQueryRequest());
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error consulting all products by category ascending");
                return new FindProductByCategoryAscQueryResponse(null);
            }
        }


        [HttpGet("AllProductByCategoryDesc")]
        public async Task<FindProductByCategoryDescQueryResponse> GetAllProductsByCategoryDesc()
        {
            _logger.Log(LogLevel.Information, "Method GetAllProductsByCategoryDesc - Controller - Api");
            try
            {
                var response = await _mediator.Send(new FindProductByCategoryDescQueryRequest());
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error consulting all products by category descending");
                return new FindProductByCategoryDescQueryResponse(null);
            }
        }

        [HttpPost("ProductByDescription")]
        public async Task<FindProductByDescriptionQueryResponse> GetProductByDescription(FindProductByDescriptionQueryRequest request)
        {
            _logger.Log(LogLevel.Information, "Method GetProductByDescription - Controller - Api");
            try
            {
                var response = await _mediator.Send(new FindProductByDescriptionQueryRequest(request.description));
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error consulting product by description");
                return new FindProductByDescriptionQueryResponse(null);
            }
        }


        [HttpPost("ProductByNameProduct")]
        public async Task<FindProductByNameQueryResponse> GetProductByName(FindProductByNameQueryRequest request)
        {
            _logger.Log(LogLevel.Information, "Method GetProductByName - Controller - Api");
            try
            {
                var response = await _mediator.Send(new FindProductByNameQueryRequest(request.nameProduct));
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error consulting product by name product");
                return new FindProductByNameQueryResponse(null);
            }
        }

        [HttpPost("ProductByCategory")]
        public async Task<FindProductByCategoryQueryResponse> GetProductByCategory(FindProductByCategoryQueryRequest request)
        {
            _logger.Log(LogLevel.Information, "Method GetProductByCategory - Controller - Api");
            try
            {
                var response = await _mediator.Send(new FindProductByCategoryQueryRequest(request.category));
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error consulting product by category product");
                return new FindProductByCategoryQueryResponse(null);
            }
        }

    }
}
