using JobSeekerAssistant.Application.Interfaces;
using JobSeekerAssistant.Domain.Interfaces;
using MongoDB.Driver;

namespace JobSeekerAssistant.Infrastructure.Repositories.MongoDb;

public abstract class MongoRepositoryBase<TEntity, TId>(string collectionName, string connectionString) : IRepository<TEntity, TId> where TEntity : IEntity<TId>
{
    protected const string DataBaseName = "JobSeekerAssistantDb";

    protected readonly string ConnectionsString = connectionString;
    protected readonly string _collectionName = collectionName;

    protected IMongoCollection<T> ConnectToMongo<T>()
    {
        var client = new MongoClient(ConnectionsString);
        var db = client.GetDatabase(DataBaseName);
        return db.GetCollection<T>(_collectionName);
    }

    public async Task<TEntity> GetByIdAsync(TId id)
    {
        var collection = ConnectToMongo<TEntity>();

        var filter = Builders<TEntity>.Filter.Eq("Id", id);

        var entity = await collection.Find(filter).FirstOrDefaultAsync();

        return entity;
    }

    public async Task AddAsync(TEntity entity)
    {
        var collection = ConnectToMongo<TEntity>();

        await collection.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(TEntity entity, TId id)
    {
        var collection = ConnectToMongo<TEntity>();

        var filter = Builders<TEntity>.Filter.Eq("Id", id);
        var options = new ReplaceOptions() { IsUpsert = true };

        await collection.ReplaceOneAsync(filter, entity, options);
    }

    public async Task DeleteAsync(TId id)
    {
        var collection = ConnectToMongo<TEntity>();

        var filter = Builders<TEntity>.Filter.Eq("Id", id);

        await collection.DeleteOneAsync(filter);
    }
}