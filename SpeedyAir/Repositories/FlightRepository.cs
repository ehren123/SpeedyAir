using SpeedyAir.Entities;

namespace SpeedyAir.Repositories;

public class FlightRepository : IFlightRepository
{
    public List<Flight> GetFlights() =>
        new()
        {
            new Flight
            {
                Id = 1, 
                Day = 1,
                Departure = "YUL",
                Arrival = "YYZ",
                Orders = new List<Order>(20)
            },
            new Flight
            {
                Id = 2,
                Day = 1, 
                Departure = "YUL", 
                Arrival = "YYC", 
                Orders = new List<Order>(20)
            },
            new Flight
            {
                Id = 3,
                Day = 1, 
                Departure = "YUL", 
                Arrival = "YVR", 
                Orders = new List<Order>(20)
            },
            new Flight
            {
                Id = 4,
                Day = 2, 
                Departure = "YUL", 
                Arrival = "YYZ", 
                Orders = new List<Order>(20)
            },
            new Flight
            {
                Id = 5,
                Day = 2, 
                Departure = "YUL", 
                Arrival = "YYC", 
                Orders = new List<Order>(20)
            },
            new Flight
            {
                Id = 6,
                Day = 2, 
                Departure = "YUL", 
                Arrival = "YVR", 
                Orders = new List<Order>(20)
            },
        };
}