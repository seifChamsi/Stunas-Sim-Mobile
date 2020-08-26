using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StunasMobile.api.Extensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using StunasMobile.Data;
using StunasMobile.Data.DbContext;
using StunasMobile.Data.Repositories;
using StunasMobile.Entities.Entitites;

namespace StunasMobile.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddScoped<IMobileRepository, MobileRepository>();
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );;
            
            //Db context setyp
            services.AddDbContext<StunasDBContext>(op =>
            {
                op.UseNpgsql("Host=localhost;Database=StunasDB;Username=postgres;Password=MyDbPassword");
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddJWTAuthentification(Configuration);
            // Swagger
            services.AddSwaggerSecurity();

            services.AddCors(options =>
            {
                options.AddPolicy("myPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyHeader().AllowAnyMethod());
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            /*app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
            );*/
            // Use Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Stunas V0");
            });

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("myPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}