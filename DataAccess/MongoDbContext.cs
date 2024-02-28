namespace Mausam.DataAccess
{
    using Microsoft.AspNetCore.Identity;
    using MongoDB.Driver;
    using Microsoft.Extensions.Configuration;
    using Microsoft.AspNet.Identity.EntityFramework;
    using IdentityUser = Microsoft.AspNet.Identity.EntityFramework.IdentityUser;
    using MongoDB.Bson.Serialization.Attributes;


    [BsonIgnoreExtraElements]
    public class ApplicationUser : IdentityUser
    {
        // Add any additional fields you need
    }

    public class ApplicationDbContext
    {
        private readonly IMongoCollection<ApplicationUser> _users;

        public ApplicationDbContext(IMongoDatabase database)
        {
            _users = database.GetCollection<ApplicationUser>("Users");
        }

        public IMongoCollection<ApplicationUser> Users => _users;
    }

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

        public IMongoDatabase Database => _database;

        // Add your MongoDB collections here as properties
        // e.g., public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
    }
}
