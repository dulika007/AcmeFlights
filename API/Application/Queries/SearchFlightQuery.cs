using Domain.Aggregates.FlightAggregate;
using MediatR;
using System.Collections.Generic;

namespace API.Application.Queries
{
    public class SearchFlightQuery : IRequest<IEnumerable<Flight>>
    {
        public string Destination { get; set; }
    }
}