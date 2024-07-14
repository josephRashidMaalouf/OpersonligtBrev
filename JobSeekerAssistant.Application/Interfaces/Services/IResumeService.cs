using JobSeekerAssistant.Domain.Entities;

namespace JobSeekerAssistant.Application.Interfaces.Services;

public interface IResumeService<TUserId> : IService<Resume, string>
{
    Task<IEnumerable<Resume>> GetAllByUserIdAsync(TUserId userId);
    Task<IEnumerable<Resume>> GetAllByUserEmailAsync(string userEmail);

}