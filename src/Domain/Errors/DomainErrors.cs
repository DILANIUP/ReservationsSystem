namespace ReservationsSystem.Domain.Errors;

using ReservationsSystem.Domain.Primitives;

public static class AdditionalServiceErrors
{
    public static readonly Error InvalidName =
        new("AdditionalService.InvalidName", "The name of the additional service is invalid.");

    public static readonly Error InvalidPriceForFreeService = new("AdditionalService.InvalidPriceForFreeService",
        "The price of a free additional service must be null.");

    public static readonly Error InvalidPriceForPaidService = new("AdditionalService.InvalidPriceForPaidService",
        "The price of a paid additional service must be provided and valid.");
}

public static class CatalogueErrors
{
    public static readonly Error InvalidName = new("Catalogue.InvalidName", "The name of the catalogue is invalid.");
}

public static class ExceptionDateErrors
{
    public static readonly Error InvalidResourceId =
        new("ExceptionDate.InvalidResourceId", "The resource ID of the exception date is invalid.");

    public static readonly Error InvalidDate =
        new("ExceptionDate.InvalidDate", "The date of the exception date is invalid.");
}

public static class FlatErrors
{
    public static readonly Error InvalidFlatNumber =
        new("Flat.InvalidFlatNumber", "The flat number must be greater than zero.");

    public static readonly Error InvalidRestaurantId =
        new("Flat.InvalidRestaurantId", "The restaurant ID of the flat is invalid.");
}

public static class MenuErrors
{
    public static readonly Error InvalidRestaurantId =
        new("Menu.InvalidRestaurantId", "The restaurant ID of the menu is invalid.");

    public static readonly Error InvalidCategoryId =
        new("Menu.InvalidCategoryId", "The category ID of the menu is invalid.");

    public static readonly Error InvalidName = new("Menu.InvalidName", "Menu name is invalid.");
}

public static class MenuItemErrors
{
    public static readonly Error InvalidName = new("MenuItem.InvalidName", "Menuitem name is required.");

    public static readonly Error InvalidCategoryId =
        new("MenuItem.InvalidCategoryId", "The category ID of the menu is invalid.");
}

public static class ReservationsErrors
{
    public static readonly Error InvalidUserId =
        new("Reservation.InvalidUserId", "The user ID of the reservation is invalid.");

    public static readonly Error InvalidResourceId =
        new("Reservation.InvalidResourceId", "The resource ID of the reservation is invalid.");

    public static readonly Error InvalidDate = new("Reservation.InvalidDate",
        "The date of the reservation must be greater than the current date.");

    public static readonly Error InvalidTimeRange = new("Reservation.InvalidTimeRange",
        "The reservation start time must be earlier than the end time.");

    public static readonly Error InvalidReservationSlot = new("Reservation.InvalidReservationSlot",
        "The reservation slot is required.");

    public static readonly Error InvalidTotalAmount = new("Reservation.InvalidTotalAmount",
        "The reservation total amount is required.");

    public static readonly Error InvalidGuestCount = new("Reservation.InvalidGuestCount",
        "The reservation guest count must be greater than zero.");

    public static readonly Error InvalidAdvancedPayment = new("Reservation.InvalidAdvancedPayment",
        "The advanced payment cannot exceed the total amount and must use the same currency.");

    public static readonly Error AlreadyCancelled = new("Reservation.AlreadyCancelled",
        "The reservation is already cancelled.");

    public static readonly Error CannotCancelFinalizedReservation = new("Reservation.CannotCancelFinalizedReservation",
        "A completed or rejected reservation cannot be cancelled.");

    public static readonly Error AlreadyConfirmed = new("Reservation.AlreadyConfirmed",
        "The reservation is already confirmed.");

    public static readonly Error CannotConfirmReservation = new("Reservation.CannotConfirmReservation",
        "Only pending reservations can be confirmed.");

    public static readonly Error AlreadyCompleted = new("Reservation.AlreadyCompleted",
        "The reservation is already completed.");

    public static readonly Error CannotCompleteReservation = new("Reservation.CannotCompleteReservation",
        "Only confirmed reservations can be completed.");

    public static readonly Error AlreadyRejected = new("Reservation.AlreadyRejected",
        "The reservation is already rejected.");

