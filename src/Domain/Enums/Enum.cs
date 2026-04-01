namespace ReservationsSystem.Domain.Enums
{
    public enum ReservationStatus
    {
        Pending = 1,        // Created, awaiting payment
        Confirmed = 2,      // Payment received
        Cancelled = 3,      // Cancelled by guest or host
        Completed = 4,      // Stay completed
        Rejected = 5
    }

    public enum AdditionalServiceStatus
    {
        Confirmed = 1,      // Payment received
        Cancelled = 2,      // Cancelled by guest or host
    }

    public enum ResourceType
    {
        Restaurant = 1,
        Hotel = 2,
        EventVenue = 3
    }

    public enum RoleCode    {
        Manager = 1,
        Client = 2,
        Admin = 3
    }
}