using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashAlgorithm sha = SHA256.Create(); //Make a HashAlgorithm object for makeing hash computations.
            byte[] result = sha.ComputeHash(Encoding.ASCII.GetBytes("yhu24sae")); //Encodes the password into a hash in a Byte array.

            foreach (byte b in result)
            {
                Console.WriteLine(b);
            }
        }
    }
}