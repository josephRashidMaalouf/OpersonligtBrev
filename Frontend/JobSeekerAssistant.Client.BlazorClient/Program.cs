using JobSeekerAssistant.Client.Application.Interfaces;
using JobSeekerAssistant.Client.BlazorClient;
using JobSeekerAssistant.Client.BlazorClient.Identity;
using JobSeekerAssistant.Client.Infrastructure.DependecyInjection;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<CookieHandler>();

builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<AuthenticationStateProvider, CookieAuthenticationStateProvider>();

builder.Services.AddScoped(
    sp => (IAccountManagement)sp.GetRequiredService<AuthenticationStateProvider>());

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient(
        "JobSeekerAssistantApi",
        opt => opt.BaseAddress = new Uri("https://localhost:7137"))
    .AddHttpMessageHandler<CookieHandler>();

builder.Services.AddServices();

await builder.Build().RunAsync();
