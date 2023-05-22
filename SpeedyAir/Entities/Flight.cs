namespace SpeedyAir.Entities;

public class Flight
{
    public long Id { get; init; }
    
    public int Day { get; init; }

    public string Departure { get; init; } = string.Empty;

    public string Arrival { get; init; } = string.Empty;

    public List<Order> Orders { get; set; } = new List<Order>(20);
    
    public bool IsFull => Orders.Count >= Orders.Capacity;
}