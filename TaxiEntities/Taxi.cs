namespace Entities;

public class Taxi 
{
    public int Id { get; init; }
    public string Car { get; init; }
    public string Cost { get; init; }
    public string Time { get; init; }
    public string Luxury { get; init; }
    public bool isAvailable { get ;set; } = true;
}