using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BuberDinner.Application.Common.Interfaces.Authentication;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Infra.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    public string GenerateToken(string userId, string firstName, string lastName)
    {
        var sininingCredentiasl = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super-secret-key")), SecurityAlgorithms.HmacSha256); 
        
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var securityToken = new JwtSecurityToken(
            issuer: "BuberDinner",
            expires: DateTime.Now.AddDays(1),
            claims: claims, 
            signingCredentials: sininingCredentiasl);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}