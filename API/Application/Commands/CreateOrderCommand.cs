using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;

namespace API.Application.Commands
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public Guid CustomerId { get; private set; }
        public Guid FlightId { get; private set; }
        public Guid AirportId { get; private set; }
        public Guid FlightRateId { get; private set; }

        public CreateOrderCommand(Guid customerId, Guid flightId, Guid airportId, Guid flightRateId)
        {
            CustomerId = customerId;
            FlightId = flightId;
            AirportId = airportId;
            FlightRateId = flightRateId;
        }
    }
}
