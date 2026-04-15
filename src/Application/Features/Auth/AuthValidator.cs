

using FluentValidation;
using Microsoft.AspNetCore.Identity.Data;

namespace ReservationsSystem.Application.Features.Auth;

public sealed class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Fullname)
        .NotEmpty().WithMessage("First name is required.")
        .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

        RuleFor(x => x.Password)
        .NotEmpty().WithMessage("Password is required.")
        .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
        .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
        .Matches("[0-9]").WithMessage("Password must contain at least one number.");

        RuleFor(x => x.IdentificationNumber)
        .NotEmpty().WithMessage("Identification Number is required");

        RuleFor(x => x.IdentificationType)
        .NotEmpty().WithMessage("Identification Type is required");
    }

}

public sealed class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Email)
        .NotEmpty().WithMessage("Email is required")
        .EmailAddress().WithMessage("Email format is invalid");

        RuleFor(x => x.Password)
        .NotEmpty().WithMessage("Password is required");

    }
}