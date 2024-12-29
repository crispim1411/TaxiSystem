namespace Entities;

public record Candidate 
{
    public Taxi Taxi { get; init; }
    public int SupplierId { get; init; }
}