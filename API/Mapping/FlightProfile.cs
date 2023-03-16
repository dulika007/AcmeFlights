using API.ApiResponses;
using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;
using System.Linq;

namespace API.Mapping
{
    public class FlightProfile : Profile
    {
        public FlightProfile()
        {
            CreateMap<Flight, FlightResponse>()
                .ForMember(d => d.DepartureAirportCode, opts => opts.MapFrom(s => s.OriginAirport.Code))
                .ForMember(d => d.ArrivalAirportCode, opts => opts.MapFrom(s => s.DestinationAirport.Code))
                .ForMember(d => d.PriceFrom, opts => opts.MapFrom(s => s.Rates.OrderBy(i => i.Price.Value).First().Price.Value));
        }
    }
}
