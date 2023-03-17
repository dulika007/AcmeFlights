using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;

namespace API.Application.Commands
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public Guid CustomerId { get; private set; }
        public Guid FlightId { get; private set; }
        public Guid AirportId { get; private set; }
        public Guid FlightRateId { get; private set; }
        public int Quantity { get; private set; }

        public CreateOrderCommand(Guid customerId, Guid flightId, Guid airportId, Guid flightRateId, int quantity)
        {
            CustomerId = customerId;
            FlightId = flightId;
            AirportId = airportId;
            FlightRateId = flightRateId;
            Quantity = quantity;
        }
    }
}
