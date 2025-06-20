using Ecommerce.Application.UseCases.Interfaces.Order;
using Ecommerce.Application.UseCases.Models;
using FastEndpoints;

namespace Ecommerce.Api._Endpoints_.Order.Post
{
    public class Endpoint : Endpoint<OrderCreateRequest, OrderCreateResponse>
    {
        private readonly IOrderAddUseCase _useCase;

        public Endpoint(IOrderAddUseCase useCase)
        {
            _useCase = useCase;
        }

        public override void Configure()
        {
            Post("/order");
            AllowAnonymous();
        }

        public override async Task HandleAsync(OrderCreateRequest req, CancellationToken ct)
        {
            var result = await _useCase.ExecuteAsync(req, ct);
            await SendAsync(result, StatusCodes.Status201Created, ct);
        }
    }
}
