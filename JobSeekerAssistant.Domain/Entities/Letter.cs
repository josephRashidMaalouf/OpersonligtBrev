using JobSeekerAssistant.Domain.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JobSeekerAssistant.Domain.Entities;

public class Letter : IEntity<string>
{
    [BsonId, BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string UserId { get; set; }
    public string Text { get; set; }

}