namespace ReservationsSystem.Domain.Entities;

public class Catalogue
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int? Order { get; set; }
    public string? description;

    private Catalogue(
        Guid id,
        string name,
        int? order,
        string? description
    )
    {
        Id = id;
        Name = name;
        Order = order;
        this.description = description;
    }
    private Catalogue() { }
}