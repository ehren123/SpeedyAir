using System.Text;
using SpeedyAir.Entities;
using SpeedyAir.Repositories;

namespace SpeedyAir.Services;

public class ShippingService : IShippingService
{
    private readonly IFlightRepository _flightRepository;
    
    private readonly IOrderRepository _orderRepository;
    
    public ShippingService(IFlightRepository flightRepository, IOrderRepository orderRepository)
    {
        _flightRepository = flightRepository;
        _orderRepository = orderRepository;
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
    
    public string GetOrderItineraries()
    {
        var orders = GetOrdersWithFlights();
        
        var sb = new StringBuilder();

        foreach (var order in orders)
        {
            var line = order.Flight == null 
                ? $"order: {order.Id}, flightNumber: not scheduled{Environment.NewLine}" 
                : $"order: {order.Id}, flightNumber: {order.Flight.Id}, departure: {order.Flight.Departure}, arrival: {order.Flight.Arrival}, day: {order.Flight.Day}{Environment.NewLine}";

            sb.Append(line);
        }

        return sb.ToString();
    }

    private List<Order> GetOrdersWithFlights()
    {
        var flights = _flightRepository.GetFlights()
            .ToLookup(f => (f.Departure, f.Arrival));
        var orders = _orderRepository.GetOrders();

        foreach (var order in orders)
        {
            var flight = flights
                [(order.Origin, order.Destination)]
                .OrderBy(f => f.Day)
                .FirstOrDefault(f => !f.IsFull);

            // No available flight found.
            if (flight == null)
            {
                continue;
            }

            // We may wish to update a database in the future to save the flight itinerary.
            flight.Orders.Add(order);
            order.Flight = flight;
        }
        
        return orders;
    }
}