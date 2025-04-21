using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace truckspot_api.Config.Database;

public class TruckSpotDatabaseService
{
    public IMongoClient Client { get; }
    public IMongoDatabase Database { get; }

    public TruckSpotDatabaseService(IOptions<TruckSpotDatabaseSettings> settings)
    {
        Client = new MongoClient(settings.Value.ConnectionString);
        Database = Client.GetDatabase(settings.Value.DatabaseName);
    }

    public IMongoCollection<T> GetCollection<T>(string collectionName)
    {
        return Database.GetCollection<T>(collectionName);
    }

}