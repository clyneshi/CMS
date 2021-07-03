using Microsoft.Extensions.DependencyInjection;

namespace CMS.WinformUI.Utils
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddForms(this IServiceCollection services)
        {
            services.AddScoped<IFormUtil, FormUtil>();

            // AddTransient - Always returns a new instance since the scope will not change
            // in the life time of the application
            // https://marcominerva.wordpress.com/2020/03/09/using-hostbuilder-serviceprovider-and-dependency-injection-with-windows-forms-on-net-core-3/
            services.AddTransient<Login>();
            services.AddTransient<Register>();
            services.AddTransient<RequestValidate>();
            services.AddTransient<Main>();
            services.AddTransient<ConferenceInfo>();
            services.AddTransient<ConferenceInfo_Admin>();
            services.AddTransient<LaunchConference>();
            services.AddTransient<AccountSetting>();
            services.AddTransient<AccountSetting_R>();
            services.AddTransient<PaperStatus>();
            services.AddTransient<AssignPaper>();
            services.AddTransient<ReviewPaper>();
            services.AddTransient<SubmitPaper>();
            services.AddTransient<RatingBox>();
            services.AddTransient<MakeDecision>();
            
            return services;
        }
    }
}
