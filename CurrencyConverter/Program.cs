using CurrencyConverter.Services;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

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
            ServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.connectionString = "Data Source=.\\AppDB.db;Version=3;";
            serviceCollection.fastFOREX = "f0099a65ea-5b6494a5ac-ra8iig";
            
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainView(serviceCollection));
        }
    }
}