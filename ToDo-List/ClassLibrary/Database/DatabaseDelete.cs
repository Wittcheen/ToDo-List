namespace ClassLibrary.Database
{
    public partial class Database
    {
        /// <summary>
        /// Deletes a todo from the database with the id
        /// </summary>
        /// <param name="todoID">The id of the todo</param>
        public void DeleteToDo(int toDoID)
        {
            string sqlInsert = $@"DELETE FROM ToDos WHERE ToDoID = {toDoID}";
            ExecuteSqlCommand(sqlInsert);
        }
    }
}
