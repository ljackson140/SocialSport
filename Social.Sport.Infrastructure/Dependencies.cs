using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Social.Sport.Core.Interfaces.Data;
using Social.Sport.Infrastructure.Data;
using System.Text;
using static Social.Sport.Core.Constants.ConstantConfig;

namespace Social.Sport.Infrastructure
{
    public static class Dependencies
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var useInMemoryDatabase = bool.Parse(configuration[APIConfig.UseInMemoryDatabaseKey]);
            if (useInMemoryDatabase)
            {
                services.AddDbContext<AppDbContext>(x => x.UseInMemoryDatabase(APIConfig.InMemoryDatabase));
            }
            else
            {
                services.AddDbContext<AppDbContext>(x => x.UseSqlServer(APIConfig.ConnectionStringKey));
            };

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ILogService, LogService>
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
