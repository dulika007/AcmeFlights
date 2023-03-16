using System;

namespace API.ApiResponses;

public class FlightResponse
{
    public string DepartureAirportCode { get; set; }
    public string ArrivalAirportCode { get; set; }
    public DateTimeOffset Departure { get; set; }
    public decimal PriceFrom { get; set; }

}
