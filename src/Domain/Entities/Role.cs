using ReservationsSystem.Domain.Errors;
using ReservationsSystem.Domain.Primitives;
namespace ReservationsSystem.Domain.Entities;
public class Role : AuditableEntity
{
    public string Name { get; private set ; } = null!;
    public ICollection<User> Users { get; private set; } = new List<User>();


    private Role(
        Guid id,
        string name) : base(id)
    {
        Name = name;
    }

    private Role() { }

    public static Result<Role> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Role>(RoleErrors.InvalidName);

        var role = new Role(Guid.NewGuid(), name.Trim());
        return role;
    }

    public Result Update(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure(RoleErrors.InvalidName);

        Name = name.Trim();
        return Result.Success();
    }
}