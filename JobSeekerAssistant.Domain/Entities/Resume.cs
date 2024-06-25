using JobSeekerAssistant.Domain.Interfaces;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace JobSeekerAssistant.Domain.Entities;

public class Resume : IEntity<string>
{
    [BsonId, BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string UserId { get; set; }
    public string Name { get; set; }
    public string AboutMe { get; set; }
    public IEnumerable<string> Skills { get; set; }
    public IEnumerable<string> Languages { get; set; }
    public IEnumerable<ResumeWorkItem> WorkItems { get; set; }
    public IEnumerable<ResumeEducationItem> EducationItems { get; set; }

}