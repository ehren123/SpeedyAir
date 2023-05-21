using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SpeedyAir.Entities;

namespace SpeedyAir.Repositories;

public class OrderRepository
{
    private readonly string _ordersJsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"Data/coding-assigment-orders.json");
    
    public IList<Order> GetOrders()
    {
        var ordersJson = File.ReadAllText(_ordersJsonPath);
        var ordersJObject = JObject.Parse(ordersJson);
        
        var orders = new List<Order>();
        foreach(var orderJObject in ordersJObject)
        {
            orders.Add(new Order(orderJObject.Key, "YUL",((string)orderJObject.Value!["destination"])!));
        }
        
        return orders;
    }
}