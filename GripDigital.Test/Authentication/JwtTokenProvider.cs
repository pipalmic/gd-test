using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GripDigital.Test.Authentication.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace GripDigital.Test.Authentication
{
    public class JwtTokenProvider : ITokenProvider
    {
        private readonly SigningCredentials _signingCredentials;
        private readonly AuthenticationConfig _authenticationConfig;
        
        public JwtTokenProvider(AuthenticationConfig config)
        {
            _authenticationConfig = config;
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Key));
            _signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
        }
        
        public string GenerateToken(string userName)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateJwtSecurityToken(new SecurityTokenDescriptor()
            {
                Issuer = _authenticationConfig.Issuer,
                Audience = _authenticationConfig.Audience,
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = _signingCredentials,
                Claims = new Dictionary<string, object>
                {
                    [ClaimTypes.NameIdentifier] = userName
                }
            });

            return handler.WriteToken(token)!;
        }
    }
}