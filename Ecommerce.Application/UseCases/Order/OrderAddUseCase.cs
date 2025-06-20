using Ecommerce.Application.Repositories.Interfaces;
using Ecommerce.Application.UseCases.Interfaces.Order;
using Ecommerce.Application.UseCases.Models;

namespace Ecommerce.Application.UseCases.Order
{
    public class OrderAddUseCase : IOrderAddUseCase
    {
        private readonly IOrderRepository _repository;

        public OrderAddUseCase(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OrderCreateResponse> ExecuteAsync(OrderCreateRequest req, CancellationToken cancellationToken = default)
        {
            var order = new Domain.Order
            {
               date = req.Date,
               participantid = req.ParticipantId,
               total = req.Total
            };

            var orderCreated = await _repository.AddAsync(order, cancellationToken);

            var response = new OrderCreateResponse
            {
                Id = orderCreated.id,
                Date = orderCreated.date,
                ParticipantId = orderCreated.participantid,
                Total = orderCreated.total
            };

            return response;
        }
    }
}
