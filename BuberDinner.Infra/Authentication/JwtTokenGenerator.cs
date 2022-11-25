using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Infra.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProviderr;
    private readonly JwtSettings _jwtSettings;
    public JwtTokenGenerator(IDateTimeProvider dateTimeProviderr, IOptions<JwtSettings> jwtOptions)
    {
        _dateTimeProviderr = dateTimeProviderr;
        _jwtSettings = jwtOptions.Value;
    }

    public string GenerateToken(string userId, string firstName, string lastName)
    {
        var sininingCredentiasl = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256); 
        
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _dateTimeProviderr.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            claims: claims, 
            signingCredentials: sininingCredentiasl);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}