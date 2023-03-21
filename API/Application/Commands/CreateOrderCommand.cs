using API.Application.ViewModels;
using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;

namespace API.Application.Commands
{
    public class CreateOrderCommand : IRequest<OrderViewModel>
    {
        public Guid CustomerId { get; private set; }
        public Guid FlightId { get; private set; }
        public Guid FlightRateId { get; private set; }
        public int Quantity { get; private set; }

        public CreateOrderCommand(Guid customerId, Guid flightId, Guid flightRateId, int quantity)
        {
            CustomerId = customerId;
            FlightId = flightId;
            FlightRateId = flightRateId;
            Quantity = quantity;
        }
    }
}
