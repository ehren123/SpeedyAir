using SpeedyAir.Services;

namespace SpeedyAir;

public class App
{
    private readonly IShippingService _shippingService;
    
    public App(IShippingService shippingService)
    {
        _shippingService = shippingService;
    }

    public int Run(string[] args)
    {
        // var schedule = _shippingService.GetFlightSchedule();
        // Console.WriteLine(schedule);
        //
        // var orderItineraries = _shippingService.GetOrderItineraries();
        // Console.WriteLine(orderItineraries);
        
        _shippingService.GetFlightsWithOrdersById(3);

        Console.ReadKey();

        return 0;
    }
}