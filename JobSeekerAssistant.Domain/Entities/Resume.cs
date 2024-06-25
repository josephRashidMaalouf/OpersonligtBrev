namespace JobSeekerAssistant.Domain.Entities;

public class Resume
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public string Name { get; set; }
    public string AboutMe { get; set; }
    public IEnumerable<string> Skills { get; set; }
    public IEnumerable<string> Languages { get; set; }
    public IEnumerable<ResumeWorkItem> WorkItems { get; set; }
    public IEnumerable<ResumeEducationItem> EducationItems { get; set; }

}