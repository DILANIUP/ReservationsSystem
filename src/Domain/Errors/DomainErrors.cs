namespace ReservationsSystem.Domain.Errors;
using ReservationsSystem.Domain.Primitives;

public static class AdditionalServiceErrors
{
    public static readonly Error InvalidName = new ("AdditionalService.InvalidName", "The name of the additional service is invalid.");
    public static readonly Error InvalidPriceForFreeService = new ("AdditionalService.InvalidPriceForFreeService", "The price of a free additional service must be null.");
    public static readonly Error InvalidPriceForPaidService = new ("AdditionalService.InvalidPriceForPaidService", "The price of a paid additional service must be provided and valid.");
}

public static class CatalogueErrors
{
    public static readonly Error InvalidName = new ("Catalogue.InvalidName", "The name of the catalogue is invalid.");
    
}

public static class ExceptionDateErrors
{
    public static readonly Error InvalidResourceId = new ("ExceptionDate.InvalidResourceId", "The resource ID of the exception date is invalid.");
    public static readonly Error InvalidDate = new ("ExceptionDate.InvalidDate", "The date of the exception date is invalid.");
}

public static class FlatErrors
{
    public static readonly Error InvalidFlatNumber = new ("Flat.InvalidFlatNumber", "The flat number must be greater than zero.");
    public static readonly Error InvalidRestaurantId = new ("Flat.InvalidRestaurantId", "The restaurant ID of the flat is invalid.");
}

public static class MenuErrors
{
    public static readonly Error InvalidRestaurantId = new ("Menu.InvalidRestaurantId", "The restaurant ID of the menu is invalid.");
    public static readonly Error InvalidCategoryId = new ("Menu.InvalidCategoryId", "The category ID of the menu is invalid.");

    public static readonly Error InvalidName = new ("Menu.InvalidName", "The name of the menu is invalid.");
}

public static class ReviewErrors
{
    public static readonly Error InvalidRating = new ("Review.InvalidRating", "The rating must be between 1 and 5.");
}

public static class RoleErrors
{
    public static readonly Error InvalidName = new ("Role.InvalidName", "The name of the role is invalid.");
}

public static class ScheduleErrors
{
    public static readonly Error InvalidTimeRange = new ("Schedule.InvalidTimeRange", "The open time must be before the close time.");
}

public static class TableErrors
{
    public static readonly Error InvalidCapacity = new ("Table.InvalidCapacity", "The capacity of the table must be greater than zero.");
    public static readonly Error InvalidLocation = new ("Table.InvalidLocation", "The location of the table is invalid.");
    public static readonly Error InvalidTableNumber = new ("Table.InvalidTableNumber", "The table number must be greater than zero.");
}

public static class UserErrors
{
    public static readonly Error InvalidEmail = new ("User.InvalidEmail", "The email address is invalid.");
    public static readonly Error InvalidPasswordHash = new ("User.InvalidPasswordHash", "The password hash is invalid.");
    public static readonly Error InvalidRole = new ("User.InvalidRole", "The role is invalid.");

}

public static class UserProfileErrors
{
    public static readonly Error InvalidFullName = new ("UserProfile.InvalidFullName", "The full name is invalid.");
    public static readonly Error InvalidIdentificationNumber = new ("UserProfile.InvalidIdentificationNumber", "The identification number is invalid.");
    public static readonly Error InvalidIdentificationType = new ("UserProfile.InvalidIdentificationType", "The identification type is invalid.");
    public static readonly Error InvalidAddress = new ("UserProfile.InvalidAddress", "The address is invalid.");
    public static readonly Error InvalidCity = new ("UserProfile.InvalidCity", "The city is invalid.");
}