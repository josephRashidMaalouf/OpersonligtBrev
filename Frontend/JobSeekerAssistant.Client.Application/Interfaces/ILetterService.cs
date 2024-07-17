using JobSeekerAssistant.Client.Domain.Dtos;
using JobSeekerAssistant.Client.Domain.Models;

namespace JobSeekerAssistant.Client.Application.Interfaces;

public interface ILetterService : IService<LetterModel, string, string>
{
    Task<LetterModel?> GenerateLetterAsync(string resumeId, PromptRequestDto promptRequest);
    Task<LetterModel?> GetByIdAsync(string letterId);
}