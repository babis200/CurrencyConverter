using CurrencyConverter.Database;
using CurrencyConverter.Models;

using System.Text;

namespace CurrencyConverter.Services
{
    public class UserService
    {
        private IUserRepo _userDatabase;

        public UserService(IUserRepo userDatabase)
        {
            _userDatabase = userDatabase;
        }

        public string EncryptPassword(string password)
        {
            byte[] data = Encoding.ASCII.GetBytes(password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = Encoding.ASCII.GetString(data);

            return hash;
        }

        public bool ValidateUser(UserModel user)
        {
            if (_userDatabase.Get(Enum.GetName(typeof(UserModel.Usernames), user.Username)).Password == EncryptPassword(user.Password))
                return true;
            return false;
        }

        public void Add(UserModel user)
        {
            user.Password = EncryptPassword(user.Password);
            _userDatabase.Add(user);
        }

        public UserModel Get(string username)
        {
            return _userDatabase.Get(username);
        }
    }
}
