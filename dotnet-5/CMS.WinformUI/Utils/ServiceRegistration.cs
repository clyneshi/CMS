using Microsoft.Extensions.DependencyInjection;

namespace CMS.WinformUI.Utils;

public static class ServiceRegistration
{
    public static IServiceCollection AddForms(this IServiceCollection services)
    {
        services.AddScoped<IFormUtil, FormUtil>();

        // AddTransient - Always returns a new instance since the scope will not change
        // in the life time of the application
        // https://marcominerva.wordpress.com/2020/03/09/using-hostbuilder-serviceprovider-and-dependency-injection-with-windows-forms-on-net-core-3/
        services.AddTransient<LoginForm>();
        services.AddTransient<RegisterUserForm>();
        services.AddTransient<ReviewRegistrationRequestForm>();
        services.AddTransient<HomeForm>();
        services.AddTransient<ConferenceInfoForm>();
        services.AddTransient<ConferenceInfoAdminForm>();
        services.AddTransient<LaunchConferenceForm>();
        services.AddTransient<AccountSettingForm>();
        services.AddTransient<AccountSettingReviewerForm>();
        services.AddTransient<PaperFeedbackForm>();
        services.AddTransient<AssignPaperForm>();
        services.AddTransient<ReviewPaperForm>();
        services.AddTransient<SubmitPaperForm>();
        services.AddTransient<RatingBoxForm>();
        services.AddTransient<MakeDecisionForm>();
        
        return services;
    }
}
