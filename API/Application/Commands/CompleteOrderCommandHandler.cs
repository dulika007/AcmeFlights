using Domain.Aggregates.OrderAggregate;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Linq;

namespace API.Application.Commands
{
    public class CompleteOrderCommandHandler : IRequestHandler<CompleteOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public CompleteOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(CompleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId);

            if (order is null)
                throw new Exception("Order not found!");

            if (order.Status is not Domain.Aggregates.OrderAggregate.Enums.Status.Draft)
                throw new Exception("Order is not in draft state to complete");

            order.Status = Domain.Aggregates.OrderAggregate.Enums.Status.Confirm;
            order.FlightRate.MutateAvailability(-1);
            order.ConfirmOrder();

            await _orderRepository.UnitOfWork.SaveEntitiesAsync();

            return Unit.Value;
        }
    }
}
