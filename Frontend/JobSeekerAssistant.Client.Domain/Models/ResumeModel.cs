using JobSeekerAssistant.Client.Domain.Interfaces;
using JobSeekerAssistant.Domain.Entities;

namespace JobSeekerAssistant.Client.Domain.Models;

public class ResumeModel:  IModel<string> 
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public string Name { get; set; }
    public List<string> Skills { get; set; }
    public List<string> Languages { get; set; }
    public List<ResumeWorkItem> ResumeWorkItems { get; set; } = new();
    public List<ResumeEducationItem> ResumeEducationItems { get; set; } = new();

}