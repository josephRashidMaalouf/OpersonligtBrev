using JobSeekerAssistant.Client.Domain.Interfaces;

namespace JobSeekerAssistant.Client.Application.Interfaces;

public interface IService<TDto, TId> where TDto : IDto<TId>
{
    public Task<IEnumerable<TDto>> GetAllByUserIdAsync(string userId);
    public Task<bool> UpdateAsync(string userId);
    public Task<bool> DeleteAsync(string userId);
}