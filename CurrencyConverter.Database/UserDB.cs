using CurrencyConverter.Models;

using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Database
{
    public class UserDB : IUserRepo
    {
        public void Create(UserModel user)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserModel.Usernames username)
        {
            throw new NotImplementedException();
        }

        public UserModel Get(UserModel.Usernames username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public string GetConnectionString(string name = "SQLiteConnection")
        {
            var config = new ConfigurationBuilder()

            string connString = config.GetConnectionString("SQLiteConnection");
            return connString;
        }

        public void Update(UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
