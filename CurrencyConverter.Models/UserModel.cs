using System.ComponentModel.DataAnnotations;

namespace CurrencyConverter.Models
{
    public class UserModel
    {
        [Key]
        public Usernames Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public UserModel(string username, string password)
        {
            Enum.TryParse(username, out Usernames Username);
            Password = password;
        }

        public UserModel() { }

        public enum Usernames
        {
            Babis,
            Admin,
            User
        }
    }
}