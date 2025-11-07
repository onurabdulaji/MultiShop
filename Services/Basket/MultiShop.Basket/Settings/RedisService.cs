using StackExchange.Redis;

namespace MultiShop.Basket.Settings
{
    public class RedisService
    {
        private readonly ConnectionMultiplexer _connectionMultiplexer;

        public RedisService(string host, int port)
        {
            _connectionMultiplexer = ConnectionMultiplexer.Connect($"{host}:{port}");
        }

        public IDatabase GetDb(int db = 0)
        {
            return _connectionMultiplexer.GetDatabase(db);
        }
    }
}
