using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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

        /// <summary>
        /// Hashes the password, so it's harder to see in the database
        /// </summary>
        /// <param name="password">The password to be hashed</param>
        /// <returns>Returns the hashed password</returns>
        public string HashPassword(string password)
        {
            HashAlgorithm sha = SHA256.Create();
            byte[] result = sha.ComputeHash(Encoding.ASCII.GetBytes(password));
            string passwordHashed = Convert.ToBase64String(result);
            return passwordHashed;
        }

        /// <summary>
        /// Validates the users login
        /// </summary>
        /// <param name="loginUserName"></param>
        /// <param name="loginPassword"></param>
        /// <returns>Returns boolean</returns>
        public bool ValidateLogin(string loginUserName, string loginPassword)
        {
            string HashedPassword = HashPassword(loginPassword);
            ObservableCollection<User> users = Database.Database.Instance.ImportAllUsers();

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Username == loginUserName)
                {
                    if (users[i].Password == HashedPassword)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
