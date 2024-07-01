using JobSeekerAssistant.Client.Domain.Dtos;

namespace JobSeekerAssistant.Client.Application.Interfaces;

public interface IAccountManagement
{
    public Task<AuthResponse> LoginAsync(string email, string password);

    public Task LogoutAsync();

    public Task<AuthResponse> RegisterAsync(string email, string password);

    public Task<bool> CheckAuthenticatedAsync();

    Task<string> GetUserEmailAsync();
}