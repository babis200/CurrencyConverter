using CurrencyConverter.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CurrencyConverter.Database
{
    public interface IUserRepo
    {
        public void Add(UserModel user);

        public void Update(UserModel user);

        public void Delete(string username);

        public IEnumerable<UserModel> GetAll();

        public UserModel Get(string username);

    }
}
