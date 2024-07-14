using JobSeekerAssistant.Application.Interfaces.Repositories;
using JobSeekerAssistant.Domain.Entities;
using JobSeekerAssistant.Domain.Entities.Identity;
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

    public async Task<IEnumerable<Resume>> GetAllByUserEmailAsync(string userEmail)
    {
        var collection = ConnectToMongo<Resume>();

        var filter = Builders<Resume>.Filter.Eq("UserEmail", userEmail);

        var resumes = await collection.FindAsync(filter);

        return await resumes.ToListAsync();
    }
}