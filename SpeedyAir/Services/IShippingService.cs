namespace SpeedyAir.Services;

public interface IShippingService
{
    string GetFlightSchedule();

    string GetOrderItineraries();

    string GetFlightsWithOrdersById(long id);
}