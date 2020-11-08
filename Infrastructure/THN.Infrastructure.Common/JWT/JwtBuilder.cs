using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace THN.Infrastructure.Common.JWT
{
    public interface IJwtBuilder
    {
        JwtTokenReturnModel GetToken(string username);

        Guid ValidateToken(string token);
    }


    public class JwtBuilder : IJwtBuilder
    {
        private readonly JwtOptions _options;

        public JwtBuilder(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }

        public JwtTokenReturnModel GetToken(string username)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Secret));
            var singingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var claims = new Claim[]
            {
                new Claim("Username", username)
            };


            var expirationDate = DateTime.Now.AddMinutes(_options.ExpiryMinutes);
            var jwt = new JwtSecurityToken(claims: claims, signingCredentials: singingCredentials, expires: expirationDate);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);


            return new JwtTokenReturnModel
            {
                Token = encodedJwt,
                ExpirationDate = expirationDate,
                TokenTimeout = _options.ExpiryMinutes
            };

        }


        public Guid ValidateToken(string token)
        {
            var principal = GetPrincipal(token);
            if (principal == null)
                return Guid.Empty;

            ClaimsIdentity identity;

            try
            {
                identity = (ClaimsIdentity)principal.Identity;
            }catch(NullReferenceException)
            {
                return Guid.Empty;
            }

            var claimUsername = identity.FindFirst("Username");
            var userId = new Guid(claimUsername.Value);

            return userId;
        }


        private ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
                
                if (jwtToken == null)
                    return null;


                var key = Encoding.UTF8.GetBytes(_options.Secret);
                var parameters = new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };

                IdentityModelEventSource.ShowPII = true;
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, parameters, out SecurityToken securityToken);
                return principal;

            }catch
            {
                return null;
            }
        }
    }
}
