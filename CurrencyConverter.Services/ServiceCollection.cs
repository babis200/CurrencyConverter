using CurrencyConverter.Database;

namespace CurrencyConverter.Services
{
    public class ServiceCollection
    {
        public string _connectionString;

        public string _fastFOREX;

        public CurrencyService CurrencyService;

        public UserService UserService;

        public ServiceCollection(string conString, string key)
        {
            _connectionString = conString;
            _fastFOREX = key;

            CurrencyService = new CurrencyService(_fastFOREX);

            UserService = new UserService(new UserDB(_connectionString));
        }
    }
}
