using AgileManagementSystem.Application;
using AgileManagementSystem.Domain;
using AgileManagementSystem.Infrastructure;
using AgileManagementSystem.Persistence.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileManagementSystem.WebAPI
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AgileManagementSystem.WebAPI", Version = "v1" });
            });
            services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyMethod(); // GET,POST apida a��k, HTTPDELETE, HTTPUT i�inde a�m�� olduk; 415 hatas�da HttpMethod izni verilmemi�tir.
                    policy.AllowAnyOrigin(); // Herhangi bir domaine istek atabiliriz.
                    //policy.WithOrigins("www.a.com", "www.b.com");
                    policy.AllowAnyHeader(); // Application/json appliation/xml
                    //policy.WithHeaders("x-token"); // Application/json appliation/xml
                });
            });
            ApplicationModule.Load(services);
            InfrastructureModule.Load(services, Configuration);
            EFModule.Load(services, Configuration);
            DomainModule.Load(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AgileManagementSystem.WebAPI v1"));
            }

            app.UseHttpsRedirection();
            app.UseCors();
            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
