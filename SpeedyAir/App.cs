using Newtonsoft.Json;
using SpeedyAir.Repositories;
using SpeedyAir.Services;

public class App
{
    private readonly OrderRepository _orderRepository;

    private readonly ShippingService _shippingService;
    public App(OrderRepository  orderRepository, ShippingService shippingService)
    {
        _orderRepository = orderRepository;
        _shippingService = shippingService;
    }

    public void Run(string[] args)
    {
        var schedule = _shippingService.GetFlightSchedule();
        Console.WriteLine(schedule);
        // var orders = _orderRepository.GetOrders();
        //
        // var json = JsonConvert.SerializeObject(orders);
        //
        // Console.WriteLine(json);
        
        //Console.WriteLine("Hello World!");
        Console.ReadKey();
    }
}