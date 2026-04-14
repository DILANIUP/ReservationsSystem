using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ReservationsSystem.Domain.Entities;

namespace ReservationsSystem.Infrastructure.Authentication;

public sealed class JwtTokenService(IOptions<JwtSettings> settings) : ITokenService
{
    private readonly JwtSettings _settings = settings.Value;

    public string GenerateAccessToken(User user)
    {
        var claims = new List<Claim> // !important: información dentro del token 
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email.Value),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //jwt token identificador
        };

        foreach (var role in user.Roles)
            claims.Add(new Claim(ClaimTypes.Role, role.Code.ToString()));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _settings.Issuer, //quien emite el token
            audience: _settings.Audience, // quien puede usarlo
            claims: claims,//info del usuario
            expires: DateTime.UtcNow.AddMinutes(_settings.ExpirationMinutes), // expiraci;ón
            signingCredentials: credentials //credenciales para firmar el token 
        );
        return new JwtSecurityTokenHandler().WriteToken(token); // convierte a string el token
    }

    public string GenerateRefreshToken()
    {
        var bytes = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(bytes);
        return Convert.ToBase64String(bytes); // convierte en string en base64
    }
}