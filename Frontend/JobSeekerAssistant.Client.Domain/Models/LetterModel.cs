using JobSeekerAssistant.Client.Domain.Interfaces;

namespace JobSeekerAssistant.Client.Domain.Models;

public class LetterModel : IModel<string>
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public string UserId { get; set; }
}