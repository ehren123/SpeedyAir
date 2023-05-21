using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SpeedyAir.Entities;

namespace SpeedyAir.Repositories;

public class OrderRepository
{
    private readonly string ORDERS_JSON_PATH = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"Data/coding-assigment-orders.json");
    
    public IList<Order> GetOrders()
    {
        var ordersJson = File.ReadAllText(ORDERS_JSON_PATH);
        var ordersJObject = JObject.Parse(ordersJson);
        
        var orders = new List<Order>();
        foreach(var orderJObject in ordersJObject)
        {
            orders.Add(new Order(orderJObject.Key, (string)orderJObject.Value["destination"]));
        }
        
        return orders;
    }
}