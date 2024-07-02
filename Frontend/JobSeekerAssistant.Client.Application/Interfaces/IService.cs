using JobSeekerAssistant.Client.Domain.Interfaces;

namespace JobSeekerAssistant.Client.Application.Interfaces;

public interface IService<TModel, TId, TUserId> where TModel : IModel<TId>
{
    Task<IEnumerable<TModel>> GetAllByUserIdAsync(TUserId id);
    Task<bool> UpdateAsync(TId id, TModel model);
    Task<bool> DeleteAsync(TId id);
}