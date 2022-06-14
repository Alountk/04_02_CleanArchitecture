using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Blog.Infrastructure.Extensions.ApplicationBuilder
{
    public static class DefaultCfg
    {
        public static void InitConfigurationAPI(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            // app.UseCors(x => x
            //     .AllowAnyOrigin()
            //     .AllowAnyMethod()
            //     .AllowAnyHeader()
            // );
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("MyPolicy");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
