using Blog.Core.Interfaces;
using Blog.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infrastructure.Extensions.ServiceCollections
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            return services;
        }
    }
}