namespace SpeedyAir.Entities;

public class Order
{
    public string Id { get; set; } = string.Empty;

    public string Origin { get; set; } = string.Empty;

    public string Destination { get; set; } = string.Empty;
    
    public Flight? Flight { get; set; }
}