using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositores
{
    public class FlightRepository : IFlightRepository
    {
        private readonly FlightsContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public FlightRepository(FlightsContext context)
        {
            _context = context;
        }

        public Flight Add(Flight flight)
        {
            return _context.Flights.Add(flight).Entity;
        }
        public void Update(Flight flight)
        {
            _context.Flights.Update(flight);
        }

        public async Task<Flight> GetAsync(Guid flightId)
        {
            return await _context.Flights.FirstOrDefaultAsync(o => o.Id == flightId);
        }

        public async Task<IEnumerable<Flight>> GetAllAsync()
        {
            return await _context.Flights
                .Include(i => i.OriginAirport)
                .Include(i => i.DestinationAirport)
                .Include(i => i.Rates)
                .ToListAsync();
        }

        public async Task<IEnumerable<Flight>> GetAllByDestinationAsync(string destination)
        {
            return await _context.Flights
                .Include(i => i.OriginAirport)
                .Include(i => i.DestinationAirport)
                .Include(i => i.Rates)
                .Where(i => i.DestinationAirport.Name.ToLower().Contains(destination.ToLower()) && i.Rates.Any())
                .ToListAsync();
        }
    }
}
