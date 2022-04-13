using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Services
{
    public interface IConfigManager
    {
        string fastFOREXKey { get; }

        string GetConnectionString(string connectionName);

    }
}
