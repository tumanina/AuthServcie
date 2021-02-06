using Microsoft.IdentityModel.Tokens;
using AuthService.Common.Enums;
using System.IdentityModel.Tokens.Jwt;

namespace AuthService.Common.Interfaces.Security
{
    public interface ISecurityService
    {
        SecurityTypeEnum Type { get; }

        string GenerateToken(JwtPayload payload);

        SecurityKey GetSecurityKey();
    }
}
