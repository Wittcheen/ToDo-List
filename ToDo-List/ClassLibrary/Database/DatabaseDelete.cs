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
        /// Deletes a todo from the database with the id
        /// </summary>
        /// <param name="todoID">The id of the todo</param>
        public void DeleteToDo(int todoID)
        {
            string sqlInsert = $@"DELETE FROM ToDos WHERE ToDoID = {todoID}";
            ExecuteSqlCommand(sqlInsert);
        }
    }
}
