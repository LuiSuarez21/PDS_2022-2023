using BuildMe.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BuildMe.Infrastructure.Services
{
    public class JwtService
    {
        private const int EXPIRATION_MINUTES = 60;

        //private readonly IConfiguration _configuration;

        public JwtService(
            //IConfiguration configuration, 
            //IOptions<JwtOptions> jwtOptions
            )
        {
            //_configuration = configuration;
        }

        public DomainAuthenticationResponse CreateToken(User user)
        {
            var expiration = DateTime.Now.AddMinutes(EXPIRATION_MINUTES);

            //var claims = new Claim[] 
            //{
            //    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            //    new Claim(JwtRegisteredClaimNames.Email, user.Email)
            //};

            //var signingCredentials = new SigningCredentials(
            //    new SymmetricSecurityKey(
            //        Encoding.UTF8.GetBytes(_jwtOptions.SecurityKey)),
            //    SecurityAlgorithms.HmacSha256); 

            //var token = new JwtSecurityToken(
            //    _jwtOptions.Issuer,
            //    _jwtOptions.Audience,
            //    claims,
            //    null,
            //    expiration,
            //    signingCredentials);

            //string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            //var expiration = DateTime.Now.AddMinutes(EXPIRATION_MINUTES);

            //var token = CreateJwtToken(
            //    CreateClaims(user),
            //    CreateSigningCredentials(),
            //    expiration
            //);

            //var tokenHandler = new JwtSecurityTokenHandler();

            return new DomainAuthenticationResponse
            {
                Token = "",
                Expiration = expiration
            };
        }

        //private JwtSecurityToken CreateJwtToken(Claim[] claims, SigningCredentials credentials, DateTime expiration) =>
        //    new JwtSecurityToken(
        //        _configuration["Jwt:Issuer"],
        //        _configuration["Jwt:Audience"],
        //        claims,
        //        expires: expiration,
        //        signingCredentials: credentials
        //    );

        //private Claim[] CreateClaims(IdentityUser user) =>
        //    new[] {
        //        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
        //        new Claim(ClaimTypes.NameIdentifier, user.Id),
        //        new Claim(ClaimTypes.Name, user.UserName),
        //        new Claim(ClaimTypes.Email, user.Email)
        //    };

        //private SigningCredentials CreateSigningCredentials() =>
        //    new SigningCredentials(
        //        new SymmetricSecurityKey(
        //            Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])
        //        ),
        //        SecurityAlgorithms.HmacSha256
        //    );
    }
}