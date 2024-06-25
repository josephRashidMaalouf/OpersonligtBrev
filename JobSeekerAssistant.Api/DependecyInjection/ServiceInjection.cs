using JobSeekerAssistant.Application.Interfaces.Services;
using JobSeekerAssistant.Application.Services;

namespace JobSeekerAssistant.Api.DependecyInjection;

public static class ServiceInjection
{
    public static IServiceCollection InjectServices(this IServiceCollection services)
    {
        services.AddScoped<ILetterService<string>, LetterService>();
        services.AddScoped<IResumeService<string>, ResumeService>();

        return services;
    }
}