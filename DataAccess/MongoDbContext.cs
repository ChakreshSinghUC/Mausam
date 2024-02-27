namespace Mausam.DataAccess
{
	using Microsoft.Extensions.Configuration;
	using MongoDB.Driver;
	public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDBConnection");
            var databaseName = configuration.GetValue<string>("MongoDBDatabaseName");

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        // Add your MongoDB collections here as properties, e.g., public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
    }
}
