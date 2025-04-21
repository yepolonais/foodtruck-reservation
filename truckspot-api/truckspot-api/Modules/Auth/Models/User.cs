using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace truckspot_api.Modules.Auth.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
}