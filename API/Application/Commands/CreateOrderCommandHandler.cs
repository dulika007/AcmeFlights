using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Domain.Aggregates.OrderAggregate;
using System;
using Domain.Aggregates.CustomerAggregate;
using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.AirportAggregate;
using System.Linq;

namespace API.Application.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IFlightRepository _flightRepository;
        private readonly IAirportRepository _airportRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, ICustomerRepository customerRepository, IFlightRepository flightRepository, IAirportRepository airportRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _flightRepository = flightRepository;
            _airportRepository = airportRepository;
        }

        /// <summary>
        /// Create order handler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId); // Validate if the customer is available
            if (customer is null)
                throw new Exception("Invalid CustomerId!");

            var flight = await _flightRepository.GetByIdAsync(request.FlightId); // Validate if the flight is available
            if (flight is null)
                throw new Exception("Invalid FlightId!");

            var airport = await _airportRepository.GetByIdAsync(request.AirportId); // Validate if the airport is available
            if (airport is null)
                throw new Exception("Invalid AirportId!");

            var flightRate = flight.Rates.FirstOrDefault(i => i.Id == request.FlightRateId); // Validate if the flight rate is available
            if (flightRate is null)
                throw new Exception("Invalid FlightRateId!");

            if(flightRate.Available < request.Quantity) // Validate if the quantity is available
                throw new Exception("Not enough quantity!");

            var order = new Order()
            {
                AirportId = request.AirportId,
                CustomerId = request.CustomerId,
                FlightId = request.FlightId,
                FlightRateId = request.FlightRateId,
                Quantity = request.Quantity,
                Status = Domain.Aggregates.OrderAggregate.Enums.Status.Draft
            };

            var orderRsult = _orderRepository.Add(order);

            await _orderRepository.UnitOfWork.SaveEntitiesAsync();

            return orderRsult.Id;
        }
    }
}
