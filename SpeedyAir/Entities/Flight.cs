using SpeedyAir.Entities;

public class Flight
{
    public long Id { get; set; }
    
    public int Day { get; set; }

    public string Departure { get; set; } = string.Empty;

    public string Arrival { get; set; } = string.Empty;

    public List<Order> Orders { get; set; } = new List<Order>(20);
}