using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Blog.Infrastructure.Data;

namespace Blog.Infrastructure.Extensions.ServiceCollections
{
    public static class DbCtx
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            // services.AddDbContext<BlogDbContext>(x => x.UseNpgsql(configuration.GetConnectionString("AppDb")));
            services.AddDbContext<BlogDbContext>(x => x.UseNpgsql(configuration.GetConnectionString("AWS_RDS")));
            return services;
        }
    }
}