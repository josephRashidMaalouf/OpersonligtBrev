using JobSeekerAssistant.Domain.Entities;

namespace JobSeekerAssistant.Application.Interfaces;

public interface ILetterRepository<TUserId> : IRepository<Letter, string>
{
    Task<IEnumerable<Letter>> GetAllByUserIdAsync(TUserId userId);

    
}