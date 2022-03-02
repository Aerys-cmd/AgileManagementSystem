using AgileManagement.Infrastructure.Notification.Smtp;
using AgileManagementSystem.Core.Authentication;
using AgileManagementSystem.Core.Domain;
using AgileManagementSystem.Core.Notification;
using AgileManagementSystem.Core.Security;
using AgileManagementSystem.Infrastructure.Events;
using AgileManagementSystem.Infrastructure.Security.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Infrastructure
{
    public static class InfrastructureModule
    {
        public static void Load(IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton<IDomainEventDispatcher, NetCoreEventDispatcher>();
            // konfigürasyon, yardımcı servis gibi tek instance ile çalışabilen yapılar için singleton tercih edelim
            services.AddSingleton<IEmailService, NetSmtpEmailService>();
            // veri tabanı , servis çağırısı, api çağırısı gibi işlemler için scoped tercih edelim

            services.AddSingleton<ITokenService, JwtTokenService>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.SaveToken = true;// token sessionda tutumamızı sağlar
                //opt.Audience = Configuration["JWT:audience"];

                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = true, // yanlış audince gönderirse token kabul etme
                    ValidateIssuer = true, // access tokendan yanlış issuer gelirse validate etme
                    ValidateIssuerSigningKey = true, // çok önemli signkey validate etmemiz lazım
                    ValidateLifetime = true, // token yaşam süresini kontrol et
                    ValidIssuer = configuration["JWT:issuer"], // valid issuer değeri
                    ValidAudience = configuration["JWT:audience"], // valid audience değeri
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:signingKey"])),

                };
            });

        }
    }
}
