using JobSeekerAssistant.Domain.Entities;
using JobSeekerAssistant.Domain.Interfaces;

namespace JobSeekerAssistant.Application.Interfaces.Repositories;

public interface IResumeRepository<TUserId> : IRepository<Resume, string>
{
    Task<IEnumerable<Resume>> GetAllByUserIdAsync(TUserId userId);
    Task<IEnumerable<Resume>> GetAllByUserEmailasync(string userEmail);

}