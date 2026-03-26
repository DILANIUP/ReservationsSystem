namespace ReservationsSystem.Domain.Errors;
using ReservationsSystem.Domain.Primitives;

public static class AdditionalServiceErrors
{
    public static readonly Error InvalidName = new ("AdditionalService.InvalidName", "The name of the additional service is invalid.");
    public static readonly Error InvalidPriceForFreeService = new ("AdditionalService.InvalidPriceForFreeService", "The price of a free additional service must be null.");
    public static readonly Error InvalidPriceForPaidService = new ("AdditionalService.InvalidPriceForPaidService", "The price of a paid additional service must be provided and valid.");
}