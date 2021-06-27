using Microsoft.Extensions.DependencyInjection;

namespace CMS.WinformUI.Utils
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddForms(this IServiceCollection services)
        {
            services.AddScoped<IFormUtil, FormUtil>();

            services.AddScoped<Login>();
            services.AddScoped<Register>();
            services.AddScoped<RequestValidate>();
            services.AddSingleton<Main>();
            services.AddScoped<ConferenceInfo>();
            services.AddScoped<ConferenceInfo_Admin>();
            services.AddScoped<LaunchConference>();
            services.AddScoped<AccountSetting>();
            services.AddScoped<AccountSetting_R>();
            services.AddScoped<PaperStatus>();
            services.AddScoped<AssignPaper>();
            services.AddScoped<ReviewPaper>();
            services.AddScoped<SubmitPaper>();
            services.AddScoped<RatingBox>();
            services.AddScoped<MakeDicision>();
            
            return services;
        }
    }
}
