using JobSeekerAssistant.Application.Interfaces.Repositories;
using JobSeekerAssistant.Application.Interfaces.Services;
using JobSeekerAssistant.Domain.Entities;
using JobSeekerAssistant.Domain.Entities.Identity;

namespace JobSeekerAssistant.Application.Services;

public class ResumeService(IResumeRepository<string> resumeRepository) : IResumeService<string>
{
    private readonly IResumeRepository<string> _resumeRepository = resumeRepository; 
    public async Task<IEnumerable<Resume>> GetAllByUserIdAsync(string userId)
    {
        var resumes = await _resumeRepository.GetAllByUserIdAsync(userId);

        return resumes;
    }

    public async Task<IEnumerable<Resume>> GetAllByUserEmailAsync(string userEmail)
    {
        var resumes = await _resumeRepository.GetAllByUserEmailAsync(userEmail);

        return resumes;
    }

    public async Task<Resume> GetByIdAsync(string id)
    {
        var resume = await _resumeRepository.GetByIdAsync(id);

        return resume;
    }

    public async Task AddAsync(Resume entity)
    {
        await _resumeRepository.AddAsync(entity);
    }

    public async Task UpdateAsync(Resume entity, string id)
    {
        await _resumeRepository.UpdateAsync(entity, id);
    }

    public async Task DeleteAsync(string id)
    {
        await _resumeRepository.DeleteAsync(id);
    }
}