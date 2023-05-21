using Newtonsoft.Json;
using SpeedyAir.Repositories;

public class App
{
    private readonly OrderRepository _orderRepository;
    public App(OrderRepository  orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public void Run(string[] args)
    {
        var orders = _orderRepository.GetOrders();

        var json = JsonConvert.SerializeObject(orders);
        
        Console.WriteLine(json);
        
        //Console.WriteLine("Hello World!");
        Console.ReadKey();
    }
}