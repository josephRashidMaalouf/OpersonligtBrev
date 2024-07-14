using JobSeekerAssistant.Client.Domain.Interfaces;
namespace JobSeekerAssistant.Client.Domain.Models;

public class ResumeModel:  IModel<string> 
{
    public string Id { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;
    public string Name { get; set; }
    public string AboutMe { get; set; }
    public List<string> Skills { get; set; } = new();
    public List<string> Languages { get; set; } = new();
    public List<ResumeWorkItem> WorkItems { get; set; } = new();
    public List<ResumeEducationItem> EducationItems { get; set; } = new();

}