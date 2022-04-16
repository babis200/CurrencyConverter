using CurrencyConverter.Services;

namespace CurrencyConverter
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ServiceCollection serviceCollection = new ServiceCollection("Data Source=.\\AppDB.db;", "f0099a65ea-5b6494a5ac-ra8iig");

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginView(serviceCollection));
        }
    }
}