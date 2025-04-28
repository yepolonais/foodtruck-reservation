using MongoDB.Driver;
using truckspot_api.Config.Database;
using truckspot_api.Modules.Auth.Models;
using MongoDB.Bson;
namespace truckspot_api.Modules.Auth.Repositories;

public class UserRepository
{
    private readonly IMongoCollection<User> _usersCollection;

    public UserRepository(TruckSpotDatabaseService mongo)
    {
        _usersCollection = mongo.GetCollection<User>("Users");
    }
    
    public async Task<List<User>> GetAllAsync()
    {
        return await _usersCollection.Find(_ => true).ToListAsync();
    }


    public async Task<User?> GetAsync(string id)
    {
        var objectId = ObjectId.Parse(id);
        return await _usersCollection.Find(x => x.Id == objectId).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(User newUser)
    {
         await _usersCollection.InsertOneAsync(newUser);
    }

    public async Task UpdateAsync(string id, User updatedUser)
    {
        var objectId = ObjectId.Parse(id);
        await _usersCollection.ReplaceOneAsync(x => x.Id == objectId, updatedUser);
    }

    public async Task RemoveAsync(string id)
    {
        var objectId = ObjectId.Parse(id);

        await _usersCollection.DeleteOneAsync(x => x.Id == objectId);
    }
    
    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _usersCollection.Find(u => u.Email == email).FirstOrDefaultAsync();
    }   
    
}