namespace ReservationsSystem.Domain.Primitives;

public abstract class AuditableEntity: Entity
{
    protected AuditableEntity(Guid id) : base(id){}
    protected AuditableEntity(){}
    
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Guid? CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }

}