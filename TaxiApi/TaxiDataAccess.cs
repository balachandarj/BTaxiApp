using System.Data.SQLite;
using TaxiApi.Models;

namespace TaxiApi
{

    public class TaxiDataAccess
    {
        private string _dbPath = @"C:\DB\Taxi.db";
        public TaxiDataAccess()
        {
            CreateDB();
        }

        private void CreateDB()
        {

            // Create the SQLite database and table
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={_dbPath};Version=3;"))
            {
                connection.Open();

                string createTableSql = @"
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    FirstName TEXT NOT NULL,
                    LastName TEXT NOT NULL,
                    Email TEXT NOT NULL,
                    Phone TEXT NOT NULL
                )";

                using (SQLiteCommand createTableCommand = new SQLiteCommand(createTableSql, connection))
                {
                    createTableCommand.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public User AddUser(User newUser)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={_dbPath};Version=3;"))
            {
                connection.Open();

                // SQL command to insert a new user
                string insertUserSql = @"
                INSERT INTO Users (FirstName, LastName, Email, Phone)
                VALUES (@FirstName, @LastName, @Email, @Phone)";

                using (SQLiteCommand insertUserCommand = new SQLiteCommand(insertUserSql, connection))
                {
                    insertUserCommand.Parameters.AddWithValue("@FirstName", newUser.FirstName);
                    insertUserCommand.Parameters.AddWithValue("@LastName", newUser.LastName);
                    insertUserCommand.Parameters.AddWithValue("@Email", newUser.Email);
                    insertUserCommand.Parameters.AddWithValue("@Phone", newUser.Phone);

                    // Execute the INSERT command
                    insertUserCommand.ExecuteNonQuery();
                }

                connection.Close();
            }
            return newUser;
        }

        public List<User> GetUsers()
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={_dbPath};Version=3;"))
            {
                connection.Open();
                // SQL command to select all users
                string selectAllUsersSql = "SELECT * FROM Users";
                List<User> userList = new List<User>();
                using (SQLiteCommand selectAllUsersCommand = new SQLiteCommand(selectAllUsersSql, connection))
                {
                    using (SQLiteDataReader reader = selectAllUsersCommand.ExecuteReader())
                    {
                       

                        while (reader.Read())
                        {
                            User user = new User
                            {
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Email = reader["Email"].ToString(),
                                Phone = reader["Phone"].ToString()
                            };

                            userList.Add(user);
                        }
                    }


                }
                return userList;
            }

        }
    }
}
