using JobSeekerAssistant.Client.Domain.Interfaces;

namespace JobSeekerAssistant.Client.Domain.Models;

public class LetterModel : IModel<string>
{
    public string Id { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;
}