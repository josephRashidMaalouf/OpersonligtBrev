using JobSeekerAssistant.Client.Domain.Models;

namespace JobSeekerAssistant.Client.Application.Interfaces;

public interface IResumeService : IService<ResumeModel, string, string>
{
    Task<bool> PostAsync(ResumeModel resumeModel);
}