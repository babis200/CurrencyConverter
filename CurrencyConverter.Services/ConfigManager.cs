using Microsoft.Extensions.Configuration;

namespace CurrencyConverter.Services
{
    public class ConfigManager : IConfigManager
    {
        private readonly IConfiguration _configuration;

        public ConfigManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string fastFOREXKey
        {
            get
            {
                return _configuration["APIKeys:fastFOREX"];
            }
        }

        public string GetConnectionString(string connectionName)
        {
            return _configuration.GetConnectionString(connectionName);
        }

    }
}
