namespace JobSeekerAssistant.Client.Domain.Dtos;

public class AuthResponse
{
    public bool Succeeded { get; set; }

    public string[] ErrorList { get; set; } = [];
}