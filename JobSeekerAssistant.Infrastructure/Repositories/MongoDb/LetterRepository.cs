using JobSeekerAssistant.Application.Interfaces;
using JobSeekerAssistant.Domain.Entities;
using MongoDB.Driver;

namespace JobSeekerAssistant.Infrastructure.Repositories.MongoDb;

public class LetterRepository(string collectionName, string connectionString) : MongoRepositoryBase<Letter, string>(collectionName, connectionString), ILetterRepository<string>
{
    public async Task<IEnumerable<Letter>> GetAllByUserIdAsync(string userId)
    {
        var collection = ConnectToMongo<Letter>();

        var filter = Builders<Letter>.Filter.Eq("UserId", userId);

        var letters = await collection.FindAsync(filter);

        return await letters.ToListAsync();
    }
}