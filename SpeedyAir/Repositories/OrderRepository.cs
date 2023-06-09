﻿using Newtonsoft.Json.Linq;
using SpeedyAir.Entities;

namespace SpeedyAir.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly string _ordersJsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"Data/coding-assigment-orders.json");
    
    public List<Order> GetOrders()
    {
        var ordersJson = File.ReadAllText(_ordersJsonPath);
        var ordersJObject = JObject.Parse(ordersJson);
        
        var orders = new List<Order>();
        foreach(var orderJObject in ordersJObject)
        {
            if ((string?)orderJObject.Value?["destination"] == null || (string?)orderJObject.Value?["service"] == null)
            {
                throw new NullReferenceException();
            }

            var orderToAdd = new Order
            {
                Id = orderJObject.Key,
                Origin = "YUL",
                Destination = (string)orderJObject.Value["destination"]!,
                Guarantee =  (string)orderJObject.Value["service"]! switch
                {
                    "same-day" => Guarantee.SameDay,
                    "next-day" => Guarantee.NextDay,
                    _ => Guarantee.Regular
                }
            };

            orders.Add(orderToAdd);
        }

        return orders
            .OrderBy(o => (int)o.Guarantee)
            .ThenBy(o => o.Id)
            .ToList();
    }
}