using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Services
{
    public class ServiceCollection
    {
        public string connectionString;

        public string fastFOREX;

        public CurrencyService CurrencyService;

        public UserService UserService;

        public ServiceCollection()
        {
            CurrencyService = new CurrencyService();

            UserService = new UserService();
        }
    }
}
