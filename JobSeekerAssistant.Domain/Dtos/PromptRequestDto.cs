namespace JobSeekerAssistant.Domain.Dtos;

public class PromptRequestDto
{
    public string Language { get; set; }
    public JobDto JobDto { get; set; }
}