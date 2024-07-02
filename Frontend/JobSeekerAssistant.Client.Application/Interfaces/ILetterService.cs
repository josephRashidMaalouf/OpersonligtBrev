using JobSeekerAssistant.Client.Domain.Models;
using JobSeekerAssistant.Domain.Dtos;

namespace JobSeekerAssistant.Client.Application.Interfaces;

public interface ILetterService : IService<LetterModel, string, string>
{
    Task<LetterModel?> GenerateLetterAsync(string resumeId, PromptRequestDto promptRequest);
    Task<LetterModel?> GetByIdAsync(string letterId);
}