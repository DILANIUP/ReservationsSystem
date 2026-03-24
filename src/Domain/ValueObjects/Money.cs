using ReservationsSystem.Domain.Primitives;

namespace ReservationsSystem.Domain.ValueObjects;

public sealed class Money : IEquatable<Money>
{
    public const string DefaultCurrency = "USD";

    public decimal Amount { get; private set; }
    public string Currency { get; private set; } = default!;

    private Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    private Money() { }


    public static Result<Money> Create(decimal amount, string? currency = DefaultCurrency)
    {
        if (amount < 0)
            return Result.Failure<Money>(new Error("Money.NegativeAmount", "Amount cannot be negative."));

        if (string.IsNullOrWhiteSpace(currency) || currency.Length != 3)
            return Result.Failure<Money>(new Error("Money.InvalidCurrency", "Currency must be a valid 3-letter ISO code."));

        return new Money(Math.Round(amount, 2), currency.ToUpperInvariant());
    }

    // La diferencia con Create() es que Of() no retorna Result<Money>, 
    // retorna Money directamente.Existe para uso interno del dominio donde los valores ya fueron validados previamente 
    // y crear un Result sería redundante.
    /// <summary>Factory without Result for internal domain use where values are already validated.</summary>
    public static Money Of(decimal amount, string currency = DefaultCurrency) =>
        new(Math.Round(amount, 2), currency.ToUpperInvariant()); // convert to uppercase for consistency based on worldwide rules avoiding issues with the locale of the server

    public Money Add(Money other)
    {
        EnsureSameCurrency(other);
        return new Money(Amount + other.Amount, Currency);
    }

    public Money Multiply(int factor) =>
        new(Math.Round(Amount * factor, 2), Currency);

    public bool Equals(Money? other) =>
        other is not null && Amount == other.Amount && Currency == other.Currency;

    public override bool Equals(object? obj) => obj is Money money && Equals(money);
    public override int GetHashCode() => HashCode.Combine(Amount, Currency);
    public override string ToString() => $"{Amount:F2} {Currency}";

    private void EnsureSameCurrency(Money other)
    {
        if (Currency != other.Currency)
            throw new InvalidOperationException($"Cannot operate on different currencies: {Currency} vs {other.Currency}");
    }
}