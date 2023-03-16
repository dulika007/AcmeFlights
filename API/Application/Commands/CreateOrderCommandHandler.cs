using Domain.Aggregates.AirportAggregate;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Domain.Aggregates.OrderAggregate;

namespace API.Application.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order()
            {
                AirportId = request.AirportId,
                CustomerId = request.CustomerId,
                FlightId = request.FlightId,
                FlightRateId = request.FlightRateId,
                Status = Domain.Aggregates.OrderAggregate.Enums.Status.Draft
            };

            var airport = _orderRepository.Add(order);

            await _orderRepository.UnitOfWork.SaveEntitiesAsync();

            return airport;
        }
    }
}
