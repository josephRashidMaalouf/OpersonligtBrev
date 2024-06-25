using JobSeekerAssistant.Domain.Interfaces;

namespace JobSeekerAssistant.Application.Interfaces;

public interface IRepository<TEntity, TId> where TEntity : IEntity<TId>
{
    Task<TEntity> GetByIdAsync(TId id);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity, TId id);
    Task DeleteAsync(TId id);

}