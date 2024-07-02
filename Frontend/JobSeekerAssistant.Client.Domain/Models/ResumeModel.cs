using JobSeekerAssistant.Client.Domain.Interfaces;

namespace JobSeekerAssistant.Client.Domain.Models;

public class ResumeModel:  IModel<string> 
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<string> Skills { get; set; }
    public List<string> Languages { get; set; }
    public List<ResumeWorkItemModel> ResumeWorkItems { get; set; }
    public  Type { get; set; }
}