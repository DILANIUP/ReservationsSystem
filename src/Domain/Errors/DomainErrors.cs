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