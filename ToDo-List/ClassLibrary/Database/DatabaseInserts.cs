namespace ClassLibrary.Database
{
    public partial class Database
    {
        /// <summary>
        /// Inserts a user to the database
        /// </summary>
        /// <param name="user">The user to be insertet</param>
        /// <returns>The insertet user</returns>
        public User InsertUser(User user)
        {
            string sqlInsert = $@"EXEC InsertUser {user.Username}, '{user.Password}'";
            ExecuteSqlCommand(sqlInsert);
            return user;
        }

        /// <summary>
        /// Inserts the creates auction into the database
        /// </summary>
        /// <param name="todo">The todo to create</param>
        /// <returns>The todo created</returns>
        public ToDo CreateToDo(ToDo todo)
        {
            string sqlInsert = $@"EXEC CreateTodo {todo.Username}, '{todo.Description}'";
            ExecuteSqlCommand(sqlInsert);
            return todo;
        }
    }
}
