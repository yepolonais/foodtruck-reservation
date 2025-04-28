using AspNetCore.Identity.Mongo.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace truckspot_api.Modules.Auth.Models;

public class User: MongoUser
{
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
}