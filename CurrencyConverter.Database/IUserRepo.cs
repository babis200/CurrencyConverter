using CurrencyConverter.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static CurrencyConverter.Models.UserModel;

namespace CurrencyConverter.Database
{
    public interface IUserRepo
    {
        public void Create(UserModel user);

        public void Update(UserModel user);

        public void Delete(Usernames username);

        public IEnumerable<UserModel> GetAll();

        public UserModel Get(Usernames username);

        public string GetConnectionString(string name = "SQLiteConnection");
    }
}
