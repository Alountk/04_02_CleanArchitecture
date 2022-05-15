using Blog.Core.Interfaces;
using Blog.Infrastructure.Repositories;

namespace Blog.Api.Middleware
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