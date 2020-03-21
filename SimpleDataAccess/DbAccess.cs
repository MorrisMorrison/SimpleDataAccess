using EazyMoney.Config;
using MongoDB.Driver;

namespace SimpleDataAccess
{
    
    public interface IDbAccess
    {
        IMongoDatabase GetDatabase();
        IMongoCollection<T> GetCollection<T>();
    }


    public class DbAccess:IDbAccess
    {
        
        private  string _connectionString { get; set; }
        private  MongoClient _client { get; set; }
        private  IMongoDatabase _database { get; set; }
        private DatabaseConfig Config {get;set;}

        public DbAccess(Config p_config){
            Config = new DatabaseConfig(p_config);
        }

        public  IMongoDatabase GetDatabase()
        {
            if (_database != null) return _database;

            _connectionString = Config.CONNECTION_STRING;
            _client = new MongoClient(connectionString: _connectionString + "?retryWrites=false");
            _database = _client.GetDatabase(Config.DATABASE);

            return _database;
        }

        public IMongoCollection<T> GetCollection<T>()
        {
           return  GetDatabase().GetCollection<T>(typeof(T).Name);
        }
        
    }
}