using ReservationsSystem.Domain.Errors;
using ReservationsSystem.Domain.Primitives;

namespace ReservationsSystem.Domain.Entities;

public class Table : AuditableEntity
{
    public Guid FlatId { get; set; }
    public int TableNumber { get; set; }
    public int Capacity { get; set; } 
    public string Location { get; set; } = null!;
    public bool IsActive { get; set; }
    public Flat Flat { get; set; } = null!;

    private Table(
        Guid id,
        Guid flatId,
        int tableNumber,
        int capacity,
        string location,
        bool isActive
    ) : base(id)
    {
        FlatId = flatId;
        TableNumber = tableNumber;
        Capacity = capacity;
        Location = location;
        IsActive = isActive;
    }

    private Table() { }

    public static Result<Table> Create(
        Guid flatId,
        int tableNumber,
        int capacity,
        string location,
        bool isActive
    )
    {
        if (flatId == Guid.Empty)
            return Result.Failure<Table>(TableErrors.InvalidRestaurantId);
            
        if (capacity <= 0)
            return Result.Failure<Table>(TableErrors.InvalidCapacity);

        if (string.IsNullOrWhiteSpace(location))
            return Result.Failure<Table>(TableErrors.InvalidLocation);
        
        if (tableNumber <= 0)
            return Result.Failure<Table>(TableErrors.InvalidTableNumber);
            
        var table = new Table(Guid.NewGuid(), flatId, tableNumber, capacity, location, isActive);
        return table;
    }



    public Result Update(
        int tableNumber,
        int capacity,
        string location,
        bool isActive
    )
    {
        if (capacity <= 0)
            return Result.Failure(TableErrors.InvalidCapacity);

        if (string.IsNullOrWhiteSpace(location))
            return Result.Failure(TableErrors.InvalidLocation);
        
        if (tableNumber <= 0)
            return Result.Failure(TableErrors.InvalidTableNumber);

        TableNumber = tableNumber;
        Capacity = capacity;
        Location = location;
        IsActive = isActive;
        return Result.Success();
    }
    //todo: delete -> consultar como vamos a gestionar el delte lógico, si es necesario un método específico o simplemente marcar la entidad como inactiva.
}