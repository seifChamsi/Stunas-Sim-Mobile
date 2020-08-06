using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;

namespace StunasMobile.api.Extensions
{
   public static class ConfigureSwaggerExtension
      {
          public static IServiceCollection AddSwaggerSecurity(this IServiceCollection services)
          {
              return services.AddSwaggerGen(c =>
              {
  
                  c.SwaggerDoc("v1", new OpenApiInfo{Title = "StunasAPI",Version = "v1"});
                  c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                  {
                      In = ParameterLocation.Header,
                      Description = "Please enter into field the word 'Bearer' following by space and JWT",
                      Name = "Authorization",
                      Type = SecuritySchemeType.ApiKey
                  });
                  c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                      {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              },
                              Scheme = "oauth2",
                              Name = "Bearer",
                              In = ParameterLocation.Header,

                          },
                          new List<string>()
                      }
                  });
  
              });
          }
      }
}