namespace SpeedyAir.Entities;

public class Order
{
    public string Id { get; init; } = string.Empty;

    public string Origin { get; init; } = string.Empty;

    public string Destination { get; init; } = string.Empty;
    
    public Flight? Flight { get; set; }
}