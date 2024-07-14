using JobSeekerAssistant.Application.Interfaces.Repositories;
using JobSeekerAssistant.Application.Interfaces.Services;
using JobSeekerAssistant.Domain.Dtos;
using JobSeekerAssistant.Domain.Entities;
using JobSeekerAssistant.Domain.Entities.Identity;

namespace JobSeekerAssistant.Application.Services;

public class LetterService(ILetterRepository<string> letterRepository) : ILetterService<string>
{
    private readonly ILetterRepository<string> _letterRepository = letterRepository;
    public async Task<IEnumerable<Letter>> GetAllByUserIdAsync(string userId)
    {
        var letters = await _letterRepository.GetAllByUserIdAsync(userId);
        return letters;
    }

    public async Task<IEnumerable<Letter>> GetAllByUserEmailAsync(string userEmail)
    {
        var letters = await _letterRepository.GetAllByUserEmailAsync(userEmail);
        return letters;
    }


    public async Task<Letter?> GetByIdAsync(string id)
    {
        var letter = await _letterRepository.GetByIdAsync(id);

        return letter;
    }

    public async Task AddAsync(Letter entity)
    {
        await _letterRepository.AddAsync(entity);
    }

    public async Task UpdateAsync(Letter entity, string id)
    {
        await _letterRepository.UpdateAsync(entity, id);
    }

    public async Task DeleteAsync(string id)
    {
        await _letterRepository.DeleteAsync(id);
    }
}