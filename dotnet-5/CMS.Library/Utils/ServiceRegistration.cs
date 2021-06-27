using CMS.DAL.Core;
using CMS.BL.Services.Implementation;
using CMS.BL.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace CMS.BL.Utils
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IConferenceService, ConferenceService>();
            services.AddScoped<IKeywordService, KeywordService>();
            services.AddScoped<IPaperService, PaperService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserRequestService, UserRequestService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IApplicationStrategy, ApplicationStrategy>();
            return services;
        }
    }
}
