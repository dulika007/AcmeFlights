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

        /// <summary>
        /// Add Flight
        /// </summary>
        /// <param name="flight"></param>
        /// <returns></returns>
        public Flight Add(Flight flight)
        {
            return _context.Flights.Add(flight).Entity;
        }

        /// <summary>
        /// Update Flight
        /// </summary>
        /// <param name="flight"></param>
        public void Update(Flight flight)
        {
            _context.Flights.Update(flight);
        }

        /// <summary>
        /// Get by Flight Id
        /// </summary>
        /// <param name="flightId"></param>
        /// <returns></returns>
        public async Task<Flight> GetByIdAsync(Guid flightId)
        {
            return await _context.Flights.Include(i => i.Rates).FirstOrDefaultAsync(o => o.Id == flightId);
        }

        /// <summary>
        /// Get all Flight data
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Flight>> GetAllAsync()
        {
            return await _context.Flights
                .Include(i => i.OriginAirport)
                .Include(i => i.DestinationAirport)
                .Include(i => i.Rates)
                .ToListAsync();
        }

        /// <summary>
        /// Get all Flights by Destination
        /// </summary>
        /// <param name="destination"></param>
        /// <returns></returns>
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
