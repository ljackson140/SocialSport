﻿using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Social.Sport.Core.Interfaces.Data;
using Social.Sport.Core.Interfaces.Services;
using Social.Sport.Core.Services;
using Social.Sport.Infrastructure.Data;
using System.Configuration;
using System.Text;
using static Social.Sport.Core.Constants.ConstantConfig;

namespace Social.Sport.Infrastructure
{
    public static class Dependencies
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {           

            services.AddDbContext<AppDbContext>(c => c.UseSqlServer(configuration[APIConfig.ConnectionStringKey]));

            services.AddScoped(typeof(IAuthenticateTokenService), typeof(AuthenticateTokenService));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(ISignUpInfoService), typeof(SignUpInfoService));
            services.AddScoped<ILogService, LogService>(
                    serviceProvider => new LogService(
                        options: serviceProvider.GetRequiredService<IOptions<TelemetryConfiguration>>())
                );
            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddAuthentication(AuthenticateTokenMessages.HoldKey)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration[AuthenticateTokenMessages.Issuer],
                        ValidAudience = configuration[AuthenticateTokenMessages.Audience],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.ASCII.GetBytes(configuration[AuthenticateTokenMessages.SecretKey]))
                    };
                });
            return services.AddJwtAuthentication(configuration);
        }
    }
}
