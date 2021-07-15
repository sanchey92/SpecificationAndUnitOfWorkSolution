using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Api.Extensions
{
    public static class StoreConnectionExtensions
    {
        public static IServiceCollection AddConnectionToDb(
            this IServiceCollection services, IConfiguration config)
        {
            var builder = new NpgsqlConnectionStringBuilder
            {
                ConnectionString = config.GetConnectionString("DefaultConnection"),
                Username = config["User ID"],
                Password = config["Password"]
            };

            services.AddDbContext<StoreContext>(options => options.UseNpgsql(builder.ConnectionString));

            return services;
        }
    }
}