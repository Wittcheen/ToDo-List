using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace ClassLibrary
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public User(string username)
        {
            Username = username;
        }

        /// <summary>
        /// Hashes the password, so it's harder to see in the database
        /// </summary>
        /// <param name="password">The password to be hashed</param>
        /// <returns>Returns the hashed password</returns>
        public static string HashPassword(string password)
        {
            HashAlgorithm sha = SHA256.Create();
            byte[] result = sha.ComputeHash(Encoding.ASCII.GetBytes(password));
            string passwordHashed = Convert.ToBase64String(result);
            return passwordHashed;
        }

        /// <summary>
        /// Validates the users login
        /// </summary>
        /// <param name="loginUsername"></param>
        /// <param name="loginPassword"></param>
        /// <returns>Returns boolean</returns>
        public static bool ValidateLogin(string loginUsername, string loginPassword)
        {
            string hashedPassword = HashPassword(loginPassword);
            string query = $"SELECT count(*) FROM Users WHERE username='{loginUsername}' AND password='{hashedPassword}'";

            using (SqlConnection conn = Database.Database.GetDatabaseConnection())
            {
                SqlCommand cmd = new(query, conn);
                int numrows = (int)cmd.ExecuteScalar();
                
                if (numrows == 1)
                {
                    return true;
                }
                else { return false; }
            }
        }

        /// <summary>
        /// Checks if the user already exist in the database
        /// </summary>
        /// <param name="loginUsername"></param>
        /// <returns>Returns boolean</returns>
        public static bool UserExist(string loginUsername)
        {
            string query = $"SELECT count(*) FROM Users WHERE username='{loginUsername}'";

            using (SqlConnection conn = Database.Database.GetDatabaseConnection())
            {
                SqlCommand cmd = new(query, conn);
                int numrows = (int)cmd.ExecuteScalar();

                if (numrows == 0)
                {
                    return false;
                }
                else { return true; }
            }
        }
    }
}
