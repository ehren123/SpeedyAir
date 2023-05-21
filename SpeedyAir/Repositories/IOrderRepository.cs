using SpeedyAir.Entities;

namespace SpeedyAir.Repositories;

public interface IOrderRepository
{
    List<Order> GetOrders();
}