using JobSeekerAssistant.Domain.Entities;
using JobSeekerAssistant.Domain.Interfaces;

namespace JobSeekerAssistant.Application.Interfaces;

public interface IResumeRepository<TUserId> : IRepository<Resume, string>
{
    Task<Resume> GetAllByUserIdAsync(TUserId userId);

}