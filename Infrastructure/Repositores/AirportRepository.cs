using System;
using System.Threading.Tasks;
using Domain.Aggregates.AirportAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositores
{
    public class AirportRepository : IAirportRepository
    {
        private readonly FlightsContext _context;
        
        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public AirportRepository(FlightsContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Add Airport
        /// </summary>
        /// <param name="airport"></param>
        /// <returns></returns>
        public Airport Add(Airport airport)
        {
            return _context.Airports.Add(airport).Entity;
        }

        /// <summary>
        /// Update Airport
        /// </summary>
        /// <param name="airport"></param>
        public void Update(Airport airport)
        {
            _context.Airports.Update(airport);
        }

        /// <summary>
        /// Get by Airport Id
        /// </summary>
        /// <param name="airportId"></param>
        /// <returns></returns>
        public async Task<Airport> GetByIdAsync(Guid airportId)
        {
            return await _context.Airports.FirstOrDefaultAsync(o => o.Id == airportId);
        }
    }
}