using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace anti_scam_backend.Services
{
    public static class TokenService
    {
        private const double EXPIRE_HOURS = 12.0;
        public static string CreateToken(Domain.Entities.User user)
        {
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenHandler = new JwtSecurityTokenHandler();
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(GetClaims(user)),
                Expires = DateTime.UtcNow.AddHours(EXPIRE_HOURS),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }
        private static Claim[] GetClaims(Domain.Entities.User user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName.ToString()));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            if (user.IsAdmin)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));
            }
            if (user.RoleAdmins != null)
            {
                foreach(var role in user.RoleAdmins)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.Role.Name));
                }

            }
            
            return claims.ToArray();
        }
    }
}
