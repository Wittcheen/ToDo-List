namespace ClassLibrary.Database
{
    public partial class Database
    {
        /// <summary>
        /// Updates a todo from the database with the id
        /// </summary>
        /// <param name="toDo">The new todo</param>
        /// <param name="toDoID">The id of the todo</param>
        public void EditToDo(ToDo toDo, int toDoID)
        {
            string sqlInsert = $@"UPDATE ToDos SET description = '{toDo.Description}' WHERE ToDoID = {toDoID}";
            ExecuteSqlCommand(sqlInsert);
        }
    }
}
