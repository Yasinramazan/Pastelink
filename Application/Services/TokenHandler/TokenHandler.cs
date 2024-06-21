using Application.Abstractions.Token;
using Application.DTOs;
using Domain.Entities.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.TokenHandler
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token CreateAccessToken(AppUser user)
        {
            Token token= new();
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:IssuerSigningKey"]));

            SigningCredentials credentials= new(securityKey,SecurityAlgorithms.HmacSha256);
            token.ExpirationTime = DateTime.UtcNow.AddMinutes(5);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.ExpirationTime,
                notBefore:DateTime.UtcNow,
                signingCredentials:credentials,
                claims: new List<Claim>
                {
                    new(ClaimTypes.Name,user.Email)
                }
                );

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            token.AccessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
            return token;
           
        }
    }
}
