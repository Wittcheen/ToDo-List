using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Database
{
    public partial class Database
    {
        /// <summary>
        /// Gets all the users from the database
        /// </summary
        /// <returns>List with all the users</returns>
        public ObservableCollection<User> ImportAllUsers()
        {
            ObservableCollection<User> users = new();
            using (var connection = GetDatabaseConnection())
            {
                SqlDataReader reader = ExecuteReader(connection, "SELECT userID, username, password FROM chri36ky2.SKOLE");
                try
                {
                    while (reader.Read())
                    {
                        User user = new(reader.GetString(1), reader.GetString(2))
                        {
                            ID = reader.GetInt32(0)
                        };
                        users.Add(user);
                    }
                }
                catch (Exception)
                {
                }
            }
            return users;
        }

        /// <summary>
        /// Gets all the todos from the database, that a user created
        /// </summary>
        /// <param name="username">The user to check</param>
        /// <returns>List with todos, that the user created</returns>
        public ObservableCollection<ToDo> ImportUsersToDos(string username)
        {
            ObservableCollection<ToDo> toDos = new();
            using (var connection = GetDatabaseConnection())
            {
                SqlDataReader reader = ExecuteReader(connection, "SELECT ToDoID, username_FK, description" +
                    "FROM chri36ky2.SKOLE WHERE username_FK LIKE '" + username + "'");
                try
                {
                    while (reader.Read())
                    {
                        ToDo todo = new(reader.GetString(1), reader.GetString(2))
                        {
                            ID = reader.GetInt32(0)
                        };
                        toDos.Add(todo);
                    }
                }
                catch (Exception)
                {
                }
            }
            return toDos;
        }
    }
}
