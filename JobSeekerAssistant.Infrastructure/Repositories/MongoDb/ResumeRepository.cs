using JobSeekerAssistant.Application.Interfaces;
using JobSeekerAssistant.Domain.Entities;
using MongoDB.Driver;

namespace JobSeekerAssistant.Infrastructure.Repositories.MongoDb;

public class ResumeRepository(string collectionName, string connectionString) : MongoRepositoryBase<Resume, string>(collectionName, connectionString), IResumeRepository<string> 
{
    
    public async Task<IEnumerable<Resume>> GetAllByUserIdAsync(string userId)
    {
        var collection = ConnectToMongo<Resume>();

        var filter = Builders<Resume>.Filter.Eq("UserId", userId);

        var resumes = await collection.FindAsync(filter);

        return await resumes.ToListAsync();
    }
}