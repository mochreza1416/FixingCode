using AuthDocument.Context;
using AuthDocument.Service;
using Microsoft.AspNetCore.Http.Features;

namespace AuthDocument
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            // Service
            services.AddScoped<IAccessService, AccessService>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddDbContext<DatabaseContext>();
            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 209715200; // Adjust the limit as needed (in bytes)
            });
            return services;
        }
    }
}
