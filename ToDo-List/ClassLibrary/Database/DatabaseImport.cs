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
