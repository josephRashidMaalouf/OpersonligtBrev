using JobSeekerAssistant.Domain.Dtos;
using JobSeekerAssistant.Domain.Entities;

namespace JobSeekerAssistant.Application.Interfaces.Services;

public interface IPromptService
{
    Task<string> GeneratePromptForLetterAsync(JobDto job, Resume resume, string language);
}