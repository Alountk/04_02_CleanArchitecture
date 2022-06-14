using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

using FluentValidation.AspNetCore;

using Blog.Infrastructure.Filters;

namespace Blog.Infrastructure.Extensions.ServiceCollections
{
    public static class CtrlCfg
    {
        public static IServiceCollection AddControllersExtend(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<GlobalValidationFilterAttribute>();
            })
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            })
            .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                    options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;
                    options.UseCamelCasing(false);
                }
            ).AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });
            return services;
        }
        public static IServiceCollection AddCORS(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "MyPolicy", builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });
            return services;
        }
    }

}