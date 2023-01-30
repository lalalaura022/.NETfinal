using Microsoft.AspNetCore.Authentication.JwtBearer;
using proiectfinaal2.Repositories;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace proiectfinaal2.Helpers
{
    public class SessionTokenValidator
    {
        public static async Task ValidateSessionToken(TokenValidatedContext context)
        {
            var repository = context.HttpContext.RequestServices.GetRequiredService<IRepositoryWrapper>();

            if (context.Principal.HasClaim(c => c.Type.Equals(JwtRegisteredClaimNames.Jti)))
            {
                var jti = context.Principal.Claims.FirstOrDefault(c => c.Type.Equals(JwtRegisteredClaimNames.Jti)).Value;

                var tokenInDb = await repository.SessionToken.GetByJTI(jti);
                if (tokenInDb != null && tokenInDb.ExpirationDate > DateTime.Now)
                {
                    return;
                }

            }

            context.Fail("");
        }
    }
}
