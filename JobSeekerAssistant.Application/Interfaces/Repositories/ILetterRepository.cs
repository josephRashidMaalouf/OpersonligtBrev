using JobSeekerAssistant.Domain.Entities;

namespace JobSeekerAssistant.Application.Interfaces.Repositories;

public interface ILetterRepository<TUserId> : IRepository<Letter, string>
{
    Task<IEnumerable<Letter>> GetAllByUserIdAsync(TUserId userId);


}