

using ReservationsSystem.Domain.Entities;
using ReservationsSystem.Domain.Errors;
using ReservationsSystem.Domain.Interfaces;
using ReservationsSystem.Domain.Primitives;
using ReservationsSystem.Domain.ValueObjects;
using ReservationsSystem.Infrastructure.Authentication;

namespace ReservationsSystem.Application.Features.Auth
{
    public class AuthService(
        IUserRepository userRepository,
        IUserProfileRepository userProfileRepository,
        IRefreshTokenRepository refreshTokenRepository,
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher,
        ITokenService tokenService,
        RegisterRequestValidator registerValidator,
        LoginRequestValidator loginValidator
    )
    {
        public async Task<Result<RegisterResponse>> RegisterAsync(RegisterRequest request, CancellationToken ct)
        {
            var validation = await registerValidator.ValidateAsync(request, ct);
            
            if (!validation.IsValid)
            {
                var failure = validation.Errors[0];
                return Result.Failure<RegisterResponse>(Error.Validation(failure.PropertyName, failure.ErrorMessage));
            }

            if (await userRepository.ExistsByEmailAsync(request.Email, ct))
                return Result.Failure<RegisterResponse>(UserErrors.EmailAlreadyInUse);

            var emailResult = Email.Create(request.Email);
            if (emailResult.IsFailure)
                return Result.Failure<RegisterResponse>(emailResult.Error);

            var passwordHash = passwordHasher.Hash(request.Password);
            var userResult = User.Create(emailResult.Value, passwordHash);
            if (userResult.IsFailure)
                return Result.Failure<RegisterResponse>(userResult.Error);

            Address? address = null;
            if (request.Street is not null && request.City is not null)
            {
                var addressResult = Address.Create(request.Street, request.City, request.PostalCode);
                if (addressResult.IsFailure)
                    return Result.Failure<RegisterResponse>(addressResult.Error);

                address = addressResult.Value;
            }

            var userProfileResult = UserProfile.Create(userResult.Value.Id, request.Fullname, request.Phone, request.IdentificationNumber, request.IdentificationType, address);
            if (userProfileResult.IsFailure)
                return Result.Failure<RegisterResponse>(userProfileResult.Error);

            userRepository.Add(userResult.Value);
            userProfileRepository.Create(userProfileResult.Value);
            await unitOfWork.SaveChangesAsync(ct);

            return new RegisterResponse(userResult.Value.Id, userResult.Value.Email.Value, userProfileResult.Value.FullName);
        }


        public async Task<Result<LoginResponse>> LoginAsync(LoginRequest request, CancellationToken ct)
        {
            var validation = await loginValidator.ValidateAsync(request, ct);
            if (!validation.IsValid)
            {
                var failure = validation.Errors[0];
                return Result.Failure<LoginResponse>(Error.Validation(failure.PropertyName , failure.ErrorMessage));
            }

            var user = await userRepository.GetByEmailAsync(request.Email, ct);
            if (user is null)
                return Result.Failure<LoginResponse>(UserErrors.InvalidCredentials);

            if (!passwordHasher.Verify(request.Password, user.PasswordHash))
                return Result.Failure<LoginResponse>(UserErrors.InvalidCredentials);

            var accessToken = tokenService.GenerateAccessToken(user);
            var refreshTokenValue =tokenService.GenerateRefreshToken();

            var refreshToken = RefreshToken.Create(
                user.Id,
                refreshTokenValue,
                DateTime.UtcNow.AddDays(7));
            
            refreshTokenRepository.Create(refreshToken);
            await unitOfWork.SaveChangesAsync(ct);
            return new LoginResponse(user.Id,accessToken,refreshTokenValue);

        }
        
    }
}