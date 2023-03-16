using Domain.Aggregates.AirportAggregate;
using Domain.SeedWork;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Aggregates.FlightAggregate
{
    public interface IFlightRepository : IRepository<Flight>
    {
        Flight Add(Flight flight);

        void Update(Flight flight);

        Task<Flight> GetAsync(Guid flightId);

        Task<IEnumerable<Flight>> GetAllAsync();
        Task<IEnumerable<Flight>> GetAllByDestinationAsync(string destination);
    }
}