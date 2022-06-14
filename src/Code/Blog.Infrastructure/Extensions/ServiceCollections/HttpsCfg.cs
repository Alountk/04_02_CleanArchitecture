using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infrastructure.Extensions.ServiceCollections
{
    public static class HttpsCfg
    {
        public static IServiceCollection AddHttps(this IServiceCollection services)
        {
            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(365);
            });
            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                options.HttpsPort = 7071;
            });
            return services;
        }
    }
}