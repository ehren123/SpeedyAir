using System.Text;
using SpeedyAir.Repositories;

namespace SpeedyAir.Services;

public class ShippingService
{
    private readonly FlightRepository _flightRepository;
    
    public ShippingService(FlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }
    
    public string GetFlightSchedule()
    {
        var flights = _flightRepository.GetFlights();
        
        var sb = new StringBuilder();

        foreach (var flight in flights)
        {
            var line =
                $"Flight: {flight.Id}, departure: {flight.Departure}, arrival: {flight.Arrival}, day: {flight.Day}{Environment.NewLine}";
            sb.Append(line);
        }

        return sb.ToString();
    }
}