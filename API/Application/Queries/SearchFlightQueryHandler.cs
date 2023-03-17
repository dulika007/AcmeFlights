using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Domain.Aggregates.FlightAggregate;
using System.Collections.Generic;
using System.Linq;

namespace API.Application.Queries
{
    public class SearchFlightQueryHandler : IRequestHandler<SearchFlightQuery, IEnumerable<Flight>>
    {
        private readonly IFlightRepository _flightRepository;

        public SearchFlightQueryHandler(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        /// <summary>
        /// Search flight handler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Flight>> Handle(SearchFlightQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Destination))
                return Enumerable.Empty<Flight>();

            return await _flightRepository.GetAllByDestinationAsync(request.Destination);
        }
    }
}
