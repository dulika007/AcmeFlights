using System;
using System.Threading.Tasks;
using Domain.SeedWork;

namespace Domain.Aggregates.AirportAggregate
{
    public interface IAirportRepository : IRepository<Airport>
    {
        Airport Add(Airport airport);

        void Update(Airport airport);

        Task<Airport> GetByIdAsync(Guid airportId);
    }
}