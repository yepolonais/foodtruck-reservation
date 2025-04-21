using MongoDB.Driver;
using truckspot_api.Config.Database;
using truckspot_api.Modules.Auth.Models;

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
        return await _usersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(User newUser)
    {
         await _usersCollection.InsertOneAsync(newUser);
    }

    public async Task UpdateAsync(string id, User updatedUser)
    {
        await _usersCollection.ReplaceOneAsync(x => x.Id == id, updatedUser);
    }

    public async Task RemoveAsync(string id) =>
        await _usersCollection.DeleteOneAsync(x => x.Id == id);
}