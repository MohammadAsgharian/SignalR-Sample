using Microsoft.IdentityModel.Tokens;
using SignalR_Sample.WebApi.Configurations;
using SignalR_Sample.WebApi.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SignalR_Sample.WebApi.Application
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSettings jwtSettings;

        /// <summary>
        /// Constructor of JwtTokenGenerator Class 
        /// </summary>
        /// <param name="_jwtSettings"></param>
        public JwtTokenGenerator(JwtSettings _jwtSettings) =>
            this.jwtSettings = _jwtSettings;



        ///Generate Refresh Token
        public string GenerateRefreshToken()
        {
            //var expirationTime = DateTime.UtcNow.AddSeconds(jwtSettings.JWTLifespan);
            Guid newGUID = Guid.NewGuid();
            return newGUID.ToString();

        }

        /// Generate Token
        public string GenerateToken(
            long PersonId,
            string UserName)
        {
            //var expirationTime = DateTime.UtcNow.AddSeconds(jwtSettings.JWTLifespan);

            var signingCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.JWTSecretKey)),
                    SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                    new Claim(ClaimTypes.Name, UserName),
                   };
            var securityToken = new JwtSecurityToken(
                expires: DateTime.UtcNow.AddMinutes(jwtSettings.JWTLifespan),
                claims: claims,
                signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }

}
