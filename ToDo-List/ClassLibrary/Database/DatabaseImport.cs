using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace ClassLibrary.Database
{
    public partial class Database
    {
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
                SqlDataReader reader = ExecuteReader(connection, "SELECT ToDoID, username_FK, description " +
                    "FROM ToDos WHERE username_FK LIKE '" + username + "'");
                try
                {
                    while (reader.Read())
                    {
                        ToDo toDo = new(reader.GetString(1), reader.GetString(2))
                        {
                            ID = reader.GetInt32(0)
                        };
                        toDos.Add(toDo);
                    }
                }
                catch (Exception)
                {
                }
            }
            return toDos;
        }

        /// <summary>
        /// Gets the users todo from the database from id
        /// </summary>
        /// <param name="username">The user to check</param>
        /// <param name="toDoID">The to-do id</param>
        /// <returns>A todo with the id, that the user created</returns>
        public ToDo ImportUsersToDo(string username, int toDoID)
        {
            ToDo? toDo = null;
            using (var connection = GetDatabaseConnection())
            {
                SqlDataReader reader = ExecuteReader(connection, "SELECT ToDoID, username_FK, description " +
                    "FROM ToDos WHERE username_FK LIKE '" + username + "' AND ToDoID = "+ toDoID);
                try
                {
                    while (reader.Read())
                    {
                        toDo = new(reader.GetString(1), reader.GetString(2))
                        {
                            ID = reader.GetInt32(0)
                        };
                    }
                }
                catch (Exception)
                {
                }
            }
            return toDo;
        }
    }
}
