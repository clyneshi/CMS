using CMS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CMS.DAL.Utils
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddCMSDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CMSContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
