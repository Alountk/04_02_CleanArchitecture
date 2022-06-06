using Blog.Core.Interfaces;
using Blog.Infrastructure.Repositories;
using Blog.Infrastructure.Services;
using Blog.Infrastructure.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infrastructure.Extensions.ServiceCollections
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPostCommentRepository, PostCommentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            return services;
        }
    }
}