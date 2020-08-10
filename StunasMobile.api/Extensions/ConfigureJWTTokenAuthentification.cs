using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StunasMobile.api.Extensions
{
    public static class  ConfigureJWTTokenAuthentification
    {
        public static AuthenticationBuilder AddJWTAuthentification(this IServiceCollection services, IConfiguration configuration)
        {
            // remove default claims
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            return services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer(cfg =>
                {
               
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        
                        ValidIssuer = "http://localhost:5001",
                        ValidAudience = "http://localhost:4200",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SOME_RANDOM_KEY_DO_NOT_SHARE")),
                        
                    };
                });
        }
    }
}

