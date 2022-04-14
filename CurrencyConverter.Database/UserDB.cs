using CurrencyConverter.Models;

using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Database
{
    public class UserDB : IUserRepo
    {
        private string _connectionString;

        public UserDB(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(UserModel user)
        {
            string query = "INSERT INTO Users VALUES(@name, @pwd)";
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@name", Enum.GetName(typeof(UserModel.Usernames), user.Username));
                command.Parameters.AddWithValue("@pwd", user.Password);
                connection.Open();
                
                command.ExecuteScalar();
            }
        }

        public void Delete(string username)
        {
            throw new NotImplementedException();
        }

        public UserModel Get(string username)
        {
            string query = "SELECT * FROM Users WHERE Username = @name";
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@name", username);
                connection.Open();

                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return new UserModel(reader.GetString(0), reader.GetString(1));
                    }
                }              
                reader.Close();
                return null;
            }
        }

        public IEnumerable<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
