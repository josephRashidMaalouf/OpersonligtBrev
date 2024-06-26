using JobSeekerAssistant.Domain.Interfaces;
using System.Security.Cryptography;

namespace JobSeekerAssistant.Application.Interfaces.Services;

public interface IService<TEntity, TId> where TEntity : IEntity<TId>
{
    Task<TEntity?> GetByIdAsync(TId id);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity, TId id);
    Task DeleteAsync(TId id);
}