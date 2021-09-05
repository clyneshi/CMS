using CMS.BL.Services.Implementation;
using CMS.BL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CMS.BL.Utils
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IConferenceService, ConferenceService>();
            services.AddScoped<IKeywordService, KeywordService>();
            services.AddScoped<IPaperService, PaperService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserRequestService, UserRequestService>();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<IApplicationStrategy, ApplicationStrategy>();

            return services;
        }
    }
}
