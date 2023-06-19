namespace FirstWebApp.Models;


public record Product
{
    public required int Id { get; init; }
    public string Name { get; init; }
    public double Price { get; init; }
}
