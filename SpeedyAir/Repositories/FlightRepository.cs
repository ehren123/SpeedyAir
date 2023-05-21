namespace SpeedyAir.Repositories;

public class FlightRepository
{
    public List<Flight> GetFlights() =>
        new()
        {
            new Flight(1, 1, "YUL", "YYZ"),
            new Flight(2, 1, "YUL", "YYC"),
            new Flight(3, 1, "YUL", "YVR"),
            new Flight(4, 2, "YUL", "YYZ"),
            new Flight(5, 2, "YUL", "YYC"),
            new Flight(6, 2, "YUL", "YVR"),
        };
}