    public static readonly Error CannotRejectReservation = new("Reservation.CannotRejectReservation",
        "Only pending reservations can be rejected.");
}

public static class ReservationServiceErrors
{
    public static readonly Error InvalidReservationId = new Error("Reservation.InvalidReservationId",
        "The reservation ID of the reservation service is invalid.");

    public static readonly Error AdditionalServiceId = new Error("Reservation.AdditionalServiceId",
        "The additional service ID of the reservation service is invalid.");

    public static readonly Error AlreadyDeleted = new Error(
    "ReservationService.AlreadyDeleted",
    "The reservation service has already been deleted.");
}

public static class ResourceErrors
{
    public static readonly Error InvalidRestaurantId =
        new("Resource.InvalidRestaurantId", "The restaurant ID of the resource is invalid.");

    public static readonly Error InvalidHotelId = new("Resource.HotelId", "The Hotel ID of the resource is invalid.");

    public static readonly Error InvalidEventVenueId =
        new("Resource.EventVenueId", "The Event venue ID of the resource is invalid.");

    public static readonly Error MultipleOwnerEntities =
        new("Resource.MultipleOwnerEntities", "The resource can only belong to one entity.");

    public static readonly Error NoOwnerEntity =
        new("Resource.NoOwnerEntity", "The resource must belong to at least one entity.");

    public static readonly Error InvalidName =
        new("Resource.InvalidName", "Resource name is required.");

    public static readonly Error InvalidPhone = new("Resource.InvalidPhone", "Phone number is required.");

    public static readonly Error AlreadyActive = new("Resource.AlreadyActive", "The resource is already active.");
    public static readonly Error AlreadyInactive = new("Resource.AlreadyInactive", "The resource is already inactive.");
}
public static class ReviewErrors
{
    public static readonly Error InvalidRating = new("Review.InvalidRating", "The rating must be between 1 and 5.");
    public static readonly Error InvalidUserId = new("Review.InvalidUserId", "The user ID of the review is invalid.");
    public static readonly Error InvalidResourceId = new("Review.InvalidResourceId", "The resource ID of the review is invalid.");
}

public static class RoleErrors
{
    public static readonly Error InvalidName = new("Role.InvalidName", "The name of the role is invalid.");
}

public static class ScheduleErrors
{
    public static readonly Error InvalidTimeRange = new("Schedule.InvalidTimeRange", "The open time must be before the close time.");
    public static readonly Error InvalidResourceId = new("Schedule.InvalidResourceId", "The resource ID of the schedule is invalid.");
}

public static class TableErrors
{
    public static readonly Error InvalidRestaurantId = new("Table.InvalidRestaurantId", "The restaurant ID of the table is invalid.");
    public static readonly Error InvalidCapacity = new("Table.InvalidCapacity", "The capacity of the table must be greater than zero.");
    public static readonly Error InvalidLocation = new("Table.InvalidLocation", "The location of the table is invalid.");
    public static readonly Error InvalidTableNumber = new("Table.InvalidTableNumber", "The table number must be greater than zero.");
}

public static class UserErrors
{
    public static readonly Error InvalidEmail = new("User.InvalidEmail", "The email address is invalid.");
    public static readonly Error InvalidPasswordHash = new("User.InvalidPasswordHash", "The password hash is invalid.");
    public static readonly Error InvalidRole = new("User.InvalidRole", "The role is invalid.");

}

public static class UserProfileErrors
{
    public static readonly Error InvalidFullName = new("UserProfile.InvalidFullName", "The full name is invalid.");
    public static readonly Error InvalidIdentificationNumber = new("UserProfile.InvalidIdentificationNumber", "The identification number is invalid.");
    public static readonly Error InvalidIdentificationType = new("UserProfile.InvalidIdentificationType", "The identification type is invalid.");
    public static readonly Error InvalidAddress = new("UserProfile.InvalidAddress", "The address is invalid.");
    public static readonly Error InvalidCity = new("UserProfile.InvalidCity", "The city is invalid.");
}
public static class RestaurantErrors
{
    public static readonly Error InvalidResourceId = new("Restaurant.InvalidResourceId", "The resource ID of the restaurant is invalid.");
}