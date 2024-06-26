namespace JobSeekerAssistant.Domain.Dtos;

public class GptDto
{
    public string Model { get; set; } = "gpt-4o-2024-05-13";
    public IEnumerable<GptMessageDto> Messages { get; set; }
}