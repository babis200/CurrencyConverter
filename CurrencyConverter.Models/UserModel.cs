using System.ComponentModel.DataAnnotations;

namespace CurrencyConverter.Models
{
    public class UserModel
    {
        [Key]
        public Usernames Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }        //TODO - password not null warning check


        public enum Usernames
        {
            Babis,
            Admin,
            User
        }
    }
}