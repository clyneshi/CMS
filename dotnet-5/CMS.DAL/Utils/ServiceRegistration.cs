using CMS.DAL.Core;
using CMS.DAL.Models;
using CMS.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace CMS.DAL.Utils;

public static class ServiceRegistration
{
    public static IServiceCollection AddUnitOfWork(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CmsDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // register all repositories 
        var assembly = typeof(IRepository).Assembly;
        var repositoryTypes = assembly.GetTypes().Where(t => t.IsClass && typeof(IRepository).IsAssignableFrom(t));

        foreach (var type in repositoryTypes)
        {
            services.AddScoped(typeof(IRepository), type);
        }

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
