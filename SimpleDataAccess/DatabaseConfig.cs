namespace EazyMoney.Config
{
    public class DatabaseConfig
    {
        public string CONNECTION_STRING { get; }
        public string DATABASE { get; }

        public DatabaseConfig(Config p_config)
        {
            CONNECTION_STRING = p_config["Database:ConnectionString"];
            DATABASE = p_config["Database:Database"];
        }
    }
}