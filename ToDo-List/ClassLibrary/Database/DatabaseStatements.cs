using System.Data.SqlClient;

namespace ClassLibrary.Database
{
    public partial class Database
    {
        /// <summary>
        /// Database statements to create tables, if they arent already created.
        /// </summary>
        public static void DatabaseStamenets()
        {
            using (var connection = GetDatabaseConnection())
            {
                SqlCommand command = connection.CreateCommand();

                string[] SQLStatements = {
                @"CREATE TABLE Users(
                    userID INT IDENTITY(1,1),
                    username VARCHAR(25) PRIMARY KEY NOT NULL,
					[password] VARCHAR(200) NOT NULL,
	                dateCreated DATETIME NOT NULL
                );",

                @"CREATE TABLE ToDos(
					ToDoID INT PRIMARY KEY IDENTITY(1,1),
					username_FK VARCHAR(25) FOREIGN KEY REFERENCES Users(username) NOT NULL,
					[description] VARCHAR(MAX) NOT NULL
				);"
                };

                foreach (var item in SQLStatements)
                {
                    command.CommandText = item;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
