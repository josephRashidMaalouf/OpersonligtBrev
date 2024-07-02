using JobSeekerAssistant.Client.Application.Interfaces;
using JobSeekerAssistant.Client.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace JobSeekerAssistant.Client.Infrastructure.DependecyInjection;

public static class ServiceInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ILetterService, LetterService>();
        services.AddScoped<IResumeService, ResumeService>();

        return services;
    }
}