using CurrencyConverter.Models;


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
