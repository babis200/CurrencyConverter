namespace CurrencyConverter.Services
{
    public interface IConfigManager
    {
        string fastFOREXKey { get; }

        string GetConnectionString(string connectionName);

    }
}
