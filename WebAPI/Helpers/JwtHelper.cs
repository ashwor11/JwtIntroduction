using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Models;

namespace WebAPI.Helpers
{
    public static class JwtHelper
    {
        public static string CreateJwtToken(User user)
        {
            string issuer = "kerimyildirim.com";
            string audience = "thismyaudience.com";
            List<Claim> claims = new List<Claim>(); //using System.Security.Claims;
            Claim claim1 = new(ClaimTypes.Name, user.Name);
            Claim claim2 = new(ClaimTypes.NameIdentifier, user.Id.ToString());
            Claim claim3 = new(ClaimTypes.Email, user.Email);
            Claim claim4 = new(ClaimTypes.Role, "admin");
            claims.Add(claim1);
            claims.Add(claim2);
            claims.Add(claim3);
            claims.Add(claim4);
            DateTime notBefore = DateTime.UtcNow;
            DateTime expires = DateTime.UtcNow.AddMinutes(10);

            string secretKey = "myverysecretkey1";

            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha512Signature);


            JwtSecurityToken token = new JwtSecurityToken(issuer,audience,claims,notBefore,expires,signingCredentials);

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            return jwtSecurityTokenHandler.WriteToken(token);
        }
    }
}
