using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SpeedyAir.Entities;

namespace SpeedyAir.Repositories;

public class OrderRepository
{
    private readonly string _ordersJsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"Data/coding-assigment-orders.json");
    
    public List<Order> GetOrders()
    {
        var ordersJson = File.ReadAllText(_ordersJsonPath);
        var ordersJObject = JObject.Parse(ordersJson);
        
        var orders = new List<Order>();
        foreach(var orderJObject in ordersJObject)
        {
            if ((string?)orderJObject.Value?["destination"] == null)
            {
                throw new NullReferenceException();
            }

            var orderToAdd = new Order
            {
                Id = orderJObject.Key,
                Origin = "YUL",
                Destination = (string)orderJObject.Value["destination"]!
            };
            
            orders.Add(orderToAdd);
        }
        
        return orders.OrderBy(o => o.Id).ToList();
    }
}