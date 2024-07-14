using JobSeekerAssistant.Client.Domain.Interfaces;
namespace JobSeekerAssistant.Client.Domain.Models;

public class ResumeModel:  IModel<string> 
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public string Name { get; set; }
    public string AboutMe { get; set; }
    public List<string> Skills { get; set; } = new();
    public List<string> Languages { get; set; } = new();
    public List<ResumeWorkItem> ResumeWorkItems { get; set; } = new();
    public List<ResumeEducationItem> ResumeEducationItems { get; set; } = new();

}