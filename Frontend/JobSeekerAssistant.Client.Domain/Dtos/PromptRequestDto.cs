namespace JobSeekerAssistant.Client.Domain.Dtos;

public class PromptRequestDto
{
    public string Language { get; set; } = "svenska";
    public JobDto JobDto { get; set; } = new();
}