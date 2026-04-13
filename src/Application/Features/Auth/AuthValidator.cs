

using FluentValidation;
using Microsoft.AspNetCore.Identity.Data;

namespace ReservationsSystem.Application.Features.Auth;

public sealed class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Fullname)
        .NotEmpty().WithMessage("First name is required.")
        .MaximumLength(50).WithMessage("Firts name cannot exceed 50 characters.");

        RuleFor(x => x.Password)
        .NotEmpty().WithMessage("Password is required.")
        .MinimumLength(6).WithMessage
    }

}

public sealed class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Email)
    }
}